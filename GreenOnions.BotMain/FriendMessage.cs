using GreenOnions.PictureSearcher;
using GreenOnions.TicTacToe;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IFriendMessageEventArgs, FriendMessageEventArgs>))]
    public partial class FriendMessage : IMiraiHttpMessageHandler<IFriendMessageEventArgs>
    {
        public async Task HandleMessageAsync(IMiraiHttpSession session, IFriendMessageEventArgs e)
        {
            LogHelper.WriteInfoLog($"收到来自{e.Sender.Id}的私聊消息");
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
                        LogHelper.WriteInfoLog($"{e.Sender.Id}私聊消息为:{string.Join<IChatMessage>("\r\n", e.Chain)}");
                        await PlainMessageHandler.HandleMesage(e.Chain, e.Sender,
                            (chatMessages, bQuote) => session.SendFriendMessageAsync(e.Sender.Id, chatMessages, bQuote ? quoteMessage.Id : null),  //发送好友消息,
                            picStream => session.UploadPictureAsync(UploadTarget.Friend, picStream),   //上传图片
                            urls => session.SendImageToFriendAsync(e.Sender.Id, urls),
                            revokeId => 
                            {
                                if (BotInfo.HPicturePMRevoke > 0)
                                    Task.Delay(BotInfo.HPicturePMRevoke * 1000).ContinueWith(_ => session.RevokeMessageAsync(revokeId));
                            });
                        break;
                    case "Image":
                        LogHelper.WriteInfoLog($"{e.Sender.Id}私聊为图片消息");
                        #region -- 井字棋 --
                        if (Cache.PlayingTicTacToeUsers.ContainsKey(e.Sender.Id))
                        {
                            LogHelper.WriteInfoLog($"{e.Sender.Id}正在下井字棋, 按井字棋处理图片消息");
                            ImageMessage imgMsg = e.Chain[1] as ImageMessage;
                            if (imgMsg != null)
                            {
                                using (MemoryStream playerMoveStream = await HttpHelper.DownloadImageAsMemoryStream(ImageHelper.ReplaceGroupUrl(imgMsg.Url)))
                                {
                                    if (playerMoveStream == null)
                                    {
                                        //图片下载失败, 暂时没想好怎么处理
                                        return;
                                    }

                                    TicTacToeHandler.PlayerMoveByBitmap(e.Sender.Id, playerMoveStream,
                                        (msg, bQuote) => session.SendFriendMessageAsync(e.Sender.Id, msg, bQuote ? quoteMessage.Id : null),
                                        picStream => session.UploadPictureAsync(UploadTarget.Friend, picStream));
                                }
                            }
                        }
                        #endregion -- 井字棋 --
                        #region -- 连续搜图 --
                        else //if (Cache.SearchingPicturesUsers.Keys.Contains(e.Sender.Id))  //如果不在井字棋模式中就直接搜图
                        {
                            LogHelper.WriteInfoLog($"{e.Sender.Id}私聊自动搜图");
                            for (int i = 1; i < e.Chain.Length; i++)
                            {
                                ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                await SearchPictureHandler.SearchPicture(imgMsg, picStream => session.UploadPictureAsync(UploadTarget.Friend, picStream),
                                    (msg, bQuote) => session.SendFriendMessageAsync(e.Sender.Id, msg),
                                    urls => session.SendImageToFriendAsync(e.Sender.Id, urls));
                            }
                        }
                        #endregion -- 连续搜图 --
                        break;
                }
            }
        }

        private bool CheckPreconditions(Mirai.CSharp.HttpApi.Models.IFriendInfo e)
        {
            if (BotInfo.BannedUser.Contains(e.Id))
            {
                LogHelper.WriteInfoLog($"{e.Id}在黑名单中, 不响应私聊消息");
                return false;
            }
            if (BotInfo.DebugMode)
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Id))
                        return false;
            return true;
        }
    }
}
