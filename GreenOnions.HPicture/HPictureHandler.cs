using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TencentCloud.Ame.V20190916.Models;
using Yande.re.Api;

namespace GreenOnions.HPicture
{
    public static class HPictureHandler
    {
        /// <summary>
        /// 自定义命令的单张色图
        /// </summary>
        public static void SendOnlyOneHPictures(long senderId, long? senderGroup, Action<GreenOnionsMessages> SendMessage)
        {
            List<Action> randomSource = new List<Action>();
            if (BotInfo.EnabledHPictureSource.Contains(PictureSource.Lolicon))
            {
                randomSource.Add(async () =>
                {
                    string size = "original";
                    if (BotInfo.HPictureSize1200)
                        size = "regular";

                    string strHttpRequest = $@"https://api.lolicon.app/setu/v2?size={size}&proxy=i.{BotInfo.PixivProxy}";
                    await SendLoliconHPicture(senderId, senderGroup, strHttpRequest, size, SendMessage);
                });
            }
            if (BotInfo.EnabledHPictureSource.Contains(PictureSource.Yande_re))
            {
                randomSource.Add(() => SendYandeHPicture(senderId, senderGroup, 1, null, false, SendMessage));
            }
            if (randomSource.Count > 0)
            {
                Random rdmSource = new Random(Guid.NewGuid().GetHashCode());
                int iSource = rdmSource.Next(0, randomSource.Count);
                randomSource[iSource]();
            }
        }

        public static void SendHPictures(long senderId, long? senderGroup, Match matchMessage, Action<GreenOnionsMessages> SendMessage)
        {
            try
            {
                string size = "original";
                if (BotInfo.HPictureSize1200)
                    size = "regular";

                string strHttpRequest;

                #region -- 色图数量 --
                long lImgCount = 1;
                if (matchMessage.Groups["数量"].Success)
                {
                    string strCount = matchMessage.Groups["数量"].Value;
                    if (!long.TryParse(strCount, out lImgCount) && !string.IsNullOrEmpty(strCount))
                        lImgCount = StringHelper.Chinese2Num(strCount);
                }
                if (lImgCount <= 0)   //犯贱呢要0张或以下色图
                    return;

                if (lImgCount > BotInfo.HPictureOnceMessageMaxImageCount)
                    lImgCount = BotInfo.HPictureOnceMessageMaxImageCount;
                #endregion -- 色图数量 --

                #region -- 关键词 --
                string strKeyword = null;
                if (matchMessage.Groups["关键词"].Success)
                    strKeyword = matchMessage.Groups["关键词"].Value;

                if (BotInfo.HPictureShieldingWords.Contains(strKeyword))  //屏蔽词
                    return;

                #endregion  -- 关键词 --

                bool bR18 = false;

                #region -- R18 --
                if (matchMessage.Groups["r18"].Success)
                {
                    if (BotInfo.HPictureAllowR18)
                    {
                        bR18 = true;
                        if (senderGroup != null) //群聊
                        {
                            if (BotInfo.HPictureR18WhiteOnly && !BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))
                            {
                                return;  //仅限白名单但此群不在白名单中, 不响应R18命令
                            }
                        }
                    }
                    else
                    {
                        return;  //没开R18, 不响应R18命令
                    }
                }
                #endregion -- R18 --

                bool bNonSourceSuffix = false;
                if (!matchMessage.Groups.ContainsKey("色图后缀") && !matchMessage.Groups.ContainsKey("美图后缀"))
                    bNonSourceSuffix = true;  //命令不含任何后缀组

                PictureSource pictureSource = (PictureSource)(-1);
                if (bNonSourceSuffix)
                    pictureSource = (PictureSource)BotInfo.HPictureDefaultSource;

                if (matchMessage.Groups["色图后缀"].Success || BotInfo.EnabledHPictureSource.Contains(pictureSource))  //指定色图后缀或不含后缀组时使用色图
                {
                    if (!bNonSourceSuffix)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];
                    }

