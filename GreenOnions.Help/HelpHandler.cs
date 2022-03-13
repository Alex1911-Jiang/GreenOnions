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
using PlainMessage = Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage;

namespace GreenOnions.Help
{
    public static class HelpHandler
    {
        public static async void Helps(Regex regexHelp, IBaseInfo sender, string msg, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            Match match = regexHelp.Matches(msg).FirstOrDefault();
            if (match?.Groups.Count > 0)
            {
                string strFeatures = msg.Substring(match.Groups[0].Length).ToUpper();
                IChatMessage[] strHelpResult = strFeatures switch
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
                    "--井字棋" => await helpTicTacToe(),
                    "--查手机号" => phoneHelp(),
                    "--功能" => helpFailCMD(),
                    _ => defaultHelp(),
                };

                List<string> getEnabledFunction()
                {
                    List<string> lstEnabledFeatures = new List<string>();
                    if (BotInfo.SearchEnabled)
                        lstEnabledFeatures.Add("搜图");
                    if (BotInfo.OriginPictureEnabled)
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
                    if (BotInfo.TicTacToeEnabled)
                        lstEnabledFeatures.Add("井字棋");
                    return lstEnabledFeatures;
                }

                IChatMessage[] defaultHelp()
                {
                    if (string.IsNullOrEmpty(strFeatures))
                    {
                        return new[] { new PlainMessage($"现在您可以让我 {string.Join("，", getEnabledFunction())}。\r\n输入\"{BotInfo.BotName}帮助--功能\"以获取具体功能的使用帮助。\r\n如果您觉得{BotInfo.BotName}好用，请到{BotInfo.BotName}的项目地址 https://github.com/Alex1911-Jiang/GreenOnions 给{BotInfo.BotName}一颗星星。") };
                    }
                    return null;
                }
                IChatMessage[] pictureSearchHelp()
                {
                    if (BotInfo.SearchEnabled)
                        return new[] { new PlainMessage($"发送\"{BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags()}\"启动搜图模式，\r\n" +
                            $"随后直接发图即可，完事后发送\"{BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags()}\"退出搜图，\r\n" +
                            $"您也可以在一条消息中直接@{BotInfo.BotName}并发送图片来进行单张搜图" + "\r\n如果不明白命令中符号所代表的的意义，请在搜索引擎搜\"正则表达式\"") };
                    else
                        return new[] { new PlainMessage($"当前{BotInfo.BotName}没有启用搜图功能") };
                }
                IChatMessage[] downloadOriginPictureHelp()
                {
                    return new[] { new PlainMessage($"发送\"{BotInfo.BotName}下载Pixiv原图:Pixiv作品ID\"(注意中间有个冒号)\r\n" +
                        $"或直接\"@{BotInfo.BotName} Pixiv作品ID\"(中间没有冒号)来下载原图\r\n" +
                        $"当作品页存在不止一个作品时可在作品号后面加 p数字 来取第几张图，例如：10000p0") };
                }
                IChatMessage[] translateHelp()
                {
                    if (BotInfo.TranslateEnabled)
                    {
                        if (BotInfo.TranslateEngineType == TranslateEngine.Google)
                        {
                            StringBuilder strTranslateGoogle = new StringBuilder($"发送\"{BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags()}翻译内容\" 以翻译成中文。");
                            strTranslateGoogle.AppendLine($"发送\"{BotInfo.TranslateToCMD.ReplaceGreenOnionsTags()}翻译内容\"自动识别当前语言并翻译成指定语言。");
                            strTranslateGoogle.AppendLine($"发送\"{BotInfo.TranslateFromToCMD.ReplaceGreenOnionsTags()}翻译内容\"从指定语言翻译成指定语言。");
                            strTranslateGoogle.AppendLine($"目前支持的语言有:{string.Join("\r\n", GoogleTranslateHelper.Languages.Keys)}");
                            strTranslateGoogle.AppendLine("目前接入的翻译引擎为:谷歌翻译");
                            return new[] { new PlainMessage(strTranslateGoogle.ToString()) };
                        }
                        else
                        {
                            StringBuilder strTranslateYouDao = new StringBuilder("发送\"{BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags()}翻译内容\" 以翻译成中文。");
                            strTranslateYouDao.AppendLine($"发送\"{BotInfo.TranslateFromToCMD.ReplaceGreenOnionsTags()}翻译内容\"从指定语言翻译成指定语言。");
                            strTranslateYouDao.AppendLine($"目前支持的语言有:{string.Join("\r\n", YouDaoTranslateHelper.Languages.Keys)}");
                            strTranslateYouDao.AppendLine("目前接入的翻译引擎为:有道翻译");
                            return new[] { new PlainMessage(strTranslateYouDao.ToString()) };
                        }
                    }
                    else
                        return new[] { new PlainMessage($"当前{BotInfo.BotName}没有启用翻译功能") };
                }
                IChatMessage[] hPictureHelp()
                {
                    if (BotInfo.HPictureEnabled && BotInfo.EnabledHPictureSource.Contains(PictureSource.Lolicon))
                    {
                        if (sender is IGroupMemberInfo)  //群消息
                        {
                            IGroupMemberInfo senderGroup = sender as IGroupMemberInfo;
                            if (!BotInfo.HPictureWhiteOnly || (BotInfo.HPictureR18WhiteOnly && BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)))
                                return new[] { new PlainMessage(hpictureHelpMsg()) };
                            else
                                return new[] { new PlainMessage($"没有为当前群组启用色图功能") };
                        }
                        else
                            return new[] { new PlainMessage(hpictureHelpMsg()) };
                        string hpictureHelpMsg()
                        {
                            StringBuilder strHPicture = new StringBuilder($"发送\"{BotInfo.HPictureCmd.ReplaceGreenOnionsTags()}\"来索要色图。");
                            strHPicture.AppendLine($"需要注意的是，关键词中，如果仅输入一个关键词，则按模糊匹配查询，如果用|或&连接多个关键词，则按标签精确匹配(|代表或，&代表与)");
                            if (BotInfo.HPictureUserCmd.Count() > 0)
                                strHPicture.AppendLine($"或直接输入\"{string.Join("\",\"", BotInfo.HPictureUserCmd)}\"中的一个来索要一张随机色图。");
                            strHPicture.AppendLine("如果不明白命令中符号所代表的的意义，请在搜索引擎搜\"正则表达式\"");
                            return strHPicture.ToString();
                        }
                    }
                    else
                        return new[] { new PlainMessage($"当前{BotInfo.BotName}没有启用色图功能") };
                }
                IChatMessage[] beauthPictureHelp()
                {
                    if (BotInfo.HPictureEnabled && BotInfo.EnabledHPictureSource.Contains(PictureSource.ELF))
                        return new[] { new PlainMessage($"发送\"{BotInfo.BeautyPictureCmd.ReplaceGreenOnionsTags()}\"来索要美图 \r\n如果不明白命令中符号所代表的的意义，请在搜索引擎搜\"正则表达式\"") };
                    else
                        return new[] { new PlainMessage($"当前{BotInfo.BotName}没有启用美图功能") };
                }
                IChatMessage[] repeatHelp()
                {
                    StringBuilder strRepeat = new StringBuilder();
                    if (!BotInfo.RandomRepeatEnabled && !BotInfo.SuccessiveRepeatEnabled)
                        return new[] { new PlainMessage($"当前{BotInfo.BotName}没有启用复读功能") };
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
                    return new[] { new PlainMessage(strRepeat.ToString()) };
                }
                IChatMessage[] forgeMessageHelp()
                {
                    if (BotInfo.ForgeMessageEnabled)
                        return new[] { new PlainMessage($"发送\"{BotInfo.ForgeMessageCmdBegin.ReplaceGreenOnionsTags()}@被害者 伪造消息内容\" 以伪造消息，在消息之间添加\"{BotInfo.ForgeMessageCmdNewLine.ReplaceGreenOnionsTags()}\"将消息拆分为两句" + "\r\n如果不明白命令中符号所代表的的意义，请在搜索引擎搜\"正则表达式\"") };
                    else
                        return new[] { new PlainMessage($"当前{BotInfo.BotName}没有启用伪造消息功能") };
                }
                IChatMessage[] rssHelp()
                {
                    return new[] { new PlainMessage($"RSS订阅转发功能暂无命令且仅可通过管理端进行配置，{BotInfo.BotName}将抓取到的订阅源(如B站动态，推文，Pixiv日榜)发送给指定的群组或好友。") };
                }
                IChatMessage[] phoneHelp()
                {
                    return new[] { new PlainMessage($"发送 \"{BotInfo.BotName}查询手机号:QQ号码\" 可以查询腾讯数据库泄露的对应QQ号的手机号") };
                }
                IChatMessage[] helpFailCMD()
                {
                    StringBuilder strFail = new StringBuilder($"您需要将\"功能\"替换为功能名称，例如：\"{BotInfo.BotName}帮助--搜图\" 以获取搜图功能的帮助。\r\n目前启用的功能有： {string.Join("，", getEnabledFunction())}。");
                    if (BotInfo.QQId == 3246934384)
                        strFail.AppendLine($"您也可以私聊{BotInfo.BotName}留言，主人看到的时候会进行回复（可能）。");
                    return new[] { new PlainMessage(strFail.ToString()) };
                }
                async Task<IChatMessage[]> helpTicTacToe()
                {
                    if (BotInfo.TicTacToeEnabled)
                    {
                        if (!Directory.Exists("Icon"))
                            Directory.CreateDirectory("Icon");

                        List<IChatMessage> chatMessages = new List<IChatMessage>();

                        chatMessages.Add(new PlainMessage($"发送\"{BotInfo.StartTicTacToeCmd.ReplaceGreenOnionsTags()}\"来开启一局井字棋游戏。\r\n"));
                        chatMessages.Add(new PlainMessage($"{BotInfo.BotName}会发送一个空棋盘图片，\r\n"));

                        if ((BotInfo.TicTacToeMoveMode & (int)TicTacToeMoveMode.OpenCV) != 0)
                        {
                            chatMessages.Add(new PlainMessage("您可以对棋盘进行表情涂鸦来进行下子。\r\n"));
                            chatMessages.Add(new PlainMessage("手机端操作方式：\r\n"));

                            string mobieGraffitiFile = Path.Combine("Icon", "MobieGraffiti");
                            Resource.MobieGraffiti.Save(mobieGraffitiFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                            using (FileStream fsMobieGraffiti = new FileStream(mobieGraffitiFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                chatMessages.Add(await UploadPicture(fsMobieGraffiti));
                            }

                            chatMessages.Add(new PlainMessage("电脑端操作方式：\r\n"));

                            string pcGraffitiFile = Path.Combine("Icon", "PcGraffiti");
                            Resource.PcGraffiti.Save(pcGraffitiFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                            using (FileStream fsMobieGraffiti = new FileStream(pcGraffitiFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                chatMessages.Add(await UploadPicture(fsMobieGraffiti));
                            }
                        }
                        if (BotInfo.TicTacToeMoveMode == (int)(TicTacToeMoveMode.OpenCV | TicTacToeMoveMode.Nomenclature))
                        {
                            chatMessages.Add(new PlainMessage("另外，"));
                        }
                        if ((BotInfo.TicTacToeMoveMode & (int)TicTacToeMoveMode.Nomenclature) != 0)
                        {
                            chatMessages.Add(new PlainMessage("您可以通过输入格号来下子，如\"C2\"。\r\n"));
                            chatMessages.Add(new PlainMessage("棋盘编号命名示例为：\r\n"));

                            string chessboardFile = Path.Combine("Icon", "Chessboard");
                            Resource.Chessboard.Save(chessboardFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                            using (FileStream fsMobieGraffiti = new FileStream(chessboardFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                chatMessages.Add(await UploadPicture(fsMobieGraffiti));
                            }
                        }
                        return chatMessages.ToArray();
                    }
                    else
                    {
                        return new[] { new PlainMessage($"当前{BotInfo.BotName}没有启用井字棋功能") };
                    }
                }
                SendMessage?.Invoke(strHelpResult, true);
            }
        }
    }
}
