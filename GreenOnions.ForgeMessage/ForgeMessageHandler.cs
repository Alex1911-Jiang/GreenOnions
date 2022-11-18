using GreenOnions.Interface;
using GreenOnions.Interface.Helpers;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System;
using System.Linq;

namespace GreenOnions.ForgeMessage
{
    public static class ForgeMessageHandler
    {
        public static void SendForgeMessage(GreenOnionsMessages originalMsg, long qqId, Action<GreenOnionsMessages> SendMessage)
        {
            if (!BotInfo.Config.ForgeMessageAdminOnly || BotInfo.Config.AdminQQ.Contains(qqId))
            {
                if (originalMsg.Count > 2 && (originalMsg[1] is GreenOnionsAtMessage atMsg))
                {
                    if (!BotInfo.Config.AdminQQ.Contains(qqId) && BotInfo.Config.AdminQQ.Contains(atMsg.AtId))
                    {
                        SendMessage(BotInfo.Config.RefuseForgeAdminReply);
                        return;
                    }
                    if (!BotInfo.Config.AdminQQ.Contains(qqId) && atMsg.AtId == BotInfo.Config.QQId)
                    {
                        SendMessage(BotInfo.Config.RefuseForgeBotReply);
                        return;
                    }

                    GreenOnionsForwardMessage forwardMessage = new GreenOnionsForwardMessage();
                    for (int i = 2; i < originalMsg.Count; i++)
                    {
                        if (originalMsg[i] is GreenOnionsTextMessage textMsg)
                        {
                            string[] plainMsgs = textMsg.ToString().Trim().Split(BotInfo.Config.ForgeMessageCmdNewLine);
                            for (int j = 0; j < plainMsgs.Length; j++)
                            {
                                if (!string.IsNullOrEmpty(plainMsgs[j]))
                                    forwardMessage.Add(atMsg.AtId, atMsg.NickName, new GreenOnionsMessages(plainMsgs[j]));
                            }
                        }
                        else if (originalMsg[i] is GreenOnionsImageMessage imageMsg)
                        {
                            forwardMessage.Add(atMsg.AtId, atMsg.NickName, new GreenOnionsMessages(imageMsg));
                        }
                        else
                            continue;
                    }

                    if (BotInfo.Config.ForgeMessageAppendBotMessageEnabled)
                    {
                        if (!BotInfo.Config.ForgeMessageAdminDontAppend || !BotInfo.Config.AdminQQ.Contains(qqId))
                            forwardMessage.Add(BotInfo.Config.QQId, BotInfo.Config.BotName, new GreenOnionsMessages(BotInfo.Config.ForgeMessageAppendMessage));
                    }
                    SendMessage(forwardMessage);
                }
            }
        }
    }
}