                    if (pictureSource == PictureSource.Lolicon)
                    {
                        string keyword = "";
                        if (!string.IsNullOrWhiteSpace(strKeyword))
                        {
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
                        strHttpRequest = $@"https://api.lolicon.app/setu/v2?num={lImgCount}&proxy=i.{BotInfo.PixivProxy}&r18={(bR18 ? "1" : "0")}{keyword}&size={size}";
                        _ = SendLoliconHPicture(senderId, senderGroup, strHttpRequest, size, SendMessage);
                    }
                    else if (pictureSource == PictureSource.Yande_re)
                    {
                        if (BotInfo.HPictureSendByForward)  //合并转发
                            ForwardSendYandeHPicture(senderId, senderGroup, lImgCount, strKeyword, bR18, SendMessage);
                        else
                            SendYandeHPicture(senderId, senderGroup, lImgCount, strKeyword, bR18, SendMessage);
                    }
                }
                else if (matchMessage.Groups["美图后缀"].Success || BotInfo.EnabledBeautyPictureSource.Contains(pictureSource))
                {
                    if (!bNonSourceSuffix)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        pictureSource = BotInfo.EnabledBeautyPictureSource[r.Next(0, BotInfo.EnabledBeautyPictureSource.Count)];
                    }

                    if (pictureSource == PictureSource.ELF)
                    {
                        strHttpRequest = string.IsNullOrEmpty(strKeyword) ? $@"http://159.75.48.23:5000/api/img/{lImgCount},0" : $@"http://159.75.48.23:5000/api/tag/{strKeyword},{lImgCount},0";
                        _ = SendELFHPicture(senderId, senderGroup, strHttpRequest, SendMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                SendMessage(BotInfo.HPictureErrorReply.ReplaceGreenOnionsStringTags() + ex.Message);
            }
        }

        #region -- Yande.re --

        /// <summary>
        /// 逐张发送Yande.re色图
        /// </summary>
        private static async void SendYandeHPicture(long senderId, long? senderGroup, long lImgCount, string strKeyword, bool bR18, Action<GreenOnionsMessages> SendMessage)
        {
            for (int i = 0; i < lImgCount; i++)
            {
                try
                {
                    YandeItem imgItem = await YandeApi.GetRandomHPictrue(strKeyword, bR18);
                    if (imgItem == null)
                    {
                        SendMessage(BotInfo.HPictureNoResultReply.ReplaceGreenOnionsStringTags());
                        return;
                    }
                    GreenOnionsMessages outMessage = CreateOnceYandeHPicture(imgItem);
                    SetRevokeTime(senderGroup, outMessage);  //设置撤回时间
                    SendMessage(outMessage);
                    RecordLimit(senderId, senderGroup, LimitType.Count);
                }
                catch (Exception ex)
                {
                    SendMessage(BotInfo.HPictureDownloadFailReply.ReplaceGreenOnionsStringTags() + ex.Message);
                }
            }
            RecordLimit(senderId, senderGroup, LimitType.Frequency);
        }

        /// <summary>
        /// 合并转发Yande.re色图
        /// </summary>
        private static async void ForwardSendYandeHPicture(long senderId, long? senderGroup, long lImgCount, string strKeyword, bool bR18, Action<GreenOnionsMessages> SendMessage)
        {
            try
            {
                List<GreenOnionsMessages> outMessages = new List<GreenOnionsMessages>();
                for (int i = 0; i < lImgCount; i++)
                {
                    YandeItem imgItem = await YandeApi.GetRandomHPictrue(strKeyword, bR18);
                    if (imgItem == null)
                    {
                        SendMessage(BotInfo.HPictureNoResultReply.ReplaceGreenOnionsStringTags());
                        return;
                    }
                    GreenOnionsMessages outMessage = CreateOnceYandeHPicture(imgItem);
                    outMessages.Add(outMessage);
                    RecordLimit(senderId, senderGroup, LimitType.Count);
                }
                if (outMessages.Count > 0)
                {
                    GreenOnionsForwardMessage[] forwardMessages = outMessages.Select(msg => new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, msg)).ToArray();
                    GreenOnionsMessages outForwardMsg = forwardMessages;
                    outForwardMsg.RevokeTime = outMessages.First().RevokeTime;
                    SetRevokeTime(senderGroup, outForwardMsg);  //设置撤回时间
                    SendMessage(outForwardMsg);  //合并转发
                    RecordLimit(senderId, senderGroup, LimitType.Frequency);
                }
            }
            catch (Exception ex)
            {
                SendMessage(BotInfo.HPictureDownloadFailReply.ReplaceGreenOnionsStringTags() + ex.Message);
            }
        }

        /// <summary>
        /// 使用Yande.re数据构造一条消息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static GreenOnionsMessages CreateOnceYandeHPicture(YandeItem item)
        {
            GreenOnionsMessages outMessage = new();
            StringBuilder sb = new();
            if (BotInfo.HPictureSendUrl)
                sb.AppendLine($"http://yande.re{item.ShowPageUrl}");
            if (BotInfo.HPictureSendTags)
                sb.AppendLine($"标签:{string.Join(", ", item.Tags)}");
            outMessage.Add(sb);
            string imgCacheName = Path.Combine(ImageHelper.ImagePath, $"{item.ShowPageUrl.Substring("/post/show/".Length)}.png");
            outMessage.Add(CreateImageMessage(item.BigImgUrl, imgCacheName));
            return outMessage;
        }

