namespace GreenOnions.NT.Base
{
    public interface ICommonConfig
    {
        /// <summary>
        /// 代理地址
        /// </summary>
        public string? ProxyUrl { get; }

        /// <summary>
        /// 登录代理的用户名
        /// </summary>
        public string? ProxyUserName { get; }

        /// <summary>
        /// 登录代理的密码
        /// </summary>
        public string? ProxyPassword { get; }

        /// <summary>
        /// 机器人名称
        /// </summary>
        public string BotName { get; }

        /// <summary>
        /// 管理员QQ号
        /// </summary>
        public HashSet<uint> AdminQQ { get; }

        /// <summary>
        /// 黑名单组
        /// </summary>
        public HashSet<uint> BannedGroup { get; }

        /// <summary>
        /// 黑名单用户
        /// </summary>
        public HashSet<uint> BannedUser { get; }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public bool DebugMode { get; }

        /// <summary>
        /// 调试群组
        /// </summary>
        public HashSet<uint> DebugGroups { get; }
    }
}
