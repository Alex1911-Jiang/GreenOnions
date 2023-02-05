namespace GreenOnions.Interface.Subinterface
{
    /// <summary>
    /// Http请求替代插件接口
    /// </summary>
    public interface IHttpClientSubstitutes : IPlugin
    {
        public string GetString(string url, IDictionary<string, string>? header = null);
        public Task<string> GetStringAsync(string url, IDictionary<string, string>? header = null);
        public byte[] GetByteArray(string url, IDictionary<string, string>? header = null);
        public Task<byte[]> GetByteArrayAsync(string url, IDictionary<string, string>? header = null);
        public Stream GetStream(string url, IDictionary<string, string>? header = null);
        public Task<Stream> GetStreamAsync(string url, IDictionary<string, string>? header = null);

        public string PostString(string url, string jsonBody, IDictionary<string, string>? header = null);
        public Task<string> PostStringAsync(string url, string jsonBody, IDictionary<string, string>? header = null);
        public byte[] PostByteArray(string url, string jsonBody, IDictionary<string, string>? header = null);
        public Task<byte[]> PostByteArrayAsync(string url, string jsonBody, IDictionary<string, string>? header = null);
        public Stream PostStream(string url, string jsonBody, IDictionary<string, string>? header = null);
        public Task<Stream> PostStreamAsync(string url, string jsonBody, IDictionary<string, string>? header = null);
    }
}
