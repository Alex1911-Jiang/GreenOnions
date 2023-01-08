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

        public async Task<bool> HandleMessageAsync(GreenOnionsMessages msgs, long? targetGroupId)
        {
            if (msgs.FirstOrDefault() is not GreenOnionsTextMessage textMsg)
                return false;

            if (_userCmds.Contains(textMsg.Text))  //自定义色图命令
            {
                bool success = await SendOnecHPictures(msgs.SenderId, targetGroupId, msgs.Id);
                if (success)
                    RecordLimit(msgs.SenderId, targetGroupId, LimitType.Frequency);
                return true;
            }
            else if (false)  //通用色图命令
            {

            }
            return false;
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
                    //case PictureSource.Yande_re:

                    //    break;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception ex)
            {
                await SendMessageAsync(senderId, senderGroup, ex.Message, replyMsgId);
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
            else
            {
                if (BotInfo.Config.HPictureWhiteGroup.Contains(senderGroup.Value))  //白名单群撤回
                    return BotInfo.Config.HPictureWhiteRevoke;
                else
                    return BotInfo.Config.HPictureRevoke;  //普通群撤回
            }
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
