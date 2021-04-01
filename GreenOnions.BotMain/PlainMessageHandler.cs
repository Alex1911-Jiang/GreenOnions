using GreenOnions.HPicture;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GreenOnions.BotMain
{
    public static class PlainMessageHandler
    {
        public static async void HandleGroupMesage(MiraiHttpSession session, IMessageBase[] Chain, IGroupMemberInfo sender, QuoteMessage quoteMessage)
        {
            Regex regexSearchOn = new Regex(BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags());
            Regex regexSearchOff = new Regex(BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags());
            Regex regexTranslateToChinese = new Regex(BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags());
            Regex regexTranslateTo = new Regex(BotInfo.TranslateToCMD.ReplaceGreenOnionsTags());
            Regex regexHPicture = new Regex(BotInfo.HPictureCmd.ReplaceGreenOnionsTags());
            Regex regexShabHPicture = new Regex(BotInfo.ShabHPictureCmd.ReplaceGreenOnionsTags());
            Regex regexSelectPhone = new Regex($"({BotInfo.BotName}查询手机号[:：])");

            string firstMessage = Chain[1].ToString();

            #region -- 连续搜图 --
            if (regexSearchOn.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures[sender.Id] = DateTime.Now.AddMinutes(1);
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeAlreadyOnReply.ReplaceGreenOnionsTags()) }, quoteMessage.Id);
                }
                else
                {
                    Cache.SearchingPictures.Add(sender.Id, DateTime.Now.AddMinutes(1));
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeOnReply.ReplaceGreenOnionsTags()) }, quoteMessage.Id);
                    Cache.CheckSearchPictureTime(callback =>
                    {
                        Cache.SearchingPictures.Remove(sender.Id);
                        session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeTimeOutReply.ReplaceGreenOnionsTags()) }, quoteMessage.Id);
                    });
                }
            }
            else if (regexSearchOff.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(sender.Id))
                {
                    Cache.SearchingPictures.Remove(sender.Id);
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeOffReply.ReplaceGreenOnionsTags()) }, quoteMessage.Id);
                }
                else
                {
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchModeAlreadyOffReply.ReplaceGreenOnionsTags()) }, quoteMessage.Id);
                }
            }
            #endregion -- 连续搜图 --
            #region -- 翻译 --
            else if (regexTranslateToChinese.IsMatch(firstMessage))
            {
                foreach (Match match in regexTranslateToChinese.Matches(firstMessage))
                {
                    try
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(await GoogleTranslateHelper.TranslateToChinese(firstMessage.Substring(match.Value.Length))) }, quoteMessage.Id);
                    }
                    catch (Exception ex)
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id, new PlainMessage("翻译失败，" + ex.Message));
                    }
                    break;
                }
            }
            else if (regexTranslateTo.IsMatch(firstMessage))
            {
                foreach (Match match in regexTranslateTo.Matches(firstMessage))
                {
                    if (match.Groups.Count > 1)
                    {
                        try
                        {
                            await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(await GoogleTranslateHelper.TranslateTo(firstMessage.Substring(match.Value.Length), match.Groups[1].Value)) }, quoteMessage.Id);
                        }
                        catch (Exception ex)
                        {
                            await session.SendGroupMessageAsync(sender.Group.Id, new PlainMessage("翻译失败，" + ex.Message));
                        }
                    }
                    break;
                }
            }
            #endregion -- 翻译 --
            #region -- 色图 --
            #region -- Lolicon图库 --
            else if (BotInfo.EnabledLoliconDataBase && (regexHPicture.IsMatch(firstMessage) || BotInfo.HPictureUserCmd.Contains(firstMessage)))
            {
                #region -- 异步流色图(已弃用) --
                //await foreach (var item in HPictureHandlerAsync.SendHPictures(session, firstMessage, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id))))
                //{
                //    int messageID = await session.SendGroupMessageAsync(sender.Group.Id, new[] { item }, quoteMessage.Id);

                //    if (item is PlainMessage)  //地址发出去后记录次数
                //    {
                //        if (BotInfo.HPictureLimitType == LimitType.Frequency)
                //        {
                //            Cache.RecordLimit(sender.Id);
                //        }
                //        Cache.RecordCD(sender.Id, sender.Group.Id);
                //    }
                //    else if (item is ImageMessage)
                //    {
                //        if (BotInfo.HPictureLimitType == LimitType.Count)
                //        {
                //            Cache.RecordLimit(sender.Id);
                //        }
                //        HPictureHandler.RevokeHPicture(session, messageID, BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id) ? BotInfo.HPictureWhiteRevoke : BotInfo.HPictureRevoke);
                //    }
                //}
                #endregion -- 异步流色图(已弃用) --

                if (sender.Permission == GroupPermission.Member || !BotInfo.HPictureManageNoLimit)
                {
                    if (Cache.CheckGroupLimit(sender.Id, sender.Group.Id))
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.HPictureOutOfLimitReply) }, quoteMessage.Id);
                        return;
                    }
                    if (Cache.CheckGroupCD(sender.Id, sender.Group.Id))
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.HPictureCDUnreadyReply) }, quoteMessage.Id);
                        return;
                    }
                }

                HPictureHandler.SendHPictures(session, firstMessage, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id)), BotInfo.HPictureEndCmd, stream => session.UploadPictureAsync(UploadTarget.Group, stream), msg => session.SendGroupMessageAsync(sender.Group.Id, msg, quoteMessage.Id), limitType =>
                {
                    if (limitType == LimitType.Frequency)
                    {
                        Cache.RecordGroupCD(sender.Id, sender.Group.Id);
                        if (BotInfo.HPictureLimitType == LimitType.Frequency)
                            Cache.RecordLimit(sender.Id);
                    }
                    else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)
                        Cache.RecordLimit(sender.Id);
                }, BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id) ? BotInfo.HPictureWhiteRevoke : BotInfo.HPictureRevoke);
            }
            #endregion  -- Lolicon图库 --
            #region -- Shab图库 --
            else if (BotInfo.EnabledShabDataBase && (regexShabHPicture.IsMatch(firstMessage) || BotInfo.HPictureUserCmd.Contains(firstMessage)))
            {
                if (sender.Permission == GroupPermission.Member || !BotInfo.HPictureManageNoLimit)
                {
                    if (Cache.CheckGroupLimit(sender.Id, sender.Group.Id))
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.HPictureOutOfLimitReply) }, quoteMessage.Id);
                        return;
                    }
                    if (Cache.CheckGroupCD(sender.Id, sender.Group.Id))
                    {
                        await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.HPictureCDUnreadyReply) }, quoteMessage.Id);
                        return;
                    }
                }

                HPictureHandler.SendHPictures(session, firstMessage, BotInfo.HPictureAllowR18 && (!BotInfo.HPictureR18WhiteOnly || BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id)), BotInfo.ShabHPictureEndCmd, stream => session.UploadPictureAsync(UploadTarget.Group, stream), msg => session.SendGroupMessageAsync(sender.Group.Id, msg, quoteMessage.Id), limitType =>
                {
                    if (limitType == LimitType.Frequency)
                    {
                        Cache.RecordGroupCD(sender.Id, sender.Group.Id);
                        if (BotInfo.HPictureLimitType == LimitType.Frequency)
                            Cache.RecordLimit(sender.Id);
                    }
                    else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)
                        Cache.RecordLimit(sender.Id);
                }, BotInfo.HPictureWhiteGroup.Contains(sender.Group.Id) ? BotInfo.HPictureWhiteRevoke : BotInfo.HPictureRevoke);
            }
            #endregion -- Shab图库 --
            #endregion -- 色图 --
            else if (firstMessage == $"{BotInfo.BotName}帮助")
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

                if (BotInfo.QQId == 3246934384)
                {
                    lstEnabledFeatures.Add("查手机号");
                }
                string strHelpResult = $"现在您可以让我{string.Join("，", lstEnabledFeatures)}。\r\n如果您觉得{BotInfo.BotName}好用，请到{BotInfo.BotName}的项目地址 https://github.com/Alex1911-Jiang/GreenOnions 给{BotInfo.BotName}一颗星星。";
                await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(strHelpResult) }, quoteMessage.Id);
            }
            #region -- 查询手机号(夹带私货) --
            else if (regexSelectPhone.IsMatch(firstMessage))
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
                                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(result) }, quoteMessage.Id);
                                }
                                catch (Exception ex)
                                {
                                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage("查询失败" + ex.Message) }, quoteMessage.Id);
                                }
                            }
                            else
                            {
                                await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage("请输入正确的QQ号码(不支持以邮箱查询)") }, quoteMessage.Id);
                            }
                        }
                    }
                }
            }
            #endregion -- 查询手机号(夹带私货) --
        }


        public static async void HandleFriendMesage(MiraiHttpSession session, IMessageBase[] Chain, long qqId)
        {
            Regex regexSearchOn = new Regex(BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags());
            Regex regexSearchOff = new Regex(BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags());
            Regex regexTranslateToChinese = new Regex(BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags());
            Regex regexTranslateTo = new Regex(BotInfo.TranslateToCMD.ReplaceGreenOnionsTags());
            Regex regexHPicture = new Regex(BotInfo.HPictureCmd.ReplaceGreenOnionsTags());
            Regex regexShabHPicture = new Regex(BotInfo.ShabHPictureCmd.ReplaceGreenOnionsTags());
            Regex regexSelectPhone = new Regex($"({BotInfo.BotName}查询手机号[:：])");


            string firstMessage = Chain[1].ToString();

            #region -- 连续搜图 --
            if (regexSearchOn.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(qqId))
                {
                    Cache.SearchingPictures[qqId] = DateTime.Now.AddMinutes(1);
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.SearchModeAlreadyOnReply.ReplaceGreenOnionsTags()));
                }
                else
                {
                    Cache.SearchingPictures.Add(qqId, DateTime.Now.AddMinutes(1));
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.SearchModeOnReply.ReplaceGreenOnionsTags()));
                    Cache.CheckSearchPictureTime(callback =>
                    {
                        Cache.SearchingPictures.Remove(qqId);
                        session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.SearchModeTimeOutReply.ReplaceGreenOnionsTags()));
                    });
                }
            }
            else if (regexSearchOff.IsMatch(firstMessage))
            {
                if (Cache.SearchingPictures.ContainsKey(qqId))
                {
                    Cache.SearchingPictures.Remove(qqId);
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.SearchModeOffReply.ReplaceGreenOnionsTags()));
                }
                else
                {
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.SearchModeAlreadyOffReply.ReplaceGreenOnionsTags()));
                }
            }
            #endregion -- 连续搜图 --
            #region -- 翻译 --
            else if (regexTranslateToChinese.IsMatch(firstMessage))
            {
                foreach (Match match in regexTranslateToChinese.Matches(firstMessage))
                {
                    try
                    {
                        await session.SendFriendMessageAsync(qqId, new PlainMessage(await GoogleTranslateHelper.TranslateToChinese(firstMessage.Substring(match.Value.Length))));
                    }
                    catch (Exception ex)
                    {
                        await session.SendFriendMessageAsync(qqId, new PlainMessage("翻译失败，" + ex.Message));
                    }
                    break;
                }
            }
            else if (regexTranslateTo.IsMatch(firstMessage))
            {
                foreach (Match match in regexTranslateTo.Matches(firstMessage))
                {
                    if (match.Groups.Count > 1)
                    {
                        try
                        {
                            await session.SendFriendMessageAsync(qqId, new PlainMessage(await GoogleTranslateHelper.TranslateTo(firstMessage.Substring(match.Value.Length), match.Groups[1].Value)));
                        }
                        catch (Exception ex)
                        {
                            await session.SendFriendMessageAsync(qqId, new PlainMessage("翻译失败，" + ex.Message));
                        }
                    }
                    break;
                }
            }
            #endregion -- 翻译 --
            #region -- 色图 --
            #region  -- Lolicon图库 --
            else if (regexHPicture.IsMatch(firstMessage) || BotInfo.HPictureUserCmd.Contains(firstMessage))
            {
                if (Cache.CheckPMLimit(qqId))
                {
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.HPictureOutOfLimitReply));
                    return;
                }
                if (Cache.CheckPMCD(qqId))
                {
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.HPictureCDUnreadyReply));
                    return;
                }
                HPictureHandler.SendHPictures(session, firstMessage, BotInfo.HPictureAllowR18, BotInfo.HPictureEndCmd, stream => session.UploadPictureAsync(UploadTarget.Friend, stream), msg => session.SendFriendMessageAsync(qqId, msg), limitType =>
                {
                    if (limitType == LimitType.Frequency)
                    {
                        Cache.RecordFriendCD(qqId);
                        if (BotInfo.HPictureLimitType == LimitType.Frequency)
                            Cache.RecordLimit(qqId);
                    }
                    else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)
                        Cache.RecordLimit(qqId);
                }, BotInfo.HPicturePMRevoke);
            }
            #endregion  -- Lolicon图库 --
            #region  -- Shab图库 --
            else if (regexShabHPicture.IsMatch(firstMessage) || BotInfo.HPictureUserCmd.Contains(firstMessage))
            {
                if (Cache.CheckPMLimit(qqId))
                {
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.HPictureOutOfLimitReply));
                    return;
                }
                if (Cache.CheckPMCD(qqId))
                {
                    await session.SendFriendMessageAsync(qqId, new PlainMessage(BotInfo.HPictureCDUnreadyReply));
                    return;
                }
                HPictureHandler.SendHPictures(session, firstMessage, BotInfo.HPictureAllowR18, BotInfo.ShabHPictureEndCmd, stream => session.UploadPictureAsync(UploadTarget.Friend, stream), msg => session.SendFriendMessageAsync(qqId, msg), limitType =>
                {
                    if (limitType == LimitType.Frequency)
                    {
                        Cache.RecordFriendCD(qqId);
                        if (BotInfo.HPictureLimitType == LimitType.Frequency)
                            Cache.RecordLimit(qqId);
                    }
                    else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)
                        Cache.RecordLimit(qqId);
                }, BotInfo.HPicturePMRevoke);
            }
            #endregion  -- Shab图库 --
            #endregion -- 色图 --
            else if (firstMessage == $"{BotInfo.BotName}帮助")
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
                if (BotInfo.QQId == 3246934384)
                {
                    lstEnabledFeatures.Add("查手机号");
                }
                string strHelpResult = $"现在您可以让我{string.Join("，", lstEnabledFeatures)}。\r\n如果您觉得{BotInfo.BotName}好用，请到{BotInfo.BotName}的项目地址 https://github.com/Alex1911-Jiang/GreenOnions 给{BotInfo.BotName}一颗星星。";
                await session.SendFriendMessageAsync(qqId, new PlainMessage(strHelpResult));
            }
            #region -- 查询手机号(夹带私货) --
            else if (regexSelectPhone.IsMatch(firstMessage))
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
                                    string result = AssemblyHelper.CallStaticMethod<string>("GreenOnions.QQPhone", "GreenOnions.QQPhone.QQAndPhone", lQQNumber == qqId ? "GetSelfPhoneByQQ" : "GetPhoneByQQ", lQQNumber);
                                    await session.SendFriendMessageAsync(qqId, new PlainMessage(result));
                                }
                                catch (Exception ex)
                                {
                                    await session.SendFriendMessageAsync(qqId, new PlainMessage("查询失败" + ex.Message));
                                }
                            }
                            else
                            {
                                await session.SendFriendMessageAsync(qqId, new PlainMessage("请输入正确的QQ号码(不支持以邮箱查询)"));
                            }
                        }
                    }
                }
            }
            #endregion -- 查询手机号(夹带私货) --
        }
    }
}
