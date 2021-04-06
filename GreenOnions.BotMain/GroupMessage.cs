using GreenOnions.PictureSearcher;
using GreenOnions.Repeater;
using GreenOnions.Utility;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using Mirai_CSharp.Plugin.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public class GroupMessage : IGroupMessage
    {
        async Task<bool> IGroupMessage.GroupMessage(MiraiHttpSession session, IGroupMessageEventArgs e)
        {
            if (BotInfo.BannedGroup.Contains(e.Sender.Group.Id)) return false;
            if (BotInfo.BannedUser.Contains(e.Sender.Id)) return false;
            if (BotInfo.DebugMode)
            {
                if (BotInfo.DebugReplyAdminOnly)
                    if (!BotInfo.AdminQQ.Contains(e.Sender.Id))
                        return false;
                if (BotInfo.OnlyReplyDebugGroup)
                    if (!BotInfo.DebugGroups.Contains(e.Sender.Group.Id))
                        return false;
            }

            QuoteMessage quoteMessage = new QuoteMessage((e.Chain[0] as SourceMessage).Id, e.Sender.Group.Id, e.Sender.Id, e.Sender.Id, null);
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
                        PlainMessageHandler.HandleGroupMesage(session, e.Chain, e.Sender, quoteMessage);
                        break;
                    case "Image":
                        if (Cache.SearchingPictures.Keys.Contains(e.Sender.Id))
                        {
                            #region -- 连续搜图 --
                            for (int i = 1; i < e.Chain.Length; i++)
                            {
                                ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                await SearchPictureHandler.SuccessiveSearchPicture(session, imgMsg, e.Sender, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream), msg => session.SendGroupMessageAsync(e.Sender.Group.Id, msg, quoteMessage.Id));
                            }
                            #endregion -- 连续搜图 --
                        }
                        break;
                }

                #region -- 复读 --
                if (e.Chain.Length == 2)
                {
                    IMessageBase repeatingMessage = Repeat.Repeating(e.Chain[1], e.Sender.Group.Id, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream).GetAwaiter().GetResult());
                    if (repeatingMessage != null)
                    {
                        await session.SendGroupMessageAsync(e.Sender.Group.Id, repeatingMessage);
                    }
                }
                #endregion -- 复读 --
            }
            return false;
        }
    }
}
