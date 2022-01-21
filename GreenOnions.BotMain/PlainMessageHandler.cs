using GreenOnions.HPicture;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace GreenOnions.BotMain
{
    public static class PlainMessageHandler
    {
        private static Regex regexSearchOn;
        private static Regex regexSearchOff;
        private static Regex regexTranslateToChinese;
        private static Regex regexTranslateTo;
        private static Regex regexHPicture;
        private static Regex regexBeautyPicture;
        private static Regex regexForgeMessage;
        private static Regex regexSelectPhone;

        static PlainMessageHandler() => UpdateRegexs();

        public static void UpdateRegexs()
        {
            regexSearchOn = new Regex(BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags());
            regexSearchOff = new Regex(BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags());
            regexTranslateToChinese = new Regex(BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags());
            regexTranslateTo = new Regex(BotInfo.TranslateToCMD.ReplaceGreenOnionsTags());
            regexHPicture = new Regex(BotInfo.HPictureCmd.ReplaceGreenOnionsTags());
            regexBeautyPicture = new Regex(BotInfo.BeautyPictureCmd.ReplaceGreenOnionsTags());
            regexForgeMessage = new Regex(BotInfo.ForgeMessageCmdBegin.ReplaceGreenOnionsTags());
            regexSelectPhone = new Regex($"({BotInfo.BotName}查询手机号[:：])");
        }

        public static async Task HandleMesage(IChatMessage[] Chain, IBaseInfo sender, Action<IChatMessage[], bool> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            string firstMessage = Chain[1].ToString();

            #region -- 伪造消息 --
            if (BotInfo.EnabledForgeMessage && regexForgeMessage.IsMatch(firstMessage))
            {
                if (!BotInfo.ForgeMessageAdminOnly || BotInfo.AdminQQ.Contains(sender.Id))
                {
                    if (Chain.Length > 3 && (Chain[2] is MyAtMessage))
                    {
                        MyAtMessage atMessage = Chain[2] as MyAtMessage;
                        if (!BotInfo.AdminQQ.Contains(sender.Id) && BotInfo.AdminQQ.Contains(atMessage.Target))
                        {
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.RefuseForgeAdminReply.ReplaceGreenOnionsTags()) }, false);
                            return;
                        }
                        if (!BotInfo.AdminQQ.Contains(sender.Id) && atMessage.Target == BotInfo.QQId)
                        {
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.RefuseForgeBotReply.ReplaceGreenOnionsTags()) }, false);
                            return;
                        }

                        List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode> forwardMessageNodes = new List<Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode>();
                        for (int i = 3; i < Chain.Length; i++)
                        {
                            if (Chain[i] is IChatMessage)
                            {
                                string[] plainMsgs = Chain[i].ToString().Split(BotInfo.ForgeMessageCmdNewLine);
                                for (int j = 0; j < plainMsgs.Length; j++)
                                {
                                    forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                    {
                                        Id = forwardMessageNodes.Count,
                                        Name = atMessage.Name,
                                        QQNumber = atMessage.Target,
                                        Time = DateTime.Now,
                                        Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(plainMsgs[j]) },
                                    });
                                }
                            }
                            else if (Chain[i] is IImageMessage)
                            {
                                forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                {
                                    Id = forwardMessageNodes.Count,
                                    Name = atMessage.Name,
                                    QQNumber = atMessage.Target,
                                    Time = DateTime.Now,
                                    Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage((Chain[i] as IImageMessage).ImageId, null, null) },
                                });
                            }
                            else
                                continue;
                        }

                        if (BotInfo.ForgeMessageAppendBotMessageEnabled)
                        {
                            if (!BotInfo.ForgeMessageAdminDontAppend || !BotInfo.AdminQQ.Contains(sender.Id))
                            {
                                forwardMessageNodes.Add(new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                                {
                                    Id = forwardMessageNodes.Count,
                                    Name = BotInfo.BotName,
                                    QQNumber = BotInfo.QQId,
                                    Time = DateTime.Now,
                                    Chain = new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.ForgeMessageAppendMessage.ReplaceGreenOnionsTags()) },
                                });
                            }
                        }

                        Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage forwardMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage(forwardMessageNodes.ToArray());
                        SendMessage?.Invoke(new[] { forwardMessage }, false);
                        return;
                    }
                }
            }
            #endregion -- 伪造消息 --

            #region -- 连续搜图 --
            if (regexSearchOn.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures[sender.Id] = DateTime.Now.AddMinutes(1);
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeAlreadyOnReply.ReplaceGreenOnionsTags()) }, false);
                }
                else
                {
                    Cache.SearchingPictures.Add(sender.Id, DateTime.Now.AddMinutes(1));
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeOnReply.ReplaceGreenOnionsTags()) }, false);
                    Cache.CheckSearchPictureTime(_ =>
                    {
                        Cache.SearchingPictures.Remove(sender.Id);
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeTimeOutReply.ReplaceGreenOnionsTags()) }, false);
                    });
                }
            }
            if (regexSearchOff.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures.Remove(sender.Id);
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeOffReply.ReplaceGreenOnionsTags()) }, false);
                }
                else
                {
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.SearchModeAlreadyOffReply.ReplaceGreenOnionsTags()) }, false);
                }
            }
            #endregion -- 连续搜图 --
            #region -- 翻译 --
            if (regexTranslateToChinese.IsMatch(firstMessage))
            {

                foreach (Match match in regexTranslateToChinese.Matches(firstMessage))
                {
                    try
                    {
                        SendMessage?.Invoke(new [] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(await GoogleTranslateHelper.TranslateToChinese(firstMessage.Substring(match.Value.Length))) }, false);
                    }
                    catch (Exception ex)
                    {
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("翻译失败，" + ex.Message) }, false);
                    }
                }
            }
            if (regexTranslateTo.IsMatch(firstMessage))
            {
                foreach (Match match in regexTranslateTo.Matches(firstMessage))
                {
                    if (match.Groups.Count > 1)
                    {
                        try
                        {
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(await GoogleTranslateHelper.TranslateTo(firstMessage.Substring(match.Value.Length), match.Groups[1].Value)) }, false);
                        }
                        catch (Exception ex)
                        {
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("翻译失败，" + ex.Message) }, false);
                        }
                    }
                }
            }
            #endregion -- 翻译 --
            #region -- 色图 --
            if (regexHPicture.IsMatch(firstMessage) || BotInfo.HPictureUserCmd.Contains(firstMessage))
            {
                if (BotInfo.HPictureEnabled)
                {
                    if (sender is IGroupMemberInfo)  //群消息
                    {
                        IGroupMemberInfo senderGroup = sender as IGroupMemberInfo;
                        if (!BotInfo.HPictureR18WhiteOnly || (BotInfo.HPictureR18WhiteOnly && BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)))
                        {
                            if (senderGroup.Permission == GroupPermission.Member || !BotInfo.HPictureManageNoLimit)
                            {
                                if (Cache.CheckGroupLimit(senderGroup.Id, senderGroup.Group.Id))
                                {
                                    SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureOutOfLimitReply) }, false);
                                    return;
                                }
                                if (Cache.CheckGroupCD(senderGroup.Id, senderGroup.Group.Id))
                                {
                                    SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureCDUnreadyReply) }, false);
                                    return;
                                }
                            }

                            if (BotInfo.EnabledHPictureSource.Count > 0)
                            {
                                Random r = new Random();
                                PictureSource pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];
                                SendPicture(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(senderGroup.Group.Id)));
                            }
                        }
                    }
                    else if (sender is IFriendInfo)  //私聊消息
                    {
                        IFriendInfo senderFriend = sender as IFriendInfo;
                        if (BotInfo.HPictureAllowPM)
                        {
                            if (Cache.CheckPMLimit(senderFriend.Id))
                            {
                                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureOutOfLimitReply) }, false);
                                return;
                            }
                            if (Cache.CheckPMCD(senderFriend.Id))
                            {
                                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureCDUnreadyReply) }, false);
                                return;
                            }

                            if (BotInfo.EnabledHPictureSource.Count > 0)
                            {
                                Random r = new Random();
                                PictureSource pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];
                                SendPicture(sender, pictureSource, BotInfo.HPictureEndCmd, BotInfo.HPictureAllowR18);
                            }
                        }
                    }
                }
                return;
            }
            #endregion -- 色图 --
            #region -- 美图 --
            if (regexBeautyPicture.IsMatch(firstMessage))
            {
                if (BotInfo.HPictureEnabled && BotInfo.EnabledBeautyPictureSource.Count > 0)
                {
                    Random r = new Random();
                    PictureSource pictureSource = BotInfo.EnabledBeautyPictureSource[r.Next(0, BotInfo.EnabledBeautyPictureSource.Count)];
                    SendPicture(sender, pictureSource, BotInfo.BeautyPictureEndCmd, false);
                }
                return;
            }
            #endregion -- 美图 --
            if (firstMessage == $"{BotInfo.BotName}帮助")
            {
                List<string> lstEnabledFeatures = new List<string>();
                if (BotInfo.SearchEnabled)
                {
                    lstEnabledFeatures.Add("搜图");
                }
                if (BotInfo.TranslateEnabled)
                {
                    lstEnabledFeatures.Add("翻译");
                }
                if (BotInfo.HPictureEnabled)
                {
                    lstEnabledFeatures.Add("GHS");
                }
                if (BotInfo.RandomRepeatEnabled || BotInfo.SuccessiveRepeatEnabled)
                {
                    lstEnabledFeatures.Add("复读");
                }
                if (BotInfo.EnabledForgeMessage)
                {
                    lstEnabledFeatures.Add("伪造消息");
                }
                if (BotInfo.QQId == 3246934384)
                {
                    lstEnabledFeatures.Add("查手机号");
                }
                string strHelpResult = $"现在您可以让我{string.Join("，", lstEnabledFeatures)}。\r\n如果您觉得{BotInfo.BotName}好用，请到{BotInfo.BotName}的项目地址 https://github.com/Alex1911-Jiang/GreenOnions 给{BotInfo.BotName}一颗星星。";
                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(strHelpResult) }, false);
            }
            #region -- 查询手机号(夹带私货) --
            if (regexSelectPhone.IsMatch(firstMessage))
            {
                if (BotInfo.QQId == 3246934384)
                {
                    foreach (Match match in regexSelectPhone.Matches(firstMessage))
                    {
                        if (match.Groups.Count > 1)
                        {
                            string qqNumber = firstMessage.Substring(match.Groups[1].Length);
                            long lQQNumber;
                            if (long.TryParse(qqNumber, out lQQNumber))
                            {
                                try
                                {
                                    string result = AssemblyHelper.CallStaticMethod<string>("GreenOnions.QQPhone", "GreenOnions.QQPhone.QQAndPhone", "GetPhoneByQQ", lQQNumber);
                                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(result) }, false);
                                }
                                catch (Exception ex)
                                {
                                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("查询失败" + ex.Message) }, false);
                                }
                            }
                            else
                            {
                                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("请输入正确的QQ号码(不支持以邮箱查询)") }, false);
                            }
                        }
                    }
                }
                return;
            }
            #endregion -- 查询手机号(夹带私货) --

            #region -- 自动翻译 --
            if (BotInfo.AutoTranslateGroupMemoriesQQ.Contains(sender.Id))
            {
                string tranStr = await GoogleTranslateHelper.TranslateToChinese(string.Join('\n', Chain.Skip(1)));
                try
                {
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(tranStr) }, false);
                }
                catch (Exception ex)
                {
                    ErrorHelper.WriteErrorLogWithUserMessage("自动翻译失败", ex);
                }
            };
            #endregion -- 自动翻译 --

            //色图
            void SendPicture(IBaseInfo sender, PictureSource pictureSource, string pictureEndCmd, bool allowR18)
            {
                HPictureHandler.SendHPictures(firstMessage, pictureSource, allowR18, pictureEndCmd, UploadPicture, SendMessage, limitType =>
                {
                    if (limitType == LimitType.Frequency)  //如果本次记录是计次, 说明地址消息已经成功发出, 可以记录CD
                    {
                        if (sender is IGroupMemberInfo)  //记录CD
                        {
                            IGroupMemberInfo senderGroup = sender as IGroupMemberInfo;
                            Cache.RecordGroupCD(senderGroup.Id, senderGroup.Group.Id);
                        }
                        else
                            Cache.RecordFriendCD(sender.Id);
                        if (BotInfo.HPictureLimitType == LimitType.Frequency)  //如果设置是计次
                            Cache.RecordLimit(sender.Id);
                    }
                    else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)  //如果本次记录是记张且设置是记张
                        Cache.RecordLimit(sender.Id);
                });
            }
        }
    }
}
