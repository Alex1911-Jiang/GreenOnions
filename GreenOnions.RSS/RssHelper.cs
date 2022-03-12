using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using GreenOnions.Utility.Items;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using IChatMessage = Mirai.CSharp.Models.ChatMessages.IChatMessage;
using System.Linq;

namespace GreenOnions.RSS
{
    public static class RssHelper
    {
        private static Task _RssWorker = null;
        public static void StartRssTask(Func<UploadTarget, Stream, Task<Mirai.CSharp.Models.ChatMessages.IImageMessage>> UploadPicture, Action<long, IChatMessage[], UploadTarget> SendMessage)
        {
            if (BotInfo.RssEnabled && BotInfo.IsLogin)
            {
                if (_RssWorker != null && !_RssWorker.IsCompleted && !_RssWorker.IsCanceled && !_RssWorker.IsFaulted)
                    return;
                _RssWorker = Task.Run(async () =>
                {
                    while (BotInfo.RssEnabled && BotInfo.IsLogin)
                    {
                        foreach (RssSubscriptionItem item in BotInfo.RssSubscription)  //若干条订阅地址
                        {
                            //如果在调试模式并且转发的QQ和群组均不在管理员和调试群组集合中时不去请求
                            if (BotInfo.DebugMode && ((BotInfo.DebugReplyAdminOnly && item.ForwardQQs.Intersect(BotInfo.AdminQQ).Count() == 0) || (BotInfo.OnlyReplyDebugGroup && item.ForwardGroups.Intersect(BotInfo.DebugGroups).Count() == 0)))
                                continue;
                            try
                            {
                                if (item.ForwardGroups.Length == 0 && item.ForwardQQs.Length == 0)
                                    continue;
                                if (!Cache.LastOneSendRssTime.ContainsKey(item.Url))  //如果不存在上次发送的日期记录
                                {
                                    Cache.LastOneSendRssTime.TryAdd(item.Url, DateTime.Now);  //添加现在作为起始日期(避免把所有历史信息全都抓过来发送)
                                    Cache.LastOneSendRssTime = Cache.LastOneSendRssTime;
                                    JsonHelper.SaveCacheFile();
                                    continue;
                                }
                                foreach (var rss in ReadRss(item.Url))  //每条订阅地址可能获取到若干条更新
                                {
                                    if (rss.pubDate > Cache.LastOneSendRssTime[item.Url])
                                    {
                                        PlainMessage titleMsg = new PlainMessage($"{rss.title}更新啦:\r\n{rss.description}");
                                        PlainMessage translateMsg = null;
                                        if (item.Translate)
                                        {
                                            string translatedText;
                                            if (item.TranslateFromTo)
                                                translatedText = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateFromTo(rss.description, item.TranslateFrom, item.TranslateTo) : YouDaoTranslateHelper.TranslateFromTo(rss.description, item.TranslateFrom, item.TranslateTo));
                                            else
                                                translatedText = await (BotInfo.TranslateEngineType == TranslateEngine.Google ? GoogleTranslateHelper.TranslateToChinese(rss.description) : YouDaoTranslateHelper.TranslateToChinese(rss.description));
                                            translateMsg = new PlainMessage($"\r\n以下为翻译内容:\r\n{ translatedText }");
                                        }

                                        List<MemoryStream> imgList = null;
                                        if (rss.imgsSrc.Length > 0)
                                        {
                                            imgList = new List<MemoryStream>();
                                            for (int i = 0; i < rss.imgsSrc.Length; i++)
                                                imgList.Add(await HttpHelper.DownloadImageAsMemoryStream(rss.imgsSrc[i]));
                                        }

                                        if (item.ForwardGroups.Length > 0 )
                                        {
                                            List<IChatMessage> chatGroupMessages = new List<IChatMessage>();
                                            chatGroupMessages.Add(titleMsg);
                                            if (translateMsg != null)
                                                chatGroupMessages.Add(translateMsg);

                                            if (imgList != null)
                                            {
                                                for (int i = 0; i < imgList.Count; i++)
                                                {
                                                    MemoryStream stream = new MemoryStream(imgList[i].ToArray());
                                                    chatGroupMessages.Add(await UploadPicture(UploadTarget.Group, stream));
                                                    stream.Dispose();
                                                }
                                            }

                                            chatGroupMessages.Add(new PlainMessage($"\r\n更新时间:{rss.pubDate}"));
                                            chatGroupMessages.Add(new PlainMessage($"\r\n原文地址:{rss.link}"));

                                            if (item.SendByForward)
                                            {
                                                ForwardMessage forwardMessage = new ForwardMessage(new[] { new ForwardMessageNode()
                                                {
                                                    Id = 0,
                                                    Name = BotInfo.BotName,
                                                    QQNumber = BotInfo.QQId,
                                                    Time = DateTime.Now,
                                                    Chain = chatGroupMessages.Select( c => c as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage).ToArray(),
                                                }});
                                                for (int i = 0; i < item.ForwardGroups.Length; i++)
                                                {
                                                    if (!BotInfo.DebugMode || BotInfo.DebugGroups.Contains(item.ForwardGroups[i]))
                                                        SendMessage?.Invoke(item.ForwardGroups[i], new[] { forwardMessage }, UploadTarget.Group);
                                                }
                                            }
                                            else
                                            {
                                                for (int i = 0; i < item.ForwardGroups.Length; i++)
                                                {

                                                    if (!BotInfo.DebugMode || BotInfo.DebugGroups.Contains(item.ForwardGroups[i]))
                                                        SendMessage?.Invoke(item.ForwardGroups[i], chatGroupMessages.ToArray(), UploadTarget.Group);
                                                }
                                            }
                                        }
                                        if (item.ForwardQQs.Length > 0)
                                        {
                                            List<IChatMessage> chatFriendMessages = new List<IChatMessage>();
                                            chatFriendMessages.Add(titleMsg);
                                            if (translateMsg != null)
                                                chatFriendMessages.Add(translateMsg);

                                            if (imgList != null)
                                            {
                                                for (int i = 0; i < imgList.Count; i++)
                                                {
                                                    MemoryStream stream = new MemoryStream(imgList[i].ToArray());
                                                    chatFriendMessages.Add(await UploadPicture(UploadTarget.Friend, stream));
                                                    stream.Dispose();
                                                }
                                            }

                                            chatFriendMessages.Add(new PlainMessage($"\r\n更新时间:{rss.pubDate}"));
                                            chatFriendMessages.Add(new PlainMessage($"\r\n原文地址:{rss.link}"));

                                            if (item.SendByForward)
                                            {
                                                ForwardMessage forwardMessage = new ForwardMessage(new[] { new ForwardMessageNode()
                                                {
                                                    Id = 0,
                                                    Name = BotInfo.BotName,
                                                    QQNumber = BotInfo.QQId,
                                                    Time = DateTime.Now,
                                                    Chain = chatFriendMessages.Select( c => c as Mirai.CSharp.HttpApi.Models.ChatMessages.IChatMessage).ToArray(),
                                                }});
                                                for (int i = 0; i < item.ForwardQQs.Length; i++)
                                                {
                                                    if (!BotInfo.DebugMode || BotInfo.AdminQQ.Contains(item.ForwardQQs[i]))
                                                        SendMessage?.Invoke(item.ForwardQQs[i], new[] { forwardMessage }, UploadTarget.Friend);
                                                }
                                            }
                                            else
                                            {
                                                for (int i = 0; i < item.ForwardQQs.Length; i++)
                                                {
                                                    if (!BotInfo.DebugMode || BotInfo.AdminQQ.Contains(item.ForwardQQs[i]))
                                                        SendMessage?.Invoke(item.ForwardQQs[i], chatFriendMessages.ToArray(), UploadTarget.Friend);
                                                }
                                            }
                                        }

                                        if (Cache.LastOneSendRssTime.ContainsKey(item.Url))
                                            Cache.LastOneSendRssTime[item.Url] = rss.pubDate;
                                        else
                                            Cache.LastOneSendRssTime.TryAdd(item.Url, rss.pubDate);  //群和好友均推送完毕后记录此地址的最后更新时间
                                        Cache.LastOneSendRssTime = Cache.LastOneSendRssTime;
                                        JsonHelper.SaveCacheFile();

                                        //if (rss.iframseSrc.Length > 0)  //视频或内嵌网页没想好怎么处理
                                        //{

                                        //}
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorHelper.WriteErrorLogWithUserMessage("获取RSS错误",ex, $"请求地址为:{item.Url}");
                            }
                        }
                        await Task.Delay(BotInfo.ReadRssInterval * 1000 * 60);
                    }
                });
            }
        }

        private static IEnumerable<(string title, string description, string[] imgsSrc, string[] iframseSrc, DateTime pubDate, string link)> ReadRss(string url)
        {
            if (url != string.Empty)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                string title = doc.GetElementsByTagName("title")[0].InnerText;
                XmlNodeList nodeList = doc.GetElementsByTagName("item");
                if (doc.HasChildNodes)
                {
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
                            yield return (title, description, imgsSrc, iframesSrc, pubDate, link);
                        }
                    }
                }
            }
        }
    }
}
