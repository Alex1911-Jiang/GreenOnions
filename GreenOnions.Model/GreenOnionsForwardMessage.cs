namespace GreenOnions.Model
{
    public record GreenOnionsForwardMessage : GreenOnionsBaseMessage
    {
        public List<(long QQid, string NickName, GreenOnionsMessages itemMessage)> ItemMessages { get; set; }
        public GreenOnionsForwardMessage(long QQid, string NickName, GreenOnionsMessages itemMessage)
        {
            ItemMessages = new List<(long QQid, string NickName, GreenOnionsMessages itemMessage)>();
            ItemMessages.Add((QQid, NickName, itemMessage));
        }
        public GreenOnionsForwardMessage(IEnumerable<(long QQid, string NickName, GreenOnionsMessages itemMessage)> itemMessage)
        {
            ItemMessages = itemMessage.ToList();
        }
        public GreenOnionsForwardMessage()
        {
            ItemMessages = new List<(long QQid, string NickName, GreenOnionsMessages itemMessage)>();
        }
        public void Add(long qqId, string nickName, GreenOnionsMessages originMessage)
        {
            ItemMessages.Add(new(qqId, nickName, originMessage));
        }
    }
}
