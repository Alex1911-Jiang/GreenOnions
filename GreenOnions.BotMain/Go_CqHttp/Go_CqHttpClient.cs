using System.Net.Sockets;
using EleCho.GoCqHttpSdk;
using GreenOnions.BotMain.Go_CqHttp;
using GreenOnions.Interface;
using GreenOnions.RSS;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain.OneBot
{
    public class Go_CqHttpClient : MiraiClient
    {
        private CqWsSession _session;

        public Go_CqHttpClient(Action<bool, string> connectedEvent) : base(connectedEvent)
        {
        }

        public override async Task Connect(long qqId, string ip, ushort port, string accessToken)
        {
            try
            {
                //实例化Sora服务
                _session = new CqWsSession(new CqWsSessionOptions()
                {
                    BaseUri = new Uri($"ws://{ip}:{port}"),  // WebSocket 地址
                    UseApiEndPoint = true,                     // 使用 api 终结点
                    UseEventEndPoint = true,                   // 使用事件终结点
                });
                await _session.StartAsync();

                //_session.PostPipeline.Use(async (context, next) =>
                //{
                //    // context 为上报数据的上下文, 其中包含了具体的信息

                //    // 在这里添加你的逻辑代码 //

                //    // next 是中间件管道中的下一个中间件, 
                //    // 如果你希望当中间件执行时, 不继续执行下一个中间件
                //    // 可以选择不执行 next



                //    await next();
                //});
                _session.HandlePipeline();
                


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
                    if (e is not null)
                        LogHelper.WriteErrorLog("Sora服务异常", e);
                    //Log.Error("Sora _service", Log.ErrorLogBuilder(e));
                });
                if (connectCancel)
                {
                    throw new SocketException(10061);
                }

                SoraApi? api = null;

                _service.Event.OnClientConnect += async (eventType, eventArgs) =>
                {
                    api = eventArgs.SoraApi;

                    void RecallMessage(int messageId, int revokeTime)
                    {
                        Task.Delay(revokeTime).ContinueWith(_ => api.RecallMessage(messageId));
                    }

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
                            if (msg is null || msg.Count == 0)
                                return 0;

                            int sendedFriendMessageId = 0;
                            if (msg.First() is GreenOnionsForwardMessage)
                            {
                                var soraMsg = msg.ToOneBotForwardMessage();
                                sendedFriendMessageId = (await eventArgs.SoraApi.SendPrivateForwardMsg(targetId, soraMsg)).messageId;
                            }
                            else
                            {
                                var soraMsg = msg.ToOneBotMessages();
                                if (soraMsg is null || soraMsg.Count == 0)
                                    return 0;
                                sendedFriendMessageId = (await eventArgs.SoraApi.SendPrivateMessage(targetId, soraMsg)).messageId;
                            }
                            if (msg.RevokeTime > 0 && sendedFriendMessageId != -1)
                                RecallMessage(sendedFriendMessageId, msg.RevokeTime * 1000);
                            return sendedFriendMessageId;
                        },
                        async (targetId, msg) =>
                        {
                            if (msg is null)
                                return 0;
                            int sendedGroupMessageId = 0;
                            if (msg.First() is GreenOnionsForwardMessage)
                            {
                                var soraMsg = msg.ToOneBotForwardMessage();
                                sendedGroupMessageId = (await eventArgs.SoraApi.SendGroupForwardMsg(targetId, soraMsg)).messageId;
                            }
                            else
                            {
                                var soraMsg = msg.ToOneBotMessages();
                                if (soraMsg is null || soraMsg.Count == 0)
                                    return 0;
                                sendedGroupMessageId = (await eventArgs.SoraApi.SendGroupMessage(targetId, soraMsg)).messageId;
                            }
                            if (msg.RevokeTime > 0 && sendedGroupMessageId != -1)
                                RecallMessage(sendedGroupMessageId, msg.RevokeTime * 1000);
                            return sendedGroupMessageId;
                        },
                        async (targetId, targetGroup, msg) =>
                        {
                            if (msg is null)
                                return 0;
                            var soraMsg = msg.ToOneBotMessages();
                            if (soraMsg is null || soraMsg.Count == 0)
                                return 0;
                            int sendedTempMessageId = (await eventArgs.SoraApi.SendTemporaryMessage(targetId, targetGroup, soraMsg)).messageId;
                            if (msg.RevokeTime > 0 && sendedTempMessageId != -1)
                                RecallMessage(sendedTempMessageId, msg.RevokeTime * 1000);
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
                        LogHelper.WriteErrorLog("启动RSS抓取线程发生错误", ex);
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
                LogHelper.WriteErrorLog("连接到OneBot失败", ex);
                ConnectedEvent(false, $"{ex.Message} ({ip}:{port}) OneBot");
            }
        }

        public override async Task Disconnect()
        {
            if (_session is not null)
            {
                await _session.StopAsync();
            }
            BotInfo.IsLogin = false;
            PluginManager.Disconnected();
            ConnectedEvent?.Invoke(false, "");
        }
    }
}