using GreenOnions.PictureSearcher;
using GreenOnions.Repeater;
using GreenOnions.Utility;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageEventArgs, GroupMessageEventArgs>))]
    public class GroupMessage : IMiraiHttpMessageHandler<IGroupMessageEventArgs>
    {
        public async Task HandleMessageAsync(IMiraiHttpSession session, IGroupMessageEventArgs e)
        {
            e.BlockRemainingHandlers = false;

            if (BotInfo.BannedGroup.Contains(e.Sender.Group.Id)) return;
            if (BotInfo.BannedUser.Contains(e.Sender.Id)) return;
            if (BotInfo.DebugMode)
            {
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Sender.Id))
                        return;
                if (BotInfo.OnlyReplyDebugGroup)
                    if (!BotInfo.DebugGroups.Contains(e.Sender.Group.Id))
                        return;
            }

            QuoteMessage quoteMessage = new QuoteMessage((e.Chain[0] as SourceMessage).Id, e.Sender.Group.Id, e.Sender.Id, e.Sender.Id);
            if (e.Chain.Length > 1)  //普通消息
            {
                switch (e.Chain[1].Type)
                {
                    case "At":
                        if (e.Chain.Length > 2)
                        {
                            #region -- @搜图 --
                            AtMessage atMe = e.Chain[1] as AtMessage;
                            if (atMe.Target == BotInfo.QQId)  //@自己
                            {
                                for (int i = 2; i < e.Chain.Length; i++)
                                {
                                    if (e.Chain[i].Type == "Image")
                                    {
                                        ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                        await SearchPictureHandler.SearchPicture(imgMsg, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream), msg => session.SendGroupMessageAsync(e.Sender.Group.Id, msg, quoteMessage.Id));
                                    }
                                }
                            }
                            #endregion -- @搜图 --
                        }
                        break;
                    case "Plain":
                        await PlainMessageHandler.HandleMesage(e.Chain, e.Sender,
                            (chatMessages, bRevoke) =>
                            {
                                session.SendGroupMessageAsync(e.Sender.Group.Id, chatMessages, quoteMessage.Id).ContinueWith(callback => 
                                {
                                    if (bRevoke)
                                    {
                                        int revokeTime = BotInfo.HPictureWhiteGroup.Contains(e.Sender.Group.Id) ? BotInfo.HPictureWhiteRevoke : BotInfo.HPictureRevoke;
                                        if (revokeTime > 0)
                                        {
                                            Task.Delay(revokeTime * 1000).ContinueWith(_ => session.RevokeMessageAsync(callback.Result));
                                        }
                                    }
                                });  //发送群消息
                                
                            },
                            picStream => session.UploadPictureAsync(UploadTarget.Group, picStream));  //上传图片
                        break;
                    case "Image":
                        if (Cache.SearchingPictures.Keys.Contains(e.Sender.Id))
                        {
                            #region -- 连续搜图 --
                            for (int i = 1; i < e.Chain.Length; i++)
                            {
                                ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                await SearchPictureHandler.SuccessiveSearchPicture(imgMsg, e.Sender,
                                    picStream => session.UploadPictureAsync(UploadTarget.Group, picStream),  //上传图片
                                    msg => session.SendGroupMessageAsync(e.Sender.Group.Id, msg, quoteMessage.Id));  //发送群消息
                            }
                            #endregion -- 连续搜图 --
                        }
                        break;
                }

                #region -- 复读 --
                if (e.Chain.Length == 2)
                {
                    Mirai.CSharp.Models.ChatMessages.IChatMessage repeatingMessage = await Repeat.Repeating(e.Chain[1], e.Sender.Group.Id, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream));
                    if (repeatingMessage != null)
                    {
                        await session.SendGroupMessageAsync(e.Sender.Group.Id, repeatingMessage);
                    }
                }
                #endregion -- 复读 --
            }
        }
    }
}
