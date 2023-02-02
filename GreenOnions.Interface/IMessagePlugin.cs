namespace GreenOnions.Interface
{
    /// <summary>
    /// 消息插件接口
    /// </summary>
    public interface IMessagePlugin : IPlugin
    {
        /// <summary>
        /// 接收到消息时触发
        /// </summary>
        /// <param name="msgs">收到的消息</param>
        /// <param name="senderGroup">消息来自的群号, 私聊消息时为空</param>
        /// <param name="Response">回发消息的方法(消息体)</param>
        /// <returns>返回是否中断消息链的向后传递(如果装有多个插件, 返回true时表示消息已经被当前插件处理, 接收到的消息不会往后续插件传递, false反之)</returns>
        public bool OnMessage(GreenOnionsMessages msgs, long? senderGroup, Action<GreenOnionsMessages> Response);
    }
}