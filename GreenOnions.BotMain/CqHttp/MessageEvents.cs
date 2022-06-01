using GreenOnions.Model;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.Entities.Segment.DataModel;
using Sora.EventArgs.SoraEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.BotMain.CqHttp
{
    public static class MessageEvents
    {
        public static async ValueTask Event_OnGroupMessage(string eventType, GroupMessageEventArgs eventArgs)
        {
            if (!CheckPreconditionsGroup(eventArgs))
            {
                return;
            }
            LogHelper.WriteInfoLog($"收到来自{eventArgs.Sender.Id}的群消息");

            int quoteId = eventArgs.Message.MessageId;
            bool isHandle = await MessageHandler.HandleMesage(eventArgs.Message.MessageBody.ToOnionsMessages(), eventArgs.Sender.Id, eventArgs.SourceGroup.Id, async outMsg =>
            {
                if (outMsg != null)
                {
                    if (outMsg != null && outMsg.Count > 0)
                    {
                        if (outMsg.First() is GreenOnionsForwardMessage forwardMessage)
                        {
                            _ = eventArgs.SoraApi.SendGroupForwardMsg(eventArgs.SourceGroup.Id, forwardMessage.ToCqHttpForwardMessage());
                        }
                        else
                        {
                            ValueTask<(ApiStatus, int)> result = eventArgs.SoraApi.SendGroupMessage(eventArgs.SourceGroup.Id, outMsg.ToCqHttpMessages(quoteId));
                            if (outMsg.RevokeTime > 0)
                            {
                                _ = result.AsTask().ContinueWith(async t =>
                                {
                                    await Task.Delay(1000 * outMsg.RevokeTime);
                                    _ = eventArgs.SoraApi.RecallMessage(outMsg.RevokeTime);
                                }); 
                            }
                        }
                    }
                }
            });
        }

        public static async ValueTask Event_OnPrivateMessage(string eventType, PrivateMessageEventArgs eventArgs)
        {
            if (!CheckPreconditionsPrivate(eventArgs))
            {
                return;
            }
            LogHelper.WriteInfoLog($"收到来自{eventArgs.Sender.Id}的私聊消息");

            int quoteId = eventArgs.Message.MessageId;
            bool isHandle = await MessageHandler.HandleMesage(eventArgs.Message.MessageBody.ToOnionsMessages(), eventArgs.Sender.Id, null, outMsg =>
            {
                if (outMsg != null)
                {
                    if (outMsg != null && outMsg.Count > 0)
                    {
                        //if (outMsg.First() is GreenOnionsForwardMessage forwardMessage)
                        //{
                        //    _ = eventArgs.SoraApi.SendGroupForwardMsg(eventArgs.Sender.Id, forwardMessage.ToCqHttpForwardMessage());
                        //}
                        //else
                        //{
                            //没有私聊合并转发api?
                            ValueTask<(ApiStatus apiStatus, int messageId)> result = eventArgs.SoraApi.SendPrivateMessage(eventArgs.Sender.Id, outMsg.ToCqHttpMessages(quoteId));
                            if (outMsg.RevokeTime > 0)
                            {
                                _ = result.AsTask().ContinueWith(async t =>
                                {
                                    await Task.Delay(1000 * outMsg.RevokeTime);
                                    _ = eventArgs.SoraApi.RecallMessage(result.Result.messageId);
                                });
                            }
                        //}
                    }
                }
            });
        }

        private static bool CheckPreconditionsGroup(GroupMessageEventArgs e)
        {
            if (BotInfo.BannedGroup.Contains(e.SourceGroup.Id) ||
                BotInfo.BannedUser.Contains(e.Sender.Id))
            {
                return false;
            }
            if (BotInfo.DebugMode)
            {
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Sender.Id))
                        return false;
                if (BotInfo.OnlyReplyDebugGroup)
                    if (!BotInfo.DebugGroups.Contains(e.SourceGroup.Id))
                        return false;
            }
            return true;
        } 
        
        private static bool CheckPreconditionsPrivate(PrivateMessageEventArgs e)
        {
            if (BotInfo.BannedUser.Contains(e.Sender.Id))
            {
                return false;
            }
            if (BotInfo.DebugMode)
            {
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Sender.Id))
                        return false;
            }
            return true;
        }
    }
}
