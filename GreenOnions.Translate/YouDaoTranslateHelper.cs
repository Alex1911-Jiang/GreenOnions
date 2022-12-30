using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GreenOnions.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.Translate
{
    public static class YouDaoTranslateHelper
    {
        public static async Task<string> TranslateToChinese(string text)
        {
            return await Translate(text, "AUTO");
        }

        public static async Task<string> TranslateTo(string text, string toLanguageChineseName)
        {
            if (toLanguageChineseName == "英文")
                return await Translate(text, "ZH_CN2EN");
            else
                return await Translate(text, "EN2ZH_CN");
        }

        public static async Task<string> TranslateFromTo(string text, string fromLanguageChineseName, string toLanguageChineseName)
        {
            string fromCode = ChineseToCode(fromLanguageChineseName);
            string toCode = ChineseToCode(toLanguageChineseName);
            return await Translate(text, $"{fromCode}2{toCode}");
        }

        private static string UTF32ToUTF8(string utf32Str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < utf32Str.Length; i++)
            {
                byte[] bts = Encoding.UTF32.GetBytes(utf32Str[i].ToString());
                if (bts[0].ToString() != "253" || bts[1].ToString() != "255")
                    sb.Append(utf32Str[i]);
            }
            return sb.ToString();
        }

        private static async Task<string> Translate(string text, string languageType)
        {
            text = UTF32ToUTF8(text);
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

        private static string ChineseToCode(string languageName)
        {
            if (Constants.YouDaoWebLanguages.ContainsKey(languageName))
                return Constants.YouDaoWebLanguages[languageName];
            return "AUTO";
        }
    }
}
