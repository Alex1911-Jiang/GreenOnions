using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.HPicture
{
    public static class HPictureHandler
    {
        public static void SendHPictures(IBaseInfo sender, PictureSource pictureSource, string pictureEndCmd, bool allowR18, string msg, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture, Action<int> RevokeMessage)
        {
            HPictureHandler.SendHPictureInner(sender, msg, pictureSource, allowR18, pictureEndCmd, UploadPicture, SendMessage, limitType =>
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
            }, RevokeMessage);
        }

        private static void SendHPictureInner(IBaseInfo sender, string message, PictureSource pictureSource, bool isAllowR18, string PictureEndCmd, Func<Stream, Task<IImageMessage>> UploadPicture, Func<IChatMessage[], bool, Task<int>> SendMessage, Action<LimitType> Record, Action<int> RevokeMessage)
        {
            try
            {
                string size = "original";
                if (BotInfo.HPictureSize1200)
                    size = "regular";

                string strHttpRequest;
                if (BotInfo.HPictureUserCmd.Contains(message))
                {
                    strHttpRequest = $@"https://api.lolicon.app/setu/v2?size={size}&proxy=i.pixiv.re";
                    SendLoliconHPhicture(strHttpRequest, size);
                }
                else
                {
                    //分割请求接口所需的参数
                    long lImgCount = 1;
                    string strR18 = "0";

                    #region -- R18 --
                    string r18Cmd = BotInfo.HPictureR18Cmd.ReplaceGreenOnionsTags();
                    if (r18Cmd[0] == '(' && r18Cmd[r18Cmd.Length - 2] == ')' && r18Cmd[r18Cmd.Length-1]=='?')
                        r18Cmd = r18Cmd.Substring(1, r18Cmd.Length - 3);

                    Regex rxR18 = new Regex(r18Cmd);
                    if (rxR18.IsMatch(message))
                    {
                        if (sender is IGroupMemberInfo)
                            if (BotInfo.HPictureR18WhiteOnly && !BotInfo.HPictureWhiteGroup.Contains(((IGroupMemberInfo)sender).Group.Id))
                                return;
                        strR18 = "1";
                    }

                    if (!isAllowR18)
                        strR18 = "0";//如果不允许R18
                    #endregion -- R18 --

                    #region -- 色图数量 -- 
                    string strCount = StringHelper.GetRegex(message, new[] 
                    {
                        BotInfo.HPictureBeginCmd.ReplaceGreenOnionsTags()
                    }, 
                    BotInfo.HPictureCountCmd.ReplaceGreenOnionsTags(), new[] 
                    { 
                        BotInfo.HPictureUnitCmd.ReplaceGreenOnionsTags(),
                        BotInfo.HPictureR18Cmd.ReplaceGreenOnionsTags(),
                        BotInfo.HPictureKeywordCmd.ReplaceGreenOnionsTags(),
                        pictureSource == PictureSource.Lolicon ? BotInfo.HPictureEndCmd.ReplaceGreenOnionsTags() : BotInfo.BeautyPictureEndCmd.ReplaceGreenOnionsTags(),
                    });

                    if (!long.TryParse(strCount, out lImgCount) && !string.IsNullOrEmpty(strCount)) 
                        lImgCount = StringHelper.Chinese2Num(strCount);

                    if (string.IsNullOrEmpty(strCount)) 
                        lImgCount = 1;

                    if (lImgCount <= 0)   //犯贱呢要0张或以下色图
                        return;

                    if (lImgCount > BotInfo.HPictureOnceMessageMaxImageCount) 
                        lImgCount = BotInfo.HPictureOnceMessageMaxImageCount;

                    #endregion -- 色图数量 -- 

                    #region -- 关键词 --
                    string strKeyword = StringHelper.GetRegex(message, new[] 
                    { 
                        BotInfo.HPictureBeginCmd.ReplaceGreenOnionsTags(),
                        BotInfo.HPictureCountCmd.ReplaceGreenOnionsTags(),
                        BotInfo.HPictureUnitCmd.ReplaceGreenOnionsTags(), 
                        BotInfo.HPictureR18Cmd.ReplaceGreenOnionsTags()
                    },
                    BotInfo.HPictureKeywordCmd, 
                    new[] 
                    { 
                        BotInfo.HPictureR18Cmd.ReplaceGreenOnionsTags(),
                        pictureSource == PictureSource.Lolicon ? BotInfo.HPictureEndCmd.ReplaceGreenOnionsTags() : BotInfo.BeautyPictureEndCmd.ReplaceGreenOnionsTags(),
                    });
                    #endregion -- 关键词 --
                    if (pictureSource == PictureSource.Lolicon)
                    {
                        string keyword = "";
                        if (!string.IsNullOrWhiteSpace(strKeyword))
                        {
                            if (strKeyword.EndsWith("的"))
                                strKeyword = strKeyword.Substring(0, strKeyword.Length - 1);

                            if (strKeyword.Contains("&") || strKeyword.Contains("|"))
                            {
                                string[] ands = strKeyword.Split("&");
                                keyword = "&tag=" + string.Join("&tag=", ands);
                            }
                            else
                            {
                                keyword = "&keyword=" + strKeyword;
                            }
                        }

                        strHttpRequest = $@"https://api.lolicon.app/setu/v2?num={lImgCount}&proxy=i.pixiv.re&r18={strR18}{keyword}&size={size}";
                        SendLoliconHPhicture(strHttpRequest, size);
                    }
                    else if (pictureSource == PictureSource.ELF)
                    {
                        strHttpRequest = string.IsNullOrEmpty(strKeyword) ? $@"http://159.75.48.23:5000/api/img/{lImgCount},{strR18}" : $@"http://159.75.48.23:5000/api/tag/{strKeyword},{lImgCount},{strR18}";
                        SendELFHPicture(strHttpRequest);
                    }
                    else if (pictureSource == PictureSource.GreenOnions)
                    {

                    }
                }

                async void SendLoliconHPhicture(string strHttpRequestUrl, string sizeUrlName)
                {
                    string resultValue = "";
                    try
                    {
                        resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);
                    }
                    catch (Exception ex)
                    {
                        _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, true);
                        return;
                    }

                    JObject jo = (JObject)JsonConvert.DeserializeObject(resultValue);
                    JToken jt = jo["data"];
                    string err = jo["error"].ToString();
                    if (!string.IsNullOrWhiteSpace(err))//Api错误
                    {
                        _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(err) }, true);
                        return;
                    }
                    
                    if (jt.Count() == 0)//没找到对应词条的色图;
                    {
                        _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureNoResultReply) }, true);  //没有结果
                        return;
                    }

                    IEnumerable<LoliconHPictureItem> enumImg = jt.Select(i => new LoliconHPictureItem(
                        i["p"].ToString(), 
                        i["pid"].ToString(),
                        i["urls"][sizeUrlName].ToString(),
                        i["title"].ToString(),
                        i["author"].ToString(),
                        string.Join(",", (i["tags"] as JArray)),
                        @$"https://www.pixiv.net/artworks/{i["pid"]}(p{i["p"]})")
                    );

                    if (enumImg == null)
                    {
                        _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply) }, true);  //发生错误
                        return;
                    }

                    //发送地址和标签
                    string addresses = string.Join("\r\n", enumImg.Select(i => @"https://www.pixiv.net/artworks/" + i.ID + $" (p{i.P})\r\n标题:{i.Title}\r\n作者:{i.Author}\r\n标签:{i.Tags}"));
                    await SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(addresses) }, true).ContinueWith(_=> Record(LimitType.Frequency));

                    foreach (LoliconHPictureItem imgItem in enumImg)
                    {
                        SendOnceHPicture(() => SendOnceLoliconHPicture(imgItem));
                    }
                }

                async void SendELFHPicture(string strHttpRequestUrl)
                {
                    string resultValue = "";
                    try
                    {
                        resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);

                        JArray ja = (JArray)JsonConvert.DeserializeObject(resultValue);
                        if (ja.Count == 0)
                        {
                            _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureNoResultReply) }, true);  //没有结果
                            return;
                        }
                        IEnumerable<ELFHPictureItem> enumImg = ja.Select(i => new ELFHPictureItem(i["id"].ToString(), i["link"].ToString(), i["source"].ToString(), string.Join(",", i["jp_tag"].Select(s => s.ToString())), string.Join(",", i["zh_tags"].Select(s => s.ToString())), i["author"].ToString()));
                        string addresses = string.Join("\r\n", enumImg.Select(l => l.Source));
                        _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(addresses) }, true);
                        //包含twimg.com的图墙内无法访问, 暂时不处理
                        SendOnceHPicture(() => SendOnceELFHPicture(enumImg));
                    }
                    catch (Exception ex)
                    {
                        _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, true);  //发生错误
                        return;
                    }
                }

                //发送图片
                void SendOnceHPicture(Action SendHPictureInner)
                {
                    if (BotInfo.HPictureMultithreading)
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                SendHPictureInner();
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteErrorLog(ex);
                                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, false);
                            }
                        });
                    }
                    else
                    {
                        try
                        {
                            SendHPictureInner();
                        }
                        catch (Exception ex)
                        {
                            SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, false);
                        }
                    }
                }

                async void SendOnceLoliconHPicture(LoliconHPictureItem item)
                {
                    IImageMessage imageMessage = null;
                    try
                    {
                        string imgName = Path.Combine(ImageHelper.ImagePath, $"{item.ID}_{item.P}{(BotInfo.HPictureSize1200 ? "_1200" : "")}.png");
                        if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) //存在本地缓存时优先使用缓存
                        {
                            imageMessage = await UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read));  //上传图片
                        }
                        else
                        {
                            MemoryStream ms = await HttpHelper.DownloadImageAsMemoryStream(item.URL);

                            if (ms != null)
                            {
                                if (BotInfo.HPictureAntiShielding)
                                {
                                    ms = ms.StreamAntiShielding();
                                }
                                MemoryStream tempMs = new MemoryStream(ms.ToArray());  //不重新new一次的话上传的时候解码会为空
                                ms.Dispose();
                                ms = tempMs;
                            }
                            else
                            {
                                _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureDownloadFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("URL", item.Address))) }, true);  //下载失败
                                return;
                            }
                            imageMessage = await UploadPicture(ms);  //上传图片
                            ms.Dispose();
                        }

                        _ = SendMessage(new[] { imageMessage }, false).ContinueWith(msg =>
                        {
                            Record(LimitType.Count);  //记录冷却时间
                            RevokeMessage(msg.Result);
                        });
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage($"Lolicon色图下载失败, 地址为:{item.URL}", ex);
                    }
                }

                async void SendOnceELFHPicture(IEnumerable<ELFHPictureItem> items)
                {
                    foreach (var item in items)
                    {
                        IChatMessage imageMessage = null;
                        try
                        {
                            string imgName = Path.Combine(ImageHelper.ImagePath, $"ELF_{item.ID}.png");
                            if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) //存在本地缓存时优先使用缓存
                            {
                                imageMessage = await UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read));  //上传图片
                            }
                            else
                            {
                                MemoryStream ms = await HttpHelper.DownloadImageAsMemoryStream(item.Link);

                                if (BotInfo.HPictureAntiShielding)
                                {
                                    ms = ms.StreamAntiShielding();
                                }

                                if (ms == null)
                                {
                                    _ = SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureDownloadFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("URL", item.Link))) }, true);
                                    return;
                                }

                                MemoryStream tempMs = new MemoryStream(ms.ToArray());  //不重新new一次的话上传的时候解码会为空
                                ms.Dispose();
                                ms = tempMs;
                                imageMessage = await UploadPicture(ms);  //上传图片
                                ms.Dispose();
                            }
                            _ = SendMessage(new IChatMessage[] { imageMessage, new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage($"地址:{item.Source}\r\n日文标签:{item.Jp_Tag}\r\n中文标签:{item.Zh_Tags}\r\n作者:{item.Author}") }, false)
                                .ContinueWith(_ => Record(LimitType.Count)); //记录冷却时间
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteErrorLogWithUserMessage($"ELF美图下载失败, 地址为:{item.Link}", ex);
                            imageMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage("图片下载失败。\r\n");
                            _ = SendMessage(new IChatMessage[] { imageMessage }, false);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, true);
            }
        }
    }
}
