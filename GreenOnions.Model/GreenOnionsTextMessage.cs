using GreenOnions.Interface;
using System.Text;

namespace GreenOnions.Model
{
    public record GreenOnionsTextMessage : GreenOnionsBaseMessage, IGreenOnionsTextMessage
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