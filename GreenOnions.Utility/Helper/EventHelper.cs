using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.Utility.Helper
{
    public static class EventHelper
    {
        public static Func<string, (string document, string jumpUrl)> GetDocumentByBrowserEvent;
    }
}
