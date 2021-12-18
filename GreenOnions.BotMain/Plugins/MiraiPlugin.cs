using System.Threading.Tasks;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;

namespace GreenOnions.BotMain.Plugins
{
    public class MiraiPlugin : MiraiMessageHandler<IMiraiSession, IGroupMessageEventArgs>, // .NET Framework 只能继承 MiraiMessageHandler<TClient, TMessage>
                               IMiraiMessageHandler<IMiraiSession, IGroupMessageEventArgs> // .NET Core 起, 你应该直接实现 IMiraiMessageHandler<TClient, TMessage> 接口
    {
        public override Task HandleMessageAsync(IMiraiSession session, IGroupMessageEventArgs message)
        {
            return Task.CompletedTask;
        }
    }
}
