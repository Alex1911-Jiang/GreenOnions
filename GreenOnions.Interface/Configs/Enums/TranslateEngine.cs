namespace GreenOnions.Interface.Configs.Enums
{
    /// <summary>
    /// 翻译引擎
    /// </summary>
    public enum TranslateEngine
    {
        /// <summary>
        /// 谷歌(爬虫方式)
        /// </summary>
        [Obsolete("谷歌翻译爬虫方式已失效", true)]
        Google = 0,
        /// <summary>
        /// 有道(爬虫方式)
        /// </summary>
        YouDao = 1,
        /// <summary>
        /// 有道(Api方式)
        /// </summary>
        YouDaoApi = 2,
        /// <summary>
        /// 百度(Api方式)
        /// </summary>
        BaiduApi = 3,
    }
}