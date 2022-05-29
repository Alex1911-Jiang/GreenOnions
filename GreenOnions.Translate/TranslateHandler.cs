using GreenOnions.Model;
using GreenOnions.Utility;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.Translate
{
    public static class TranslateHandler
    {
        public async static void TranslateToChinese(Regex regexTranslateToChinese, string msg, Action<GreenOnionsMessages> SendMessage)
        {
            try
            {
                string text = msg.Substring(regexTranslateToChinese.Matches(msg).First().Value.Length);
                string translateResult = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateToChinese(text) : YouDaoTranslateHelper.TranslateToChinese(text));
                SendMessage(translateResult);
            }
            catch (Exception ex)
            {
                SendMessage("翻译失败，" + ex.Message);
            }
        }

        public async static void TranslateTo(Regex regexTranslateTo, string msg, Action<GreenOnionsMessages> SendMessage)
        {
            Match match = regexTranslateTo.Matches(msg).First();
            if (match.Groups.Count > 1)
            {
                try
                {
                    SendMessage(await GoogleTranslateHelper.TranslateTo(msg.Substring(match.Value.Length), match.Groups[1].Value));
                }
                catch (Exception ex)
                {
                    SendMessage("翻译失败，" + ex.Message);
                }
            }
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
                        translateResult = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateFromTo(text, from, to) : YouDaoTranslateHelper.TranslateFromTo(text, from, to));
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
