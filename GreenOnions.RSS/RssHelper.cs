using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using GreenOnions.Utility.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;
using GreenOnions.Model;

namespace GreenOnions.RSS
{
    public static class RssHelper
    {
        private static Task _RssWorker = null;
        public static void StartRssTask(Action<GreenOnionsMessageGroup, long, long> SendMessage)
        {
            if (BotInfo.RssEnabled && BotInfo.IsLogin)
            {
                if (_RssWorker != null && !_RssWorker.IsCompleted && !_RssWorker.IsCanceled && !_RssWorker.IsFaulted)
                    return;
                _RssWorker = Task.Run(async () =>
                {
                    LogHelper.WriteInfoLog("启动RSS抓取线程");
                    while (BotInfo.RssEnabled && BotInfo.IsLogin)
                    {
                        foreach (RssSubscriptionItem item in BotInfo.RssSubscription)  //若干条订阅地址
                        {
                            //如果在调试模式并且转发的QQ和群组均不在管理员和调试群组集合中时不去请求
                            if (BotInfo.DebugMode && ((BotInfo.DebugReplyAdminOnly && item.ForwardQQs.Intersect(BotInfo.AdminQQ).Count() == 0) || (BotInfo.OnlyReplyDebugGroup && item.ForwardGroups.Intersect(BotInfo.DebugGroups).Count() == 0)))
                            {
                                LogHelper.WriteWarningLog("没有为订阅源设置转发目标或当前处于调试模式, 不进行转发");
                                continue;
                            }
                            
                            try
                            {
                                if (item.ForwardGroups.Length == 0 && item.ForwardQQs.Length == 0)
                                    continue;
                                if (!Cache.LastOneSendRssTime.ContainsKey(item.Url))  //如果不存在上次发送的日期记录
                                {
                                    LogHelper.WriteInfoLog($"首次抓取到{item.Url}内容, 只保存不发送, 防止内容太多刷屏");
                                    Cache.LastOneSendRssTime.TryAdd(item.Url, DateTime.Now);  //添加现在作为起始日期(避免把所有历史信息全都抓过来发送)
                                    Cache.LastOneSendRssTime = Cache.LastOneSendRssTime;
                                    JsonHelper.SaveCacheFile();
                                    continue;
                                }
                                foreach (var rss in ReadRss(item.Url))  //每条订阅地址可能获取到若干条更新
                                {
                                    if (rss.pubDate > Cache.LastOneSendRssTime[item.Url])
                                    {
                                        LogHelper.WriteInfoLog($"更新时间晚于记录时间, 需要推送消息");

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
                                            translateMsg = $"\r\n以下为翻译内容:\r\n{ translatedText }";
                                            LogHelper.WriteInfoLog($"翻译成功");
                                        }

                                        //List<MemoryStream> imgList = null;
                                        //if (rss.imgsSrc.Length > 0)
                                        //{
                                        //    LogHelper.WriteInfoLog($"本条RSS内容包含图片");
                                        //    imgList = new List<MemoryStream>();
                                        //    for (int i = 0; i < rss.imgsSrc.Length; i++)
                                        //        imgList.Add(await HttpHelper.DownloadImageAsMemoryStream(rss.imgsSrc[i]));
                                        //    LogHelper.WriteInfoLog($"全部图片下载成功");
                                        //}

                                        LogHelper.WriteInfoLog($"需要转发的组:{item.ForwardGroups.Length}个");
                                        if (item.ForwardGroups.Length > 0 )
                                        {
                                            GreenOnionsMessageGroup groupResultMsg = new GreenOnionsMessageGroup();

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
                                                //MemoryStream stream = new MemoryStream(imgList[i].ToArray());
                                                groupResultMsg.Add(new GreenOnionsImageMessage(rss.imgsSrc[i]));
                                                //stream.Dispose();
                                            }

                                            groupResultMsg.Add($"\r\n更新时间:{rss.pubDate}");
                                            groupResultMsg.Add($"\r\n原文地址:{rss.link}");

                                            LogHelper.WriteInfoLog($"组合群消息完成");

                                            if (item.SendByForward)
                                            {
                                                LogHelper.WriteInfoLog($"发送模式为合并转发");
                                                //ForwardMessage forwardMessage = new ForwardMessage(new[] { new ForwardMessageNode()
                                                //{
                                                //    Id = 0,
                                                //    Name = BotInfo.BotName,
                                                //    QQNumber = BotInfo.QQId,
                                                //    Time = DateTime.Now,
                                                //    Chain = chatGroupMessages.Select( c => c as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage).ToArray(),
                                                //}});

                                                GreenOnionsForwardMessage greenOnionsForwardMessage = new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, groupResultMsg);

                                                for (int i = 0; i < item.ForwardGroups.Length; i++)
                                                {
                                                    SendMessage(greenOnionsForwardMessage, -1, item.ForwardGroups[i]);
                                                }
                                            }
                                            else
                                            {
                                                LogHelper.WriteInfoLog($"发送模式为直接发送");
                                                for (int i = 0; i < item.ForwardGroups.Length; i++)
                                                {
                                                    SendMessage(groupResultMsg, -1, item.ForwardGroups[i]);
                                                }
                                            }
                                            LogHelper.WriteInfoLog($"全部群消息发送完毕");
                                        }
                                        LogHelper.WriteInfoLog($"需要转发的好友:{item.ForwardQQs.Length}个");
                                        if (item.ForwardQQs.Length > 0)
                                        {
                                            GreenOnionsMessageGroup friendResultMsg = new GreenOnionsMessageGroup();

                                            friendResultMsg.Add(titleMsg);
                                            if (translateMsg != null)
                                                friendResultMsg.Add(translateMsg);

                                            for (int i = 0; i < rss.imgsSrc.Length; i++)
                                            {
                                                //MemoryStream stream = new MemoryStream(imgList[i].ToArray());
                                                friendResultMsg.Add(new GreenOnionsImageMessage(rss.imgsSrc[i]));
                                                //stream.Dispose();
                                            }

                                            friendResultMsg.Add($"\r\n更新时间:{rss.pubDate}");
                                            friendResultMsg.Add($"\r\n原文地址:{rss.link}");

                                            LogHelper.WriteInfoLog($"组合好友消息完成");

                                            if (item.SendByForward)
                                            {
                                                LogHelper.WriteInfoLog($"发送模式为合并转发");
                                                //ForwardMessage forwardMessage = new ForwardMessage(new[] { new ForwardMessageNode()
                                                //{
                                                //    Id = 0,
                                                //    Name = BotInfo.BotName,
                                                //    QQNumber = BotInfo.QQId,
                                                //    Time = DateTime.Now,
                                                //    Chain = chatFriendMessages.Select( c => c as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage).ToArray(),
                                                //}});
                                                GreenOnionsForwardMessage greenOnionsForwardMessage = new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, friendResultMsg);

                                                for (int i = 0; i < item.ForwardQQs.Length; i++)
                                                {
                                                    SendMessage(friendResultMsg, item.ForwardQQs[i], -1);
                                                }
                                            }
                                            else
                                            {
                                                LogHelper.WriteInfoLog($"发送模式为直接发送");
                                                for (int i = 0; i < item.ForwardQQs.Length; i++)
                                                {
                                                    SendMessage(friendResultMsg, item.ForwardQQs[i], -1);
                                                }
                                            }
                                            LogHelper.WriteInfoLog($"全部好友消息发送完毕");
                                        }

                                        if (Cache.LastOneSendRssTime.ContainsKey(item.Url))
                                            Cache.LastOneSendRssTime[item.Url] = rss.pubDate;
                                        else
                                            Cache.LastOneSendRssTime.TryAdd(item.Url, rss.pubDate);  //群和好友均推送完毕后记录此地址的最后更新时间
                                        Cache.LastOneSendRssTime = Cache.LastOneSendRssTime;
                                        JsonHelper.SaveCacheFile();

                                        LogHelper.WriteInfoLog($"记录{item.Url}最后更新时间完毕");

                                        //if (rss.iframseSrc.Length > 0)  //视频或内嵌网页没想好怎么处理
                                        //{

                                        //}
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteErrorLogWithUserMessage("获取RSS错误",ex, $"请求地址为:{item.Url}");
                            }
                        }
                        await Task.Delay((int)Math.Round(BotInfo.ReadRssInterval * 1000 * 60));
                    }
                });
            }
        }

        private static IEnumerable<(string title, string description, string[] imgsSrc, string[] iframseSrc, DateTime pubDate, string link)> ReadRss(string url)
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
                            string[] iframesSrc = null;
                            foreach (XmlNode subNode in subNodeList)
                            {
                                switch (subNode.Name.ToLower())
                                {
                                    case "description":
                                        description = subNode.InnerText;
                                        MatchCollection imgMatches = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        int iImage = 0;
                                        imgsSrc = new string[imgMatches.Count];
                                        foreach (Match match in imgMatches)
                                        {
                                            description = description.Replace(match.Groups[0].Value, "");
                                            imgsSrc[iImage++] = match.Groups["imgUrl"].Value.Replace("&amp;", "&");
                                        }
                                        MatchCollection iframeMatches = new Regex(@"<iframe\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<iframeUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        int iIframe = 0;
                                        iframesSrc = new string[iframeMatches.Count];
                                        foreach (Match match in iframeMatches)
                                        {
                                            description = description.Replace(match.Groups[0].Value, "");
                                            iframesSrc[iIframe++] = match.Groups["iframeUrl"].Value.Replace("&amp;", "&");
                                        }

                                        MatchCollection aMatches = new Regex(@"<a\b[^<>]*?\bhref[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<aTag>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase).Matches(subNode.InnerXml);
                                        foreach (Match match in aMatches)
                                        {
                                            if (match.Groups.Count > 1)
                                                description = description.Replace(match.Groups[0].Value, match.Groups[1].Value);
                                            else
                                                description = description.Replace(match.Groups[0].Value, "");
                                        }

                                        description = description.Replace("<br>", "\r\n").Replace("</a>", "").Replace("</iframe>", "").Replace("<p>", "").Replace("</p>", "\r\n").Replace("&amp;", "&");

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
                            yield return (title, description, imgsSrc, iframesSrc, pubDate, link);
                        }
                    }
                }
            }
        }
    }
}
