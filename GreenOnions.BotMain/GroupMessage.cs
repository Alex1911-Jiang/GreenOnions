using GreenOnions.PictureSearcher;
using GreenOnions.Utility;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using Mirai_CSharp.Plugin.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public class GroupMessage : IGroupMessage
    {
        async Task<bool> IGroupMessage.GroupMessage(MiraiHttpSession session, IGroupMessageEventArgs e)
        {
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
                                        await SearchPictureHandler.SearchPicture(session, imgMsg, e.Sender, quoteMessage);
                                    }
                                }
                            }
                            #endregion -- @搜图 --
                        }
                        break;
                    case "Plain":
                        string strMsg = e.Chain[1].ToString();
                        PlainMessageHandler.HandleMesage(session, strMsg, e.Sender, quoteMessage);
                        break;
                    case "Image":
                        if (Cache.SearchingPictures.Keys.Contains(e.Sender.Id))
                        {
                            #region -- 连续搜图 --
                            for (int i = 1; i < e.Chain.Length; i++)
                            {
                                ImageMessage imgMsg = e.Chain[i] as ImageMessage;
                                await SearchPictureHandler.SuccessiveSearchPicture(session, imgMsg, e.Sender, quoteMessage);
                            }
                            #endregion -- 连续搜图 --
                        }
                        break;
                }
            }
            return false;
        }
    }
}
