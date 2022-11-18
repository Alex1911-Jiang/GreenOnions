namespace GreenOnions.Interface
{
    /// <summary>
    /// 表示图片消息
    /// </summary>
    public record GreenOnionsImageMessage : GreenOnionsBaseMessage
    {
        private string? _base64Str;
        /// <summary>
        /// 图片消息
        /// </summary>
        /// <param name="ms">图片的内存流</param>
        public GreenOnionsImageMessage(MemoryStream ms)
        {
            _base64Str = ms.ToBase64();
            ms.Dispose();
        }
        /// <summary>
        /// 图片消息
        /// </summary>
        /// <param name="url">图片的地址</param>
        public GreenOnionsImageMessage(string url)
        {
            Url = url;
        }

        /// <summary>
        /// 图片的内存字节流
        /// </summary>
        public MemoryStream? MemoryStream
        {
            get
            {
                return _base64Str?.Base64ToMemoryStream();
            }
        }
        /// <summary>
        /// 获取图片的Base64字符串
        /// </summary>
        public string? Base64Str => _base64Str;
        /// <summary>
        /// 获取或设置图片的地址
        /// </summary>
        public string? Url { get; }
    }
}
