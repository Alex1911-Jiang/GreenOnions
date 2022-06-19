using GreenOnions.Model;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System;
using System.Linq;

namespace GreenOnions.ForgeMessage
{
    public static class ForgeMessageHandler
    {
        public static void SendForgeMessage(GreenOnionsMessages originMsg, long qqId, Action<GreenOnionsMessages> SendMessage)
        {
            if (!BotInfo.ForgeMessageAdminOnly || BotInfo.AdminQQ.Contains(qqId))
            {
                if (originMsg.Count > 2 && (originMsg[1] is GreenOnionsAtMessage atMsg))
                {
                    if (!BotInfo.AdminQQ.Contains(qqId) && BotInfo.AdminQQ.Contains(atMsg.AtId))
                    {
                        SendMessage(BotInfo.RefuseForgeAdminReply.ReplaceGreenOnionsTags());
                        return;
                    }
                    if (!BotInfo.AdminQQ.Contains(qqId) && atMsg.AtId == BotInfo.QQId)
                    {
                        SendMessage(BotInfo.RefuseForgeBotReply.ReplaceGreenOnionsTags());
                        return;
                    }

                    GreenOnionsForwardMessage forwardMessage = new GreenOnionsForwardMessage();
                    for (int i = 2; i < originMsg.Count; i++)
                    {
                        if (originMsg[i] is GreenOnionsTextMessage textMsg)
                        {
                            string[] plainMsgs = textMsg.ToString().Trim().Split(BotInfo.ForgeMessageCmdNewLine);
                            for (int j = 0; j < plainMsgs.Length; j++)
                            {
                                if (!string.IsNullOrEmpty(plainMsgs[j]))
                                    forwardMessage.Add(atMsg.AtId, atMsg.NickName, new GreenOnionsMessages(plainMsgs[j]));
                            }
                        }
                        else if (originMsg[i] is GreenOnionsImageMessage imageMsg)
                        {
                            forwardMessage.Add(atMsg.AtId, atMsg.NickName, new GreenOnionsMessages(imageMsg));
                        }
                        else
                            continue;
                    }

                    if (BotInfo.ForgeMessageAppendBotMessageEnabled)
                    {
                        if (!BotInfo.ForgeMessageAdminDontAppend || !BotInfo.AdminQQ.Contains(qqId))
                            forwardMessage.Add(BotInfo.QQId, BotInfo.BotName, new GreenOnionsMessages(BotInfo.ForgeMessageAppendMessage.ReplaceGreenOnionsTags()));
                    }
                    SendMessage(forwardMessage);
                }
            }
        }
    }
}
