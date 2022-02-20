using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

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

            return await Translate(text, $"{fromLanguageName}2{toLanguageName}" );
        }

        private static async Task<string> Translate(string text, string languageType)
        {
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
