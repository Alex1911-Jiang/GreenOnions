using GreenOnions.Model;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace GreenOnions.PictureSearcher
{
    public static class SearchPictureHandler
    {
        public static void SearchOn(long qqId, Action<GreenOnionsMessages> SendMessage)
        {
            if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
            {
                Cache.SearchingPicturesUsers[qqId] = DateTime.Now.AddMinutes(1);
                SendMessage(BotInfo.SearchModeAlreadyOnReply.ReplaceGreenOnionsTags());
            }
            else
            {
                Cache.SearchingPicturesUsers.TryAdd(qqId, DateTime.Now.AddMinutes(1));
                SendMessage(BotInfo.SearchModeOnReply.ReplaceGreenOnionsTags());
                Cache.SetWorkingTimeout(qqId, Cache.SearchingPicturesUsers, () =>
                {
                    if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
                        Cache.SearchingPicturesUsers.TryRemove(qqId, out _);
                    SendMessage(BotInfo.SearchModeTimeOutReply.ReplaceGreenOnionsTags());
                });
            }
        }

        public static void UpdateSearchTime(long qqId)
        {
            if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
                Cache.SearchingPicturesUsers[qqId] = DateTime.Now.AddMinutes(1);
        }

        public static void SearchOff(long qqId, Action<GreenOnionsMessages> SendMessage)
        {
            if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
            {
                Cache.SearchingPicturesUsers.TryRemove(qqId, out _);
                SendMessage(BotInfo.SearchModeOffReply.ReplaceGreenOnionsTags());
            }
            else
            {
                SendMessage(BotInfo.SearchModeAlreadyOffReply.ReplaceGreenOnionsTags());
            }
        }

        public static void SearchPicture(GreenOnionsImageMessage inImgMsg, Action<GreenOnionsMessages> SendMessage)
        {
            LogHelper.WriteInfoLog("进入搜图处理事件");

            if (!string.IsNullOrWhiteSpace(BotInfo.SearchingReply))
                if (BotInfo.SearchEnabledTraceMoe || BotInfo.SearchEnabledSauceNao || BotInfo.SearchEnabledASCII2D)  //至少启用了一种搜图引擎
                    SendMessage(BotInfo.SearchingReply);  //正在搜索中提示
            
            string qqImgUrl = ImageHelper.ReplaceGroupUrl(inImgMsg.Url);
            LogHelper.WriteInfoLog($"需要搜图的地址为:{qqImgUrl}");
            try
            {
                List<Task> searchTasks = null;
                List<GreenOnionsMessages> outMessages = null;
                if (BotInfo.SearchSendByForward)
                { 
                    searchTasks = new List<Task>();
                    outMessages = new List<GreenOnionsMessages>();
                }

                if (BotInfo.SearchEnabledTraceMoe)
                {
                    Task<GreenOnionsMessages> traceMoeTask = SearchTraceMoe(qqImgUrl);
                    if (BotInfo.SearchSendByForward)
                    {
                        searchTasks.Add(traceMoeTask);
                        traceMoeTask.ContinueWith(callback =>
                        {
                            if (callback.Result != null)  //只有高于发送阈值时才会返回
                                outMessages.Add(callback.Result);
                        });
                    }
                    else
                        traceMoeTask.ContinueWith(callback => SendMessage(callback.Result));
                }
                if (BotInfo.SearchEnabledSauceNao)
                {
                    Task<(GreenOnionsMessages OutMessages, bool DoAscii2dSearch)> sauceNaoTask = SearchSauceNao(qqImgUrl, SendMessage);
                    if (BotInfo.SearchSendByForward)
                    { 
                        searchTasks.Add(sauceNaoTask);
                        sauceNaoTask.ContinueWith(sauceNaoCallback => outMessages.Add(sauceNaoCallback.Result.OutMessages));

                        if (BotInfo.SearchEnabledASCII2D)  //合并转发不能等到SauceNao结果回来之后再开启Ascii2D, 直接一起搜
                        {
                            Task<GreenOnionsMessages> ascii2dTask = SearchAscii2D(qqImgUrl);
                            searchTasks.Add(ascii2dTask);
                            ascii2dTask.ContinueWith(ascii2dCallback => outMessages.Add(ascii2dCallback.Result));
                        }
                    }
                    else
                    {
                        sauceNaoTask.ContinueWith(callback =>
                        {
                            var sauceNaoSearchResult = callback.Result;
                            if (BotInfo.SearchEnabledASCII2D && sauceNaoSearchResult.DoAscii2dSearch)
                            {
                                sauceNaoSearchResult.OutMessages.Add("\r\n自动使用ASCII2D搜索。");
                                _ = SearchAscii2D(qqImgUrl).ContinueWith(callback => SendMessage(callback.Result));  //直接发送
                            }
                            SendMessage(sauceNaoSearchResult.OutMessages);
                        });
                    }
                }
                else if (BotInfo.SearchEnabledASCII2D)  //不启用SauceNao只启用ASCII2D
                {
                    LogHelper.WriteInfoLog("没有启用SauceNao");
                    Task<GreenOnionsMessages> ascii2dTask = SearchAscii2D(qqImgUrl);
                    if (BotInfo.SearchSendByForward)
                    {
                        searchTasks.Add(ascii2dTask);
                        ascii2dTask.ContinueWith(callback =>
                        {
                            if (callback.Result != null)
                                outMessages.Add(callback.Result);
                        });
                    }
                    else
                        ascii2dTask.ContinueWith(callback => SendMessage(callback.Result));
                }

                if (BotInfo.SearchSendByForward)
                {
                    Task.Factory.ContinueWhenAll(searchTasks.ToArray(), callback =>
                    {
                        GreenOnionsForwardMessage[] forwardMessages = outMessages.Select(msg => new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, msg)).ToArray();
                        SendMessage(forwardMessages);  //合并转发
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                SendMessage("搜图服务器爆炸惹_(:3」∠)_ " + ex.Message);
            }
        }

        private static async Task<GreenOnionsMessages> SearchTraceMoe(string qqImgUrl)
        {
            LogHelper.WriteInfoLog("进入TraceMoe搜图逻辑");
            if (!qqImgUrl.StartsWith(@"http://") && !qqImgUrl.StartsWith(@"https://"))
            {
                qqImgUrl = "http://" + qqImgUrl;
            }
            string TraceMoeUrl = @$"https://api.trace.moe/search?anilistInfo&url={qqImgUrl}";  //https://trace.moe/?url=  //https://trace.moe/api/search?url=
            try
            {
                LogHelper.WriteInfoLog($"请求TraceMoe, 地址为:{TraceMoeUrl}");
                string strSauceTraceMoe = await HttpHelper.GetHttpResponseStringAsync(TraceMoeUrl);
                LogHelper.WriteInfoLog($"请求TraceMoe成功");
                JToken json = JsonConvert.DeserializeObject<JToken>(strSauceTraceMoe);
                JArray jResults = json["result"] as JArray;
                if (jResults.Count > 0)
                {
                    LogHelper.WriteInfoLog($"成功解析TraceMoe响应文");
                    double similarity = Math.Round(Convert.ToDouble(jResults[0]["similarity"]), 4) * 100; //相似度
                    if (similarity >= BotInfo.TraceMoeSendThreshold)
                    {
                        LogHelper.WriteInfoLog($"相似度大于设定值, 读取番剧信息");
                        string id = jResults[0]["anilist"]["id"].ToString();
                        string anime = jResults[0]["anilist"]["title"]["native"].ToString();  //动画名称
                        string synonyms = jResults[0]["anilist"]["synonyms"].ToString();  //别名
                        bool isAdult = Convert.ToBoolean(jResults[0]["anilist"]["isAdult"]);

                        string episode = "1";
                        if (!string.IsNullOrEmpty(jResults[0]["episode"].ToString()))
                            episode = jResults[0]["episode"].ToString();  //集数
                        string from = jResults[0]["from"].ToString(); //时间
                        int seconds = (int)Convert.ToSingle(from); //时间
                        TimeSpan timeSpan = new TimeSpan(0, 0, seconds);
                        string time = $"{timeSpan.Hours}小时{timeSpan.Minutes}分{timeSpan.Seconds}秒";
                        string previewSize = "m";
                        string imgUrl = jResults[0]["image"].ToString() + $"&size={previewSize}";
                        string imgName = Path.Combine(ImageHelper.ImagePath, $"TraceMoe_{id}_{previewSize}.png");

                        GreenOnionsMessages outMessage = new GreenOnionsMessages();

                        outMessage.Add($"动画名称:{anime}\r\n其他名称:{synonyms}\r\n相似度:{similarity}% (trace.moe)\r\n里:{(isAdult ? "是" : "否")}\r\n第{episode}集 {time}处\r\n");

                        //TraceMoe缩略图
                        try
                        {
                            string notHealth = Path.Combine(ImageHelper.ImagePath, $"TraceMoe_{id}_{previewSize}_NotHealth.png");
                            string healthed = Path.Combine(ImageHelper.ImagePath, $"TraceMoe_{id}_{previewSize}_Healthed.png");
                            await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled, imgUrl, imgName, outMessage, notHealth, healthed);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteErrorLog(ex);
                            outMessage.Add(BotInfo.SearchDownloadThuImageFailReply.ReplaceGreenOnionsTags());
                        }

                        LogHelper.WriteInfoLog($"TraceMoe搜番完成");
                        return outMessage;
                    }
                    else 
                        return null;  //相似度低于发送阈值
                }
                else
                    return null;  //没有搜索结果
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLogWithUserMessage("TraceMoe搜番失败, 内容解析错误", ex, $"请求地址为：{TraceMoeUrl}");
                return BotInfo.SearchErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "TraceMoe")) + ex.Message;
            }
        }

        private static async Task CheckPornAndCache(bool checkPorn, string imgUrl, string imgName, GreenOnionsMessages message, string notHealth, string healthed)
        {
            if (File.Exists(imgName))  //存在本地缓存
            {
                LogHelper.WriteInfoLog($"存在TraceMoe缩略图本地缓存");
                if (checkPorn)  //鉴黄
                {
                    if (File.Exists(notHealth))  //曾经鉴黄不通过的
                        message.Add(BotInfo.SearchCheckPornIllegalReply); //鉴黄不通过
                    else if (File.Exists(healthed))  //曾经鉴黄通过的
                        message.Add(new GreenOnionsImageMessage(imgName));
                    else  //曾经没参与鉴黄的
                    {
                        switch (TencentCloudHelper.CheckImageHealth(imgName, out string CheckPornErrMsg))
                        {
                            case TencentCloudHelper.CheckedPornStatus.Healthed:  //健康
                                message.Add(new GreenOnionsImageMessage(imgName));
                                File.Copy(imgName, healthed, true);
                                break;
                            case TencentCloudHelper.CheckedPornStatus.NotHealth:  //不健康
                                message.Add(BotInfo.SearchCheckPornIllegalReply.ReplaceGreenOnionsTags());
                                File.Copy(imgName, notHealth, true);
                                break;
                            case TencentCloudHelper.CheckedPornStatus.Error:  //错误
                                message.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags());
                                break;
                            case TencentCloudHelper.CheckedPornStatus.OutOfLimit:  //超过限制
                                message.Add(BotInfo.SearchCheckPornOutOfLimitReply.ReplaceGreenOnionsTags());
                                break;
                        }
                    }
                }
                else  //不鉴黄
                {
                    message.Add(new GreenOnionsImageMessage(imgName));
                }
            }
            else  //没有本地缓存
            {
                LogHelper.WriteInfoLog($"不存在TraceMoe缩略图本地缓存");
                try
                {
                    using (MemoryStream stream = await HttpHelper.DownloadImageAsMemoryStreamAsync(imgUrl))
                    {
                        File.WriteAllBytes(imgName, stream.ToArray());
                        if (checkPorn)  //鉴黄
                        {
                            LogHelper.WriteInfoLog($"下载TraceMoe缩略图");

                            switch (TencentCloudHelper.CheckImageHealth(stream.ToArray(), out string CheckPornErrMsg))
                            {
                                case TencentCloudHelper.CheckedPornStatus.Healthed:  //健康
                                    message.Add(new GreenOnionsImageMessage(stream));
                                    File.WriteAllBytes(healthed, stream.ToArray());
                                    break;
                                case TencentCloudHelper.CheckedPornStatus.NotHealth:  //不健康
                                    message.Add(BotInfo.SearchCheckPornIllegalReply.ReplaceGreenOnionsTags());
                                    File.WriteAllBytes(notHealth, stream.ToArray());
                                    break;
                                case TencentCloudHelper.CheckedPornStatus.Error:  //错误
                                    message.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags());
                                    break;
                                case TencentCloudHelper.CheckedPornStatus.OutOfLimit:  //超过限制
                                    message.Add(BotInfo.SearchCheckPornOutOfLimitReply.ReplaceGreenOnionsTags());
                                    break;
                            }
                        }
                        else  //不鉴黄
                        {
                            message.Add(new GreenOnionsImageMessage(imgUrl));
                        }
                    }
                }
                catch (Exception ex)
                {
                    message.Add(BotInfo.SearchDownloadThuImageFailReply);
                }
            }
        }

        /// <summary>
        /// SauceNao搜图
        /// </summary>
        /// <param name="qqImgUrl"></param>
        /// <returns>搜图结果, 是否使用Ascii2D搜索</returns>
        private static async Task<(GreenOnionsMessages OutMessages, bool DoAscii2dSearch)> SearchSauceNao(string qqImgUrl, Action<GreenOnionsMessages> SendMessage)
        {
            LogHelper.WriteInfoLog("进入SauceNao搜图逻辑");
            string apiKeyStr = "";
            string apiKey = "";
            if (Cache.SauceNaoKeysAndShortRemaining.Count > 0)
            {
                var source = Cache.SauceNaoKeysAndShortRemaining.OrderByDescending(p => p.Value).ToDictionary(k => k.Key, v => v.Value);
                foreach (KeyValuePair<string, int> item in source)
                {
                    if (Cache.SauceNaoKeysAndShortRemaining[item.Key] > 0 && Cache.SauceNaoKeysAndLongRemaining[item.Key] > 0)
                    {
                        apiKey = item.Key;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(apiKey))  //本地记录key次数耗尽, 不携带Key去搜图
                    LogHelper.WriteWarningLog("SauceNao所有Key搜图次数均耗尽");
                else
                    apiKeyStr = $"&api_key={apiKey}";
            }

            string strSauceNaoResult;
            string SauceNaoUrl = "";
            try
            {
                if (EventHelper.GetDocumentByBrowserEvent != null && BotInfo.HttpRequestByWebBrowser && BotInfo.SauceNaoRequestByWebBrowser)  //浏览器方式
                {
                    //html方式只有一个结果
                    SauceNaoUrl = @$"https://saucenao.com/search.php?db=999&output_type=0{apiKeyStr}&testmode=1&url={qqImgUrl}";

                    LogHelper.WriteInfoLog($"调用浏览器请求SauceNao搜图, 地址为:{SauceNaoUrl}");
                    strSauceNaoResult = EventHelper.GetDocumentByBrowserEvent(SauceNaoUrl).document;
                    LogHelper.WriteInfoLog($"调用浏览器请求SauceNao成功");

                    HtmlDocument docSauceNao = new HtmlDocument();
                    docSauceNao.LoadHtml(strSauceNaoResult);
                    string imgXPath = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttableimage']/div[@class='resultimage']/a/img";
                    string titleXPath = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttablecontent']/div[@class='resultcontent']/div[@class='resulttitle']/strong";
                    string resultXPath = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttablecontent']/div[@class='resultcontent']/div[@class='resultcontentcolumn']";
                    string resultSimilarity = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttablecontent']/div[@class='resultmatchinfo']/div[@class='resultsimilarityinfo']";
                    HtmlNode imgNode = docSauceNao.DocumentNode.SelectSingleNode(imgXPath);

                    if (imgNode == null)
                    {
                        LogHelper.WriteWarningLog($"SauceNao(浏览器)没有搜索到结果, 请求地址为：{SauceNaoUrl}");
                        File.WriteAllText("html.html", strSauceNaoResult);
                        return (BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "SauceNao")), true);  //没有结果并自动使用Ascii2D
                    }
                    else
                    {
                        LogHelper.WriteInfoLog("SauceNao存在结果");
                        string imgUrl = imgNode.Attributes["src"].Value.Replace("amp;", "");
                        string title = docSauceNao.DocumentNode.SelectSingleNode(titleXPath).InnerText;
                        float similarity = Convert.ToSingle(docSauceNao.DocumentNode.SelectSingleNode(resultSimilarity).InnerText.Replace("%", ""));
                        string strSimilarity = "相似度：" + docSauceNao.DocumentNode.SelectSingleNode(resultSimilarity).InnerText;
                        List<string> results = new List<string>();

                        string key = "";
                        foreach (HtmlNode node in docSauceNao.DocumentNode.SelectSingleNode(resultXPath).ChildNodes)
                        {
                            if (node.Name == "br")
                                continue;
                            else if (node.Name == "strong")
                                key = node.InnerText.Replace("Creator(s): ", "作者：").Replace("Creator: ", "作者：").Replace("Member: ", "作者：").Replace("Characters: ", "角色：").Replace("Material: ", "所属：").Replace("&amp;", "&");
                            else if (node.Name == "#text")
                            {
                                if (!string.IsNullOrEmpty(key))
                                {
                                    results.Add($"{key}{node.InnerText}");
                                    key = "";
                                }
                            }
                            else if (node.Name == "a")
                            {
                                if (!string.IsNullOrEmpty(key))
                                {
                                    results.Add($"{key}{node.InnerText}");
                                    key = "";
                                }
                                results.Add(node.Attributes["href"].Value);
                            }
                            else if (node.Name == "small")
                                results.Add(node.InnerText);
                        }

                        GreenOnionsMessages outMessage = new GreenOnionsMessages(string.Join("\r\n", results) + "\r\n" + strSimilarity + "(SauceNAO)\r\n");

                        #region -- 相似度过滤和鉴黄 --
                        //相似度大于发送缩略图的阈值
                        if (similarity > BotInfo.SearchSauceNAOLowSimilarity)
                        {
                            LogHelper.WriteInfoLog($"SauceNAO相似度大于发图设定值");

                            using (MemoryStream stream = await HttpHelper.DownloadImageAsMemoryStreamAsync(imgUrl))
                            {
                                LogHelper.WriteInfoLog($"SauceNAO下载缩略图成功");
                                //鉴黄
                                if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                                {
                                    //爬虫模式无法区分文本类型, 不进行缓存, 每次都重复鉴黄
                                    try
                                    {
                                        switch (TencentCloudHelper.CheckImageHealth(stream.ToArray(), out string CheckPornErrMsg))
                                        {
                                            case TencentCloudHelper.CheckedPornStatus.Healthed:  //健康
                                                outMessage.Add(new GreenOnionsImageMessage(stream));
                                                break;
                                            case TencentCloudHelper.CheckedPornStatus.NotHealth:  //不健康
                                                outMessage.Add(BotInfo.SearchCheckPornIllegalReply.ReplaceGreenOnionsTags());
                                                break;
                                            case TencentCloudHelper.CheckedPornStatus.Error:  //错误
                                                outMessage.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags());
                                                break;
                                            case TencentCloudHelper.CheckedPornStatus.OutOfLimit:  //超过限制
                                                outMessage.Add(BotInfo.SearchCheckPornOutOfLimitReply.ReplaceGreenOnionsTags());
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogHelper.WriteErrorLog(ex);
                                        outMessage.Add(BotInfo.SearchDownloadThuImageFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", ex.Message)));  //下载缩略图失败
                                    }
                                }
                                else
                                {
                                    outMessage.Add(new GreenOnionsImageMessage(imgUrl));
                                }
                                LogHelper.WriteInfoLog($"SauceNao(浏览器)搜图完成, 相似度高于发图设定值");
                                return (outMessage, similarity < BotInfo.SearchSauceNAOHighSimilarity);  //发缩略图, 判断相似度是否继续使用Ascii2D搜索
                            }
                        }
                        else
                        {
                            LogHelper.WriteInfoLog($"SauceNao(浏览器)搜图完成, 相似度低于发图设定值");
                            outMessage.Add(BotInfo.SearchLowSimilarityReply.ReplaceGreenOnionsTags());  //不显示缩略图
                            return (outMessage, similarity < BotInfo.SearchSauceNAOHighSimilarity);  //不发缩略图, 判断相似度是否继续使用Ascii2D搜索
                        }
                        #endregion -- 相似度过滤和鉴黄 --
                    }
                }
                else  //后端方式
                {
                    SauceNaoUrl = @$"https://saucenao.com/search.php?db=999&output_type=2{apiKeyStr}&testmode=1&numres=16&url={qqImgUrl}";

                    LogHelper.WriteInfoLog($"请求SauceNao搜图, 地址为:{SauceNaoUrl}");
                    strSauceNaoResult = await HttpHelper.GetHttpResponseStringAsync(SauceNaoUrl);
                    LogHelper.WriteInfoLog($"请求SauceNao成功");

                    JToken json = JsonConvert.DeserializeObject<JToken>(strSauceNaoResult);

                    JToken jHeader = json["header"];
                    if (jHeader != null)
                    {
                        Cache.SauceNaoKeysAndLongRemaining[apiKey] = Convert.ToInt32(jHeader["long_remaining"]);
                        Cache.SauceNaoKeysAndShortRemaining[apiKey] = Convert.ToInt32(jHeader["short_remaining"]);
                    }

                    JArray jResults = json["results"] as JArray;

                    if (BotInfo.SearchSauceNAOSortByDesc)
                        jResults = new JArray(jResults.OrderByDescending(x => x["header"]["similarity"]));  //按相似度排序

                    if (jResults == null)
                    {
                        LogHelper.WriteWarningLog($"SauceNao(后端)没有搜索到结果, 请求地址为：{SauceNaoUrl}");
                        return (BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "SauceNao")), true);  //没有结果并自动使用Ascii2D
                    }

                    LogHelper.WriteInfoLog($"成功解析SauceNao响应文");

                    for (int j = 0; j < jResults.Count; j++)
                    {
                        JToken jItemHeader = jResults[j]["header"];
                        JToken jData = jResults[j]["data"];

                        SauceNaoItem sauceNaoItem = new SauceNaoItem();

                        sauceNaoItem.similarity = Convert.ToSingle(jItemHeader["similarity"]);
                        sauceNaoItem.thumbnail = jItemHeader["thumbnail"].ToString();  //缩略图地址
                        sauceNaoItem.index_name = jItemHeader["index_name"].ToString();  //index_name

                        if (jData["ext_urls"] != null)
                        {
                            sauceNaoItem.ext_urls = new List<string>();
                            foreach (JToken ext_url in jData["ext_urls"])
                            {
                                sauceNaoItem.ext_urls.Add(ext_url.ToString());
                            }
                        }
                        #region -- Pixiv体系 --
                        sauceNaoItem.title = jData["title"]?.ToString();  //作品标题
                        sauceNaoItem.pixiv_id = jData["pixiv_id"]?.ToString();
                        sauceNaoItem.member_name = jData["member_name"]?.ToString();  //作者名称
                        sauceNaoItem.member_id = jData["member_id"]?.ToString();
                        #endregion -- Pixiv体系 --

                        #region -- 其他体系 --
                        sauceNaoItem.creator = jData["creator"]?.ToString();  //作者
                        sauceNaoItem.material = jData["material"]?.ToString();  //所属
                        sauceNaoItem.characters = jData["characters"]?.ToString();  //角色
                        sauceNaoItem.source = jData["source"]?.ToString();  //图片来源
                        #endregion -- 其他体系 --

                        //如果优先度高的没有地址
                        if (sauceNaoItem.ext_urls == null)
                        {
                            LogHelper.WriteInfoLog($"搜图结果不含来源地址, 查找相似度低一级的结果");
                            continue;
                        }

                        StringBuilder stringBuilder = new StringBuilder();

                        if (sauceNaoItem.ext_urls != null)
                        {
                            string sauceNaoUrl = "";
                            if (sauceNaoItem.ext_urls.Count == 1)
                            {
                                sauceNaoUrl = $"地址：{sauceNaoItem.ext_urls[0]}\r\n";
                            }
                            else
                            {
                                for (int k = 0; k < sauceNaoItem.ext_urls.Count; k++)
                                {
                                    sauceNaoUrl += $"地址{k + 1}：{sauceNaoItem.ext_urls[k].Replace("&amp;", "&")}\r\n";
                                }
                            }
                            stringBuilder.AppendLine(sauceNaoUrl);
                        }

                        LogHelper.WriteInfoLog($"搜索到包含{sauceNaoItem.ext_urls.Count}条地址");

                        if (!string.IsNullOrEmpty(sauceNaoItem.source)) 
                            stringBuilder.AppendLine("图片来源：" + HttpUtility.UrlDecode(sauceNaoItem.source));
                        stringBuilder.AppendLine($"相似度：{sauceNaoItem.similarity}%(SauceNAO)");  //一定有相似度
                        if (!string.IsNullOrEmpty(sauceNaoItem.title)) 
                            stringBuilder.AppendLine("标题：" + HttpUtility.UrlDecode(sauceNaoItem.title));
                        if (!string.IsNullOrEmpty(sauceNaoItem.member_name))
                            stringBuilder.AppendLine("作者：" + HttpUtility.UrlDecode(sauceNaoItem.member_name));
                        else if (!string.IsNullOrEmpty(sauceNaoItem.creator))
                            stringBuilder.AppendLine("作者：" + HttpUtility.UrlDecode(sauceNaoItem.creator));
                        if (!string.IsNullOrEmpty(sauceNaoItem.characters)) 
                            stringBuilder.AppendLine("角色：" + HttpUtility.UrlDecode(sauceNaoItem.characters));
                        if (!string.IsNullOrEmpty(sauceNaoItem.material))
                            stringBuilder.AppendLine("所属：" + HttpUtility.UrlDecode(sauceNaoItem.material));

                        GreenOnionsMessages outMessage = new GreenOnionsMessages(stringBuilder);

                        #region -- 相似度过滤和鉴黄 --
                        //相似度大于设定的阈值
                        if (sauceNaoItem.similarity > BotInfo.SearchSauceNAOLowSimilarity)
                        {
                            LogHelper.WriteInfoLog($"相似度大于发图设定值");
                            string imgName;
                            string notHealth;
                            string healthed;
                            if (sauceNaoItem.pixiv_id == null)
                            {
                                string urlMd5 = GreenOnionsTypeHelper.ComputeMD5(sauceNaoItem.thumbnail);
                                imgName = Path.Combine(ImageHelper.ImagePath, $"Thu_Other_{urlMd5}.png");
                                notHealth = Path.Combine(ImageHelper.ImagePath, $"Thu_Other_{urlMd5}_NotHealth.png");
                                healthed = Path.Combine(ImageHelper.ImagePath, $"Thu_Other_{urlMd5}_Healthed.png");
                            }
                            else
                            {
                                imgName = Path.Combine(ImageHelper.ImagePath, $"Thu_Pixiv{sauceNaoItem.pixiv_id}.png");
                                notHealth = Path.Combine(ImageHelper.ImagePath, $"Thu_Pixiv{sauceNaoItem.pixiv_id}_NotHealth.png");
                                healthed = Path.Combine(ImageHelper.ImagePath, $"Thu_Pixiv{sauceNaoItem.pixiv_id}_Healthed.png");
                            }
                            try
                            {
                                await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled, sauceNaoItem.thumbnail, imgName, outMessage, notHealth, healthed);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteErrorLog(ex);
                                outMessage.Add(BotInfo.SearchDownloadThuImageFailReply.ReplaceGreenOnionsTags());
                            }

                            LogHelper.WriteInfoLog($"鉴黄通过或不需要鉴黄");

                            if (BotInfo.SearchSauceNAOSendPixivOriginPicture)
                            {
                                //如果是pixiv体系尝试下载原图
                                if (sauceNaoItem.pixiv_id != null)
                                {
                                    Match matchBigImg = Regex.Match(sauceNaoItem.index_name, @$".+{sauceNaoItem.pixiv_id}_p([0-9]+)[_\.].+");
                                    if (matchBigImg.Groups.Count > 1)
                                    {
                                        LogHelper.WriteInfoLog($"图片来自Pixiv, 尝试下载原图");
                                        int p = Convert.ToInt32(matchBigImg.Groups[1].Value);
                                        string imgUrlHasP = $"https://pixiv.re/{sauceNaoItem.pixiv_id}-{p + 1}.png";
                                        if (p == 0)  //NAO返回的P为0
                                        {
                                            using (var httpClient = new HttpClient())
                                            {
                                                var catRouteTask = CheckCatRoute(Convert.ToInt64(sauceNaoItem.pixiv_id), -1);
                                                if (BotInfo.SearchSendByForward)
                                                {
                                                    string catRoute = await catRouteTask;
                                                    if (string.IsNullOrEmpty(catRoute))
                                                    {
                                                        string imgUrlNoP = $"https://pixiv.re/{sauceNaoItem.pixiv_id}.png";
                                                        outMessage.Add(new GreenOnionsImageMessage(imgUrlNoP));
                                                        DownloadImageArchive(imgUrlNoP, sauceNaoItem.pixiv_id, p);
                                                    }
                                                    else
                                                    {
                                                        outMessage.Add(new GreenOnionsImageMessage(imgUrlHasP));
                                                        DownloadImageArchive(imgUrlHasP, sauceNaoItem.pixiv_id, p);
                                                    }
                                                }
                                                else
                                                {
                                                    _ = catRouteTask.ContinueWith(t =>
                                                    {
                                                        if (string.IsNullOrEmpty(t.Result))
                                                        {
                                                            string imgUrlNoP = $"https://pixiv.re/{sauceNaoItem.pixiv_id}.png";
                                                            SendMessage(new GreenOnionsImageMessage(imgUrlNoP));
                                                            DownloadImageArchive(imgUrlNoP, sauceNaoItem.pixiv_id, p);
                                                        }
                                                        else
                                                        {
                                                            SendMessage(new GreenOnionsImageMessage(imgUrlHasP));
                                                            DownloadImageArchive(imgUrlHasP, sauceNaoItem.pixiv_id, p);
                                                        }
                                                    });
                                                }
                                            }
                                        }
                                        else  //地址有P且>0
                                        {
                                            if (BotInfo.SearchSendByForward)
                                                outMessage.Add(new GreenOnionsImageMessage(imgUrlHasP));
                                            else
                                                _ = Task.Run(() => SendMessage(new GreenOnionsImageMessage(imgUrlHasP)));
                                            DownloadImageArchive(imgUrlHasP, sauceNaoItem.pixiv_id, p);
                                        }

                                        //下载原图并存储
                                        void DownloadImageArchive(string url, string pixivID, int p)
                                        {
                                            Task.Run(() =>
                                            {
                                                string imgName = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{pixivID}_p{p}.png");
                                                if (!File.Exists(imgName) || new FileInfo(imgName).Length == 0)
                                                    HttpHelper.DownloadImageFile(url, imgName);  //仅下载
                                            });
                                        }
                                    }
                                }
                            }

                            LogHelper.WriteInfoLog($"SauceNao(后端)搜图完成, 相似度高于发图设定值");
                            return (outMessage, sauceNaoItem.similarity < BotInfo.SearchSauceNAOHighSimilarity);
                        }
                        else
                        {
                            LogHelper.WriteInfoLog($"相似度低于发图设定值");
                            outMessage.Add(BotInfo.SearchLowSimilarityReply.ReplaceGreenOnionsTags());
                            LogHelper.WriteInfoLog($"SauceNao(后端)搜图完成, 相似度低于发图设定值");
                            return (outMessage, sauceNaoItem.similarity < BotInfo.SearchSauceNAOHighSimilarity);
                        }
                        #endregion -- 相似度过滤和鉴黄 --
                    }
                }
            }
            catch (Exception ex)
            {
                GreenOnionsMessages outMessage = new GreenOnionsMessages();
                outMessage.Add("SauceNao搜图失败, " + ex.Message);

                if (ex.Message.Contains("429"))
                {
                    LogHelper.WriteWarningLog($"当前Key:{apiKey}的搜索次数已耗尽");
                    Cache.SauceNaoKeysAndLongRemaining[apiKey] = 0;
                    Cache.SauceNaoKeysAndShortRemaining[apiKey] = 0;
                    outMessage.Add("SauceNao搜索次数已耗尽。");
                }

                LogHelper.WriteErrorLogWithUserMessage("SauceNao搜图失败", ex, $"请求地址为：{SauceNaoUrl}");
                return (outMessage, true);
            }

            //没有结果
            return (BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "SauceNao")), true);
        }

        private static async Task<GreenOnionsMessages> SearchAscii2D(string qqImgUrl)
        {
            LogHelper.WriteInfoLog("进入Ascii2D搜图逻辑");

            GreenOnionsMessages outMessage = new GreenOnionsMessages();

            string strAscii2dColorResult = null;
            string strAscii2dBovwResult = null;
            string colorUrl = @$"https://ascii2d.net/search/url/{qqImgUrl}?type=color";
            string bovwUrl = null;

            if (EventHelper.GetDocumentByBrowserEvent != null && BotInfo.HttpRequestByWebBrowser && BotInfo.ASCII2DRequestByWebBrowser)  //使用浏览器请求
            {
                try
                {
                    LogHelper.WriteInfoLog($"调用浏览器请求ASCII2D颜色识别, 地址为:{colorUrl}");
                    var responseColor = EventHelper.GetDocumentByBrowserEvent(colorUrl);
                    strAscii2dColorResult = responseColor.document;
                    LogHelper.WriteInfoLog($"ASCII2D颜色识别请求成功, 跳转地址到特征识别");

                    try
                    {
                        bovwUrl = responseColor.jumpUrl.Replace("/color/", "/bovw/");
                        LogHelper.WriteInfoLog($"调用浏览器请求ASCII2D特征识别, 地址为:{bovwUrl}");
                        var responseBovw = EventHelper.GetDocumentByBrowserEvent(bovwUrl);
                        strAscii2dBovwResult = responseBovw.document;
                        LogHelper.WriteInfoLog($"ASCII2D特征识别请求成功");
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("ASCII2D特征(浏览器)搜索失败", ex, $"请求地址为：{bovwUrl}");
                        outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "ASCII2D特征")) + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage("ASCII2D颜色(浏览器)搜索失败", ex, $"请求地址为：{colorUrl}");
                    outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "ASCII2D颜色")) + ex.Message);
                }
            }
            else
            {
                try
                {
                    LogHelper.WriteInfoLog($"请求ASCII2D颜色识别, 地址为:{colorUrl}");
                    var response = await HttpHelper.GetHttpResponseStringAndJumpUrlAsync(colorUrl);
                    strAscii2dColorResult = response.document;
                    LogHelper.WriteInfoLog($"ASCII2D颜色识别请求成功, 跳转地址到特征识别");
                    try
                    {
                        bovwUrl = response.jumpUrl.Replace("/color/", "/bovw/");
                        strAscii2dBovwResult = await HttpHelper.GetHttpResponseStringAsync(bovwUrl);
                        LogHelper.WriteInfoLog($"ASCII2D特征识别请求成功");
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("ASCII2D特征(后端)搜索失败", ex, $"请求地址为：{colorUrl}");
                        outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "ASCII2D特征")) + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage("ASCII2D颜色(后端)搜索失败", ex, $"请求地址为：{colorUrl}");
                    outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "ASCII2D颜色")) + ex.Message);
                }
            }

            try
            {
                #region -- 颜色搜索 --
                if (!string.IsNullOrEmpty(strAscii2dColorResult))
                {
                    LogHelper.WriteInfoLog($"开始解析颜色搜索响应文");
                    HtmlDocument docColor = new HtmlDocument();
                    docColor.LoadHtml(strAscii2dColorResult);

                    for (int i = 2; i < BotInfo.SearchShowAscii2dCount + 2; i++)  //HtmlAgilityPack的索引从1开始, 且第1个位置是上传的图片, 故从2开始读取, 结果存在最多20个
                    {
                        //缩略图
                        HtmlNode nodeColorImg = docColor.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img");

                        //唯一哈希
                        HtmlNode nodeColorHash = docColor.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='hash']");

                        //地址(InnerText是作品标题, href是地址)
                        HtmlNode nodeColorWorks = docColor.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='detail-box gray-link']/h6/a[1]");

                        //作者(InnerText是作者名称, href是地址)
                        HtmlNode nodeColorCreator = docColor.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='detail-box gray-link']/h6/a[2]");

                        //来源
                        HtmlNode nodeColorSource = docColor.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='detail-box gray-link']/h6/small");

                        if (nodeColorWorks == null)
                        {
                            outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", $"ASCII2D颜色第{i}个结果")));
                        }
                        else
                        {
                            string img = nodeColorImg.Attributes["src"].Value.Replace("&amp;", "&");
                            string hash = nodeColorHash.InnerText;
                            string title = nodeColorWorks.InnerText;
                            string url = nodeColorWorks.Attributes["href"].Value.Replace("&amp;", "&");
                            string creator = nodeColorCreator.InnerText;
                            string home = nodeColorCreator.Attributes["href"].Value.Replace("&amp;", "&");
                            string source = nodeColorSource.InnerText;

                            LogHelper.WriteInfoLog($"成功解析颜色搜索响应文");
                            StringBuilder stringBuilderColor = new StringBuilder();
                            stringBuilderColor.AppendLine("ASCII2D 颜色搜索");
                            stringBuilderColor.AppendLine($"标题:{nodeColorWorks.InnerText}");
                            stringBuilderColor.AppendLine($"地址:{nodeColorWorks.Attributes["href"].Value.Replace("&amp;", "&")}");
                            if (nodeColorCreator != null)
                            {
                                stringBuilderColor.AppendLine($"作者:{nodeColorCreator.InnerText}");
                                stringBuilderColor.AppendLine($"主页:{nodeColorCreator.Attributes["href"].Value.Replace("&amp;", "&")}");
                            }
                            outMessage.Add(stringBuilderColor);  //文字结果
                            string imgUrl = "https://ascii2d.net" + nodeColorImg.Attributes["src"].Value.Replace("&amp;", "&");
                            string imgName = Path.Combine(ImageHelper.ImagePath, $"Ascii2D_{nodeColorHash.InnerHtml}.png");
                            string notHealth = Path.Combine(ImageHelper.ImagePath, $"Ascii2D_{nodeColorHash.InnerHtml}_NotHealth.png");
                            string healthed = Path.Combine(ImageHelper.ImagePath, $"Ascii2D_{nodeColorHash.InnerHtml}_Healthed.png");
                            try
                            {
                                await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled, imgUrl, imgName, outMessage, notHealth, healthed);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteErrorLog(ex);
                            }
                            outMessage.Add("\r\n");
                            LogHelper.WriteInfoLog($"ASCII2D颜色搜索完成");
                        }
                    }

                    #region -- 旧逻辑 --
                    //string pathColorItemBox = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']";
                    //HtmlNode nodeColorItemBox = docColor.DocumentNode.SelectNodes(pathColorItemBox)[2];
                    //string pathColorHash = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['hash']";
                    //string pathColorImage = "div['col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img";
                    //string pathColorUrlA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[1]";
                    //string pathColorMemberA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[2]";
                    //string pathColorUrlSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[1]/a";
                    //string pathColorMemberSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[2]/a";
                    //HtmlNode nodeColorHash = nodeColorItemBox.SelectSingleNode(pathColorHash);
                    //HtmlNode nodeColorImage = nodeColorItemBox.SelectSingleNode(pathColorImage);
                    //HtmlNode nodeColorUrl = nodeColorItemBox.SelectSingleNode(pathColorUrlA) ?? nodeColorItemBox.SelectSingleNode(pathColorUrlSmall);
                    //HtmlNode nodeColorMember = nodeColorItemBox.SelectSingleNode(pathColorMemberA) ?? nodeColorItemBox.SelectSingleNode(pathColorMemberSmall);
                    //StringBuilder stringBuilderColor = new StringBuilder();
                    #endregion -- 旧逻辑 --

                    #endregion -- 颜色搜索 --
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLogWithUserMessage("ASCII2D颜色搜索解析错误", ex, $"请求地址为:{colorUrl}\r\n请求结果为：{strAscii2dColorResult}");
                outMessage.Add(BotInfo.SearchErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "ASCII2D颜色")) + ex.Message);
            }

            outMessage.Add("\r\n\r\n");

            try
            {
                #region -- 特征搜索 --
                if (!string.IsNullOrEmpty(strAscii2dBovwResult))
                {
                    LogHelper.WriteInfoLog($"开始解析特征搜索响应文");
                    HtmlDocument docBovw = new HtmlDocument();
                    docBovw.LoadHtml(strAscii2dBovwResult);

                    for (int i = 2; i < BotInfo.SearchShowAscii2dCount + 2; i++)  //HtmlAgilityPack的索引从1开始, 且第1个位置是上传的图片, 故从2开始读取, 结果存在最多20个
                    {
                        //缩略图
                        HtmlNode nodeBovwImg = docBovw.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img");

                        //唯一哈希
                        HtmlNode nodeBovwHash = docBovw.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='hash']");

                        //地址(InnerText是作品标题, href是地址)
                        HtmlNode nodeBovwWorks = docBovw.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='detail-box gray-link']/h6/a[1]");

                        //作者(InnerText是作者名称, href是地址)
                        HtmlNode nodeBovwCreator = docBovw.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='detail-box gray-link']/h6/a[2]");

                        //来源
                        HtmlNode nodeBovwSource = docBovw.DocumentNode.SelectSingleNode($"/html/body/div[@class='container']/div[@class='row']/div[@class='col-xs-12 col-lg-8 col-xl-8']/div[@class='row item-box'][{i}]/div[@class='col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div[@class='detail-box gray-link']/h6/small");

                        if (nodeBovwWorks == null)
                        {
                            outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", $"ASCII2D特征第{i}个结果")));
                        }
                        else
                        {
                            string img = nodeBovwImg.Attributes["src"].Value.Replace("&amp;", "&");
                            string hash = nodeBovwHash.InnerText;
                            string title = nodeBovwWorks.InnerText;
                            string url = nodeBovwWorks.Attributes["href"].Value.Replace("&amp;", "&");
                            string creator = nodeBovwCreator.InnerText;
                            string home = nodeBovwCreator.Attributes["href"].Value.Replace("&amp;", "&");
                            string source = nodeBovwSource.InnerText;

                            LogHelper.WriteInfoLog($"成功解析特征搜索响应文");
                            StringBuilder stringBuilderBovw = new StringBuilder();
                            stringBuilderBovw.AppendLine("ASCII2D 特征搜索");
                            stringBuilderBovw.AppendLine($"标题:{nodeBovwWorks.InnerText}");
                            stringBuilderBovw.AppendLine($"地址:{nodeBovwWorks.Attributes["href"].Value.Replace("&amp;", "&")}");
                            if (nodeBovwCreator != null)
                            {
                                stringBuilderBovw.AppendLine($"作者:{nodeBovwCreator.InnerText}");
                                stringBuilderBovw.AppendLine($"主页:{nodeBovwCreator.Attributes["href"].Value.Replace("&amp;", "&")}");
                            }
                            outMessage.Add(stringBuilderBovw);  //文字结果
                            string imgUrl = "https://ascii2d.net" + nodeBovwImg.Attributes["src"].Value.Replace("&amp;", "&");
                            string imgName = Path.Combine(ImageHelper.ImagePath, $"Ascii2D_{nodeBovwHash.InnerHtml}.png");
                            string notHealth = Path.Combine(ImageHelper.ImagePath, $"Ascii2D_{nodeBovwHash.InnerHtml}_NotHealth.png");
                            string healthed = Path.Combine(ImageHelper.ImagePath, $"Ascii2D_{nodeBovwHash.InnerHtml}_Healthed.png");
                            try
                            {
                                await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled, imgUrl, imgName, outMessage, notHealth, healthed);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteErrorLog(ex);
                            }
                            outMessage.Add("\r\n");
                            LogHelper.WriteInfoLog($"ASCII2D特征搜索完成");
                        }
                    }

                    #region -- 旧逻辑 --
                    //string pathBovwItemBox = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']";
                    //HtmlNode nodeBovwItemBox = docBovw.DocumentNode.SelectNodes(pathBovwItemBox)[2];
                    //string pathBovwHash = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['hash']";
                    //string pathBovwImage = "div['col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img";
                    //string pathBovwUrlA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[1]";
                    //string pathBovwMemberA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[2]";
                    //string pathBovwUrlSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[1]/a";
                    //string pathBovwMemberSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[2]/a";
                    //HtmlNode nodeBovwHash = nodeBovwItemBox.SelectSingleNode(pathBovwHash);
                    //HtmlNode nodeBovwImage = nodeBovwItemBox.SelectSingleNode(pathBovwImage);
                    //HtmlNode nodeBovwUrl = nodeBovwItemBox.SelectSingleNode(pathBovwUrlA) ?? nodeBovwItemBox.SelectSingleNode(pathBovwUrlSmall);
                    //HtmlNode nodeBovwMember = nodeBovwItemBox.SelectSingleNode(pathBovwMemberA) ?? nodeBovwItemBox.SelectSingleNode(pathBovwMemberSmall);
                    #endregion -- 旧逻辑 --
                }
                #endregion -- 特征搜索 --
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLogWithUserMessage("ASCII2D特征搜索解析错误", ex, $"请求地址为:{bovwUrl}\r\n请求结果为：{strAscii2dBovwResult}");
                outMessage.Add(BotInfo.SearchErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "ASCII2D特征")) + ex.Message);
            }
            return outMessage;
        }

        private static async Task<string> CheckCatRoute(long id, int p = -1)
        {
            using (var httpClient = new HttpClient())
            {
                string index = "";
                if (p != -1)
                    index = $"-{p + 1}";

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://pixiv.re/{id}{index}.png"))
                {
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        HtmlDocument docCat = new HtmlDocument();
                        docCat.LoadHtml(await response.Content.ReadAsStringAsync());
                        HtmlNode node = docCat.DocumentNode.SelectNodes("/html/body/p")[0];
                        return node.InnerText;
                    }
                }
            }
            return null;
        }


        public static async Task<GreenOnionsMessages> SendPixivOriginPictureWithIdAndP(string strPixivId)
        {
            string[] idWithIndex = strPixivId.Split("-");
            if (idWithIndex.Length == 2)
            {
                if (int.TryParse(idWithIndex[1], out int index) && long.TryParse(idWithIndex[0], out long id))
                {
                    return await SearchPictureHandler.DownloadPixivOriginPicture(id, index - 1);
                }
            }
            string[] idWithP = strPixivId.ToLower().Split("p");
            if (idWithP.Length == 2)
            {
                if (int.TryParse(idWithP[1], out int p) && long.TryParse(idWithP[0], out long id))
                {
                    return await SearchPictureHandler.DownloadPixivOriginPicture(id, p);
                }
            }
            if (long.TryParse(strPixivId, out long idNoneP))
            {
                return await SearchPictureHandler.DownloadPixivOriginPicture(idNoneP, -1);
            }
            return null;
        }


        private static async Task<GreenOnionsMessages> DownloadPixivOriginPicture(long id, int p = -1)
        {
            GreenOnionsMessages outMessage = new GreenOnionsMessages();

            string msg = await CheckCatRoute(id, p);
            string index = "";
            if (p != -1)
                index = $"-{p + 1}";

            if (string.IsNullOrEmpty(msg))
            {
                string url = $"https://pixiv.re/{id}{index}.png";
                string imgName = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{id}_p{p}.png");
                string healthed = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{id}_p{p}_Healthed.png");
                string notHealth = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{id}_p{p}_NotHealth.png");

                await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.OriginPictureCheckPornEnabled, url, imgName, outMessage, healthed, notHealth);
            }
            else
                outMessage.Add(msg);

            return outMessage;
        }
    }
}
