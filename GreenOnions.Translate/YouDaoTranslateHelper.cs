using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.Translate
{
    public static class YouDaoTranslateHelper
    {
        public static readonly Dictionary<string, string> Languages = new Dictionary<string, string>()
        {
            {"中文" , "ZH_CN"},
            {"英文" , "EN"},
            {"日文" , "JA"},
            {"韩文" , "KO"},
            {"法文" , "FR"},
            {"德文" , "DE"},
            {"西班牙文" , "ES"},
            {"葡萄牙文" , "PT"},
            {"意大利文" , "IT"},
            {"越南文" , "VI"},
            {"印尼文" , "ID"},
            {"阿拉伯文" , "AR"},
            {"荷兰文" , "NL"},
            {"泰文" , "TH"},
        };

        public static async Task<string> TranslateToChinese(string text)
        {
            return await Translate(text, "AUTO");
        }

        public static async Task<string> TranslateFromTo(string text, string fromLanguageChineseName, string toLanguageChineseName)
        {
            string fromLanguageName = fromLanguageChineseName.Replace("语", "文");
            if (Languages.ContainsKey(fromLanguageName))
                fromLanguageName = Languages[fromLanguageChineseName];

            string toLanguageName = toLanguageChineseName.Replace("语", "文");
            if (Languages.ContainsKey(toLanguageName))
                toLanguageName = Languages[toLanguageName];

            return await Translate(text, $"{fromLanguageName}2{toLanguageName}");
        }

        private static string RemoveEmoji(string source)
        {
            char[] chars = source.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int next = i + 1;
                char hs = chars[i];
                if (0xd800 <= hs && hs <= 0xdbff)
                {
                    if (chars.Length > 1)
                    {
                        char ls = chars[next];
                        int uc = ((hs - 0xd800) * 0x400) + (ls - 0xdc00) + 0x10000;
                        if (0x1d000 <= uc && uc <= 0x1f77f)
                            chars[next] = ' ';
                    }
                }
                else
                {
                    if (0x2100 <= hs && hs <= 0x27ff && hs != 0x263b)
                        chars[i] = ' ';
                    if (0x2B05 <= hs && hs <= 0x2b07)
                        chars[i] = ' ';
                    if (0x2934 <= hs && hs <= 0x2935)
                        chars[i] = ' ';
                    if (0x3297 <= hs && hs <= 0x3299)
                        chars[i] = ' ';
                    if (hs == 0xa9 || hs == 0xae || hs == 0x303d || hs == 0x3030 || hs == 0x2b55 || hs == 0x2b1c || hs == 0x2b1b || hs == 0x2b50 || hs == 0x231a)
                        chars[i] = ' ';
                    if (source.Length > 1 && i < source.Length - 1)
                    {
                        char ls = source[next];
                        if (ls == 0x20e3)
                            chars[next] = ' ';
                    }
                }
            }
            return new string(chars);
        }

        private static async Task<string> Translate(string text, string languageType)
        {
            text = RemoveEmoji(text);
            string url = $"http://fanyi.youdao.com/translate?&doctype=json&type={languageType}&i={text}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html, application/xhtml+xml, */*";
            HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
            using (Stream rs = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(rs, Encoding.UTF8))
                {
                    string translatedText = await sr.ReadToEndAsync();
                    if (translatedText.Contains("\"type\":null"))
                        return "";
                    JToken json = JsonConvert.DeserializeObject<JToken>(translatedText);
                    JArray jResult = json["translateResult"] as JArray;
                    List<string> resultList = new List<string>();
                    foreach (JArray innerArray in jResult)
                        resultList.AddRange(innerArray.Select(j => j["tgt"].ToString()));
                    return string.Join("\r\n", resultList).ToString();
                }
            }
        }
    }
}
