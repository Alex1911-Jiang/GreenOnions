using GreenOnions.Translate;
using GreenOnions.Utility;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    // 所有实现了 I(Dedicate)MiraiHttpMessageHandler<TMessage> 接口的实现类实例都可以通过 IMiraiHttpSession.Add(Remove)Plugin 实时添加/移除
    // 但请注意, 其标定的 RegisterMiraiHttpParserAttribute 无法被实时解析
    // 请用户在配置 IServiceCollection 时提前调用 IMiraiHttpFrameworkBuilder.ResolveParser<THandler>
    // 以令框架提前解析其所需要使用到的消息解析器, 否则消息处理方法将不会被调用
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageEventArgs, GroupMessageEventArgs>))]
    public class DynamicPlugin : IMiraiHttpMessageHandler<IGroupMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession session, IGroupMessageEventArgs e)
        {
            //3
            return Task.CompletedTask;
        }
    }
}
