namespace GreenOnions.Model
{
    public record GreenOnionsForwardMessage : GreenOnionsBaseMessage
    {
        public List<(long QQid, string NickName, GreenOnionsMessageGroup itemMessage)> ItemMessages { get; set; }
        public GreenOnionsForwardMessage(long QQid, string NickName, GreenOnionsMessageGroup itemMessage)
        {
            ItemMessages = new List<(long QQid, string NickName, GreenOnionsMessageGroup itemMessage)>();
            ItemMessages.Add((QQid, NickName, itemMessage));
        }
        public GreenOnionsForwardMessage(IEnumerable<(long QQid, string NickName, GreenOnionsMessageGroup itemMessage)> itemMessage)
        {
            ItemMessages = itemMessage.ToList();
        }
        public GreenOnionsForwardMessage()
        {
            ItemMessages = new List<(long QQid, string NickName, GreenOnionsMessageGroup itemMessage)>();
        }
        public void Add(long qqId, string nickName, GreenOnionsMessageGroup originMessage)
        {
            ItemMessages.Add(new(qqId, nickName, originMessage));
        }
    }
}
