using System.Net.Sockets;
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
    public class CqHttpClient : MiraiClient
    {
        private ISoraService? _service;

        public CqHttpClient(Action<bool, string> connectedEvent) : base(connectedEvent)
        {
        }

        public override async Task Connect(long qqId, string ip, ushort port, string accessToken)
        {
            try
            {
                //实例化Sora服务
                _service = SoraServiceFactory.CreateService(new ClientConfig() { Host = ip, Port = port, AccessToken = accessToken }, ex => LogHelper.WriteErrorLogWithUserMessage("Sora连接异常", ex));

                _service.Event.OnGroupMessage += MessageEvents.Event_OnGroupMessage;
                _service.Event.OnPrivateMessage += MessageEvents.Event_OnPrivateMessage;
                _service.Event.OnGroupMemberChange += MessageEvents.Event_OnGroupMemberChange;
                _service.Event.OnGroupMemberMute += MessageEvents.Event_OnGroupMemberMute;

                bool connectCancel = false;
                BotInfo.IsLogin = false;
                _ = Task.Delay(3000).ContinueWith(async _ =>
                {
                    if (!BotInfo.IsLogin)
                        await _service.StopService();
                });

                //启动服务并捕捉错误
                await _service.StartService().RunCatch(e =>
                {
                    connectCancel = true;
                    Log.Error("Sora _service", Log.ErrorLogBuilder(e));
                });
                if (connectCancel)
                {
                    throw new SocketException(10061);
                }

                SoraApi api = null;

                _service.Event.OnClientConnect += async (eventType, eventArgs) =>
                {
                    api = eventArgs.SoraApi;
                    BotInfo.Config.QQId = eventArgs.SoraApi.GetLoginUserId();

                    List<FriendInfo> IFriendInfos = (await eventArgs.SoraApi.GetFriendList()).friendList;
                    string nickname = "未知";

                    var self = IFriendInfos.Where(q => q.UserId == qqId).FirstOrDefault();
                    if (self is not null)
                        nickname = self.Nick;

                    ConnectedEvent?.Invoke(true, nickname);

                    GreenOnionsApi greenOnionsApi = new (
                        async (targetId, msg) =>
                        {
                            var soramsg = msg.ToCqHttpMessages();
                            int sendedFriendMessageId = (await eventArgs.SoraApi.SendPrivateMessage(targetId, soramsg)).messageId;
                            if (msg.RevokeTime > 0)
                                _ = Task.Delay(msg.RevokeTime * 1000).ContinueWith(_ => eventArgs.SoraApi.RecallMessage(sendedFriendMessageId));
                            return sendedFriendMessageId;
                        },
                        async (targetId, msg) =>
                        {
                            int sendedGroupMessageId = (await eventArgs.SoraApi.SendGroupMessage(targetId, msg.ToCqHttpMessages())).messageId;
                            if (msg.RevokeTime > 0)
                                _ = Task.Delay(msg.RevokeTime * 1000).ContinueWith(_ => eventArgs.SoraApi.RecallMessage(sendedGroupMessageId));
                            return sendedGroupMessageId;
                        },
                        async (targetId, targetGroup, msg) =>
                        {
                            int sendedTempMessageId = (await eventArgs.SoraApi.SendTemporaryMessage(targetId, targetGroup, msg.ToCqHttpMessages())).messageId;
                            if (msg.RevokeTime > 0)
                                _ = Task.Delay(msg.RevokeTime * 1000).ContinueWith(_ => eventArgs.SoraApi.RecallMessage(sendedTempMessageId));
                            return sendedTempMessageId;
                        },
                        async () => (await eventArgs.SoraApi.GetFriendList()).friendList.Select(f => new GreenOnionsFriendInfo(f.UserId, f.Nick, f.Remark)).ToList(),
                        async () => (await eventArgs.SoraApi.GetGroupList()).groupList.Select(g => new GreenOnionsGroupInfo(g.GroupId, g.GroupName)).ToList(),
                        async (groupId) => (await eventArgs.SoraApi.GetGroupMemberList(groupId)).groupMemberList.Select(m => m.ToGreenOnionsMemberInfo()).ToList(),
                        async (groupId, memberId) => (await eventArgs.SoraApi.GetGroupMemberInfo(groupId, memberId)).memberInfo.ToGreenOnionsMemberInfo());

                    BotInfo.API = greenOnionsApi;

                    BotInfo.IsLogin = true;

                    try
                    {
                        RssHelper.StartRssTask(greenOnionsApi);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("启动RSS抓取线程发生错误", ex);
                        throw;
                    }

                    PluginManager.Connected(BotInfo.Config.QQId, greenOnionsApi);

                    if (BotInfo.Config.LeaveGroupAfterBeMushin)  //自动退出被禁言的群
                    {
                        if (api is not null)
                        {
                            var groups = await api.GetGroupList();
                            foreach (var group in groups.groupList)
                            {
                                var selfInfo = await api.GetGroupMemberInfo(group.GroupId, BotInfo.Config.QQId);
                                if (selfInfo.memberInfo.ShutUpTime > DateTime.Now)
                                    await api.LeaveGroup(group.GroupId);
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                ConnectedEvent(false, $"{ex.Message} ({ip}:{port}) OneBot/Cqhttp");
            }
        }

        public override async Task Disconnect()
        {
            if (_service is not null)
                await _service.StopService();
            BotInfo.IsLogin = false;
            PluginManager.Disconnected();
            ConnectedEvent?.Invoke(false, "");
        }
    }
}