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
        /// 是否在显示在总帮助信息的功能列表中
        /// </summary>
        public bool DisplayedInTheHelp { get; }

        /// <summary>
        /// 帮助消息(当用户输入 "机器人名称"帮助 --"插件名称" 时会发送的帮助消息, 该消息可以替换预定义标签)
        /// </summary>
        public GreenOnionsMessages? HelpMessage { get; }

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

        /// <summary>
        /// 接收到消息时触发
        /// </summary>
        /// <param name="msgs">收到的消息</param>
        /// <param name="senderGroup">消息来自的群号, 私聊消息时为空</param>
        /// <param name="Response">回发消息的方法(消息体)</param>
        /// <returns>返回是否中断消息链的向后传递(如果装有多个插件, 返回true时表示消息已经被当前插件处理, 接收到的消息不会往后续插件传递, false反之)</returns>
        public bool OnMessage(GreenOnionsMessages msgs, long? senderGroup, Action<GreenOnionsMessages> Response);

        /// <summary>
        /// 在Console端设置该插件时触发
        /// </summary>
        public void ConsoleSetting();

        /// <summary>
        /// 在Windows端设置该插件时触发
        /// </summary>
        /// <returns>返回Windows是否已处理设置的调用(当插件有设计Windows设置界面时应当返回true, 如果返回false则会调用Console设置)</returns>
        public bool WindowSetting();
    }
}