        #endregion -- Yande.re --

        #region -- Lolicon --

        private static async Task SendLoliconHPicture(long senderId, long? senderGroup, string strHttpRequestUrl, string sizeUrlName, Action<GreenOnionsMessages> SendMessage)
        {
            string resultValue = string.Empty;
            string errorMessage = string.Empty;
            try
            {
                resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);
            }
            catch (Exception ex)
            {
                errorMessage = BotInfo.HPictureErrorReply.ReplaceGreenOnionsStringTags() + ex.Message;
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                SendMessage(errorMessage);
            }

            JObject jo = JsonConvert.DeserializeObject<JObject>(resultValue);
            JToken jt = jo["data"];
            string err = jo["error"].ToString();
            if (!string.IsNullOrWhiteSpace(err))//Api错误
            {
                SendMessage(BotInfo.HPictureErrorReply.ReplaceGreenOnionsStringTags() + err);
            }

            if (jt.Count() == 0)//没找到对应词条的色图;
            {
                SendMessage(BotInfo.HPictureNoResultReply);  //没有结果
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
                LogHelper.WriteErrorLog("Lolicon响应解析失败");
                SendMessage(BotInfo.HPictureErrorReply.ReplaceGreenOnionsStringTags());  //发生错误
            }

            List<GreenOnionsMessages> outMessages = null;
            if (BotInfo.HPictureSendByForward)
                outMessages = new List<GreenOnionsMessages>();

            foreach (LoliconHPictureItem imgItem in enumImg)
            {
                GreenOnionsMessages outMessage = new GreenOnionsMessages();
                StringBuilder sb = new StringBuilder();
                if (BotInfo.HPictureSendUrl)
                    sb.AppendLine($"https://www.pixiv.net/artworks/{imgItem.ID} (p{imgItem.P})");
                if (BotInfo.HPictureSendTitle)
                    sb.AppendLine($"标题:{imgItem.Title}\r\n作者:{imgItem.Author}");
                if (BotInfo.HPictureSendTags)
                    sb.AppendLine($"标签:{imgItem.Tags}");
                outMessage.Add(sb);
                GreenOnionsImageMessage imgMsg = CreateOnceLoliconHPicture(imgItem);

                SetRevokeTime(senderGroup, outMessage);  //设置撤回时间

                outMessage.Add(imgMsg);
                if (BotInfo.HPictureSendByForward)
                    outMessages.Add(outMessage);
                else
                    SendMessage(outMessage);
                RecordLimit(senderId, senderGroup, LimitType.Count);
            }

