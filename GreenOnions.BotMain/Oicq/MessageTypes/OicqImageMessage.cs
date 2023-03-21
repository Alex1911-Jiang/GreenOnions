namespace GreenOnions.BotMain.Oicq.MessageTypes
{
    public class OicqImageMessage : OicqMessage
    {
        public string file { get; set; }
        public string url { get; set; }
        public bool asface { get; set; }
    }
}
