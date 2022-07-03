namespace GreenOnions.Interface
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

        public GreenOnionsImageMessage(string url, string imgFile)
        {
            Url = url;
            ImgFile = imgFile;
        }

        public MemoryStream? MemoryStream
        {
            get
            {
                return _base64Str?.Base64ToMemoryStream();
            }
        }

        public string Base64Str => _base64Str;
        public string? Url { get; set; }
        public string? ImgFile { get; set; }
    }
}
