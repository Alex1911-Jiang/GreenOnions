using System.Collections.ObjectModel;
using GreenOnions.Interface;
using GreenOnions.RSS;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Sora;
using Sora.Entities.Base;
using Sora.Entities.Info;
using Sora.Interfaces;
using Sora.Net.Config;
using Sora.Util;
using YukariToolBox.LightLog;

namespace GreenOnions.BotMain.CqHttp
{
    public class CqHttpMain
    {
        public static async void Connect(long qqId, string ip, ushort port, string accessToken, Action<bool, string> ConnectedEvent)
        {
            ////设置log等级
            //Log.LogConfiguration
            //   .EnableConsoleOutput()
            //   .SetLogLevel(LogLevel.Error);

            try
            {
                //实例化Sora服务
                ISoraService service = SoraServiceFactory.CreateService(new ClientConfig() { Host = ip, Port = port, AccessToken = accessToken });
                service.Event.OnGroupMessage += MessageEvents.Event_OnGroupMessage;
                service.Event.OnPrivateMessage += MessageEvents.Event_OnPrivateMessage;
                service.Event.OnGroupMemberChange += MessageEvents.Event_OnGroupMemberChange;

                bool connectCancel = false;
                BotInfo.IsLogin = false;
                _ = Task.Delay(3000).ContinueWith(_ =>
                {
                    if (!BotInfo.IsLogin)
                    {
                        service.StopService();
                    }
                });

                //启动服务并捕捉错误
                await service.StartService().RunCatch(e => 
                {
                    connectCancel = true;
                    Log.Error("Sora Service", Log.ErrorLogBuilder(e));
                });
                if (connectCancel)
                    throw new HttpRequestException($"尝试连接到CqHttp超时，无法连接。 ({ip}:{port})");

                service.Event.OnClientConnect += async (eventType, eventArgs) =>
                {
                    SoraApi api = service.GetApi(service.ServiceId);

                    if (api != null)
                    {
                        BotInfo.QQId = api.GetLoginUserId();

                        List<FriendInfo> IFriendInfos = (await api.GetFriendList()).friendList;
                        string nickname = "未知";

                        var self = IFriendInfos.Where(q => q.UserId == qqId).FirstOrDefault();
                        if (self != null)
                            nickname = self.Nick;

                        ConnectedEvent?.Invoke(true, nickname);

                        BotInfo.IsLogin = true;


                        Dictionary<string, string> props = AssemblyHelper.GetAllPropertiesValue();
                        GreenOnionsApi greenOnionsApi = new GreenOnionsApi(new ReadOnlyDictionary<string, string>(props), 
                            async (targetId, msg) => (await api.SendPrivateMessage(targetId, msg.ToCqHttpMessages(null))).messageId,
                            async (targetId, msg) => (await api.SendGroupMessage(targetId, msg.ToCqHttpMessages(null))).messageId,
                            async (targetId, targetGroup, msg) => (await api.SendTemporaryMessage(targetId, targetGroup, msg.ToCqHttpMessages(null))).messageId,
                            async () => (await api.GetFriendList()).friendList.Select(f => new GreenOnionsFriendInfo(f.UserId, f.Nick, f.Remark)).ToList(),
                            async () => (await api.GetGroupList()).groupList.Select(g => new GreenOnionsGroupInfo(g.GroupId, g.GroupName)).ToList(),
                            async (groupId) => (await api.GetGroupMemberList(groupId)).groupMemberList.Select(m => m.ToGreenOnionsMemberInfo()).ToList(),
                            async (groupId, memberId) => (await api.GetGroupMemberInfo(groupId, memberId)).memberInfo.ToGreenOnionsMemberInfo());

                        try
                        {
                            RssHelper.StartRssTask(greenOnionsApi);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteErrorLogWithUserMessage("启动RSS抓取线程发生错误", ex);
                            throw;
                        }

                        PluginManager.Connected(BotInfo.QQId, greenOnionsApi);
                    }
                };

                await Task.Run(() =>
                {
                    while (true)
                    {
                        BotInfo.IsLogin = true;
                        if (Console.ReadLine() == "exit")
                        {
                            BotInfo.IsLogin = false;
                            PluginManager.Disconnected();
                            ConnectedEvent?.Invoke(false, "");
                            break;
                        }
                        Task.Delay(100).Wait();
                    }
                });
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                ConnectedEvent(false, ex.Message);
            }
        }
    }
}