using GreenOnions.Interface;
using GreenOnions.Model;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.Entities.Base;
using Sora.Entities.Info;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;

namespace GreenOnions.BotMain.CqHttp
{
    public static class MessageConvertHelper
    {
        public static GreenOnionsMessages ToOnionsMessages(this MessageBody miraiMessage, long senderId, string senderName, long? senderGroup, SoraApi api)
        {
            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            for (int i = 0; i < miraiMessage.Count; i++)
            {
                if (miraiMessage[i].Data is AtSegment atMsg)
                {
                    //获取@群名片
                    if (long.TryParse(atMsg.Target, out long atId))
                    {
                        var apiResult = api.GetGroupMemberList(senderGroup.Value).GetAwaiter().GetResult();
                        List<GroupMemberInfo> groupMemberInfos = apiResult.groupMemberList;
                        GroupMemberInfo targetQQ = groupMemberInfos.Where(m => m.UserId == atId).FirstOrDefault();
                        string nickName = targetQQ?.Nick;
                        greenOnionsMessages.Add(new GreenOnionsAtMessage(atId, nickName));
                    }
                    else
                    {
                        greenOnionsMessages.Add(new GreenOnionsAtMessage(atId, atMsg.Name));
                    }
                }
                else if (miraiMessage[i].Data is TextSegment textMsg)
                    greenOnionsMessages.Add(textMsg.Content);
                else if (miraiMessage[i].Data is ImageSegment imageMsg)
                    greenOnionsMessages.Add(new GreenOnionsImageMessage(imageMsg.Url, imageMsg.ImgFile));
            }

            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static MessageBody ToCqHttpMessages(this IGreenOnionsMessages greenOnionsMessage, int? RelpyId)
        {
            MessageBody cqHttpMessages = new MessageBody();
            if (greenOnionsMessage.Reply && RelpyId != null)
                cqHttpMessages.Add(SoraSegment.Reply(RelpyId.Value));

            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is IGreenOnionsTextMessage txtMsg)
                    {
                        cqHttpMessages.Add(SoraSegment.Text(txtMsg.Text));
                    }
                    else if (greenOnionsMessage[i] is IGreenOnionsImageMessage imgMsg)
                    {
                        string data = string.IsNullOrEmpty(imgMsg.Url) ? ("base64://" + imgMsg.Base64Str) : imgMsg.Url;
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
                            var itemMsg = ToCqHttpMessages(forwardMsg.ItemMessages[i].itemMessage, RelpyId);
                            if (itemMsg!= null)
                                cqHttpMessages.AddRange(itemMsg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage("转换为CqHttp消息失败!!!", ex);
                    continue;
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
