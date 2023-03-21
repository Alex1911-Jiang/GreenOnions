namespace GreenOnions.BotMain.Oicq.MessageTypes
{
    public class ReceiveOicqMessage
    {
        public string post_type { get; set; }
        public string message_id { get; set; }
        public long user_id { get; set; }
        public long time { get; set; }
        public long seq { get; set; }
        public long rand { get; set; }
        public string font { get; set; }
        public IEnumerable<OicqMessage> message { get; set; }
        public string raw_message { get; set; }
        public string message_type { get; set; }
        public long? group_id { get; set; }
        public string sub_type { get; set; }
        public OicqSender sender { get; set; }
        public long from_id { get; set; }
        public long to_id { get; set; }
        public bool auto_reply { get; set; }
        public object friend { get; set; }
        public long self_id { get; set; }
    }
}
