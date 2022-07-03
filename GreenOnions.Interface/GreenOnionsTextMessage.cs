using System.Text;

namespace GreenOnions.Interface
{
    public record GreenOnionsTextMessage : GreenOnionsBaseMessage
    {
        public string Text { get; set; }
        public GreenOnionsTextMessage(string text)
        {
            Text = text;
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