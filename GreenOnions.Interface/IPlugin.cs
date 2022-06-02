namespace GreenOnions.Interface
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 更新设置时触发
        /// </summary>
        /// <param name="jsonSettings">配置文件json中, 程序集名节点下的所有信息</param>
        public void OnSetting(string jsonSettings);

        /// <summary>
        /// 机器人连接到平台时触发
        /// </summary>
        /// <param name="selfId">登录的机器人QQ号</param>
        /// <param name="SendFriendMessage">发送好友消息方法(好友QQ号, 消息体)</param>
        /// <param name="SendGroupMessage">发送群消息方法(群号, 消息体)</param>
        public void OnConnect(long selfId, Action<long, IGreenOnionsMessages> SendFriendMessage, Action<long, IGreenOnionsMessages> SendGroupMessage);

        /// <summary>
        /// 接收到消息时触发
        /// </summary>
        /// <param name="msgs">收到的消息</param>
        /// <param name="senderGroup">消息来自的群号, 私聊消息时为空</param>
        /// <param name="Response">回发消息的方法(消息体, 是否以回复方式发送(如果消息体是合并转发则本参数没有意义))</param>
        /// <returns></returns>
        public bool OnMessage(IGreenOnionsMessages msgs, long? senderGroup, Action<IGreenOnionsMessages, bool> Response);

        /// <summary>
        /// 更新此程序集名所对应的正则表达式
        /// </summary>
        /// <param name="regex">正则表达式</param>
        public void UpdateRegex(string regex);
    }
}