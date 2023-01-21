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
using TencentCloud.Apigateway.V20180808.Models;

namespace GreenOnions.Translate
{
    public static class YouDaoTranslateApiHelper
    {
        public static async Task<string> TranslateToChinese(string text)
        {
            return await Translate(text, "auto", "zh-CHS");
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
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string appKey = BotInfo.Config.TranslateAPPID;
            string appSecret = BotInfo.Config.TranslateAPPKey;
            string salt = DateTime.Now.Millisecond.ToString();
            dic.Add("from", from);
            dic.Add("to", to);
            dic.Add("signType", "v3");
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            long millis = (long)ts.TotalMilliseconds;
            string curtime = Convert.ToString(millis / 1000);
            dic.Add("curtime", curtime);
            string signStr = appKey + Truncate(text) + salt + curtime + appSecret;
            string sign = ComputeHash(signStr, SHA256.Create());
            dic.Add("q", System.Web.HttpUtility.UrlEncode(text));
            dic.Add("appKey", appKey);
            dic.Add("salt", salt);
            dic.Add("sign", sign);
            return await Post("https://openapi.youdao.com/api", dic);
        }

        private static async Task<string> Post(string url, Dictionary<string, string> dic)
        {
            using HttpClient client = HttpHelper.CreateClient();
            using HttpRequestMessage request = new(HttpMethod.Post, url);
            MultipartFormDataContent form = new MultipartFormDataContent();
            foreach (var item in dic)
                form.Add(new StringContent(item.Value, Encoding.UTF8, "application/x-www-form-urlencoded"), item.Key);
            request.Content = form;
            HttpResponseMessage resp = await client.SendAsync(request);
            string resultText = await resp.Content.ReadAsStringAsync();
            JToken jt = JsonConvert.DeserializeObject<JToken>(resultText);
            if (jt["translation"] is null)
                throw new Exception($"有道智云API返回错误，错误代码：{jt["errorCode"]}");
            return jt["translation"].First.ToString();
        }

        private static string Truncate(string q)
        {
            if (q == null)
                return null;
            int len = q.Length;
            return len <= 20 ? q : (q.Substring(0, 10) + len + q.Substring(len - 10, 10));
        }

        private static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        private static string ChineseToCode(string languageName)
        {
            if (Constants.YouDaoLanguages.ContainsKey(languageName))
                return Constants.YouDaoLanguages[languageName];
            return languageName;
        }
    }
}
