namespace GreenOnions.Interface
{
    /// <summary>
    /// 表示合并转发消息
    /// </summary>
    public record GreenOnionsForwardMessage : GreenOnionsBaseMessage
    {
        /// <summary>
        /// 合并转发消息中的一组子消息组, 可以嵌套合并转发消息
        /// </summary>
        public IList<(long QQid, string NickName, GreenOnionsMessages itemMessage)> ItemMessages { get; set; }

        /// <summary>
        /// 合并转发一条消息
        /// </summary>
        /// <param name="QQid">发送者的QQ</param>
        /// <param name="NickName">发送者的昵称/群名片</param>
        /// <param name="itemMessage">子消息组</param>
        public GreenOnionsForwardMessage(long QQid, string NickName, GreenOnionsMessages itemMessage)
        {
            ItemMessages = new List<(long QQid, string NickName, GreenOnionsMessages itemMessage)>();
            ItemMessages.Add((QQid, NickName, itemMessage));
        }
        /// <summary>
        /// 合并转发多条消息
        /// </summary>
        /// <param name="itemMessage">以匿名方式添加多个发送者QQ, 发送者昵称, 消息组</param>
        public GreenOnionsForwardMessage(IEnumerable<(long QQid, string NickName, GreenOnionsMessages itemMessage)> itemMessage)
        {
            ItemMessages = itemMessage.ToList();
        }
        /// <summary>
        /// 空白合并转发消息
        /// </summary>
        public GreenOnionsForwardMessage()
        {
            ItemMessages = new List<(long QQid, string NickName, GreenOnionsMessages itemMessage)>();
        }
        /// <summary>
        /// 添加一条消息到合并转发消息中
        /// </summary>
        /// <param name="qqId">发送者QQ</param>
        /// <param name="nickName">发送者昵称/群名片</param>
        /// <param name="originalMessage">消息组</param>
        public void Add(long qqId, string nickName, GreenOnionsMessages originalMessage)
        {
            ItemMessages.Add(new(qqId, nickName, originalMessage));
        }
    }
}
