namespace GreenOnions.Utility.Items
{
    public class RssSubscriptionItem
    {
        public string Url { get; set; }
        public string Remark { get; set; }
        public long[] ForwardGroups { get; set; }
        public long[] ForwardQQs { get; set; }
        public bool Translate { get; set; }
    }
}
