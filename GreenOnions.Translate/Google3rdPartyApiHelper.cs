using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GreenOnions.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.Translate
{
    public static class Google3rdPartyApiHelper
    {
        public static async Task<string> TranslateToChinese(string text)
        {
            return await Translate(text, "auto", "zh-CN");
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
                var textUrl = System.Uri.EscapeDataString(text);
                var resp = await client.GetAsync($"https://translate.googleapis.com/translate_a/single?client=gtx&sl={from}&tl={to}&dt=t&q={textUrl}");
                string result = await resp.Content.ReadAsStringAsync();
                JArray arr = JsonConvert.DeserializeObject<JArray>(result);
                StringBuilder sb = new StringBuilder();
                string resStr = string.Empty;
                foreach (var jt in arr[0])
                    sb.Append(jt[0]);
                return sb.ToString();
            }
        }

        private static string ChineseToCode(string languageName)
        {
            if (Constants.GoogleLanguages.ContainsKey(languageName))
                return Constants.GoogleLanguages[languageName];
            return languageName;
        }
    }
}
