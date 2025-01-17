using GreenOnions.NT.Base;
using YamlDotNet.Serialization;

namespace GreenOnions.NT.Core
{
    public class Config : ICommonConfig
    {
        public static void SaveConfig()
        {
            string configDirect = Path.Combine(AppContext.BaseDirectory, "config.yml");
            string config = YamlConvert.SerializeObject(SngletonInstance.Config);
            File.WriteAllText(configDirect, config);
        }

        public static void LoadConfig()
        {
            string configDirect = Path.Combine(AppContext.BaseDirectory, "config.yml");
            if (!File.Exists(configDirect))
            {
                SngletonInstance.Config = new Config();
                return;
            }
            string config = File.ReadAllText(configDirect);
            SngletonInstance.Config = YamlConvert.DeserializeObject<Config>(config) ?? new Config();
            PluginManager.OnConfigUpdate();
        }

        /// <summary>
        /// 代理地址
        /// </summary>
        [YamlMember(Description = "代理地址（如果是Http代理就只写地址和端口，例:'127.0.0.1:10809'，如果是是Socks5则加上'socks5://'例:'socks5://127.0.0.1:10808'）")]
        public string? ProxyUrl { get; set; } = null;

        /// <summary>
        /// 登录代理的用户名
        /// </summary>
        [YamlMember(Description = "登录代理的用户名（如果有）")]
        public string? ProxyUserName { get; set; } = null;

        /// <summary>
        /// 登录代理的密码
        /// </summary>
        [YamlMember(Description = "登录代理的密码（如果有）")]
        public string? ProxyPassword { get; set; } = null;

        /// <summary>
        /// 机器人名称
        /// </summary>
        [YamlMember(Description = "机器人名称（用于在QQ消息中唤起机器人）")]
        public string BotName { get; set; } = "葱葱";


        [YamlMember(Description = "管理员QQ号")]
        public HashSet<uint> AdminQQ { get; set; } = new HashSet<uint>();

        /// <summary>
        /// 黑名单组
        /// </summary>
        [YamlMember(Description = "群黑名单")]
        public HashSet<uint> BannedGroup { get; set; } = new HashSet<uint>();

        /// <summary>
        /// 黑名单用户
        /// </summary>
        [YamlMember(Description = "用户黑名单")]
        public HashSet<uint> BannedUser { get; set; } = new HashSet<uint>();

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        [YamlMember(Description = "是否启用调试模式（机器人只响应来自管理员和调试群组的消息）")]
        public bool DebugMode { get; set; } = false;

        /// <summary>
        /// 调试群组
        /// </summary>
        [YamlMember(Description = "调试群组号")]
        public HashSet<uint> DebugGroups { get; set; } = new HashSet<uint>();

    }
}
