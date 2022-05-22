namespace GreenOnions.Model
{
    public class GreenOnionsImageMessage : GreenOnionsBaseMessage
    {
        public GreenOnionsImageMessage(MemoryStream ms)
        {
            MemoryStream = ms;
        }
        public GreenOnionsImageMessage(string url)
        {
            Url = url;
        }

        public MemoryStream? MemoryStream { get; set; }
        public string? Url { get; set; }
    }
}
