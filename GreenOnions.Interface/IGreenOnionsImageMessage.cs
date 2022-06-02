namespace GreenOnions.Interface
{
    public interface IGreenOnionsImageMessage : IGreenOnionsBaseMessage
    {
        public MemoryStream? MemoryStream { get; }
        public string Base64Str { get; }
        public string? Url { get; set; }
    }
}
