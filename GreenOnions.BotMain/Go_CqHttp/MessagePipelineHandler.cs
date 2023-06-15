using System.Text.RegularExpressions;
using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain.Go_CqHttp
{
    internal static class MessagePipelineHandler
    {
        private static readonly Regex regexTags = new Regex("<@?成员QQ>|<成员昵称>|<@?操作者QQ>|<操作者昵称>", RegexOptions.Compiled);
        public static void HandlePipeline(this CqWsSession session)
        {
            session.UsePrivateMessage(async (context, next) =>
            {
                if (!CheckPreconditions(context))
                    return;
                LogHelper.WriteInfoLog($"收到来自{context.Sender.UserId}的私聊消息");

                bool isHandle = await MessageHandler.HandleMesage(context.Message.ToGreenOnionsMessages(context.MessageId, context.Sender.UserId, context.Sender.Nickname), null, async outMsg =>
                {
                    if (outMsg is null || outMsg.Count == 0)
                        return;
                    int iRevokeTime = outMsg.RevokeTime;
                    if (outMsg.FirstOrDefault() is GreenOnionsForwardMessage)
                    {
                        var msg = outMsg.ToCqForwardMessage();
                        if (msg is null || msg.Count == 0)
                            return;
                        await session.SendPrivateForwardMessageAsync(context.Sender.UserId, msg);
                    }
                    else
                    {
                        var msg = outMsg.ToCqMessages();
                        if (msg is null || msg.Count == 0)
                            return;
                        if (iRevokeTime > 0)
                        {
                            var sendedMsg = await session.SendPrivateMessageAsync(context.Sender.UserId, msg);
                            if (sendedMsg is null)
                                return;
                            await Task.Delay(1000 * iRevokeTime);
                            await session.RecallMessageAsync(sendedMsg.MessageId);
                        }
                        else
                        {
                            await session.SendPrivateMessageAsync(context.Sender.UserId, msg);
                        }
                    }
                });
                if (!isHandle)
                    await next();
            });
            session.UseGroupMessage(async (context, next) =>
            {
                if (!CheckPreconditionsGroup(context))
                    return;

                for (int i = 0; i < context.Message.Count; i++)
                {
                    if (context.Message[i] is not CqAtMsg atMsg || atMsg.IsAtAll || atMsg.Name is not null)
                        continue;
                    var member = await session.GetGroupMemberInformationAsync(context.GroupId, atMsg.Target);
                    atMsg.Name = member?.GroupNickname;
                }

                bool isHandle = await MessageHandler.HandleMesage(context.Message.ToGreenOnionsMessages(context.MessageId, context.Sender.UserId, context.Sender.Nickname), context.GroupId, async outMsg =>
                {
                    if (outMsg is null || outMsg.Count == 0)
                        return;
                    int iRevokeTime = outMsg.RevokeTime;
                    if (outMsg.FirstOrDefault() is GreenOnionsForwardMessage)
                    {
                        var msg = outMsg.ToCqForwardMessage();
                        if (msg is null || msg.Count == 0)
                            return;
                        await session.SendGroupForwardMessageAsync(context.GroupId, msg);
                    }
                    else
                    {
                        var msg = outMsg.ToCqMessages();
                        if (msg is null || msg.Count == 0)
                            return;
                        if (iRevokeTime > 0)
                        {
                            var sendedMsg = await session.SendGroupMessageAsync(context.GroupId, msg);
                            if (sendedMsg is null)
                                return;
                            await Task.Delay(1000 * iRevokeTime);
                            await session.RecallMessageAsync(sendedMsg.MessageId);
                        }
                        else
                        {
                            session.SendGroupMessageAsync(context.GroupId, msg);
                        }
                    }
                });
                if (!isHandle)
                    await next();
            });
            session.UseGroupMemberIncreased(async (context, next) =>
            {
                if (context.UserId == BotInfo.Config.QQId)
                    return;

                string cmdMsg = string.Empty;
                if (BotInfo.Config.SendMemberJoinedMessage)
                    cmdMsg = BotInfo.Config.MemberJoinedMessage;

                CqGetGroupMemberInformationActionResult? user = await session.GetGroupMemberInformationAsync(context.GroupId, context.UserId);
                if (!string.IsNullOrEmpty(cmdMsg))
                    await session.SendGroupMessageAsync(context.GroupId, new CqMessage(new CqTextMsg(cmdMsg)));
            });
            session.UseGroupMemberDecreased(async (context, next) =>
            {
                if (context.UserId == BotInfo.Config.QQId)
                    return;

                CqGetGroupMemberInformationActionResult? member = null;
                CqGetGroupMemberInformationActionResult? @operator = null;

                string cmdMsg = string.Empty;
                switch (context.ChangeType)
                {
                    case CqGroupDecreaseChangeType.Kick:
                        if (!BotInfo.Config.SendMemberBeKickedMessage)
                            return;
                        cmdMsg = BotInfo.Config.MemberBeKickedMessage;
                        @operator = await session.GetGroupMemberInformationAsync(context.GroupId, context.OperatorId);
                        break;
                    case CqGroupDecreaseChangeType.Leave:
                        if (!BotInfo.Config.SendMemberPositiveLeaveMessage)
                            return;
                        cmdMsg = BotInfo.Config.MemberPositiveLeaveMessage;
                        break;
                }
                member = await session.GetGroupMemberInformationAsync(context.GroupId, context.UserId);
                if (!string.IsNullOrEmpty(cmdMsg))
                    await session.SendGroupMessageAsync(context.GroupId, ReplaceMessage(cmdMsg, member, @operator));
            });
        }

        private static CqMessage ReplaceMessage(string messageCmd, CqGetGroupMemberInformationActionResult? member, CqGetGroupMemberInformationActionResult? @operator = null)
        {
            CqMessage outMsg = new CqMessage();
            string remainMessage = messageCmd;
            foreach (Match match in regexTags.Matches(messageCmd))
            {
                string matchString = match.ToString();
                int index = remainMessage.IndexOf(matchString);
                string left = remainMessage.Substring(0, index);
                if (!string.IsNullOrEmpty(left))
                {
                    outMsg.Add(new CqTextMsg(left));
                }
                string right = remainMessage.Substring(index + matchString.Length);
                remainMessage = right;
                string identifier = match.ToString();

                if (identifier == "<@成员QQ>")
                {
                    outMsg.Add(new CqAtMsg(member.UserId));
                }
                else if (identifier == "<成员QQ>")
                {
                    outMsg.Add(new CqTextMsg(member.UserId.ToString()));
                }
                else if (identifier == "<成员昵称>")
                {
                    if (member.UserId == BotInfo.Config.QQId)
                    {
                        outMsg.Add(new CqTextMsg(BotInfo.Config.BotName));
                    }
                    else
                    {
                        outMsg.Add(new CqTextMsg(member.GroupNickname));
                    }
                }
                else if (@operator is not null)
                {
                    if (identifier == "<@操作者QQ>")
                    {
                        outMsg.Add(new CqAtMsg(@operator.UserId));
                    }
                    else if (identifier == "<操作者QQ>")
                    {
                        outMsg.Add(new CqTextMsg(@operator.UserId.ToString()));
                    }
                    else if (identifier == "<操作者昵称>")
                    {
                        if (@operator.UserId == BotInfo.Config.QQId)
                        {
                            outMsg.Add(new CqTextMsg(BotInfo.Config.BotName));
                        }
                        else
                        {
                            outMsg.Add(new CqTextMsg(@operator.GroupNickname));
                        }
                    }
                }
            }
            outMsg.Add(new CqTextMsg(remainMessage));
            return outMsg;
        }

        private static bool CheckPreconditions(CqPrivateMessagePostContext context)
        {
            if (BotInfo.Config.BannedUser.Contains(context.Sender.UserId))
            {
                LogHelper.WriteInfoLog($"QQ号：{context.Sender.UserId}在黑名单中, 不响应私聊消息");
                return false;
            }
            if (BotInfo.Config.DebugMode)
                if (BotInfo.Config.DebugReplyAdminOnly)
                    if (!BotInfo.Config.AdminQQ.Contains(context.Sender.UserId))
                        return false;  //调试模式不响应非管理员消息
            return true;
        }

        private static bool CheckPreconditionsGroup(CqGroupMessagePostContext context)
        {
            if (BotInfo.Config.BannedGroup.Contains(context.GroupId) || BotInfo.Config.BannedUser.Contains(context.Sender.UserId))
                return false;

            if (BotInfo.Config.DebugMode)
            {
                if (BotInfo.Config.DebugReplyAdminOnly)
                    if (!BotInfo.Config.AdminQQ.Contains(context.Sender.UserId))
                        return false;
                if (BotInfo.Config.OnlyReplyDebugGroup)
                    if (!BotInfo.Config.DebugGroups.Contains(context.GroupId))
                        return false;
            }
            return true;
        }
    }
}
