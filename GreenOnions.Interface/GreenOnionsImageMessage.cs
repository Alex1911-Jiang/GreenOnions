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
        /// <param name="stream">图片流</param>
        /// <param name="disposeStream">是否在创建完图片消息实例后释放流</param>
        public GreenOnionsImageMessage(Stream stream, bool disposeStream = true)
        {
            _base64Str = stream.ToBase64(disposeStream);
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
