using GreenOnions.NT.Base;
using Lagrange.Core.Common;
using YamlDotNet.Serialization;

namespace GreenOnions.NT.Core
{
    public class Config
    {
        public static Config Instance { get; set; } = new Config();

        public static void SaveConfig()
        {
            string configDirect = Path.Combine(AppContext.BaseDirectory, "config.yml");
            string config = YamlConvert.SerializeObject(Instance);
            File.WriteAllText(configDirect, config);
        }

        public static void LoadConfig()
        {
            string configDirect = Path.Combine(AppContext.BaseDirectory, "config.yml");
            if (!File.Exists(configDirect))
            {
                Instance = new Config();
                return;
            }
            string config = File.ReadAllText(configDirect);
            Instance = YamlConvert.DeserializeObject<Config>(config);
        }

        [YamlMember(Description = "登录配置")]
        public BotConfig? BotConfig { get; set; }

        /// <summary>
        /// 代理地址
        /// </summary>
        [YamlMember(Description = "代理地址（如果是Http代理就只写地址和端口，例:'127.0.0.1:10809'，如果是是Socks5则加上'socks5://'例:'socks5://127.0.0.1:10808'）")]
        public string ProxyUrl { get; set; }

        /// <summary>
        /// 机器人QQ号
        /// </summary>
        [YamlMember(Description = "机器人QQ号")]
        public long BotQQ { get; set; } = 0;

        /// <summary>
        /// 机器人密码
        /// </summary>
        [YamlMember(Description = "机器人密码（如果不填则使用扫码登录）")]
        public long BotPassword { get; set; } = 0;

        /// <summary>
        /// 机器人名称
        /// </summary>
        [YamlMember(Description = "机器人名称（用于在QQ消息中唤起机器人）")]
        public string BotName { get; set; } = "葱葱";


        [YamlMember(Description = "管理员QQ号")]
        public HashSet<long> AdminQQ { get; set; } = new HashSet<long>();

        /// <summary>
        /// 黑名单组
        /// </summary>
        [YamlMember(Description = "群黑名单")]
        public HashSet<long> BannedGroup { get; set; } = new HashSet<long>();

        /// <summary>
        /// 黑名单用户
        /// </summary>
        [YamlMember(Description = "用户黑名单")]
        public HashSet<long> BannedUser { get; set; } = new HashSet<long>();

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        [YamlMember(Description = "是否启用调试模式（机器人只响应来自管理员和调试群组的消息）")]
        public bool DebugMode { get; set; } = false;

        /// <summary>
        /// 调试群组
        /// </summary>
        [YamlMember(Description = "调试群组号")]
        public HashSet<long> DebugGroups { get; set; } = new HashSet<long>();

        /// <summary>
        /// 允许使用Chromium去访问网站
        /// </summary>
        [YamlMember(Description = "调试群组号")]
        public bool UseChromium { get; set; } = false;

    }
}
