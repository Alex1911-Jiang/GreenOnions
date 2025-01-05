using Lagrange.Core.Message;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;

namespace GreenOnions.NT.Base
{
    public static class Extensions
    {
        public static async Task ReplyAsync(this BotContext context, MessageChain chain, string text)
        {
            MessageChain msg;
            if (chain.GroupUin is not null)
                msg = MessageBuilder.Group(chain.GroupUin.Value).Forward(chain).Text(text).Build();
            else
                msg = MessageBuilder.Friend(chain.FriendUin).Text(text).Build();
            await context.SendMessage(msg);
        }
    }
}
