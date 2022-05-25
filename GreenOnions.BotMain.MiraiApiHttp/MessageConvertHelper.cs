using GreenOnions.Model;
using Mirai.CSharp.Models.ChatMessages;
using System.Collections.Generic;

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
    }
}
