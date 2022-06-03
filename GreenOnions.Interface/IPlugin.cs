namespace GreenOnions.Interface
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 加载控件成功时触发
        /// </summary>
        public void OnLoad();

        /// <summary>
        /// 机器人连接到平台时触发
        /// </summary>
        /// <param name="selfId">登录的机器人QQ号</param>
        /// <param name="SendFriendMessage">发送好友消息方法(好友QQ号, 消息体, 返回发送后的消息id)</param>
        /// <param name="SendGroupMessage">发送群消息方法(群号, 消息体, 返回发送后的消息id)</param>
        /// <param name="SendTempMessage">发送临时消息方法(目标QQ号, 群号, 消息体, 返回发送后的消息id)</param>
        public void OnConnected(long selfId, Func<long, IGreenOnionsMessages, Task<int>> SendFriendMessage, Func<long, IGreenOnionsMessages, Task<int>> SendGroupMessage, Func<long, long, IGreenOnionsMessages, Task<int>> SendTempMessage);

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
        /// <returns></returns>
        public bool OnMessage(IGreenOnionsMessages msgs, long? senderGroup, Action<IGreenOnionsMessages> Response);
    }
}