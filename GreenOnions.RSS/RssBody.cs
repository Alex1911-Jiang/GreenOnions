using System.Collections.Generic;
using System.Text;
using GreenOnions.Interface;

namespace GreenOnions.RSS
{
    internal class RssBody
    {
        internal GreenOnionsMessages Message { get; } = new GreenOnionsMessages();
        internal StringBuilder Text { get; } = new StringBuilder();
        internal List<string> ImageUrls { get; } = new List<string>();
        internal List<string> VideoUrls { get; } = new List<string>();
        internal List<string> IFrameUrls { get; } = new List<string>();
    }
}
