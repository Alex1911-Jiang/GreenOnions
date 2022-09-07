using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.EventArgs.SoraEvent;

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
            bool isHandle = await MessageHandler.HandleMesage(await eventArgs.Message.MessageBody.ToOnionsMessages(eventArgs.SenderInfo.UserId, eventArgs.SenderInfo.Nick, eventArgs.SourceGroup, eventArgs.SoraApi), eventArgs.SourceGroup.Id, outMsg =>
            {
                if (outMsg != null && outMsg.Count > 0)
                {
                    ValueTask<(ApiStatus apiStatus, int messageId)> result;
                    if (outMsg.FirstOrDefault() is GreenOnionsForwardMessage)
                        result = eventArgs.SoraApi.SendGroupForwardMsg(eventArgs.SourceGroup.Id, outMsg.ToCqHttpForwardMessage());
                    else
                        result = eventArgs.SoraApi.SendGroupMessage(eventArgs.SourceGroup.Id, outMsg.ToCqHttpMessages(quoteId));
                    if (outMsg.RevokeTime > 0)
                    {
                        _ = result.AsTask().ContinueWith(async t =>
                        {
                            await Task.Delay(1000 * outMsg.RevokeTime);
                            _ = eventArgs.SoraApi.RecallMessage(result.Result.messageId);
                        });
                    }
                }
            });
            eventArgs.IsContinueEventChain = !isHandle;
        }

        public static async ValueTask Event_OnPrivateMessage(string eventType, PrivateMessageEventArgs eventArgs)
        {
            if (!CheckPreconditionsPrivate(eventArgs))
            {
                return;
            }
            LogHelper.WriteInfoLog($"收到来自{eventArgs.Sender.Id}的私聊消息");

            int quoteId = eventArgs.Message.MessageId;
            bool isHandle = await MessageHandler.HandleMesage(await eventArgs.Message.MessageBody.ToOnionsMessages(eventArgs.SenderInfo.UserId, eventArgs.SenderInfo.Nick, null, eventArgs.SoraApi), null, outMsg =>
            {
                if (outMsg != null && outMsg.Count > 0)
                {
                    if (outMsg.FirstOrDefault() is GreenOnionsForwardMessage)
                    {
                        _ = eventArgs.SoraApi.SendPrivateForwardMsg(eventArgs.Sender.Id, outMsg.ToCqHttpForwardMessage());
                    }
                    else
                    {
                        ValueTask<(ApiStatus apiStatus, int messageId)> result = eventArgs.SoraApi.SendPrivateMessage(eventArgs.Sender.Id, outMsg.ToCqHttpMessages(quoteId));
                        if (outMsg.RevokeTime > 0)
                        {
                            _ = result.AsTask().ContinueWith(async t =>
                            {
                                await Task.Delay(1000 * outMsg.RevokeTime);
                                _ = eventArgs.SoraApi.RecallMessage(result.Result.messageId);
                            });
                        }
                    }
                }
            });
            eventArgs.IsContinueEventChain = !isHandle;
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
