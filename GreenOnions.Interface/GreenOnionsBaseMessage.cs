using System.Text;

namespace GreenOnions.Interface
{
    /// <summary>
    /// 消息的基类
    /// </summary>
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
    }
}
