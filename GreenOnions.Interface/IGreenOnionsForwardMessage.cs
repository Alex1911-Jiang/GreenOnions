namespace GreenOnions.Interface
{
    public interface IGreenOnionsForwardMessage : IGreenOnionsBaseMessage
    {
        public IList<(long QQid, string NickName, IGreenOnionsMessages itemMessage)> ItemMessages { get; set; }
        public void Add(long qqId, string nickName, IGreenOnionsMessages originMessage);
    }
}
