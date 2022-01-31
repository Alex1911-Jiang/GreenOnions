using System;
using System.Collections.Generic;
using System.Text;

namespace GreenOnions.HPicture
{
    public struct LoliconHPictureItem
    {
        public string P { get; private set; }
        public string ID { get; private set; }
        public string URL { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Tags { get; private set; }
        public string Address { get; private set; }
        public LoliconHPictureItem(string p, string id, string url, string title, string author, string tags, string address)
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
