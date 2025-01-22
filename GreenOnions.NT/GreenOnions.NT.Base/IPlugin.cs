using Lagrange.Core;

namespace GreenOnions.NT.Base
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
        /// <param name="bot">机器人对象</param>
        public void OnLoaded(string pluginPath, BotContext bot, ICommonConfig commonConfig);

        public void OnConfigUpdated(ICommonConfig commonConfig);
    }
}