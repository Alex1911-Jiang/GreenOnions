using System;
using System.Linq;
using System.Text.RegularExpressions;
using GreenOnions.Interface;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Utility;

namespace GreenOnions.Translate
{
    public static class TranslateHandler
    {
        public async static void TranslateToChinese(Regex regexTranslateToChinese, string msg, Action<GreenOnionsMessages> SendMessage)
        {
            try
            {
                string text = msg.Substring(regexTranslateToChinese.Matches(msg).First().Value.Length);
                string translateResult = await YouDaoTranslateHelper.TranslateToChinese(text);  //BotInfo.Config.TranslateEngineType
                SendMessage(translateResult);
            }
            catch (Exception ex)
            {
                SendMessage("翻译失败，" + ex.Message);
            }
        }

        [Obsolete("谷歌翻译已停用，有道翻译不支持该方式", true)]
        public static void TranslateTo(Regex regexTranslateTo, string msg, Action<GreenOnionsMessages> SendMessage)
        {
            throw new NotImplementedException("谷歌翻译已停用，有道翻译不支持该方式");
            //Match match = regexTranslateTo.Matches(msg).First();
            //if (match.Groups.Count > 1)
            //{
            //    try
            //    {
            //        SendMessage(await GoogleTranslateHelper.TranslateTo(msg.Substring(match.Value.Length), match.Groups[1].Value));
            //    }
            //    catch (Exception ex)
            //    {
            //        SendMessage("翻译失败，" + ex.Message);
            //    }
            //}
        }

        public async static void TranslateFromTo(Regex regexTranslateFromTo, string msg, Action<GreenOnionsMessages> SendMessage)
        {
            Match match = regexTranslateFromTo.Matches(msg).First();
            if (match.Groups.Count > 1)
            {
                try
                {
                    string translateResult = "";
                    string text = msg.Substring(match.Value.Length);
                    if (match.Groups["from"].Success && match.Groups["to"].Success)
                    {
                        string from = match.Groups["from"].Value;
                        string to = match.Groups["to"].Value;
                        translateResult = await YouDaoTranslateHelper.TranslateFromTo(text, from, to);  //BotInfo.Config.TranslateEngineType
                    }
                    SendMessage(translateResult);
                }
                catch (Exception ex)
                {
                    SendMessage("翻译失败，" + ex.Message);
                }
            }
        }
    }
}
