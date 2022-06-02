using GreenOnions.Interface;
using System.Text;

namespace GreenOnions.Model
{
    public abstract record GreenOnionsBaseMessage : IGreenOnionsBaseMessage
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
