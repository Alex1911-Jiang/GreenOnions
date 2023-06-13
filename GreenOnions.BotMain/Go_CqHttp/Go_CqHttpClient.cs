using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using GreenOnions.Interface;
using GreenOnions.RSS;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain.Go_CqHttp
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
                _session = new CqWsSession(new CqWsSessionOptions()
                {
                    BaseUri = new Uri($"ws://{ip}:{port}"),  // WebSocket 地址
                    AccessToken = accessToken,
                    UseApiEndPoint = true,                     // 使用 api 终结点
                    UseEventEndPoint = true,                   // 使用事件终结点
                });
                await _session.StartAsync();

                _session.PostPipeline.Use(async (context, next) =>
                {
                    // context 为上报数据的上下文, 其中包含了具体的信息

                    // 在这里添加你的逻辑代码 //

                    // next 是中间件管道中的下一个中间件, 
                    // 如果你希望当中间件执行时, 不继续执行下一个中间件
                    // 可以选择不执行 next

                    await next();
                });
                _session.HandlePipeline();

                //string nickname = _session.GetFriendList()?.Friends.Where(f => f.UserId == qqId).FirstOrDefault()?.Nickname ?? "未知";

                var loginInfo = await _session.GetLoginInformationAsync();
                string nickname = loginInfo?.Nickname ?? "未知";

                ConnectedEvent?.Invoke(true, nickname);

                void RecallMessage(long messageId, int revokeTime)
                {
                    Task.Delay(revokeTime).ContinueWith(_ => _session.RecallMessage(messageId));
                }

                GreenOnionsApi greenOnionsApi = new(
                    async (targetId, msg) =>
                    {
                        if (msg is null || msg.Count == 0)
                            return 0;

                        long sendedFriendMessageId = 0;
                        if (msg.First() is GreenOnionsForwardMessage)
                        {
                            var goCqhttpMsg = msg.ToCqForwardMessage();
                            sendedFriendMessageId = (await _session.SendPrivateForwardMessageAsync(targetId, goCqhttpMsg))?.MessageId ?? 0;
                        }
                        else
                        {
                            var goCqhttpMsg = msg.ToCqMessages();
                            if (goCqhttpMsg is null || goCqhttpMsg.Count == 0)
                                return 0;
                            var sendedMsg = await _session.SendPrivateMessageAsync(targetId, goCqhttpMsg);
                            sendedFriendMessageId = sendedMsg?.MessageId ?? 0;
                        }
                        if (msg.RevokeTime > 0 && sendedFriendMessageId != -1)
                            RecallMessage(sendedFriendMessageId, msg.RevokeTime * 1000);
                        return sendedFriendMessageId;
                    },
                    async (targetId, msg) =>
                    {
                        if (msg is null)
                            return 0;
                        long sendedGroupMessageId = 0;
                        if (msg.First() is GreenOnionsForwardMessage)
                        {
                            var goCqhttpMsg = msg.ToCqForwardMessage();
                            sendedGroupMessageId = (await _session.SendGroupForwardMessageAsync(targetId, goCqhttpMsg))?.MessageId ?? 0;
                        }
                        else
                        {
                            var goCqhttpMsg = msg.ToCqMessages();
                            if (goCqhttpMsg is null || goCqhttpMsg.Count == 0)
                                return 0;
                            var sendedMsg = await _session.SendGroupMessageAsync(targetId, goCqhttpMsg);
                            sendedGroupMessageId = sendedMsg?.MessageId ?? 0;
                        }
                        if (msg.RevokeTime > 0 && sendedGroupMessageId != -1)
                            RecallMessage(sendedGroupMessageId, msg.RevokeTime * 1000);
                        return sendedGroupMessageId;
                    },
                    async (targetId, targetGroup, msg) =>
                    {
                        if (msg is null || msg.Count == 0)
                            return 0;

                        long sendedTempMessageId = 0;
                        var goCqhttpMsg = msg.ToCqMessages();
                        if (goCqhttpMsg is null || goCqhttpMsg.Count == 0)
                            return 0;
                        var sendedMsg = await _session.SendPrivateMessageAsync(targetId, targetGroup, goCqhttpMsg);
                        sendedTempMessageId = sendedMsg?.MessageId ?? 0;

                        if (msg.RevokeTime > 0 && sendedTempMessageId != -1)
                            RecallMessage(sendedTempMessageId, msg.RevokeTime * 1000);
                        return sendedTempMessageId;
                    },
                    async () => (await _session.GetFriendListAsync()).Friends.Select(f => new GreenOnionsFriendInfo(f.UserId, f.Nickname, f.Remark)).ToList(),
                    async () => (await _session.GetGroupListAsync()).Groups.Select(g => new GreenOnionsGroupInfo(g.GroupId, g.GroupName)).ToList(),
                    async groupId => (await _session.GetGroupMemberListAsync(groupId)).Members.Select(m => m.ToGreenOnionsMemberInfo()).ToList(),
                    async (groupId, memberId) => (await _session.GetGroupMemberInformationAsync(groupId, memberId)).ToGreenOnionsMemberInfo());

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
                    CqGetGroupListActionResult? groups = _session.GetGroupList();
                    if (groups is null)
                        return;
                    foreach (var group in groups.Groups)
                    {
                        var selfInfo = _session.GetGroupMemberInformation(group.GroupId, BotInfo.Config.QQId);
                        if (selfInfo.BanExpireTime > DateTime.Now)
                            _session.LeaveGroup(group.GroupId);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("连接到Go-CqHttp失败", ex);
                ConnectedEvent(false, $"{ex.Message} ({ip}:{port}) Go-CqHttp");
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