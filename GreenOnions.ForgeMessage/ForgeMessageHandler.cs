using System;
using System.Collections.Generic;
using System.Linq;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.Models.ChatMessages;

namespace GreenOnions.ForgeMessage
{
    public static class ForgeMessageHandler
    {
        public static void SendForgeMessage(IChatMessage[] Chain, long qqId, Action<IChatMessage[], bool> SendMessage)
        {
            if (!BotInfo.ForgeMessageAdminOnly || BotInfo.AdminQQ.Contains(qqId))
            {
                if (Chain.Length > 3 && (Chain[2] is MyAtMessage))
                {
                    MyAtMessage atMessage = Chain[2] as MyAtMessage;
                    if (!BotInfo.AdminQQ.Contains(qqId) && BotInfo.AdminQQ.Contains(atMessage.Target))
                    {
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.RefuseForgeAdminReply.ReplaceGreenOnionsTags()) }, false);
                        return;
                    }
                    if (!BotInfo.AdminQQ.Contains(qqId) && atMessage.Target == BotInfo.QQId)
                    {
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.RefuseForgeBotReply.ReplaceGreenOnionsTags()) }, false);
                        return;
                    }

                    List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode> forwardMessageNodes = new List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode>();
                    for (int i = 3; i < Chain.Length; i++)
                    {
                        if (Chain[i] is IPlainMessage)
                        {
                            string[] plainMsgs = Chain[i].ToString().Trim().Split(BotInfo.ForgeMessageCmdNewLine);
                            for (int j = 0; j < plainMsgs.Length; j++)
                            {
                                if (!string.IsNullOrEmpty(plainMsgs[j]))
                                {
                                    forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                    {
                                        Id = forwardMessageNodes.Count,
                                        Name = atMessage.Name,
                                        QQNumber = atMessage.Target,
                                        Time = DateTime.Now,
                                        Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(plainMsgs[j]) },
                                    });
                                }
                            }
                        }
                        else if (Chain[i] is IImageMessage)
                        {
                            forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                            {
                                Id = forwardMessageNodes.Count,
                                Name = atMessage.Name,
                                QQNumber = atMessage.Target,
                                Time = DateTime.Now,
                                Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage((Chain[i] as IImageMessage).ImageId, null, null) },
                            });
                        }
                        else
                            continue;
                    }

                    if (BotInfo.ForgeMessageAppendBotMessageEnabled)
                    {
                        if (!BotInfo.ForgeMessageAdminDontAppend || !BotInfo.AdminQQ.Contains(qqId))
                        {
                            forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                            {
                                Id = forwardMessageNodes.Count,
                                Name = BotInfo.BotName,
                                QQNumber = BotInfo.QQId,
                                Time = DateTime.Now,
                                Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.ForgeMessageAppendMessage.ReplaceGreenOnionsTags()) },
                            });
                        }
                    }

                    Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage forwardMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage(forwardMessageNodes.ToArray());
                    SendMessage?.Invoke(new[] { forwardMessage }, false);
                }
            }
        }
    }
}
