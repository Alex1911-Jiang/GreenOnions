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
        public static IDictionary<long, DateTime> SearchingPicturesUsers { get; } = new Dictionary<long, DateTime>();
        public static IDictionary<string, int> SauceNaoKeysAndLongRemaining { get; }  //Nao的key剩余每日可用次数
        public static IDictionary<string, int> SauceNaoKeysAndShortRemaining { get; }  //Nao的key剩余30秒内可用次数

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

        static Cache()
        {
            SauceNaoKeysAndLongRemaining = new Dictionary<string, int>();
            foreach (var key in BotInfo.SauceNAOApiKey)
                SauceNaoKeysAndLongRemaining.Add(key, 200);

            SauceNaoKeysAndShortRemaining = new Dictionary<string, int>();
            foreach (var key in BotInfo.SauceNAOApiKey)
                SauceNaoKeysAndShortRemaining.Add(key, 6);

            Task.Run(() =>
            {
                while (true)
                {
                    foreach (var item in SauceNaoKeysAndLongRemaining)  //每7.5分钟恢复1次
                    {
                        if (SauceNaoKeysAndLongRemaining[item.Key] < 200)
                            SauceNaoKeysAndLongRemaining[item.Key] += 1;
                    }
                    Task.Delay(1000 * 450).Wait();

                    CheckWorkingTimeout(SearchingPicturesUsers);   //顺便检查正在搜图的人超时了没有
                }
            });
            Task.Run(() =>
            {
                while (true)
                {
                    foreach (var item in SauceNaoKeysAndShortRemaining)  //每5秒恢复1次
                    {
                        if (SauceNaoKeysAndShortRemaining[item.Key] < 6)
                            SauceNaoKeysAndShortRemaining[item.Key] += 1;
                    }
                    Task.Delay(1000 * 5).Wait();
                }
            });
        }

        private static void CheckWorkingTimeout(IDictionary<long, DateTime> source)
        {
            List<long> removeQQ = new List<long>();
            foreach (KeyValuePair<long, DateTime> SearchingPicturesUser in source)
                if (DateTime.Now > SearchingPicturesUser.Value.AddMinutes(1))
                    removeQQ.Add(SearchingPicturesUser.Key);
            for (int i = 0; i < removeQQ.Count; i++)
                source.Remove(removeQQ[i]);
        }

        public static int CheckPornCounting
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonCacheFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(CheckPornCounting));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonCacheFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(CheckPornCounting), value.ToString());
        }

        public static void SetWorkingTimeout(long qqId, IDictionary<long, DateTime> source, Action SendTimeOutMessage)
        {
            Task.Run(() =>
            {
                while (source.ContainsKey(qqId))
                {
                    if (source[qqId] > DateTime.Now)
                        Task.Delay(1000).Wait();
                    else
                    {
                        source.Remove(qqId);
                        SendTimeOutMessage();
                        break;
                    }
                }
            });
        }

        public static void SetTaskAtFixedTime()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today;
            if (now > oneOClock)
                oneOClock = oneOClock.AddDays(1.0);
            int msUntilFour = (int)(oneOClock - now).TotalMilliseconds;

            var t = new Timer(DoAt);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        private static void DoAt(object state)
        {
            LimitDic.Clear();
            CheckPornCounting = 0;
            SetTaskAtFixedTime();
        }

        public static void RecordLimit(long qqId)
        {
            if (LimitDic.ContainsKey(qqId))
                LimitDic[qqId] += 1;
            else
                LimitDic.Add(qqId, 1);
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
                    return true;  //超过限制
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
                    return true;  //超过限制
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