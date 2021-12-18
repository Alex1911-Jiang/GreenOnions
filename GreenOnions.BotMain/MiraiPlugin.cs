using System.Threading.Tasks;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;

namespace GreenOnions.BotMain
{
    // 从 (I)MiraiMessageHandler<IMiraiSession, TMessage> 继承(实现), 且 TMessage 位于 Mirai.CSharp.Models.EventArgs 时, 将处理任何实现框架的消息, 包括但不限于 HttpApi, Native
    // 意味着你无需引用 Mirai-CSharp.HttpApi
    public class MiraiPlugin : IMiraiMessageHandler<IMiraiSession, IGroupMessageEventArgs> // .NET Core 起, 你应该直接实现 IMiraiMessageHandler<TClient, TMessage> 接口
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMessageEventArgs message)
        {
            return Task.CompletedTask;  //2
        }
    }
}
