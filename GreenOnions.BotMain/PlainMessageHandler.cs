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
                if (!BotInfo.ForgeMessageAdminOnly || BotInfo.AdminQQ.Contains(sender.Id))
                {
                    if (Chain.Length > 3 && (Chain[2] is MyAtMessage))
                    {
                        MyAtMessage atMessage = Chain[2] as MyAtMessage;
                        if (!BotInfo.AdminQQ.Contains(sender.Id) && BotInfo.AdminQQ.Contains(atMessage.Target))
                        {
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.RefuseForgeAdminReply.ReplaceGreenOnionsTags()) }, false);
                            return;
                        }
                        if (!BotInfo.AdminQQ.Contains(sender.Id) && atMessage.Target == BotInfo.QQId)
                        {
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.RefuseForgeBotReply.ReplaceGreenOnionsTags()) }, false);
                            return;
                        }

                        List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode> forwardMessageNodes = new List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode>();
                        for (int i = 3; i < Chain.Length; i++)
                        {
                            if (Chain[i] is IPlainMessage)
                            {
                                string[] plainMsgs = Chain[i].ToString().Trim().Split(BotInfo.ForgeMessageCmdNewLine);
                                for (int j = 0; j < plainMsgs.Length; j++)
                                {
                                    if (!string.IsNullOrEmpty(plainMsgs[j]))
                                    {
                                        forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                        {
                                            Id = forwardMessageNodes.Count,
                                            Name = atMessage.Name,
                                            QQNumber = atMessage.Target,
                                            Time = DateTime.Now,
                                            Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(plainMsgs[j]) },
                                        });
                                    }
                                }
                            }
                            else if (Chain[i] is IImageMessage)
                            {
                                forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                {
                                    Id = forwardMessageNodes.Count,
                                    Name = atMessage.Name,
                                    QQNumber = atMessage.Target,
                                    Time = DateTime.Now,
                                    Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage((Chain[i] as IImageMessage).ImageId, null, null) },
                                });
                            }
                            else
                                continue;
                        }

                        if (BotInfo.ForgeMessageAppendBotMessageEnabled)
                        {
                            if (!BotInfo.ForgeMessageAdminDontAppend || !BotInfo.AdminQQ.Contains(sender.Id))
                            {
                                forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                {
                                    Id = forwardMessageNodes.Count,
                                    Name = BotInfo.BotName,
                                    QQNumber = BotInfo.QQId,
                                    Time = DateTime.Now,
                                    Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.ForgeMessageAppendMessage.ReplaceGreenOnionsTags()) },
                                });
                            }
                        }

                        Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage forwardMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage(forwardMessageNodes.ToArray());
                        SendMessage?.Invoke(new[] { forwardMessage }, false);
                        return;
                    }
                }
            }
            #endregion -- 伪造消息 --

            #region -- 连续搜图 --
            if (regexSearchOn.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures[sender.Id] = DateTime.Now.AddMinutes(1);
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeAlreadyOnReply.ReplaceGreenOnionsTags()) }, false);
                }
                else
                {
                    Cache.SearchingPictures.Add(sender.Id, DateTime.Now.AddMinutes(1));
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeOnReply.ReplaceGreenOnionsTags()) }, false);
                    Cache.CheckSearchPictureTime(_ =>
                    {
                        Cache.SearchingPictures.Remove(sender.Id);
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeTimeOutReply.ReplaceGreenOnionsTags()) }, false);
                    });
                }
            }
            if (regexSearchOff.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures.Remove(sender.Id);
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeOffReply.ReplaceGreenOnionsTags()) }, false);
                }
                else
                {
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeAlreadyOffReply.ReplaceGreenOnionsTags()) }, false);
                }
            }
            #endregion -- 连续搜图 --

            #region -- 翻译 --
            if (regexTranslateToChinese.IsMatch(firstMessage))
            {
                foreach (Match match in regexTranslateToChinese.Matches(firstMessage))
                {
                    try
                    {
                        string text = firstMessage.Substring(match.Value.Length);
                        string translateResult = await (BotInfo.TranslateEngineType == TranslateEngine.Google ?  GoogleTranslateHelper.TranslateToChinese(text) : YouDaoTranslateHelper.TranslateToChinese(text));
                        SendMessage?.Invoke(new [] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(translateResult) }, false);
                    }
                    catch (Exception ex)
                    {
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("翻译失败，" + ex.Message) }, false);
                    }
                }
            }
            if (regexTranslateTo.IsMatch(firstMessage))
            {
                if (BotInfo.TranslateEngineType == TranslateEngine.Google)
                {
                    foreach (Match match in regexTranslateTo.Matches(firstMessage))
                    {
                        if (match.Groups.Count > 1)
                        {
                            try
                            {
                                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(await GoogleTranslateHelper.TranslateTo(firstMessage.Substring(match.Value.Length), match.Groups[1].Value)) }, false);
                            }
                            catch (Exception ex)
                            {
                                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("翻译失败，" + ex.Message) }, false);
                            }
                        }
                    }
                }
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
                                SendPicture(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)));
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
                                SendPicture(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18);
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
                    SendPicture(sender, pictureSource, BotInfo.BeautyPictureEndCmd, false);
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
                    await SendPixivOriginPictureWithIdAndP(strId, SendImage, UploadPicture, msg => SendMessage?.Invoke(msg, false));
                    return;
                }
            }
            #endregion -- 下载Pixiv原图 --

            #region -- 帮助 --
            if (regexHelp.IsMatch(firstMessage))
            {
                Match match = regexHelp.Matches(firstMessage).FirstOrDefault();
                if (match.Groups.Count > 0)
                {
                    string strFeatures = firstMessage.Substring(match.Groups[0].Length).ToUpper();
                    string strHelpResult = strFeatures switch
                    {
                        "--搜图" => pictureSearchHelp(),
                        "--下载原图" => downloadOriginPictureHelp(),
                        "--翻译" => translateHelp(),
                        "--GHS" => hPictureHelp(),
                        "--色图" => hPictureHelp(),
                        "--美图" => beauthPictureHelp(),
                        "--复读" => repeatHelp(),
                        "--伪造消息" => forgeMessageHelp(),
                        "--RSS订阅转发" => rssHelp(),
                        "--查手机号" => phoneHelp(),
                        _ => defaultHelp(),
                    };

                    string defaultHelp()
                    {
                        if (string.IsNullOrEmpty(strFeatures))
                        {
                            List<string> lstEnabledFeatures = new List<string>();
                            if (BotInfo.SearchEnabled)
                                lstEnabledFeatures.Add("搜图");
                            lstEnabledFeatures.Add("下载原图");
                            if (BotInfo.TranslateEnabled)
                                lstEnabledFeatures.Add("翻译");
                            if (BotInfo.HPictureEnabled)
                            {
                                if (BotInfo.EnabledHPictureSource.Contains(PictureSource.Lolicon))
                                    lstEnabledFeatures.Add("GHS");
                                if (BotInfo.EnabledHPictureSource.Contains(PictureSource.ELF))
                                    lstEnabledFeatures.Add("美图");
                            }
                            if (BotInfo.RandomRepeatEnabled || BotInfo.SuccessiveRepeatEnabled)
                                lstEnabledFeatures.Add("复读");
                            if (BotInfo.ForgeMessageEnabled)
                                lstEnabledFeatures.Add("伪造消息");
                            if (BotInfo.RssEnabled)
                                lstEnabledFeatures.Add("RSS订阅转发");
                            if (BotInfo.QQId == 3246934384)
                                lstEnabledFeatures.Add("查手机号");

                            return $"现在您可以让我{string.Join("，", lstEnabledFeatures)}。\r\n输入\"{BotInfo.BotName}帮助--功能\"以获取具体功能的使用帮助。\r\n如果您觉得{BotInfo.BotName}好用，请到{BotInfo.BotName}的项目地址 https://github.com/Alex1911-Jiang/GreenOnions 给{BotInfo.BotName}一颗星星。";
                        }
                        return null;
                    }
                    string pictureSearchHelp()
                    {
                        if (BotInfo.SearchEnabled)
                            return $"发送\"{BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags()}\"启动搜图模式,\r\n" +
                                $"随后直接发图即可, 完事后发送\"{BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags()}\"退出搜图,\r\n" +
                                $"您也可以在一条消息中直接@{BotInfo.BotName}并发送图片来进行单张搜图" + "\r\n如果不明白命令中符号所代表的的意义, 请在搜索引擎搜\"正则表达式\"";
                        else
                            return $"当前{BotInfo.BotName}没有启用搜图功能";
                    }
                    string downloadOriginPictureHelp()
                    {
                        return $"发送\"{BotInfo.BotName}下载Pixiv原图:Pixiv作品ID\"(注意中间有个冒号)\r\n" +
                            $"或直接\"@{BotInfo.BotName} Pixiv作品ID\"(中间没有冒号)来下载原图";
                    }
                    string translateHelp()
                    {
                        if (BotInfo.TranslateEnabled)
                        {
                            if (BotInfo.TranslateEngineType == TranslateEngine.Google)
                            {
                                StringBuilder strTranslateGoogle = new StringBuilder($"发送\"{BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags()}翻译内容\" 以翻译成中文。");
                                strTranslateGoogle.AppendLine($"发送\"{BotInfo.TranslateToCMD.ReplaceGreenOnionsTags()}翻译内容\"翻译成指定语言。");
                                strTranslateGoogle.AppendLine($"目前支持的语言有:{string.Join("\r\n", GoogleTranslateHelper.Languages.Keys)}");
                                strTranslateGoogle.AppendLine("如果不明白命令中符号所代表的的意义, 请在搜索引擎搜\"正则表达式\"");
                                return strTranslateGoogle.ToString();
                            }
                            else
                                return $"发送\"{BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags()}翻译内容\" 以翻译成中文" + "\r\n如果不明白命令中符号所代表的的意义, 请在搜索引擎搜\"正则表达式\"";
                        }
                        else
                            return $"当前{BotInfo.BotName}没有启用翻译功能";
                    }
                    string hPictureHelp()
                    {
                        if (BotInfo.HPictureEnabled && BotInfo.EnabledHPictureSource.Contains(PictureSource.Lolicon))
                        {
                            if (sender is IGroupMemberInfo)  //群消息
                            {
                                IGroupMemberInfo senderGroup = sender as IGroupMemberInfo;
                                if (!BotInfo.HPictureWhiteOnly || (BotInfo.HPictureR18WhiteOnly && BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)))
                                    return hpictureHelpMsg();
                                else
                                    return $"没有为当前群组启用色图功能";
                            }
                            else
                               return hpictureHelpMsg();
                            string hpictureHelpMsg()
                            {
                                StringBuilder strHPicture = new StringBuilder($"发送\"{BotInfo.HPictureCmd.ReplaceGreenOnionsTags()}\"来索要色图。");
                                strHPicture.AppendLine( $"需要注意的是, 关键词中, 如果仅输入一个关键词, 则按模糊匹配查询, 如果用|或&连接多个关键词, 则按标签精确匹配(|代表或, &代表与)");
                                if (BotInfo.HPictureUserCmd.Count() > 0)
                                    strHPicture.AppendLine($"或直接输入\"{string.Join("\",\"", BotInfo.HPictureUserCmd)}\"中的一个来索要一张随机色图。");
                                strHPicture.AppendLine("如果不明白命令中符号所代表的的意义, 请在搜索引擎搜\"正则表达式\"");
                                return strHPicture.ToString();
                            }
                        }
                        else
                            return $"当前{BotInfo.BotName}没有启用色图功能";
                    }
                    string beauthPictureHelp()
                    {
                        if (BotInfo.HPictureEnabled && BotInfo.EnabledHPictureSource.Contains(PictureSource.ELF))
                            return $"发送\"{BotInfo.BeautyPictureCmd.ReplaceGreenOnionsTags()}\"来索要美图" + "\r\n如果不明白命令中符号所代表的的意义, 请在搜索引擎搜\"正则表达式\"";
                        else
                            return $"当前{BotInfo.BotName}没有启用美图功能";
                    }
                    string repeatHelp()
                    {
                        StringBuilder strRepeat = new StringBuilder();
                        if (!BotInfo.RandomRepeatEnabled && !BotInfo.SuccessiveRepeatEnabled)
                           return $"当前{BotInfo.BotName}没有启用复读功能";
                        if (BotInfo.RandomRepeatEnabled)
                            strRepeat.AppendLine($"随机复读:当前有{BotInfo.RandomRepeatProbability}%的概率随机复读消息");
                        if (BotInfo.SuccessiveRepeatEnabled)
                            strRepeat.AppendLine($"连续复读:当相同消息连续出现{BotInfo.SuccessiveRepeatCount}次时自动复读");
                        if (BotInfo.HorizontalMirrorImageEnabled && BotInfo.HorizontalMirrorImageProbability > 0)
                            strRepeat.AppendLine($"有{BotInfo.HorizontalMirrorImageProbability}%几率水平镜像图片");
                        if (BotInfo.VerticalMirrorImageEnabled && BotInfo.VerticalMirrorImageProbability > 0)
                            strRepeat.AppendLine($"有{BotInfo.VerticalMirrorImageProbability}%几率垂直镜像图片");
                        if (BotInfo.RewindGifEnabled && BotInfo.RewindGifProbability > 0)
                            strRepeat.AppendLine($"有{BotInfo.RewindGifProbability}%几率倒放Gif");
                        return strRepeat.ToString();
                    }
                    string forgeMessageHelp()
                    {
                        if (BotInfo.ForgeMessageEnabled)
                            return $"发送\"{BotInfo.ForgeMessageCmdBegin.ReplaceGreenOnionsTags()}@被害者 伪造消息内容\" 以伪造消息, 在消息之间添加\"{BotInfo.ForgeMessageCmdNewLine.ReplaceGreenOnionsTags()}\"将消息拆分为两句" + "\r\n如果不明白命令中符号所代表的的意义, 请在搜索引擎搜\"正则表达式\"";
                        else
                            return $"当前{BotInfo.BotName}没有启用伪造消息功能";
                    }
                    string rssHelp()
                    {
                        return $"RSS订阅转发功能暂无命令且仅可通过管理端进行配置, {BotInfo.BotName}将抓取到的订阅源(如B站动态, 推文, Pixiv日榜)发送给指定的群组或好友。";
                    }
                    string phoneHelp()
                    {
                        return $"发送 \"{BotInfo.BotName}查询手机号:QQ号码\" 可以查询腾讯数据库泄露的对应QQ号的手机号";
                    }

                    if (!string.IsNullOrEmpty(strHelpResult))
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(strHelpResult) }, false);
                }
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
            };
            #endregion -- 自动翻译 --

            //色图
            void SendPicture(IBaseInfo sender, PictureSource pictureSource, string pictureEndCmd, bool allowR18)
            {
                HPictureHandler.SendHPictures(firstMessage, pictureSource, allowR18, pictureEndCmd, UploadPicture, SendMessage, limitType =>
                {
                    if (limitType == LimitType.Frequency)  //如果本次记录是计次, 说明地址消息已经成功发出, 可以记录CD
                    {
                        if (sender is IGroupMemberInfo)  //记录CD
                        {
                            IGroupMemberInfo senderGroup = sender as IGroupMemberInfo;
                            Cache.RecordGroupCD(senderGroup.Id, senderGroup.Group.Id);
                        }
                        else
                            Cache.RecordFriendCD(sender.Id);
                        if (BotInfo.HPictureLimitType == LimitType.Frequency)  //如果设置是计次
                            Cache.RecordLimit(sender.Id);
                    }
                    else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)  //如果本次记录是记张且设置是记张
                        Cache.RecordLimit(sender.Id);
                });
            }
        }

        public static async Task SendPixivOriginPictureWithIdAndP(string strId, Func<string[], Task<string[]>> SendImage, Func<Stream, Task<IImageMessage>> UploadPicture, Action<IChatMessage[]> SendMessage)
        {
            string[] idWithIndex = strId.Split("-");
            if (idWithIndex.Length == 2)
            {
                if (int.TryParse(idWithIndex[1], out int index) && long.TryParse(idWithIndex[0], out long id))
                {
                    await SearchPictureHandler.DownloadPixivOriginPicture(SendImage, UploadPicture, SendMessage, id, index - 1);
                }
                return;
            }
            string[] idWithP = strId.ToLower().Split("p");
            if (idWithP.Length == 2)
            {
                if (int.TryParse(idWithP[1], out int p) && long.TryParse(idWithP[0], out long id))
                {
                    await SearchPictureHandler.DownloadPixivOriginPicture(SendImage, UploadPicture, SendMessage, id, p);
                }
                return;
            }
            if (long.TryParse(strId, out long idNoneP))
            {
                await SearchPictureHandler.DownloadPixivOriginPicture(SendImage, UploadPicture, SendMessage, idNoneP, -1);
                return;
            }
        }
    }
}
