using GreenOnions.BotMain.Konata;
using GreenOnions.BotMain.Oicq.MessageTypes;
using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GreenOnions.BotMain.Oicq
{
    public class OicqClient : WsClient
    {
        public OicqClient(Action<bool, string> connectedEvent) : base(connectedEvent)
        {
        }

        public override async Task Connect(long qqId, string ip, ushort port, string key)
        {
            await base.Connect(qqId, ip, port, key);

            GreenOnionsApi greenOnionsApi = new(
                (targetId, msg) =>
                {
                    SendMessage(msg, targetId);
                    return Task.FromResult(0);
                },
                (targetId, msg) =>
                {
                    SendMessage(msg, null, targetId);
                    return Task.FromResult(0);
                },
                (targetId, targetGroup, msg) =>
                {
                    SendMessage(msg, targetId, targetGroup);
                    return Task.FromResult(0);
                },
                //TODO fl gl gml bot.pickMember.info
                //async () => (await _session.GetFriendListAsync()).Select(f => new GreenOnionsFriendInfo(f.Id, f.Name, f.Remark)).ToList(),
                //async () => (await _session.GetGroupListAsync()).Select(g => new GreenOnionsGroupInfo(g.Id, g.Name)).ToList(),
                //async (groupId) => (await _session.GetGroupMemberListAsync(groupId)).Select(m => m.ToGreenOnionsMemberInfo()).ToList(),
                //async (groupId, memberId) => (await _session.GetGroupMemberInfoAsync(groupId, memberId)).ToGreenOnionsMemberInfo());
                null, null, null, null);

            BotInfo.API = greenOnionsApi;
        }

        public override async void ReceiveMessage(string json)
        {
            ReceiveOicqMessage? oMsg = JsonConvert.DeserializeObject<ReceiveOicqMessage>(json);
            if (oMsg is null)
            {
                LogHelper.WriteWarningLog($"解析Oicq的Json消息失败，原文为：\r\n{json}");
                return;
            }
            GreenOnionsMessages msgs = OicqMessageConverter.ToGreenOnionsMessages(oMsg);
            await MessageHandler.HandleMesage(msgs, oMsg.group_id, msg => SendMessage(msg, oMsg.sender.user_id, oMsg.group_id));
        }

        protected async void SendMessage(GreenOnionsMessages msg, long? targetId, long? targetGroup = null)
        {
            if (msg is null || msg.Count == 0)
                return;
            if (msg.First() is GreenOnionsTextMessage txm && string.IsNullOrEmpty(txm.Text))
                return;

            List<OicqMessage> lstMsg = OicqMessageConverter.ToOicqMessages(msg);

            OicqWsMessage oicqMessage = new OicqWsMessage();
            oicqMessage.Mode = "message";
            oicqMessage.Message = JsonConvert.SerializeObject(lstMsg, Formatting.Indented, new StringEnumConverter());
            oicqMessage.TargetId = targetId;
            oicqMessage.TargetGroup = targetGroup;
            oicqMessage.RevokeTime = msg.RevokeTime;

            string json = JsonConvert.SerializeObject(oicqMessage);
            await base.SendMessage(json);
        }

        //TODO
        //private void GetFriendList()
        //{
        //    OicqWsMessage oicqMessage = new OicqWsMessage();
        //    oicqMessage.Mode = "fl";

        //    string json = JsonConvert.SerializeObject(oicqMessage);
        //    base.SendMessage(json);
        //}
    }
}
