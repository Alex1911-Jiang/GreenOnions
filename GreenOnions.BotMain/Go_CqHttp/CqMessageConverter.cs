using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;
using GreenOnions.BotMain.OneBot;
using GreenOnions.Interface;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    public static class CqMessageConverter
    {
        public static GreenOnionsMessages ToGreenOnionsMessages(this CqMessage cqMessage, long messageId, long senderId, string senderName)
        {
            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            for (int i = 0; i < cqMessage.Count; i++)
            {
                try
                {
                    if (cqMessage[i] is CqAtMsg atMsg)
                        greenOnionsMessages.Add(new GreenOnionsAtMessage(atMsg.Target, atMsg.Name));
                    else if (cqMessage[i] is CqTextMsg textMsg)
                        greenOnionsMessages.Add(textMsg.ToString() ?? string.Empty);
                    else if (cqMessage[i] is CqImageMsg imageMsg)
                        greenOnionsMessages.Add(new GreenOnionsImageMessage(ImageHelper.ReplaceGroupUrl(imageMsg.Url!.ToString()!)));
                    else if (cqMessage[i] is CqFaceMsg faceMsg)
                        greenOnionsMessages.Add(new GreenOnionsFaceMessage(faceMsg.Id, faceMsg.MsgType));
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"转换为GreenOnions消息失败, 原消息类型为:{cqMessage[i].GetType()}", ex);
                }
            }

            greenOnionsMessages.Id = messageId;
            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static CqMessage ToCqMessages(this GreenOnionsMessages greenOnionsMessage)
        {
            if (!greenOnionsMessage.IsGreenOnionsCommand)
                greenOnionsMessage.ReplaceGreenOnionsStringTags();

            CqMessage cqMessage = new CqMessage();
            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                    {
                        if (!string.IsNullOrEmpty(txtMsg.Text))
                            cqMessage.Add(new CqTextMsg(txtMsg.Text));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
                    {
                        if (!string.IsNullOrEmpty(imgMsg.Url))
                        {
                            cqMessage.Add(new CqImageMsg(imgMsg.Url));
                        }
                        else if (!string.IsNullOrEmpty(imgMsg.Base64Str))
                        {
                            cqMessage.Add(new CqImageMsg($"base64://{imgMsg.Base64Str}"));
                        }
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                    {
                        if (atMsg.AtId == -1)
                            cqMessage.Add(CqAtMsg.AtAll);
                        else
                            cqMessage.Add(new CqAtMsg(atMsg.AtId));
                    }
                    //else if (greenOnionsMessage[i] is GreenOnionsForwardMessage forwardMsg)
                    //{
                        
                    //}
                    else if (greenOnionsMessage[i] is GreenOnionsVoiceMessage voiceMsg)
                    {
                        if (!string.IsNullOrEmpty(voiceMsg.Url))
                        {
                            cqMessage.Add(new CqRecordMsg(voiceMsg.Url));
                        }
                        else if (!string.IsNullOrEmpty(voiceMsg.Base64Str))
                        {
                            cqMessage.Add(new CqRecordMsg($"base64://{voiceMsg.Base64Str}"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog("转换为MiraiApiHttp消息失败!!!", ex);
                    continue;
                }
            }
            return cqMessage;
        }

        public static CqForwardMessage ToCqForwardMessage(this GreenOnionsMessages msgs)
        {
            CqForwardMessage nodes = new CqForwardMessage();
            for (int i = 0; i < msgs.Count; i++)
            {
                if (msgs[i] is not GreenOnionsForwardMessage forwardMsg)
                    continue;
                for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                {
                    var itemMsg = forwardMsg.ItemMessages[j].itemMessage.ToCqMessages();
                    if (itemMsg is null)
                        continue;
                    CqForwardMessageNode node = new CqForwardMessageNode(forwardMsg.ItemMessages[j].NickName, forwardMsg.ItemMessages[j].QQid, itemMsg);
                    nodes.Add(node);
                }
            }
            return nodes;
        }
        public static GreenOnionsMemberInfo ToGreenOnionsMemberInfo(this CqGroupMember groupMemberInfo)
        {
            int iRole = groupMemberInfo.Role == CqRole.Owner ? 2 : (int)groupMemberInfo.Role;
            return new GreenOnionsMemberInfo(groupMemberInfo.GroupId, groupMemberInfo.Nickname, (Permission)iRole);
        }
        public static GreenOnionsMemberInfo ToGreenOnionsMemberInfo(this CqGetGroupMemberInformationActionResult groupMemberInfo)
        {
            int iRole = groupMemberInfo.Role == CqRole.Owner ? 2 : (int)groupMemberInfo.Role;
            return new GreenOnionsMemberInfo(groupMemberInfo.GroupId, groupMemberInfo.Nickname, (Permission)iRole);
        }
    }
}
