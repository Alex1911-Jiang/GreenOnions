using System.Collections.ObjectModel;

namespace GreenOnions.Interface
{
    /// <summary>
    /// 抽象平台Api接口
    /// </summary>
    public interface IGreenOnionsApi
    {
        public Func<long, GreenOnionsMessages, Task<int>> _sendFriendMessageAsync { get; init; }
        public Func<long, GreenOnionsMessages, Task<int>> _sendGroupMessageAsync { get; init; }
        public Func<long, long, GreenOnionsMessages, Task<int>> _sendTempMessageAsync { get; init; }
        public Func<Task<List<GreenOnionsFriendInfo>>> _getFriendListAsync { get; init; }
        public Func<Task<List<GreenOnionsGroupInfo>>> _getGroupListAsync { get; init; }
        public Func<long, Task<List<GreenOnionsMemberInfo>>> _getMemberListAsync { get; init; }
        public Func<long, long, Task<GreenOnionsMemberInfo>> _getMemberInfoAsync { get; init; }

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

        #region -- 方法 --

        /// <summary>
        /// 替换目标文本中的标签字符串为变量值，如 "机器人名称" => BotName
        /// </summary>
        /// <param name="originalString">目标文本</param>
        /// <returns>替换标签为变量的完整文本</returns>
        public string ReplaceGreenOnionsStringTags(string originalString);

        #endregion -- 方法 --
    }
}
