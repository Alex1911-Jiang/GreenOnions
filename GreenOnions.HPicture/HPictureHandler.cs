using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
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
        public static async Task SendOnlyOneHPictures(long senderId, long? senderGroup, Action<GreenOnionsMessages> SendMessage)
        {
            string size = "original";
            if (BotInfo.HPictureSize1200)
                size = "regular";

            string strHttpRequest = $@"https://api.lolicon.app/setu/v2?size={size}&proxy=i.{BotInfo.PixivProxy}";
            _ = SendLoliconHPhicture(senderId, senderGroup, strHttpRequest, size, SendMessage);
        }

        public static async Task SendHPictures(long senderId, long? senderGroup, Match matchMessage, Action<GreenOnionsMessages> SendMessage)
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

                if (!string.IsNullOrWhiteSpace(strKeyword) && strKeyword.Length >1)
                {
                    if (strKeyword.EndsWith("的"))
                        strKeyword = strKeyword.Remove(strKeyword.Length - 1, 1);
                }
                #endregion  -- 关键词 --

                string strR18 = "0";

                #region -- R18 --
                if (matchMessage.Groups["r18"].Success)
                {
                    if (BotInfo.HPictureAllowR18)
                    {
                        strR18 = "1";
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
                    bNonSourceSuffix = true;

                if (matchMessage.Groups["色图后缀"].Success || bNonSourceSuffix)
                {
                    Random r = new Random(Guid.NewGuid().GetHashCode());
                    PictureSource pictureSource = BotInfo.EnabledHPictureSource[r.Next(0, BotInfo.EnabledHPictureSource.Count)];

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
                        strHttpRequest = $@"https://api.lolicon.app/setu/v2?num={lImgCount}&proxy=i.{BotInfo.PixivProxy}&r18={strR18}{keyword}&size={size}";
                        _ = SendLoliconHPhicture(senderId, senderGroup, strHttpRequest, size, SendMessage);
                    }
                    else if (pictureSource == PictureSource.GreenOnions)
                    {

                    }
                }
                else if (matchMessage.Groups["美图后缀"].Success)
                {
                    Random r = new Random(Guid.NewGuid().GetHashCode());
                    PictureSource pictureSource = BotInfo.EnabledBeautyPictureSource[r.Next(0, BotInfo.EnabledBeautyPictureSource.Count)];

                    if (pictureSource == PictureSource.ELF)
                    {
                        strHttpRequest = string.IsNullOrEmpty(strKeyword) ? $@"http://159.75.48.23:5000/api/img/{lImgCount},0" : $@"http://159.75.48.23:5000/api/tag/{strKeyword},{lImgCount},0";
                        _ = SendELFHPicture(senderId, senderGroup, strHttpRequest, SendMessage);
                    }
                    else if (pictureSource == PictureSource.GreenOnions)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                SendMessage(BotInfo.HPictureErrorReply + ex.Message);
            }
        }

        private static async Task SendLoliconHPhicture(long senderId, long? senderGroup, string strHttpRequestUrl, string sizeUrlName, Action<GreenOnionsMessages> SendMessage)
        {
            string resultValue = string.Empty;
            string errorMessage = string.Empty;
            try
            {
                resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);
            }
            catch (Exception ex)
            {
                errorMessage = BotInfo.HPictureErrorReply + ex.Message;
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
                SendMessage(BotInfo.HPictureErrorReply + err);
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
                SendMessage(BotInfo.HPictureErrorReply);  //发生错误
            }

            List<GreenOnionsMessages> outMessages = null;
            if (BotInfo.HPictureSendByForward)
                outMessages = new List<GreenOnionsMessages>();

            RecordLimit(senderId, senderGroup, LimitType.Frequency);
            foreach (LoliconHPictureItem imgItem in enumImg)
            {
                GreenOnionsMessages outMessage = new GreenOnionsMessages();
                if (BotInfo.HPictureSendUrl)
                {
                    string addresses;
                    if (BotInfo.HPictureSendTags)
                        addresses = $"https://www.pixiv.net/artworks/{imgItem.ID} (p{imgItem.P})\r\n标题:{imgItem.Title}\r\n作者:{imgItem.Author}\r\n标签:{imgItem.Tags}";
                    else
                        addresses = $"https://www.pixiv.net/artworks/{imgItem.ID} (p{imgItem.P})";
                    outMessage.Add(addresses);
                }

                GreenOnionsImageMessage imgMsg = CreateOnceLoliconHPicture(imgItem);

                #region  -- 撤回时间 --
                if (senderGroup == null)
                    outMessage.RevokeTime = BotInfo.HPicturePMRevoke;  //私聊撤回
                else
                {
                    if (BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))  //白名单群撤回
                        outMessage.RevokeTime = BotInfo.HPictureWhiteRevoke;
                    else
                        outMessage.RevokeTime = BotInfo.HPictureRevoke;  //普通群撤回
                }
                #endregion  -- 撤回时间 --

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
        }

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
                    if (BotInfo.HPictureSendUrl)
                    {
                        string addresses;
                        if (BotInfo.HPictureSendTags)
                            addresses = $"{imgItem.Source}\r\n中文标签:{imgItem.Zh_Tags}\r\n日文标签:{imgItem.Jp_Tag}\r\n作者:{imgItem.Author}";
                        else
                            addresses = imgItem.Source;
                        outMessage.Add(addresses);
                        RecordLimit(senderId, senderGroup, LimitType.Frequency);
                    }

                    GreenOnionsImageMessage imgMsg = CreateOnceELFHPicture(imgItem);

                    #region  -- 撤回时间 --
                    if (BotInfo.RevokeBeautyPicture)
                    {
                        if (senderGroup == null)
                            outMessage.RevokeTime = BotInfo.HPicturePMRevoke;  //私聊撤回
                        else
                        {
                            if (BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))  //白名单群撤回
                                outMessage.RevokeTime = BotInfo.HPictureWhiteRevoke;
                            else
                                outMessage.RevokeTime = BotInfo.HPictureRevoke;  //普通群撤回
                        }
                    }
                    #endregion  -- 撤回时间 --

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
            }
            catch (Exception ex)
            {
                SendMessage(BotInfo.HPictureErrorReply + ex.Message);  //发生错误
            }
        }

        private static GreenOnionsImageMessage CreateOnceLoliconHPicture(LoliconHPictureItem item)
        {
            GreenOnionsImageMessage imageMsg;
            string imgName = Path.Combine(ImageHelper.ImagePath, $"{item.ID}_{item.P}{(BotInfo.HPictureSize1200 ? "_1200" : "")}.png");
            if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) //存在本地缓存时优先使用缓存
            {
                imageMsg = new GreenOnionsImageMessage(imgName);  //上传图片
            }
            else
            {
                if (BotInfo.SendImageByFile)  //下载完成后发送文件
                {
                    HttpHelper.DownloadImageFile(item.URL, imgName);
                    imageMsg = new GreenOnionsImageMessage(imgName);
                }
                else
                {
                    imageMsg = new GreenOnionsImageMessage(item.URL);
                    if (BotInfo.DownloadImage4Caching)
                        _ = Task.Run(() => HttpHelper.DownloadImageFile(item.URL, imgName));  //下载图片用于缓存
                }
            }
            return imageMsg;
        }

        private static GreenOnionsImageMessage CreateOnceELFHPicture(ELFHPictureItem item)
        {
            GreenOnionsImageMessage imageMsg;
            string imgName = Path.Combine(ImageHelper.ImagePath, $"ELF_{item.ID}.png");
            if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) //存在本地缓存时优先使用缓存
            {
                imageMsg = new GreenOnionsImageMessage(imgName);  //上传图片
            }
            else
            {
                if (BotInfo.SendImageByFile)  //下载完成后发送文件
                {
                    HttpHelper.DownloadImageFile(item.Link, imgName);
                    imageMsg = new GreenOnionsImageMessage(imgName);
                }
                else
                {
                    imageMsg = new GreenOnionsImageMessage(item.Link);
                    if (BotInfo.DownloadImage4Caching)
                        _ = Task.Run(() => HttpHelper.DownloadImageFile(item.Link, imgName));  //下载图片用于缓存
                }
            }
            return imageMsg;
        }

        private static void RecordLimit(long senderId, long? senderGroup, LimitType limitType)
        {
            if (limitType == LimitType.Frequency)  //如果本次记录是计次, 说明地址消息已经成功发出, 可以记录CD
            {
                if (senderGroup != null)  //群色图记录CD
                    Cache.RecordGroupCD(senderId, senderGroup.Value);
                else
                    Cache.RecordFriendCD(senderId);

                if (BotInfo.HPictureLimitType == LimitType.Frequency)  //如果设置是计次
                    Cache.RecordLimit(senderId);
            }
            else if (limitType == LimitType.Count && BotInfo.HPictureLimitType == LimitType.Count)  //如果本次记录是记张且设置是记张
                Cache.RecordLimit(senderId);
        }
    }
}