            if (BotInfo.HPictureSendByForward && outMessages.Count > 0)
            {
                GreenOnionsForwardMessage[] forwardMessages = outMessages.Select(msg => new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, msg)).ToArray();
                GreenOnionsMessages outForwardMsg = forwardMessages;
                outForwardMsg.RevokeTime = outMessages.First().RevokeTime;
                SendMessage(outForwardMsg);  //合并转发
            }
            RecordLimit(senderId, senderGroup, LimitType.Frequency);
        }

        private static GreenOnionsImageMessage CreateOnceLoliconHPicture(LoliconHPictureItem item)
        {
            string imgCacheName = Path.Combine(ImageHelper.ImagePath, $"{item.ID}_{item.P}{(BotInfo.HPictureSize1200 ? "_1200" : "")}.png");
            return CreateImageMessage(item.URL, imgCacheName);
        }

        #endregion -- Lolicon --

        #region -- ELF --

        private static async Task SendELFHPicture(long senderId, long? senderGroup, string strHttpRequestUrl, Action<GreenOnionsMessages> SendMessage)
        {
            List<GreenOnionsMessages> outMessages = null;
            if (BotInfo.HPictureSendByForward)
                outMessages = new List<GreenOnionsMessages>();

            string resultValue = "";
            try
            {
                resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);

                JArray ja = (JArray)JsonConvert.DeserializeObject(resultValue);
                if (ja.Count == 0)
                {
                    SendMessage(BotInfo.HPictureNoResultReply);  //没有结果
                }

                IEnumerable<ELFHPictureItem> enumImg = ja.Select(i => new ELFHPictureItem(i["id"].ToString(), i["link"].ToString().Replace("pixiv.cat", BotInfo.PixivProxy), i["source"].ToString(), string.Join(",", i["jp_tag"].Select(s => s.ToString())), string.Join(",", i["zh_tags"].Select(s => s.ToString())), i["author"].ToString()));

                //包含twimg.com的图墙内无法访问, 暂时不处理
                foreach (ELFHPictureItem imgItem in enumImg)
                {
                    GreenOnionsMessages outMessage = new GreenOnionsMessages();
                    StringBuilder sb = new StringBuilder();
                    if (BotInfo.HPictureSendUrl)
                        sb.AppendLine(imgItem.Source);
                    if (BotInfo.HPictureSendTitle)
                        sb.AppendLine($"作者:{imgItem.Author}");
                    if (BotInfo.HPictureSendTags)
                    {
                        sb.AppendLine($"中文标签:{imgItem.Zh_Tags}");
                        sb.AppendLine($"日文标签:{imgItem.Jp_Tag}");
                    }
                    outMessage.Add(sb);
                    GreenOnionsImageMessage imgMsg = CreateOnceELFHPicture(imgItem);

                    SetRevokeTime(senderGroup, outMessage);

                    if (BotInfo.RevokeBeautyPicture)  //撤回美图
                        SetRevokeTime(senderGroup, outMessage);  //设置撤回时间

                    outMessage.Add(imgMsg);
                    if (BotInfo.HPictureSendByForward)
                        outMessages.Add(outMessage);
                    else
                        SendMessage(outMessage);
                    RecordLimit(senderId, senderGroup, LimitType.Count);
                }

                if (BotInfo.HPictureSendByForward && outMessages.Count > 0)
                {
                    GreenOnionsForwardMessage[] forwardMessages = outMessages.Select(msg => new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, msg)).ToArray();
                    GreenOnionsMessages outForwardMsg = forwardMessages;
                    outForwardMsg.RevokeTime = outMessages.First().RevokeTime;
                    SendMessage(forwardMessages);  //合并转发
                }
                RecordLimit(senderId, senderGroup, LimitType.Frequency);
            }
            catch (Exception ex)
            {
                SendMessage(BotInfo.HPictureErrorReply.ReplaceGreenOnionsStringTags() + ex.Message);  //发生错误
            }
        }

        private static GreenOnionsImageMessage CreateOnceELFHPicture(ELFHPictureItem item)
        {
            string imgCacheName = Path.Combine(ImageHelper.ImagePath, $"ELF_{item.ID}.png");
            return CreateImageMessage(item.Link, imgCacheName);
        }

        #endregion -- ELF --

        private static GreenOnionsImageMessage CreateImageMessage(string url, string cacheName)
        {
            GreenOnionsImageMessage imageMsg = null;
            if (File.Exists(cacheName) && new FileInfo(cacheName).Length > 0) //存在本地缓存时优先使用缓存
            {
                imageMsg = new GreenOnionsImageMessage(cacheName);  //上传图片
            }
            else
            {
                if (BotInfo.SendImageByFile)  //下载完成后发送文件
                {
                    HttpHelper.DownloadImageFile(url, cacheName);
                    if (File.Exists(cacheName))
                        imageMsg = new GreenOnionsImageMessage(cacheName);
                }
                else
                {
                    imageMsg = new GreenOnionsImageMessage(url);
                    if (BotInfo.DownloadImage4Caching)
                        HttpHelper.DownloadImageFileAsync(url, cacheName);  //下载图片用于缓存
                }
            }
            return imageMsg;
        }

        /// <summary>
        /// 设置消息撤回时间
        /// </summary>
        private static void SetRevokeTime(long? senderGroup, GreenOnionsMessages message)
        {
            if (senderGroup == null)
                message.RevokeTime = BotInfo.HPicturePMRevoke;  //私聊撤回
            else
            {
                if (BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))  //白名单群撤回
                    message.RevokeTime = BotInfo.HPictureWhiteRevoke;
                else
                    message.RevokeTime = BotInfo.HPictureRevoke;  //普通群撤回
            }
        }

        /// <summary>
        /// 设置次数限制和冷却时间
        /// </summary>
        private static void RecordLimit(long senderId, long? senderGroup, LimitType limitType)
        {
            if (BotInfo.HPictureLimitType == LimitType.Frequency && limitType == LimitType.Frequency)  //如果本次记录是计次, 说明地址消息已经成功发出, 可以记录CD
                Cache.RecordLimit(senderId);
            else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)  //如果本次记录是记张且设置是记张
                Cache.RecordLimit(senderId);

            if (senderGroup != null)  //群色图记录CD
                Cache.RecordGroupCD(senderId, senderGroup.Value);
            else
                Cache.RecordFriendCD(senderId);
        }
    }
}
