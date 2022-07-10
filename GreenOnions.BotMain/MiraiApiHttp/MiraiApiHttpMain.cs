using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Microsoft.Extensions.DependencyInjection;
using Mirai.CSharp.Builders;
using Mirai.CSharp.HttpApi.Builder;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.Options;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    public static class MiraiApiHttpMain
    {
        public static async Task Connect(long qqId, string ip, ushort port, string authKey, Action<bool, string> ConnectedEvent)
        {
            try
            {
                // 一套能用的框架, 必须要注册至少一个 Invoker, Parser, Client 和 Handler
                // Invoker 负责消息调度
                // Parser 负责解析消息到具体接口以便调度器调用相关 Handler 下的处理方法
                // Client 负责收发原始数据
                IServiceProvider services = new ServiceCollection().AddMiraiBaseFramework()   // 表示使用基于基础框架的构建器
                                                                   .Services
                                                                   .AddDefaultMiraiHttpFramework() // 表示使用 mirai-api-http 实现的构建器
                                                                   .AddInvoker<MiraiHttpMessageHandlerInvoker>() // 使用默认的调度器
                                                                   .AddHandler<GroupMessage>() // 群消息
                                                                   .AddHandler<FriendMessage>() // 好友消息
                                                                   .AddHandler<TempMessage>() // 临时消息
                                                                   .AddClient<MiraiHttpSession>() // 使用默认的客户端
                                                                   .Services
                                                                   // 由于 MiraiHttpSession 使用 IOptions<MiraiHttpSessionOptions>, 其作为 Singleton 被注册
                                                                   // 配置此项将配置基于此 IServiceProvider 全局的连接配置
                                                                   // 如果你想一个作用域一个配置的话
                                                                   // 自行做一个实现类, 继承MiraiHttpSession, 构造参数中使用 IOptionsSnapshot<MiraiHttpSessionOptions>
                                                                   // 并将其传递给父类的构造参数
                                                                   // 然后在每一个作用域中!先!配置好 IOptionsSnapshot<MiraiHttpSessionOptions>, 再尝试获取 IMiraiHttpSession
                                                                   .Configure<MiraiHttpSessionOptions>(options =>
                                                                   {
                                                                       options.Host = ip;
                                                                       options.Port = port; // 端口
                                                                       options.AuthKey = authKey; // 凭据
                                                                   })
                                                                   .AddLogging()
                                                                   .BuildServiceProvider();
                await using AsyncServiceScope scope = services.CreateAsyncScope(); // 自 .NET 6.0 起才可以如此操作代替上边两句
                services = scope.ServiceProvider;
                IMiraiHttpSession session = services.GetRequiredService<IMiraiHttpSession>(); // 大部分服务都基于接口注册, 请使用接口作为类型解析

                await session.ConnectAsync(qqId); // 填入期望连接到的机器人QQ号

                Cache.SetTaskAtFixedTime();

                IFriendInfo[] IFriendInfos = await session.GetFriendListAsync();
                string nickname = "未知";

                var self = IFriendInfos.Where(m => m.Id == qqId).FirstOrDefault();  //获取自身昵称失败, 部分QQ号好友中不存在自己?
                if (self != null)
                    nickname = self.Name;

                ConnectedEvent?.Invoke(true, nickname);

                BotInfo.QQId = session.QQNumber.Value;

                BotInfo.IsLogin = true;

                PluginManager.Connected(
                    BotInfo.QQId,
                    async (targetId, msg) => await session.SendFriendMessageAsync(targetId, await msg.ToMiraiApiHttpMessages(session, UploadTarget.Friend)),
                    async (targetId, msg) => await session.SendGroupMessageAsync(targetId, await msg.ToMiraiApiHttpMessages(session, UploadTarget.Group)),
                    async (targetId, targetGroup, msg) => await session.SendTempMessageAsync(targetId, targetGroup, await msg.ToMiraiApiHttpMessages(session, UploadTarget.Temp))
                    );

                try
                {
                    RssWorker.StartRssTask(async (msgs, targetId, groupId) =>
                    {
                        if (targetId != -1)
                            _ = session.SendFriendMessageAsync(targetId, await msgs.ToMiraiApiHttpMessages(session, UploadTarget.Friend));
                        else if (groupId != -1)
                            _ = session.SendGroupMessageAsync(groupId, await msgs.ToMiraiApiHttpMessages(session, UploadTarget.Group));
                    });
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage("启动RSS抓取线程发生错误", ex);
                    throw;
                }

                while (true)
                {
                    BotInfo.IsLogin = true;
                    if (Console.ReadLine() == "exit")
                    {
                        BotInfo.IsLogin = false;
                        PluginManager.Disconnected();
                        session.Dispose();
                        ConnectedEvent?.Invoke(false, "");
                        break;
                    }
                    Task.Delay(100).Wait();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                ConnectedEvent?.Invoke(false, ex.Message);
            }
        }
    }
}
