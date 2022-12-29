using System.Threading.Tasks;
using GreenOnions.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Tmt.V20180321;
using TencentCloud.Tmt.V20180321.Models;

namespace GreenOnions.Translate
{
    public static class TencentTranslateApiHelper
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
            Credential cred = new Credential
            {
                SecretId = BotInfo.Config.TranslateAPPID,
                SecretKey = BotInfo.Config.TranslateAPPKey
            };
            ClientProfile clientProfile = new ClientProfile();
            HttpProfile httpProfile = new HttpProfile();
            httpProfile.Endpoint = ("tmt.tencentcloudapi.com");
            clientProfile.HttpProfile = httpProfile;

            TmtClient client = new TmtClient(cred, "ap-guangzhou", clientProfile);
            TextTranslateRequest req = new TextTranslateRequest();
            req.SourceText = text;
            req.Source = from;
            req.Target = to;
            req.ProjectId = 0;
            TextTranslateResponse resp = await client.TextTranslate(req);
            string strJson = AbstractModel.ToJsonString(resp);
            JToken jt = JsonConvert.DeserializeObject<JToken>(strJson);
            return jt["TargetText"].ToString();
        }
        
        private static string ChineseToCode(string languageName)
        {
            if (Constants.TencentLanguages.ContainsKey(languageName))
                return Constants.TencentLanguages[languageName];
            return languageName;
        }
    }
}
