using System.Text;

namespace GreenOnions.Model
{
    public class GreenOnionsTextMessage : GreenOnionsBaseMessage
    {
        public string Text { get; set; }
        public long? ReplyId { get; set; }
        public GreenOnionsTextMessage(string text)
        {
            Text = text;
        }
        public GreenOnionsTextMessage(string text, long replyId)
        {
            Text = text;
            ReplyId = replyId;
        }
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