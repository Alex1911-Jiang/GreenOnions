using GreenOnions.Translate;
using GreenOnions.Utility;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    // 为此消息处理类标定所需要使用到的消息解析器
    // 标定的特性仅在使用 IMessageFrameworkBuilder.AddHandler 和 IMessageFrameworkBuilder.ResolveParser 时才会被解析
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageEventArgs, GroupMessageEventArgs>))]
    public class HttpApiPlugin : IMiraiHttpMessageHandler<IGroupMessageEventArgs> // .NET Core 起, 你应该直接实现 IMiraiHttpMessageHandler<TMessage> / IDedicateMiraiHttpMessageHandler<TMessage> 接口
    {
        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMessageEventArgs e)
        {
            //1
            return Task.CompletedTask;
        }
    }
}
