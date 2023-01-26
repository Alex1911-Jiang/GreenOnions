using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;

namespace GreenOnions.BotMain.MiraiApiHttp
{
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IFriendMessageEventArgs, FriendMessageEventArgs>))]
    public partial class FriendMessage : IMiraiHttpMessageHandler<IFriendMessageEventArgs>
    {
        public async Task HandleMessageAsync(IMiraiHttpSession session, IFriendMessageEventArgs e)
        {
            if (!CheckPreconditions(e.Sender))
            {
                return;
            }
            LogHelper.WriteInfoLog($"收到来自{e.Sender.Id}的私聊消息");

            int quoteId = (e.Chain[0] as SourceMessage)!.Id;
            bool isHandle = await MessageHandler.HandleMesage(e.Chain.ToGreenOnionsMessages(e.Sender.Id, e.Sender.Name), null, async outMsg =>
            {
                if (outMsg is null || outMsg.Count == 0)
                    return;
                int iRevokeTime = outMsg.RevokeTime;
                var msg = await outMsg.ToMiraiApiHttpMessages(session, UploadTarget.Friend);
                if (msg is null || msg.Length == 0)
                    return ;
                _ = session.SendFriendMessageAsync(e.Sender.Id, msg, outMsg.Reply ? quoteId : null).ContinueWith(async sendedCallBack =>
               {
                   if (!sendedCallBack.IsFaulted && !sendedCallBack.IsCanceled)
                   {
                       if (iRevokeTime > 0)
                       {
                           await Task.Delay(1000 * iRevokeTime);
                           await session.RevokeMessageAsync(sendedCallBack.Result, e.Sender.Id);
                       }
                   }
               });
            });
            e.BlockRemainingHandlers = isHandle;
        }

        private bool CheckPreconditions(Mirai.CSharp.HttpApi.Models.IFriendInfo e)
        {
            if (BotInfo.Config.BannedUser.Contains(e.Id))
            {
                LogHelper.WriteInfoLog($"{e.Id}在黑名单中, 不响应私聊消息");
                return false;
            }
            if (BotInfo.Config.DebugMode)
                if (BotInfo.Config.DebugReplyAdminOnly)
                    if (!BotInfo.Config.AdminQQ.Contains(e.Id))
                        return false;  //调试模式不响应非管理员消息
            return true;
        }
    }
}
