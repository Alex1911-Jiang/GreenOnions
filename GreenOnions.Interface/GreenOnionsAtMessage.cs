namespace GreenOnions.Interface
{
    /// <summary>
    /// 表示@消息
    /// </summary>
    public record GreenOnionsAtMessage : GreenOnionsBaseMessage
    {
        /// <summary>
        /// 被@的的QQ号
        /// </summary>
        public long AtId { get; }
        /// <summary>
        /// 被@的昵称
        /// </summary>
        public string? NickName { get; }

        /// <summary>
        /// @消息
        /// </summary>
        /// <param name="atId">被@的人的QQ号</param>
        /// <param name="nickName">被@的人的群名片(可以和真实群名片不同)</param>
        public GreenOnionsAtMessage(long atId, string? nickName)
        {
            AtId = atId;
            NickName = nickName;
        }
    }
}
