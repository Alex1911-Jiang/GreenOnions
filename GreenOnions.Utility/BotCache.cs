using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GreenOnions.Utility
{
    public class BotCache
    {
        public ConcurrentDictionary<long, DateTime> HPictureCDDic { get; set; } = new ConcurrentDictionary<long, DateTime>();
        public ConcurrentDictionary<long, DateTime> HPictureWhiteCDDic { get; set; } = new ConcurrentDictionary<long, DateTime>();
        public ConcurrentDictionary<long, DateTime> HPicturePMCDDic { get; set; } = new ConcurrentDictionary<long, DateTime>();
        public ConcurrentDictionary<long, int> LimitDic { get; set; } = new ConcurrentDictionary<long, int>();
        public ConcurrentDictionary<long, DateTime> SearchingPicturesUsers { get; set; } = new ConcurrentDictionary<long, DateTime>();
        public ConcurrentDictionary<long, DateTime> SearchingAnimeUsers { get; set; } = new ConcurrentDictionary<long, DateTime>();
        public ConcurrentDictionary<long, DateTime> Searching3DUsers { get; set; } = new ConcurrentDictionary<long, DateTime>();
        public ConcurrentDictionary<long, DateTime>[] SearchingUserGroups { get; set; }
        public ConcurrentDictionary<string, int> SauceNAOKeysAndLongRemaining { get; set; }  //Nao的key剩余每日可用次数
        public ConcurrentDictionary<string, int> SauceNAOKeysAndShortRemaining { get; set; }  //Nao的key剩余30秒内可用次数

        public BotCache()
        {
            SearchingUserGroups = new ConcurrentDictionary<long, DateTime>[] { SearchingPicturesUsers, SearchingAnimeUsers, Searching3DUsers };
        }

        public void SetSauceNAOKey(string key)
        {
            if (!SauceNAOKeysAndLongRemaining.ContainsKey(key))
                SauceNAOKeysAndLongRemaining.TryAdd(key, 200);
            if (!SauceNAOKeysAndShortRemaining.ContainsKey(key))
                SauceNAOKeysAndShortRemaining.TryAdd(key, 6);
        }

        internal void CheckWorkingTimeout(IDictionary<long, DateTime> source)
        {
            List<long> removeQQ = new List<long>();
            foreach (KeyValuePair<long, DateTime> SearchingPicturesUser in source)
                if (DateTime.Now > SearchingPicturesUser.Value.AddMinutes(1))
                    removeQQ.Add(SearchingPicturesUser.Key);
            for (int i = 0; i < removeQQ.Count; i++)
                source.Remove(removeQQ[i]);
        }

        public void SetWorkingTimeout(long qqId, Action SendTimeOutMessage, params IDictionary<long, DateTime>[] source)
        {
            Task.Run(() =>
            {
                while (source.Where(s => s.ContainsKey(qqId)).Count() > 0)
                {
                    for (int i = 0; i < source.Length; i++)
                    {
                        if (source[i].ContainsKey(qqId))
                        {
                            if (source[i][qqId] < DateTime.Now)
                            {
                                source[i].Remove(qqId);
                                if (source.Where(s => s.ContainsKey(qqId)).Count() == 0)
                                    SendTimeOutMessage();
                            }
                        }
                    }
                    Task.Delay(1000).Wait();
                }
            });
        }

        public void SetTaskAtFixedTime()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today;
            if (now > oneOClock)
                oneOClock = oneOClock.AddDays(1.0);
            int msUntilFour = (int)(oneOClock - now).TotalMilliseconds;

            var t = new Timer(DoAt);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        private void DoAt(object state)
        {
            LimitDic.Clear();
            SetTaskAtFixedTime();
        }

        public void RecordLimit(long qqId)
        {
            if (LimitDic.ContainsKey(qqId))
                LimitDic[qqId] += 1;
            else
                LimitDic.TryAdd(qqId, 1);
        }

        /// <summary>
        /// 检查群聊次数限制 true为超过限制
        /// </summary>
        /// <param name="qqId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public bool CheckGroupLimit(long qqId, long groupId)
        {
            if (BotInfo.Config.HPictureLimit == 0)
                return false;

            if (BotInfo.Config.AdminQQ.Contains(qqId) && BotInfo.Config.HPictureAdminNoLimit) return false;
            if (BotInfo.Config.HPictureWhiteGroup.Contains(groupId) && BotInfo.Config.HPictureWhiteNoLimit) return false;
            if (LimitDic.ContainsKey(qqId))
            {
                if (LimitDic[qqId] >= BotInfo.Config.HPictureLimit)
                    return true;  //超过限制
            }
            return false;
        }

        /// <summary>
        /// 检查私聊次数限制 true 为超过限制
        /// </summary>
        /// <param name="qqId"></param>
        /// <returns></returns>
        public bool CheckPMLimit(long qqId)
        {
            if (BotInfo.Config.HPictureLimit == 0)
                return false;

            if (BotInfo.Config.AdminQQ.Contains(qqId) && BotInfo.Config.HPictureAdminNoLimit) return false;
            if (BotInfo.Config.HPicturePMNoLimit) return false;
            if (LimitDic.ContainsKey(qqId))
            {
                if (LimitDic[qqId] >= BotInfo.Config.HPictureLimit)
                    return true;  //超过限制
            }
            return false;
        }

        /// <summary>
        /// 检查群冷却时间 true 为冷却中
        /// </summary>
        /// <param name="qqId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public bool CheckGroupCD(long qqId, long groupId)
        {
            if (BotInfo.Config.AdminQQ.Contains(qqId) && BotInfo.Config.HPictureAdminNoLimit) return false;
            if (BotInfo.Config.HPictureWhiteGroup.Contains(groupId))
            {
                if (BotInfo.Config.HPictureWhiteNoLimit) return false;
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

        public bool CheckPMCD(long qqId)
        {
            if (BotInfo.Config.AdminQQ.Contains(qqId) && BotInfo.Config.HPictureAdminNoLimit) return false;
            if (BotInfo.Config.HPicturePMNoLimit) return false;
            if (HPicturePMCDDic.ContainsKey(qqId))
                if (DateTime.Now < HPicturePMCDDic[qqId]) return true;  //还在冷却中
            return false;
        }

        public void RecordGroupCD(long qqId, long groupId)
        {
            if (BotInfo.Config.HPictureWhiteGroup.Contains(groupId))
            {
                if (BotInfo.Config.HPictureWhiteCD > 0)
                {
                    if (HPictureWhiteCDDic.ContainsKey(qqId))
                        HPictureWhiteCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.Config.HPictureWhiteCD);
                    else
                        HPictureWhiteCDDic.TryAdd(qqId, DateTime.Now.AddSeconds(BotInfo.Config.HPictureWhiteCD));
                }
            }
            else
            {
                if (BotInfo.Config.HPictureCD > 0)
                {
                    if (HPictureCDDic.ContainsKey(qqId))
                        HPictureCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.Config.HPictureCD);
                    else
                        HPictureCDDic.TryAdd(qqId, DateTime.Now.AddSeconds(BotInfo.Config.HPictureCD));
                }
            }
        }

        public void RecordFriendCD(long qqId)
        {
            if (BotInfo.Config.HPicturePMCD > 0)
            {
                if (HPicturePMCDDic.ContainsKey(qqId))
                    HPicturePMCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.Config.HPicturePMCD);
                else
                    HPicturePMCDDic.TryAdd(qqId, DateTime.Now.AddSeconds(BotInfo.Config.HPicturePMCD));
            }
        }
    }
}