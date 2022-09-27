using System.Collections.ObjectModel;

namespace GreenOnions.Interface
{
    /// <summary>
    /// 抽象平台Api接口类
    /// </summary>
    public sealed class GreenOnionsApi : IDisposable
    {
        private Func<long, GreenOnionsMessages, Task<int>> _sendFriendMessageAsync;
        private Func<long, GreenOnionsMessages, Task<int>> _sendGroupMessageAsync;
        private Func<long, long, GreenOnionsMessages, Task<int>> _sendTempMessageAsync;
        private Func<Task<List<GreenOnionsFriendInfo>>> _getFriendListAsync;
        private Func<Task<List<GreenOnionsGroupInfo>>> _getGroupListAsync;
        private Func<long, Task<List<GreenOnionsMemberInfo>>> _getMemberListAsync;
        private Func<long, long, Task<GreenOnionsMemberInfo>> _getMemberInfoAsync;

        /// <summary>
        /// 表示GreenOnions本体所有的属性
        /// </summary>
        public ReadOnlyDictionary<string, string> BotProperties { get; set; }

        /// <summary>
        /// 此类不应被用户构造
        /// </summary>
        public GreenOnionsApi(
            in ReadOnlyDictionary<string, string> botProperties,
            in Func<long, GreenOnionsMessages, Task<int>> sendFriendMessageAsync,
            in Func<long, GreenOnionsMessages, Task<int>> sendGroupMessageAsync,
            in Func<long, long, GreenOnionsMessages, Task<int>> sendTempMessageAsync,
            in Func<Task<List<GreenOnionsFriendInfo>>> getFriendListAsync,
            in Func<Task<List<GreenOnionsGroupInfo>>> getGroupListAsync,
            in Func<long, Task<List<GreenOnionsMemberInfo>>> getMemberListAsync,
            in Func<long, long, Task<GreenOnionsMemberInfo>> getMemberInfoAsync
            )
        {
            BotProperties = botProperties;
            _sendFriendMessageAsync = sendFriendMessageAsync;
            _sendGroupMessageAsync = sendGroupMessageAsync;
            _sendTempMessageAsync = sendTempMessageAsync;
            _getFriendListAsync = getFriendListAsync;
            _getGroupListAsync = getGroupListAsync;
            _getMemberListAsync = getMemberListAsync;
            _getMemberInfoAsync = getMemberInfoAsync;
        }

        public void SS()
        {
            _sendFriendMessageAsync = null;
        }

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="qqId">好友QQ</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>消息ID</returns>
        public Task<int> SendFriendMessageAsync(long qqId, GreenOnionsMessages message) => _sendFriendMessageAsync(qqId, message);

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="groupId">目标群号</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>消息ID</returns>
        public Task<int> SendGroupMessageAsync(long groupId, GreenOnionsMessages message) => _sendGroupMessageAsync(groupId, message);

        /// <summary>
        /// 发送临时消息
        /// </summary>
        /// <param name="qqId">目标QQ号</param>
        /// <param name="groupId">目标群号</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>消息ID</returns>
        public Task<int> SendTempMessageAsync(long qqId, long groupId, GreenOnionsMessages message) => _sendTempMessageAsync(qqId, groupId, message);

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <returns>好友列表</returns>
        public Task<List<GreenOnionsFriendInfo>> GetFriendListAsync() => _getFriendListAsync();

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <returns>群列表</returns>
        public Task<List<GreenOnionsGroupInfo>> GetGroupListAsync() => _getGroupListAsync();

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <returns>群成员列表</returns>
        public Task<List<GreenOnionsMemberInfo>> GetMemberListAsync(long groupId) => _getMemberListAsync(groupId);

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="memberId">成员QQ号</param>
        /// <returns>单个群成员的信息</returns>
        public Task<GreenOnionsMemberInfo> GetMemberInfoAsync(long groupId, long memberId) => _getMemberInfoAsync(groupId, memberId);

        /// <summary>
        /// 替换群图片路由
        /// </summary>
        /// <param name="imageUrl">原始图片Url</param>
        /// <returns>替换路由后的图片Url</returns>
        public string ReplaceGroupUrl(string imageUrl)
        {
            if (BotProperties.ContainsKey("ReplaceImgRoute"))
            {
                int iRouteType = Convert.ToInt32(BotProperties["ReplaceImgRoute"]);
                switch (iRouteType)
                {
                    case 1:
                        return imageUrl.Replace("/gchat.qpic.cn/gchatpic_new/", "/c2cpicdw.qpic.cn/offpic_new/");
                    case 2:
                        return imageUrl.Replace("/c2cpicdw.qpic.cn/offpic_new/", "/gchat.qpic.cn/gchatpic_new/");
                }
            }
            return imageUrl;
        }

        /// <summary>
        /// 设置目标QQ号业务超时触发事件
        /// </summary>
        /// <param name="qqId">申请业务的QQ(目标QQ)</param>
        /// <param name="TimeOutDo">超时触发</param>
        /// <param name="source">延时业务集合</param>
        public void SetWorkingTimeout(long qqId, Action TimeOutDo, params IDictionary<long, DateTime>[] source)
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
                                    TimeOutDo();
                            }
                        }
                    }
                    Task.Delay(1000).Wait();
                }
            });
        }

        /// <summary>
        /// 释放Api委托
        /// </summary>
        public void Dispose()
        {
            _sendFriendMessageAsync = null;
            _sendGroupMessageAsync = null;
            _sendTempMessageAsync = null;
            _getFriendListAsync = null;
            _getGroupListAsync = null;
            _getMemberListAsync = null;
            _getMemberInfoAsync = null;
        }
    }
}
