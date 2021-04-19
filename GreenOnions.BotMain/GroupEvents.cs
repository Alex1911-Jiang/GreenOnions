using GreenOnions.Utility;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public static class GroupEvents
    {
        private static Regex regexTags;
        static GroupEvents() => regexTags = new Regex("<@?成员QQ>|<成员昵称>|<@?操作者QQ>|<操作者昵称>");

        /// <summary>
        /// 新人入群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static async Task<bool> Session_GroupMemberJoinedEvt(MiraiHttpSession sender, IGroupMemberJoinedEventArgs e)
        {
            if (BotInfo.SendMemberJoinedMessage)
            {
                await sender.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(BotInfo.MemberJoinedMessage, e.Member));
            }
            return false;
        }

        /// <summary>
        /// 成员退群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static async Task<bool> Session_GroupMemberPositiveLeaveEvt(MiraiHttpSession sender, IGroupMemberPositiveLeaveEventArgs e)
        {
            if (BotInfo.SendMemberPositiveLeaveMessage)
            {
                await sender.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(BotInfo.MemberPositiveLeaveMessage, e.Member));
            }
            return false;
        }

        /// <summary>
        /// 成员被踢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static async Task<bool> Session_GroupMemberKickedEvt(MiraiHttpSession sender, IGroupMemberKickedEventArgs e)
        {
            if (BotInfo.SendMemberBeKickedMessage)
            {
                await sender.SendGroupMessageAsync(e.Member.Group.Id, ReplaceMessage(BotInfo.MemberBeKickedMessage, e.Member, e.Operator));
            }
            return false;
        }

        private static IMessageBase[] ReplaceMessage(string messageCmd, IGroupMemberInfo member, IGroupMemberInfo Operator = null)
        {
            List<IMessageBase> lstMessages = new List<IMessageBase>();
            string remainMessage = messageCmd;
            foreach (Match match in regexTags.Matches(messageCmd))
            {
                string matchString = match.ToString();
                int index = remainMessage.IndexOf(matchString);
                string left = remainMessage.Substring(0, index);
                if (!string.IsNullOrEmpty(left))
                {
                    lstMessages.Add(new PlainMessage(left));
                }
                string right = remainMessage.Substring(index + matchString.Length);
                remainMessage = right;

                if (match.ToString() == "<@成员QQ>")
                {
                    lstMessages.Add(new AtMessage(member.Id));
                }
                else if (match.ToString() == "<成员QQ>")
                {
                    lstMessages.Add(new PlainMessage(member.Id.ToString()));
                }
                else if (match.ToString() == "<成员昵称>")
                {
                    lstMessages.Add(new PlainMessage(member.Name));
                }
                else if (Operator != null)
                {
                    if (match.ToString() == "<@操作者QQ>")
                    {
                        lstMessages.Add(new AtMessage(Operator.Id));
                    }
                    else if (match.ToString() == "<操作者QQ>")
                    {
                        lstMessages.Add(new PlainMessage(Operator.Id.ToString()));
                    }
                    else if (match.ToString() == "<操作者昵称>")
                    {
                        lstMessages.Add(new PlainMessage(Operator.Name));
                    }
                }
            }
            lstMessages.Add(new PlainMessage(remainMessage));
            return lstMessages.ToArray();
        }
    }
}
