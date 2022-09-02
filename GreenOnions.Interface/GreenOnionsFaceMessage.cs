namespace GreenOnions.Interface
{
    /// <summary>
    /// 表示表情消息(QQ自带的表情)
    /// </summary>
    public record GreenOnionsFaceMessage : GreenOnionsBaseMessage
    {
        /// <summary>
        /// 表情ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 表情名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 表情消息
        /// </summary>
        /// <param name="id">表情ID</param>
        /// <param name="name">表情名称(当表情ID能找到对应表情时, 该参数无效)</param>
        public GreenOnionsFaceMessage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
