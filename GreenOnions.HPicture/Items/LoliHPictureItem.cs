namespace GreenOnions.HPicture.Items
{
    public struct LoliHPictureItem
    {
        public string P { get; private set; }
        public string ID { get; private set; }
        public string URL { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Tags { get; private set; }
        public string Address { get; private set; }
        /// <summary>
        /// 构造一个Loli响应对象(lolicon/lolisuki)
        /// </summary>
        /// <param name="p">图片在作品页中的序号</param>
        /// <param name="id">作品id</param>
        /// <param name="url">图片代理地址</param>
        /// <param name="title">作品标题</param>
        /// <param name="author">作者</param>
        /// <param name="tags">标签</param>
        /// <param name="address">作品页</param>
        public LoliHPictureItem(string p, string id, string url, string title, string author, string tags, string address)
        {
            P = p;
            ID = id;
            URL = url;
            Title = title;
            Author = author;
            Tags = tags;
            Address = address;
        }
    }
}
