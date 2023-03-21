using GreenOnions.BotMain.Oicq.MessageTypes;
using GreenOnions.Interface;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain.Konata
{
    public static class OicqMessageConverter
    {
        public static GreenOnionsMessages ToGreenOnionsMessages(this ReceiveOicqMessage oicqMessages)
        {
            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            foreach (var oicqMessage in oicqMessages.message)
            {
                if (oicqMessage is null)
                    continue;
                try
                {
                    switch (oicqMessage.type)
                    {
                        case MessageType.text:
                            greenOnionsMessages.Add((oicqMessage as OicqTextMessage)!.text);
                            break;
                        case MessageType.at:
                            OicqAtMessage atMsg = (OicqAtMessage)oicqMessage;
                            greenOnionsMessages.Add(new GreenOnionsAtMessage(atMsg.qq, atMsg.text));
                            break;
                        case MessageType.face:
                            OicqFaceMessage faceMsg = (OicqFaceMessage)oicqMessage;
                            greenOnionsMessages.Add(new GreenOnionsFaceMessage(faceMsg.id, faceMsg.text));
                            break;
                        case MessageType.image:
                            greenOnionsMessages.Add(new GreenOnionsImageMessage(ImageHelper.ReplaceGroupUrl((oicqMessage as OicqImageMessage)!.url)));
                            break;
                        case MessageType.record:
                            greenOnionsMessages.Add(new GreenOnionsVoiceMessage((oicqMessage as OicqRecordMessage)!.url));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"转换为GreenOnions消息失败, 原消息类型为:{oicqMessage.GetType()}", ex);
                }
            }
            greenOnionsMessages.Id = oicqMessages.rand;
            greenOnionsMessages.SenderId = oicqMessages.sender.user_id;
            greenOnionsMessages.SenderName = oicqMessages.sender.nickname;
            return greenOnionsMessages;
        }

        public static List<OicqMessage> ToOicqMessages(this GreenOnionsMessages greenOnionsMessage, int? coverReplyId = null)
        {
            if (!greenOnionsMessage.IsGreenOnionsCommand)
                greenOnionsMessage.ReplaceGreenOnionsStringTags();

            if (coverReplyId is not null)
                greenOnionsMessage.ReplyId = coverReplyId;

            List<OicqMessage> oicqMessages = new List<OicqMessage>();
            if (greenOnionsMessage.FirstOrDefault() is GreenOnionsForwardMessage forwardMsg)
            {
                GreenOnionsMessages defMessage = new GreenOnionsMessages();
                for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                    defMessage.AddRange(forwardMsg.ItemMessages[j].itemMessage);
                greenOnionsMessage = defMessage;
            }

            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                    {
                        if (!string.IsNullOrEmpty(txtMsg.Text))
                            oicqMessages.Add(new OicqTextMessage() { text = txtMsg.Text });
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
                    {
                        if (string.IsNullOrEmpty(imgMsg.Url))
                            oicqMessages.Add(new OicqImageMessage() { url = $"base64://{imgMsg.Base64Str}" });
                        else if (File.Exists(imgMsg.Url))
                            oicqMessages.Add(new OicqImageMessage() { url = imgMsg.Url.Replace('\\','/') });
                        else
                            oicqMessages.Add(new OicqImageMessage() { url = imgMsg.Url });
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                    {
                        if (atMsg.AtId == -1)
                            oicqMessages.Add(new OicqAtMessage() { text = "all" });
                        else
                            oicqMessages.Add(new OicqAtMessage() { qq = atMsg.AtId});
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsVoiceMessage voiceMsg)
                    {
                        if (string.IsNullOrEmpty(voiceMsg.Url))
                            new OicqRecordMessage() { url = $"base64://{voiceMsg.Base64Str}" };
                        else if (File.Exists(voiceMsg.Url))
                            oicqMessages.Add(new OicqImageMessage() { url = voiceMsg.Url.Replace('\\', '/') });
                        else
                            oicqMessages.Add(new OicqImageMessage() { url = voiceMsg.Url.Replace('\\', '/') });
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"转换为Konata消息失败!!! 消息类型为：{greenOnionsMessage[i]?.GetType()}", ex);
                    continue;
                }
            }
            return oicqMessages;
        }
    }
}
