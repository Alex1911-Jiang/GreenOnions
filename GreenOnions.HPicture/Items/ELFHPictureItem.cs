using System;

namespace GreenOnions.HPicture.Items
{
    [Obsolete("ELF图库大部分图片已失效，作者也不再维护，R.I.P", true)]
    public struct ELFHPictureItem
    {
        public string ID { get; private set; }
        public string Link { get; private set; }
        public string Source { get; private set; }
        public string Jp_Tag { get; private set; }
        public string Zh_Tags { get; private set; }
        public string Author { get; private set; }
        public ELFHPictureItem(string id,string link, string source, string jp_tag, string zh_tags, string author)
        {
            ID = id;
            Link = link;
            Source = source;
            Jp_Tag = jp_tag;
            Zh_Tags = zh_tags;
            Author = author;
        }
    }
}
