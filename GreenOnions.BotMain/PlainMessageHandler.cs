using GreenOnions.HPicture;
using GreenOnions.Translate;
using GreenOnions.Utility;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public static class PlainMessageHandler
    {
        public static async void HandleMesage(MiraiHttpSession session, string message, IGroupMemberInfo sender, QuoteMessage quoteMessage)
        {
            Regex regexSearchOn = new Regex(BotInfo.SearchModeOnCmd.Replace("<机器人名称>", BotInfo.BotName));
            Regex regexSearchOff = new Regex(BotInfo.SearchModeOffCmd.Replace("<机器人名称>", BotInfo.BotName));
            Regex regexTranslateToChinese = new Regex(BotInfo.TranslateToChineseCMD.Replace("<机器人名称>", BotInfo.BotName));
            Regex regexTranslateTo = new Regex(BotInfo.TranslateToCMD.Replace("<机器人名称>", BotInfo.BotName));
            Regex regexHPicture = new Regex(BotInfo.HPictureCmd.Replace("<机器人名称>", BotInfo.BotName));

            #region -- 连续搜图 --
            if (regexSearchOn.IsMatch(message))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures[sender.Id] = DateTime.Now.AddMinutes(1);
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeAlreadyOnReply.Replace("<机器人名称>", BotInfo.BotName)) }, quoteMessage.Id);
                }
                else
                {
                    Cache.SearchingPictures.Add(sender.Id, DateTime.Now.AddMinutes(1));
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeOnReply.Replace("<机器人名称>", BotInfo.BotName)) }, quoteMessage.Id);
                    Cache.CheckSearchPictureTime(callback =>
                    {
                        Cache.SearchingPictures.Remove(sender.Id);
                        session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeTimeOutReply.Replace("<机器人名称>", BotInfo.BotName)) }, quoteMessage.Id);
                    });
                }
            }
            else if (regexSearchOff.IsMatch(message))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures.Remove(sender.Id);
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeOffReply.Replace("<机器人名称>", BotInfo.BotName)) }, quoteMessage.Id);
                }
                else
                {
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeAlreadyOffReply.Replace("<机器人名称>", BotInfo.BotName)) }, quoteMessage.Id);
                }
            }
            #endregion -- 连续搜图 --
            #region -- 翻译 --
            else if (regexTranslateToChinese.IsMatch(message))
            {
                foreach (Match match in regexTranslateToChinese.Matches(message))
                {
                    try
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(await GoogleTranslateHelper.TranslateToChinese(message.Substring(match.Value.Length))) }, quoteMessage.Id);
                    }
                    catch (Exception ex)
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id,  new PlainMessage("翻译失败，" + ex.Message) );
                    }
                    break;
                }
            }
            else if (regexTranslateTo.IsMatch(message))
            {
                foreach (Match match in regexTranslateTo.Matches(message))
                {
                    if (match.Groups.Count > 1)
                    {
                        try
                        {
                            await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(await GoogleTranslateHelper.TranslateTo(message.Substring(match.Value.Length), match.Groups[1].Value)) }, quoteMessage.Id);
                        }
                        catch (Exception ex)
                        {
                            await session.SendGroupMessageAsync(sender.Group.Id, new PlainMessage("翻译失败，" + ex.Message));
                        }
                    }
                    break;
                }
            }
            #endregion -- 翻译 --
            #region -- 色图 --
            else if (regexHPicture.IsMatch(message))
            {
                //await foreach (var item in HPictureHandlerAsync.SendHPictures(session, message, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id))))
                //{
                //    int messageID = await session.SendGroupMessageAsync(sender.Group.Id, new[] { item }, quoteMessage.Id);

                //    if (item is PlainMessage)  //地址发出去后记录次数
                //    {
                //        if (BotInfo.HPictureLimitType == LimitType.Frequency)
                //        {
                //            Cache.RecordLimit(sender.Id);
                //        }
                //        Cache.RecordCD(sender.Id, sender.Group.Id);
                //    }
                //    else if (item is ImageMessage)
                //    {
                //        if (BotInfo.HPictureLimitType == LimitType.Count)
                //        {
                //            Cache.RecordLimit(sender.Id);
                //        }
                //        HPictureHandler.RevokeHPicture(session, messageID, BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id) ? BotInfo.HPictureWhiteRevoke : BotInfo.HPictureRevoke);
                //    }
                //}

                HPictureHandler.SendHPictures(session, sender, quoteMessage, message, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id)));
            }
            #endregion -- 色图 --
        }
    }
}
