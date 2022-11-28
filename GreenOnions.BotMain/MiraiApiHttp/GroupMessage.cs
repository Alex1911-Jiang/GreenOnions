using System.Text.RegularExpressions;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.Builders;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageEventArgs, GroupMessageEventArgs>))]
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberJoinedEventArgs, GroupMemberJoinedEventArgs>))]
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberPositiveLeaveEventArgs, GroupMemberPositiveLeaveEventArgs>))]
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberKickedEventArgs, GroupMemberKickedEventArgs>))]
    public class GroupMessage : IMiraiHttpMessageHandler<IGroupMessageEventArgs>,
                                IMiraiHttpMessageHandler<IGroupMemberJoinedEventArgs>,
                                IMiraiHttpMessageHandler<IGroupMemberPositiveLeaveEventArgs>,
                                IMiraiHttpMessageHandler<IGroupMemberKickedEventArgs>
    {
        public async Task HandleMessageAsync(IMiraiHttpSession session, IGroupMessageEventArgs e)
        {
            if (!CheckPreconditions(e.Sender))
            {
                return;
            }
            LogHelper.WriteInfoLog($"收到来自{e.Sender.Id}的群消息");

            int quoteId = (e.Chain[0] as SourceMessage).Id;

            for (int i = 0; i < e.Chain.Length; i++)
            {
                //获取@群名片
                if (e.Chain[i] is IAtMessage atMsg)
                {
                    IGroupMemberInfo[] groupMemberInfos = await session.GetGroupMemberListAsync(e.Sender.Group.Id);
                    IGroupMemberInfo targetQQ = groupMemberInfos.Where(m => m.Id == atMsg.Target).FirstOrDefault();
                    string nickName = targetQQ?.Name;
                    e.Chain[i] = new AtMessage(atMsg.Target, nickName);
                }
            }

            bool isHandle = await MessageHandler.HandleMesage(e.Chain.ToOnionsMessages(e.Sender.Id, e.Sender.Name), e.Sender.Group.Id, async outMsg =>
            {
                if (outMsg is not null && outMsg.Count > 0)
                {
                    int iRevokeTime = outMsg.RevokeTime;
                    var msg = await outMsg.ToMiraiApiHttpMessages(session, UploadTarget.Group);
                    _ = session.SendGroupMessageAsync(e.Sender.Group.Id, msg, outMsg.Reply ? quoteId : null).ContinueWith(async sendedCallBack =>
                    {
                        if (!sendedCallBack.IsFaulted && !sendedCallBack.IsCanceled)
                        {
                            if (iRevokeTime > 0)
                            {
                                await Task.Delay(1000 * iRevokeTime);
                                await session.RevokeMessageAsync(sendedCallBack.Result, e.Sender.Group.Id);
                            }
                        }
                    });
                }
            });
            e.BlockRemainingHandlers = isHandle;
        }

        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMemberJoinedEventArgs e)
        {
            if (!BotInfo.Config.SendMemberJoinedMessage || !CheckPreconditions(e.Member))
            {
                return Task.CompletedTask;
            }
            return session.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(session.GetMessageChainBuilder(), BotInfo.Config.MemberJoinedMessage, e.Member));
        }

        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMemberPositiveLeaveEventArgs e)
        {
            if (!BotInfo.Config.SendMemberPositiveLeaveMessage || !CheckPreconditions(e.Member))
            {
                return Task.CompletedTask;
            }
            return session.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(session.GetMessageChainBuilder(), BotInfo.Config.MemberPositiveLeaveMessage, e.Member));
        }

        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMemberKickedEventArgs e)
        {
            if (!BotInfo.Config.SendMemberBeKickedMessage || !CheckPreconditions(e.Member))
            {
                return Task.CompletedTask;
            }
            return session.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(session.GetMessageChainBuilder(), BotInfo.Config.MemberBeKickedMessage, e.Member, e.Operator));
        }

        private readonly Regex regexTags = new Regex("<@?成员QQ>|<成员昵称>|<@?操作者QQ>|<操作者昵称>");

        private bool CheckPreconditions(IGroupMemberInfo e)
        {
            if (BotInfo.Config.BannedGroup.Contains(e.Group.Id) ||
                BotInfo.Config.BannedUser.Contains(e.Id))
            {
                return false;
            }
            if (BotInfo.Config.DebugMode)
            {
                if (BotInfo.Config.DebugReplyAdminOnly)
                    if (!BotInfo.Config.AdminQQ.Contains(e.Id))
                        return false;
                if (BotInfo.Config.OnlyReplyDebugGroup)
                    if (!BotInfo.Config.DebugGroups.Contains(e.Group.Id))
                        return false;
            }
            return true;
        }

        private IMessageChainBuilder ReplaceMessage(IMessageChainBuilder builder, string messageCmd, IGroupMemberInfo member, IGroupMemberInfo Operator = null)
        {
            string remainMessage = messageCmd;
            foreach (Match match in regexTags.Matches(messageCmd))
            {
                string matchString = match.ToString();
                int index = remainMessage.IndexOf(matchString);
                string left = remainMessage.Substring(0, index);
                if (!string.IsNullOrEmpty(left))
                {
                    builder.AddPlainMessage(left);
                }
                string right = remainMessage.Substring(index + matchString.Length);
                remainMessage = right;
                string identifier = match.ToString();

                if (identifier == "<@成员QQ>")
                {
                    builder.AddAtMessage(member.Id);
                }
                else if (identifier == "<成员QQ>")
                {
                    builder.AddPlainMessage(member.Id.ToString());
                }
                else if (identifier == "<成员昵称>")
                {
                    if (member.Id == BotInfo.Config.QQId)
                        builder.AddPlainMessage(BotInfo.Config.BotName);
                    else
                        builder.AddPlainMessage(member.Name);
                }
                else if (Operator is not null)
                {
                    if (identifier == "<@操作者QQ>")
                    {
                        builder.AddAtMessage(Operator.Id);
                    }
                    else if (identifier == "<操作者QQ>")
                    {
                        builder.AddPlainMessage(Operator.Id.ToString());
                    }
                    else if (identifier == "<操作者昵称>")
                    {
                        if (Operator.Id == BotInfo.Config.QQId)
                            builder.AddPlainMessage(BotInfo.Config.BotName);
                        else
                            builder.AddPlainMessage(Operator.Name);
                    }
                }
            }
            builder.AddPlainMessage(remainMessage);
            return builder;
        }
    }
}
