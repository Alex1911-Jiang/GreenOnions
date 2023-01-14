using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using GreenOnions.Interface;
using GreenOnions.Interface.Items;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.RSS
{
    public static class RssHelper
    {
        public static ConcurrentQueue<string>? Logs { get; set; }
        private static Task? _mainTask = null;
        private static Dictionary<string, Task>? _rssTasks = null;

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
                        LogInfo($"开始本次工作");
                        _rssTasks.Clear();
                        LogInfo($"存在{BotInfo.Config.RssSubscription.Count}条订阅地址");
                        foreach (RssSubscriptionItem item in BotInfo.Config.RssSubscription)  //若干条订阅地址
                        {
                            if (!string.IsNullOrWhiteSpace(item.Url))
                            {
                                if (BotInfo.Config.RssParallel)
                                    _rssTasks.Add(item.Url, RssInnerAsync(item, api));
                                else
                                    _rssTasks.Add(item.Url, RssInner(item, api));
                            }
                        }
                        Task.WaitAll(_rssTasks.Values.ToArray());
                        int SleepTime = (int)Math.Round(BotInfo.Config.ReadRssInterval * 1000 * 60);
                        LogInfo($"等待{SleepTime}毫秒");
                        await Task.Delay(SleepTime);
                    }
                    LogInfo("已禁用RSS功能或断开与平台的连接，RSS进程结束");
                    _rssTasks.Clear();
                    _rssTasks = null;
                }
            });
        }

        public static Dictionary<string,string> GetTaskStatus()
        {
            Dictionary<string, string> result = new();
            if (_mainTask is null || _rssTasks is null)
                result.Add("中控线程","尚未启动");
            else
                result.Add("中控线程", "正常工作中");
            if (_rssTasks is not null)
            {
                foreach (var item in _rssTasks)
                {
                    if (item.Value.IsCompleted)
                    {
                        StringBuilder taskStatus = new("已停止，");
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

        private static async Task RssInner(RssSubscriptionItem item, IGreenOnionsApi api)
        {
            //如果在调试模式并且转发的QQ和群组均不在管理员和调试群组集合中时不去请求
            if (BotInfo.Config.DebugMode && ((BotInfo.Config.DebugReplyAdminOnly && item.ForwardQQs?.Intersect(BotInfo.Config.AdminQQ).Count() == 0) || (BotInfo.Config.OnlyReplyDebugGroup && item.ForwardGroups?.Intersect(BotInfo.Config.DebugGroups).Count() == 0)))
            {
                LogWarn($"{item.Url}没有为订阅源设置转发目标或当前处于调试模式, 不进行转发");
                return;
            }
            if ((item.ForwardGroups is null || item.ForwardGroups.Length == 0) && (item.ForwardQQs is null || item.ForwardQQs.Length == 0))
            {
                LogInfo($"{item.Url}没有要转发的群和好友, 不进行抓取");
                return;
            }

            if (!BotInfo.LastOneSendRssTime.ContainsKey(item.Url!))  //如果不存在上次发送的日期记录
            {
                LogInfo($"{item.Url}没有记录, 添加当前时间作为比对时间");
                BotInfo.LastOneSendRssTime.TryAdd(item.Url!, DateTime.Now);  //添加现在作为起始日期(避免把所有历史信息全都抓过来发送)
                string serRssCache = JsonConvert.SerializeObject(BotInfo.LastOneSendRssTime, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("rssCache.json", serRssCache);
                return;
            }

            try
            {
                LogInfo($"{item.Url}开始抓取");

                if (!string.IsNullOrWhiteSpace(item.Url))
                {
                    LogInfo($"{item.Url}抓取内容");
                    using HttpClient client = new();
                    if (item.Headers is not null)
                    {
                        foreach (var header in item.Headers)
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    var resp = await client.GetAsync(item.Url);
                    var xml = await resp.Content.ReadAsStringAsync();
                    XmlDocument xmlDoc = new();
                    xmlDoc.LoadXml(xml);

                    bool isContent = xmlDoc.GetElementsByTagName("rss")?[0]?.Attributes?["xmlns:content"] is not null;
                    bool isAtom = xmlDoc.GetElementsByTagName("rss")?[0]?.Attributes?["xmlns:atom"] is not null;

                    if (!isContent && !isAtom)
                        isAtom = xmlDoc.GetElementsByTagName("feed")?[0]?.Attributes?["xmlns"]?.Value.EndsWith("Atom") == true;  //Github

                    string title = xmlDoc.GetElementsByTagName("title")[0]!.InnerText;
                    XmlNodeList nodeList = xmlDoc.GetElementsByTagName("item");
                    if (nodeList.Count == 0)
                        nodeList = xmlDoc.GetElementsByTagName("entry");

                    string? thuImgUrl = null;
                    if (BotInfo.Config.RssSendLiveCover)  //获取直播封面
                    {
                        if (item.Url.Contains("bilibili") && item.Url.Contains("/room/"))
                        {
                            string roomId = item.Url[(item.Url.LastIndexOf("/room/") + "/room/".Length)..];
                            string apiResult = await HttpHelper.GetHttpResponseStringAsync($@"https://api.live.bilibili.com/xlive/web-room/v1/index/getInfoByRoom?room_id={roomId}");
                            JObject jo = JsonConvert.DeserializeObject<JObject>(apiResult);
                            thuImgUrl = jo?["data"]?["room_info"]?["cover"]?.ToString();
                        }
                    }

                    if (isContent)
                    {
                        LogInfo($"{item.Url}的Rss规范类型为Content");
                        await foreach (var rss in ReadRssContent(nodeList, BotInfo.LastOneSendRssTime[item.Url]))  //每条订阅地址可能获取到若干条更新
                        {
                            LogInfo($"{item.Url}更新时间晚于记录时间, 需要推送消息");
                            if (!FilterMessage(item, rss.Description))
                                continue;
                            await SendRssMessage(item, api, title, thuImgUrl, rss);
                        }
                    }
                    else if (isAtom)
                    {
                        LogInfo($"{item.Url}的Rss规范类型为Atom");
                        await foreach (var rss in ReadRssAtom(nodeList, BotInfo.LastOneSendRssTime[item.Url]))  //每条订阅地址可能获取到若干条更新
                        {
                            LogInfo($"{item.Url}更新时间晚于记录时间, 需要推送消息");
                            if (!FilterMessage(item, rss.Description))
                                continue;
                            await SendRssMessage(item, api, title, thuImgUrl, rss);
                        }
                    }
                    else
                    {
                        LogWarn($"{item.Url}的Rss规范类型没有支持，请联系机器人作者");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"{item.Url}获取RSS错误", ex, $"请求地址为:{item.Url}");
            }
        }

        private static async Task SendRssMessage(RssSubscriptionItem item, IGreenOnionsApi api, string title, string? thuImgUrl, RssResult rss)
        {
            if (!string.IsNullOrWhiteSpace(item.Url))
            {
                string titleMsg = $"{title}更新啦:\r\n";
                string? translateMsg = await TranslateRss(item, rss.Description);

                LogInfo($"{item.Url}需要转发的群:{(item.ForwardGroups is null ? 0 : item.ForwardGroups.Length)}个");
                if (item.ForwardGroups?.Length > 0)
                {
                    GreenOnionsMessages groupResultMsg = new();

                    if (item.AtAll)
                    {
                        groupResultMsg.Add(new GreenOnionsAtMessage(-1, "全体成员"));
                        groupResultMsg.Add("\r\n");
                    }

                    groupResultMsg.Add(titleMsg);  //标题

                    groupResultMsg.AddRange(rss.Messages);  //正文

                    if (!string.IsNullOrWhiteSpace(translateMsg))
                        groupResultMsg.Add(translateMsg);  //翻译

                    if (thuImgUrl is not null)
                        groupResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(thuImgUrl)));  //B站封面

                    if (!string.IsNullOrWhiteSpace(rss.Author))
                        groupResultMsg.Add($"\r\n作者:{rss.Author}");  //作者

                    groupResultMsg.Add($"\r\n更新时间:{rss.PubDate}");  //时间
                    groupResultMsg.Add($"\r\n原文地址:{rss.Link}");  //地址

                    LogInfo($"{item.Url}组合群消息完成");
                    if (item.SendByForward)
                    {
                        LogInfo($"{item.Url}发送模式为合并转发");
                        GreenOnionsForwardMessage greenOnionsForwardMessage = new(BotInfo.Config.QQId, BotInfo.Config.BotName, groupResultMsg);
                        for (int i = 0; i < item.ForwardGroups?.Length; i++)
                        {
                            await api.SendGroupMessageAsync(item.ForwardGroups[i], greenOnionsForwardMessage);
                        }
                    }
                    else
                    {
                        LogInfo($"{item.Url}发送模式为直接发送");
                        for (int i = 0; i < item.ForwardGroups?.Length; i++)
                        {
                            await api.SendGroupMessageAsync(item.ForwardGroups[i], groupResultMsg);
                        }
                    }
                    LogInfo($"{item.Url}全部群消息发送完毕");
                }
                LogInfo($"{item.Url}需要转发的好友:{(item.ForwardQQs is null ? 0 : item.ForwardQQs.Length)}个");
                if (item.ForwardQQs?.Length > 0)
                {
                    GreenOnionsMessages friendResultMsg = new() { titleMsg };  //标题

                    //friendResultMsg.AddRange(rss.Messages);  //正文

                    if (!string.IsNullOrWhiteSpace(translateMsg))
                        friendResultMsg.Add(translateMsg);  //翻译

                    if (thuImgUrl is not null)
                        friendResultMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(thuImgUrl)));    //B站封面

                    if (!string.IsNullOrWhiteSpace(rss.Author))
                        friendResultMsg.Add($"\r\n作者:{rss.Author}");  //作者

                    friendResultMsg.Add($"\r\n更新时间:{rss.PubDate}");  //时间
                    friendResultMsg.Add($"\r\n原文地址:{rss.Link}");  //地址

                    LogInfo($"{item.Url}组合好友消息完成");
                    if (item.SendByForward)
                    {
                        LogInfo($"{item.Url}发送模式为合并转发");
                        GreenOnionsForwardMessage greenOnionsForwardMessage = new(BotInfo.Config.QQId, BotInfo.Config.BotName, friendResultMsg);
                        for (int i = 0; i < item.ForwardQQs?.Length; i++)
                        {
                            await api.SendFriendMessageAsync(item.ForwardQQs[i], greenOnionsForwardMessage);
                        }
                    }
                    else
                    {
                        LogInfo($"{item.Url}发送模式为直接发送");
                        for (int i = 0; i < item.ForwardQQs?.Length; i++)
                        {
                            await api.SendFriendMessageAsync(item.ForwardQQs[i], friendResultMsg);
                        }
                    }
                    LogInfo($"{item.Url}全部好友消息发送完毕");
                }

                if (BotInfo.LastOneSendRssTime.ContainsKey(item.Url))
                {
                    if (rss.PubDate > BotInfo.LastOneSendRssTime[item.Url])
                        BotInfo.LastOneSendRssTime[item.Url] = rss.PubDate;
                }
                else
                    BotInfo.LastOneSendRssTime.TryAdd(item.Url, rss.PubDate);  //群和好友均推送完毕后记录此地址的最后更新时间
                string serRssCache = JsonConvert.SerializeObject(BotInfo.LastOneSendRssTime, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("rssCache.json", serRssCache);

                LogInfo($"{item.Url}记录最后更新时间完毕");
            }
        }

        private static async Task<string?> TranslateRss(RssSubscriptionItem item, string description)
        {
            string? translateMsg = null;
            if (item.Translate)
            {
                LogInfo($"{item.Url}本条RSS订阅启用了翻译");
                string translatedText;
                if (item.TranslateFromTo)
                    translatedText = await TranslateHandler.TranslateFromTo(description, item.TranslateFrom, item.TranslateTo);
                else
                    translatedText = await TranslateHandler.TranslateToChinese(description);
                translateMsg = $"\r\n以下为翻译内容:\r\n{translatedText}\r\n";
                LogInfo($"{item.Url}翻译成功");
            }
            return translateMsg;
        }

        private static bool FilterMessage(RssSubscriptionItem item, string description)
        {
            bool bSend = false;
            int bContainCount = 0;
            switch (item.FilterMode)
            {
                case 0:  //不过滤
                    bSend = true;
                    break;
                case 1:  //包含任意发送
                    for (int i = 0; i < item.FilterKeyWords?.Length; i++)
                    {
                        if (description.Contains(item.FilterKeyWords[i]))
                        {
                            bSend = true;
                            break;
                        }
                    }
                    break;
                case 2:  //包含所有发送
                    for (int i = 0; i < item.FilterKeyWords?.Length; i++)
                    {
                        if (description.Contains(item.FilterKeyWords[i]))
                            bContainCount++;
                    }
                    if (bContainCount == item.FilterKeyWords?.Length)
                        bSend = true;
                    break;
                case 3:  //包含任意不发送
                    bSend = true;
                    for (int i = 0; i < item.FilterKeyWords?.Length; i++)
                    {
                        if (description.Contains(item.FilterKeyWords[i]))
                        {
                            bSend = false;
                            break;
                        }
                    }
                    break;
                case 4:  //包含所有不发送
                    bSend = true;
                    for (int i = 0; i < item.FilterKeyWords?.Length; i++)
                    {
                        if (description.Contains(item.FilterKeyWords[i]))
                            bContainCount++;
                    }
                    if (bContainCount == item.FilterKeyWords?.Length)
                        bSend = false;
                    break;
            }

            return bSend;
        }

        private static Task RssInnerAsync(RssSubscriptionItem item, IGreenOnionsApi api)
        {
            return Task.Run(() => RssInner(item, api));
        }

        private static async Task<string> GetImgUrlOrFileNameAsync(string url)
        {
            if (BotInfo.Config.SendImageByFile)  //下载完成后发送文件
            {
                string fileName;
                if (url.Contains("twimg"))
                {
                    string extSubStart = url[(url.IndexOf("?format=") + "?format=".Length)..];
                    string ext = extSubStart[..extSubStart.IndexOf('&')];

                    string nameSubToEnd = url[..url.IndexOf("?format")];
                    string nameSub = nameSubToEnd[(nameSubToEnd.LastIndexOf('/') + 1)..];

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

        private static async Task<GreenOnionsMessages> HtmlToMessageAsync(HtmlNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                GreenOnionsMessages outMsg = new();
                foreach (var itemNode in node.ChildNodes)
                    outMsg.AddRange(await HtmlToMessageAsync(itemNode));
                return outMsg;
            }
            else
            {
                if (node.Name == "img")
                    return new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(HttpUtility.HtmlDecode(node.Attributes["src"].Value)));
                if (node.Name == "video")
                    return "\r\n视频地址：" + HttpUtility.HtmlDecode(node.Attributes["src"].Value) + "\r\n";
                if (node.Name == "iframe")
                    return "\r\n内容地址：" + HttpUtility.HtmlDecode(node.Attributes["src"].Value) + "\r\n";
                else if (!string.IsNullOrWhiteSpace(node.InnerText))
                    return HttpUtility.HtmlDecode(node.InnerText);
                else
                    return "\r\n";
            }
        }

        private static async IAsyncEnumerable<RssResult> ReadRssContent(XmlNodeList nodeList, DateTime lastUpdateTime)
        {
            foreach (XmlNode node in nodeList)
            {
                if (node.HasChildNodes)
                {
                    XmlNode? noteDate = node.ChildNodes.OfType<XmlNode>().Where(n => n.Name.ToLower() == "pubdate").FirstOrDefault();
                    if (noteDate is not null)
                    {
                        GreenOnionsMessages outMsg = new();
                        string description = string.Empty, link = string.Empty, creator = string.Empty;

                        bool bHasEncoded = false;

                        if (node.ChildNodes.OfType<XmlNode>().Any(n => n.Name == "content:encoded"))
                            bHasEncoded = true;

                        HtmlDocument htmlDoc;
                        DateTime pubDate = pubDate = DateTime.Parse(noteDate.InnerText);
                        if (pubDate > lastUpdateTime)
                        {
                            foreach (XmlNode subNode in node.ChildNodes)
                            {
                                switch (subNode.Name.ToLower())
                                {
                                    case "content:encoded":
                                        htmlDoc = new HtmlDocument();
                                        htmlDoc.LoadHtml(subNode.InnerText);
                                        foreach (var itemNode in htmlDoc.DocumentNode.ChildNodes)
                                        {
                                            outMsg.AddRange(await HtmlToMessageAsync(itemNode));
                                        }
                                        description = HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
                                        break;
                                    case "description":
                                    case "content":
                                        if (!bHasEncoded)
                                        {
                                            htmlDoc = new HtmlDocument();
                                            htmlDoc.LoadHtml(subNode.InnerText);
                                            description = HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
                                            outMsg.Add(description);
                                        }
                                        break;
                                    case "link":
                                        if (subNode.Attributes?["href"] is not null)
                                            link = subNode.Attributes["href"]!.Value;
                                        else
                                            link = subNode.InnerText;
                                        break;
                                    case "dc:creator":
                                        creator = subNode.InnerText;
                                        break;
                                }
                            }
                            yield return new(outMsg, description, pubDate, link, creator);
                        }
                        else
                            yield break;
                    }
                }
            }
        }

        private static async IAsyncEnumerable<RssResult> ReadRssAtom(XmlNodeList nodeList, DateTime lastUpdateTime)
        {
            foreach (XmlNode node in nodeList)
            {
                if (node.HasChildNodes)
                {
                    XmlNode? noteDate = node.ChildNodes.OfType<XmlNode>().Where(n => n.Name.ToLower() == "pubdate").FirstOrDefault();
                    noteDate ??= node.ChildNodes.OfType<XmlNode>().Where(n => n.Name.ToLower() == "updated").FirstOrDefault();

                    if (noteDate is not null)
                    {
                        GreenOnionsMessages outMsg = new();
                        DateTime pubDate = DateTime.Parse(noteDate.InnerText);
                        if (pubDate > lastUpdateTime)
                        {
                            string description = string.Empty, link = string.Empty, author = string.Empty;
                            foreach (XmlNode subNode in node.ChildNodes)
                            {
                                switch (subNode.Name.ToLower())
                                {
                                    case "description":
                                    case "content":
                                        HtmlDocument htmlDoc = new();
                                        htmlDoc.LoadHtml(subNode.InnerText);
                                        description = HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
                                        outMsg.AddRange(await HtmlToMessageAsync(htmlDoc.DocumentNode));

                                        #region -- 暴力正则 --
                                        //string[]? imgsSrc = null;
                                        //string[]? videosSrc = null;
                                        //string[]? iframesSrc = null;
                                        //description = subNode.InnerText;
                                        //#region -- img ---
                                        //MatchCollection imgMatches = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        //int iImage = 0;
                                        //imgsSrc = new string[imgMatches.Count];
                                        //foreach (Match match in imgMatches)
                                        //{
                                        //    description = description.Replace(match.Groups[0].Value, "");
                                        //    imgsSrc[iImage++] = match.Groups["imgUrl"].Value.ReplaceHtmlTags();
                                        //}
                                        //#endregion -- img --

                                        //#region -- video --
                                        //MatchCollection videoMatches = new Regex(@"<video\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<videoUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        //int iVideo = 0;
                                        //videosSrc = new string[videoMatches.Count];
                                        //foreach (Match match in videoMatches)
                                        //{
                                        //    description = description.Replace(match.Groups[0].Value, "");
                                        //    videosSrc[iVideo++] = match.Groups["videoUrl"].Value.ReplaceHtmlTags();
                                        //}
                                        //#endregion -- video --

                                        //#region -- iframe --
                                        //MatchCollection iframeMatches = new Regex(@"<iframe\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<iframeUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        //int iIframe = 0;
                                        //iframesSrc = new string[iframeMatches.Count];
                                        //foreach (Match match in iframeMatches)
                                        //{
                                        //    description = description.Replace(match.Groups[0].Value, "");
                                        //    iframesSrc[iIframe++] = match.Groups["iframeUrl"].Value.ReplaceHtmlTags();
                                        //}
                                        //#endregion -- iframe --

                                        //MatchCollection aMatches = new Regex(@"<a\b[^<>]*?\bhref[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<aTag>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        //foreach (Match match in aMatches)
                                        //{
                                        //    if (match.Groups.Count > 1)
                                        //        description = description.Replace(match.Groups[0].Value, match.Groups[1].Value);
                                        //    else
                                        //        description = description.Replace(match.Groups[0].Value, "");
                                        //}

                                        //description = description.Replace("<br>", "\r\n").Replace("</a>", "").Replace("</img>", "").Replace("</video>", "").Replace("</iframe>", "").Replace("<p>", "").Replace("</p>", "\r\n").ReplaceHtmlTags();

                                        //outMsg.Add(description);

                                        //for (int i = 0; i < imgsSrc?.Length; i++)
                                        //{
                                        //    try
                                        //    {
                                        //        outMsg.Add(new GreenOnionsImageMessage(await GetImgUrlOrFileNameAsync(imgsSrc[i])));
                                        //    }
                                        //    catch (Exception ex)
                                        //    {
                                        //        LogWarn($"{imgsSrc[i]}图片下载失败，{ex.Message}");
                                        //    }
                                        //}

                                        //if (videosSrc?.Length > 0)
                                        //{
                                        //    outMsg.Add("视频地址:\r\n");
                                        //    for (int i = 0; i < videosSrc.Length; i++)
                                        //    {
                                        //        outMsg.Add(videosSrc[i]);
                                        //    }
                                        //}
                                        #endregion -- 暴力正则 --

                                        break;
                                    case "link":
                                        if (subNode.Attributes?["href"] is not null)
                                            link = subNode.Attributes["href"]!.Value;
                                        else
                                            link = subNode.InnerText;
                                        break;
                                    case "pubdate":
                                    case "updated":
                                        pubDate = DateTime.Parse(subNode.InnerText);
                                        break;
                                    case "author":
                                        author = subNode.InnerText;
                                        break;
                                }
                            }
                            yield return new(outMsg, description, pubDate, link, author);
                        }
                        else
                            yield break;
                    }
                }
            }
        }

        private static void LogInfo(string logMessage)
        {
            while (Logs!.Count > 5000)
                Logs.TryDequeue(out _);
            Logs.Enqueue("消息：" + logMessage);
            LogHelper.WriteInfoLog(logMessage);
        }

        private static void LogWarn(string logMessage)
        {
            while (Logs!.Count > 5000)
                Logs.TryDequeue(out _);
            Logs.Enqueue("警告：" + logMessage);
            LogHelper.WriteWarningLog(logMessage);
        }

        private static void LogError(string logMessageStart, Exception ex, string logMessageEnd)
        {
            while (Logs!.Count > 5000)
                Logs.TryDequeue(out _);
            Logs.Enqueue($"错误：{logMessageStart}，{ex.Message}");
            LogHelper.WriteErrorLogWithUserMessage(logMessageStart, ex, logMessageEnd);
        }

        private struct RssResult
        {
            public RssResult(GreenOnionsMessages messages, string description, DateTime pubDate, string link, string author)
            {
                Messages = messages;
                Description = description;
                PubDate = pubDate;
                Link = link;
                Author = author;
            }
            public GreenOnionsMessages Messages { get; private set; }
            public string Description { get; private set; }
            public DateTime PubDate { get; private set; }
            public string Link { get; private set; }
            public string Author { get; private set; }
        }
    }
}
