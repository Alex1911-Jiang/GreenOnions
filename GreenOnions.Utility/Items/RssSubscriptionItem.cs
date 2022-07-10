namespace GreenOnions.Utility.Items
{
    public class RssSubscriptionItem
    {
        public string Url { get; set; }
        public string Remark { get; set; }
        public long[] ForwardGroups { get; set; }
        public long[] ForwardQQs { get; set; }
        public bool Translate { get; set; }
        public bool TranslateFromTo { get; set; }
        public string TranslateFrom { get; set; }
        public string TranslateTo { get; set; }
        public bool SendByForward { get; set; }
        public bool AtAll { get; set; }
        public int FilterMode { get; set; }
        public string[] FilterKeyWords { get; set; }
    }
}
