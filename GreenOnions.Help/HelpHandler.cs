using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GreenOnions.Interface;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Interface.Helpers;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.Help
{
    public static class HelpHandler
    {
        public static GreenOnionsMessages Helps(Regex regexHelp, string msg, long? groupId, List<IPlugin> plugins)
        {
            Match match = regexHelp.Matches(msg).FirstOrDefault();
            if (match?.Groups.Count > 0)
            {
                string strFeatures = msg.Substring(match.Groups[0].Length).Trim();
                GreenOnionsBaseMessage[] strHelpResult = strFeatures switch
                {
                    "--搜图" => PictureSearchHelp(),
                    "--下载原图" => downloadOriginalPictureHelp(),
                    "--翻译" => TranslateHelp(),
                    "--GHS" or "--色图" or "--美图" => HPictureHelp(groupId),
                    "--复读" => RepeatHelp(),
                    "--伪造消息" => ForgeMessageHelp(),
                    "--RSS订阅转发" => RssHelp(),
                    "--功能" => HelpFailCMD(plugins),
                    null or "" => DefaultHelp(),
                    _ => null,
                };
                foreach (IPlugin plugin in plugins)
                {
                    if (strFeatures.Equals("--" + plugin.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        if (BotInfo.PluginStatus[plugin.Name])
                        {
                            GreenOnionsMessages helpMsg = plugin.HelpMessage;
                            if (helpMsg is null || helpMsg.Count == 0)
                                helpMsg = $"功能<{plugin.Name}>没有帮助信息。";
                            return helpMsg;
                        }
                        else
                        {
                            return $"功能<{plugin.Name}>没有启用。";
                        }
                    }
                }
                GreenOnionsBaseMessage[] DefaultHelp()
                {
                    if (string.IsNullOrEmpty(strFeatures))
                        return new[] { $"现在您可以让我 {string.Join("，", GetEnabledFunction(plugins))}。\r\n输入\"{BotInfo.Config.BotName}帮助--<功能>\"以获取具体功能的使用帮助。(不含尖括号)\r\n如果您觉得{BotInfo.Config.BotName}好用，请到{BotInfo.Config.BotName}的项目地址 https://github.com/Alex1911-Jiang/GreenOnions 给{BotInfo.Config.BotName}一颗星星。" }.ToTextMessageArray();
                    return null;
                }
                return strHelpResult;
            }
            return null;
        }

        private static List<string> GetEnabledFunction(List<IPlugin> plugins)
        {
            List<string> lstEnabledFeatures = new List<string>();
            if (BotInfo.Config.SearchEnabled)
                lstEnabledFeatures.Add("搜图");
            if (BotInfo.Config.OriginalPictureEnabled)
                lstEnabledFeatures.Add("下载原图");
            if (BotInfo.Config.TranslateEnabled)
                lstEnabledFeatures.Add("翻译");
            if (BotInfo.Config.HPictureEnabled)
            {
                if (BotInfo.Config.EnabledHPictureSource.Contains(PictureSource.Lolicon))
                    lstEnabledFeatures.Add("GHS");
                if (BotInfo.Config.EnabledHPictureSource.Contains(PictureSource.ELF))
                    lstEnabledFeatures.Add("美图");
            }
            if (BotInfo.Config.RandomRepeatEnabled || BotInfo.Config.SuccessiveRepeatEnabled)
                lstEnabledFeatures.Add("复读");
            if (BotInfo.Config.ForgeMessageEnabled)
                lstEnabledFeatures.Add("伪造消息");
            if (BotInfo.Config.RssEnabled)
                lstEnabledFeatures.Add("RSS订阅转发");

            foreach (IPlugin plugin in plugins)
            {
                if (BotInfo.PluginStatus[plugin.Name] && plugin.DisplayedInTheHelp)
                    lstEnabledFeatures.Add(plugin.Name);
            }

            return lstEnabledFeatures;
        }

        private static GreenOnionsBaseMessage[] PictureSearchHelp()
        {
            if (BotInfo.Config.SearchEnabled)
                return new[] { $"发送\"{BotInfo.Config.SearchModeOnCmd}\"启动搜图模式，\r\n" +
                            $"随后直接发图即可，完事后发送\"{BotInfo.Config.SearchModeOffCmd}\"退出搜图，\r\n" +
                            $"您也可以在一条消息中直接@{BotInfo.Config.BotName}并发送图片来进行单张搜图" + "\r\n如果不明白命令中符号所代表的的意义，请在搜索引擎搜\"正则表达式\""}.ToTextMessageArray();
            else
                return new[] { $"当前{BotInfo.Config.BotName}没有启用搜图功能" }.ToTextMessageArray();
        }
        private static GreenOnionsBaseMessage[] downloadOriginalPictureHelp()
        {
            return new[] { $"发送\"{BotInfo.Config.BotName}下载Pixiv原图:Pixiv作品ID\"(注意中间有个冒号)\r\n" +
                        $"或直接\"@{BotInfo.Config.BotName} Pixiv作品ID\"(中间没有冒号)来下载原图\r\n" +
                        $"当作品页存在不止一个作品时可在作品号后面加 p数字 来取第几张图，例如：10000p0"}.ToTextMessageArray();
        }
        private static GreenOnionsBaseMessage[] TranslateHelp()
        {
            if (BotInfo.Config.TranslateEnabled)
            {
                //if (BotInfo.Config.TranslateEngineType == TranslateEngine.Google)
                //{
                //    StringBuilder strTranslateGoogle = new StringBuilder($"发送\"{BotInfo.Config.TranslateToChineseCMD}翻译内容\" 以翻译成中文。");
                //    strTranslateGoogle.AppendLine($"发送\"{BotInfo.Config.TranslateToCMD}翻译内容\"自动识别当前语言并翻译成指定语言。");
                //    strTranslateGoogle.AppendLine($"发送\"{BotInfo.Config.TranslateFromToCMD}翻译内容\"从指定语言翻译成指定语言。");
                //    strTranslateGoogle.AppendLine($"目前支持的语言有:\r\n{string.Join("\r\n", Constants.GoogleLanguages.Keys)}");
                //    strTranslateGoogle.AppendLine("目前接入的翻译引擎为:谷歌翻译");
                //    return new[] { strTranslateGoogle.ToString() }.ToTextMessageArray();
                //}
                if (BotInfo.Config.TranslateEngineType == TranslateEngine.YouDao)
                {
                    StringBuilder strTranslateYouDao = new StringBuilder($"发送\"{BotInfo.Config.TranslateToChineseCMD}翻译内容\" 以翻译成中文。");
                    strTranslateYouDao.AppendLine($"发送\"{BotInfo.Config.TranslateFromToCMD}翻译内容\"从指定语言翻译成指定语言。");
                    strTranslateYouDao.AppendLine($"目前支持的语言有:\r\n{string.Join("\r\n", Constants.YouDaoWebLanguages.Keys)}");
                    strTranslateYouDao.AppendLine("目前接入的翻译引擎为:有道网页翻译");
                    return new[] { strTranslateYouDao.ToString() }.ToTextMessageArray();
                }
                else if (BotInfo.Config.TranslateEngineType == TranslateEngine.YouDaoApi)
                {
                    StringBuilder strTranslateYouDaoApi = new StringBuilder($"发送\"{BotInfo.Config.TranslateToChineseCMD}翻译内容\" 以翻译成中文。");
                    strTranslateYouDaoApi.AppendLine($"发送\"{BotInfo.Config.TranslateToCMD}翻译内容\"自动识别当前语言并翻译成指定语言。");
                    strTranslateYouDaoApi.AppendLine($"发送\"{BotInfo.Config.TranslateFromToCMD}翻译内容\"从指定语言翻译成指定语言。");
                    strTranslateYouDaoApi.AppendLine($"目前支持的语言有:\r\n{string.Join("\r\n", Constants.YouDaoLanguages.Keys)}");
                    strTranslateYouDaoApi.AppendLine("目前接入的翻译引擎为:有道智云");
                    return new[] { strTranslateYouDaoApi.ToString() }.ToTextMessageArray();
                }
                else if (BotInfo.Config.TranslateEngineType == TranslateEngine.BaiduApi)
                {
                    StringBuilder strTranslateBaiduApi = new StringBuilder($"发送\"{BotInfo.Config.TranslateToChineseCMD}翻译内容\" 以翻译成中文。");
                    strTranslateBaiduApi.AppendLine($"发送\"{BotInfo.Config.TranslateToCMD}翻译内容\"自动识别当前语言并翻译成指定语言。");
                    strTranslateBaiduApi.AppendLine($"发送\"{BotInfo.Config.TranslateFromToCMD}翻译内容\"从指定语言翻译成指定语言。");
                    strTranslateBaiduApi.AppendLine($"目前支持的语言有:\r\n{string.Join("\r\n", Constants.BaiduLanguages.Keys)}");
                    strTranslateBaiduApi.AppendLine("目前接入的翻译引擎为:百度翻译");
                    return new[] { strTranslateBaiduApi.ToString() }.ToTextMessageArray();
                }
                return new[] { "没有指定翻译引擎或翻译引擎不可用，请联系机器人管理员" }.ToTextMessageArray();
            }
            else
                return new[] { $"当前{BotInfo.Config.BotName}没有启用翻译功能" }.ToTextMessageArray();
        }
        private static GreenOnionsBaseMessage[] HPictureHelp(long? groupId)
        {
            if (BotInfo.Config.HPictureEnabled && BotInfo.Config.EnabledHPictureSource.Contains(PictureSource.Lolicon))
            {
                if (groupId is not null)  //群消息
                {
                    if (!BotInfo.Config.HPictureWhiteOnly || (BotInfo.Config.HPictureR18WhiteOnly && BotInfo.Config.HPictureWhiteGroup.Contains(groupId.Value)))
                        return new[] { HpictureHelpMsg() }.ToTextMessageArray();
                    else
                        return new[] { $"没有为当前群组启用色图功能" }.ToTextMessageArray();
                }
                else
                    return new[] { HpictureHelpMsg() }.ToTextMessageArray();

                string HpictureHelpMsg()
                {
                    StringBuilder strHPicture = new StringBuilder($"发送\"{BotInfo.Config.HPictureCmd}\"来索要色图/美图。");
                    strHPicture.AppendLine($"需要注意的是，色图关键词中，如果仅输入一个关键词，则按模糊匹配查询，如果用|或&连接多个关键词，则按标签精确匹配 |代表或，&代表与(美图仅支持一个关键词)");
                    if (BotInfo.Config.HPictureUserCmd.Count() > 0)
                        strHPicture.AppendLine($"或直接输入\"{string.Join("\",\"", BotInfo.Config.HPictureUserCmd)}\"中的一个来索要一张随机色图。");
                    strHPicture.AppendLine("如果不明白命令中符号所代表的的意义，请在搜索引擎搜\"正则表达式\"");
                    return strHPicture.ToString();
                }
            }
            else
                return new[] { $"当前{BotInfo.Config.BotName}没有启用色图功能" }.ToTextMessageArray();
        }
        private static GreenOnionsBaseMessage[] RepeatHelp()
        {
            StringBuilder strRepeat = new StringBuilder();
            if (!BotInfo.Config.RandomRepeatEnabled && !BotInfo.Config.SuccessiveRepeatEnabled)
                return new[] { $"当前{BotInfo.Config.BotName}没有启用复读功能" }.ToTextMessageArray();
            if (BotInfo.Config.RandomRepeatEnabled)
                strRepeat.AppendLine($"随机复读:当前有{BotInfo.Config.RandomRepeatProbability}%的概率随机复读消息");
            if (BotInfo.Config.SuccessiveRepeatEnabled)
                strRepeat.AppendLine($"连续复读:当相同消息连续出现{BotInfo.Config.SuccessiveRepeatCount}次时自动复读");
            if (BotInfo.Config.HorizontalMirrorImageEnabled && BotInfo.Config.HorizontalMirrorImageProbability > 0)
                strRepeat.AppendLine($"有{BotInfo.Config.HorizontalMirrorImageProbability}%几率水平镜像图片");
            if (BotInfo.Config.VerticalMirrorImageEnabled && BotInfo.Config.VerticalMirrorImageProbability > 0)
                strRepeat.AppendLine($"有{BotInfo.Config.VerticalMirrorImageProbability}%几率垂直镜像图片");
            if (BotInfo.Config.RewindGifEnabled && BotInfo.Config.RewindGifProbability > 0)
                strRepeat.AppendLine($"有{BotInfo.Config.RewindGifProbability}%几率倒放Gif");
            return new[] { strRepeat.ToString() }.ToTextMessageArray();
        }
        private static GreenOnionsBaseMessage[] ForgeMessageHelp()
        {
            if (BotInfo.Config.ForgeMessageEnabled)
                return new[] { $"发送\"{BotInfo.Config.ForgeMessageCmdBegin}@被害者 伪造消息内容\" 以伪造消息，在消息之间添加\"{BotInfo.Config.ForgeMessageCmdNewLine}\"将消息拆分为两句" + "\r\n如果不明白命令中符号所代表的的意义，请在搜索引擎搜\"正则表达式\"" }.ToTextMessageArray();
            else
                return new[] { $"当前{BotInfo.Config.BotName}没有启用伪造消息功能" }.ToTextMessageArray();
        }
        private static GreenOnionsBaseMessage[] RssHelp()
        {
            return new[] { $"RSS订阅转发功能暂无命令且仅可通过管理端进行配置，{BotInfo.Config.BotName}将抓取到的订阅源(如B站动态，推文，Pixiv日榜)发送给指定的群组或好友。" }.ToTextMessageArray();
        }
        private static GreenOnionsBaseMessage[] HelpFailCMD(List<IPlugin> plugins)
        {
            StringBuilder strFail = new StringBuilder($"您需要将\"功能\"替换为功能名称，例如：\"{BotInfo.Config.BotName}帮助 --搜图\" 以获取搜图功能的帮助。\r\n目前启用的功能有： {string.Join("，", GetEnabledFunction(plugins))}。");
            return new GreenOnionsBaseMessage[] { strFail };
        }

    }
}
