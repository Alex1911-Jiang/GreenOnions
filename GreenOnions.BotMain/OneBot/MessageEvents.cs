﻿using System.Text.RegularExpressions;
using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.Entities.Segment;
using Sora.Enumeration.EventParamsType;
using Sora.EventArgs.SoraEvent;

namespace GreenOnions.BotMain.OneBot
{
    public static class MessageEvents
    {
        private static readonly Regex regexTags = new Regex("<@?成员QQ>|<成员昵称>|<@?操作者QQ>|<操作者昵称>", RegexOptions.Compiled);
        public static async ValueTask Event_OnGroupMessage(string eventType, GroupMessageEventArgs eventArgs)
        {
            if (eventArgs.SoraApi == null)
            {
                LogHelper.WriteErrorLog("SoraApi为空", null);
                return;
            }
            if (!CheckPreconditionsGroup(eventArgs))
                return;

            LogHelper.WriteInfoLog($"收到来自{eventArgs.Sender.Id}的群消息");
            int quoteId = eventArgs.Message.MessageId;
            bool isHandle = await MessageHandler.HandleMesage(await eventArgs.Message.ToGreenOnionsMessages(eventArgs.SenderInfo.UserId, eventArgs.SenderInfo.Nick, eventArgs.SourceGroup, eventArgs.SoraApi), eventArgs.SourceGroup.Id, outMsg =>
            {
                if (outMsg is null || outMsg.Count == 0)
                    return;
                if (outMsg.FirstOrDefault() is GreenOnionsForwardMessage)
                {
                    ValueTask<(ApiStatus apiStatus, int messageId, string forwardId)> result = eventArgs.SoraApi.SendGroupForwardMsg(eventArgs.SourceGroup.Id, outMsg.ToOneBotForwardMessage());
                    if (outMsg.RevokeTime > 0)
                    {
                        _ = result.AsTask().ContinueWith(async t =>
                        {
                            await Task.Delay(1000 * outMsg.RevokeTime);
                            _ = eventArgs.SoraApi.RecallMessage(result.Result.messageId);
                        });
                    }
                }
                else
                {
                    var soraMsg = outMsg.ToOneBotMessages(outMsg.Reply ? quoteId : null);
                    if (soraMsg is null || soraMsg.Count == 0)
                        return;
                    ValueTask<(ApiStatus apiStatus, int messageId)> result = eventArgs.SoraApi.SendGroupMessage(eventArgs.SourceGroup.Id, soraMsg);
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
            if (eventArgs.SoraApi == null)
            {
                LogHelper.WriteErrorLog("SoraApi为空", null);
                return;
            }

            if (!CheckPreconditionsPrivate(eventArgs))
                return;

            LogHelper.WriteInfoLog($"收到来自{eventArgs.Sender.Id}的私聊消息");

            int quoteId = eventArgs.Message.MessageId;
            bool isHandle = await MessageHandler.HandleMesage(await eventArgs.Message.ToGreenOnionsMessages(eventArgs.SenderInfo.UserId, eventArgs.SenderInfo.Nick, null, eventArgs.SoraApi), null, outMsg =>
            {
                if (outMsg is null || outMsg.Count == 0)
                    return;
                if (outMsg.FirstOrDefault() is GreenOnionsForwardMessage)
                {
                    _ = eventArgs.SoraApi.SendPrivateForwardMsg(eventArgs.Sender.Id, outMsg.ToOneBotForwardMessage());
                }
                else
                {
                    var soraMsg = outMsg.ToOneBotMessages(outMsg.Reply ? quoteId : null);
                    if (soraMsg is null || soraMsg.Count == 0)
                        return;
                    ValueTask<(ApiStatus apiStatus, int messageId)> result = eventArgs.SoraApi.SendPrivateMessage(eventArgs.Sender.Id, soraMsg);
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


        public static async ValueTask Event_OnGroupMemberChange(string eventType, GroupMemberChangeEventArgs eventArgs)
        {
            if (eventArgs.ChangedUser.Id == BotInfo.Config.QQId)
                return;

            if (eventArgs.SoraApi == null)
            {
                LogHelper.WriteErrorLog("SoraApi为空", null);
                return;
            }

            if (!CheckPreconditionsGroup(eventArgs))
                return;

            string cmdMsg = string.Empty;
            switch (eventArgs.SubType)
            {
                case MemberChangeType.Leave:
                    if (BotInfo.Config.SendMemberPositiveLeaveMessage)
                        cmdMsg = BotInfo.Config.MemberPositiveLeaveMessage;
                    break;
                case MemberChangeType.Kick:
                    if (BotInfo.Config.SendMemberBeKickedMessage)
                        cmdMsg = BotInfo.Config.MemberBeKickedMessage;
                    break;
                case MemberChangeType.Approve:
                case MemberChangeType.Invite:
                    if (BotInfo.Config.SendMemberJoinedMessage)
                        cmdMsg = BotInfo.Config.MemberJoinedMessage;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(cmdMsg))
            {
                MessageBody outMsg = await ReplaceMessage(cmdMsg, eventArgs.SourceGroup.Id, eventArgs.ChangedUser, eventArgs.Operator);
                await eventArgs.SoraApi.SendGroupMessage(eventArgs.SourceGroup.Id, outMsg);
            }
        }

        private static async Task<MessageBody> ReplaceMessage(string messageCmd, long group, User member, User? @operator = null)
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
                else if (@operator is not null)
                {
                    if (identifier == "<@操作者QQ>")
                    {
                        outMsg.Add(SoraSegment.At(@operator.Id));
                    }
                    else if (identifier == "<操作者QQ>")
                    {
                        outMsg.AddText(@operator.Id.ToString());
                    }
                    else if (identifier == "<操作者昵称>")
                    {
                        if (@operator.Id == BotInfo.Config.QQId)
                        {
                            outMsg.AddText(BotInfo.Config.BotName);
                        }
                        else
                        {
                            var getOperator = await @operator.SoraApi.GetGroupMemberInfo(group, @operator.Id);
                            if (string.IsNullOrEmpty(getOperator.memberInfo.Card))
                            {
                                var getUserInfo = await @operator.GetUserInfo();
                                outMsg.AddText(getUserInfo.userInfo.Nick);
                            }
                            else
                            {
                                outMsg.AddText(getOperator.memberInfo.Card);
                            }
                        }
                    }
                }
            }
            outMsg.AddText(remainMessage);
            return outMsg;
        }

        public static async ValueTask Event_OnGroupMemberMute(string eventType, GroupMuteEventArgs eventArgs)
        {
            if (BotInfo.Config.LeaveGroupAfterBeMushin)
            {
                if (eventArgs.Duration == -1 || (eventArgs.User == BotInfo.Config.QQId && eventArgs.Duration > 0))  //全体禁言或禁言自己
                {
                    await eventArgs.SoraApi.LeaveGroup(eventArgs.SourceGroup.Id);
                }
            }
        }

        private static bool CheckPreconditionsGroup(GroupMemberChangeEventArgs e)
        {
            if (BotInfo.Config.BannedGroup.Contains(e.SourceGroup.Id) ||
                BotInfo.Config.BannedUser.Contains(e.ChangedUser.Id))
            {
                return false;
            }
            if (BotInfo.Config.DebugMode)
            {
                if (BotInfo.Config.DebugReplyAdminOnly)
                    if (!BotInfo.Config.AdminQQ.Contains(e.ChangedUser.Id))
                        return false;
                if (BotInfo.Config.OnlyReplyDebugGroup)
                    if (!BotInfo.Config.DebugGroups.Contains(e.SourceGroup.Id))
                        return false;
            }
            return true;
        }

        private static bool CheckPreconditionsGroup(GroupMessageEventArgs e)
        {
            if (BotInfo.Config.BannedGroup.Contains(e.SourceGroup.Id) ||
                BotInfo.Config.BannedUser.Contains(e.Sender.Id))
            {
                return false;
            }
            if (BotInfo.Config.DebugMode)
            {
                if (BotInfo.Config.DebugReplyAdminOnly)
                    if (!BotInfo.Config.AdminQQ.Contains(e.Sender.Id))
                        return false;
                if (BotInfo.Config.OnlyReplyDebugGroup)
                    if (!BotInfo.Config.DebugGroups.Contains(e.SourceGroup.Id))
                        return false;
            }
            return true;
        } 
        
        private static bool CheckPreconditionsPrivate(PrivateMessageEventArgs e)
        {
            if (BotInfo.Config.BannedUser.Contains(e.Sender.Id))
            {
                return false;
            }
            if (BotInfo.Config.DebugMode)
            {
                if (BotInfo.Config.DebugReplyAdminOnly)
                    if (!BotInfo.Config.AdminQQ.Contains(e.Sender.Id))
                        return false;
            }
            return true;
        }
    }
}
