using System;
using GreenOnions.Interface;

namespace GreenOnions.RSS
{
    internal struct RssResult
    {
        internal RssResult(GreenOnionsMessages messages, string description, DateTime pubDate, string link, string author)
        {
            Messages = messages;
            Description = description;
            PubDate = pubDate;
            Link = link;
            Author = author;
        }
        internal GreenOnionsMessages Messages { get; private set; }
        internal string Description { get; private set; }
        internal DateTime PubDate { get; private set; }
        internal string Link { get; private set; }
        internal string Author { get; private set; }
    }
}
