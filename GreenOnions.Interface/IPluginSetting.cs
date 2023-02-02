namespace GreenOnions.Interface
{
    /// <summary>
    /// 插件设置接口，实现该接口后会在Windows插件管理端显示"设置"按钮
    /// </summary>
    public interface IPluginSetting
    {
        /// <summary>
        /// 设置时触发（Windows端点击"设置"按钮，Linux还没做）
        /// </summary>
        public void Setting();
    }
}
