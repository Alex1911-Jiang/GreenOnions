using GoogleTranslateFreeApi;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.Translate
{
    public static class GoogleTranslateHelper
    {
        private static readonly GoogleTranslator Translator = new GoogleTranslator();
        public static readonly Dictionary<string, string> Languages = new Dictionary<string, string>()
        {
            {"旁遮普文" , "Punjabi"},
            {"葡萄牙文" , "Portuguese"},
            {"波兰文" , "Polish"},
            {"波斯文" , "Persian"},
            {"普什图文" , "Pashto"},
            {"挪威文" , "Norwegian"},
            {"尼泊尔文" , "Nepali"},
            {"缅甸文" , "MyanmarBurmese"},
            {"蒙古文" , "Mongolian"},
            {"马拉地文" , "Marathi"},
            {"毛利文" , "Maori"},
            {"罗马尼亚文" , "Romanian"},
            {"马耳他文" , "Maltese"},
            {"马来文" , "Malay"},
            {"马尔加什文" , "Malagasy"},
            {"马其顿文" , "Macedonian"},
            {"卢森堡文" , "Luxembourgish"},
            {"立陶宛文" , "Lithuanian"},
            {"拉脱维亚文" , "Latvian"},
            {"拉丁文" , "Latin"},
            {"老挝文" , "Lao"},
            {"吉尔吉斯文" , "Kyrgyz"},
            {"库尔德文" , "KurdishKurmanji"},
            {"韩文" , "Korean"},
            {"韩国文" , "Korean"},
            {"马拉雅拉姆文" , "Malayalam"},
            {"高棉文" , "Khmer"},
            {"俄文" , "Russian"},
            {"俄罗斯文" , "Russian"},
            {"苏格兰盖尔文" , "ScotsGaelic"},
            {"意第绪文" , "Yiddish"},
            {"科萨文" , "Xhosa"},
            {"南非科萨文" , "Xhosa"},
            {"威尔士文" , "Welsh"},
            {"越南文" , "Vietnamese"},
            {"乌兹别克文" , "Uzbek"},
            {"乌尔都文" , "Urdu"},
            {"乌克兰文" , "Ukrainian"},
            {"土耳其文" , "Turkish"},
            {"泰文" , "Thai"},
            {"泰国文" , "Thai"},
            {"泰卢固文" , "Telugu"},
            {"泰米尔文" , "Tamil"},
            {"萨摩亚文" , "Samoan"},
            {"塔吉克文" , "Tajik"},
            {"斯瓦希里文" , "Swahili"},
            {"印尼巽他文" , "Sundanese"},
            {"西班牙文" , "Spanish"},
            {"索马里文" , "Somali"},
            {"斯洛文尼亚文" , "Slovenian"},
            {"斯洛伐克文" , "Slovak"},
            {"僧伽罗文" , "Sinhala"},
            {"信德文" , "Sindhi"},
            {"修纳文" , "Shona"},
            {"塞索托文" , "Sesotho"},
            {"塞尔维亚文" , "Serbian"},
            {"瑞典文" , "Swedish"},
            {"哈萨克文" , "Kazakh"},
            {"卡纳达文" , "Kannada"},
            {"印尼爪哇文" , "Javanese"},
            {"约鲁巴文" , "Yoruba"},
            {"捷克文" , "Czech"},
            {"克罗地亚文" , "Croatian"},
            {"科西嘉文" , "Corsican"},
            {"繁体中文" , "ChineseTraditional"},
            {"简体中文" , "ChineseSimplified"},
            {"齐切瓦文" , "Chichewa"},
            {"宿务文" , "Cebuano"},
            {"加泰罗尼亚文" , "Catalan"},
            {"保加利亚文" , "Bulgarian"},
            {"波斯尼亚文" , "Bosnian"},
            {"孟加拉文" , "Bengali"},
            {"白俄罗斯文" , "Belarusian"},
            {"巴斯克文" , "Basque"},
            {"阿塞拜疆文" , "Azerbaijani"},
            {"亚美尼亚文" , "Armenian"},
            {"阿拉伯文" , "Arabic"},
            {"阿姆哈拉文" , "Amharic"},
            {"阿尔巴尼亚文" , "Albanian"},
            {"布尔文" , "Afrikaans"},
            {"南非文" , "Afrikaans"},
            {"布尔文(南非荷兰文)" , "Afrikaans"},
            {"南非荷兰文" , "Afrikaans"},
            {"荷兰文" , "Dutch"},
            {"英文" , "English"},
            {"丹麦文" , "Danish"},
            {"爱沙尼亚文" , "Estonian"},
            {"日文" , "Japanese"},
            {"日本文" , "Japanese"},
            {"意大利文" , "Italian"},
            {"爱尔兰文" , "Irish"},
            {"印度尼西亚文" , "Indonesian"},
            {"伊博文" , "Igbo"},
            {"冰岛文" , "Icelandic"},
            {"匈牙利文" , "Hungarian"},
            {"世界文" , "Esperanto"},
            {"印地文" , "Hindi"},
            {"希伯来文" , "Hebrew"},
            {"夏威夷文" , "Hawaiian"},
            {"苗文" , "Hmong"},
            {"苗族文" , "Hmong"},
            {"海地克里奥尔文" , "HaitianCreole"},
            {"菲律宾文" , "Filipino"},
            {"豪萨文" , "Hausa"},
            {"法文" , "French"},
            {"法国文" , "French"},
            {"弗里西文" , "Frisian"},
            {"弗里斯文" , "Frisian"},
            {"弗里斯兰文" , "Frisian"},
            {"芬兰文" , "Finnish"},
            {"格鲁吉亚文" , "Georgian"},
            {"德文" , "German"},
            {"德国文" , "German"},
            {"希腊文" , "Greek"},
            {"古吉拉特文" , "Gujarati"},
            {"加利西亚文" , "Galician"},
            {"祖鲁文" , "Zulu"},
            {"南非祖鲁文" , "Zulu"},
        };

        static GoogleTranslateHelper()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static async Task<string> TranslateToChinese(string text)
        {
            TranslationResult result = await Translator.TranslateAsync(text, Language.Auto, Language.ChineseSimplified);
            return result.MergedTranslation;
        }

        public static async Task<string> TranslateTo(string text, string languageChineseName)
        {
            languageChineseName = languageChineseName.Replace("语", "文");
            string languageName = Languages[languageChineseName];
            TranslationResult result = await Translator.TranslateAsync(text, Language.Auto, GoogleTranslator.GetLanguageByName(languageName));
            return result.MergedTranslation;
        }
    }
}
