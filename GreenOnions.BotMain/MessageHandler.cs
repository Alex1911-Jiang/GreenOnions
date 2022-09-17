using GreenOnions.Command;
using GreenOnions.ForgeMessage;
using GreenOnions.Help;
using GreenOnions.HPicture;
using GreenOnions.Interface;
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
        private static Regex regexSearchAnimeOn;
        private static Regex regexSearch3DOn;
        private static Regex regexSearchOff;
        private static Regex regexTranslateToChinese;
        private static Regex regexTranslateTo;
        private static Regex regexTranslateFromTo;
        private static Regex regexHPicture;
        private static Regex regexForgeMessage;
        private static Regex regexDownloadPixivOriginalPicture;
        private static Regex regexHelp;
        private static Regex regexTicTacToeStart;
        private static Regex regexTicTacToeStop;

        static MessageHandler()
        {
            regexDownloadPixivOriginalPicture = new Regex($"{BotInfo.BotName}下[載载][Pp]([Ii][Xx][Ii][Vv]|站)原[圖图][:：]");
            regexHelp = new Regex($"{BotInfo.BotName}帮助");
            UpdateRegexs();
        }

        public static string UpdateRegexs()
        {
            string regexName = null;
            try
            {
                regexName = "开启搜图";
                regexSearchOn = new Regex(BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags());
                regexName = "开启搜番";
                regexSearchAnimeOn = new Regex(BotInfo.SearchAnimeModeOnCmd.ReplaceGreenOnionsTags());
                regexName = "开启搜车";
                regexSearch3DOn = new Regex(BotInfo.Search3DModeOnCmd.ReplaceGreenOnionsTags());
                regexName = "关闭搜图";
                regexSearchOff = new Regex(BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags());
                regexName = "翻译为中文";
                regexTranslateToChinese = new Regex(BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags());
                regexName = "翻译";
                regexTranslateTo = new Regex(BotInfo.TranslateToCMD.ReplaceGreenOnionsTags());
                regexName = "指定语言翻译";
                regexTranslateFromTo = new Regex(BotInfo.TranslateFromToCMD.ReplaceGreenOnionsTags());
                regexName = "色图";
                regexHPicture = new Regex(BotInfo.HPictureCmd.ReplaceGreenOnionsTags());
                regexName = "伪造消息";
                regexForgeMessage = new Regex(BotInfo.ForgeMessageCmdBegin.ReplaceGreenOnionsTags());
                regexName = "开启井字棋";
                regexTicTacToeStart = new Regex(BotInfo.StartTicTacToeCmd.ReplaceGreenOnionsTags());
                regexName = "结束井字棋";
                regexTicTacToeStop = new Regex(BotInfo.StopTicTacToeCmd.ReplaceGreenOnionsTags());
                regexName = null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLogWithUserMessage($"更新{regexName}正则命令发生异常", ex);
            }
            return regexName;
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="inMsg">传入的消息体</param>
        /// <param name="senderGroup">消息来自的群号(私聊时为空)</param>
        /// <param name="SendMessage">回发消息方法</param>
        /// <returns></returns>
        public static async Task<bool> HandleMesage(GreenOnionsMessages inMsg, long? senderGroup, Action<GreenOnionsMessages> SendMessage)
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
                            SearchPictureHandler.SearchPicture(imgMsg, SendMessage, SearchMode.Picture | SearchMode.Anime);
                        #endregion -- @搜图 --
                    }
                    else if (inMsg[i] is GreenOnionsTextMessage txtMsg)
                    {
                        #region -- @下载原图 --
                        LogHelper.WriteInfoLog($"群消息为@下载原图");
                        if (BotInfo.OriginalPictureEnabled)
                        {
                            if (string.IsNullOrWhiteSpace(txtMsg.Text))
                                continue;
                            _ = SearchPictureHandler.SendPixivOriginalPictureWithIdAndP(txtMsg.Text).ContinueWith(callback => SendMessage(callback.Result));
                        }
                        #endregion -- @下载原图 --
                    }
                }
            }

            if (Cache.SearchingPicturesUsers.Keys.Contains(inMsg.SenderId) || Cache.SearchingAnimeUsers.Keys.Contains(inMsg.SenderId) || Cache.Searching3DUsers.Keys.Contains(inMsg.SenderId))  //连续搜图
            {
                var imgMsgs = inMsg.OfType<GreenOnionsImageMessage>();
                if (inMsg.Count == imgMsgs.Count())
                {
                    SearchMode mode = 0;
                    if (Cache.SearchingPicturesUsers.Keys.Contains(inMsg.SenderId))
                        mode |= SearchMode.Picture;
                    if (Cache.SearchingAnimeUsers.Keys.Contains(inMsg.SenderId))
                        mode |=  SearchMode.Anime;
                    if (Cache.Searching3DUsers.Keys.Contains(inMsg.SenderId))
                        mode |= SearchMode.ThreeD;
                    SearchPictureHandler.UpdateSearchTime(inMsg.SenderId);  //刷新搜图超时时间到1分钟
                    foreach (GreenOnionsImageMessage imgMsg in imgMsgs)
                        SearchPictureHandler.SearchPicture(imgMsg, SendMessage, mode);
                    return true;
                }
            }
            else if (Cache.PlayingTicTacToeUsers.ContainsKey(inMsg.SenderId))  //井字棋
            {
                if (inMsg.Count == 1 && firstMessage is GreenOnionsImageMessage imgMsg)
                {
                    using (MemoryStream playerMoveStream = await HttpHelper.DownloadImageAsMemoryStreamAsync(ImageHelper.ReplaceGroupUrl(imgMsg.Url)))
                    {
                        if (playerMoveStream == null)
                            return true;  //图片下载失败, 暂时没想好怎么处理

                        SendMessage(TicTacToeHandler.PlayerMoveByBitmap(inMsg.SenderId, playerMoveStream));
                    }
                    return true;
                }
            }

            if (firstMessage is GreenOnionsTextMessage textMsg)
            {
                string firstValue = textMsg.ToString();

                #region -- 命令 --
                string command = "<机器人名称>命令".ReplaceGreenOnionsTags();
                if (BotInfo.AdminQQ.Contains(inMsg.SenderId) && firstValue.StartsWith(command))
                {
                    string? cmdReply = await CommandEditor.HandleCommand(string.Join("", inMsg).Substring(command.Length).Trim(), UpdateRegexs);
                    if (cmdReply != null)
                    {
                        SendMessage(cmdReply);
                        return true;
                    }
                }
                #endregion -- 命令 --

                #region -- 井字棋 --

                if (BotInfo.TicTacToeEnabled)
                {
                    if (regexTicTacToeStart.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发开始井字棋");
                        TicTacToeHandler.StartTicTacToeSession(inMsg.SenderId, SendMessage);
                        return true;
                    }
                    else if (regexTicTacToeStop.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发结束井字棋");
                        TicTacToeHandler.StopTicTacToeSession(inMsg.SenderId, SendMessage);
                        return true;
                    }
                    else if ((BotInfo.TicTacToeMoveMode & (int)TicTacToeMoveMode.Nomenclature) != 0 && Cache.PlayingTicTacToeUsers.ContainsKey(inMsg.SenderId) && firstValue.Length == 2)
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发井字棋移动");
                        TicTacToeHandler.PlayerMoveByNomenclature(firstValue, inMsg.SenderId, SendMessage);
                        return true;
                    }
                }

                #endregion -- 井字棋 --

                #region -- 伪造消息 --
                if (BotInfo.ForgeMessageEnabled && regexForgeMessage.IsMatch(firstValue))
                {
                    LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发伪造消息");
                    ForgeMessageHandler.SendForgeMessage(inMsg, inMsg.SenderId, SendMessage);
                    return true;
                }
                #endregion -- 伪造消息 --

                #region -- 连续搜图 --
                if (BotInfo.SearchEnabled)
                {
                    SearchMode mode =  0;
                    if ((BotInfo.SearchEnabledSauceNAO || BotInfo.SearchEnabledASCII2D) && regexSearchOn.IsMatch(firstValue))
                        mode |= SearchMode.Picture;
                    if (BotInfo.SearchEnabledTraceMoe && regexSearchAnimeOn.IsMatch(firstValue))
                        mode |= SearchMode.Anime;
                    if (BotInfo.SearchEnabled3dIqdb && regexSearch3DOn.IsMatch(firstValue))
                        mode |= SearchMode.ThreeD;

                    if (mode != 0)
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发开始连续搜图");
                        SearchPictureHandler.SearchOn(inMsg.SenderId, SendMessage, mode);
                        return true;
                    }
                    if (regexSearchOff.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发结束连续搜图");
                        SearchPictureHandler.SearchOff(inMsg.SenderId, SendMessage);
                        return true;
                    }
                }
                #endregion -- 连续搜图 --

                #region -- 翻译 --
                if (BotInfo.TranslateEnabled)
                {
                    if (regexTranslateToChinese.IsMatch(firstValue))  //翻译为中文
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发自动识别语言并翻译为中文");
                        TranslateHandler.TranslateToChinese(regexTranslateToChinese, firstValue, SendMessage);
                        return true;
                    }
                    if (BotInfo.TranslateEngineType == TranslateEngine.Google && regexTranslateTo.IsMatch(firstValue))  //翻译为指定语言(仅限谷歌)
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发自动识别语言并翻译为指定语言");
                        TranslateHandler.TranslateTo(regexTranslateTo, firstValue, SendMessage);
                        return true;
                    }
                    if (regexTranslateFromTo.IsMatch(firstValue))  //从指定语言翻译为指定语言
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息触发从指定语言翻译为指定语言");
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
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息命中色图命令");
                        if (senderGroup != null)  //群消息
                        {
                            if (!BotInfo.HPictureWhiteOnly || BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))
                            {
                                LogHelper.WriteInfoLog($"{inMsg.SenderId}有权限使用群色图");

                                if (Cache.CheckGroupLimit(inMsg.SenderId, senderGroup.Value))
                                {
                                    LogHelper.WriteInfoLog($"{inMsg.SenderId}群色图次数耗尽");
                                    SendMessage(new GreenOnionsMessages(BotInfo.HPictureOutOfLimitReply));  //次数用尽
                                    return true;
                                }
                                if (Cache.CheckGroupCD(inMsg.SenderId, senderGroup.Value))
                                {
                                    LogHelper.WriteInfoLog($"{inMsg.SenderId}群色图冷却中");
                                    SendMessage(new GreenOnionsMessages(BotInfo.HPictureCDUnreadyReply));  //冷却中
                                    return true;
                                }

                                if (BotInfo.EnabledHPictureSource.Count > 0)
                                {
                                    if (BotInfo.HPictureUserCmd.Contains(firstValue))
                                    {
                                        HPictureHandler.SendOnlyOneHPictures(inMsg.SenderId, senderGroup, SendMessage);
                                    }
                                    else
                                    {
                                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息进入群色图处理事件");
                                        HPictureHandler.SendHPictures(inMsg.SenderId, senderGroup, regexHPicture.Match(firstValue), SendMessage);
                                    }
                                }
                            }
                        }
                        else  //私聊消息
                        {
                            if (BotInfo.HPictureAllowPM)  //允许私聊使用色图
                            {
                                LogHelper.WriteInfoLog($"{inMsg.SenderId}有权限使用私聊色图");
                                if (Cache.CheckPMLimit(inMsg.SenderId))
                                {
                                    LogHelper.WriteInfoLog($"{inMsg.SenderId}私聊色图次数耗尽");
                                    SendMessage(new GreenOnionsMessages(BotInfo.HPictureOutOfLimitReply));  //次数用尽
                                    return true;
                                }
                                if (Cache.CheckPMCD(inMsg.SenderId))
                                {
                                    LogHelper.WriteInfoLog($"{inMsg.SenderId}私聊色图冷却中");
                                    SendMessage(new GreenOnionsMessages(BotInfo.HPictureCDUnreadyReply));  //冷却中
                                    return true;
                                }

                                if (BotInfo.EnabledHPictureSource.Count > 0)
                                {
                                    if (BotInfo.HPictureUserCmd.Contains(firstValue))
                                    {
                                        HPictureHandler.SendOnlyOneHPictures(inMsg.SenderId, senderGroup, SendMessage);
                                    }
                                    else
                                    {
                                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息进入私聊色图处理事件");
                                        HPictureHandler.SendHPictures(inMsg.SenderId, null, regexHPicture.Match(firstValue), SendMessage);
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
                if (BotInfo.OriginalPictureEnabled)
                {
                    if (regexDownloadPixivOriginalPicture.IsMatch(firstValue))
                    {
                        LogHelper.WriteInfoLog($"{inMsg.SenderId}消息命中下载Pixiv原图命令");
                        Match match = regexDownloadPixivOriginalPicture.Matches(firstValue).FirstOrDefault();
                        if (match.Groups.Count > 1)
                        {
                            string strId = firstValue.Substring(match.Groups[0].Length);
                            LogHelper.WriteInfoLog($"{inMsg.SenderId}下载id={strId}的原图");
                            _ = SearchPictureHandler.SendPixivOriginalPictureWithIdAndP(strId).ContinueWith(callback => SendMessage(callback.Result));
                        }
                        return true;
                    }
                }
                #endregion -- 下载Pixiv原图 --

                #region -- 帮助 --
                if (regexHelp.IsMatch(firstValue))
                {
                    LogHelper.WriteInfoLog($"{inMsg.SenderId}消息命中帮助命令");
                    SendMessage(HelpHandler.Helps(regexHelp, firstValue, senderGroup));
                    return true;
                }
                #endregion -- 帮助 --

                #region -- 自动翻译 --
                if (BotInfo.AutoTranslateGroupMemoriesQQ.Contains(inMsg.SenderId))
                {
                    string tranStr = await GoogleTranslateHelper.TranslateToChinese(string.Join('\n', inMsg.OfType<GreenOnionsTextMessage>().Select(m => m.Text)));
                    try
                    {
                        SendMessage(new GreenOnionsMessages(tranStr));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("自动翻译失败", ex);
                    }
                    return true;
                };
                #endregion -- 自动翻译 --

                LogHelper.WriteInfoLog($"{inMsg.SenderId}消息没有命中任何逻辑命令");
            }

            if (PluginManager.Message(inMsg, senderGroup, SendMessage))
                return true;

            if (BotInfo.PmAutoSearch && senderGroup is null && BotInfo.SearchEnabled)  //私聊自动搜图
            {
                for (int i = 0; i < inMsg.Count; i++)
                {
                    if (inMsg[i] is GreenOnionsImageMessage imgMsg)
                        SearchPictureHandler.SearchPicture(imgMsg, SendMessage, SearchMode.Picture | SearchMode.Anime | SearchMode.ThreeD);
                }
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