using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using GreenOnions.Interface;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using GreenOnions.Utility.Items;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.RSS
{
    public static class RssHelper
    {
        public static async void StartRssTask(GreenOnionsApi api)
        {
            LogHelper.WriteInfoLog("启动RSS功能");
            if (BotInfo.RssEnabled && BotInfo.IsLogin)
            {
                LogHelper.WriteInfoLog("启动RSS抓取线程");
                LogHelper.WriteInfoLog($"{BotInfo.RssEnabled},{BotInfo.IsLogin}");
                while (BotInfo.RssEnabled && BotInfo.IsLogin)
                {
                    LogHelper.WriteInfoLog($"存在{BotInfo.RssSubscription.Count()}条订阅地址");

                    if (BotInfo.RssParallel)
                    {
                        Parallel.ForEach(BotInfo.RssSubscription, async item =>  //若干条订阅地址
                        {
                            RssInner(item, api);
                            await Task.Delay((int)Math.Round(BotInfo.ReadRssInterval * 1000 * 60));
                        });
                    }
                    else
                    {
                        foreach (RssSubscriptionItem item in BotInfo.RssSubscription)  //若干条订阅地址
                        {
                            RssInner(item, api);
                            await Task.Delay((int)Math.Round(BotInfo.ReadRssInterval * 1000 * 60));
                        }
                    }
                }
            }
        }

        private static async void RssInner(RssSubscriptionItem item, GreenOnionsApi api)
        {
            LogHelper.WriteInfoLog(item.Url);
            //如果在调试模式并且转发的QQ和群组均不在管理员和调试群组集合中时不去请求
            if (BotInfo.DebugMode && ((BotInfo.DebugReplyAdminOnly && item.ForwardQQs.Intersect(BotInfo.AdminQQ).Count() == 0) || (BotInfo.OnlyReplyDebugGroup && item.ForwardGroups.Intersect(BotInfo.DebugGroups).Count() == 0)))
            {
                LogHelper.WriteWarningLog("没有为订阅源设置转发目标或当前处于调试模式, 不进行转发");
                return;
            }
            if ((item.ForwardGroups == null || item.ForwardGroups.Length == 0) && (item.ForwardGroups == null || item.ForwardQQs.Length == 0))
            {
                LogHelper.WriteInfoLog($"没有要转发的群和好友, 不进行抓取");
                return;
            }
            if (!Cache.LastOneSendRssTime.ContainsKey(item.Url))  //如果不存在上次发送的日期记录
            {
                LogHelper.WriteInfoLog($"首次抓取到{item.Url}内容, 只保存不发送, 防止内容太多刷屏");
                Cache.LastOneSendRssTime.TryAdd(item.Url, DateTime.Now);  //添加现在作为起始日期(避免把所有历史信息全都抓过来发送)
                Cache.LastOneSendRssTime = Cache.LastOneSendRssTime;
                ConfigHelper.SaveCacheFile();
                return;
            }

            try
            {
                LogHelper.WriteInfoLog($"抓取地址:{item.Url}");
                foreach (var rss in ReadRss(item.Url))  //每条订阅地址可能获取到若干条更新
                {
                    if (rss.pubDate > Cache.LastOneSendRssTime[item.Url])
                    {
                        LogHelper.WriteInfoLog($"更新时间晚于记录时间, 需要推送消息");

                        bool bSend = false;
                        int bContainCount = 0;
                        switch (item.FilterMode)
                        {
                            case 0:  //不过滤
                                bSend = true;
                                break;
                            case 1:  //包含任意发送
                                for (int i = 0; i < item.FilterKeyWords.Length; i++)
                                {
                                    if (rss.description.Contains(item.FilterKeyWords[i]))
                                    {
                                        bSend = true;
                                        break;
                                    }
                                }
                                break;
                            case 2:  //包含所有发送
                                for (int i = 0; i < item.FilterKeyWords.Length; i++)
                                {
                                    if (rss.description.Contains(item.FilterKeyWords[i]))
                                        bContainCount++;
                                }
                                if (bContainCount == item.FilterKeyWords.Length)
                                    bSend = true;
                                break;
                            case 3:  //包含任意不发送
                                bSend = true;
                                for (int i = 0; i < item.FilterKeyWords.Length; i++)
                                {
                                    if (rss.description.Contains(item.FilterKeyWords[i]))
                                    {
                                        bSend = false;
                                        break;
                                    }
                                }
                                break;
                            case 4:  //包含所有不发送
                                bSend = true;
                                for (int i = 0; i < item.FilterKeyWords.Length; i++)
                                {
                                    if (rss.description.Contains(item.FilterKeyWords[i]))
                                        bContainCount++;
                                }
                                if (bContainCount == item.FilterKeyWords.Length)
                                    bSend = false;
                                break;
                        }
                        if (!bSend)
                            continue;

                        string titleMsg = $"{rss.title}更新啦:\r\n{rss.description}";
                        string translateMsg = null;
                        if (item.Translate)
                        {
                            LogHelper.WriteInfoLog($"本条RSS订阅启用了翻译");
                            string translatedText;
                            if (item.TranslateFromTo)
                                translatedText = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateFromTo(rss.description, item.TranslateFrom, item.TranslateTo) : YouDaoTranslateHelper.TranslateFromTo(rss.description, item.TranslateFrom, item.TranslateTo));
                            else
                                translatedText = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateToChinese(rss.description) : YouDaoTranslateHelper.TranslateToChinese(rss.description));
                            translateMsg = $"\r\n以下为翻译内容:\r\n{ translatedText }\r\n";
                            LogHelper.WriteInfoLog($"翻译成功");
                        }
                        string thuImgUrl = null;
                        if (BotInfo.RssSendLiveCover)  //获取直播封面
                        {
                            if (item.Url.Contains("bilibili") && item.Url.Contains("/room/"))
                            {
                                string roomId = item.Url.Substring(item.Url.LastIndexOf("/room/") + "/room/".Length);
                                string apiResult = await HttpHelper.GetHttpResponseStringAsync($@"https://api.live.bilibili.com/xlive/web-room/v1/index/getInfoByRoom?room_id={roomId}");
                                JObject jo = JsonConvert.DeserializeObject<JObject>(apiResult);
                                thuImgUrl = jo?["data"]?["room_info"]?["cover"]?.ToString();
                            }
                        }
                        LogHelper.WriteInfoLog($"需要转发的组:{item.ForwardGroups.Length}个");
                        if (item.ForwardGroups.Length > 0)
                        {
                            GreenOnionsMessages groupResultMsg = new GreenOnionsMessages();

                            if (item.AtAll)
                            {
                                groupResultMsg.Add(new GreenOnionsAtMessage(-1, "全体成员"));
                                groupResultMsg.Add("\r\n");
                            }

                            groupResultMsg.Add(titleMsg);
                            if (translateMsg != null)
                                groupResultMsg.Add(translateMsg);
                            for (int i = 0; i < rss.imgsSrc.Length; i++)
                            {
                                groupResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(rss.imgsSrc[i])));
                            }

                            if (rss.videosSrc.Length > 0)
                            {
                                groupResultMsg.Add("视频地址:\r\n");
                                for (int i = 0; i < rss.videosSrc.Length; i++)
                                {
                                    groupResultMsg.Add(rss.videosSrc[i]);
                                }
                            }

                            if (thuImgUrl != null)
                                groupResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(thuImgUrl)));

                            groupResultMsg.Add($"\r\n更新时间:{rss.pubDate}");
                            groupResultMsg.Add($"\r\n原文地址:{rss.link}");

                            LogHelper.WriteInfoLog($"组合群消息完成");

                            if (item.SendByForward)
                            {
                                LogHelper.WriteInfoLog($"发送模式为合并转发");
                                GreenOnionsForwardMessage greenOnionsForwardMessage = new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, groupResultMsg);

                                for (int i = 0; i < item.ForwardGroups.Length; i++)
                                {
                                    await api.SendGroupMessageAsync(item.ForwardGroups[i], greenOnionsForwardMessage);
                                }
                            }
                            else
                            {
                                LogHelper.WriteInfoLog($"发送模式为直接发送");
                                for (int i = 0; i < item.ForwardGroups.Length; i++)
                                {
                                    await api.SendGroupMessageAsync(item.ForwardGroups[i], groupResultMsg);
                                }
                            }
                            LogHelper.WriteInfoLog($"全部群消息发送完毕");
                        }
                        LogHelper.WriteInfoLog($"需要转发的好友:{item.ForwardQQs.Length}个");
                        if (item.ForwardQQs.Length > 0)
                        {
                            GreenOnionsMessages friendResultMsg = new GreenOnionsMessages();

                            friendResultMsg.Add(titleMsg);
                            if (translateMsg != null)
                                friendResultMsg.Add(translateMsg);

                            for (int i = 0; i < rss.imgsSrc.Length; i++)
                            {
                                friendResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(rss.imgsSrc[i])));
                            }
                            if (rss.videosSrc.Length > 0)
                            {
                                friendResultMsg.Add("视频地址:\r\n");
                                for (int i = 0; i < rss.videosSrc.Length; i++)
                                {
                                    friendResultMsg.Add(rss.videosSrc[i]);
                                }
                            }

                            if (thuImgUrl != null)
                                friendResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(thuImgUrl)));
                            friendResultMsg.Add($"\r\n更新时间:{rss.pubDate}");
                            friendResultMsg.Add($"\r\n原文地址:{rss.link}");

                            LogHelper.WriteInfoLog($"组合好友消息完成");

                            if (item.SendByForward)
                            {
                                LogHelper.WriteInfoLog($"发送模式为合并转发");
                                GreenOnionsForwardMessage greenOnionsForwardMessage = new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, friendResultMsg);
                                for (int i = 0; i < item.ForwardQQs.Length; i++)
                                {
                                    await api.SendFriendMessageAsync(item.ForwardQQs[i], greenOnionsForwardMessage);
                                }
                            }
                            else
                            {
                                LogHelper.WriteInfoLog($"发送模式为直接发送");
                                for (int i = 0; i < item.ForwardQQs.Length; i++)
                                {
                                    await api.SendFriendMessageAsync(item.ForwardQQs[i], friendResultMsg);
                                }
                            }
                            LogHelper.WriteInfoLog($"全部好友消息发送完毕");
                        }

                        if (Cache.LastOneSendRssTime.ContainsKey(item.Url))
                            Cache.LastOneSendRssTime[item.Url] = rss.pubDate;
                        else
                            Cache.LastOneSendRssTime.TryAdd(item.Url, rss.pubDate);  //群和好友均推送完毕后记录此地址的最后更新时间
                        Cache.LastOneSendRssTime = Cache.LastOneSendRssTime;
                        ConfigHelper.SaveCacheFile();

                        LogHelper.WriteInfoLog($"记录{item.Url}最后更新时间完毕");

                        //if (rss.iframseSrc.Length > 0)  //视频或内嵌网页没想好怎么处理
                        //{

                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLogWithUserMessage("获取RSS错误", ex, $"请求地址为:{item.Url}");
            }
        }

        private static async Task<string> GetImgUrlOrFileNameAsync(string url)
        {
            if (BotInfo.SendImageByFile)  //下载完成后发送文件
            {
                string imgName = Path.Combine(ImageHelper.ImagePath, $"RSS_{Path.GetFileName(url)}");
                await HttpHelper.DownloadImageFileAsync(url, imgName);
                if (File.Exists(imgName))
                    return imgName;
            }
            return url;
        }

        private static IEnumerable<(string title, string description, string[] imgsSrc, string[] videosSrc, string[] iframseSrc, DateTime pubDate, string link)> ReadRss(string url)
        {
            if (url != string.Empty)
            {
                LogHelper.WriteInfoLog($"准备请求{url}抓取更新");
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                string title = doc.GetElementsByTagName("title")[0].InnerText;
                XmlNodeList nodeList = doc.GetElementsByTagName("item");
                if (doc.HasChildNodes)
                {
                    LogHelper.WriteInfoLog($"抓取成功");
                    foreach (XmlNode node in nodeList)
                    {
                        if (node.HasChildNodes)
                        {
                            string description = string.Empty, link = string.Empty;
                            DateTime pubDate = DateTime.MinValue;
                            XmlNodeList subNodeList = node.ChildNodes;
                            string[] imgsSrc = null;
                            string[] videosSrc = null;
                            string[] iframesSrc = null;
                            foreach (XmlNode subNode in subNodeList)
                            {
                                switch (subNode.Name.ToLower())
                                {
                                    case "description":
                                        description = subNode.InnerText;

                                        #region -- img ---
                                        MatchCollection imgMatches = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        int iImage = 0;
                                        imgsSrc = new string[imgMatches.Count];
                                        foreach (Match match in imgMatches)
                                        {
                                            description = description.Replace(match.Groups[0].Value, "");
                                            imgsSrc[iImage++] = match.Groups["imgUrl"].Value.ReplaceHtmlTags();
                                        }
                                        #endregion -- img --

                                        #region -- video --
                                        MatchCollection videoMatches = new Regex(@"<video\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<videoUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        int iVideo = 0;
                                        videosSrc = new string[videoMatches.Count];
                                        foreach (Match match in videoMatches)
                                        {
                                            description = description.Replace(match.Groups[0].Value, "");
                                            videosSrc[iVideo++] = match.Groups["videoUrl"].Value.ReplaceHtmlTags();
                                        }
                                        #endregion -- video --

                                        #region -- iframe --
                                        MatchCollection iframeMatches = new Regex(@"<iframe\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<iframeUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        int iIframe = 0;
                                        iframesSrc = new string[iframeMatches.Count];
                                        foreach (Match match in iframeMatches)
                                        {
                                            description = description.Replace(match.Groups[0].Value, "");
                                            iframesSrc[iIframe++] = match.Groups["iframeUrl"].Value.ReplaceHtmlTags();
                                        }
                                        #endregion -- iframe --

                                        MatchCollection aMatches = new Regex(@"<a\b[^<>]*?\bhref[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<aTag>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        foreach (Match match in aMatches)
                                        {
                                            if (match.Groups.Count > 1)
                                                description = description.Replace(match.Groups[0].Value, match.Groups[1].Value);
                                            else
                                                description = description.Replace(match.Groups[0].Value, "");
                                        }

                                        description = description.Replace("<br>", "\r\n").Replace("</a>", "").Replace("</img>", "").Replace("</video>", "").Replace("</iframe>", "").Replace("<p>", "").Replace("</p>", "\r\n").ReplaceHtmlTags();
                                        break;
                                    case "link":
                                        link = subNode.InnerText;
                                        break;
                                    case "pubdate":
                                        pubDate = DateTime.Parse(subNode.InnerText);
                                        break;
                                }
                                if (description != string.Empty && link != string.Empty && pubDate != DateTime.MinValue)
                                    break;
                            }

                            LogHelper.WriteInfoLog($"返回抓取内容");
                            yield return (title, description, imgsSrc, videosSrc, iframesSrc, pubDate, link);
                        }
                    }
                }
            }
        }
    }
}
