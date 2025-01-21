using System.Collections;
using System.Reflection;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Message;
using Newtonsoft.Json;

namespace GreenOnions.NT.Base
{
    public static class Extensions
    {
        public static bool AllowUseIfDebug(this MessageChain chain)
        {
            if (SngletonInstance.Config is null)
                return false;
            if (SngletonInstance.Config.DebugMode && chain.GroupUin is not null && !SngletonInstance.Config.DebugGroups.Contains(chain.GroupUin.Value))
                return false;
            if (SngletonInstance.Config.DebugMode && chain.GroupUin is null && !SngletonInstance.Config.AdminQQ.Contains(chain.FriendUin))
                return false;
            return true;
        }

        public static async Task ReplyAsync(this MessageChain chain, string text)
        {
            if (string.IsNullOrEmpty(text))
                return;
            if (SngletonInstance.Bot is null)
                throw new Exception("未构建机器人实例，请先登录");

            text = ReplaceTags(text);

            MessageChain msg;
            if (chain.GroupUin is not null)
                msg = MessageBuilder.Group(chain.GroupUin.Value).Forward(chain).Text(text).Build();
            else
                msg = MessageBuilder.Friend(chain.FriendUin).Text(text).Build();
            await SngletonInstance.Bot.SendMessage(msg);
        }

        public static async Task SendMessageToAdmin(this BotContext bot, string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            if (bot is null)
                throw new Exception("未构建机器人实例，请先登录");

            if (SngletonInstance.Config is null)
                throw new Exception("配置实例不存在，请确保config.yml格式合法后重启机器人");

            text = ReplaceTags(text);
            foreach (var admin in SngletonInstance.Config.AdminQQ)
            {
                MessageChain msg = MessageBuilder.Friend(admin).Text(text).Build();
                await bot.SendMessage(msg);
            }
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

        public static string ReplaceTags(this string text)
        {
            if (SngletonInstance.Config is null)
                return text;

            foreach (var prop in typeof(ICommonConfig).GetProperties())
            {
                string tag = $"<{prop.Name}>";
                if (!text.Contains(tag))
                    continue;
                object? val = prop.GetValue(SngletonInstance.Config);
                if (val is null)
                    continue;
                text = text.Replace($"<{prop.Name}>", typeof(IEnumerable).IsAssignableFrom(prop.GetType())
                    ? JsonConvert.SerializeObject(val)
                    : val.ToString());
            }
            return text;
        }
    }
}
