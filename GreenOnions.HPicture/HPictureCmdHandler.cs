using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GreenOnions.HPicture.Items;
using GreenOnions.Interface;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Interface.Modules;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Yande.re.Api;

namespace GreenOnions.HPicture
{
    public class HPictureCmdHandler : IRegexModule
    {
        private List<string> _userCmds;
        public Regex ModuleRegex { get; private set; }

        public HPictureCmdHandler()
        {
            UpdateRegex();
        }

        public void UpdateRegex()
        {
            _userCmds = BotInfo.Config.HPictureUserCmd.ToList();
            ModuleRegex = new Regex(BotInfo.Config.HPictureCmd.ReplaceGreenOnionsStringTags());
        }

        public async Task SendMessageAsync(long targetId, long? targetGroup, GreenOnionsMessages msgs, int? replyMsgId = null)
        {
            msgs.ReplyId = replyMsgId;
            if (targetGroup is null)
                await BotInfo.API.SendFriendMessageAsync(targetId, msgs);
            else
                await BotInfo.API.SendGroupMessageAsync(targetGroup.Value, msgs);
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="msgs">传入的消息</param>
        /// <param name="targetGroupId">回复目标群</param>
        /// <returns>消息是否已被处理</returns>
        public async Task<bool> HandleMessageAsync(GreenOnionsMessages msgs, long? targetGroupId)
        {
            if (msgs.FirstOrDefault() is not GreenOnionsTextMessage textMsg)
                return false;

            if (_userCmds.Contains(textMsg.Text))  //命中自定义色图命令
            {
                LogHelper.WriteInfoLog($"{msgs.SenderId}的消息命中了自定义色图命令");
                if (!await CheckPermissions(msgs.SenderId, targetGroupId, msgs.Id))  //检查权限
                {
                    LogHelper.WriteInfoLog($"{msgs.SenderId}无权使用色图");
                    return true;
                }
                bool success = await SendOnecHPictures(msgs.SenderId, targetGroupId, msgs.Id);
                if (success)
                    RecordLimit(msgs.SenderId, targetGroupId, LimitType.Frequency);
                return true;
            }

            return false; //TODO

            //常规色图命令
            Match matchHPcitureCmd = ModuleRegex.Match(textMsg.Text);
            if (matchHPcitureCmd is not null)  //命中常规色图命令
            {
                LogHelper.WriteInfoLog($"{msgs.SenderId}的消息命中了常规色图命令");
                if (!await CheckPermissions(msgs.SenderId, targetGroupId, msgs.Id))  //检查权限
                {
                    LogHelper.WriteInfoLog($"{msgs.SenderId}无权使用色图");
                    return true;
                }

                (string keyword, int num, bool r18) = ExtractParameter(matchHPcitureCmd);

                if (BotInfo.Config.HPictureShieldingWords.Contains(keyword))  //屏蔽词
                    return true;

                if (num < 1) //请求0张图
                    return true;

                if (r18)
                {
                    if (!BotInfo.Config.HPictureAllowR18)  //不允许R18
                        return true;

                    if (targetGroupId is long lGroupId && BotInfo.Config.HPictureR18WhiteOnly && !BotInfo.Config.HPictureWhiteGroup.Contains(lGroupId))
                        return true;  //仅限白名单但此群不在白名单中, 不响应R18命令
                }
                //TODO请求
            }

            return false;
        }

        private int ExtractNum(Match matchHPictureCmd)
        {
            if (!matchHPictureCmd.Groups["数量"].Success)
                return 1;

            if (string.IsNullOrWhiteSpace(matchHPictureCmd.Groups["数量"].Value))
                return 1;

            if (int.TryParse(matchHPictureCmd.Groups["数量"].Value, out int iNum))
                return iNum;

            long lNum = StringHelper.Chinese2Num(matchHPictureCmd.Groups["数量"].Value);

            if (lNum > BotInfo.Config.HPictureOnceMessageMaxImageCount)
                lNum = BotInfo.Config.HPictureOnceMessageMaxImageCount;

            if (lNum > 20)
                lNum = 20;

            return (int)lNum;
        }

        private string ExtractKeyword(Match matchHPictureCmd)
        {
            if (matchHPictureCmd.Groups["关键词"].Success)
                return matchHPictureCmd.Groups["关键词"].Value;
            return string.Empty;
        }

        private (string keyword, int num, bool r18) ExtractParameter(Match matchHPictureCmd)
        {
            string keyword = ExtractKeyword(matchHPictureCmd);
            int num = ExtractNum(matchHPictureCmd);
            bool bR18 = matchHPictureCmd.Groups["r18"].Success;
            return (keyword, num, bR18);
        }

        /// <summary>
        /// 检查是否有权限使用色图
        /// </summary>
        /// <param name="qqId">QQ号</param>
        /// <param name="groupId">群号</param>
        /// <param name="replyMessageId">回复引用消息ID</param>
        /// <returns></returns>
        private async Task<bool> CheckPermissions(long qqId, long? groupId, int replyMessageId)
        {
            if (!BotInfo.Config.HPictureEnabled)  //没有启用色图
            {
                LogHelper.WriteInfoLog($"没有启动色图，不响应命令");
                return false;
            }

            if (groupId is null)
            {
                if (!BotInfo.Config.HPictureAllowPM) //不允许私聊
                {
                    LogHelper.WriteInfoLog($"没有启动私聊色图，不响应私聊色图命令");
                    return false;
                }

                if (BotInfo.Cache.CheckPMLimit(qqId))
                {
                    LogHelper.WriteInfoLog($"{qqId}私聊色图次数耗尽");
                    await SendMessageAsync(qqId, groupId, BotInfo.Config.HPictureOutOfLimitReply, replyMessageId);  //次数用尽
                    return false;
                }
                if (BotInfo.Cache.CheckPMCD(qqId))
                {
                    LogHelper.WriteInfoLog($"{qqId}私聊色图冷却中");
                    await SendMessageAsync(qqId, groupId, BotInfo.Config.HPictureCDUnreadyReply, replyMessageId);  //冷却中
                    return false;
                }
            }
            else
            {
                if (BotInfo.Config.HPictureWhiteOnly && !BotInfo.Config.HPictureWhiteGroup.Contains(groupId.Value))  //仅限白名单但当前群不在白名单中
                {
                    LogHelper.WriteInfoLog($"启用了仅限白名单但{groupId.Value}不在白名单中");
                    return false;
                }

                if (BotInfo.Cache.CheckGroupLimit(qqId, groupId.Value))
                {
                    LogHelper.WriteInfoLog($"{qqId}群色图次数耗尽");
                    await SendMessageAsync(qqId, groupId, BotInfo.Config.HPictureOutOfLimitReply, replyMessageId);  //次数用尽
                    return false;
                }
                if (BotInfo.Cache.CheckGroupCD(qqId, groupId.Value))
                {
                    LogHelper.WriteInfoLog($"{qqId}群色图冷却中");
                    await SendMessageAsync(qqId, groupId, BotInfo.Config.HPictureCDUnreadyReply, replyMessageId);  //冷却中
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> SendOnecHPictures(long senderId, long? senderGroup, int? replyMsgId)
        {
            if (BotInfo.Config.EnabledHPictureSource.Count == 0)
            {
                await SendMessageAsync(senderId, senderGroup, "没有连接到任何图库，请联系机器人管理员", replyMsgId);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(BotInfo.Config.HPictureDownloadingReply))  //开始下载回复
                await SendMessageAsync(senderId, senderGroup, BotInfo.Config.HPictureDownloadingReply);

            Random rdm = new(Guid.NewGuid().GetHashCode());
            int rdmIndex = rdm.Next(0, BotInfo.Config.EnabledHPictureSource.Count);
            GreenOnionsMessages onceHPictureMsg;
            try
            {
                switch (BotInfo.Config.EnabledHPictureSource.ToArray()[rdmIndex])
                {
                    case PictureSource.Lolicon:
                        LoliconHPictureItem loliconItem = await LoliconClient.GetOnceLoliconItem();
                        onceHPictureMsg = await MessageCreater.CreateMessageByLoliconItemAsync(loliconItem);
                        break;
                    case PictureSource.Yande_re:
                        YandeItem yandeItem = await YandeApi.GetOnceYandeItem();
                        onceHPictureMsg = await MessageCreater.CreateMessageByYandeItemAsync(yandeItem);
                        break;
                    default:
                        throw new Exception("没有连接到任何图库，请联系机器人管理员");
                }
            }
            catch (Exception ex)
            {
                await SendMessageAsync(senderId, senderGroup, BotInfo.Config.HPictureErrorReply + ex.Message, replyMsgId);
                return false;
            }
            
            onceHPictureMsg.RevokeTime = GetRevokeTime(senderGroup);

            if (BotInfo.Config.SplitTextAndImageMessage && (onceHPictureMsg.OfType<GreenOnionsTextMessage>().Any() && onceHPictureMsg.OfType<GreenOnionsImageMessage>().Any()))  //把文字和图片拆成两条消息
            {
                GreenOnionsMessages outTextMessage = onceHPictureMsg.OfType<GreenOnionsTextMessage>().ToArray();
                GreenOnionsMessages outImageMessage = onceHPictureMsg.OfType<GreenOnionsImageMessage>().ToArray();
                if (BotInfo.Config.HPictureSendByForward)
                {
                    GreenOnionsForwardMessage[] forwardMessages = new[]
                    {
                        new GreenOnionsForwardMessage(BotInfo.Config.QQId, BotInfo.Config.BotName, outTextMessage),
                        new GreenOnionsForwardMessage(BotInfo.Config.QQId, BotInfo.Config.BotName, outImageMessage),
                    };
                    GreenOnionsMessages outForwardMsg = forwardMessages;
                    outForwardMsg.Reply = false;  //合并转发不能回复
                    outForwardMsg.RevokeTime = onceHPictureMsg.RevokeTime;
                    await SendMessageAsync(senderId, senderGroup, outForwardMsg);  //拆成两条子消息的单条合并转发
                }
                else
                {
                    await SendMessageAsync(senderId, senderGroup, outTextMessage, replyMsgId);  //文字消息
                    await SendMessageAsync(senderId, senderGroup, outImageMessage, replyMsgId); //图片消息
                }
            }
            else
            {
                if (BotInfo.Config.HPictureSendByForward)
                {
                    GreenOnionsForwardMessage forwardMsg = new(BotInfo.Config.QQId, BotInfo.Config.BotName, onceHPictureMsg);
                    GreenOnionsMessages outForwardMsg = forwardMsg;
                    outForwardMsg.Reply = false;  //合并转发不能回复
                    outForwardMsg.RevokeTime = onceHPictureMsg.RevokeTime;
                    await SendMessageAsync(senderId, senderGroup, outForwardMsg);  //单条合并转发
                }
                else
                    await SendMessageAsync(senderId, senderGroup, onceHPictureMsg, replyMsgId);  //单条普通消息
            }
            RecordLimit(senderId, senderGroup, LimitType.Count);  //记录张数限制
            return true;
        }

        /// <summary>
        /// 获取消息撤回时间
        /// </summary>
        private static int GetRevokeTime(long? senderGroup)
        {
            if (senderGroup is null)
                return BotInfo.Config.HPicturePMRevoke;  //私聊撤回

            if (BotInfo.Config.HPictureWhiteGroup.Contains(senderGroup.Value))  //白名单群撤回
                return BotInfo.Config.HPictureWhiteRevoke;
            else
                return BotInfo.Config.HPictureRevoke;  //普通群撤回
        }

        /// <summary>
        /// 设置次数限制和冷却时间
        /// </summary>
        private static void RecordLimit(long senderId, long? senderGroup, LimitType limitType)
        {
            if (BotInfo.Config.HPictureLimitType == LimitType.Frequency && limitType == LimitType.Frequency)  //如果本次记录是计次, 说明地址消息已经成功发出, 可以记录CD
                BotInfo.Cache.RecordLimit(senderId);
            else if (limitType == LimitType.Count && BotInfo.Config.HPictureLimitType == LimitType.Count)  //如果本次记录是记张且设置是记张
                BotInfo.Cache.RecordLimit(senderId);

            if (senderGroup is not null)  //群色图记录CD
                BotInfo.Cache.RecordGroupCD(senderId, senderGroup.Value);
            else
                BotInfo.Cache.RecordFriendCD(senderId);
        }
    }
}
