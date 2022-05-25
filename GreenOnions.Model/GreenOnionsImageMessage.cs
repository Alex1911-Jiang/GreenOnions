namespace GreenOnions.Model
{
    public record GreenOnionsImageMessage : GreenOnionsBaseMessage
    {
        private string _base64Str;
        public GreenOnionsImageMessage(MemoryStream ms)
        {
            _base64Str = ms.ToBase64();
            ms.Dispose();
        }
        public GreenOnionsImageMessage(string url)
        {
            Url = url;
        }

        public MemoryStream? MemoryStream
        {
            get
            {
                return _base64Str?.Base64ToMemoryStream();
            }
        }

        public string Base64Str { get; }
        public string? Url { get; set; }
    }
}
