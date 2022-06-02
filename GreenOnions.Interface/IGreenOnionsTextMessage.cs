namespace GreenOnions.Interface
{
    public interface IGreenOnionsTextMessage : IGreenOnionsBaseMessage
    {
        public string Text { get; set; }
        public string ToString()
        {
            return Text;
        }
    }
}