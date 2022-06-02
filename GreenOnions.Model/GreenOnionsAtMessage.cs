using GreenOnions.Interface;

namespace GreenOnions.Model
{
    public record GreenOnionsAtMessage : GreenOnionsBaseMessage, IGreenOnionsAtMessage
    {
        public long AtId { get; set; }
        public string NickName { get; set; }
        public GreenOnionsAtMessage(long atId, string nickName)
        {
            AtId = atId;
            NickName = nickName;
        }
    }
}
