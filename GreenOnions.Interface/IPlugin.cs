using GreenOnions.Interface.Configs;

namespace GreenOnions.Interface
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 插件描述信息(显示在插件列表中)
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// 加载控件成功时触发
        /// </summary>
        /// <param name="pluginPath">传入插件所在目录, 插件配置项尽量存放在此目录, 避免使用机器人目录</param>
        /// <param name="config">机器人本体的配置信息</param>
        public void OnLoad(string pluginPath, IBotConfig config);

        /// <summary>
        /// 机器人连接到平台时触发
        /// </summary>
        /// <param name="selfId">登录的机器人QQ号</param>
        /// <param name="api">接口类对象</param>
        public void OnConnected(long selfId, IGreenOnionsApi api);

        /// <summary>
        /// 机器人主动断开平台连接时触发
        /// </summary>
        public void OnDisconnected();
    }
}