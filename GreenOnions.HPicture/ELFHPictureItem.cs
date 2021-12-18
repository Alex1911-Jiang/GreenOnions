using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.HPicture
{
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
