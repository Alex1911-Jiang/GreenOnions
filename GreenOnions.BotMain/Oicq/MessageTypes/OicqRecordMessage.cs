namespace GreenOnions.BotMain.Oicq.MessageTypes
{
    public class OicqRecordMessage : OicqMessage
    {
        public string file { get; set; }
        public string url { get; set; }
        public bool md5 { get; set; }
        public bool size { get; set; }
        public bool seconds { get; set; }
    }
}
