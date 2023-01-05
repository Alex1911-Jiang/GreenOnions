using GreenOnions.Interface;
using GreenOnions.Utility;

namespace GreenOnions.MessageTransfer
{
    public class Transfer
    {
        private Dictionary<int,long> _msgIds;
        public Transfer()
        {
            _msgIds = new Dictionary<int, long>();
        }

        public async void PrivateMessage(GreenOnionsMessages msgs)
        {
            if (BotInfo.Config.AdminQQ.Contains(msgs.SenderId))
            {
                await AdminMessage(msgs);
            }
            else
            {
                await FriendOrTempMessage(msgs);
            }
        }

        private async Task FriendOrTempMessage(GreenOnionsMessages msgs)
        {
            if (BotInfo.Config.MessageTransferEnabled)
            {
                _msgIds.Add(msgs.Id, msgs.SenderId);
                GreenOnionsMessages msgToAdmin = new GreenOnionsMessages();
                msgToAdmin.Add($"{msgs.SenderName}({msgs.SenderId})说：");
                msgToAdmin.AddRange(msgs);
                msgToAdmin.Add($"\r\n(消息ID：{msgs.Id})");
                await SendMessageToAdmin(msgToAdmin);
            }
        }

        private async Task SendMessageToAdmin(GreenOnionsMessages msgs)
        {
            foreach (long adminQQ in BotInfo.Config.AdminQQ)
                await BotInfo.API.SendFriendMessageAsync(adminQQ, msgs);
        }

        private async Task AdminMessage(GreenOnionsMessages msgs)
        {
            if (msgs.FirstOrDefault() is GreenOnionsTextMessage textMsg)
            {
                int colonIndex = Math.Max(textMsg.Text.IndexOf(':'), textMsg.Text.IndexOf('：'));
                if (textMsg.Text.StartsWith("回复"))
                {
                    if (colonIndex == -1)
                    {
                        await BotInfo.API.SendFriendMessageAsync(msgs.SenderId, "回复格式错误，正确格式为“回复+消息ID+冒号+内容”\r\n如果要向QQ号发送消息，请用“发送给+目标QQ号+冒号+内容”");
                        return;
                    }
                    int replyId = 0;
                    if (!int.TryParse(textMsg.Text["回复".Length..colonIndex], out replyId))
                    {
                        await BotInfo.API.SendFriendMessageAsync(msgs.SenderId, "回复消息ID错误，请确保“回复”和“：”中的消息ID为数字（不是QQ号）\r\n如果要向QQ号发送消息，请用“发送给+目标QQ号+冒号+内容”");
                        return;
                    }
                    if (!_msgIds.ContainsKey(replyId))
                    {
                        await BotInfo.API.SendFriendMessageAsync(msgs.SenderId, "回复消息ID不存在，请改用“发送给”向QQ号发送消息");
                        return;
                    }
                    GreenOnionsMessages outMsg = new GreenOnionsMessages() { Reply = true, ReplyId = replyId };
                    string replyText = textMsg.Text[(colonIndex+1)..];
                    outMsg.Add(replyText);
                    for (int i = 1; i < msgs.Count; i++)
                        outMsg.Add(msgs[i]);
                    await BotInfo.API.SendFriendMessageAsync(_msgIds[replyId], outMsg);
                }
                else if (textMsg.Text.StartsWith("发送给"))
                {
                    if (colonIndex == -1)
                    {
                        await BotInfo.API.SendFriendMessageAsync(msgs.SenderId, "发送消息格式错误，正确格式为“发送给+目标QQ号+冒号+内容”\r\n如果要回复消息，请用“回复+消息ID+冒号+内容”");
                        return;
                    }
                    long targetQQ = -1;
                    if (!long.TryParse(textMsg.Text["发送给".Length..colonIndex], out targetQQ))
                    {
                        await BotInfo.API.SendFriendMessageAsync(msgs.SenderId, "发送消息QQ号格式错误，请确保“发送给”和“：”中的QQ号为数字（不是消息ID）\r\n如果要回复消息，请用“回复+消息ID+冒号+内容”");
                        return;
                    }
                    GreenOnionsMessages outMsg = new GreenOnionsMessages() { Reply = false };
                    string sendText = textMsg.Text[(colonIndex + 1)..];
                    outMsg.Add(sendText);
                    for (int i = 1; i < msgs.Count; i++)
                        outMsg.Add(msgs[i]);
                    await BotInfo.API.SendFriendMessageAsync(targetQQ, outMsg);
                }
            }
        }
    }
}