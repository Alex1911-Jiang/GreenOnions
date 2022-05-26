using GreenOnions.Model;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    public static class MessageConvertHelper
    {
        public static GreenOnionsMessageGroup ToOnionsMessages(this IChatMessage[] miraiMessage)
        {
            GreenOnionsMessageGroup greenOnionsMessages = new GreenOnionsMessageGroup();
            for (int i = 0; i < miraiMessage.Length; i++)
            {
                if (miraiMessage[i] is IAtMessage atMsg)
                    greenOnionsMessages.Add(new GreenOnionsAtMessage(atMsg.Target, atMsg.Display));
                else if (miraiMessage[i] is IPlainMessage plainMsg)
                    greenOnionsMessages.Add(plainMsg.ToString());
                else if (miraiMessage[i] is IImageMessage imageMsg)
                    greenOnionsMessages.Add(new GreenOnionsImageMessage(imageMsg.Url));
            }
            return greenOnionsMessages;
        }

        public static async Task<IChatMessage> ToMiraiApiHttpMessage(this GreenOnionsBaseMessage greenOnionsMessage, IMiraiHttpSession session, UploadTarget uploadTarget)
        {
            if (greenOnionsMessage is GreenOnionsTextMessage txtMsg)
            {
                return new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(txtMsg.Text);
            }
            else if (greenOnionsMessage is GreenOnionsImageMessage imgMsg)
            {
                if (!string.IsNullOrEmpty(imgMsg.Url))
                {
                    string url = null;
                    string path = null;
                    if (File.Exists(imgMsg.Url))
                        path = imgMsg.Url;
                    else
                        url = imgMsg.Url;
                    return new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage(null, url, path);
                }
                else if (!string.IsNullOrEmpty(imgMsg.Base64Str))
                {
                    using (MemoryStream ms = imgMsg.MemoryStream)
                    {
                        return await session.UploadPictureAsync(uploadTarget, ms);
                    }
                }
            }
            else if (greenOnionsMessage is GreenOnionsAtMessage atMsg)
            {
                if (atMsg.AtId == -1)
                    return new Mirai.CSharp.HttpApi.Models.ChatMessages.AtAllMessage();
                else
                    return new Mirai.CSharp.HttpApi.Models.ChatMessages.AtMessage(atMsg.AtId);
            }
            else if (greenOnionsMessage is GreenOnionsForwardMessage forwardMsg)
            {
                List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode> nodes = new List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode>();
                for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                {
                    Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode node = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                    {
                        Id = j,
                        Name = forwardMsg.ItemMessages[j].NickName,
                        QQNumber = forwardMsg.ItemMessages[j].QQid,
                        Time = DateTime.Now,
                        Chain = (await ToMiraiApiHttpMessages(forwardMsg.ItemMessages[j].itemMessage, session, uploadTarget)).Select(msg => msg as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage).ToArray(),
                    };
                    nodes.Add(node);
                }
                Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage forwardMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage(nodes.ToArray());
                return forwardMessage;
            }
            return null;
        }

        public static async Task<IChatMessage[]> ToMiraiApiHttpMessages(this GreenOnionsMessageGroup greenOnionsMessage, IMiraiHttpSession session, UploadTarget uploadTarget)
        {
            List<IChatMessage> miraiApiHttpMessages = new List<IChatMessage>();
            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                {
                    miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(txtMsg.Text));
                }
                else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
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
                else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                {
                    if (atMsg.AtId == -1)
                        miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.AtAllMessage());
                    else
                        miraiApiHttpMessages.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.AtMessage(atMsg.AtId));
                }
                else if (greenOnionsMessage[i] is GreenOnionsForwardMessage forwardMsg)
                {
                    List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode> nodes = new List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode>();
                    for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                    {
                        Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode node = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                        {
                            Id = j,
                            Name = forwardMsg.ItemMessages[j].NickName,
                            QQNumber = forwardMsg.ItemMessages[j].QQid,
                            Time = DateTime.Now,
                            Chain = (await ToMiraiApiHttpMessages(forwardMsg.ItemMessages[j].itemMessage, session, uploadTarget)).Select(msg => msg as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage).ToArray(),
                        };
                        nodes.Add(node);
                    }
                    Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage forwardMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage(nodes.ToArray());
                    miraiApiHttpMessages.Add(forwardMessage);
                }
            }
            return miraiApiHttpMessages.ToArray();
        }
    }
}
