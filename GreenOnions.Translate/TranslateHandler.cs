using GreenOnions.Utility;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GreenOnions.Translate
{
    public static class TranslateHandler
    {
        public async static void TranslateToChinese(Regex regexTranslateToChinese, string msg, Action<IChatMessage[], bool> SendMessage)
        {
            try
            {
                string text = msg.Substring(regexTranslateToChinese.Matches(msg).First().Value.Length);
                string translateResult = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateToChinese(text) : YouDaoTranslateHelper.TranslateToChinese(text));
                SendMessage?.Invoke(new[] { new PlainMessage(translateResult) }, false);
            }
            catch (Exception ex)
            {
                SendMessage?.Invoke(new[] { new PlainMessage("翻译失败，" + ex.Message) }, false);
            }
        }

        public async static void TranslateTo(Regex regexTranslateTo, string msg, Action<IChatMessage[], bool> SendMessage)
        {
            Match match = regexTranslateTo.Matches(msg).First();
            if (match.Groups.Count > 1)
            {
                try
                {
                    SendMessage?.Invoke(new[] { new PlainMessage(await GoogleTranslateHelper.TranslateTo(msg.Substring(match.Value.Length), match.Groups[1].Value)) }, false);
                }
                catch (Exception ex)
                {
                    SendMessage?.Invoke(new[] { new PlainMessage("翻译失败，" + ex.Message) }, false);
                }
            }
        }

        public async static void TranslateFromTo(Regex regexTranslateFromTo, string msg, Action<IChatMessage[], bool> SendMessage)
        {
            Match match = regexTranslateFromTo.Matches(msg).First();
            if (match.Groups.Count > 1)
            {
                try
                {
                    string translateResult = "";
                    string text = msg.Substring(match.Value.Length);
                    if (match.Groups.ContainsKey("from") && match.Groups.ContainsKey("to"))
                    {
                        string from = match.Groups["from"].Value;
                        string to = match.Groups["to"].Value;
                        translateResult = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateFromTo(text, from, to) : YouDaoTranslateHelper.TranslateFromTo(text, from, to));
                    }
                    SendMessage?.Invoke(new[] { new PlainMessage(translateResult) }, false);
                }
                catch (Exception ex)
                {
                    SendMessage?.Invoke(new[] { new PlainMessage("翻译失败，" + ex.Message) }, false);
                }
            }
        }
    }
}
