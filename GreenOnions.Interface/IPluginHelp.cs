namespace GreenOnions.Interface
{
    /// <summary>
    /// 插件帮助信息接口，实现该接口后当用户输入 "机器人名称"帮助 --"插件名称" 时会发送的帮助消息, 该消息可以替换预定义标签
    /// </summary>
    public interface IPluginHelp
    {
        /// <summary>
        /// 帮助消息
        /// </summary>
        public GreenOnionsMessages? HelpMessage { get; }
    }
}
