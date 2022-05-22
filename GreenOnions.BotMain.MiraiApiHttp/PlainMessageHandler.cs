using GreenOnions.ForgeMessage;
using GreenOnions.Help;
using GreenOnions.HPicture;
using GreenOnions.Model;
using GreenOnions.PictureSearcher;
using GreenOnions.TicTacToe;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.BotMain.MiraiApiHttp
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
        private static Regex regexTicTacToeStart;
        private static Regex regexTicTacToeStop;

        static PlainMessageHandler()
        {
            regexDownloadPixivOriginPicture = new Regex($"{BotInfo.BotName}下[載载][Pp]([Ii][Xx][Ii][Vv]|站)原[圖图][:：]");
            regexHelp = new Regex($"{BotInfo.BotName}帮助");
            regexSelectPhone = new Regex($"{BotInfo.BotName}查询手机号[:：]");
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
            regexTicTacToeStart = new Regex(BotInfo.StartTicTacToeCmd.ReplaceGreenOnionsTags());
            regexTicTacToeStop = new Regex(BotInfo.StopTicTacToeCmd.ReplaceGreenOnionsTags());
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="Chain">传入的消息体</param>
        /// <param name="sender">传入消息的QQ或群的属性</param>
        /// <param name="SendMessage">发送消息的委托(需要发出的消息体, 是否撤回或是否以回复的方式发送消息)</param>
        /// <param name="UploadPicture">上传图片事件(图片流, 返回上传完毕后的图片消息体)</param>
        /// <returns></returns>
        public static async Task<bool> HandleMesage(IChatMessage[] Chain, IBaseInfo sender, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture, Func<string[], Task<string[]>> SendImage, Action<int> RevokeMessage)
        {
            LogHelper.WriteInfoLog($"{sender.Id}消息进入处理逻辑");
            string firstMessage = Chain[1].ToString();

            GreenOnionsBaseMessage[] greenOnionsMsgs = null;

            #region -- 井字棋 --

            if (BotInfo.TicTacToeEnabled)
            {
                if (regexTicTacToeStart.IsMatch(firstMessage))
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发开始井字棋");
                    TicTacToeHandler.StartTicTacToeSession(sender.Id, SendMessage, UploadPicture);
                    return true;
                }
                else if (regexTicTacToeStop.IsMatch(firstMessage))
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发结束井字棋");
                    TicTacToeHandler.StopTicTacToeSession(sender.Id, SendMessage);
                    return true;
                }
                else if ((BotInfo.TicTacToeMoveMode & (int)TicTacToeMoveMode.Nomenclature) != 0 && Cache.PlayingTicTacToeUsers.ContainsKey(sender.Id) && firstMessage.Length == 2)
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发井字棋移动");
                    TicTacToeHandler.PlayerMoveByNomenclature(firstMessage, sender.Id, SendMessage, UploadPicture);
                    return true;
                } 
            }

            #endregion -- 井字棋 --

            #region -- 伪造消息 --
            if (BotInfo.ForgeMessageEnabled && regexForgeMessage.IsMatch(firstMessage))
            {
                LogHelper.WriteInfoLog($"{sender.Id}消息触发伪造消息");
                ForgeMessageHandler.SendForgeMessage(Chain.ToOnionsMessages(), sender.Id);
                return true;
            }
            #endregion -- 伪造消息 --

            #region -- 连续搜图 --
            if (BotInfo.SearchEnabled)
            {
                if (regexSearchOn.IsMatch(firstMessage))
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发开始连续搜图");
                    SearchPictureHandler.SearchOn(sender.Id, SendMessage);
                    return true;
                }
                if (regexSearchOff.IsMatch(firstMessage))
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发结束连续搜图");
                    SearchPictureHandler.SearchOff(sender.Id, SendMessage);
                    return true;
                }
            }
            #endregion -- 连续搜图 --

            #region -- 翻译 --
            if (BotInfo.TranslateEnabled)
            {
                if (regexTranslateToChinese.IsMatch(firstMessage))  //翻译为中文
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发自动识别语言并翻译为中文");
                    TranslateHandler.TranslateToChinese(regexTranslateToChinese, firstMessage, SendMessage);
                    return true;
                }
                if (BotInfo.TranslateEngineType == TranslateEngine.Google && regexTranslateTo.IsMatch(firstMessage))  //翻译为指定语言(仅限谷歌)
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发自动识别语言并翻译为指定语言");
                    TranslateHandler.TranslateTo(regexTranslateTo, firstMessage, SendMessage);
                    return true;
                }
                if (regexTranslateFromTo.IsMatch(firstMessage))  //从指定语言翻译为指定语言
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息触发从指定语言翻译为指定语言");
                    TranslateHandler.TranslateFromTo(regexTranslateFromTo, firstMessage, SendMessage);
                    return true;
                }
            }
            #endregion -- 翻译 --

            #region -- 色图 --
            if (BotInfo.HPictureEnabled)
            {
                if (regexHPicture.IsMatch(firstMessage) || BotInfo.HPictureUserCmd.Contains(firstMessage))
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息命中色图命令, 消息类型为:{sender.GetType()}");
                    if (sender is IGroupMemberInfo)  //群消息
                    {
                        IGroupMemberInfo senderGroup = sender as IGroupMemberInfo;
                        if (!BotInfo.HPictureWhiteOnly || BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id))
                        {
                            LogHelper.WriteInfoLog($"{sender.Id}有权限使用群色图");
                            if (senderGroup.Permission == GroupPermission.Member || !BotInfo.HPictureManageNoLimit)
                            {
                                if (Cache.CheckGroupLimit(senderGroup.Id, senderGroup.Group.Id))
                                {
                                    LogHelper.WriteInfoLog($"{sender.Id}群色图次数耗尽");
                                    _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureOutOfLimitReply) }, true);  //次数用尽
                                    return true;
                                }
                                if (Cache.CheckGroupCD(senderGroup.Id, senderGroup.Group.Id))
                                {
                                    LogHelper.WriteInfoLog($"{sender.Id}群色图冷却中");
                                    _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureCDUnreadyReply) }, true);  //冷却中
                                    return true;
                                }
                            }

                            if (BotInfo.EnabledHPictureSource.Count > 0)
                            {
                                LogHelper.WriteInfoLog($"{sender.Id}消息进入群色图处理事件");
                                Random r = new Random(Guid.NewGuid().GetHashCode());
                                PictureSource pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];
                                HPictureHandler.SendHPictures(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)), firstMessage, SendMessage, UploadPicture, RevokeMessage);
                            }
                        }
                    }
                    else if (sender is IFriendInfo)  //私聊消息
                    {
                        IFriendInfo senderFriend = sender as IFriendInfo;
                        if (BotInfo.HPictureAllowPM)
                        {
                            LogHelper.WriteInfoLog($"{sender.Id}有权限使用私聊色图");
                            if (Cache.CheckPMLimit(senderFriend.Id))
                            {
                                LogHelper.WriteInfoLog($"{sender.Id}私聊色图次数耗尽");
                                _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureOutOfLimitReply) }, true);  //次数用尽
                                return true;
                            }
                            if (Cache.CheckPMCD(senderFriend.Id))
                            {
                                LogHelper.WriteInfoLog($"{sender.Id}私聊色图冷却中");
                                _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureCDUnreadyReply) }, true);  //冷却中
                                return true;
                            }

                            if (BotInfo.EnabledHPictureSource.Count > 0)
                            {
                                LogHelper.WriteInfoLog($"{sender.Id}消息进入私聊色图处理事件");
                                Random r = new Random(Guid.NewGuid().GetHashCode());
                                PictureSource pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];
                                HPictureHandler.SendHPictures(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18, firstMessage, SendMessage, UploadPicture, RevokeMessage);
                            }
                            else
                            {
                                LogHelper.WriteInfoLog($"没有启用任何图库");
                            }
                        }
                    }
                    return true;
                }
            }
            #endregion -- 色图 --

            #region -- 美图 --
            if (BotInfo.HPictureEnabled && BotInfo.EnabledBeautyPictureSource.Count > 0 && regexBeautyPicture.IsMatch(firstMessage))
            {
                LogHelper.WriteInfoLog($"{sender.Id}消息进入美图处理事件");
                Random r = new Random(Guid.NewGuid().GetHashCode());
                PictureSource pictureSource = BotInfo.EnabledBeautyPictureSource[r.Next(0, BotInfo.EnabledBeautyPictureSource.Count)];
                HPictureHandler.SendHPictures(sender, pictureSource, BotInfo.BeautyPictureEndCmd, false, firstMessage, SendMessage, UploadPicture, RevokeMessage);
                return true;
            }
            #endregion -- 美图 --

            #region -- 下载Pixiv原图 --
            if (BotInfo.OriginPictureEnabled)
            {
                if (regexDownloadPixivOriginPicture.IsMatch(firstMessage))
                {
                    LogHelper.WriteInfoLog($"{sender.Id}消息命中下载Pixiv原图命令");
                    Match match = regexDownloadPixivOriginPicture.Matches(firstMessage).FirstOrDefault();
                    if (match.Groups.Count > 1)
                    {
                        string strId = firstMessage.Substring(match.Groups[0].Length);
                        LogHelper.WriteInfoLog($"{sender.Id}下载id={strId}的原图");
                        await SearchPictureHandler.SendPixivOriginPictureWithIdAndP(strId, SendImage, UploadPicture, SendMessage);
                    }
                    return true;
                }
            }
            #endregion -- 下载Pixiv原图 --

            #region -- 帮助 --
            if (regexHelp.IsMatch(firstMessage))
            {
                LogHelper.WriteInfoLog($"{sender.Id}消息命中帮助命令");
                greenOnionsMsgs = HelpHandler.Helps(regexHelp, firstMessage, sender is IGroupInfo groupInfo ? groupInfo.Id : -1);
                return true;
            }
            #endregion -- 帮助 --

            #region -- 查询手机号(夹带私货) --
            if (regexSelectPhone.IsMatch(firstMessage))
            {
                if (BotInfo.QQId == 3246934384)
                {
                    string qqNumber = firstMessage.Substring(regexSelectPhone.Matches(firstMessage).First().Length);
                    long lQQNumber;
                    if (long.TryParse(qqNumber, out lQQNumber))
                    {
                        try
                        {
                            string result = AssemblyHelper.CallStaticMethod<string>("GreenOnions.QQPhone", "GreenOnions.QQPhone.QQAndPhone", "GetPhoneByQQ", lQQNumber);
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(result) }, true);
                        }
                        catch (Exception ex)
                        {
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("查询失败" + ex.Message) }, true);
                        }
                    }
                    else
                    {
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("请输入正确的QQ号码(不支持以邮箱查询)") }, true);
                    }
                }
                return true;
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
                    LogHelper.WriteErrorLogWithUserMessage("自动翻译失败", ex);
                }
                return true;
            };
            #endregion -- 自动翻译 --




            LogHelper.WriteInfoLog($"{sender.Id}消息没有命中任何命令");
            return false;
        }
    }
}
