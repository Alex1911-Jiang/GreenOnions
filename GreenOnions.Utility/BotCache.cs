using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenOnions.Interface.Configs.Enums;

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
        public ConcurrentDictionary<string, int> SauceNAOKeysAndLongRemaining { get; set; } = new ConcurrentDictionary<string, int>();  //Nao的key剩余每日可用次数
        public ConcurrentDictionary<string, int> SauceNAOKeysAndShortRemaining { get; set; } = new ConcurrentDictionary<string, int>();  //Nao的key剩余30秒内可用次数

        public BotCache()
        {
            SearchingUserGroups = new ConcurrentDictionary<long, DateTime>[] { SearchingPicturesUsers, SearchingAnimeUsers, Searching3DUsers };
        }

        public void SetSauceNAOKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
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

        public void RecordHPictureLimit(long qqId)
        {
            if (LimitDic.ContainsKey(qqId))
                LimitDic[qqId] += 1;
            else
                LimitDic.TryAdd(qqId, 1);
        }

        /// <summary>
        /// 获取色图剩余配额
        /// </summary>
        public int GetHPictureQuota(int num, long qqId, long? groupId)
        {
            if (BotInfo.Config.HPictureLimit == 0)  //无限制
                return num;

            if (BotInfo.Config.AdminQQ.Contains(qqId) && BotInfo.Config.HPictureAdminNoLimit)  //机器人管理员无限制
                return num;

            if (groupId is null)  //私聊
            {
                if (BotInfo.Config.HPicturePMNoLimit)  //私聊无限制
                    return num;
            }
            else  //群
            {
                if (BotInfo.Config.HPictureWhiteGroup.Contains(groupId.Value) && BotInfo.Config.HPictureWhiteNoLimit)  //白名单群无限制
                    return num;
            }

            if (BotInfo.Config.HPictureLimitType == LimitType.Count)
            {
                if (LimitDic.ContainsKey(qqId))
                    return Math.Min(num, BotInfo.Config.HPictureLimit - LimitDic[qqId]);
                return Math.Min(num, BotInfo.Config.HPictureLimit);
            }
            else
            {
                if (LimitDic.ContainsKey(qqId) && LimitDic[qqId] >= BotInfo.Config.HPictureLimit)
                    return 0;
            }
            return num;
        }

        /// <summary>
        /// 检查冷却时间，true为冷却中
        /// </summary>
        public bool CheckHPictureCD(long qqId, long? groupId = null)
        {
            if (BotInfo.Config.AdminQQ.Contains(qqId) && BotInfo.Config.HPictureAdminNoLimit)  //机器人管理员无限制
                return false;

            if (groupId is null)  //私聊
            {
                if (BotInfo.Config.HPicturePMNoLimit)  //私聊无限制
                    return false;

                if (HPicturePMCDDic.ContainsKey(qqId))
                    if (DateTime.Now < HPicturePMCDDic[qqId]) 
                        return true;  //还在冷却中
            }
            else  //群
            {
                if (BotInfo.Config.HPictureWhiteGroup.Contains(groupId.Value))
                {
                    if (BotInfo.Config.HPictureWhiteNoLimit)  //白名单群无限制
                        return false;

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
            return false;
        }

        /// <summary>
        /// 记录色图冷却时间
        /// </summary>
        public void RecordHPictureCD(long qqId, long? groupId = null)
        {
            if (groupId is null)
            {
                if (BotInfo.Config.HPicturePMCD > 0)
                {
                    if (HPicturePMCDDic.ContainsKey(qqId))
                        HPicturePMCDDic[qqId] = DateTime.Now.AddSeconds(BotInfo.Config.HPicturePMCD);
                    else
                        HPicturePMCDDic.TryAdd(qqId, DateTime.Now.AddSeconds(BotInfo.Config.HPicturePMCD));
                }
            }
            else
            {
                if (BotInfo.Config.HPictureWhiteGroup.Contains(groupId.Value))
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
        }
    }
}