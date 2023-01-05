using GreenOnions.Interface;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.Entities.Base;
using Sora.Entities.Info;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;

namespace GreenOnions.BotMain.CqHttp
{
    public static class CqHttpMessageConverter
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
                        LogHelper.WriteErrorLogWithUserMessage($"转换为GreenOnions消息失败, SoraApi为空, 原消息类型为:{miraiMessage[i].Data.GetType()}", ex);
                    else
                        LogHelper.WriteErrorLogWithUserMessage($"转换为GreenOnions消息失败, 原消息类型为:{miraiMessage[i].Data.GetType()}", ex);
                }
            }

            greenOnionsMessages.Id = miraiMessage.MessageId;
            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static MessageBody ToCqHttpMessages(this GreenOnionsMessages greenOnionsMessage, int? RelpyId)
        {
            if (!greenOnionsMessage.IsGreenOnionsCommand)
                greenOnionsMessage.ReplaceGreenOnionsStringTags();

            MessageBody cqHttpMessages = new MessageBody();
            if (greenOnionsMessage.Reply && RelpyId is not null)
                cqHttpMessages.Add(SoraSegment.Reply(RelpyId.Value));

            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                    {
                        cqHttpMessages.Add(SoraSegment.Text(txtMsg.Text));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
                    {
                        string data = string.IsNullOrEmpty(imgMsg.Url) ? ("base64://" + imgMsg.Base64Str) : imgMsg.Url.Replace("//","/").Replace("http:/", "http://").Replace("https:/", "https://");
                        cqHttpMessages.Add(SoraSegment.Image(data));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                    {
                        if (atMsg.AtId == -1)
                            cqHttpMessages.Add(SoraSegment.AtAll());
                        else
                            cqHttpMessages.Add(SoraSegment.At(atMsg.AtId));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsForwardMessage forwardMsg)
                    {
                        for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                        {
                            var itemMsg = ToCqHttpMessages(forwardMsg.ItemMessages[i].itemMessage, RelpyId);
                            if (itemMsg is not null)
                                cqHttpMessages.AddRange(itemMsg);
                        }
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsVoiceMessage voiceMsg)
                    {
                        string data = string.IsNullOrEmpty(voiceMsg.Url) ? ("base64://" + voiceMsg.Base64Str) : voiceMsg.Url;
                        cqHttpMessages.Add(SoraSegment.Record(data));
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage($"转换为CqHttp消息失败!!! 消息类型为：{greenOnionsMessage[i].GetType()}", ex);
                    continue;
                }
                
            }
            return cqHttpMessages;
        }

        public static List<CustomNode> ToCqHttpForwardMessage(this GreenOnionsMessages msgs)
        {
            List<CustomNode> nodes = new List<CustomNode>();
            for (int i = 0; i < msgs.Count; i++)
            {
                if (msgs[i] is GreenOnionsForwardMessage forwardMsg)
                {
                    for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                    {
                        nodes.Add(new CustomNode(forwardMsg.ItemMessages[j].NickName, forwardMsg.ItemMessages[j].QQid, forwardMsg.ItemMessages[j].itemMessage.ToCqHttpMessages(null)));
                    }
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
