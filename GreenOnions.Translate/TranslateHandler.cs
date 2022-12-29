using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Utility;

namespace GreenOnions.Translate
{
    public static class TranslateHandler
    {
        public async static Task<string> TranslateToChinese(string text)
        {
            return BotInfo.Config.TranslateEngineType switch
            {
                TranslateEngine.YouDao => await YouDaoTranslateHelper.TranslateToChinese(text),
                TranslateEngine.YouDaoApi => await YouDaoTranslateApiHelper.TranslateToChinese(text),
                TranslateEngine.BaiduApi => await BaiduTranslateApiHelper.TranslateToChinese(text),
                TranslateEngine.TencentApi => await TencentTranslateApiHelper.TranslateToChinese(text),
                _ => throw new NotImplementedException("翻译引擎设置有误，请联系机器人管理员"),
            };
        }

        public static async Task<string> TranslateTo(string text, string toLanguageChineseName)
        {
            toLanguageChineseName = toLanguageChineseName.Replace("语", "文");
            return BotInfo.Config.TranslateEngineType switch
            {
                TranslateEngine.YouDao => await YouDaoTranslateHelper.TranslateTo(text, toLanguageChineseName),
                TranslateEngine.YouDaoApi => await YouDaoTranslateApiHelper.TranslateTo(text, toLanguageChineseName),
                TranslateEngine.BaiduApi => await BaiduTranslateApiHelper.TranslateTo(text, toLanguageChineseName),
                TranslateEngine.TencentApi => await TencentTranslateApiHelper.TranslateTo(text, toLanguageChineseName),
                _ => throw new NotImplementedException("翻译引擎设置有误，请联系机器人管理员"),
            };
        }

        public async static Task<string> TranslateFromTo(string text, string fromLanguageChineseName, string toLanguageChineseName)
        {
            fromLanguageChineseName = fromLanguageChineseName.Replace("语", "文");
            toLanguageChineseName = toLanguageChineseName.Replace("语", "文");
            return BotInfo.Config.TranslateEngineType switch
            {
                TranslateEngine.YouDao => await YouDaoTranslateHelper.TranslateFromTo(text, fromLanguageChineseName, toLanguageChineseName),
                TranslateEngine.YouDaoApi => await YouDaoTranslateApiHelper.TranslateFromTo(text, fromLanguageChineseName, toLanguageChineseName),
                TranslateEngine.BaiduApi => await BaiduTranslateApiHelper.TranslateFromTo(text, fromLanguageChineseName, toLanguageChineseName),
                TranslateEngine.TencentApi => await TencentTranslateApiHelper.TranslateFromTo(text, fromLanguageChineseName, toLanguageChineseName),
                _ => throw new NotImplementedException("翻译引擎设置有误，请联系机器人管理员"),
            };
        }

        public async static Task<string> TranslateToChinese(Regex regexTranslateToChinese, string msg)
        {
            try
            {
                string text = msg.Substring(regexTranslateToChinese.Matches(msg).First().Value.Length);
                return await TranslateToChinese(text);
            }
            catch (Exception ex)
            {
                return "翻译失败，" + ex.Message;
            }
        }

        public static async Task<string> TranslateTo(Regex regexTranslateTo, string msg)
        {
            Match match = regexTranslateTo.Matches(msg).First();
            if (match.Groups.Count > 1)
            {
                try
                {
                    string text = msg.Substring(match.Value.Length);
                    if (match.Groups["to"].Success)
                    {
                        string toLanguageChineseName = match.Groups["to"].Value;
                        return await TranslateTo(text, toLanguageChineseName);
                    }
                    else
                    {
                        string toLanguageChineseName = match.Groups[1].Value;
                        return await TranslateTo(text, toLanguageChineseName);
                    }
                }
                catch (Exception ex)
                {
                    return "翻译失败，" + ex.Message;
                }
            }
            return "翻译目标语言提取失败，请联系机器人管理员检查命令格式。";
        }

        public async static Task<string> TranslateFromTo(Regex regexTranslateFromTo, string msg)
        {
            Match match = regexTranslateFromTo.Matches(msg).First();
            if (match.Groups.Count > 1)
            {
                try
                {
                    if (match.Groups["from"].Success && match.Groups["to"].Success)
                    {
                        string text = msg.Substring(match.Value.Length);
                        string fromLanguageChineseName = match.Groups["from"].Value;
                        string toLanguageChineseName = match.Groups["to"].Value;
                        return await TranslateFromTo(text, fromLanguageChineseName, toLanguageChineseName);
                    }
                }
                catch (Exception ex)
                {
                    return "翻译失败，" + ex.Message;
                }
            }
            return "翻译目标语言提取失败，请联系机器人管理员检查命令格式。";
        }
    }
}
