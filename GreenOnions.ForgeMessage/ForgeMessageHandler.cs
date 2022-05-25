using GreenOnions.Model;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System;
using System.Linq;

namespace GreenOnions.ForgeMessage
{
    public static class ForgeMessageHandler
    {
        public static void SendForgeMessage(GreenOnionsMessageGroup originMsg, long qqId, Action<GreenOnionsMessageGroup> SendMessage)
        {
            if (!BotInfo.ForgeMessageAdminOnly || BotInfo.AdminQQ.Contains(qqId))
            {
                if (originMsg.Count > 2 && (originMsg[1] is GreenOnionsAtMessage atMsg))
                {
                    if (!BotInfo.AdminQQ.Contains(qqId) && BotInfo.AdminQQ.Contains(atMsg.AtId))
                        SendMessage(BotInfo.RefuseForgeAdminReply.ReplaceGreenOnionsTags());
                    if (!BotInfo.AdminQQ.Contains(qqId) && atMsg.AtId == BotInfo.QQId)
                        SendMessage(BotInfo.RefuseForgeBotReply.ReplaceGreenOnionsTags());

                    GreenOnionsForwardMessage forwardMessage = new GreenOnionsForwardMessage();
                    for (int i = 2; i < originMsg.Count; i++)
                    {
                        if (originMsg[i] is GreenOnionsTextMessage textMsg)
                        {
                            string[] plainMsgs = textMsg.ToString().Trim().Split(BotInfo.ForgeMessageCmdNewLine);
                            for (int j = 0; j < plainMsgs.Length; j++)
                            {
                                if (!string.IsNullOrEmpty(plainMsgs[j]))
                                    forwardMessage.Add(atMsg.AtId, atMsg.NickName, plainMsgs[j]);
                            }
                        }
                        else if (originMsg[i] is GreenOnionsImageMessage imageMsg)
                        {
                            forwardMessage.Add(atMsg.AtId, atMsg.NickName, imageMsg);
                        }
                        else
                            continue;
                    }

                    if (BotInfo.ForgeMessageAppendBotMessageEnabled)
                    {
                        if (!BotInfo.ForgeMessageAdminDontAppend || !BotInfo.AdminQQ.Contains(qqId))
                            forwardMessage.Add(BotInfo.QQId, BotInfo.BotName, BotInfo.ForgeMessageAppendMessage.ReplaceGreenOnionsTags());
                    }
                    SendMessage(forwardMessage);
                }
            }
        }
    }
}
