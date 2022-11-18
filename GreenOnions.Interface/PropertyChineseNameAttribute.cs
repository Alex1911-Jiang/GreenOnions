namespace GreenOnions.Interface
{
    /// <summary>
    /// 属性中文别名特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyChineseNameAttribute : Attribute
    {
        /// <summary>
        /// (属性的)中文别名
        /// </summary>
        public string ChineseName { get; init; } = "";
        /// <summary>
        /// (属性的)所属分类
        /// </summary>
        public string NodeName { get; init; } = "";
        /// <summary>
        /// (属性的)描述
        /// </summary>
        public string? Description { get; init; } = "";
        /// <summary>
        /// 属性中文特性
        /// </summary>
        /// <param name="chineseName">中文别名</param>
        /// <param name="nodeName">所属分类</param>
        /// <param name="description">描述</param>
        public PropertyChineseNameAttribute(string chineseName, string nodeName, string? description = null)
        {
            ChineseName = chineseName;
            NodeName = nodeName;
            Description = description;
        }
    }
}
