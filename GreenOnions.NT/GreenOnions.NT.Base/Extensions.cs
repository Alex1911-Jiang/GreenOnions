using System.Reflection;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Message;

namespace GreenOnions.NT.Base
{
    public static class Extensions
    {
        public static async Task ReplyAsync(this BotContext context, MessageChain chain, string text)
        {
            if (string.IsNullOrEmpty(text))
                return;
            MessageChain msg;
            if (chain.GroupUin is not null)
                msg = MessageBuilder.Group(chain.GroupUin.Value).Forward(chain).Text(text).Build();
            else
                msg = MessageBuilder.Friend(chain.FriendUin).Text(text).Build();
            await context.SendMessage(msg);
        }

        public static long GetVersion(this IPlugin self)
        {
            string? version = Assembly.GetAssembly(self.GetType())?.GetName()?.Version?.ToString();
            if (version is null)
                throw new Exception("查询版本号失败，版本号为空");
            string[] arrVersion = version.Split('.');
            if (arrVersion.Length != 4)
                throw new Exception("查询版本号失败，版本号格式不正确");
            int year = int.Parse(arrVersion[1]);
            int monthAndDay = int.Parse(arrVersion[2]);
            int hourAndMinute = int.Parse(arrVersion[3]);
            return Convert.ToInt64($"{year}{monthAndDay:0000}{hourAndMinute:0000}");
        }

        public static string? GetPath(this IPlugin self)
        {
            return Assembly.GetAssembly(self.GetType())?.Location;
        }
    }
}
