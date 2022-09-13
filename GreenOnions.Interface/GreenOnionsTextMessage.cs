using System.Text;

namespace GreenOnions.Interface
{
    public record GreenOnionsTextMessage : GreenOnionsBaseMessage
    {
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// 文字消息
        /// </summary>
        /// <param name="text">字符串</param>
        public GreenOnionsTextMessage(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 文字消息
        /// </summary>
        /// <param name="text">StringBuilder</param>
        public GreenOnionsTextMessage(StringBuilder text)
        {
            Text = text.ToString();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}