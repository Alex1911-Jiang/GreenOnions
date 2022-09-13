namespace GreenOnions.Interface
{
    /// <summary>
    /// 好友信息
    /// </summary>
    public class GreenOnionsFriendInfo : IGreenOnionsBaseInfo
    {
        /// <summary>
        /// 好友QQ号
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// 好友昵称
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// 备注名称
        /// </summary>
        public string? Remark { get; }

        /// <summary>
        /// 用户信息(此类不应被用户构造)
        /// </summary>
        public GreenOnionsFriendInfo(long id, string name, string remark)
        {
            Id = id;
            Name = name;
            Remark = remark;
        }
    }
}
