namespace GreenOnions.Interface
{
    /// <summary>
    /// 表示语音消息
    /// </summary>
    public record GreenOnionsVoiceMessage : GreenOnionsBaseMessage
    {
        private string? _base64Str;
        /// <summary>
        /// 音频Url或物理路径
        /// </summary>
        public string? Url { get; }

        /// <summary>
        /// 音频消息
        /// </summary>
        /// <param name="url">音频Url或物理路径</param>
        public GreenOnionsVoiceMessage(string? url)
        {
            Url = url;
        }

        public GreenOnionsVoiceMessage(MemoryStream ms)
        {
            _base64Str = ms.ToBase64();
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
    }
}
