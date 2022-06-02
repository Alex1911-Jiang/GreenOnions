using GreenOnions.Interface;
using GreenOnions.Model;
using Sora.Entities;
using Sora.Entities.Info;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;

namespace GreenOnions.BotMain.CqHttp
{
    public static class MessageConvertHelper
    {
        public static GreenOnionsMessages ToOnionsMessages(this MessageBody miraiMessage, long senderId, string senderName)
        {
            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            for (int i = 0; i < miraiMessage.Count; i++)
            {
                if (miraiMessage[i].Data is AtSegment atMsg)
                {
                    if (long.TryParse(atMsg.Target, out long atId))
                        greenOnionsMessages.Add(new GreenOnionsAtMessage(atId, atMsg.Name));
                }
                else if (miraiMessage[i].Data is TextSegment textMsg)
                    greenOnionsMessages.Add(textMsg.Content);
                else if (miraiMessage[i].Data is ImageSegment imageMsg)
                    greenOnionsMessages.Add(new GreenOnionsImageMessage(imageMsg.Url));
            }

            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static MessageBody ToCqHttpMessages(this IGreenOnionsMessages greenOnionsMessage, int? RelpyId)
        {
            MessageBody cqHttpMessages = new MessageBody();
            if (RelpyId != null)
                cqHttpMessages.Add(SoraSegment.Reply(RelpyId.Value));

            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                if (greenOnionsMessage[i] is IGreenOnionsTextMessage txtMsg)
                {
                    cqHttpMessages.Add(SoraSegment.Text(txtMsg.Text));
                }
                else if (greenOnionsMessage[i] is IGreenOnionsImageMessage imgMsg)
                {
                    string data = string.IsNullOrEmpty(imgMsg.Url) ? imgMsg.Base64Str : imgMsg.Url;
                    cqHttpMessages.Add(SoraSegment.Image(data));
                }
                else if (greenOnionsMessage[i] is IGreenOnionsAtMessage atMsg)
                {
                    if (atMsg.AtId == -1)
                        cqHttpMessages.Add(SoraSegment.AtAll());
                    else
                        cqHttpMessages.Add(SoraSegment.At(atMsg.AtId));
                }
                else if (greenOnionsMessage[i] is IGreenOnionsForwardMessage forwardMsg)
                {
                    for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                    {
                        cqHttpMessages.AddRange(ToCqHttpMessages(forwardMsg.ItemMessages[i].itemMessage, RelpyId));
                    }
                }
            }
            return cqHttpMessages;
        }

        public static List<CustomNode> ToCqHttpForwardMessage(this IGreenOnionsForwardMessage forwardMsg)
        {
            List<CustomNode> nodes = new List<CustomNode>();
            for (int i = 0; i < forwardMsg.ItemMessages.Count; i++)
            {
                nodes.Add(new CustomNode(forwardMsg.ItemMessages[i].NickName, forwardMsg.ItemMessages[i].QQid, forwardMsg.ItemMessages[i].itemMessage.ToCqHttpMessages(null)));
            }
            return nodes;
        }
    }
}
