using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using GreenOnions.Interface;
using GreenOnions.Interface.Items;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.RSS
{
    public static class RssHelper
    {
        public static ConcurrentQueue<string> Logs { get; set; }
        private static Task _mainTask = null;
        private static Dictionary<string, Task> _rssTasks = null;

        public static void StartRssTask(IGreenOnionsApi api)
        {
            _mainTask = Task.Run(async () =>
            {
                _rssTasks = new Dictionary<string, Task>();
                Logs = new ConcurrentQueue<string>();
                LogInfo("启动RSS功能");
                if (BotInfo.Config.RssEnabled && BotInfo.IsLogin)
                {
                    LogInfo("启动RSS抓取线程");
                    while (BotInfo.Config.RssEnabled && BotInfo.IsLogin)
                    {
                        _rssTasks.Clear();
                        LogInfo($"存在{BotInfo.Config.RssSubscription.Count()}条订阅地址");
                        foreach (RssSubscriptionItem item in BotInfo.Config.RssSubscription)  //若干条订阅地址
                            _rssTasks.Add(item.Url, RssInner(item, api));
                        Task.WaitAll(_rssTasks.Values.ToArray());
                        await Task.Delay((int)Math.Round(BotInfo.Config.ReadRssInterval * 1000 * 60));
                    }
                    LogInfo("已禁用RSS功能或断开与平台的连接，RSS进程结束");
                    _rssTasks.Clear();
                    _rssTasks = null;
                }
            });
        }

        public static Dictionary<string,string> GetTaskStatus()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (_mainTask == null || _rssTasks == null)
                result.Add("中控线程","尚未启动");
            else
                result.Add("中控线程", "正常工作中");
            if (_rssTasks is not null)
            {
                foreach (var item in _rssTasks)
                {
                    if (item.Value.IsCompleted)
                    {
                        StringBuilder taskStatus = new StringBuilder("已停止，");
                        if (item.Value.IsFaulted)
                            taskStatus.Append("被中断");
                        else if (item.Value.IsCanceled)
                            taskStatus.Append("被取消");
                        else
                            taskStatus.Append("正常结束");
                        result.Add(item.Key, taskStatus.ToString());
                    }
                    else
                    {
                        result.Add(item.Key, "正常工作中");
                    }
                }
            }
            return result;
        }
        
        private static Task RssInner(RssSubscriptionItem item, IGreenOnionsApi api)
        {
            return Task.Run(async () =>
            {
                //如果在调试模式并且转发的QQ和群组均不在管理员和调试群组集合中时不去请求
                if (BotInfo.Config.DebugMode && ((BotInfo.Config.DebugReplyAdminOnly && item.ForwardQQs.Intersect(BotInfo.Config.AdminQQ).Count() == 0) || (BotInfo.Config.OnlyReplyDebugGroup && item.ForwardGroups.Intersect(BotInfo.Config.DebugGroups).Count() == 0)))
                {
                    LogWarn($"{item.Url}没有为订阅源设置转发目标或当前处于调试模式, 不进行转发");
                    return;
                }
                if ((item.ForwardGroups is null || item.ForwardGroups.Length == 0) && (item.ForwardGroups is null || item.ForwardQQs.Length == 0))
                {
                    LogInfo($"{item.Url}没有要转发的群和好友, 不进行抓取");
                    return;
                }

                if (!BotInfo.LastOneSendRssTime.ContainsKey(item.Url))  //如果不存在上次发送的日期记录
                {
                    LogInfo($"{item.Url}没有记录, 添加当前时间作为比对时间");
                    BotInfo.LastOneSendRssTime.TryAdd(item.Url, DateTime.Now);  //添加现在作为起始日期(避免把所有历史信息全都抓过来发送)
                    string serRssCache = JsonConvert.SerializeObject(BotInfo.LastOneSendRssTime);
                    File.WriteAllText("rssCache.json", serRssCache);
                    return;
                }

                try
                {
                    LogInfo($"{item.Url}开始抓取");
                    bool hasUpdate = false;
                    foreach (var rss in ReadRss(item.Url))  //每条订阅地址可能获取到若干条更新
                    {
                        if (rss.pubDate > BotInfo.LastOneSendRssTime[item.Url])
                        {
                            hasUpdate = true;
                            LogInfo($"{item.Url}更新时间晚于记录时间, 需要推送消息");

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
                                LogInfo($"{item.Url}本条RSS订阅启用了翻译");
                                string translatedText;
                                if (item.TranslateFromTo)
                                    translatedText = await YouDaoTranslateHelper.TranslateFromTo(rss.description, item.TranslateFrom, item.TranslateTo);
                                else
                                    translatedText = await YouDaoTranslateHelper.TranslateToChinese(rss.description);
                                translateMsg = $"\r\n以下为翻译内容:\r\n{translatedText}\r\n";
                                LogInfo($"{item.Url}翻译成功");
                            }
                            string thuImgUrl = null;
                            if (BotInfo.Config.RssSendLiveCover)  //获取直播封面
                            {
                                if (item.Url.Contains("bilibili") && item.Url.Contains("/room/"))
                                {
                                    string roomId = item.Url.Substring(item.Url.LastIndexOf("/room/") + "/room/".Length);
                                    string apiResult = await HttpHelper.GetHttpResponseStringAsync($@"https://api.live.bilibili.com/xlive/web-room/v1/index/getInfoByRoom?room_id={roomId}");
                                    JObject jo = JsonConvert.DeserializeObject<JObject>(apiResult);
                                    thuImgUrl = jo?["data"]?["room_info"]?["cover"]?.ToString();
                                }
                            }
                            LogInfo($"{item.Url}需要转发的组:{item.ForwardGroups.Length}个");
                            if (item.ForwardGroups.Length > 0)
                            {
                                GreenOnionsMessages groupResultMsg = new GreenOnionsMessages();

                                if (item.AtAll)
                                {
                                    groupResultMsg.Add(new GreenOnionsAtMessage(-1, "全体成员"));
                                    groupResultMsg.Add("\r\n");
                                }

                                groupResultMsg.Add(titleMsg);
                                if (translateMsg is not null)
                                    groupResultMsg.Add(translateMsg);
                                for (int i = 0; i < rss.imgsSrc.Length; i++)
                                {
                                    try
                                    {
                                        groupResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(rss.imgsSrc[i])));
                                    }
                                    catch (Exception ex)
                                    {
                                        LogWarn($"{item.Url}图片下载失败，{ex.Message}");
                                        LogInfo($"{item.Url}图片地址：{rss.imgsSrc[i]}");
                                    }
                                }

                                if (rss.videosSrc.Length > 0)
                                {
                                    groupResultMsg.Add("视频地址:\r\n");
                                    for (int i = 0; i < rss.videosSrc.Length; i++)
                                    {
                                        groupResultMsg.Add(rss.videosSrc[i]);
                                    }
                                }

                                if (thuImgUrl is not null)
                                    groupResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(thuImgUrl)));

                                groupResultMsg.Add($"\r\n更新时间:{rss.pubDate}");
                                groupResultMsg.Add($"\r\n原文地址:{rss.link}");

                                LogInfo($"{item.Url}组合群消息完成");

                                if (item.SendByForward)
                                {
                                    LogInfo($"{item.Url}发送模式为合并转发");
                                    GreenOnionsForwardMessage greenOnionsForwardMessage = new GreenOnionsForwardMessage(BotInfo.Config.QQId, BotInfo.Config.BotName, groupResultMsg);

                                    for (int i = 0; i < item.ForwardGroups.Length; i++)
                                    {
                                        await api.SendGroupMessageAsync(item.ForwardGroups[i], greenOnionsForwardMessage);
                                    }
                                }
                                else
                                {
                                    LogInfo($"{item.Url}发送模式为直接发送");
                                    for (int i = 0; i < item.ForwardGroups.Length; i++)
                                    {
                                        await api.SendGroupMessageAsync(item.ForwardGroups[i], groupResultMsg);
                                    }
                                }
                                LogInfo($"{item.Url}全部群消息发送完毕");
                            }
                            LogInfo($"{item.Url}需要转发的好友:{item.ForwardQQs.Length}个");
                            if (item.ForwardQQs.Length > 0)
                            {
                                GreenOnionsMessages friendResultMsg = new GreenOnionsMessages();

                                friendResultMsg.Add(titleMsg);
                                if (translateMsg is not null)
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

                                if (thuImgUrl is not null)
                                    friendResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(thuImgUrl)));
                                friendResultMsg.Add($"\r\n更新时间:{rss.pubDate}");
                                friendResultMsg.Add($"\r\n原文地址:{rss.link}");

                                LogInfo($"{item.Url}组合好友消息完成");

                                if (item.SendByForward)
                                {
                                    LogInfo($"{item.Url}发送模式为合并转发");
                                    GreenOnionsForwardMessage greenOnionsForwardMessage = new GreenOnionsForwardMessage(BotInfo.Config.QQId, BotInfo.Config.BotName, friendResultMsg);
                                    for (int i = 0; i < item.ForwardQQs.Length; i++)
                                    {
                                        await api.SendFriendMessageAsync(item.ForwardQQs[i], greenOnionsForwardMessage);
                                    }
                                }
                                else
                                {
                                    LogInfo($"{item.Url}发送模式为直接发送");
                                    for (int i = 0; i < item.ForwardQQs.Length; i++)
                                    {
                                        await api.SendFriendMessageAsync(item.ForwardQQs[i], friendResultMsg);
                                    }
                                }
                                LogInfo($"{item.Url}全部好友消息发送完毕");
                            }

                            if (BotInfo.LastOneSendRssTime.ContainsKey(item.Url))
                                BotInfo.LastOneSendRssTime[item.Url] = rss.pubDate;
                            else
                                BotInfo.LastOneSendRssTime.TryAdd(item.Url, rss.pubDate);  //群和好友均推送完毕后记录此地址的最后更新时间
                            BotInfo.LastOneSendRssTime = BotInfo.LastOneSendRssTime;
                            string serRssCache = JsonConvert.SerializeObject(BotInfo.LastOneSendRssTime);
                            File.WriteAllText("rssCache.json", serRssCache);

                            LogInfo($"{item.Url}记录最后更新时间完毕");

                            //if (rss.iframseSrc.Length > 0)  //视频或内嵌网页没想好怎么处理
                            //{

                            //}
                        }
                    }
                    if (!hasUpdate)
                    {
                        LogInfo($"{item.Url}更新时间早于或等于记录时间, 无需推送");
                    }
                }
                catch (Exception ex)
                {
                    LogError($"{item.Url}获取RSS错误", ex, $"请求地址为:{item.Url}");
                }
            });
        }

        private static async Task<string> GetImgUrlOrFileNameAsync(string url)
        {
            if (BotInfo.Config.SendImageByFile)  //下载完成后发送文件
            {
                string fileName;
                if (url.Contains("twimg"))
                {
                    string extSubStart = url.Substring(url.IndexOf("?format=") + "?format=".Length);
                    string ext = extSubStart.Substring(0, extSubStart.IndexOf('&'));

                    string nameSubToEnd = url.Substring(0, url.IndexOf("?format"));
                    string nameSub = nameSubToEnd.Substring(nameSubToEnd.LastIndexOf('/') + 1);

                    fileName = $"{nameSub}.{ext}";
                }
                else
                {
                    fileName = Path.GetFileName(url);
                }
                string imgName = Path.Combine(ImageHelper.ImagePath, $"RSS_{fileName}");
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
                LogInfo($"{url}抓取内容");
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                string title = doc.GetElementsByTagName("title")[0].InnerText;
                XmlNodeList nodeList = doc.GetElementsByTagName("item");
                if (nodeList.Count == 0)
                    nodeList = doc.GetElementsByTagName("entry");

                if (doc.HasChildNodes)
                {
                    LogInfo($"{url}抓取成功");
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
                                    case "content":
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
                                        if (subNode.Attributes["href"] != null)
                                            link = subNode.Attributes["href"].Value;
                                        else
                                            link = subNode.InnerText;
                                        break;
                                    case "pubdate":
                                    case "updated":
                                        pubDate = DateTime.Parse(subNode.InnerText);
                                        break;
                                }
                                if (description != string.Empty && link != string.Empty && pubDate != DateTime.MinValue)
                                    break;
                            }

                            yield return (title, description, imgsSrc, videosSrc, iframesSrc, pubDate, link);
                        }
                    }
                }
            }
        }

        private static void LogInfo(string logMessage)
        {
            while (Logs.Count > 5000)
                Logs.TryDequeue(out _);
            Logs.Enqueue("消息：" + logMessage);
            LogHelper.WriteInfoLog(logMessage);
        }

        private static void LogWarn(string logMessage)
        {
            while (Logs.Count > 5000)
                Logs.TryDequeue(out _);
            Logs.Enqueue("警告：" + logMessage);
            LogHelper.WriteWarningLog(logMessage);
        }

        private static void LogError(string logMessageStart, Exception ex, string logMessageEnd)
        {
            while (Logs.Count > 5000)
                Logs.TryDequeue(out _);
            Logs.Enqueue($"错误：{logMessageStart}，{ex.Message}");
            LogHelper.WriteErrorLogWithUserMessage(logMessageStart, ex, logMessageEnd);
        }
    }
}
