using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenOnions.Utility;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Session;

namespace GreenOnions.BotMain
{
    //[RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IFriendMessageEventArgs, FriendMessageEventArgs>))]
    public partial class FriendPlugin : IMiraiHttpMessageHandler<IFriendMessageEventArgs>
    {
        public async Task HandleMessageAsync(IMiraiHttpSession session, IFriendMessageEventArgs e) // 法2: 使用 params IMessageBase[]
        {

            IChatMessage plain1 = new PlainMessage($"收到了来自{e.Sender.Name}({e.Sender.Remark})[{e.Sender.Id}]的私聊消息:{string.Join(null, (IEnumerable<IChatMessage>)e.Chain)}");
            //                                                /   好友昵称  /  /    好友备注    /  /  好友QQ号  /                                                        / 消息链 /
            IChatMessage plain2 = new PlainMessage("嘤嘤嘤"); // 在下边的 SendFriendMessageAsync, 你可以串起n个 IChatMessage
            await session.SendFriendMessageAsync(e.Sender.Id, plain1/*, plain2, /* etc... */); // 向消息来源好友异步发送由以上chain表示的消息
            e.BlockRemainingHandlers = false; // 不阻断消息传递。如需阻断请返回true
        }

        //public async Task HandleMessageAsync(IMiraiSession client, IFriendMessageEventArgs message)
        //{
        //    if (BotInfo.BannedUser.Contains(message.Sender.Id)) return;
        //    if (BotInfo.DebugMode)
        //        if (BotInfo.DebugReplyAdminOnly)
        //            if (!BotInfo.AdminQQ.Contains(message.Sender.Id))
        //                return;

        //    IChatMessage plain1 = new PlainMessage($"收到了来自{message.Sender.Name}({message.Sender.Remark})[{message.Sender.Id}]的私聊消息:{string.Join(null, (IEnumerable<IChatMessage>)message.Chain)}");
        //    //                                                /   好友昵称  /  /    好友备注    /  /  好友QQ号  /                                                        / 消息链 /
        //    await client.SendFriendMessageAsync(message.Sender.Id, plain1); // 向消息来源好友异步发送由以上chain表示的消息
        //    message.BlockRemainingHandlers = false; // 不阻断消息传递。如需阻断请返回true


        //    //if (e.Chain.Length > 1)  //普通消息
        //    //{
        //    //    switch (e.Chain[1].Type)
        //    //    {
        //    //        case "Plain":
        //    //            PlainMessageHandler.HandleFriendMesage(session, e.Chain, e.Sender.Id);
        //    //            break;
        //    //        case "Image":
        //    //            for (int i = 1; i < e.Chain.Length; i++)
        //    //            {
        //    //                ImageMessage imgMsg = e.Chain[i] as ImageMessage;
        //    //                await SearchPictureHandler.SearchPicture(imgMsg, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream), msg => session.SendFriendMessageAsync(e.Sender.Id, msg));
        //    //            }
        //    //            break;
        //    //    }
        //    //}
        //}
    }
}
