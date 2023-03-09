using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GreenOnions.HPicture.Clients;
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
        private List<string>? _userCmds;
        public Regex? ModuleRegex { get; private set; }

        public HPictureCmdHandler()
        {
            UpdateRegex();
        }

        public void UpdateRegex()
        {
            _userCmds = BotInfo.Config.HPictureUserCmd.ToList();
            ModuleRegex = new Regex(BotInfo.Config.HPictureCmd.ReplaceGreenOnionsStringTags());
        }

        public async Task SendMessageAsync(long targetId, long? targetGroup, GreenOnionsMessages? msgs, long? replyMsgId = null)
        {
            if (msgs is null)
                return;
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

            //自定义色图命令
            if (_userCmds!.Contains(textMsg.Text))  //命中自定义色图命令
            {
                LogHelper.WriteInfoLog($"{msgs.SenderId}的消息命中了自定义色图命令");
                if (!await CheckPermissions(msgs.SenderId, targetGroupId, msgs.Id))  //检查权限
                {
                    LogHelper.WriteInfoLog($"{msgs.SenderId}无权使用色图");
                    return true;
                }
                try
                {
                    if (await SendOnceHPicture(msgs.SenderId, targetGroupId, msgs.Id))
                        RecordLimit(msgs.SenderId, targetGroupId, LimitType.Frequency);  //记录次数限制
                }
                catch (Exception ex)
                {
                    await SendMessageAsync(msgs.SenderId, targetGroupId, BotInfo.Config.HPictureErrorReply.ReplaceGreenOnionsStringTags(("<错误信息>", ex.Message)), msgs.Id);
                }
                return true;
            }

            //常规色图命令
            if (!ModuleRegex!.IsMatch(textMsg.Text))  //命中常规色图命令
                return false;

            Match matchHPcitureCmd = ModuleRegex!.Match(textMsg.Text);

            LogHelper.WriteInfoLog($"{msgs.SenderId}的消息命中了常规色图命令");
            if (!await CheckPermissions(msgs.SenderId, targetGroupId, msgs.Id))  //检查权限
            {
                LogHelper.WriteInfoLog($"{msgs.SenderId}无权使用色图");
                return true;
            }

            (string keyword, int num, bool r18) = MatchHelper.ExtractParameter(matchHPcitureCmd);

            if (num < 1) //请求0张图
            {
                LogHelper.WriteInfoLog($"{msgs.SenderId}请求了少于1张色图，不响应命令");
                return true;
            }

            num = BotInfo.Cache.GetHPictureQuota(num, msgs.SenderId, targetGroupId);  //剩余次数

            if (num < 1) //请求大于等于1张，但次数已耗尽
            {
                LogHelper.WriteInfoLog($"{msgs.SenderId}色图次数耗尽");
                await SendMessageAsync(msgs.SenderId, targetGroupId, BotInfo.Config.HPictureOutOfLimitReply, msgs.Id);  //次数用尽
                return true;
            }

            if (BotInfo.Config.HPictureShieldingWords.Contains(keyword))  //屏蔽词
            {
                LogHelper.WriteInfoLog($"{msgs.SenderId}的色图命令中包含屏蔽词，不响应该命令");
                return true;
            }

            if (r18)
            {
                if (!BotInfo.Config.HPictureAllowR18)  //不允许R18
                    return true;

                if (targetGroupId is long lGroupId && BotInfo.Config.HPictureR18WhiteOnly && !BotInfo.Config.HPictureWhiteGroup.Contains(lGroupId))
                    return true;  //仅限白名单但此群不在白名单中, 不响应R18命令
            }

            try
            {
                if (await SendHPictures(keyword, num, r18, msgs.SenderId, targetGroupId, msgs.Id))
                    RecordLimit(msgs.SenderId, targetGroupId, LimitType.Frequency);  //记录次数限制
            }
            catch (Exception ex)
            {
                await SendMessageAsync(msgs.SenderId, targetGroupId, BotInfo.Config.HPictureErrorReply.ReplaceGreenOnionsStringTags(("<错误信息>", ex.Message)), msgs.Id);
            }

            return false;
        }

        /// <summary>
        /// 检查是否有权限使用色图
        /// </summary>
        private async Task<bool> CheckPermissions(long qqId, long? groupId, long? replyMessageId)
        {
            if (!BotInfo.Config.HPictureEnabled)  //没有启用色图
            {
                LogHelper.WriteInfoLog($"没有启动色图，不响应命令");
                return false;
            }

            if (BotInfo.Cache.GetHPictureQuota(1, qqId, groupId) <= 0)
            {
                LogHelper.WriteInfoLog($"{qqId}色图次数耗尽");
                await SendMessageAsync(qqId, groupId, BotInfo.Config.HPictureOutOfLimitReply, replyMessageId);  //次数用尽
                return false;
            }

            if (BotInfo.Cache.CheckHPictureCD(qqId, groupId))
            {
                LogHelper.WriteInfoLog($"{qqId}色图冷却中");
                await SendMessageAsync(qqId, groupId, BotInfo.Config.HPictureCDUnreadyReply, replyMessageId);  //冷却中
                return false;
            }

            if (groupId is null)
            {
                if (!BotInfo.Config.HPictureAllowPM) //不允许私聊
                {
                    LogHelper.WriteInfoLog($"没有启动私聊色图，不响应私聊色图命令");
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
            }
            return true;
        }

        /// <summary>
        /// 根据设置中启用的色图图库随机一个图库
        /// </summary>
        private async Task<PictureSource> RandomHPictureSource(long senderId, long? senderGroup, long? replyMsgId)
        {
            if (!string.IsNullOrWhiteSpace(BotInfo.Config.LocalHPictureDirect) && Directory.Exists(BotInfo.Config.LocalHPictureDirect))
                BotInfo.Config.EnabledHPictureSource.Add(PictureSource.UserLocal);

            if (BotInfo.Config.EnabledHPictureSource.Count == 0)
            {
                LogHelper.WriteWarningLog($"没有启用任何色图图库");
                throw new Exception("没有连接到任何图库，请联系机器人管理员");
            }

            PictureSource pictureSource;
            if (BotInfo.Config.EnabledHPictureSource.Count == 1)
            {
                pictureSource = BotInfo.Config.EnabledHPictureSource.First();
            }
            else
            {
                Random rdm = new(Guid.NewGuid().GetHashCode());
                int rdmIndex = rdm.Next(0, BotInfo.Config.EnabledHPictureSource.Count);
                pictureSource = BotInfo.Config.EnabledHPictureSource.ToArray()[rdmIndex];
            }

            if (!Enum.IsDefined(pictureSource))
            {
                LogHelper.WriteWarningLog($"设置的色图图库不是允许的值");
                throw new Exception("图库设置有误或指定图库已失效，请联系机器人管理员");
            }

            if (!string.IsNullOrWhiteSpace(BotInfo.Config.HPictureDownloadingReply))  //开始下载回复
                await SendMessageAsync(senderId, senderGroup, BotInfo.Config.HPictureDownloadingReply, replyMsgId);

            return pictureSource;
        }

        /// <summary>
        /// 构建并发送一条色图消息
        /// </summary>
        /// <returns>是否发送成功</returns>
        private async Task<bool> SendOnceHPicture(long senderId, long? senderGroup, long? replyMsgId)
        {
            PictureSource pictureSource = await RandomHPictureSource(senderId, senderGroup, replyMsgId);
            object pictureSourceItem = pictureSource switch
            {
                PictureSource.Lolicon => await new LoliconClient().GetOnceLoliItem(),
                PictureSource.Yande_re => await YandeApi.GetOnceItem(),
                PictureSource.Konachan_net => await KonachanApi.GetOnceItem(),
                PictureSource.Lolibooru => await LolibooruApi.GetOnceItem(),
                PictureSource.Lolisuki => await new LolisukiClient().GetOnceLoliItem(),
                PictureSource.Yuban10703 => await new Yuban10703Client().GetOnceLoliItem(),
                PictureSource.UserLocal => new LocalHPictureItem(),
                _ => throw new Exception("图库设置有误或指定图库已失效，请联系机器人管理员")  //应该不会来到这里
            };
            return await SendOnceHPictureInner(senderId, senderGroup, replyMsgId, pictureSourceItem);
        }

        private async Task<bool> SendOnceHPictureInner(long senderId, long? senderGroup, long? replyMsgId, object pictureSourceItem)
        {
            GreenOnionsMessages? onceHPictureMsgs = new GreenOnionsMessages();  //文字+图片的单条消息
            List<GreenOnionsForwardMessage>? forwardMessages = new List<GreenOnionsForwardMessage>();  //合并转发消息

            try
            {
                GreenOnionsTextMessage? onceHPictureTextMsg = MessageCreater.CreateTextMessageByItem(pictureSourceItem);
                if (onceHPictureTextMsg is not null)
                {
                    if (BotInfo.Config.SplitTextAndImageMessage && BotInfo.Config.HPictureSendByForward)  //文字和图片分别发+合并转发
                        forwardMessages.Add(new GreenOnionsForwardMessage(BotInfo.Config.QQId, BotInfo.Config.BotName, onceHPictureTextMsg));  //将文字消息添加进合并转发
                    else if (BotInfo.Config.SplitTextAndImageMessage)  //文字和图片分别发
                        await SendMessageAsync(senderId, senderGroup, onceHPictureTextMsg, replyMsgId);  //发送文字消息
                    else
                        onceHPictureMsgs.Add(onceHPictureTextMsg);  //将文字添加进单条消息中
                }
            }
            catch (Exception ex)
            {
                await SendMessageAsync(senderId, senderGroup, BotInfo.Config.HPictureErrorReply.ReplaceGreenOnionsStringTags(("<错误信息>", ex.Message)), replyMsgId);
                return false;
            }

            try
            {
                GreenOnionsImageMessage onceHPictureImageMsg = await MessageCreater.CreateImageMessageByItemAsync(pictureSourceItem);
                if (BotInfo.Config.SplitTextAndImageMessage && BotInfo.Config.HPictureSendByForward)  //文字和图片分别发+合并转发
                    forwardMessages.Add(new GreenOnionsForwardMessage(BotInfo.Config.QQId, BotInfo.Config.BotName, onceHPictureImageMsg));  //将图片消息添加进合并转发
                else if (BotInfo.Config.SplitTextAndImageMessage)  //文字和图片分别发
                    await SendMessageAsync(senderId, senderGroup, new GreenOnionsMessages(onceHPictureImageMsg) { RevokeTime = GetRevokeTime(senderGroup) }, replyMsgId);  //发送图片消息
                else
                    onceHPictureMsgs.Add(onceHPictureImageMsg);  //将图片添加进单条消息中
            }
            catch (Exception ex)
            {
                await SendMessageAsync(senderId, senderGroup, BotInfo.Config.HPictureDownloadFailReply.ReplaceGreenOnionsStringTags(("<错误信息>", ex.Message)), replyMsgId);
                return false;
            }

            if (BotInfo.Config.HPictureSendByForward)  //合并转发
            {
                forwardMessages.Add(new GreenOnionsForwardMessage(BotInfo.Config.QQId, BotInfo.Config.BotName, onceHPictureMsgs));
                await SendMessageAsync(senderId, senderGroup, new GreenOnionsMessages(forwardMessages.ToArray()) { RevokeTime = GetRevokeTime(senderGroup) }, replyMsgId);  //发送文字+图片的单条合并转发消息
                RecordLimit(senderId, senderGroup, LimitType.Count);  //记录张数限制
                return true;
            }

            if (BotInfo.Config.SplitTextAndImageMessage)  //已经单独发送了文字和图片
            {
                RecordLimit(senderId, senderGroup, LimitType.Count);  //记录张数限制
                return true;
            }

            onceHPictureMsgs.RevokeTime = GetRevokeTime(senderGroup);
            await SendMessageAsync(senderId, senderGroup, onceHPictureMsgs, replyMsgId);  //发送文字+图片的单条消息
            RecordLimit(senderId, senderGroup, LimitType.Count);  //记录张数限制
            return true;
        }

        /// <summary>
        /// 构建并发送多条色图消息
        /// </summary>
        private async Task<bool> SendHPictures(string keyword, int num, bool r18, long senderId, long? senderGroup, long? replyMsgId)
        {
            int sendCount = 0;
            try
            {
            IL_Rerandom:;
                PictureSource pictureSource = await RandomHPictureSource(senderId, senderGroup, replyMsgId);
                if (pictureSource == PictureSource.UserLocal)
                    goto IL_Rerandom;
                switch (pictureSource)
                {
                    case PictureSource.Lolicon:
                        await foreach (var item in new LoliconClient().GetLoliItems(keyword, num, r18))
                            await SendOnceHPictureInner(senderId, senderGroup, replyMsgId, item);
                        break;
                    case PictureSource.Yande_re:
                        await foreach (var item in YandeApi.GetItems(keyword, r18))
                        {
                            if (sendCount >= num)
                                break;
                            await SendOnceHPictureInner(senderId, senderGroup, replyMsgId, item);
                            sendCount++;
                        }
                        break;
                    case PictureSource.Lolisuki:
                        await foreach (var item in new LolisukiClient().GetLoliItems(keyword, num, r18))
                            await SendOnceHPictureInner(senderId, senderGroup, replyMsgId, item);
                        break;
                    case PictureSource.Yuban10703:
                        await foreach (var item in new Yuban10703Client().GetLoliItems(keyword, num, r18))
                            await SendOnceHPictureInner(senderId, senderGroup, replyMsgId, item);
                        break;
                    case PictureSource.Konachan_net:
                        await foreach (var item in KonachanApi.GetItems(keyword, r18))
                        {
                            if (sendCount >= num)
                                break;
                            await SendOnceHPictureInner(senderId, senderGroup, replyMsgId, item);
                            sendCount++;
                        }
                        break;
                    case PictureSource.Lolibooru:
                        await foreach (var item in LolibooruApi.GetItems(keyword, r18))
                        {
                            if (sendCount >= num)
                                break;
                            await SendOnceHPictureInner(senderId, senderGroup, replyMsgId, item);
                            sendCount++;
                        }
                        break;
                    default:
                        throw new Exception("图库设置有误或指定图库已失效，请联系机器人管理员");  //应该不会来到这里
                }
            }
            catch (Exception ex)
            {
                await SendMessageAsync(senderId, senderGroup, BotInfo.Config.HPictureErrorReply.ReplaceGreenOnionsStringTags(("<错误信息>", ex.Message)), replyMsgId);
                return false;
            }
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
                BotInfo.Cache.RecordHPictureLimit(senderId);
            else if (limitType == LimitType.Count && BotInfo.Config.HPictureLimitType == LimitType.Count)  //如果本次记录是记张且设置是记张
                BotInfo.Cache.RecordHPictureLimit(senderId);

            BotInfo.Cache.RecordHPictureCD(senderId, senderGroup);  //色图记录CD
        }
    }
}
