using System;
using System.Collections.Generic;
using System.Text;

namespace GreenOnions.HPicture
{
    public struct HPictureItem
    {
        public string P { get; set; }
        public string ID { get; set; }
        public string URL { get; set; }
        public HPictureItem(string p, string id, string url)
        {
            P = p;
            ID = id;
            URL = url;
        }
    }
}
