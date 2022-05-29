using GreenOnions.Model;
using GreenOnions.RSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public static class RssWorker
    {
        public static void StartRssTask(Action<GreenOnionsMessages, long, long> SendMessage)
        {
            RssHelper.StartRssTask(SendMessage);
        }
    }
}
