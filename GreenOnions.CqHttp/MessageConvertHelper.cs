using GreenOnions.Model;
using Sora.Entities;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;

namespace GreenOnions.CqHttp
{
    public static class MessageConvertHelper
    {
        public static GreenOnionsBaseMessage[] ToOnionsMessages(this MessageBody miraiMessage)
        {
            List<GreenOnionsBaseMessage> greenOnionsMessages = new List<GreenOnionsBaseMessage>();
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
            return greenOnionsMessages.ToArray();
        }

        public static SoraSegment ToCqHttpMessage(this GreenOnionsBaseMessage greenOnionsMessage)
        {
            if (greenOnionsMessage is GreenOnionsTextMessage txtMsg)
            {
                return SoraSegment.Text(txtMsg.Text);
            }
            else if (greenOnionsMessage is GreenOnionsImageMessage imgMsg)
            {
                string data = string.IsNullOrEmpty(imgMsg.Url) ? imgMsg.Base64Str : imgMsg.Url;
                return SoraSegment.Image(data);
            }
            else if (greenOnionsMessage is GreenOnionsAtMessage atMsg)
            {
                if (atMsg.AtId == -1)
                    return SoraSegment.AtAll();
                else
                    return SoraSegment.At(atMsg.AtId);
            }
            return null;
        }

        public static MessageBody ToCqHttpMessages(this GreenOnionsMessageGroup greenOnionsMessage)
        {
            MessageBody cqHttpMessages = new MessageBody();
            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                {
                    cqHttpMessages.Add(SoraSegment.Text(txtMsg.Text));
                }
                else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
                {
                    string data = string.IsNullOrEmpty(imgMsg.Url) ? imgMsg.Base64Str : imgMsg.Url;
                    cqHttpMessages.Add(SoraSegment.Image(data));
                }
                else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                {
                    if (atMsg.AtId == -1)
                        cqHttpMessages.Add(SoraSegment.AtAll());
                    else
                        cqHttpMessages.Add(SoraSegment.At(atMsg.AtId));
                }
            }
            return cqHttpMessages;
        }

        public static List<CustomNode> ToCqHttpForwardMessage(this GreenOnionsForwardMessage forwardMsg)
        {
            List<CustomNode> nodes = new List<CustomNode>();
            for (int i = 0; i < forwardMsg.ItemMessages.Count; i++)
            {
                nodes.Add(new CustomNode(forwardMsg.ItemMessages[i].NickName, forwardMsg.ItemMessages[i].QQid, forwardMsg.ItemMessages[i].itemMessage.ToCqHttpMessages()));
            }
            return nodes;
        }
    }
}
