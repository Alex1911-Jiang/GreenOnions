namespace GreenOnions.Interface.Configs.Enums
{
    /// <summary>
    /// QQ机器人平台
    /// </summary>
    public enum BotProtocol
    {
        /// <summary>
        /// 内置Konata.Core
        /// </summary>
        Konata_Core = -1,
        /// <summary>
        /// 未选择
        /// </summary>
        None = 0,
        /// <summary>
        /// mirai-api-http平台
        /// </summary>
        mirai_api_http = 1,
        /// <summary>
        /// OneBot(原CqHttp平台)
        /// </summary>
        OneBot = 2,
    }
}
