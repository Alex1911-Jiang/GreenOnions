using System.Text.RegularExpressions;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.HPicture
{
    public static class MatchHelper
    {
        /// <summary>
        /// 从匹配式中提取数量
        /// </summary>
        /// <param name="matchHPictureCmd"></param>
        /// <returns></returns>
        private static int ExtractNum(Match matchHPictureCmd)
        {
            if (!matchHPictureCmd.Groups["数量"].Success)
                return 1;

            if (string.IsNullOrWhiteSpace(matchHPictureCmd.Groups["数量"].Value))
                return 1;

            if (int.TryParse(matchHPictureCmd.Groups["数量"].Value, out int iNum))
                return iNum;

            long lNum = StringHelper.Chinese2Num(matchHPictureCmd.Groups["数量"].Value);

            if (lNum > BotInfo.Config.HPictureOnceMessageMaxImageCount)
                lNum = BotInfo.Config.HPictureOnceMessageMaxImageCount;

            if (lNum > 20)
                lNum = 20;

            return (int)lNum;
        }

        /// <summary>
        /// 从匹配式中提取关键词
        /// </summary>
        /// <param name="matchHPictureCmd"></param>
        /// <returns></returns>
        private static string ExtractKeyword(Match matchHPictureCmd)
        {
            if (matchHPictureCmd.Groups["关键词"].Success)
                return matchHPictureCmd.Groups["关键词"].Value;
            return string.Empty;
        }

        /// <summary>
        /// 从匹配式中提取组
        /// </summary>
        public static (string keyword, int num, bool r18) ExtractParameter(Match matchHPictureCmd)
        {
            string keyword = ExtractKeyword(matchHPictureCmd);
            int num = ExtractNum(matchHPictureCmd);
            bool bR18 = matchHPictureCmd.Groups["r18"].Success;
            return (keyword, num, bR18);
        }
    }
}
