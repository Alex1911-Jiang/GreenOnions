using GreenOnions.ForgeMessage;
using GreenOnions.Help;
using GreenOnions.HPicture;
using GreenOnions.PictureSearcher;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public static class PlainMessageHandler
    {
        private static Regex regexSearchOn;
        private static Regex regexSearchOff;
        private static Regex regexTranslateToChinese;
        private static Regex regexTranslateTo;
        private static Regex regexTranslateFromTo;
        private static Regex regexHPicture;
        private static Regex regexBeautyPicture;
        private static Regex regexForgeMessage;
        private static Regex regexDownloadPixivOriginPicture;
        private static Regex regexSelectPhone;
        private static Regex regexHelp;

        static PlainMessageHandler()
        {
            regexDownloadPixivOriginPicture = new Regex($"{BotInfo.BotName}下[載载][Pp]([Ii][Xx][Ii][Vv]|站)原[圖图][:：]");
            regexHelp = new Regex($"{BotInfo.BotName}帮助");
            regexSelectPhone = new Regex($"({BotInfo.BotName}查询手机号[:：])");
            UpdateRegexs();
        }

        public static void UpdateRegexs()
        {
            regexSearchOn = new Regex(BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags());
            regexSearchOff = new Regex(BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags());
            regexTranslateToChinese = new Regex(BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags());
            regexTranslateTo = new Regex(BotInfo.TranslateToCMD.ReplaceGreenOnionsTags());
            regexTranslateFromTo = new Regex(BotInfo.TranslateFromToCMD.ReplaceGreenOnionsTags());
            regexHPicture = new Regex(BotInfo.HPictureCmd.ReplaceGreenOnionsTags());
            regexBeautyPicture = new Regex(BotInfo.BeautyPictureCmd.ReplaceGreenOnionsTags());
            regexForgeMessage = new Regex(BotInfo.ForgeMessageCmdBegin.ReplaceGreenOnionsTags());
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="Chain">传入的消息体</param>
        /// <param name="sender">传入消息的QQ或群的属性</param>
        /// <param name="SendMessage">发送消息的委托(需要发出的消息体, 是否撤回或是否以回复的方式发送消息)</param>
        /// <param name="UploadPicture">上传图片事件(图片流, 返回上传完毕后的图片消息体)</param>
        /// <returns></returns>
        public static async Task HandleMesage(IChatMessage[] Chain, IBaseInfo sender, Action<IChatMessage[], bool> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture, Func<string[], Task<string[]>> SendImage)
        {
            string firstMessage = Chain[1].ToString();

            #region -- 伪造消息 --
            if (BotInfo.ForgeMessageEnabled && regexForgeMessage.IsMatch(firstMessage))
            {
                ForgeMessageHandler.SendForgeMessage(Chain, sender.Id, SendMessage);
                return;
            }
            #endregion -- 伪造消息 --

            #region -- 连续搜图 --
            if (regexSearchOn.IsMatch(firstMessage))
            {
                SearchPictureHandler.SearchOn(sender.Id, SendMessage);
                return;
            }
            if (regexSearchOff.IsMatch(firstMessage))
            {
                SearchPictureHandler.SearchOff(sender.Id, SendMessage);
                return;
            }
            #endregion -- 连续搜图 --

            #region -- 翻译 --
            if (regexTranslateToChinese.IsMatch(firstMessage))  //翻译为中文
            {
                TranslateHandler.TranslateToChinese(regexTranslateToChinese, firstMessage, SendMessage);
                return;
            }
            if (BotInfo.TranslateEngineType == TranslateEngine.Google)
            {
                if (regexTranslateTo.IsMatch(firstMessage))  //翻译为指定语言(仅限谷歌)
                    TranslateHandler.TranslateTo(regexTranslateTo, firstMessage, SendMessage);
                return;
            }
            if (regexTranslateFromTo.IsMatch(firstMessage))  //从指定语言翻译为指定语言
            {
                TranslateHandler.TranslateFromTo(regexTranslateFromTo, firstMessage, SendMessage);
                return;
            }
            #endregion -- 翻译 --

            #region -- 色图 --
            if (regexHPicture.IsMatch(firstMessage) || BotInfo.HPictureUserCmd.Contains(firstMessage))
            {
                if (BotInfo.HPictureEnabled)
                {
                    if (sender is IGroupMemberInfo)  //群消息
                    {
                        IGroupMemberInfo senderGroup = sender as IGroupMemberInfo;
                        if (!BotInfo.HPictureWhiteOnly || (BotInfo.HPictureR18WhiteOnly && BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)))
                        {
                            if (senderGroup.Permission == GroupPermission.Member || !BotInfo.HPictureManageNoLimit)
                            {
                                if (Cache.CheckGroupLimit(senderGroup.Id, senderGroup.Group.Id))
                                {
                                    SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureOutOfLimitReply) }, false);
                                    return;
                                }
                                if (Cache.CheckGroupCD(senderGroup.Id, senderGroup.Group.Id))
                                {
                                    SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureCDUnreadyReply) }, false);
                                    return;
                                }
                            }

                            if (BotInfo.EnabledHPictureSource.Count > 0)
                            {
                                Random r = new Random();
                                PictureSource pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];
                                HPictureHandler.SendHPictures(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)), firstMessage, SendMessage, UploadPicture);
                            }
                        }
                    }
                    else if (sender is IFriendInfo)  //私聊消息
                    {
                        IFriendInfo senderFriend = sender as IFriendInfo;
                        if (BotInfo.HPictureAllowPM)
                        {
                            if (Cache.CheckPMLimit(senderFriend.Id))
                            {
                                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureOutOfLimitReply) }, false);
                                return;
                            }
                            if (Cache.CheckPMCD(senderFriend.Id))
                            {
                                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureCDUnreadyReply) }, false);
                                return;
                            }

                            if (BotInfo.EnabledHPictureSource.Count > 0)
                            {
                                Random r = new Random();
                                PictureSource pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];
                                HPictureHandler.SendHPictures(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18, firstMessage, SendMessage, UploadPicture);
                            }
                        }
                    }
                }
                return;
            }
            #endregion -- 色图 --

            #region -- 美图 --
            if (regexBeautyPicture.IsMatch(firstMessage))
            {
                if (BotInfo.HPictureEnabled && BotInfo.EnabledBeautyPictureSource.Count > 0)
                {
                    Random r = new Random();
                    PictureSource pictureSource = BotInfo.EnabledBeautyPictureSource[r.Next(0, BotInfo.EnabledBeautyPictureSource.Count)];
                    HPictureHandler.SendHPictures(sender, pictureSource, BotInfo.BeautyPictureEndCmd, false, firstMessage, SendMessage, UploadPicture);
                }
                return;
            }
            #endregion -- 美图 --

            #region -- 下载Pixiv原图 --
            if (regexDownloadPixivOriginPicture.IsMatch(firstMessage))
            {
                Match match = regexDownloadPixivOriginPicture.Matches(firstMessage).FirstOrDefault();
                if (match.Groups.Count > 1)
                {
                    string strId = firstMessage.Substring(match.Groups[0].Length);
                    await SearchPictureHandler.SendPixivOriginPictureWithIdAndP(strId, SendImage, UploadPicture, msg => SendMessage?.Invoke(msg, false));
                }
                return;
            }
            #endregion -- 下载Pixiv原图 --

            #region -- 帮助 --
            if (regexHelp.IsMatch(firstMessage))
            {
                HelpHandler.Helps(regexHelp, sender, firstMessage, SendMessage);
                return;
            }
            #endregion -- 帮助 --

            #region -- 查询手机号(夹带私货) --
            if (regexSelectPhone.IsMatch(firstMessage))
            {
                if (BotInfo.QQId == 3246934384)
                {
                    foreach (Match match in regexSelectPhone.Matches(firstMessage))
                    {
                        if (match.Groups.Count > 1)
                        {
                            string qqNumber = firstMessage.Substring(match.Groups[1].Length);
                            long lQQNumber;
                            if (long.TryParse(qqNumber, out lQQNumber))
                            {
                                try
                                {
                                    string result = AssemblyHelper.CallStaticMethod<string>("GreenOnions.QQPhone", "GreenOnions.QQPhone.QQAndPhone", "GetPhoneByQQ", lQQNumber);
                                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(result) }, false);
                                }
                                catch (Exception ex)
                                {
                                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("查询失败" + ex.Message) }, false);
                                }
                            }
                            else
                            {
                                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("请输入正确的QQ号码(不支持以邮箱查询)") }, false);
                            }
                        }
                    }
                }
                return;
            }
            #endregion -- 查询手机号(夹带私货) --

            #region -- 自动翻译 --
            if (BotInfo.AutoTranslateGroupMemoriesQQ.Contains(sender.Id))
            {
                string tranStr = await GoogleTranslateHelper.TranslateToChinese(string.Join('\n', Chain.Skip(1)));
                try
                {
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(tranStr) }, false);
                }
                catch (Exception ex)
                {
                    ErrorHelper.WriteErrorLogWithUserMessage("自动翻译失败", ex);
                }
                return;
            };
            #endregion -- 自动翻译 --
        }
    }
}
