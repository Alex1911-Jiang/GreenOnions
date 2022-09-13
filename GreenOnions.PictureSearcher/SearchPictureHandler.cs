using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using HtmlAgilityPack;
using IqdbApi;
using IqdbApi.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
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
        public static void SearchOn(long qqId, Action<GreenOnionsMessages> SendMessage, SearchMode mode)
        {
            if (Cache.SearchingUserGroups.Where(d => d.ContainsKey(qqId)).Count() > 0)
            {
                for (int i = 0; i < Cache.SearchingUserGroups.Length; i++)
                {
                    if (Cache.SearchingUserGroups[i].ContainsKey(qqId))
                    {
                        Cache.SearchingUserGroups[i][qqId] = DateTime.Now.AddMinutes(1);  //延长搜图时间到1分钟
                    }
                }
                SendMessage(BotInfo.SearchModeAlreadyOnReply.ReplaceGreenOnionsTags());
                return;
            }

            List<IDictionary<long, DateTime>> lstGroups = new List<IDictionary<long, DateTime>>();
            if ((mode & SearchMode.Picture) != 0)
                AddToGroup(Cache.SearchingPicturesUsers);
            if ((mode & SearchMode.Anime) != 0)
                AddToGroup(Cache.SearchingAnimeUsers);
            if ((mode & SearchMode.ThreeD) != 0)
                AddToGroup(Cache.Searching3DUsers);

            if (lstGroups.Count > 0)
            {
                Cache.SetWorkingTimeout(qqId, () => SendMessage(BotInfo.SearchModeTimeOutReply.ReplaceGreenOnionsTags()), lstGroups.ToArray());
                SendMessage(BotInfo.SearchModeOnReply.ReplaceGreenOnionsTags());
            }

            void AddToGroup(ConcurrentDictionary<long, DateTime> modeGroup)
            {
                modeGroup.TryAdd(qqId, DateTime.Now.AddMinutes(1));
                lstGroups.Add(modeGroup);
            }
        }

        public static void UpdateSearchTime(long qqId)
        {
            if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
                Cache.SearchingPicturesUsers[qqId] = DateTime.Now.AddMinutes(1);
            if (Cache.SearchingAnimeUsers.ContainsKey(qqId))
                Cache.SearchingAnimeUsers[qqId] = DateTime.Now.AddMinutes(1);
            if (Cache.Searching3DUsers.ContainsKey(qqId))
                Cache.Searching3DUsers[qqId] = DateTime.Now.AddMinutes(1);
        }

        public static void SearchOff(long qqId, Action<GreenOnionsMessages> SendMessage)
        {
            bool inCacheGroup = false;
            if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
            {
                Cache.SearchingPicturesUsers.TryRemove(qqId, out _);
                inCacheGroup = true;
            }
            if (Cache.SearchingAnimeUsers.ContainsKey(qqId))
            {
                Cache.SearchingAnimeUsers.TryRemove(qqId, out _);
                inCacheGroup = true;
            }
            if (Cache.Searching3DUsers.ContainsKey(qqId))
            {
                Cache.Searching3DUsers.TryRemove(qqId, out _);
                inCacheGroup = true;
            }

            if (inCacheGroup)
                SendMessage(BotInfo.SearchModeOffReply.ReplaceGreenOnionsTags());
            else
                SendMessage(BotInfo.SearchModeAlreadyOffReply.ReplaceGreenOnionsTags());
        }

        public static void SearchPicture(GreenOnionsImageMessage inImgMsg, Action<GreenOnionsMessages> SendMessage, SearchMode searchMode)
        {
            LogHelper.WriteInfoLog("进入搜图处理事件");

            if (!string.IsNullOrWhiteSpace(BotInfo.SearchingReply))
                if (BotInfo.SearchEnabledTraceMoe || BotInfo.SearchEnabledSauceNAO || BotInfo.SearchEnabledASCII2D || BotInfo.SearchEnabledIqdb || BotInfo.SearchEnabled3dIqdb)  //至少启用了一种搜图引擎
                    SendMessage(BotInfo.SearchingReply);  //正在搜索中提示

            string qqImgUrl = ImageHelper.ReplaceGroupUrl(inImgMsg.Url).Replace("//","/").Replace("http:/", "http://").Replace("https:/", "https://");
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

                //TraceMoe
                if (BotInfo.SearchEnabledTraceMoe && (searchMode & SearchMode.Anime) != 0)  //包含搜番命令
                {
                    Task<GreenOnionsMessages> traceMoeTask = SearchTraceMoe(qqImgUrl, searchMode == SearchMode.Anime);
                    if (BotInfo.SearchSendByForward)
                    {
                        searchTasks.Add(traceMoeTask);
                        traceMoeTask.ContinueWith(callback => outMessages.Add(callback.Result));
                    }
                    else
                        traceMoeTask.ContinueWith(callback => SendMessage(callback.Result));
                }
                //SauceNAO
                Task<(GreenOnionsMessages OutMessages, bool DoAscii2dSearch)> SauceNAOTask = null;
                if (BotInfo.SearchEnabledSauceNAO && (searchMode & SearchMode.Picture) != 0)
                {
                    SauceNAOTask = SearchSauceNAO(qqImgUrl, SendMessage);
                    if (BotInfo.SearchSendByForward)
                    {
                        searchTasks.Add(SauceNAOTask);
                        SauceNAOTask.ContinueWith(SauceNAOCallback => outMessages.Add(SauceNAOCallback.Result.OutMessages));
                    }
                    else
                    {
                        SauceNAOTask.ContinueWith(callback =>
                        {
                            var SauceNAOSearchResult = callback.Result;
                            if (BotInfo.SearchEnabledASCII2D && SauceNAOSearchResult.DoAscii2dSearch)
                                SauceNAOSearchResult.OutMessages.Add("\r\n自动使用ASCII2D搜索。");
                            SendMessage(SauceNAOSearchResult.OutMessages);
                        });
                    }
                }
                //ASCII2D
                if (BotInfo.SearchEnabledASCII2D && (searchMode & SearchMode.Picture) != 0)  //不启用SauceNAO只启用ASCII2D
                {
                    LogHelper.WriteInfoLog("没有启用SauceNAO");
                    Task<GreenOnionsMessages> ascii2dTask = SearchAscii2D(qqImgUrl);
                    if (BotInfo.SearchSendByForward)
                    {
                        searchTasks.Add(ascii2dTask);
                        ascii2dTask.ContinueWith(async callback =>
                        {
                            if (SauceNAOTask == null)
                                outMessages.Add(callback.Result);
                            else
                            {
                                await SauceNAOTask;
                                if (SauceNAOTask.Result.DoAscii2dSearch)
                                    outMessages.Add(callback.Result);
                            }
                        });
                    }
                    else
                    {
                        ascii2dTask.ContinueWith(async callback =>
                        {
                            if (SauceNAOTask == null)
                                SendMessage(callback.Result);
                            else
                            {
                                await SauceNAOTask;
                                if (SauceNAOTask.Result.DoAscii2dSearch)
                                    SendMessage(callback.Result);
                            }
                        });
                    }
                }
                //Iqdb anime
                if (BotInfo.SearchEnabledIqdb && (searchMode & SearchMode.Picture) != 0)  //www.iqdb.org
                {
                    Task<GreenOnionsMessages> iqdbTask = SearchIqdb(qqImgUrl.Replace("http:", "https:"), false);
                    if (BotInfo.SearchSendByForward)
                    {
                        searchTasks.Add(iqdbTask);
                        iqdbTask.ContinueWith(callback => outMessages.Add(callback.Result));
                    }
                    else
                        iqdbTask.ContinueWith(callback => SendMessage(callback.Result));
                }
                // 3d Iqdb
                if (BotInfo.SearchEnabled3dIqdb && (searchMode & SearchMode.ThreeD) != 0)  //3d.iqdb.org
                {
                    Task<GreenOnionsMessages> iqdbTask = SearchIqdb(qqImgUrl.Replace("http:", "https:"), true);
                    if (BotInfo.SearchSendByForward)
                    {
                        searchTasks.Add(iqdbTask);
                        iqdbTask.ContinueWith(callback => outMessages.Add(callback.Result));
                    }
                    else
                        iqdbTask.ContinueWith(callback => SendMessage(callback.Result));
                }

                if (BotInfo.SearchSendByForward)
                {
                    Task.Factory.ContinueWhenAll(searchTasks.ToArray(), callback =>
                    {
                        GreenOnionsForwardMessage[] forwardMessages = outMessages.Select(msg => new GreenOnionsForwardMessage(BotInfo.QQId, BotInfo.BotName, msg)).ToArray();
                        GreenOnionsMessages outForwardMsg = forwardMessages;
                        outForwardMsg.RevokeTime = outMessages.First().RevokeTime;
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

        private static async Task<GreenOnionsMessages> SearchTraceMoe(string qqImgUrl, bool alwaysSend)
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
                    if (similarity >= BotInfo.TraceMoeSendThreshold || alwaysSend)  //仅搜番时相似度低也发送
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
                {
                    if (alwaysSend)
                        return BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "TraceMoe"));  //没有结果
                    return null;  //没有搜索结果
                }
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
                LogHelper.WriteInfoLog($"存在缩略图本地缓存");
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
                                message.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", CheckPornErrMsg)));
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
                LogHelper.WriteInfoLog($"不存在缩略图本地缓存");
                try
                {
                    if (checkPorn)  //鉴黄
                    {
                        using (MemoryStream stream = await HttpHelper.DownloadImageAsMemoryStreamAsync(imgUrl))
                        {
                            if (stream == null)
                            {
                                message.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags());
                                return;
                            }
                            byte[] imgByte = stream.ToArray();
                            if (BotInfo.DownloadImage4Caching || BotInfo.SendImageByFile)
                                File.WriteAllBytes(imgName, imgByte);  //下载图片用于缓存
                            LogHelper.WriteInfoLog($"下载缩略图");
                            switch (TencentCloudHelper.CheckImageHealth(imgByte, out string CheckPornErrMsg))
                            {
                                case TencentCloudHelper.CheckedPornStatus.Healthed:  //健康
                                    message.Add(new GreenOnionsImageMessage(stream));
                                    File.WriteAllBytes(healthed, imgByte);
                                    break;
                                case TencentCloudHelper.CheckedPornStatus.NotHealth:  //不健康
                                    message.Add(BotInfo.SearchCheckPornIllegalReply.ReplaceGreenOnionsTags());
                                    File.WriteAllBytes(notHealth, imgByte);
                                    break;
                                case TencentCloudHelper.CheckedPornStatus.Error:  //错误
                                    message.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", CheckPornErrMsg)));
                                    break;
                            }
                        }
                    }
                    else  //不鉴黄
                    {
                        if (BotInfo.SendImageByFile)  //下载完成后发送文件
                        {
                            HttpHelper.DownloadImageFile(imgUrl, imgName);
                            message.Add(new GreenOnionsImageMessage(imgName));
                        }
                        else
                        {
                            message.Add(new GreenOnionsImageMessage(imgUrl));
                            if (BotInfo.DownloadImage4Caching)
                                _ = Task.Run(() => HttpHelper.DownloadImageFile(imgUrl, imgName));  //下载图片用于缓存
                        }
                    }
                }
                catch (Exception ex)
                {
                    message.Add(BotInfo.SearchDownloadThuImageFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", ex.Message)));  //缩略图下载失败
                }
            }
        }

        private static async Task<GreenOnionsMessages> SearchIqdb(string qqImgUrl, bool is3D)
        {
            using (IIqdbClient iqdbClient = is3D ? new Iqdb3dClient() : new IqdbClient())
            {
                try
                {
                    var iqdbResults = await iqdbClient.SearchUrl(qqImgUrl);
                    if (iqdbResults != null && iqdbResults.Matches.Count > 0)
                    {
                        var firstItem = iqdbResults.Matches.First();

                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("地址：" + firstItem.Url);
                        stringBuilder.AppendLine($"相似度：{firstItem.Similarity}%({ firstItem.Source.ToString().Replace("_", "") })");
                        stringBuilder.AppendLine("年龄分级：" + firstItem.Rating);
                        if (BotInfo.SearchIqdbSendTags)  //发送标签(英文)
                        {
                            stringBuilder.AppendLine("标签：" + string.Join(',', firstItem.Tags));
                        }

                        GreenOnionsMessages outMessage = new GreenOnionsMessages(stringBuilder);

                        string thuImgUrl = $"https://{(is3D ? "3d" : "www")}.iqdb.org{firstItem.PreviewUrl}";
                        if (firstItem.Similarity < BotInfo.SearchIqdbSimilarity)
                        {
                            outMessage.Add(BotInfo.SearchIqdbSimilarityReply.ReplaceGreenOnionsTags());
                        }
                        else if (BotInfo.SearchIqdbMustSafe)  //必须分级为安全
                        {
                            if (firstItem.Rating == Rating.Safe)  //安全作品无需鉴黄
                                outMessage.Add(new GreenOnionsImageMessage(thuImgUrl));
                            else
                                outMessage.Add(BotInfo.SearchCheckPornIllegalReply.ReplaceGreenOnionsTags());  //不安全不显示缩略图
                        }
                        else  //鉴黄
                        {
                            string urlMd5 = GreenOnionsTypeHelper.ComputeMD5(thuImgUrl);
                            string imgName = Path.Combine(ImageHelper.ImagePath, $"Thu_{firstItem.Source}_{urlMd5}.png");
                            string notHealth = Path.Combine(ImageHelper.ImagePath, $"Thu_{firstItem.Source}_{urlMd5}_NotHealth.png");
                            string healthed = Path.Combine(ImageHelper.ImagePath, $"Thu_{firstItem.Source}_{urlMd5}_Healthed.png");
                            await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled, thuImgUrl, imgName, outMessage, notHealth, healthed);
                        }
                        return outMessage;
                    }
                    else
                    {
                        LogHelper.WriteWarningLog($"Iqdb没有搜索到结果, 搜索地址为：{qqImgUrl}");
                        return (BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "Iqdb")));
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage($"Iqdb搜索失败, 搜索地址为：{qqImgUrl}", ex);
                    return (BotInfo.SearchErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "Iqdb")));
                }
            }
        }

        /// <summary>
        /// SauceNAO搜图
        /// </summary>
        /// <param name="qqImgUrl"></param>
        /// <returns>搜图结果, 是否使用Ascii2D搜索</returns>
        private static async Task<(GreenOnionsMessages OutMessages, bool DoAscii2dSearch)> SearchSauceNAO(string qqImgUrl, Action<GreenOnionsMessages> SendMessage)
        {
            LogHelper.WriteInfoLog("进入SauceNAO搜图逻辑");
            string apiKeyStr = "";
            string apiKey = "";
            if (Cache.SauceNAOKeysAndShortRemaining.Count > 0)
            {
                var source = Cache.SauceNAOKeysAndShortRemaining.OrderByDescending(p => p.Value).ToDictionary(k => k.Key, v => v.Value);
                foreach (KeyValuePair<string, int> item in source)
                {
                    if (Cache.SauceNAOKeysAndShortRemaining[item.Key] > 0 && Cache.SauceNAOKeysAndLongRemaining[item.Key] > 0)
                    {
                        apiKey = item.Key;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(apiKey))  //本地记录key次数耗尽, 不携带Key去搜图
                    LogHelper.WriteWarningLog("SauceNAO所有Key搜图次数均耗尽");
                else
                    apiKeyStr = $"&api_key={apiKey}";
            }

            string strSauceNAOResult;
            string SauceNAOUrl = "";
            try
            {
                if (EventHelper.GetDocumentByBrowserEvent != null && BotInfo.HttpRequestByWebBrowser && BotInfo.SauceNAORequestByWebBrowser)  //浏览器方式
                {
                    //html方式只有一个结果
                    SauceNAOUrl = @$"https://SauceNAO.com/search.php?db=999&output_type=0{apiKeyStr}&testmode=1&url={qqImgUrl}";

                    LogHelper.WriteInfoLog($"调用浏览器请求SauceNAO搜图, 地址为:{SauceNAOUrl}");
                    strSauceNAOResult = EventHelper.GetDocumentByBrowserEvent(SauceNAOUrl).document;
                    LogHelper.WriteInfoLog($"调用浏览器请求SauceNAO成功");

                    HtmlDocument docSauceNAO = new HtmlDocument();
                    docSauceNAO.LoadHtml(strSauceNAOResult);
                    string imgXPath = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttableimage']/div[@class='resultimage']/a/img";
                    string titleXPath = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttablecontent']/div[@class='resultcontent']/div[@class='resulttitle']/strong";
                    string resultXPath = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttablecontent']/div[@class='resultcontent']/div[@class='resultcontentcolumn']";
                    string resultSimilarity = "/html/body/div[@id='mainarea']/div[@id='middle']/div[@class='result']/table[@class='resulttable']/tbody/tr/td[@class='resulttablecontent']/div[@class='resultmatchinfo']/div[@class='resultsimilarityinfo']";
                    HtmlNode imgNode = docSauceNAO.DocumentNode.SelectSingleNode(imgXPath);

                    if (imgNode == null)
                    {
                        LogHelper.WriteWarningLog($"SauceNAO(浏览器)没有搜索到结果, 请求地址为：{SauceNAOUrl}");
                        File.WriteAllText("html.html", strSauceNAOResult);
                        return (BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "SauceNAO")), true);  //没有结果并自动使用Ascii2D
                    }
                    else
                    {
                        LogHelper.WriteInfoLog("SauceNAO存在结果");
                        string imgUrl = imgNode.Attributes["src"].Value.Replace("amp;", "");
                        string title = docSauceNAO.DocumentNode.SelectSingleNode(titleXPath).InnerText;
                        float similarity = Convert.ToSingle(docSauceNAO.DocumentNode.SelectSingleNode(resultSimilarity).InnerText.Replace("%", ""));
                        string strSimilarity = "相似度：" + docSauceNAO.DocumentNode.SelectSingleNode(resultSimilarity).InnerText;
                        List<string> results = new List<string>();

                        string key = "";
                        foreach (HtmlNode node in docSauceNAO.DocumentNode.SelectSingleNode(resultXPath).ChildNodes)
                        {
                            if (node.Name == "br")
                                continue;
                            else if (node.Name == "strong")
                                key = node.InnerText.Replace("Creator(s): ", "作者：").Replace("Creator: ", "作者：").Replace("Member: ", "作者：").Replace("Characters: ", "角色：").Replace("Material: ", "所属：").ReplaceHtmlTags();
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
                                if (stream == null)
                                {
                                    outMessage.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags());
                                    return (outMessage, false);
                                }
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
                                                outMessage.Add(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", CheckPornErrMsg)));
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
                                LogHelper.WriteInfoLog($"SauceNAO(浏览器)搜图完成, 相似度高于发图设定值");
                                return (outMessage, similarity < BotInfo.SearchSauceNAOHighSimilarity);  //发缩略图, 判断相似度是否继续使用Ascii2D搜索
                            }
                        }
                        else
                        {
                            LogHelper.WriteInfoLog($"SauceNAO(浏览器)搜图完成, 相似度低于发图设定值");
                            outMessage.Add(BotInfo.SearchSauceNAOLowSimilarityReply.ReplaceGreenOnionsTags());  //不显示缩略图
                            return (outMessage, similarity < BotInfo.SearchSauceNAOHighSimilarity);  //不发缩略图, 判断相似度是否继续使用Ascii2D搜索
                        }
                        #endregion -- 相似度过滤和鉴黄 --
                    }
                }
                else  //后端方式
                {
                    SauceNAOUrl = @$"https://SauceNAO.com/search.php?db=999&output_type=2{apiKeyStr}&testmode=1&numres=16&url={qqImgUrl}";

                    LogHelper.WriteInfoLog($"请求SauceNAO搜图, 地址为:{SauceNAOUrl}");
                    strSauceNAOResult = await HttpHelper.GetHttpResponseStringAsync(SauceNAOUrl);
                    LogHelper.WriteInfoLog($"请求SauceNAO成功");

                    JToken json = JsonConvert.DeserializeObject<JToken>(strSauceNAOResult);

                    JToken jHeader = json["header"];
                    if (jHeader != null)
                    {
                        Cache.SauceNAOKeysAndLongRemaining[apiKey] = Convert.ToInt32(jHeader["long_remaining"]);
                        Cache.SauceNAOKeysAndShortRemaining[apiKey] = Convert.ToInt32(jHeader["short_remaining"]);
                    }

                    JArray jResults = json["results"] as JArray;

                    if (BotInfo.SearchSauceNAOSortByDesc)
                        jResults = new JArray(jResults.OrderByDescending(x => x["header"]["similarity"]));  //按相似度排序

                    if (jResults == null)
                    {
                        LogHelper.WriteWarningLog($"SauceNAO(后端)没有搜索到结果, 请求地址为：{SauceNAOUrl}");
                        return (BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "SauceNAO")), true);  //没有结果并自动使用Ascii2D
                    }

                    LogHelper.WriteInfoLog($"成功解析SauceNAO响应文");

                    for (int j = 0; j < jResults.Count; j++)
                    {
                        JToken jItemHeader = jResults[j]["header"];
                        JToken jData = jResults[j]["data"];

                        SauceNAOItem SauceNAOItem = new SauceNAOItem();

                        SauceNAOItem.similarity = Convert.ToSingle(jItemHeader["similarity"]);
                        SauceNAOItem.thumbnail = jItemHeader["thumbnail"].ToString();  //缩略图地址
                        SauceNAOItem.index_name = jItemHeader["index_name"].ToString();  //index_name

                        if (jData["ext_urls"] != null)
                        {
                            SauceNAOItem.ext_urls = new List<string>();
                            foreach (JToken ext_url in jData["ext_urls"])
                            {
                                SauceNAOItem.ext_urls.Add(ext_url.ToString());
                            }
                        }
                        #region -- Pixiv体系 --
                        SauceNAOItem.title = jData["title"]?.ToString();  //作品标题
                        SauceNAOItem.pixiv_id = jData["pixiv_id"]?.ToString();
                        SauceNAOItem.member_name = jData["member_name"]?.ToString();  //作者名称
                        SauceNAOItem.member_id = jData["member_id"]?.ToString();
                        #endregion -- Pixiv体系 --

                        #region -- 其他体系 --
                        SauceNAOItem.creator = jData["creator"]?.ToString();  //作者
                        SauceNAOItem.material = jData["material"]?.ToString();  //所属
                        SauceNAOItem.characters = jData["characters"]?.ToString();  //角色
                        SauceNAOItem.source = jData["source"]?.ToString();  //图片来源
                        #endregion -- 其他体系 --

                        //如果优先度高的没有地址
                        if (SauceNAOItem.ext_urls == null)
                        {
                            LogHelper.WriteInfoLog($"搜图结果不含来源地址, 查找相似度低一级的结果");
                            continue;
                        }

                        StringBuilder stringBuilder = new StringBuilder();

                        if (SauceNAOItem.ext_urls != null)
                        {
                            string strUrl = "";
                            if (SauceNAOItem.ext_urls.Count == 1)
                                strUrl = $"地址：{SauceNAOItem.ext_urls[0]}\r\n";
                            else
                            {
                                for (int k = 0; k < SauceNAOItem.ext_urls.Count; k++)
                                    strUrl += $"地址{k + 1}：{SauceNAOItem.ext_urls[k].ReplaceHtmlTags()}\r\n";
                            }
                            stringBuilder.AppendLine(strUrl);
                        }

                        LogHelper.WriteInfoLog($"搜索到包含{SauceNAOItem.ext_urls.Count}条地址");

                        if (!string.IsNullOrEmpty(SauceNAOItem.source))
                            stringBuilder.AppendLine("图片来源：" + HttpUtility.UrlDecode(SauceNAOItem.source));
                        stringBuilder.AppendLine($"相似度：{SauceNAOItem.similarity}%(SauceNAO)");  //一定有相似度
                        if (!string.IsNullOrEmpty(SauceNAOItem.title))
                            stringBuilder.AppendLine("标题：" + HttpUtility.UrlDecode(SauceNAOItem.title));
                        if (!string.IsNullOrEmpty(SauceNAOItem.member_name))
                            stringBuilder.AppendLine("作者：" + HttpUtility.UrlDecode(SauceNAOItem.member_name));
                        else if (!string.IsNullOrEmpty(SauceNAOItem.creator))
                            stringBuilder.AppendLine("作者：" + HttpUtility.UrlDecode(SauceNAOItem.creator));
                        if (!string.IsNullOrEmpty(SauceNAOItem.characters))
                            stringBuilder.AppendLine("角色：" + HttpUtility.UrlDecode(SauceNAOItem.characters));
                        if (!string.IsNullOrEmpty(SauceNAOItem.material))
                            stringBuilder.AppendLine("所属：" + HttpUtility.UrlDecode(SauceNAOItem.material));

                        GreenOnionsMessages outMessage = new GreenOnionsMessages(stringBuilder);

                        #region -- 相似度过滤和鉴黄 --
                        //相似度大于设定的阈值
                        if (SauceNAOItem.similarity > BotInfo.SearchSauceNAOLowSimilarity)
                        {
                            LogHelper.WriteInfoLog($"相似度大于发图设定值");
                            string imgName;
                            string notHealth;
                            string healthed;
                            if (SauceNAOItem.pixiv_id == null)
                            {
                                string urlMd5 = GreenOnionsTypeHelper.ComputeMD5(SauceNAOItem.thumbnail);
                                imgName = Path.Combine(ImageHelper.ImagePath, $"Thu_Other_{urlMd5}.png");
                                notHealth = Path.Combine(ImageHelper.ImagePath, $"Thu_Other_{urlMd5}_NotHealth.png");
                                healthed = Path.Combine(ImageHelper.ImagePath, $"Thu_Other_{urlMd5}_Healthed.png");
                            }
                            else
                            {
                                imgName = Path.Combine(ImageHelper.ImagePath, $"Thu_Pixiv{SauceNAOItem.pixiv_id}.png");
                                notHealth = Path.Combine(ImageHelper.ImagePath, $"Thu_Pixiv{SauceNAOItem.pixiv_id}_NotHealth.png");
                                healthed = Path.Combine(ImageHelper.ImagePath, $"Thu_Pixiv{SauceNAOItem.pixiv_id}_Healthed.png");
                            }
                            try
                            {
                                await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled, SauceNAOItem.thumbnail, imgName, outMessage, notHealth, healthed);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteErrorLog(ex);
                                outMessage.Add(BotInfo.SearchDownloadThuImageFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", ex.Message)));
                            }

                            LogHelper.WriteInfoLog($"鉴黄通过或不需要鉴黄");

                            if (BotInfo.SearchSauceNAOSendPixivOriginalPicture)
                            {
                                //如果是pixiv体系尝试下载原图
                                if (SauceNAOItem.pixiv_id != null)
                                {
                                    Match matchBigImg = Regex.Match(SauceNAOItem.index_name, @$".+{SauceNAOItem.pixiv_id}_p([0-9]+)[_\.].+");
                                    if (matchBigImg.Groups.Count > 1)
                                    {
                                        LogHelper.WriteInfoLog($"图片来自Pixiv, 尝试下载原图");
                                        int p = Convert.ToInt32(matchBigImg.Groups[1].Value);
                                        string imgUrlHasP = $"https://{BotInfo.PixivProxy}/{SauceNAOItem.pixiv_id}-{p + 1}.png";
                                        if (p == 0)  //NAO返回的P为0
                                        {
                                            if (BotInfo.SearchSendByForward)
                                            {
                                                string imgUrlNoP = $"https://{BotInfo.PixivProxy}/{SauceNAOItem.pixiv_id}.png";
                                                outMessage.Add(new GreenOnionsImageMessage(DownloadImageArchive(imgUrlNoP, SauceNAOItem.pixiv_id, p)));
                                            }
                                            else
                                            {
                                                string imgUrlNoP = $"https://{BotInfo.PixivProxy}/{SauceNAOItem.pixiv_id}.png";
                                                SendMessage(new GreenOnionsImageMessage(DownloadImageArchive(imgUrlNoP, SauceNAOItem.pixiv_id, p)));
                                            }
                                        }
                                        else  //地址有P且>0
                                        {
                                            if (BotInfo.SearchSendByForward)
                                                outMessage.Add(new GreenOnionsImageMessage(imgUrlHasP));
                                            else
                                                SendMessage(new GreenOnionsImageMessage(DownloadImageArchive(imgUrlHasP, SauceNAOItem.pixiv_id, p)));
                                        }

                                        //下载原图并存储
                                        string DownloadImageArchive(string url, string pixivID, int p)
                                        {
                                            string imgName = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{pixivID}_p{p}.png");
                                            if (File.Exists(imgName) && new FileInfo(imgName).Length > 0)
                                            {
                                                return imgName;
                                            }
                                            else
                                            {
                                                if (BotInfo.SendImageByFile)  //下载完成后发送文件
                                                {
                                                    HttpHelper.DownloadImageFile(url, imgName);
                                                    return imgName;
                                                }
                                                if (BotInfo.DownloadImage4Caching)
                                                    Task.Run(() => HttpHelper.DownloadImageFile(url, imgName));//下载图片用于缓存
                                                return url;
                                            }
                                        }
                                    }
                                }
                            }

                            LogHelper.WriteInfoLog($"SauceNAO(后端)搜图完成, 相似度高于发图设定值");
                            return (outMessage, SauceNAOItem.similarity < BotInfo.SearchSauceNAOHighSimilarity);
                        }
                        else
                        {
                            LogHelper.WriteInfoLog($"相似度低于发图设定值");
                            outMessage.Add(BotInfo.SearchSauceNAOLowSimilarityReply.ReplaceGreenOnionsTags());
                            LogHelper.WriteInfoLog($"SauceNAO(后端)搜图完成, 相似度低于发图设定值");
                            return (outMessage, SauceNAOItem.similarity < BotInfo.SearchSauceNAOHighSimilarity);
                        }
                        #endregion -- 相似度过滤和鉴黄 --
                    }
                }
            }
            catch (Exception ex)
            {
                GreenOnionsMessages outMessage = new GreenOnionsMessages();
                outMessage.Add("SauceNAO搜图失败, " + ex.Message);

                if (ex.Message.Contains("429"))
                {
                    LogHelper.WriteWarningLog($"当前Key:{apiKey}的搜索次数已耗尽");
                    Cache.SauceNAOKeysAndLongRemaining[apiKey] = 0;
                    Cache.SauceNAOKeysAndShortRemaining[apiKey] = 0;
                    outMessage.Add("SauceNAO搜索次数已耗尽。");
                }

                LogHelper.WriteErrorLogWithUserMessage("SauceNAO搜图失败", ex, $"请求地址为：{SauceNAOUrl}");
                return (outMessage, true);
            }

            //没有结果
            return (BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "SauceNAO")), true);
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

                    for (int i = 2; i < BotInfo.SearchShowASCII2DCount + 2; i++)  //HtmlAgilityPack的索引从1开始, 且第1个位置是上传的图片, 故从2开始读取, 结果存在最多20个
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
                            outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", $"ASCII2D颜色第{i - 1}个结果")));
                        }
                        else
                        {
                            string img = nodeColorImg.Attributes["src"].Value.ReplaceHtmlTags();
                            string hash = nodeColorHash.InnerText;
                            string title = nodeColorWorks.InnerText;
                            string url = nodeColorWorks.Attributes["href"].Value.ReplaceHtmlTags();
                            string creator = nodeColorCreator.InnerText;
                            string home = nodeColorCreator.Attributes["href"].Value.ReplaceHtmlTags();
                            string source = nodeColorSource.InnerText;

                            LogHelper.WriteInfoLog($"成功解析颜色搜索响应文");
                            StringBuilder stringBuilderColor = new StringBuilder();
                            stringBuilderColor.AppendLine("ASCII2D 颜色搜索");
                            stringBuilderColor.AppendLine($"标题:{nodeColorWorks.InnerText}");
                            stringBuilderColor.AppendLine($"地址:{nodeColorWorks.Attributes["href"].Value.ReplaceHtmlTags()}");
                            if (nodeColorCreator != null)
                            {
                                stringBuilderColor.AppendLine($"作者:{nodeColorCreator.InnerText}");
                                stringBuilderColor.AppendLine($"主页:{nodeColorCreator.Attributes["href"].Value.ReplaceHtmlTags()}");
                            }
                            outMessage.Add(stringBuilderColor);  //文字结果
                            string imgUrl = "https://ascii2d.net" + nodeColorImg.Attributes["src"].Value.ReplaceHtmlTags();
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
                }
                #endregion -- 颜色搜索 --
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

                    for (int i = 2; i < BotInfo.SearchShowASCII2DCount + 2; i++)  //HtmlAgilityPack的索引从1开始, 且第1个位置是上传的图片, 故从2开始读取, 结果存在最多20个
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
                            outMessage.Add(BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", $"ASCII2D特征第{i - 1}个结果")));
                        }
                        else
                        {
                            string img = nodeBovwImg.Attributes["src"].Value.ReplaceHtmlTags();
                            string hash = nodeBovwHash.InnerText;
                            string title = nodeBovwWorks.InnerText;
                            string url = nodeBovwWorks.Attributes["href"].Value.ReplaceHtmlTags();
                            string creator = nodeBovwCreator.InnerText;
                            string home = nodeBovwCreator.Attributes["href"].Value.ReplaceHtmlTags();
                            string source = nodeBovwSource.InnerText;

                            LogHelper.WriteInfoLog($"成功解析特征搜索响应文");
                            StringBuilder stringBuilderBovw = new StringBuilder();
                            stringBuilderBovw.AppendLine("ASCII2D 特征搜索");
                            stringBuilderBovw.AppendLine($"标题:{nodeBovwWorks.InnerText}");
                            stringBuilderBovw.AppendLine($"地址:{nodeBovwWorks.Attributes["href"].Value.ReplaceHtmlTags()}");
                            if (nodeBovwCreator != null)
                            {
                                stringBuilderBovw.AppendLine($"作者:{nodeBovwCreator.InnerText}");
                                stringBuilderBovw.AppendLine($"主页:{nodeBovwCreator.Attributes["href"].Value.ReplaceHtmlTags()}");
                            }
                            outMessage.Add(stringBuilderBovw);  //文字结果
                            string imgUrl = "https://ascii2d.net" + nodeBovwImg.Attributes["src"].Value.ReplaceHtmlTags();
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

        /// <summary>
        /// 检查是否存在图片(已弃用, PixivCat已经改成不带第几张图时默认第一张)
        /// </summary>
        [Obsolete]
        private static async Task<string> CheckCatRoute(long id, int p = -1)
        {
            using (var httpClient = new HttpClient())
            {
                string index = "";
                if (p != -1)
                    index = $"-{p + 1}";

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://{BotInfo.PixivProxy}/{id}{index}.png"))
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

        public static async Task<GreenOnionsMessages> SendPixivOriginalPictureWithIdAndP(string strPixivId)
        {
            string[] idWithIndex = strPixivId.Split("-");
            if (idWithIndex.Length == 2)
            {
                if (int.TryParse(idWithIndex[1], out int index) && long.TryParse(idWithIndex[0], out long id))
                {
                    return await SearchPictureHandler.DownloadPixivOriginalPicture(id, index - 1);
                }
            }
            string[] idWithP = strPixivId.ToLower().Split("p");
            if (idWithP.Length == 2)
            {
                if (int.TryParse(idWithP[1], out int p) && long.TryParse(idWithP[0], out long id))
                {
                    return await SearchPictureHandler.DownloadPixivOriginalPicture(id, p);
                }
            }
            if (long.TryParse(strPixivId, out long idNoneP))
            {
                return await SearchPictureHandler.DownloadPixivOriginalPicture(idNoneP, -1);
            }
            return null;
        }


        private static async Task<GreenOnionsMessages> DownloadPixivOriginalPicture(long id, int p = -1)
        {
            GreenOnionsMessages outMessage = new GreenOnionsMessages();

            string index = "";
            if (p != -1)
                index = $"-{p + 1}";

            string url = $"https://{BotInfo.PixivProxy}/{id}{index}.png";
            string imgName = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{id}_p{p}.png");
            string healthed = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{id}_p{p}_Healthed.png");
            string notHealth = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{id}_p{p}_NotHealth.png");

            await CheckPornAndCache(BotInfo.CheckPornEnabled && BotInfo.OriginalPictureCheckPornEnabled, url, imgName, outMessage, healthed, notHealth);

            return outMessage;
        }
    }
}
