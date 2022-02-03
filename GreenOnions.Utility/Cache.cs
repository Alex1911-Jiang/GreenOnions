using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GreenOnions.Utility
{
    public static class Cache
    {
        public static IDictionary<string, Assembly> Assemblies { get; } = new Dictionary<string, Assembly>();
        public static IDictionary<long, DateTime> HPictureCDDic { get; } = new Dictionary<long, DateTime>();
        public static IDictionary<long, DateTime> HPictureWhiteCDDic { get; } = new Dictionary<long, DateTime>();
        public static IDictionary<long, DateTime> HPicturePMCDDic { get; } = new Dictionary<long, DateTime>();
        public static IDictionary<long, int> LimitDic { get; } = new Dictionary<long, int>();
        public static IDictionary<long, DateTime> SearchingPictures { get; } = new Dictionary<long, DateTime>();

        private static IDictionary<string, DateTime> _LastOneSendRssTime = null;
        public static IDictionary<string, DateTime> LastOneSendRssTime 
        {
            get
            {
                if (_LastOneSendRssTime == null)
                {
                    string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonCacheFileName, JsonHelper.JsonNodeNameRss, nameof(LastOneSendRssTime));
                    if (string.IsNullOrEmpty(strValue))
                        _LastOneSendRssTime = new Dictionary<string, DateTime>();
                    else
                        _LastOneSendRssTime = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(strValue);
                }
                return _LastOneSendRssTime;
            }
            set 
            {
                JsonHelper.SetSerializationValue(JsonHelper.JsonCacheFileName, JsonHelper.JsonNodeNameRss, nameof(LastOneSendRssTime), JsonConvert.SerializeObject(value));
            }
        }


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
            DateTime oneOClock = DateTime.Today;
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)(oneOClock - now).TotalMilliseconds;

            var t = new Timer(DoAt);
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

        /// <summary>
        /// 检查群聊次数限制 true为超过限制
        /// </summary>
        /// <param name="qqId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static bool CheckGroupLimit(long qqId, long groupId)
        {
            if (BotInfo.AdminQQ.Contains(qqId) && BotInfo.HPictureAdminNoLimit) return false;
            if (BotInfo.HPictureWhiteGroup.Contains(groupId) && BotInfo.HPictureWhiteNoLimit) return false;
            if (LimitDic.ContainsKey(qqId))
            {
                if (LimitDic[qqId] >= BotInfo.HPictureLimit)
                {
                    return true;  //超过限制
                }
            }
            return false;
        }

        /// <summary>
        /// 检查私聊次数限制 true为超过限制
        /// </summary>
        /// <param name="qqId"></param>
        /// <returns></returns>
        public static bool CheckPMLimit(long qqId)
        {
            if (BotInfo.AdminQQ.Contains(qqId) && BotInfo.HPictureAdminNoLimit) return false;
            if (BotInfo.HPicturePMNoLimit) return false;
            if (LimitDic.ContainsKey(qqId))
            {
                if (LimitDic[qqId] >= BotInfo.HPictureLimit)
                {
                    return true;  //超过限制
                }
            }
            return false;
        }

        public static bool CheckGroupCD(long qqId, long groupId)
        {
            if (BotInfo.AdminQQ.Contains(qqId) && BotInfo.HPictureAdminNoLimit) return false;
            if (BotInfo.HPictureWhiteGroup.Contains(groupId))
            {
                if (BotInfo.HPictureWhiteNoLimit) return false;
                if (HPictureWhiteCDDic.ContainsKey(qqId))
                    if (DateTime.Now < HPictureWhiteCDDic[qqId]) return true;  //还在冷却中
                return false;
            }
            else
            {
                if (HPictureCDDic.ContainsKey(qqId))
                    if (DateTime.Now < HPictureCDDic[qqId]) return true;  //还在冷却中
                return false;
            }
        }

        public static bool CheckPMCD(long qqId)
        {
            if (BotInfo.AdminQQ.Contains(qqId) && BotInfo.HPictureAdminNoLimit) return false;
            if (BotInfo.HPicturePMNoLimit) return false;
            if (HPicturePMCDDic.ContainsKey(qqId))
                if (DateTime.Now < HPicturePMCDDic[qqId]) return true;  //还在冷却中
            return false;
        }

        public static void RecordGroupCD(long qqId, long groupId)
        {
            if (BotInfo.HPictureWhiteGroup.Contains(groupId))
            {
                if (BotInfo.HPictureWhiteCD > 0)
                {
                    if (HPictureWhiteCDDic.ContainsKey(qqId))
                        HPictureWhiteCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.HPictureWhiteCD);
                    else
                        HPictureWhiteCDDic.Add(qqId, DateTime.Now.AddSeconds(BotInfo.HPictureWhiteCD));
                }
            }
            else
            {
                if (BotInfo.HPictureCD > 0)
                {
                    if (HPictureCDDic.ContainsKey(qqId))
                        HPictureCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.HPictureCD);
                    else
                        HPictureCDDic.Add(qqId, DateTime.Now.AddSeconds(BotInfo.HPictureCD));
                }
            }
        }

        public static void RecordFriendCD(long qqId)
        {
            if (BotInfo.HPicturePMCD > 0)
            {
                if (HPicturePMCDDic.ContainsKey(qqId))
                    HPicturePMCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.HPicturePMCD);
                else
                    HPicturePMCDDic.Add(qqId, DateTime.Now.AddSeconds(BotInfo.HPicturePMCD));
            }
        }
    }
}