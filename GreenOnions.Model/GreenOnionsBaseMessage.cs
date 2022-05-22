using System.Text;

namespace GreenOnions.Model
{
    public abstract class GreenOnionsBaseMessage
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
    }
}
