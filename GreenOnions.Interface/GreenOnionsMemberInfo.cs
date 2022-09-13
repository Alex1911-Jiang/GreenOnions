namespace GreenOnions.Interface
{
    /// <summary>
    /// 群成员信息
    /// </summary>
    public class GreenOnionsMemberInfo : IGreenOnionsBaseInfo
    {
        /// <summary>
        /// QQ号
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// 群名片
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// 身份
        /// </summary>
        public Permission Permission { get; }

        /// <summary>
        /// 群成员信息(此类不应该由用户构造)
        /// </summary>
        public GreenOnionsMemberInfo(long id, string name, Permission permission)
        {
            Id = id;
            Name = name;
            Permission = permission;
        }
    }

    /// <summary>
    /// 表示群员身份的枚举
    /// </summary>
    public enum Permission
    {
        /// <summary>
        /// 群员
        /// </summary>
        Member = 0,
        /// <summary>
        /// 管理员
        /// </summary>
        Administrator = 1,
        /// <summary>
        /// 裙主
        /// </summary>
        Owner = 2
    }
}
