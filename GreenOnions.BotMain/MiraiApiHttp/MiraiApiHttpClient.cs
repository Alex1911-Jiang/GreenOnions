using Google.Protobuf.WellKnownTypes;
using GreenOnions.Interface;
using GreenOnions.RSS;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Microsoft.Extensions.DependencyInjection;
using Mirai.CSharp.Builders;
using Mirai.CSharp.HttpApi.Builder;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.Options;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using Mirai_CSharp.ImageConverter.DependencyInjection;
using Mirai_CSharp.VoiceConverter.DependencyInjection;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    public class MiraiApiHttpClient : MiraiClient
    {
        private CancellationTokenSource? _ts;
        private IMiraiHttpSession _session;
        private AsyncServiceScope _scope;

        public MiraiApiHttpClient(Action<bool, string> connectedEvent) : base(connectedEvent)
        { 
        
        }

        public override async Task Connect(long qqId, string ip, ushort port, string authKey)
        {
            try
            {
                // 一套能用的框架, 必须要注册至少一个 Invoker, Parser, Client 和 Handler
                // Invoker 负责消息调度
                // Parser 负责解析消息到具体接口以便调度器调用相关 Handler 下的处理方法
                // Client 负责收发原始数据
                IServiceProvider services = new ServiceCollection()
                    .AddSkiasharpImageConverter()
                    .AddSilkLameVoiceConverter()
                    .AddMiraiBaseFramework()   // 表示使用基于基础框架的构建器
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
                _scope = services.CreateAsyncScope();
                services = _scope.ServiceProvider;

                _session = services.GetRequiredService<IMiraiHttpSession>(); // 大部分服务都基于接口注册, 请使用接口作为类型解析

                void RecallMessage(int messageId, long targetId, int revokeTime)
                {
                    Task.Delay(revokeTime).ContinueWith(_ => _session.RevokeMessageAsync(messageId, targetId));
                }
                _ts = new CancellationTokenSource();
                await _session.ConnectAsync(qqId, _ts.Token); // 填入期望连接到的机器人QQ号

                BotInfo.Cache.SetTaskAtFixedTime();

                IFriendInfo[] IFriendInfos = await _session.GetFriendListAsync();
                string nickname = "未知";

                var self = IFriendInfos.Where(m => m.Id == qqId).FirstOrDefault();  //获取自身昵称失败, 部分QQ号好友中不存在自己?
                if (self is not null)
                    nickname = self.Name;

                ConnectedEvent?.Invoke(true, nickname);

                BotInfo.Config.QQId = _session.QQNumber!.Value;

                GreenOnionsApi greenOnionsApi = new(
                    async (targetId, msg) =>
                    {
                        if (msg is null)
                            return 0;
                        var miraiMsg = await msg.ToMiraiApiHttpMessages(_session, UploadTarget.Friend);
                        if (miraiMsg is null || miraiMsg.Length == 0)
                            return 0;
                        int sendedFriendMessageId = await _session.SendFriendMessageAsync(targetId, miraiMsg);
                        if (msg.RevokeTime > 0)
                            RecallMessage(sendedFriendMessageId, targetId, msg.RevokeTime * 1000);
                        return sendedFriendMessageId;
                    },
                    async (targetId, msg) =>
                    {
                        if (msg is null)
                            return 0;
                        var miraiMsg = await msg.ToMiraiApiHttpMessages(_session, UploadTarget.Group);
                        if (miraiMsg is null || miraiMsg.Length == 0)
                            return 0;
                        int sendedGroupMessageId = await _session.SendGroupMessageAsync(targetId, miraiMsg);
                        if (msg.RevokeTime > 0)
                            RecallMessage(sendedGroupMessageId, targetId, msg.RevokeTime * 1000);
                        return sendedGroupMessageId;
                    },
                    async (targetId, targetGroup, msg) =>
                    {
                        if (msg is null)
                            return 0;
                        var miraiMsg = await msg.ToMiraiApiHttpMessages(_session, UploadTarget.Temp);
                        if (miraiMsg is null || miraiMsg.Length == 0)
                            return 0;
                        int sendedTempMessageId = await _session.SendTempMessageAsync(targetId, targetGroup, miraiMsg);
                        if (msg.RevokeTime > 0)
                            RecallMessage(sendedTempMessageId, targetId, msg.RevokeTime * 1000);
                        return sendedTempMessageId;
                    },
                    async () => (await _session.GetFriendListAsync()).Select(f => new GreenOnionsFriendInfo(f.Id, f.Name, f.Remark)).ToList(),
                    async () => (await _session.GetGroupListAsync()).Select(g => new GreenOnionsGroupInfo(g.Id, g.Name)).ToList(),
                    async (groupId) => (await _session.GetGroupMemberListAsync(groupId)).Select(m => m.ToGreenOnionsMemberInfo()).ToList(),
                    async (groupId, memberId) => (await _session.GetGroupMemberInfoAsync(groupId, memberId)).ToGreenOnionsMemberInfo());

                BotInfo.API = greenOnionsApi;

                BotInfo.IsLogin = _session.Connected;

                try
                {
                    RssHelper.StartRssTask(greenOnionsApi);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog("启动RSS抓取线程发生错误", ex);
                    throw;
                }

                PluginManager.Connected(BotInfo.Config.QQId, greenOnionsApi);

                if (BotInfo.Config.LeaveGroupAfterBeMushin)  //自动退出被禁言的群
                {
                    var groups = await _session.GetGroupListAsync();
                    foreach (var group in groups)
                    {
                        var selfInfo = await _session.GetGroupMemberInfoAsync(_session.QQNumber!.Value, group.Id);
                        if (selfInfo.MuteTimeRemaining > TimeSpan.FromSeconds(1))
                            await _session.LeaveGroupAsync(group.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("连接到Mirai-Api-Http失败", ex);
                ConnectedEvent?.Invoke(false, $"{ex.Message} mirai-api-http");
            }
        }

        public override Task Disconnect()
        {
            BotInfo.IsLogin = false;
            PluginManager.Disconnected();
            _ts?.Cancel();
            _session?.Dispose();
            _scope.Dispose();
            ConnectedEvent?.Invoke(false, "");
            return Task.CompletedTask;
        }
    }
}
