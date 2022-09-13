namespace GreenOnions.Interface
{
    /// <summary>
    /// 表示语音消息
    /// </summary>
    public record GreenOnionsVoiceMessage : GreenOnionsBaseMessage
    {
        /// <summary>
        /// 音频Url
        /// </summary>
        public string? Url { get; }
        /// <summary>
        /// 音频文件路径
        /// </summary>
        public string? FileName { get; }

        /// <summary>
        /// 音频消息
        /// </summary>
        /// <param name="url">音频Url(和路径任选一个, 同时有值时优先使用Url)</param>
        /// <param name="fileName">音频文件路径(和Url任选一个, 同时有值时优先使用Url)</param>
        public GreenOnionsVoiceMessage(string? url, string? fileName )
        {
            Url = url;
            FileName = fileName;
        }
    }
}
