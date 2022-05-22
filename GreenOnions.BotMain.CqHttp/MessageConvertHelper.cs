using GreenOnions.Model;
using Sora.Entities;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;

namespace GreenOnions.BotMain.CqHttp
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
                    {
                        greenOnionsMessages.Add(new GreenOnionsAtMessage(atId, atMsg.Name));
                    }
                }
                else if (miraiMessage[i].Data is TextSegment textMsg)
                {
                    greenOnionsMessages.Add(textMsg.Content);
                }
                else if (miraiMessage[i].Data is ImageSegment imageMsg)
                {
                    greenOnionsMessages.Add(new GreenOnionsImageMessage(imageMsg.Url));
                }
            }
            return greenOnionsMessages.ToArray();
        }
    }
}
