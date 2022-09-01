namespace GreenOnions.Utility.Items
{
    public class RssSubscriptionItem
    {
        /// <summary>
        /// 订阅地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 转发群组
        /// </summary>
        public long[] ForwardGroups { get; set; }
        /// <summary>
        /// 转发好友
        /// </summary>
        public long[] ForwardQQs { get; set; }
        /// <summary>
        /// 翻译
        /// </summary>
        public bool Translate { get; set; }
        /// <summary>
        /// 指定翻译语言
        /// </summary>
        public bool TranslateFromTo { get; set; }
        /// <summary>
        /// 翻译从
        /// </summary>
        public string TranslateFrom { get; set; }
        /// <summary>
        /// 翻译到
        /// </summary>
        public string TranslateTo { get; set; }
        /// <summary>
        /// 以合并转发方式发送
        /// </summary>
        public bool SendByForward { get; set; }
        /// <summary>
        /// At所有人
        /// </summary>
        public bool AtAll { get; set; }
        /// <summary>
        /// 过滤模式 (0=不过滤, 1=包含任一, 2=包含所有, 3=不包含)
        /// </summary>
        public int FilterMode { get; set; }
        /// <summary>
        /// 过滤词
        /// </summary>
        public string[] FilterKeyWords { get; set; }
    }
}
