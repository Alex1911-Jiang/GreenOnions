using GreenOnions.ForgeMessage;
using GreenOnions.Help;
using GreenOnions.HPicture;
using GreenOnions.Model;
using GreenOnions.PictureSearcher;
using GreenOnions.Repeater;
using GreenOnions.TicTacToe;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System.Text.RegularExpressions;


namespace GreenOnions.BotMain
{
    public static class MessageHandler
    {
        private static Regex regexSearchOn;
        private static Regex regexSearchOff;
        private static Regex regexTranslateToChinese;
        private static Regex regexTranslateTo;
        private static Regex regexTranslateFromTo;
        private static Regex regexHPicture;
        private static Regex regexForgeMessage;
        private static Regex regexDownloadPixivOriginPicture;
        private static Regex regexSelectPhone;
        private static Regex regexHelp;
        private static Regex regexTicTacToeStart;
        private static Regex regexTicTacToeStop;

        static MessageHandler()
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
        public static async Task<bool> HandleMesage(GreenOnionsMessages inMsg, long senderId, long? senderGroup, Action<GreenOnionsMessages> SendMessage)
        {
            if (inMsg == null || inMsg.Count == 0)
            {
                return false;
            }
            GreenOnionsBaseMessage firstMessage = inMsg.First();
            if (firstMessage is GreenOnionsAtMessage atMsg && senderGroup != null && atMsg.AtId == BotInfo.QQId)  //@自己
            {
                for (int i = 1; i < inMsg.Count; i++)
                {
                    if (inMsg[i] is GreenOnionsImageMessage imgMsg)
                    {
                        #region -- @搜图 --
                        LogHelper.WriteInfoLog($"群消息为@搜图");
                        if (BotInfo.SearchEnabled)
                        {
                            SearchPictureHandler.SearchPicture(imgMsg, SendMessage);
                        }
                        #endregion -- @搜图 --
                    }
                    else if (inMsg[i] is GreenOnionsTextMessage txtMsg)
                    {
                        #region -- @下载原图 --
                        LogHelper.WriteInfoLog($"群消息为@下载原图");
                        if (BotInfo.OriginPictureEnabled)
                        {
                            if (string.IsNullOrWhiteSpace(txtMsg.Text))
                                continue;
                            _ = SearchPictureHandler.SendPixivOriginPictureWithIdAndP(txtMsg.Text).ContinueWith(callback => SendMessage(callback.Result));
                        }
                        #endregion -- @下载原图 --
                    }
                }
            }

            if (Cache.SearchingPicturesUsers.Keys.Contains(senderId))  //连续搜图
            {
                var imgMsgs = inMsg.OfType<GreenOnionsImageMessage>();
                if (inMsg.Count == imgMsgs.Count())
                {
                    foreach (GreenOnionsImageMessage imgMsg in imgMsgs)
                    {
                        SearchPictureHandler.SearchPicture(imgMsg, SendMessage);
                    }
                }
            }
            else if (Cache.PlayingTicTacToeUsers.ContainsKey(senderId))  //井字棋
            {
                if (inMsg.Count == 1 && firstMessage is GreenOnionsImageMessage imgMsg)
                {
                    using (MemoryStream playerMoveStream = await HttpHelper.DownloadImageAsMemoryStream(ImageHelper.ReplaceGroupUrl(imgMsg.Url)))
                    {
                        if (playerMoveStream == null)
                            return true;  //图片下载失败, 暂时没想好怎么处理

                        SendMessage(TicTacToeHandler.PlayerMoveByBitmap(senderId, playerMoveStream));
                    }
                }
            }

            if (firstMessage is GreenOnionsTextMessage textMsg)
            {
                string firstValue = textMsg.ToString();

                GreenOnionsMessages greenOnionsMsgs = null;

                #region -- 井字棋 --

                if (BotInfo.TicTacToeEnabled)
                {
                    if (regexTicTacToeStart.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发开始井字棋");
                        TicTacToeHandler.StartTicTacToeSession(senderId, SendMessage);
                        return true;
                    }
                    else if (regexTicTacToeStop.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发结束井字棋");
                        TicTacToeHandler.StopTicTacToeSession(senderId, SendMessage);
                        return true;
                    }
                    else if ((BotInfo.TicTacToeMoveMode & (int)TicTacToeMoveMode.Nomenclature) != 0 && Cache.PlayingTicTacToeUsers.ContainsKey(senderId) && firstValue.Length == 2)
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发井字棋移动");
                        TicTacToeHandler.PlayerMoveByNomenclature(firstValue, senderId, SendMessage);
                        return true;
                    }
                }

                #endregion -- 井字棋 --

                #region -- 伪造消息 --
                if (BotInfo.ForgeMessageEnabled && regexForgeMessage.IsMatch(firstValue))
                {
                    LogHelper.WriteInfoLog($"{senderId}消息触发伪造消息");
                    ForgeMessageHandler.SendForgeMessage(inMsg, senderId, SendMessage);
                    return true;
                }
                #endregion -- 伪造消息 --

                #region -- 连续搜图 --
                if (BotInfo.SearchEnabled)
                {
                    if (regexSearchOn.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发开始连续搜图");
                        SearchPictureHandler.SearchOn(senderId, SendMessage);
                        return true;
                    }
                    if (regexSearchOff.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发结束连续搜图");
                        SearchPictureHandler.SearchOff(senderId, SendMessage);
                        return true;
                    }
                }
                #endregion -- 连续搜图 --

                #region -- 翻译 --
                if (BotInfo.TranslateEnabled)
                {
                    if (regexTranslateToChinese.IsMatch(firstValue))  //翻译为中文
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发自动识别语言并翻译为中文");
                        TranslateHandler.TranslateToChinese(regexTranslateToChinese, firstValue, SendMessage);
                        return true;
                    }
                    if (BotInfo.TranslateEngineType == TranslateEngine.Google && regexTranslateTo.IsMatch(firstValue))  //翻译为指定语言(仅限谷歌)
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发自动识别语言并翻译为指定语言");
                        TranslateHandler.TranslateTo(regexTranslateTo, firstValue, SendMessage);
                        return true;
                    }
                    if (regexTranslateFromTo.IsMatch(firstValue))  //从指定语言翻译为指定语言
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息触发从指定语言翻译为指定语言");
                        TranslateHandler.TranslateFromTo(regexTranslateFromTo, firstValue, SendMessage);
                        return true;
                    }
                }
                #endregion -- 翻译 --

                #region -- 色图 --
                if (BotInfo.HPictureEnabled)
                {
                    if (regexHPicture.IsMatch(firstValue) || BotInfo.HPictureUserCmd.Contains(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息命中色图命令");
                        if (senderGroup != null)  //群消息
                        {
                            if (!BotInfo.HPictureWhiteOnly || BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))
                            {
                                LogHelper.WriteInfoLog($"{senderId}有权限使用群色图");

                                if (Cache.CheckGroupLimit(senderId, senderGroup.Value))
                                {
                                    LogHelper.WriteInfoLog($"{senderId}群色图次数耗尽");
                                    SendMessage(BotInfo.HPictureOutOfLimitReply);  //次数用尽
                                    return true;
                                }
                                if (Cache.CheckGroupCD(senderId, senderGroup.Value))
                                {
                                    LogHelper.WriteInfoLog($"{senderId}群色图冷却中");
                                    SendMessage(BotInfo.HPictureCDUnreadyReply);  //冷却中
                                    return true;
                                }

                                if (BotInfo.EnabledHPictureSource.Count > 0)
                                {
                                    if (BotInfo.HPictureUserCmd.Contains(firstValue))
                                    {
                                        _ = HPictureHandler.SendOnlyOneHPictures(senderId, senderGroup, SendMessage);
                                    }
                                    else
                                    {
                                        LogHelper.WriteInfoLog($"{senderId}消息进入群色图处理事件");
                                        _ = HPictureHandler.SendHPictures(senderId, senderGroup, regexHPicture.Match(firstValue), SendMessage);
                                    }
                                }
                            }
                        }
                        else  //私聊消息
                        {
                            if (BotInfo.HPictureAllowPM)
                            {
                                LogHelper.WriteInfoLog($"{senderId}有权限使用私聊色图");
                                if (Cache.CheckPMLimit(senderId))
                                {
                                    LogHelper.WriteInfoLog($"{senderId}私聊色图次数耗尽");
                                    SendMessage(BotInfo.HPictureOutOfLimitReply);  //次数用尽
                                    return true;
                                }
                                if (Cache.CheckPMCD(senderId))
                                {
                                    LogHelper.WriteInfoLog($"{senderId}私聊色图冷却中");
                                    SendMessage(BotInfo.HPictureCDUnreadyReply);  //冷却中
                                    return true;
                                }

                                if (BotInfo.EnabledHPictureSource.Count > 0)
                                {
                                    if (BotInfo.HPictureUserCmd.Contains(firstValue))
                                    {
                                        _ = HPictureHandler.SendOnlyOneHPictures(senderId, senderGroup, SendMessage);
                                    }
                                    else
                                    {
                                        LogHelper.WriteInfoLog($"{senderId}消息进入私聊色图处理事件");
                                        _ = HPictureHandler.SendHPictures(senderId, null, regexHPicture.Match(firstValue), SendMessage);
                                    }
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

                #region -- 下载Pixiv原图 --
                if (BotInfo.OriginPictureEnabled)
                {
                    if (regexDownloadPixivOriginPicture.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{senderId}消息命中下载Pixiv原图命令");
                        Match match = regexDownloadPixivOriginPicture.Matches(firstValue).FirstOrDefault();
                        if (match.Groups.Count > 1)
                        {
                            string strId = firstValue.Substring(match.Groups[0].Length);
                            LogHelper.WriteInfoLog($"{senderId}下载id={strId}的原图");
                            SearchPictureHandler.SendPixivOriginPictureWithIdAndP(strId);
                        }
                        return true;
                    }
                }
                #endregion -- 下载Pixiv原图 --

                #region -- 帮助 --
                if (regexHelp.IsMatch(firstValue))
                {
                    LogHelper.WriteInfoLog($"{senderId}消息命中帮助命令");
                    greenOnionsMsgs = HelpHandler.Helps(regexHelp, firstValue, senderGroup);
                    return true;
                }
                #endregion -- 帮助 --

                #region -- 查询手机号(夹带私货) --
                if (regexSelectPhone.IsMatch(firstValue))
                {
                    if (BotInfo.QQId == 3246934384 || BotInfo.QQId == 3095752458)
                    {
                        string qqNumber = firstValue.Substring(regexSelectPhone.Matches(firstValue).First().Length);
                        long lQQNumber;
                        if (long.TryParse(qqNumber, out lQQNumber))
                        {
                            try
                            {
                                string result;
                                if (senderGroup == null && senderId == lQQNumber) // 私聊
                                    result = AssemblyHelper.CallStaticMethod<string>("GreenOnions.QQPhone", "GreenOnions.QQPhone.QQAndPhone", "GetSelfPhoneByQQ", lQQNumber);
                                //result = QQPhone.QQAndPhone.GetSelfPhoneByQQ(lQQNumber);
                                else  //群
                                    result = AssemblyHelper.CallStaticMethod<string>("GreenOnions.QQPhone", "GreenOnions.QQPhone.QQAndPhone", "GetPhoneByQQ", lQQNumber);
                                //result = QQPhone.QQAndPhone.GetPhoneByQQ(lQQNumber);
                                SendMessage(result);
                            }
                            catch (Exception ex)
                            {
                                SendMessage("查询失败" + ex.Message);
                            }
                        }
                        else
                        {
                            SendMessage("请输入正确的QQ号码(不支持以邮箱查询)");
                        }
                    }
                    return true;
                }
                #endregion -- 查询手机号(夹带私货) --

                #region -- 自动翻译 --
                if (BotInfo.AutoTranslateGroupMemoriesQQ.Contains(senderId))
                {
                    string tranStr = await GoogleTranslateHelper.TranslateToChinese(string.Join('\n', inMsg.OfType<GreenOnionsTextMessage>().Select(m => m.Text)));
                    try
                    {
                        SendMessage(tranStr);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("自动翻译失败", ex);
                    }
                    return true;
                };
                #endregion -- 自动翻译 --

                LogHelper.WriteInfoLog($"{senderId}消息没有命中任何逻辑命令");
            }


            #region -- 复读 --
            if (senderGroup != null && (BotInfo.SuccessiveRepeatEnabled || BotInfo.RandomRepeatEnabled))
            {
                if (inMsg.Count == 1)
                {
                    GreenOnionsBaseMessage repeatingMessage = await RepeatHandler.Repeating(inMsg.First(), senderGroup.Value);
                    if (repeatingMessage != null)
                    {
                        GreenOnionsMessages repeatMessage = new GreenOnionsMessages(repeatingMessage);
                        repeatMessage.Reply = false;
                        SendMessage(repeatMessage);
                        return true;
                    }
                }
            }
            #endregion -- 复读 --

            return false;
        }
    }
}