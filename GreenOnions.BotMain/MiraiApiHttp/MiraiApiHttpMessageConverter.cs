using GreenOnions.Interface;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    public static class MiraiApiHttpMessageConverter
    {
        public static GreenOnionsMessages ToGreenOnionsMessages(this IChatMessage[] miraiMessage, long senderId, string senderName)
        {
            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            for (int i = 0; i < miraiMessage.Length; i++)
            {
                try
                {
                    if (miraiMessage[i] is IAtMessage atMsg)
                        greenOnionsMessages.Add(new GreenOnionsAtMessage(atMsg.Target, atMsg.Display));
                    else if (miraiMessage[i] is IPlainMessage plainMsg)
                        greenOnionsMessages.Add(plainMsg.ToString() ?? string.Empty);
                    else if (miraiMessage[i] is IImageMessage imageMsg)
                        greenOnionsMessages.Add(new GreenOnionsImageMessage(ImageHelper.ReplaceGroupUrl(imageMsg.Url!)));
                    else if (miraiMessage[i] is IFaceMessage faceMsg)
                        greenOnionsMessages.Add(new GreenOnionsFaceMessage(faceMsg.Id, faceMsg.Name!));
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage($"转换为GreenOnions消息失败, 原消息类型为:{miraiMessage[i].GetType()}", ex);
                }
            }

            greenOnionsMessages.Id = (miraiMessage[0] as Mirai.CSharp.HttpApi.Models.ChatMessages.SourceMessage)!.Id;
            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static async Task<IChatMessage[]> ToMiraiApiHttpMessages(this GreenOnionsMessages greenOnionsMessage, IMiraiHttpSession session, UploadTarget uploadTarget)
        {
            if (!greenOnionsMessage.IsGreenOnionsCommand)
                greenOnionsMessage.ReplaceGreenOnionsStringTags();

            List<IChatMessage> miraiApiHttpMessages = new List<IChatMessage>();
            List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode> nodes = new List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode>();
            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                    {
                        if (!string.IsNullOrEmpty(txtMsg.Text))
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(txtMsg.Text));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
                    {
                        if (!string.IsNullOrEmpty(imgMsg.Url))
                        {
                            string? url = null;
                            string? path = null;
                            if (File.Exists(imgMsg.Url))
                                path = imgMsg.Url;
                            else
                                url = imgMsg.Url;
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage(null, url, path));
                        }
                        else if (!string.IsNullOrEmpty(imgMsg.Base64Str))
                        {
                            using MemoryStream ms = imgMsg.MemoryStream!;
                            miraiApiHttpMessages.Add(await session.UploadPictureAsync(uploadTarget, ms));
                        }
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                    {
                        if (atMsg.AtId == -1)
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.AtAllMessage());
                        else
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.AtMessage(atMsg.AtId));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsForwardMessage forwardMsg)
                    {
                        for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                        {
                            var itemMsg = (await ToMiraiApiHttpMessages(forwardMsg.ItemMessages[j].itemMessage, session, uploadTarget)).Select(msg => msg as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage);
                            if (itemMsg is not null)
                            {
                                Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode node = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                {
                                    Id = i * j + j,
                                    Name = forwardMsg.ItemMessages[j].NickName,
                                    QQNumber = forwardMsg.ItemMessages[j].QQid,
                                    Time = DateTime.Now,
                                    Chain = itemMsg.ToArray()!,
                                };
                                nodes.Add(node);
                            }
                        }
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsVoiceMessage voiceMsg)
                    {
                        if (!string.IsNullOrEmpty(voiceMsg.Url))
                        {
                            string? url = null;
                            string? path = null;
                            if (File.Exists(voiceMsg.Url))
                                path = voiceMsg.Url;
                            else
                                url = voiceMsg.Url;
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.VoiceMessage(null, url, path));
                        }
                        else if (!string.IsNullOrEmpty(voiceMsg.Base64Str))
                        {
                            using MemoryStream ms = voiceMsg.MemoryStream!;
                            miraiApiHttpMessages.Add(await session.UploadVoiceAsync(uploadTarget, ms));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage("转换为MiraiApiHttp消息失败!!!", ex);
                    continue;
                }
            }
            if (nodes.Count > 0)
            {
                Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage forwardMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage(nodes.ToArray());
                miraiApiHttpMessages.Add(forwardMessage);
            }
            return miraiApiHttpMessages.ToArray();
        }

        public static GreenOnionsMemberInfo ToGreenOnionsMemberInfo(this IGroupMemberInfo groupMemberInfo)
        {
            return new GreenOnionsMemberInfo(groupMemberInfo.Id, groupMemberInfo.Name, (Permission)(int)groupMemberInfo.Permission);
        }
    }
}
