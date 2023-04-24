using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using GreenOnions.Interface;
using GreenOnions.Interface.Items;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GreenOnions.RSS
{
    public static class RssHelper
    {
        public static ConcurrentQueue<string>? Logs { get; set; }
        private static Task? _mainTask = null;
        private static Dictionary<string, Task>? _rssTasks = null;
        private static IGreenOnionsApi? _api;

        /// <summary>
        /// 启动RSS工作线程
        /// </summary>
        /// <param name="api"></param>
        public static void StartRssTask(IGreenOnionsApi api)
        {
            _api = api;
            _mainTask = Task.Run(async () =>
            {
                _rssTasks = new Dictionary<string, Task>();
                Logs = new ConcurrentQueue<string>();
                if (!BotInfo.Config.RssEnabled || !BotInfo.IsLogin)
                    return;
                LogInfo("启动RSS功能");
                while (BotInfo.Config.RssEnabled && BotInfo.IsLogin)
                {
                    LogInfo($"开始本次工作");
                    _rssTasks.Clear();
                    LogInfo($"存在{BotInfo.Config.RssSubscription!.Count}条订阅地址");
                    foreach (RssSubscriptionItem item in BotInfo.Config.RssSubscription)  //若干条订阅地址
                    {
                        if (string.IsNullOrWhiteSpace(item.Url))
                        {
                            LogWarn($"没有设置Url，不进行抓取");
                            continue;
                        }
                        //如果在调试模式并且转发的QQ和群组均不在管理员和调试群组集合中时不去请求
                        if (BotInfo.Config.DebugMode && ((BotInfo.Config.DebugReplyAdminOnly && item.ForwardQQs?.Intersect(BotInfo.Config.AdminQQ).Count() == 0) || (BotInfo.Config.OnlyReplyDebugGroup && item.ForwardGroups?.Intersect(BotInfo.Config.DebugGroups).Count() == 0)))
                        {
                            LogWarn($"{item.Url}没有为订阅源设置转发目标或当前处于调试模式, 不进行转发");
                            continue;
                        }
                        if (BotInfo.Config.RssParallel)
                            _rssTasks.Add(item.Url, GetRssData(item));
                        else
                            GetRssData(item).GetAwaiter().GetResult();
                    }
                    Task.WaitAll(_rssTasks.Values.ToArray());
                    int SleepTime = (int)Math.Round(BotInfo.Config.ReadRssInterval * 1000 * 60);
                    LogInfo($"等待{SleepTime}毫秒");
                    await Task.Delay(SleepTime);
                }
                LogInfo("已禁用RSS功能或断开与平台的连接，RSS进程结束");
                _rssTasks.Clear();
                _rssTasks = null;
            });
        }

        /// <summary>
        /// 获取线程状态日志
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 抓取一个订阅源
        /// </summary>
        /// <param name="item">订阅源对象</param>
        /// <returns></returns>
        private static async Task GetRssData(RssSubscriptionItem item)
        {
            XmlDocument? xml = await RequestRssXml(item);
            if (xml is null)
                return;
            await foreach (RssResult? rssResult in RssXmlToResult(xml, item.Url!))
            {
                if (rssResult is null)
                {
                    LogWarn("当前解析结果为空，无法发送");
                    continue;
                }
                if (!FilterMessage(item, rssResult.InnerTitle, rssResult.Text))  //过滤词
                {
                    LogInfo("结果集中包含过滤词，不发送");
                    continue;
                }

                try
                {
                    GreenOnionsMessages msg = CreateRssMessage(item, rssResult);

                    LogInfo($"{item.Url}需要转发的群:{(item.ForwardGroups is null ? 0 : item.ForwardGroups.Length)}个");
                    if (item.ForwardGroups?.Length > 0)
                        await SendRssGroupMessage(item, msg);
                    LogInfo($"{item.Url}需要转发的好友:{(item.ForwardQQs is null ? 0 : item.ForwardQQs.Length)}个");
                    if (item.ForwardQQs?.Length > 0)
                        await SendRssFriendMessage(item, msg);

                    if (BotInfo.LastOneSendRssTime.ContainsKey(item.Url!))
                    {
                        if (rssResult.PubDate > BotInfo.LastOneSendRssTime[item.Url!])
                            BotInfo.LastOneSendRssTime[item.Url!] = rssResult.PubDate;
                    }
                    else
                        BotInfo.LastOneSendRssTime.TryAdd(item.Url!, rssResult.PubDate);  //群和好友均推送完毕后记录此地址的最后发布时间
                    string serRssCache = JsonConvert.SerializeObject(BotInfo.LastOneSendRssTime, Newtonsoft.Json.Formatting.Indented, new StringEnumConverter());
                    File.WriteAllText("rssCache.json", serRssCache);

                    LogInfo($"{item.Url}记录最后发布时间完毕");
                }
                catch (Exception ex)
                {
                    LogError("获取RSS内容失败", ex,$"订阅地址为：{item.Url}");
                }
            }
        }

        /// <summary>
        /// 请求RSS地址并解析为Xml
        /// </summary>
        /// <param name="item">订阅源对象</param>
        /// <returns></returns>
        private static async Task<XmlDocument?> RequestRssXml(RssSubscriptionItem item)
        {
            if ((item.ForwardGroups is null || item.ForwardGroups.Length == 0) && (item.ForwardQQs is null || item.ForwardQQs.Length == 0))
            {
                LogInfo($"{item.Url}没有要转发的群和好友, 不进行抓取");
                return null;
            }

            if (!BotInfo.LastOneSendRssTime.ContainsKey(item.Url!))  //如果不存在上次发送的日期记录
            {
                LogInfo($"{item.Url}没有记录, 添加当前时间作为比对时间");
                BotInfo.LastOneSendRssTime.TryAdd(item.Url!, DateTime.Now);  //添加现在作为起始日期(避免把所有历史信息全都抓过来发送)
                string serRssCache = JsonConvert.SerializeObject(BotInfo.LastOneSendRssTime, Newtonsoft.Json.Formatting.Indented, new StringEnumConverter());
                File.WriteAllText("rssCache.json", serRssCache);
            }
            XmlDocument xmlDoc = new();
            LogInfo($"{item.Url}开始抓取内容");
            try
            {
                if ((item.Headers is null || item.Headers.Count == 0) && !BotInfo.Config.RssUseProxy)
                {
                    xmlDoc.Load(item.Url!);
                }
                else
                {
                    LogInfo($"准备抓取 {item.Url}， 是否使用代理={BotInfo.Config.RssUseProxy}");
                    using HttpClient client = HttpHelper.CreateClient(BotInfo.Config.RssUseProxy);
                    if (item.Headers is not null)
                    {
                        foreach (var header in item.Headers)
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    HttpResponseMessage resp= await client.GetAsync(item.Url);
                    LogInfo($"{item.Url}抓取结果：{(int)resp.StatusCode} {resp.StatusCode}");
                    string xml;
                    if (item.SourceIsStream)
                    {
                        LogInfo($"作为流读取数据源");
                        byte[] bs = await resp.Content.ReadAsByteArrayAsync();
                        xml = Encoding.UTF8.GetString(bs);
                        LogInfo($"解码成功");
                    }
                    else
                    {
                        LogInfo($"作为文本读取数据源");
                        xml = await resp.Content.ReadAsStringAsync();
                    }
                    LogInfo($"开始加载xml");
                    xmlDoc.LoadXml(xml);
                }
            }
            catch (Exception ex)
            {
                LogError($"{item.Url}获取RSS错误", ex, $"请求地址为:{item.Url}");
                return null;
            }
            
            LogInfo($"{item.Url}加载XML成功");
            return xmlDoc;
        }

        /// <summary>
        /// 解析Xml对象为格式化数据
        /// </summary>
        /// <param name="xmlDoc">Xml对象</param>
        /// <param name="url">订阅地址</param>
        /// <returns></returns>
        private static IAsyncEnumerable<RssResult?> RssXmlToResult(XmlDocument xmlDoc, string url)
        {
            bool isContent = xmlDoc.GetElementsByTagName("rss")?[0]?.Attributes?["xmlns:content"] is not null;
            bool isAtom = xmlDoc.GetElementsByTagName("rss")?[0]?.Attributes?["xmlns:atom"] is not null;

            if (!isContent && !isAtom)
                isAtom = xmlDoc.GetElementsByTagName("feed")?[0]?.Attributes?["xmlns"]?.Value.EndsWith("Atom") == true;  //Github

            string title = xmlDoc.GetElementsByTagName("title")[0]!.InnerText;
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("item");
            if (nodeList.Count == 0)
                nodeList = xmlDoc.GetElementsByTagName("entry");

            if (isContent)
            {
                LogInfo($"{url}的Rss规范类型为Content");
                return ReadRssContent(nodeList, title, url);
            }
            if (isAtom)
            {
                LogInfo($"{url}的Rss规范类型为Atom");
            }
            else
            {
                string xmlns = "未知";
                if (xmlDoc.GetElementsByTagName("rss")?[0]?.Attributes?["xmlns:dc"] is not null)
                    xmlns = "Dc";
                else if (xmlDoc.GetElementsByTagName("rss")?[0]?.Attributes?["xmlns:media"] is not null)
                    xmlns = "Media";
                LogWarn($"{url}的Rss规范类型\"{xmlns}\"没有支持，尝试视为Atom解析，如果解析内容有误请联系机器人作者");
            }
            //Atom
            return ReadRssAtom(nodeList, title, url);
        }

        /// <summary>
        /// 通过RSS格式化数据创建消息
        /// </summary>
        /// <param name="item">订阅源对象</param>
        /// <param name="result">RSS格式化数据</param>
        /// <returns></returns>
        private static GreenOnionsMessages CreateRssMessage(RssSubscriptionItem item, RssResult result)
        {
            Dictionary<string, Func<GreenOnionsMessages?>> relpaceTags = new()
            {
                { "<标题>", () => result.Title},
                { "<订阅地址>", () => item.Url},
                { "<备注>", () => item.Remark},
                { "<文章标题>", () => result.InnerTitle},
                { "<正文>",() => result.Body},
                { "<正文:文本>",() => result.Text},
                { "<正文:图片>", () => result.Images()?.Result?.ToArray()},
                { "<正文:图片地址>",() => result.ImageUrls.Select(s=>new GreenOnionsTextMessage(s)).ToArray()},
                { "<视频地址>",() => result.VideoUrls.Select(s=>new GreenOnionsTextMessage(s)).ToArray()},
                { "<嵌入页面地址>",() => result.IFrameUrls.Select(s=>new GreenOnionsTextMessage(s)).ToArray()},
                { "<翻译文本>",() => item.Translate? result.TranslatedText(result.Text, item.TranslateFromTo, item.TranslateFrom, item.TranslateTo).Result : null},
                { "<B站直播封面>", () => result.BilibiliLiveCover().Result},
                { "<作者>",() => result.Author},
                { "<发布时间>", () => result.PubDate.ToString()},
                { "<原文地址>",() => result.Link},
                { "<媒体内容>",() => result.Media},
                { "<@全体成员>", () => new GreenOnionsAtMessage(-1,"全体成员")},
            };

            GreenOnionsMessages resultMsg = new();
            for (int i = 0; i < item.Format.Length; i++)
            {
                if (item.Format[i].Length == 0)
                {
                    resultMsg.Add("\r\n");
                    continue;
                }
                bool firstIsQuestion = item.Format[i][0] == '?';
                bool noneKey = true;
                foreach (var tags in relpaceTags)
                {
                    int keyIndex = item.Format[i].IndexOf(tags.Key);
                    if (keyIndex == -1)
                        continue;
                    noneKey = false;
                    GreenOnionsMessages? itemMsg;
                    try
                    {
                        itemMsg = relpaceTags[tags.Key]();
                    }
                    catch (Exception ex)
                    {
                        LogError($"将内容投影到排版表中出错，错误标签为：{tags.Key}",ex, $"订阅地址为：{result.Url}");
                        throw;
                    }
                    bool isEmptyMsg = false;
                    if (itemMsg is null)
                        isEmptyMsg = true;
                    else if (itemMsg.Count == 0)
                        isEmptyMsg = true;
                    else if (itemMsg.First() is GreenOnionsTextMessage txm && string.IsNullOrEmpty(txm.Text))
                        isEmptyMsg = true;
                    if (keyIndex > 0)
                    {
                        if (firstIsQuestion && isEmptyMsg)
                            continue;
                        int startSubIndex = firstIsQuestion ? 1 : 0;
                        int subLength = keyIndex - startSubIndex;
                        if (subLength > 0)
                            resultMsg.Add(item.Format[i].Substring(firstIsQuestion ? 1 : 0, subLength));
                        if (itemMsg is not null)
                            resultMsg.AddRange(itemMsg);
                        resultMsg.Add("\r\n");
                        break;
                    }
                    else if (keyIndex == 0)  //开头是标签
                    {
                        if (firstIsQuestion && isEmptyMsg)
                            continue;
                        if (itemMsg is not null)
                            resultMsg.AddRange(itemMsg);
                        resultMsg.Add(item.Format[i].Substring(firstIsQuestion ? tags.Key.Length + 1 : tags.Key.Length));
                        resultMsg.Add("\r\n");
                        break;
                    }
                }
                if (noneKey)  //没有标签
                {
                    if (firstIsQuestion)
                        continue;
                    resultMsg.Add(item.Format[i]);
                    resultMsg.Add("\r\n");
                }
            }
            return resultMsg.ReplaceGreenOnionsStringTags();
        }

        private static async Task SendRssGroupMessage(RssSubscriptionItem item, GreenOnionsMessages msg)
        {
            if (item.SendByForward)
            {
                LogInfo($"{item.Url}发送模式为合并转发");
                GreenOnionsForwardMessage greenOnionsForwardMessage = new(BotInfo.Config.QQId, BotInfo.Config.BotName, msg);
                for (int i = 0; i < item.ForwardGroups?.Length; i++)
                {
                    await _api!.SendGroupMessageAsync(item.ForwardGroups[i], greenOnionsForwardMessage);
                }
            }
            else
            {
                LogInfo($"{item.Url}发送模式为直接发送");
                for (int i = 0; i < item.ForwardGroups?.Length; i++)
                {
                    await _api!.SendGroupMessageAsync(item.ForwardGroups[i], msg);
                }
            }
            LogInfo($"{item.Url}全部群消息发送完毕");
        }

        private static async Task SendRssFriendMessage(RssSubscriptionItem item, GreenOnionsMessages msg)
        {
            msg.RemoveAll(m => m is GreenOnionsAtMessage);

            LogInfo($"{item.Url}组合好友消息完成");
            if (item.SendByForward)
            {
                LogInfo($"{item.Url}发送模式为合并转发");
                GreenOnionsForwardMessage greenOnionsForwardMessage = new(BotInfo.Config.QQId, BotInfo.Config.BotName, msg);
                for (int i = 0; i < item.ForwardQQs?.Length; i++)
                {
                    await _api!.SendFriendMessageAsync(item.ForwardQQs[i], greenOnionsForwardMessage);
                }
            }
            else
            {
                LogInfo($"{item.Url}发送模式为直接发送");
                for (int i = 0; i < item.ForwardQQs?.Length; i++)
                {
                    await _api!.SendFriendMessageAsync(item.ForwardQQs[i], msg);
                }
            }
            LogInfo($"{item.Url}全部好友消息发送完毕");
        }

        private static bool FilterMessage(RssSubscriptionItem item, string innerTitle, string description)
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
                        if (innerTitle.Contains(item.FilterKeyWords[i]))
                        {
                            bSend = true;
                            break;
                        }
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
                        if (innerTitle.Contains(item.FilterKeyWords[i]))
                            bContainCount++;
                    }
                    if (bContainCount == item.FilterKeyWords?.Length)
                    {
                        bSend = true;
                        break;
                    }
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
                        if (innerTitle.Contains(item.FilterKeyWords[i]))
                        {
                            bSend = false;
                            break;
                        }
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
                        if (innerTitle.Contains(item.FilterKeyWords[i]))
                            bContainCount++;
                    }
                    if (bContainCount == item.FilterKeyWords?.Length)
                    {
                        bSend = false;
                        break;
                    }
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

        /// <summary>
        /// 解析Html文本为RSS内容
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static async Task<RssBody> HtmlToRssBodyAsync(HtmlNode node)
        {
            RssBody body = new RssBody();
            if (node.ChildNodes.Count > 0)
            {
                foreach (var itemNode in node.ChildNodes)
                {
                    RssBody itemBody = await HtmlToRssBodyAsync(itemNode);
                    body.Message.AddRange(itemBody.Message);
                    body.Text.Append(itemBody.Text);
                    body.ImageUrls.AddRange(itemBody.ImageUrls);
                    body.VideoUrls.AddRange(itemBody.VideoUrls);
                    body.IFrameUrls.AddRange(itemBody.IFrameUrls);
                }
            }
            else
            {
                if (node.Name == "img")
                {
                    string imgUrl = HttpUtility.HtmlDecode(node.Attributes["src"].Value);
                    body.Message.Add(await RssResult.RssDownloadImageAsync(imgUrl));
                    body.ImageUrls.Add(imgUrl);
                }
                if (node.Name == "video")
                {
                    body.VideoUrls.Add(HttpUtility.HtmlDecode(node.Attributes["src"].Value));
                }
                if (node.Name == "iframe")
                {
                    body.IFrameUrls.Add(HttpUtility.HtmlDecode(node.Attributes["src"].Value));
                }
                else if (!string.IsNullOrWhiteSpace(node.InnerText))
                {
                    string htmlText = HttpUtility.HtmlDecode(node.InnerText);
                    body.Message.Add(htmlText);
                    body.Text.Append(htmlText);
                }
                else
                {
                    body.Message.Add("\r\n");
                    body.Text.Append("\r\n");
                }
            }
            return body;
        }

        private static async IAsyncEnumerable<RssResult> ReadRssContent(XmlNodeList nodeList, string title, string url)
        {
            DateTime lastUpdateTime = BotInfo.LastOneSendRssTime[url];
            foreach (XmlNode node in nodeList)
            {
                if (!node.HasChildNodes)
                    continue;

                XmlNode? noteDate = node.ChildNodes.OfType<XmlNode>().Where(n => n.Name.ToLower() == "pubdate").FirstOrDefault();
                if (noteDate is null)
                    continue;

                bool bHasEncoded = false;
                if (node.ChildNodes.OfType<XmlNode>().Any(n => n.Name == "content:encoded"))
                    bHasEncoded = true;

                HtmlDocument htmlDoc;
                DateTime pubDate = pubDate = DateTime.Parse(noteDate.InnerText);
                if (pubDate <= lastUpdateTime && !BotInfo.Config.DebugMode)
                {
                    LogInfo($"抓取到的内容发布时间 {pubDate} 早于记录的时间 {lastUpdateTime} 无需发送");
                    yield break;
                }

                LogInfo($"抓取到的内容发布时间 {pubDate} 晚于记录的时间 {lastUpdateTime} 需要发送");
                RssResult result = new RssResult();
                result.Url = url;
                result.Title = title;
                result.PubDate = pubDate;
                foreach (XmlNode subNode in node.ChildNodes)
                {
                    switch (subNode.Name.ToLower())
                    {
                        case "title":
                            result.InnerTitle = HttpUtility.HtmlDecode(subNode.InnerText);
                            break;
                        case "content:encoded":
                            htmlDoc = new HtmlDocument();
                            htmlDoc.LoadHtml(subNode.InnerText);
                            foreach (var itemNode in htmlDoc.DocumentNode.ChildNodes)
                            {
                                RssBody body = await HtmlToRssBodyAsync(itemNode);
                                result.Body.AddRange(body.Message);
                                result.ImageUrls.AddRange(body.ImageUrls);
                                result.VideoUrls.AddRange(body.VideoUrls);
                                result.IFrameUrls.AddRange(body.IFrameUrls);
                            }
                            result.Text = HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
                            break;
                        case "description":
                        case "content":
                            if (!bHasEncoded)
                            {
                                htmlDoc = new HtmlDocument();
                                htmlDoc.LoadHtml(subNode.InnerText);
                                string description = HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
                                result.Body.Add(description);
                                result.Text = description;
                            }
                            break;
                        case "link":
                            if (subNode.Attributes?["href"] is not null)
                                result.Link = subNode.Attributes["href"]!.Value;
                            else
                                result.Link = subNode.InnerText;
                            break;
                        case "author":
                        case "dc:creator":
                            result.Author = subNode.InnerText;
                            break;
                        case "media:content":
                            if (subNode.Attributes is null || subNode.Attributes["url"] is null || subNode.Attributes["medium"] is null)
                                continue;
                            string? mediaUrl = subNode.Attributes["url"]?.Value;
                            if (string.IsNullOrWhiteSpace(mediaUrl))
                                continue;
                            if (subNode.Attributes["medium"]?.Value == "image")
                                result.Media = await RssResult.RssDownloadImageAsync(mediaUrl);
                            else
                                result.Media = $"{subNode.Attributes["medium"]?.Value}: {mediaUrl}";
                            break;
                    }
                }
                LogInfo("当前Content内容解析成功");
                yield return result;
            }
        }

        private static async IAsyncEnumerable<RssResult> ReadRssAtom(XmlNodeList nodeList, string title, string url)
        {
            DateTime lastUpdateTime = BotInfo.LastOneSendRssTime[url];
            foreach (XmlNode node in nodeList)
            {
                if (!node.HasChildNodes)
                    continue;

                XmlNode? noteDate = node.ChildNodes.OfType<XmlNode>().Where(n => n.Name.ToLower() == "pubdate").FirstOrDefault();
                noteDate ??= node.ChildNodes.OfType<XmlNode>().Where(n => n.Name.ToLower() == "updated").FirstOrDefault();

                if (noteDate is null)
                    continue;

                DateTime pubDate = DateTime.Parse(noteDate.InnerText);
                if (pubDate <= lastUpdateTime && !BotInfo.Config.DebugMode)
                {
                    LogInfo($"抓取到的内容发布时间 {pubDate} 早于记录的时间 {lastUpdateTime} 无需发送");
                    yield break;
                }

                LogInfo($"抓取到的内容发布时间 {pubDate} 晚于记录的时间 {lastUpdateTime} 需要发送");
                RssResult result = new RssResult();
                result.Url = url;
                result.Title = title;
                result.PubDate = pubDate;

                foreach (XmlNode subNode in node.ChildNodes)
                {
                    switch (subNode.Name.ToLower())
                    {
                        case "title":
                            result.InnerTitle = HttpUtility.HtmlDecode(subNode.InnerText);
                            break;
                        case "description":
                        case "content":
                            HtmlDocument htmlDoc = new HtmlDocument();
                            htmlDoc.LoadHtml(subNode.InnerText);
                            RssBody body = await HtmlToRssBodyAsync(htmlDoc.DocumentNode);
                            result.Body = body.Message;
                            result.Text = HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
                            result.ImageUrls = body.ImageUrls;
                            result.VideoUrls = body.VideoUrls;
                            result.IFrameUrls = body.IFrameUrls;
                            break;
                        case "link":
                            if (subNode.Attributes?["href"] is not null)
                                result.Link = subNode.Attributes["href"]!.Value;
                            else
                                result.Link = subNode.InnerText;
                            break;
                        case "author":
                        case "dc:creator":
                            result.Author = subNode.InnerText;
                            break;
                        case "media:content":
                            if (subNode.Attributes is null || subNode.Attributes["url"] is null || subNode.Attributes["medium"] is null)
                                continue;
                            string? mediaUrl = subNode.Attributes["url"]?.Value;
                            if (string.IsNullOrWhiteSpace(mediaUrl))
                                continue;
                            if (subNode.Attributes["medium"]?.Value == "image")
                                result.Media = await RssResult.RssDownloadImageAsync(mediaUrl);
                            else
                                result.Media = $"{subNode.Attributes["medium"]?.Value}: {mediaUrl}";
                            break;
                    }
                }
                LogInfo("当前Atom内容解析成功");
                yield return result;
            }
        }

        #region -- 日志&监控 --
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

        private static void LogError(string logMessageStart, Exception ex, string logMessageEnd = "")
        {
            while (Logs!.Count > 5000)
                Logs.TryDequeue(out _);
            Logs.Enqueue($"错误：{logMessageStart}，{ex.Message}");
            LogHelper.WriteErrorLog(logMessageStart, ex, logMessageEnd);
        }
        #endregion -- 日志监控 --
    }
}
