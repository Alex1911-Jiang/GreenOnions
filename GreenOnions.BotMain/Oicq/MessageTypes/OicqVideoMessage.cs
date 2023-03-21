namespace GreenOnions.BotMain.Oicq.MessageTypes
{
    public class OicqVideoMessage : OicqMessage
    {
        public long id { get; set; }
        public string file { get; set; }
        public string name { get; set; }
        public string fid { get; set; }
        public string md5 { get; set; }
        public string size { get; set; }
        public string seconds { get; set; }
    }
}
