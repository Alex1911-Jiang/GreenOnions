namespace GreenOnions.Interface
{
    /// <summary>
    /// 表示基本QQ对象的接口
    /// </summary>
    public interface IGreenOnionsBaseInfo
    {
        /// <summary>
        /// QQ号/群号
        /// </summary>
        long Id { get; }

        /// <summary>
        /// 昵称/群名
        /// </summary>
        string? Name { get; }
    }
}
