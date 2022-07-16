namespace GreenOnions.Interface
{
    public class GreenOnionsMessages : List<GreenOnionsBaseMessage>
    {
        public static implicit operator GreenOnionsMessages(GreenOnionsBaseMessage onceMsg)
        {
            return new GreenOnionsMessages(onceMsg);
        }
        public static implicit operator GreenOnionsMessages(GreenOnionsBaseMessage[] arrMsg)
        {
            return new GreenOnionsMessages(arrMsg);
        }
        public static implicit operator GreenOnionsMessages(string text)
        {
            return new GreenOnionsTextMessage(text);
        }

        public GreenOnionsMessages()
        {

        }

        public GreenOnionsMessages(GreenOnionsBaseMessage messages)
        {
            Add(messages);
        }

        public GreenOnionsMessages(IEnumerable<GreenOnionsBaseMessage> messages)
        {
            AddRange(messages);
        }

        public bool Reply { get; set; } = true;
        public int RevokeTime { get; set; } = 0;
        public long SenderId { get; set; }
        public string SenderName { get; set; }
    }
}
