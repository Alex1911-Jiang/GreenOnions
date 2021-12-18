using System.Threading.Tasks;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;

namespace GreenOnions.BotMain.Plugins
{
    
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageEventArgs, GroupMessageEventArgs>))]
    public class DynamicPlugin : MiraiHttpMessageHandler<IGroupMessageEventArgs>,
                                 IMiraiHttpMessageHandler<IGroupMessageEventArgs>
    {
        public override Task HandleMessageAsync(IMiraiHttpSession session, IGroupMessageEventArgs message)
        {
            return Task.CompletedTask;
        }
    }
}
