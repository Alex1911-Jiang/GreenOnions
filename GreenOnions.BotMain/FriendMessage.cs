using GreenOnions.PictureSearcher;
using GreenOnions.Utility;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
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

            QuoteMessage quoteMessage = new QuoteMessage((e.Chain[0] as SourceMessage).Id, e.Sender.Id, e.Sender.Id, e.Sender.Id);
            if (e.Chain.Length > 1)  //普通消息
            {
                switch (e.Chain[1].Type)
                {
                    case "Plain":
                        await PlainMessageHandler.HandleMesage(e.Chain, e.Sender,
                            (chatMessages, bRevoke) =>
                            {
                                session.SendFriendMessageAsync(e.Sender.Id, chatMessages, quoteMessage.Id).ContinueWith(callback =>
                                {
                                    if (bRevoke)
                                    {
                                        if (BotInfo.HPicturePMRevoke > 0)
                                        {
                                            Task.Delay(BotInfo.HPicturePMRevoke * 1000).ContinueWith(_ => session.RevokeMessageAsync(callback.Result));
                                        }
                                    }
                                });  //发送好友消息
                            },
                            picStream => session.UploadPictureAsync(UploadTarget.Friend, picStream),
                            urls => session.SendImageToFriendAsync(e.Sender.Id, urls));  //上传图片
                        break;
                    case "Image":
                        if (Cache.SearchingPictures.Keys.Contains(e.Sender.Id))
                        {
                            #region -- 连续搜图 --
                            for (int i = 1; i < e.Chain.Length; i++)
                            {
                                ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                await SearchPictureHandler.SuccessiveSearchPicture(imgMsg, e.Sender.Id,
                                    picStream => session.UploadPictureAsync(UploadTarget.Friend, picStream),  //上传图片
                                    msg => session.SendFriendMessageAsync(e.Sender.Id, msg),  //发送好友消息
                                    urls => session.SendImageToFriendAsync(e.Sender.Id, urls));
                            }
                            #endregion -- 连续搜图 --
                        }
                        break;
                }
            }
        }

        private bool CheckPreconditions(Mirai.CSharp.HttpApi.Models.IFriendInfo e)
        {
            if (BotInfo.BannedUser.Contains(e.Id)) 
                return false;
            if (BotInfo.DebugMode)
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Id))
                        return false;
            return true;
        }
    }
}
