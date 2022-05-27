using GoogleTranslateFreeApi;
using GreenOnions.Utility;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.Translate
{
    public static class GoogleTranslateHelper
    {
        private static readonly GoogleTranslator Translator = new GoogleTranslator();

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
            string languageName = Constants.GoogleLanguages[languageChineseName];

            TranslationResult result = await Translator.TranslateAsync(text, Language.Auto, GoogleTranslator.GetLanguageByName(languageName));
            return result.MergedTranslation;
        }

        public static async Task<string> TranslateFromTo(string text, string fromLanguageChineseName, string toLanguageChineseName)
        {
            string fromLanguageName = fromLanguageChineseName.Replace("语", "文");
            if (Constants.GoogleLanguages.ContainsKey(fromLanguageName))
                fromLanguageName = Constants.GoogleLanguages[fromLanguageChineseName];

            string toLanguageName = toLanguageChineseName.Replace("语", "文");
            if (Constants.GoogleLanguages.ContainsKey(toLanguageName))
                toLanguageName = Constants.GoogleLanguages[toLanguageName];

            TranslationResult result = await Translator.TranslateAsync(text, GoogleTranslator.GetLanguageByName(fromLanguageName), GoogleTranslator.GetLanguageByName(toLanguageName));
            return result.MergedTranslation;
        }
    }
}
