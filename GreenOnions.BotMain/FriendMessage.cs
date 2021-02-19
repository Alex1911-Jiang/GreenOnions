using GreenOnions.PictureSearcher;
using GreenOnions.Utility;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using Mirai_CSharp.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public class FriendMessage : IFriendMessage
    {
        async Task<bool> IFriendMessage.FriendMessage(MiraiHttpSession session, IFriendMessageEventArgs e)
        {
            if (BotInfo.BannedUser.Contains(e.Sender.Id)) return false;
            if (e.Chain.Length > 1)  //普通消息
            {
                switch (e.Chain[1].Type)
                {
                    case "Plain":
                        //PlainMessageHandler.HandleFriendMesage(session, e.Chain, e.Sender);
                        break;
                    case "Image":
                        for (int i = 1; i < e.Chain.Length; i++)
                        {
                            ImageMessage imgMsg = e.Chain[i] as ImageMessage; 
                            await SearchPictureHandler.SearchPicture(session, imgMsg, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream), msg => session.SendFriendMessageAsync(e.Sender.Id, msg));
                        }
                        break;
                }
            }
            return false;
        }
    }
}
