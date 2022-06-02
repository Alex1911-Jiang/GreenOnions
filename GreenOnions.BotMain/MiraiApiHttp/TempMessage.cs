using GreenOnions.BotMain;
using GreenOnions.BotMain.MiraiApiHttp;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;

namespace GreenOnions.MiraiApiHttp
{
    public class TempMessage : IMiraiHttpMessageHandler<ITempMessageEventArgs>
    {
        public async Task HandleMessageAsync(IMiraiHttpSession session, ITempMessageEventArgs e)
        {
            if (!CheckPreconditions(e.Sender))
            {
                return;
            }
            LogHelper.WriteInfoLog($"收到来自{e.Sender.Id}的私聊消息");

            int quoteId = (e.Chain[0] as SourceMessage).Id;
            bool isHandle = await MessageHandler.HandleMesage(e.Chain.ToOnionsMessages(e.Sender.Id, e.Sender.Name), e.Sender.Group.Id, async outMsg =>  //临时消息按群设置记撤回时间
            {
                if (outMsg != null)
                {
                    int iRevokeTime = outMsg.RevokeTime;
                    var msg = await outMsg.ToMiraiApiHttpMessages(session, UploadTarget.Temp);
                    _ = session.SendTempMessageAsync(e.Sender.Id, e.Sender.Group.Id, msg, outMsg.Reply ? quoteId : null).ContinueWith(async sendedCallBack =>
                    {
                        if (iRevokeTime > 0)
                        {
                            await Task.Delay(1000 * iRevokeTime);
                            _ = session.RevokeMessageAsync(sendedCallBack.Result);
                        }
                    });
                }
            });
        }

        private bool CheckPreconditions(Mirai.CSharp.HttpApi.Models.IGroupMemberInfo e)
        {
            if (BotInfo.BannedGroup.Contains(e.Group.Id) ||
                BotInfo.BannedUser.Contains(e.Id))
            {
                LogHelper.WriteInfoLog($"QQ:{e.Id}或群:{e.Group.Id}在黑名单中, 不响应临时消息");
                return false;
            }
            if (BotInfo.DebugMode)
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Id))
                        return false;  //调试模式不响应非管理员消息
            return true;
        }
    }
}
