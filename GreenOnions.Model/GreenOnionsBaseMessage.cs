using System.Text;

namespace GreenOnions.Model
{
    public abstract record GreenOnionsBaseMessage
    {
        public static implicit operator GreenOnionsBaseMessage(string text)
        {
            return new GreenOnionsTextMessage(text);
        }
        public static implicit operator GreenOnionsBaseMessage(StringBuilder text)
        {
            return new GreenOnionsTextMessage(text);
        }
        public static implicit operator GreenOnionsBaseMessage(MemoryStream image)
        {
            return new GreenOnionsImageMessage(image);
        }

        public bool Reply { get; set; } = true;

        public int RevokeTime { get; set; } = 0;
    }
}
