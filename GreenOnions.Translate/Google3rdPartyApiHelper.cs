using System.Text;
using System.Threading.Tasks;
using System.Web;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
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
            text = HttpUtility.UrlEncode(text);
            string result = await HttpHelper.GetStringAsync($"https://translate.googleapis.com/translate_a/single?client=gtx&sl={from}&tl={to}&dt=t&q={text}", BotInfo.Config.TranslateUseProxy);
            JArray arr = JsonConvert.DeserializeObject<JArray>(result);
            StringBuilder sb = new StringBuilder();
            foreach (var jt in arr[0])
                sb.Append(jt[0]);
            return sb.ToString();
        }

        private static string ChineseToCode(string languageName)
        {
            if (Constants.GoogleLanguages.ContainsKey(languageName))
                return Constants.GoogleLanguages[languageName];
            return languageName;
        }
    }
}
