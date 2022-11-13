using System.Text.RegularExpressions;
using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.Entities.Segment;
using Sora.Enumeration.EventParamsType;
using Sora.EventArgs.SoraEvent;

namespace GreenOnions.BotMain.CqHttp
{
    public static class MessageEvents
    {
        private static readonly Regex regexTags = new Regex("<@?成员QQ>|<成员昵称>|<@?操作者QQ>|<操作者昵称>");
        public static async ValueTask Event_OnGroupMessage(string eventType, GroupMessageEventArgs eventArgs)
        {
            if (eventArgs.SoraApi == null)
            {
                LogHelper.WriteErrorLogWithUserMessage("SoraApi为空", null);
                return;
            }
            if (!CheckPreconditionsGroup(eventArgs))
                return;

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
                return;

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


        public static async ValueTask Event_OnGroupMemberChange(string eventType, GroupMemberChangeEventArgs eventArgs)
        {
            if (!CheckPreconditionsGroup(eventArgs))
                return;

            string cmdMsg = string.Empty;
            switch (eventArgs.SubType)
            {
                case MemberChangeType.Leave:
                    if (BotInfo.SendMemberPositiveLeaveMessage)
                        cmdMsg = BotInfo.MemberPositiveLeaveMessage;
                    break;
                case MemberChangeType.Kick:
                    if (BotInfo.SendMemberBeKickedMessage)
                        cmdMsg = BotInfo.MemberBeKickedMessage;
                    break;
                case MemberChangeType.Approve:
                case MemberChangeType.Invite:
                    if (BotInfo.SendMemberJoinedMessage)
                        cmdMsg = BotInfo.MemberJoinedMessage;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(cmdMsg))
            {
                MessageBody outMsg = await ReplaceMessage(cmdMsg, eventArgs.SourceGroup.Id, eventArgs.ChangedUser, eventArgs.Operator);
                await eventArgs.SoraApi.SendGroupMessage(eventArgs.SourceGroup.Id, outMsg);
            }
        }

        private static async Task<MessageBody> ReplaceMessage(string messageCmd, long group, User member, User? Operator = null)
        {
            MessageBody outMsg = new MessageBody();
            string remainMessage = messageCmd;
            foreach (Match match in regexTags.Matches(messageCmd))
            {
                string matchString = match.ToString();
                int index = remainMessage.IndexOf(matchString);
                string left = remainMessage.Substring(0, index);
                if (!string.IsNullOrEmpty(left))
                {
                    outMsg.AddText(left);
                }
                string right = remainMessage.Substring(index + matchString.Length);
                remainMessage = right;
                string identifier = match.ToString();

                if (identifier == "<@成员QQ>")
                {
                    outMsg.Add(SoraSegment.At(member.Id));
                }
                else if (identifier == "<成员QQ>")
                {
                    outMsg.AddText(member.Id.ToString());
                }
                else if (identifier == "<成员昵称>")
                {
                    var getMember = await member.SoraApi.GetGroupMemberInfo(group, member.Id);
                    if (string.IsNullOrEmpty(getMember.memberInfo.Card))
                    {
                        var getUserInfo = await member.GetUserInfo();
                        outMsg.AddText(getUserInfo.userInfo.Nick);
                    }
                    else
                    {
                        outMsg.AddText(getMember.memberInfo.Card);
                    }
                }
                else if (Operator != null)
                {
                    if (identifier == "<@操作者QQ>")
                    {
                        outMsg.Add(SoraSegment.At(Operator.Id));
                    }
                    else if (identifier == "<操作者QQ>")
                    {
                        outMsg.AddText(Operator.Id.ToString());
                    }
                    else if (identifier == "<操作者昵称>")
                    {
                        var getOperator = await Operator.SoraApi.GetGroupMemberInfo(group, Operator.Id);
                        if (string.IsNullOrEmpty(getOperator.memberInfo.Card))
                        {
                            var getUserInfo = await Operator.GetUserInfo();
                            outMsg.AddText(getUserInfo.userInfo.Nick);
                        }
                        else
                        {
                            outMsg.AddText(getOperator.memberInfo.Card);
                        }
                    }
                }
            }
            outMsg.AddText(remainMessage);
            return outMsg;
        }

        private static bool CheckPreconditionsGroup(GroupMemberChangeEventArgs e)
        {
            if (BotInfo.BannedGroup.Contains(e.SourceGroup.Id) ||
                BotInfo.BannedUser.Contains(e.ChangedUser.Id))
            {
                return false;
            }
            if (BotInfo.DebugMode)
            {
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.ChangedUser.Id))
                        return false;
                if (BotInfo.OnlyReplyDebugGroup)
                    if (!BotInfo.DebugGroups.Contains(e.SourceGroup.Id))
                        return false;
            }
            return true;
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
