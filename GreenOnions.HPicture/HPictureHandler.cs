using GreenOnions.Model;
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
        private static async Task<GreenOnionsMessageGroup> SendOnlyOneHPictures(long senderId, long? senderGroup)
        {
            string size = "original";
            if (BotInfo.HPictureSize1200)
                size = "regular";

            string strHttpRequest = $@"https://api.lolicon.app/setu/v2?size={size}&proxy=i.pixiv.re";
            return await SendLoliconHPhicture(senderId, senderGroup, strHttpRequest, size);
        }

        public static async Task<GreenOnionsMessageGroup> SendHPictures(long senderId, long? senderGroup, string message, PictureSource pictureSource)
        {
            try
            {
                string size = "original";
                if (BotInfo.HPictureSize1200)
                    size = "regular";

                string strHttpRequest;
                //if (BotInfo.HPictureUserCmd.Contains(message))  //自定义色图命令
                //{
                //    strHttpRequest = $@"https://api.lolicon.app/setu/v2?size={size}&proxy=i.pixiv.re";
                //    return await SendLoliconHPhicture(strHttpRequest, size);
                //}
                //else  //标准色图命令
                //{
                    //分割请求接口所需的参数
                    long lImgCount = 1;
                    string strR18 = "0";

                    #region -- R18 --
                    string r18Cmd = BotInfo.HPictureR18Cmd.ReplaceGreenOnionsTags();
                    if (r18Cmd[0] == '(' && r18Cmd[r18Cmd.Length - 2] == ')' && r18Cmd[r18Cmd.Length - 1] == '?')
                        r18Cmd = r18Cmd.Substring(1, r18Cmd.Length - 3);

                    Regex rxR18 = new Regex(r18Cmd);
                    if (rxR18.IsMatch(message))
                    {
                        strR18 = "1";
                        if (BotInfo.HPictureAllowR18)
                        {
                            if (senderGroup != null) //群聊
                            {
                                if (BotInfo.HPictureR18WhiteOnly && !BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))
                                {
                                    return null;  //仅限白名单但此群不在白名单中, 不响应R18命令
                                }
                            }
                        }
                        else
                        {
                            return null;  //没开R18, 不响应R18命令
                        }
                    }
                    #endregion -- R18 --

                    #region -- 色图数量 -- 
                    string strCount = StringHelper.GetRegex(message,
                        BotInfo.HPictureBeginCmd.ReplaceGreenOnionsTags(),
                        BotInfo.HPictureCountCmd.ReplaceGreenOnionsTags(),
                        BotInfo.HPictureUnitCmd.ReplaceGreenOnionsTags()
                    );

                    if (!long.TryParse(strCount, out lImgCount) && !string.IsNullOrEmpty(strCount))
                        lImgCount = StringHelper.Chinese2Num(strCount);

                    if (string.IsNullOrEmpty(strCount))
                        lImgCount = 1;

                    if (lImgCount <= 0)   //犯贱呢要0张或以下色图
                        return null;

                    if (lImgCount > BotInfo.HPictureOnceMessageMaxImageCount)
                        lImgCount = BotInfo.HPictureOnceMessageMaxImageCount;

                    #endregion -- 色图数量 -- 

                    #region -- 关键词 --
                    string strKeyword = StringHelper.GetRegexBySub(message, new[]
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
                        return await SendLoliconHPhicture(senderId, senderGroup, strHttpRequest, size);
                    }
                    else if (pictureSource == PictureSource.ELF)
                    {
                        strHttpRequest = string.IsNullOrEmpty(strKeyword) ? $@"http://159.75.48.23:5000/api/img/{lImgCount},0" : $@"http://159.75.48.23:5000/api/tag/{strKeyword},{lImgCount},0";
                        return await SendELFHPicture(senderId, senderGroup, strHttpRequest);
                    }
                    else if (pictureSource == PictureSource.GreenOnions)
                    {

                    }
                //}
                return null;
            }
            catch (Exception ex)
            {
                return BotInfo.HPictureErrorReply + ex.Message;
            }
        }

        private static async Task<GreenOnionsMessageGroup> SendLoliconHPhicture(long senderId, long? senderGroup, string strHttpRequestUrl, string sizeUrlName)
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
                return errorMessage;
            }

            JObject jo = (JObject)JsonConvert.DeserializeObject(resultValue);
            JToken jt = jo["data"];
            string err = jo["error"].ToString();
            if (!string.IsNullOrWhiteSpace(err))//Api错误
            {
                return BotInfo.HPictureErrorReply + err;
            }

            if (jt.Count() == 0)//没找到对应词条的色图;
            {
                return BotInfo.HPictureNoResultReply;  //没有结果
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
                return BotInfo.HPictureErrorReply;  //发生错误
            }

            GreenOnionsMessageGroup outMessage = new GreenOnionsMessageGroup();

            if (true)  //TODO: 发送地址设置
            {
                string addresses;
                if (true)  //TODO: 是否发送标签设置
                {
                    addresses = string.Join("\r\n", enumImg.Select(i => $@"https://www.pixiv.net/artworks/{i.ID} (p{i.P})\r\n标题:{i.Title}\r\n作者:{i.Author}\r\n标签:{i.Tags}"));
                }
                else
                {
                    addresses = string.Join("\r\n", enumImg.Select(i => $@"https://www.pixiv.net/artworks/{i.ID} (p{i.P})"));
                }
                outMessage.Add(addresses);
                RecordLimit(senderId, senderGroup, LimitType.Frequency);
            }

            foreach (LoliconHPictureItem imgItem in enumImg)
            {
                GreenOnionsImageMessage imgMsg = CreateOnceLoliconHPicture(imgItem);
                if (senderGroup == null)
                    imgMsg.RevokeTime = BotInfo.HPicturePMRevoke;
                else
                {
                    if (BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))
                        imgMsg.RevokeTime = BotInfo.HPictureWhiteRevoke;
                    else
                        imgMsg.RevokeTime = BotInfo.HPictureRevoke;
                }
                outMessage.Add(imgMsg);
                RecordLimit(senderId, senderGroup, LimitType.Count);
            }
            return outMessage;
        }

        private static async Task<GreenOnionsMessageGroup> SendELFHPicture(long senderId, long? senderGroup, string strHttpRequestUrl)
        {
            GreenOnionsMessageGroup outMessage = new GreenOnionsMessageGroup();
            string resultValue = "";
            try
            {
                resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);

                JArray ja = (JArray)JsonConvert.DeserializeObject(resultValue);
                if (ja.Count == 0)
                {
                    return BotInfo.HPictureNoResultReply;  //没有结果
                }

                IEnumerable<ELFHPictureItem> enumImg = ja.Select(i => new ELFHPictureItem(i["id"].ToString(), i["link"].ToString(), i["source"].ToString(), string.Join(",", i["jp_tag"].Select(s => s.ToString())), string.Join(",", i["zh_tags"].Select(s => s.ToString())), i["author"].ToString()));
                if (true)  //TODO: 发送地址设置
                {
                    string addresses;
                    if (true)  //TODO: 是否发送标签设置
                    {
                        addresses = string.Join("\r\n", enumImg.Select(l => $@"{l.Source}\r\n中文标签:{l.Zh_Tags}\r\n日文标签:{l.Jp_Tag}\r\n作者:{l.Author}"));
                    }
                    else
                    {
                        addresses = string.Join("\r\n", enumImg.Select(l => l.Source));
                    }
                    outMessage.Add(addresses);
                    RecordLimit(senderId, senderGroup, LimitType.Frequency);
                }
                //包含twimg.com的图墙内无法访问, 暂时不处理
                foreach (ELFHPictureItem imgItem in enumImg)
                {
                    GreenOnionsImageMessage imgMsg = CreateOnceELFHPicture(imgItem);
                    if (BotInfo.RevokeBeautyPicture)
                    {
                        if (senderGroup == null)
                            imgMsg.RevokeTime = BotInfo.HPicturePMRevoke;
                        else
                        {
                            if (BotInfo.HPictureWhiteGroup.Contains(senderGroup.Value))
                                imgMsg.RevokeTime = BotInfo.HPictureWhiteRevoke;
                            else
                                imgMsg.RevokeTime = BotInfo.HPictureRevoke;
                        }
                    }
                    outMessage.Add(imgMsg);
                    RecordLimit(senderId, senderGroup, LimitType.Count);
                }
                return outMessage;
            }
            catch (Exception ex)
            {
                return BotInfo.HPictureErrorReply + ex.Message;  //发生错误
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
                imageMsg = new GreenOnionsImageMessage(item.URL);
                _ = Task.Run(() => HttpHelper.DownloadImageFile(item.URL, imgName));  //仅归档
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
                imageMsg = new GreenOnionsImageMessage(item.Link);
                _ = Task.Run(() => HttpHelper.DownloadImageFile(item.Link, imgName));  //仅归档
            }
            return imageMsg;
        }

        private static void RecordLimit(long senderId, long? senderGroup, LimitType limitType)
        {
            if (limitType == LimitType.Frequency)  //如果本次记录是计次, 说明地址消息已经成功发出, 可以记录CD
            {
                if (senderGroup != null)  //群色图记录CD
                {
                    Cache.RecordGroupCD(senderId, senderGroup.Value);
                }
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
