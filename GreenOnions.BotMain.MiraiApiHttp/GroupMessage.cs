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
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            //QuoteMessage quoteMessage = new QuoteMessage((e.Chain[0] as SourceMessage).Id, e.Sender.Group.Id, e.Sender.Id, e.Sender.Id);

            bool isHandle = await MessageHandler.HandleMesage(e.Chain.ToOnionsMessages(), e.Sender.Id, e.Sender.Group.Id, async outMsg => 
            {
                if (outMsg != null)
                {
                    _ = session.SendGroupMessageAsync(e.Sender.Group.Id, await outMsg.ToMiraiApiHttpMessages(session, UploadTarget.Group), outMsg.Reply ? quoteId : null);
                }
            });
        }

        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMemberJoinedEventArgs e)
        {
            if (!CheckPreconditions(e.Member) || !BotInfo.SendMemberJoinedMessage)
            {
                return Task.CompletedTask;
            }
            return session.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(session.GetMessageChainBuilder(), BotInfo.MemberJoinedMessage, e.Member));
        }

        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMemberPositiveLeaveEventArgs e)
        {
            if (!CheckPreconditions(e.Member) || !BotInfo.SendMemberPositiveLeaveMessage)
            {
                return Task.CompletedTask;
            }
            return session.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(session.GetMessageChainBuilder(), BotInfo.MemberPositiveLeaveMessage, e.Member));
        }

        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMemberKickedEventArgs e)
        {
            if (!CheckPreconditions(e.Member) || !BotInfo.SendMemberBeKickedMessage)
            {
                return Task.CompletedTask;
            }
            return session.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(session.GetMessageChainBuilder(), BotInfo.MemberBeKickedMessage, e.Member, e.Operator));
        }

        private readonly Regex regexTags = new Regex("<@?成员QQ>|<成员昵称>|<@?操作者QQ>|<操作者昵称>");

        private bool CheckPreconditions(IGroupMemberInfo e)
        {
            if (BotInfo.BannedGroup.Contains(e.Group.Id) ||
                BotInfo.BannedUser.Contains(e.Id))
            {
                return false;
            }
            if (BotInfo.DebugMode)
            {
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Id))
                        return false;
                if (BotInfo.OnlyReplyDebugGroup)
                    if (!BotInfo.DebugGroups.Contains(e.Group.Id))
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
                    builder.AddPlainMessage(member.Name);
                }
                else if (Operator != null)
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
                        builder.AddPlainMessage(Operator.Name);
                    }
                }
            }
            builder.AddPlainMessage(remainMessage);
            return builder;
        }
    }
}
