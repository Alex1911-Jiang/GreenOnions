namespace GreenOnions.Model
{
    public class GreenOnionsMessageGroup : List<GreenOnionsBaseMessage>
    {
        public static implicit operator GreenOnionsMessageGroup(GreenOnionsBaseMessage onceMsg)
        {
            return new GreenOnionsMessageGroup(onceMsg);
        }
        public static implicit operator GreenOnionsMessageGroup(GreenOnionsBaseMessage[] arrMsg)
        {
            return new GreenOnionsMessageGroup(arrMsg);
        }
        public static implicit operator GreenOnionsMessageGroup(string text)
        {
            return new GreenOnionsTextMessage(text);
        }

        public GreenOnionsMessageGroup()
        {

        }

        public GreenOnionsMessageGroup(GreenOnionsBaseMessage messages)
        {
            Add(messages);
        }

        public GreenOnionsMessageGroup(IEnumerable<GreenOnionsBaseMessage> messages)
        {
            AddRange(messages);
        }

        public bool Reply { get; set; } = true;

        public int RevokeTime { get; set; } = 0;
    }
}
