namespace GreenOnions.Interface.Subinterface
{
    /// <summary>
    /// Http请求替代插件接口
    /// </summary>
    public interface IHttpClientSubstitutes : IPlugin
    {
        public string GetAsString(string url);
        public Task<string> GetAsStringAsync(string url);
    }
}
