using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GreenOnions.Utility
{
    public static class Cache
    {
        public static readonly string JsonConfigFileName = Environment.CurrentDirectory + @"\config.json";
        public static readonly IDictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();
        public static readonly IDictionary<long, DateTime> CDDic = new Dictionary<long, DateTime>();
        public static readonly IDictionary<long, DateTime> WhiteCDDic = new Dictionary<long, DateTime>();
        public static readonly IDictionary<long, DateTime> PMCDDic = new Dictionary<long, DateTime>();
        public static readonly IDictionary<long, int> LimitDic = new Dictionary<long, int>();
        public static readonly List<string> DownloadedImagesName = new List<string>();
        public static readonly IDictionary<long, DateTime> SearchingPictures = new Dictionary<long, DateTime>();

        private static Task _TaskCheckSearchPictureTime = null;
        public static void CheckSearchPictureTime(Action<long> Callback)
        {
            if ((_TaskCheckSearchPictureTime == null || _TaskCheckSearchPictureTime.IsCompleted) && SearchingPictures.Count > 0)
            {
                _TaskCheckSearchPictureTime = Task.Run(() =>
                {
                ILReforeach:;
                    while (SearchingPictures.Count > 0)
                    {
                        Task.Delay(1000).Wait();
                        foreach (KeyValuePair<long, DateTime> item in SearchingPictures)
                        {
                            if (DateTime.Now >= item.Value)
                            {
                                SearchingPictures.Remove(item.Key);
                                Callback(item.Key);
                                goto ILReforeach;
                            }
                        }
                    }
                });
            }
        }

        public static void SetTaskAtFixedTime()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(0);
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(DoAt);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        private static void DoAt(object state)
        {
            LimitDic.Clear();
            SetTaskAtFixedTime();
        }


        public static void RecordLimit(long qqId)
        {
            if (LimitDic.ContainsKey(qqId))
            {
                LimitDic[qqId] += 1;
            }
            else
            {
                LimitDic.Add(qqId, 1);
            }
        }

        public static void RecordCD(long qqId, long groupId)
        {

            if (BotInfo.HPictureWhiteGroup.Contains(groupId))
            {
                if (BotInfo.HPictureWhiteCD > 0)
                {
                    if (WhiteCDDic.ContainsKey(qqId))
                    {
                        WhiteCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.HPictureWhiteCD);
                    }
                    else
                    {
                        WhiteCDDic.Add(qqId, DateTime.Now.AddSeconds(BotInfo.HPictureWhiteCD));
                    }
                }
            }
            else
            {
                if (BotInfo.HPictureCD > 0)
                {
                    if (CDDic.ContainsKey(qqId))
                    {
                        CDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.HPictureCD);
                    }
                    else
                    {
                        CDDic.Add(qqId, DateTime.Now.AddSeconds(BotInfo.HPictureCD));
                    }
                }
            }
        }
    }
}