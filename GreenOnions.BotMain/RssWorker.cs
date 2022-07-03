using GreenOnions.Interface;
using GreenOnions.RSS;

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
