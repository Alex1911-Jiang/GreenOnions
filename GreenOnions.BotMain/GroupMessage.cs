using GreenOnions.ForgeMessage;
using GreenOnions.PictureSearcher;
using GreenOnions.Repeater;
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
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
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

            QuoteMessage quoteMessage = new QuoteMessage((e.Chain[0] as SourceMessage).Id, e.Sender.Group.Id, e.Sender.Id, e.Sender.Id);
            if (e.Chain.Length > 1)  //普通消息
            {
                for (int i = 1; i < e.Chain.Length; i++)
                {
                    if (e.Chain[i] is IAtMessage)
                    {
                        IAtMessage atMessage = e.Chain[i] as IAtMessage;
                        IGroupMemberInfo memberInfo = await session.GetGroupMemberInfoAsync(atMessage.Target, e.Sender.Group.Id);
                        MyAtMessage myAtMessage = new MyAtMessage(atMessage.Target, memberInfo.Name);
                        e.Chain[i] = myAtMessage;
                    }
                }

                switch (e.Chain[1].Type)
                {
                    case "At":
                        if (e.Chain.Length > 2)
                        {
                            AtMessage atMe = e.Chain[1] as AtMessage;
                            if (atMe.Target == session.QQNumber)  //@自己
                            {
                                for (int i = 2; i < e.Chain.Length; i++)
                                {
                                    #region -- @搜图 --
                                    if (e.Chain[i].Type == "Image")
                                    {
                                        ErrorHelper.WriteMessage($"触发了@搜图, 消息原句为:{string.Join(",", e.Chain.Select(c=>c.ToString()))}");
                                        ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                        await SearchPictureHandler.SearchPicture(imgMsg, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream), msg => session.SendGroupMessageAsync(e.Sender.Group.Id, msg, quoteMessage.Id), urls => session.SendImageToGroupAsync(e.Sender.Group.Id, urls));
                                    }
                                    #endregion -- @搜图 --
                                    #region -- @下载原图 --
                                    if (e.Chain[i].Type == "Plain")
                                    {
                                        if (string.IsNullOrWhiteSpace(e.Chain[i].ToString()))
                                            continue;
                                        await SearchPictureHandler.SendPixivOriginPictureWithIdAndP(e.Chain[i].ToString(),
                                            urls => session.SendImageToGroupAsync(e.Sender.Group.Id, urls),
                                            picStream => session.UploadPictureAsync(UploadTarget.Group, picStream),
                                            msg => session.SendGroupMessageAsync(e.Sender.Group.Id, msg, quoteMessage.Id));
                                    }
                                    #endregion -- @下载原图 --
                                }
                                return;
                            }
                        }
                        break;
                    case "Plain":
                        bool isHandle = await PlainMessageHandler.HandleMesage(e.Chain, e.Sender,
                            (chatMessages, bRevoke) =>
                            {
                                session.SendGroupMessageAsync(e.Sender.Group.Id, chatMessages, quoteMessage.Id).ContinueWith(callback => 
                                {
                                    if (bRevoke)
                                    {
                                        int revokeTime = BotInfo.HPictureWhiteGroup.Contains(e.Sender.Group.Id) ? BotInfo.HPictureWhiteRevoke : BotInfo.HPictureRevoke;
                                        if (revokeTime > 0)
                                        {
                                            Task.Delay(revokeTime * 1000).ContinueWith(_ => session.RevokeMessageAsync(callback.Result));
                                        }
                                    }
                                });  //发送群消息
                            },
                            picStream => session.UploadPictureAsync(UploadTarget.Group, picStream),
                            urls => session.SendImageToGroupAsync(e.Sender.Group.Id, urls));  //上传图片
                        if (isHandle)
                            return;
                        break;
                    case "Image":
                        if (Cache.SearchingPicturesUsers.Keys.Contains(e.Sender.Id))
                        {
                            #region -- 连续搜图 --
                            for (int i = 1; i < e.Chain.Length; i++)
                            {
                                ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                await SearchPictureHandler.SuccessiveSearchPicture(imgMsg, e.Sender.Id,
                                    picStream => session.UploadPictureAsync(UploadTarget.Group, picStream),  //上传图片
                                    msg => session.SendGroupMessageAsync(e.Sender.Group.Id, msg, quoteMessage.Id),  //发送群消息
                                    urls => session.SendImageToGroupAsync(e.Sender.Group.Id, urls));
                            }
                            #endregion -- 连续搜图 --
                            return;
                        }
                        break;
                }

                #region -- 复读 --
                if (e.Chain.Length == 2)
                {
                    Mirai.CSharp.Models.ChatMessages.IChatMessage repeatingMessage = await RepeatHandler.Repeating(e.Chain[1], e.Sender.Group.Id, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream));
                    if (repeatingMessage != null)
                    {
                        await session.SendGroupMessageAsync(e.Sender.Group.Id, repeatingMessage);
                    }
                }
                #endregion -- 复读 --
            }
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
