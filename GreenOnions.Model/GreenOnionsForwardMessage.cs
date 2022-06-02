using GreenOnions.Interface;

namespace GreenOnions.Model
{
    public record GreenOnionsForwardMessage : GreenOnionsBaseMessage, IGreenOnionsForwardMessage
    {
        public IList<(long QQid, string NickName, IGreenOnionsMessages itemMessage)> ItemMessages { get; set; }
        public GreenOnionsForwardMessage(long QQid, string NickName, IGreenOnionsMessages itemMessage)
        {
            ItemMessages = new List<(long QQid, string NickName, IGreenOnionsMessages itemMessage)>();
            ItemMessages.Add((QQid, NickName, itemMessage));
        }
        public GreenOnionsForwardMessage(IEnumerable<(long QQid, string NickName, IGreenOnionsMessages itemMessage)> itemMessage)
        {
            ItemMessages = itemMessage.ToList();
        }
        public GreenOnionsForwardMessage()
        {
            ItemMessages = new List<(long QQid, string NickName, IGreenOnionsMessages itemMessage)>();
        }
        public void Add(long qqId, string nickName, IGreenOnionsMessages originMessage)
        {
            ItemMessages.Add(new(qqId, nickName, originMessage));
        }
    }
}
