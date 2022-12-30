using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GreenOnions.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.Translate
{
    public static class BaiduTranslateApiHelper
    {
        public static async Task<string> TranslateToChinese(string text)
        {
            return await Translate(text, "auto", "zh");
        }

        public static async Task<string> TranslateTo(string text, string toLanguageChineseName)
        {
            string to = ChineseToCode(toLanguageChineseName);
            return await Translate(text, "auto", to);
        }

        public static async Task<string> TranslateFromTo(string text, string fromLanguageChineseName, string toLanguageChineseName)
        {
            string from = ChineseToCode(fromLanguageChineseName);
            string to = ChineseToCode(toLanguageChineseName);
            return await Translate(text, from, to);
        }

        private static async Task<string> Translate(string text, string from, string to)
        {
            using (HttpClient client = new HttpClient())
            {
                List<int> lstSalt = new List<int>(10);
                int code = Guid.NewGuid().GetHashCode();
                Random rdm = new Random(code);
                for (int i = 0; i < 10; i++)
                    lstSalt.Add(rdm.Next(0, 10));
                string salt = string.Join("", lstSalt);
                string signStr = $"{BotInfo.Config.TranslateAPPID}{text}{salt}{BotInfo.Config.TranslateAPPKey}";
                MD5 signMD5 = MD5.Create();
                byte[] signBytes = signMD5.ComputeHash(Encoding.UTF8.GetBytes(signStr));
                StringBuilder sbSign = new StringBuilder();
                for (int i = 0; i < signBytes.Length; i++)
                    sbSign.Append(signBytes[i].ToString("x2"));
                string sign = sbSign.ToString();
                using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "http://api.fanyi.baidu.com/api/trans/vip/translate"))
                {
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    content.Add(new StringContent(text, Encoding.UTF8, "application/x-www-form-urlencoded"), "q");
                    content.Add(new StringContent(from, Encoding.UTF8, "application/x-www-form-urlencoded"), "from");
                    content.Add(new StringContent(to, Encoding.UTF8, "application/x-www-form-urlencoded"), "to");
                    content.Add(new StringContent(BotInfo.Config.TranslateAPPID, Encoding.UTF8, "application/x-www-form-urlencoded"), "appid");
                    content.Add(new StringContent(salt, Encoding.UTF8, "application/x-www-form-urlencoded"), "salt");
                    content.Add(new StringContent(sign, Encoding.UTF8, "application/x-www-form-urlencoded"), "sign");
                    req.Content = content;
                    var tranResp = await client.SendAsync(req);
                    var resultJson = await tranResp.Content.ReadAsStringAsync();
                    JToken jResult = JsonConvert.DeserializeObject<JToken>(resultJson);
                    return jResult["trans_result"][0]["dst"].ToString();
                }
            }
        }

        private static string ChineseToCode(string languageName)
        {
            if (Constants.BaiduLanguages.ContainsKey(languageName))
                return Constants.BaiduLanguages[languageName];
            return languageName;
        }
    }
}
