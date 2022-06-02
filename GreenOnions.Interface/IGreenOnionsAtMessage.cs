namespace GreenOnions.Interface
{
    public interface IGreenOnionsAtMessage : IGreenOnionsBaseMessage
    {
        public long AtId { get; set; }
        public string NickName { get; set; }
    }
}
