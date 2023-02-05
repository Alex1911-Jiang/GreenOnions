using System.Reflection.PortableExecutable;

namespace GreenOnions.Interface.DispatchCenter
{
    /// <summary>
    /// HttpClient替代库接口
    /// </summary>
    public static class HttpClientSubstitutes
    {
        public static Func<string, IDictionary<string, string>?, string>? GetString { get; set; }
        public static Func<string, IDictionary<string, string>?, Task<string>>? GetStringAsync { get; set; }
        public static Func<string, IDictionary<string, string>?, byte[]>? GetByteArray { get; set; }
        public static Func<string, IDictionary<string, string>?, Task<byte[]>>? GetByteArrayAsync { get; set; }
        public static Func<string, IDictionary<string, string>?, Stream>? GetStream { get; set; }
        public static Func<string, IDictionary<string, string>?, Task<Stream>>? GetStreamAsync { get; set; }


        public static Func<string, string, IDictionary<string, string>?, string>? PostString { get; set; }
        public static Func<string, string, IDictionary<string, string>?, Task<string>>? PostStringAsync { get; set; }
        public static Func<string, string, IDictionary<string, string>?, byte[]>? PostByteArray { get; set; }
        public static Func<string, string, IDictionary<string, string>?, Task<byte[]>>? PostByteArrayAsync { get; set; }
        public static Func<string, string, IDictionary<string, string>?, Stream>? PostStream { get; set; }
        public static Func<string, string, IDictionary<string, string>?, Task<Stream>>? PostStreamAsync { get; set; }
    }
}
