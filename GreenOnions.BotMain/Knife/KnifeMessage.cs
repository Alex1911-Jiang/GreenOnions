using Konata.Core.Message;

namespace GreenOnions.BotMain.Knife
{
    public class KnifeMessage
    {
        public MessageStruct Message { get; set; }
        public long SenderId { get; set; }
        public string SenderName { get; set; }
        public long? SenderGroup { get; set; }
    }
}
