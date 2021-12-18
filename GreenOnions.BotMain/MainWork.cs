using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GreenOnions.BotMain
{
    public static class MainWork
    {
        private static CancellationTokenSource cancellation;
        public static void Start()
        {
            if (cancellation != null)
                cancellation.Cancel();
            cancellation = new CancellationTokenSource();
            DoRssTask(cancellation.Token);
        }

        public static void Stop() => cancellation.Cancel();

        public static void DoRssTask(CancellationToken token)
        {
            if (true)
            {
                //foreach (var item in collection)
                //{

                //}
                Task.Run(() =>
                {
                    //Requester rssRequester = new Requester("");
                }, token);
            }
        }
    }
}
