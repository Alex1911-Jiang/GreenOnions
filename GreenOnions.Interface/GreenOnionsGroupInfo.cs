namespace GreenOnions.Interface
{
    /// <summary>
    /// 群信息
    /// </summary>
    public class GreenOnionsGroupInfo : IGreenOnionsBaseInfo
    {
        /// <summary>
        /// 群号
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// 群名称
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// 群信息(此类不应被用户构造)
        /// </summary>
        public GreenOnionsGroupInfo(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
