namespace GreenOnions.Model
{
    public class GreenOnionsForwardMessage : GreenOnionsBaseMessage
    {
        public List<(long QQid, string NickName, GreenOnionsBaseMessage itemMessage)> ItemMessages { get; set; }
        public GreenOnionsForwardMessage(IEnumerable<(long QQid, string NickName, GreenOnionsBaseMessage itemMessage)> itemMessage)
        {
            ItemMessages = itemMessage.ToList();
        }
        public GreenOnionsForwardMessage()
        {
            ItemMessages = new List<(long QQid, string NickName, GreenOnionsBaseMessage itemMessage)>();
        }
        public void Add(long qqId, string nickName, GreenOnionsBaseMessage originMessage)
        {
            ItemMessages.Add(new(qqId, nickName, originMessage));
        }
    }
}
