using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
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
            MultipartFormDataContent content = new MultipartFormDataContent
            {
                { new StringContent(text, Encoding.UTF8, "application/x-www-form-urlencoded"), "q" },
                { new StringContent(from, Encoding.UTF8, "application/x-www-form-urlencoded"), "from" },
                { new StringContent(to, Encoding.UTF8, "application/x-www-form-urlencoded"), "to" },
                { new StringContent(BotInfo.Config.TranslateAPPID!, Encoding.UTF8, "application/x-www-form-urlencoded"), "appid" },
                { new StringContent(salt, Encoding.UTF8, "application/x-www-form-urlencoded"), "salt" },
                { new StringContent(sign, Encoding.UTF8, "application/x-www-form-urlencoded"), "sign" }
            };
            using HttpClient client = HttpHelper.CreateClient();
            var tranResp = await client.PostAsync("http://api.fanyi.baidu.com/api/trans/vip/translate", content);
            var resultJson = await tranResp.Content.ReadAsStringAsync();
            JToken jResult = JsonConvert.DeserializeObject<JToken>(resultJson);
            if (jResult["trans_result"] is null)
                throw new Exception($"百度翻译API返回错误，错误代码：{jResult["error_code"]}，错误内容：{jResult["error_msg"]}");
            return jResult["trans_result"][0]["dst"].ToString();
        }

        private static string ChineseToCode(string languageName)
        {
            if (Constants.BaiduLanguages.ContainsKey(languageName))
                return Constants.BaiduLanguages[languageName];
            return languageName;
        }
    }
}
