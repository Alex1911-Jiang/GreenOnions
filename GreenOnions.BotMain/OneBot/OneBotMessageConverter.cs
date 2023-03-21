using GreenOnions.Interface;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.Entities.Base;
using Sora.Entities.Info;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;

namespace GreenOnions.BotMain.OneBot
{
    public static class OneBotMessageConverter
    {
        public static async Task<GreenOnionsMessages> ToGreenOnionsMessages(this MessageContext miraiMessage, long senderId, string senderName, long? senderGroup, SoraApi? api)
        {
            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            for (int i = 0; i < miraiMessage.MessageBody.Count; i++)
            {
                try
                {
                    if (miraiMessage.MessageBody[i].Data is AtSegment atMsg && senderGroup != null)
                    {
                        //获取@群名片
                        if (long.TryParse(atMsg.Target, out long atId))
                        {
                            if (api != null)
                            {
                                var apiResult = await api.GetGroupMemberList(senderGroup.Value);
                                List<GroupMemberInfo> groupMemberInfos = apiResult.groupMemberList;
                                GroupMemberInfo? targetQQ = groupMemberInfos.Where(m => m.UserId == atId).FirstOrDefault();
                                if (targetQQ != null)
                                {
                                    string? nickName = targetQQ?.Card;
                                    greenOnionsMessages.Add(new GreenOnionsAtMessage(atId, nickName));
                                }
                            }
                        }
                        else
                        {
                            greenOnionsMessages.Add(new GreenOnionsAtMessage(atId, atMsg.Name));
                        }
                    }
                    else if (miraiMessage.MessageBody[i].Data is TextSegment textMsg)
                        greenOnionsMessages.Add(textMsg.Content);
                    else if (miraiMessage.MessageBody[i].Data is ImageSegment imageMsg)
                        greenOnionsMessages.Add(new GreenOnionsImageMessage(ImageHelper.ReplaceGroupUrl(imageMsg.Url)));
                    else if (miraiMessage.MessageBody[i].Data is FaceSegment faceMsg)
                        greenOnionsMessages.Add(new GreenOnionsFaceMessage(faceMsg.Id, faceMsg.ToString()));
                }
                catch (Exception ex)
                {
                    if (api == null)
                        LogHelper.WriteErrorLog($"转换为GreenOnions消息失败, SoraApi为空, 原消息类型为:{miraiMessage[i].Data.GetType()}", ex);
                    else
                        LogHelper.WriteErrorLog($"转换为GreenOnions消息失败, 原消息类型为:{miraiMessage[i].Data.GetType()}", ex);
                }
            }

            greenOnionsMessages.Id = miraiMessage.MessageId;
            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static MessageBody ToOneBotMessages(this GreenOnionsMessages greenOnionsMessage, int? coverReplyId = null)
        {
            if (!greenOnionsMessage.IsGreenOnionsCommand)
                greenOnionsMessage.ReplaceGreenOnionsStringTags();

            if (coverReplyId is not null)
                greenOnionsMessage.ReplyId = coverReplyId;

            MessageBody oneBotMessages = new MessageBody();
            if (greenOnionsMessage.Reply && greenOnionsMessage.ReplyId is not null)
                oneBotMessages.Add(SoraSegment.Reply((int)greenOnionsMessage.ReplyId.Value));

            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                    {
                        if (!string.IsNullOrEmpty( txtMsg.Text))
                            oneBotMessages.Add(SoraSegment.Text(txtMsg.Text));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
                    {
                        string data = string.IsNullOrEmpty(imgMsg.Url) ? ("base64://" + imgMsg.Base64Str) : imgMsg.Url.Replace("//","/").Replace("http:/", "http://").Replace("https:/", "https://");
                        oneBotMessages.Add(SoraSegment.Image(data));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                    {
                        if (atMsg.AtId == -1)
                            oneBotMessages.Add(SoraSegment.AtAll());
                        else
                            oneBotMessages.Add(SoraSegment.At(atMsg.AtId));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsVoiceMessage voiceMsg)
                    {
                        string data = string.IsNullOrEmpty(voiceMsg.Url) ? ("base64://" + voiceMsg.Base64Str) : voiceMsg.Url;
                        oneBotMessages.Add(SoraSegment.Record(data));
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"转换为OneBot消息失败!!! 消息类型为：{greenOnionsMessage[i].GetType()}", ex);
                    continue;
                }
            }
            return oneBotMessages;
        }

        public static List<CustomNode> ToOneBotForwardMessage(this GreenOnionsMessages msgs)
        {
            List<CustomNode> nodes = new List<CustomNode>();
            for (int i = 0; i < msgs.Count; i++)
            {
                if (msgs[i] is not GreenOnionsForwardMessage forwardMsg)
                    continue;
                for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                {
                    var innerMsg = forwardMsg.ItemMessages[j].itemMessage.ToOneBotMessages();
                    if (innerMsg.Count == 0)
                        continue;
                    nodes.Add(new CustomNode(forwardMsg.ItemMessages[j].NickName, forwardMsg.ItemMessages[j].QQid, innerMsg));
                }
            }
            return nodes;
        }

        public static GreenOnionsMemberInfo ToGreenOnionsMemberInfo(this GroupMemberInfo groupMemberInfo)
        {
            return new GreenOnionsMemberInfo(groupMemberInfo.UserId, groupMemberInfo.Card, (Permission)((int)groupMemberInfo.Role - 1));
        }
    }
}
