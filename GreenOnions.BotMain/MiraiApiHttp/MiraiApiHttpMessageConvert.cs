using GreenOnions.Interface;
using GreenOnions.Model;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    public static class MiraiApiHttpMessageConvert
    {
        public static GreenOnionsMessages ToOnionsMessages(this IChatMessage[] miraiMessage, long senderId, string senderName)
        {
            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            for (int i = 0; i < miraiMessage.Length; i++)
            {
                if (miraiMessage[i] is IAtMessage atMsg)
                    greenOnionsMessages.Add(new GreenOnionsAtMessage(atMsg.Target, atMsg.Display));
                else if (miraiMessage[i] is IPlainMessage plainMsg)
                    greenOnionsMessages.Add(plainMsg.ToString());
                else if (miraiMessage[i] is IImageMessage imageMsg)
                    greenOnionsMessages.Add(new GreenOnionsImageMessage(imageMsg.Url, imageMsg.ImageId));
            }

            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static async Task<IChatMessage[]> ToMiraiApiHttpMessages(this IGreenOnionsMessages greenOnionsMessage, IMiraiHttpSession session, UploadTarget uploadTarget)
        {
            List<IChatMessage> miraiApiHttpMessages = new List<IChatMessage>();
            List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode> nodes = new List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode>();
            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is IGreenOnionsTextMessage txtMsg)
                    {
                        miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(txtMsg.Text));
                    }
                    else if (greenOnionsMessage[i] is IGreenOnionsImageMessage imgMsg)
                    {
                        if (!string.IsNullOrEmpty(imgMsg.Url))
                        {
                            string url = null;
                            string path = null;
                            if (File.Exists(imgMsg.Url))
                                path = imgMsg.Url;
                            else
                                url = imgMsg.Url;
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage(null, url, path));
                        }
                        else if (!string.IsNullOrEmpty(imgMsg.Base64Str))
                        {
                            using (MemoryStream ms = imgMsg.MemoryStream)
                            {
                                miraiApiHttpMessages.Add(await session.UploadPictureAsync(uploadTarget, ms));
                            }
                        }
                    }
                    else if (greenOnionsMessage[i] is IGreenOnionsAtMessage atMsg)
                    {
                        if (atMsg.AtId == -1)
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.AtAllMessage());
                        else
                            miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.AtMessage(atMsg.AtId));
                    }
                    else if (greenOnionsMessage[i] is IGreenOnionsForwardMessage forwardMsg)
                    {
                        for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                        {
                            var itemMsg = (await ToMiraiApiHttpMessages(forwardMsg.ItemMessages[j].itemMessage, session, uploadTarget)).Select(msg => msg as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage);
                            if (itemMsg != null)
                            {
                                Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode node = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                {
                                    Id = i * j + j,
                                    Name = forwardMsg.ItemMessages[j].NickName,
                                    QQNumber = forwardMsg.ItemMessages[j].QQid,
                                    Time = DateTime.Now,
                                    Chain = itemMsg.ToArray(),
                                };
                                nodes.Add(node);
                            }
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
    }
}
