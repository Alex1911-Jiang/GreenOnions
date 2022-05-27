//using GreenOnions.PictureSearcher;
//using GreenOnions.Utility;
//using Mirai.CSharp;
//using Mirai.CSharp.Models;
//using Mirai.CSharp.Plugin.Interfaces;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GreenOnions.MiraiApiHttp
//{
//    public class TempMessage : ITempMessage
//    {
//        async Task<bool> ITempMessage.TempMessage(IMiraiHttpSession session, ITempMessageEventArgs e)
//        {
//            if (BotInfo.BannedUser.Contains(e.Sender.Id)) return false;
//            if (BotInfo.DebugMode)
//                if (BotInfo.DebugReplyAdminOnly)
//                    if (!BotInfo.AdminQQ.Contains(e.Sender.Id))
//                        return false;
//            if (e.Chain.Length > 1)  //普通消息
//            {
//                switch (e.Chain[1].Type)
//                {
//                    case "Plain":
//                        PlainMessageHandler.HandleFriendMesage(session, e.Chain, e.Sender.Id);
//                        break;
//                    case "Image":
//                        for (int i = 1; i < e.Chain.Length; i++)
//                        {
//                            ImageMessage imgMsg = e.Chain[i] as ImageMessage;
//                            await SearchPictureHandler.SearchPicture( imgMsg, picStream => session.UploadPictureAsync(UploadTarget.Group, picStream), msg => session.SendTempMessageAsync(e.Sender.Id, e.Sender.Group.Id, msg));
//                        }
//                        break;
//                }
//            }
//            return false;
//        }
//    }
//}
