using System;

namespace GreenOnions.Utility.Helper
{
    public static class EventHelper
    {
        public static Func<string, (string document, string redirectUrl)>? GetDocumentByBrowserEvent { get; set; }
    }
}
