using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using HtmlAgilityPack;
using Mirai.CSharp.Models.ChatMessages;
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
using PlainMessage = Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage;

namespace GreenOnions.PictureSearcher
{
    public static class SearchPictureHandler
    {
        public static async Task SendPixivOriginPictureWithIdAndP(string strId, Func<string[], Task<string[]>> SendImage, Func<Stream, Task<IImageMessage>> UploadPicture, Func<IChatMessage[], bool, Task<int>> SendMessage)
        {
            string[] idWithIndex = strId.Split("-");
            if (idWithIndex.Length == 2)
            {
                if (int.TryParse(idWithIndex[1], out int index) && long.TryParse(idWithIndex[0], out long id))
                {
                    await SearchPictureHandler.DownloadPixivOriginPicture(SendImage, UploadPicture, SendMessage, id, index - 1);
                }
                return;
            }
            string[] idWithP = strId.ToLower().Split("p");
            if (idWithP.Length == 2)
            {
                if (int.TryParse(idWithP[1], out int p) && long.TryParse(idWithP[0], out long id))
                {
                    await SearchPictureHandler.DownloadPixivOriginPicture(SendImage, UploadPicture, SendMessage, id, p);
                }
                return;
            }
            if (long.TryParse(strId, out long idNoneP))
            {
                await SearchPictureHandler.DownloadPixivOriginPicture(SendImage, UploadPicture, SendMessage, idNoneP, -1);
                return;
            }
        }

        public static void SearchOn(long qqId, Func<IChatMessage[], bool, Task<int>> SendMessage)
        {
            if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
            {
                Cache.SearchingPicturesUsers[qqId] = DateTime.Now.AddMinutes(1);
                SendMessage?.Invoke(new[] { new PlainMessage(BotInfo.SearchModeAlreadyOnReply.ReplaceGreenOnionsTags()) }, true);
            }
            else
            {
                Cache.SearchingPicturesUsers.TryAdd(qqId, DateTime.Now.AddMinutes(1));
#if DEBUG
                ErrorHelper.WriteMessage($"添加了一个用户进正在搜图的列表:{qqId}");
#endif
                SendMessage?.Invoke(new[] { new PlainMessage(BotInfo.SearchModeOnReply.ReplaceGreenOnionsTags()) }, true);
                Cache.SetWorkingTimeout(qqId, Cache.SearchingPicturesUsers, () =>
                {
                    SendMessage?.Invoke(new[] { new PlainMessage(BotInfo.SearchModeTimeOutReply.ReplaceGreenOnionsTags()) }, true);
                });
            }
        }

        public static void SearchOff(long qqId, Func<IChatMessage[], bool, Task<int>> SendMessage)
        {
            if (Cache.SearchingPicturesUsers.ContainsKey(qqId))
            {
                Cache.SearchingPicturesUsers.TryRemove(qqId, out _);
#if DEBUG
                ErrorHelper.WriteMessage($"把一个用户移除出正在搜图的列表:{qqId}");
#endif
                SendMessage?.Invoke(new[] { new PlainMessage(BotInfo.SearchModeOffReply.ReplaceGreenOnionsTags()) }, true);
            }
            else
            {
                SendMessage?.Invoke(new[] { new PlainMessage(BotInfo.SearchModeAlreadyOffReply.ReplaceGreenOnionsTags()) }, true);
            }
        }

        public static async Task SearchPicture(IImageMessage inImgMsg, Func<Stream, Task<IImageMessage>> UploadPicture, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<string[], Task<string[]>> SendImage)
        {
            string qqImgUrl = ImageHelper.ReplaceGroupUrl(inImgMsg.Url);
            try
            {
                if (BotInfo.SearchEnabledTraceMoe)
                {
                    _ = SearchTraceMoe();
                }
                if (BotInfo.SearchEnabledSauceNao)
                {
                    _ = SearchSauceNao();
                }
                else if (BotInfo.SearchEnabledASCII2D)  //不启用SauceNao只启用ASCII2D
                {
                    await SearchAscii2D();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.WriteErrorLog(ex);
                _ = SendMessage(new [] { new PlainMessage(BotInfo.SearchErrorReply + ex.Message) }, true);
            }

            async Task SearchTraceMoe()
            {
                string TraceMoeUrl = @$"https://api.trace.moe/search?anilistInfo&url={qqImgUrl}";  //https://trace.moe/?url=  //https://trace.moe/api/search?url=
                try
                {
                    string strSauceTraceMoe = await HttpHelper.GetHttpResponseStringAsync(TraceMoeUrl);
                    JToken json = JsonConvert.DeserializeObject<JToken>(strSauceTraceMoe);
                    JArray jResults = json["result"] as JArray;
                    if (jResults.Count > 0)
                    {
                        double similarity = Math.Round(Convert.ToDouble(jResults[0]["similarity"]), 4) * 100; //相似度
                        if (similarity >= BotInfo.TraceMoeSendThreshold)
                        {
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
                            string previewURL = jResults[0]["image"].ToString() + $"&size={previewSize}";
                            string imgName = Path.Combine(ImageHelper.ImagePath, $"TraceMoe_{id}_{previewSize}.png");

                            //TraceMoe缩略图
                            _ = Task.Run(async () =>
                            {
                                try
                                {
                                    if (File.Exists(imgName))  //存在本地缓存
                                    {
                                        if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                                        {
                                            string notHealth = Path.Combine(ImageHelper.ImagePath, $"TraceMoe_{id}_{previewSize}notHealth.png");
                                            string isHealth = Path.Combine(ImageHelper.ImagePath, $"TraceMoe_{id}_{previewSize}_IsHealth.png");

                                            if (File.Exists(notHealth))  //曾经鉴黄不通过的
                                                _ = SendMessage(new[] { new PlainMessage(BotInfo.SearchCheckPornIllegalReply) }, true); //直接返回鉴黄不通过
                                            else if (File.Exists(isHealth))  //曾经鉴黄通过的
                                                _ = UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }, false));
                                            else  //曾经没参与鉴黄的
                                            {
                                                IChatMessage chatMessage = CheckPornSearch(imgName, File.ReadAllBytes(imgName));
                                                if (chatMessage == null)
                                                    _ = UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }, false));
                                                else
                                                    _ = SendMessage(new[] { chatMessage }, true);
                                            }
                                        }
                                        else if (BotInfo.SearchNoCheckPorn == 0)  //不鉴黄也发图, 直接读取本地图片
                                            _ = UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }, false));

                                    }
                                    else  //没有本地缓存
                                    {
                                        //鉴黄通过或不鉴黄也发图
                                        if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                                        {
                                            MemoryStream stream = await HttpHelper.DownloadImageAsMemoryStream(previewURL);
                                            if (stream != null)
                                            {
                                                IChatMessage moeCheckPorn = CheckPornSearch(imgName, stream.ToArray());
                                                if (moeCheckPorn == null)  //只有鉴黄通过才发图
                                                    await UploadPicture(stream).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }, false));
                                                stream.Dispose();
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ErrorHelper.WriteErrorLog(ex);  //异常只是不发送缩略图, 不需要返回消息
                                }
                            });
                            await SendMessage(new[] { new PlainMessage($"动画名称:{anime}\r\n其他名称:{synonyms}\r\n相似度:{similarity}% (trace.moe)\r\n里:{(isAdult ? "是" : "否")}\r\n第{episode}集 {time}处") }, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorHelper.WriteErrorLogWithUserMessage("TraceMoe搜番失败", ex, $"请求地址为：{TraceMoeUrl}");
                    _ = SendMessage(new[] { new PlainMessage("TraceMoe搜番失败，" + ex.Message) }, true);
                }
            }

            async Task SearchSauceNao()
            {
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
                        }
                    }

                    if (string.IsNullOrEmpty(apiKey))  //所有key均已耗尽次数
                    {
                        string strLowSimilarity = "SauceNao搜索次数已耗尽。";
                        if (BotInfo.SearchEnabledASCII2D)
                        {
                            strLowSimilarity += "\r\n自动使用ASCII2D搜索。";
                            _ = SearchAscii2D();
                        }
                        _ = SendMessage(new[] { new PlainMessage(strLowSimilarity) }, true);
                        return;
                    }

                    apiKeyStr = $"&api_key={apiKey}";
                }

                string SauceNaoUrl = @$"https://saucenao.com/search.php?db=999&output_type=2{apiKeyStr}&testmode=1&numres=16&url={qqImgUrl}";
                string strSauceNaoResult;

                try
                {
                    strSauceNaoResult = await HttpHelper.GetHttpResponseStringAsync(SauceNaoUrl);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("429"))
                    {
                        Cache.SauceNaoKeysAndLongRemaining[apiKey] = 0;
                        Cache.SauceNaoKeysAndShortRemaining[apiKey] = 0;
                    }

                    string sauceNaoFail = "SauceNao搜图失败，" + ex.Message;
                    ErrorHelper.WriteErrorLogWithUserMessage("SauceNao搜图失败", ex, $"请求地址为：{SauceNaoUrl}");
                    if (BotInfo.SearchEnabledASCII2D)
                    {
                        sauceNaoFail += "\r\n自动使用ASCII2D搜索。";
                        _ = SearchAscii2D();
                    }
                    _ = SendMessage(new[] { new PlainMessage(sauceNaoFail) }, true);
                    return;
                }

                JToken json = JsonConvert.DeserializeObject<JToken>(strSauceNaoResult);

                JToken jHeader = json["header"];
                if (jHeader != null)
                {
                    Cache.SauceNaoKeysAndLongRemaining[apiKey] = Convert.ToInt32(jHeader["long_remaining"]);
                    Cache.SauceNaoKeysAndShortRemaining[apiKey] = Convert.ToInt32(jHeader["short_remaining"]);
                }

                JArray jResults = json["results"] as JArray;

                //jResults = new JArray(jResults.OrderByDescending(x => x["header"]["similarity"]));  //按相似度排序

                if (jResults == null)
                {
                    ErrorHelper.WriteErrorLogWithUserMessage("SauceNao没有搜索到结果", null, $"请求地址为：{SauceNaoUrl}");
                    _ = SendMessage(new[] { new PlainMessage(BotInfo.SearchNoResultReply.Replace("<搜索类型>", "SauceNao")) }, true);
                    return;
                }

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
                    if (sauceNaoItem.ext_urls == null && string.IsNullOrEmpty(sauceNaoItem.source))
                    {
                        continue;
                    }

                    StringBuilder stringBuilder = new StringBuilder();

                    if (sauceNaoItem.ext_urls != null)
                    {
                        string sauceNaoUrl = "";
                        if (sauceNaoItem.ext_urls.Count == 1)
                        {
                            sauceNaoUrl = $"地址:{sauceNaoItem.ext_urls[0]}\r\n";
                        }
                        else
                        {
                            for (int k = 0; k < sauceNaoItem.ext_urls.Count; k++)
                            {
                                sauceNaoUrl += $"地址{k + 1}:{sauceNaoItem.ext_urls[k]}\r\n";
                            }
                        }
                        stringBuilder.AppendLine(sauceNaoUrl);
                    }
                    if (!string.IsNullOrEmpty(sauceNaoItem.source)) stringBuilder.AppendLine("图片来源:" + HttpUtility.UrlDecode(sauceNaoItem.source));
                    stringBuilder.AppendLine($"相似度:{sauceNaoItem.similarity}%(SauceNAO)");  //一定有相似度
                    if (!string.IsNullOrEmpty(sauceNaoItem.title)) stringBuilder.AppendLine("标题:" + HttpUtility.UrlDecode(sauceNaoItem.title));
                    if (!string.IsNullOrEmpty(sauceNaoItem.member_name))
                        stringBuilder.AppendLine("作者:" + HttpUtility.UrlDecode(sauceNaoItem.member_name));
                    else if (!string.IsNullOrEmpty(sauceNaoItem.creator))
                        stringBuilder.AppendLine("作者:" + HttpUtility.UrlDecode(sauceNaoItem.creator));
                    if (!string.IsNullOrEmpty(sauceNaoItem.characters)) stringBuilder.AppendLine("角色:" + HttpUtility.UrlDecode(sauceNaoItem.characters));
                    if (!string.IsNullOrEmpty(sauceNaoItem.material)) stringBuilder.AppendLine("所属:" + HttpUtility.UrlDecode(sauceNaoItem.material));

                    PlainMessage sauceNaoMsg = new PlainMessage(stringBuilder.ToString());

                    IChatMessage IImageMessage = null;
                    //相似度大于设定的阈值
                    if (sauceNaoItem.similarity > BotInfo.SearchLowSimilarity)
                    {
                        string[] thuImgCacheFiles = sauceNaoItem.pixiv_id == null ? Directory.GetFiles(ImageHelper.ImagePath, $"Thu_Other_{sauceNaoItem.thumbnail.Substring(sauceNaoItem.thumbnail.LastIndexOf("=") + 1)}*") : Directory.GetFiles(ImageHelper.ImagePath, $"Thu_{sauceNaoItem.pixiv_id}*");
                        Stream stream = null;
                        if (thuImgCacheFiles.Length > 0 && new FileInfo(thuImgCacheFiles[0]).Length > 0)  //存在本地缓存
                        {
                            if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                            {
                                if (thuImgCacheFiles[0].Contains("_NotHealth"))  //曾经鉴黄不通过的
                                    IImageMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply); //直接返回鉴黄不通过
                                else if (thuImgCacheFiles[0].Contains("_IsHealth"))  //曾经鉴黄通过的
                                    stream = new FileStream(thuImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);  //上传本地图片
                                else  //曾经没参与鉴黄的
                                    IImageMessage = CheckPornSearch(thuImgCacheFiles[0], File.ReadAllBytes(thuImgCacheFiles[0]));
                            }
                            else if (BotInfo.SearchNoCheckPorn == 0)  //不鉴黄也发图, 直接读取本地图片
                                stream = new FileStream(thuImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                        }
                        else  //没有本地缓存
                        {
                            string cacheImageName = Path.Combine(ImageHelper.ImagePath, $"Thu_{sauceNaoItem.pixiv_id}.png");
                            //鉴黄通过或不鉴黄也发图
                            if ((BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled) || BotInfo.SearchNoCheckPorn == 0)  //不鉴黄也发图的话只需要维持IImageMessage为空
                            {
                                stream = await HttpHelper.DownloadImageAsMemoryStream(sauceNaoItem.thumbnail);
                                if (stream != null)
                                {
                                    if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                                        IImageMessage = CheckPornSearch(cacheImageName, (stream as MemoryStream).ToArray());
                                }
                            }
                        }

                        if (IImageMessage == null)
                        {
                            if (stream != null)
                            {
                                IImageMessage = await UploadPicture(stream);

                                //如果是pixiv体系尝试下载原图
                                if (sauceNaoItem.pixiv_id != null)
                                {
                                    Match matchBigImg = Regex.Match(sauceNaoItem.index_name, @$".+{sauceNaoItem.pixiv_id}_p([0-9]+)[_\.].+");
                                    if (matchBigImg.Groups.Count > 1)
                                    {
                                        int p = Convert.ToInt32(matchBigImg.Groups[1].Value);
                                        string imgUrlHasP = $"https://pixiv.re/{sauceNaoItem.pixiv_id}-{p + 1}.png";
                                        if (p == 0)  //NAO返回的P为0
                                        {
                                            using (var httpClient = new HttpClient())
                                            {
                                                _ = CheckCatRoute(Convert.ToInt64(sauceNaoItem.pixiv_id), -1).ContinueWith(c =>
                                                {
                                                    if (string.IsNullOrEmpty(c.Result))
                                                    {
                                                        string imgUrlNoP = $"https://pixiv.re/{sauceNaoItem.pixiv_id}.png";
                                                        SendOriginImage(imgUrlNoP, sauceNaoItem.pixiv_id, p);
                                                    }
                                                    else
                                                        SendOriginImage(imgUrlHasP, sauceNaoItem.pixiv_id, p);
                                                });
                                            }
                                        }
                                        else  //地址有P且>0
                                            SendOriginImage(imgUrlHasP, sauceNaoItem.pixiv_id, p);
                                    }
                                }
                            }
                            else
                            {
                                IImageMessage = new PlainMessage("");
                            }
                        }
                    }
                    else
                    {
                        string strLowSimilarity = BotInfo.SearchLowSimilarityReply.ReplaceGreenOnionsTags();
                        if (BotInfo.SearchEnabledASCII2D)
                        {
                            strLowSimilarity += "\r\n自动使用ASCII2D搜索。";
                            _ = SearchAscii2D();
                        }
                        IImageMessage = new PlainMessage(strLowSimilarity);
                    }
                    await SendMessage(new[] { sauceNaoMsg, IImageMessage }, false);
                    return;
                }
                string strNoResult = BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("<搜索类型>", "SauceNao"));
                if (BotInfo.SearchEnabledASCII2D)
                {
                    strNoResult += "\r\n自动使用ASCII2D搜索。";
                    _ = SearchAscii2D();
                }
                _ = SendMessage(new[] { new PlainMessage(strNoResult) }, true);

                async void SendOriginImage(string url, string pixivID, int p)
                {
                    try
                    {
                        string[] imgIds = await SendImage(new[] { url });

                        //下载图片并发送
                        //SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage(imgIds.First(), null, null) });

                        string imgName = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{pixivID}_p{p}.png");
                        if (!File.Exists(imgName) || new FileInfo(imgName).Length == 0)
                        {
                            _ = Task.Run(() => HttpHelper.DownloadImageFile(url, imgName));  //仅下载
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHelper.WriteErrorLog(ex);  //异常只是不发送原图, 不需要返回消息
                    }
                }
            }

            async Task SearchAscii2D()
            {
                string strAscii2dColorResult = null; 
                string strAscii2dBovwResult = null;
                string url = @$"https://ascii2d.net/search/url/{qqImgUrl}?type=color";
                if (EventHelper.GetDocumentByBrowserEvent != null && BotInfo.HttpRequestByWebBrowser && BotInfo.ASCII2DRequestByWebBrowser)
                {
                    var responseColor = EventHelper.GetDocumentByBrowserEvent(url);
                    strAscii2dColorResult = responseColor.document;
                    try
                    {
                        var responseBovw = EventHelper.GetDocumentByBrowserEvent(responseColor.jumpUrl.Replace("/color/", "/bovw/"));
                        strAscii2dBovwResult = responseBovw.document;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    var response = await HttpHelper.GetHttpResponseStringAndJumpUrlAsync(url);
                    strAscii2dColorResult = response.document;
                    try
                    {
                        strAscii2dBovwResult = await HttpHelper.GetHttpResponseStringAsync(response.jumpUrl.Replace("/color/", "/bovw/"));
                    }
                    catch (Exception ex)
                    {
                    }
                }

                bool bColorError = false;
                bool bBovwError = false;

                try
                {
                    #region -- 颜色搜索 --
                    HtmlDocument docColor = new HtmlDocument();
                    docColor.LoadHtml(strAscii2dColorResult);
                    string pathColorItemBox = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']";
                    HtmlNode nodeColorItemBox = docColor.DocumentNode.SelectNodes(pathColorItemBox)[2];
                    string pathColorHash = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['hash']";
                    string pathColorImage = "div['col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img";
                    string pathColorUrlA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[1]";
                    string pathColorMemberA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[2]";
                    string pathColorUrlSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[1]/a";
                    string pathColorMemberSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[2]/a";
                    HtmlNode nodeColorHash = nodeColorItemBox.SelectSingleNode(pathColorHash);
                    HtmlNode nodeColorImage = nodeColorItemBox.SelectSingleNode(pathColorImage);
                    HtmlNode nodeColorUrl = nodeColorItemBox.SelectSingleNode(pathColorUrlA) ?? nodeColorItemBox.SelectSingleNode(pathColorUrlSmall);
                    HtmlNode nodeColorMember = nodeColorItemBox.SelectSingleNode(pathColorMemberA) ?? nodeColorItemBox.SelectSingleNode(pathColorMemberSmall);
                    StringBuilder stringBuilderColor = new StringBuilder();

                    if (nodeColorUrl != null)
                    {
                        stringBuilderColor.AppendLine("ASCII2D 颜色搜索");
                        stringBuilderColor.AppendLine($"标题:{nodeColorUrl.InnerText}");
                        stringBuilderColor.AppendLine($"地址:{nodeColorUrl.Attributes["href"].Value}");
                        if (nodeColorMember != null)
                        {
                            stringBuilderColor.AppendLine($"作者:{nodeColorMember.InnerText}");
                            stringBuilderColor.AppendLine($"主页:{nodeColorMember.Attributes["href"].Value}");
                        }

                        string[] thuColorImgCacheFiles = Directory.GetFiles(ImageHelper.ImagePath, $"Thu_{nodeColorHash.InnerHtml}*");
                        IChatMessage imageColorMessage = null;
                        Stream streamColorImage = null;
                        if (thuColorImgCacheFiles.Length > 0 && new FileInfo(thuColorImgCacheFiles[0]).Length > 0)  //如果存在本地缓存
                        {
                            if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                            {
                                if (thuColorImgCacheFiles[0].Contains("_NotHealth"))  //曾经鉴黄不通过的
                                    imageColorMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply); //直接返回鉴黄不通过
                                else if (thuColorImgCacheFiles[0].Contains("_IsHealth"))  //曾经鉴黄通过的
                                    streamColorImage = new FileStream(thuColorImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);  //上传本地图片
                                else  //曾经没参与鉴黄的
                                {
                                    byte[] colorImageByte = File.ReadAllBytes(thuColorImgCacheFiles[0]);
                                    imageColorMessage = CheckPornSearch(thuColorImgCacheFiles[0], colorImageByte);
                                    if (imageColorMessage == null)
                                        streamColorImage = new MemoryStream(colorImageByte);  //上传本地图片
                                }
                            }
                            else if (BotInfo.SearchNoCheckPorn == 0)  //不鉴黄也发图, 直接读取本地图片
                                streamColorImage = new FileStream(thuColorImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                        }
                        else
                        {
                            string thuColorImgCache = Path.Combine(ImageHelper.ImagePath, $"Thu_{nodeColorHash.InnerHtml}.png");
                            if ((BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled) || BotInfo.SearchNoCheckPorn == 0)
                            {
                                streamColorImage = await HttpHelper.DownloadImageAsMemoryStream("https://ascii2d.net" + nodeColorImage.Attributes["src"].Value);
                                if (streamColorImage != null)
                                {
                                    if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                                        imageColorMessage = CheckPornSearch(thuColorImgCache, (streamColorImage as MemoryStream).ToArray());
                                }
                            }
                        }
                        if (streamColorImage != null)
                        {
                            if (imageColorMessage == null)
                                imageColorMessage = await UploadPicture(streamColorImage);
                            streamColorImage?.Dispose();
                        }
                        if (imageColorMessage != null)
                            await SendMessage(new[] { new PlainMessage(stringBuilderColor.ToString()), imageColorMessage }, true);
                        else
                            await SendMessage(new[] { new PlainMessage(stringBuilderColor.ToString()) }, true);
                    }
                    #endregion -- 颜色搜索 --
                }
                catch (Exception ex)
                {
                    bColorError = true;
                    ErrorHelper.WriteErrorLogWithUserMessage("Ascii2D颜色搜索失败", ex, $"请求地址为：{strAscii2dColorResult}");
                }

                try
                {
                    #region -- 特征搜索 --
                    if (!string.IsNullOrEmpty(strAscii2dBovwResult))
                    {
                        HtmlDocument docBovw = new HtmlDocument();
                        docBovw.LoadHtml(strAscii2dBovwResult);
                        string pathBovwItemBox = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']";
                        HtmlNode nodeBovwItemBox = docBovw.DocumentNode.SelectNodes(pathBovwItemBox)[2];
                        string pathBovwHash = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['hash']";
                        string pathBovwImage = "div['col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img";
                        string pathBovwUrlA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[1]";
                        string pathBovwMemberA = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[2]";
                        string pathBovwUrlSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[1]/a";
                        string pathBovwMemberSmall = "div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/small[2]/a";
                        HtmlNode nodeBovwHash = nodeBovwItemBox.SelectSingleNode(pathBovwHash);
                        HtmlNode nodeBovwImage = nodeBovwItemBox.SelectSingleNode(pathBovwImage);
                        HtmlNode nodeBovwUrl = nodeBovwItemBox.SelectSingleNode(pathBovwUrlA) ?? nodeBovwItemBox.SelectSingleNode(pathBovwUrlSmall);
                        HtmlNode nodeBovwMember = nodeBovwItemBox.SelectSingleNode(pathBovwMemberA) ?? nodeBovwItemBox.SelectSingleNode(pathBovwMemberSmall);
                        if (nodeBovwUrl != null)
                        {
                            StringBuilder stringBuilderBovw = new StringBuilder();
                            stringBuilderBovw.AppendLine("ASCII2D 特征搜索");
                            stringBuilderBovw.AppendLine($"标题:{nodeBovwUrl.InnerText}");
                            stringBuilderBovw.AppendLine($"地址:{nodeBovwUrl.Attributes["href"].Value}");
                            if (nodeBovwMember != null)
                            {
                                stringBuilderBovw.AppendLine($"作者:{nodeBovwMember.InnerText}");
                                stringBuilderBovw.AppendLine($"主页:{nodeBovwMember.Attributes["href"].Value}");
                            }

                            string[] thuBovwImgCacheFiles = Directory.GetFiles(ImageHelper.ImagePath, $"Thu_{nodeBovwHash.InnerHtml}*");
                            IChatMessage imageBovwMessage = null;
                            Stream streamBovwImage = null;
                            if (thuBovwImgCacheFiles.Length > 0 && new FileInfo(thuBovwImgCacheFiles[0]).Length > 0)  //如果存在本地缓存
                            {
                                if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                                {
                                    if (thuBovwImgCacheFiles[0].Contains("_NotHealth"))  //曾经鉴黄不通过的
                                        imageBovwMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply); //直接返回鉴黄不通过
                                    else if (thuBovwImgCacheFiles[0].Contains("_IsHealth"))  //曾经鉴黄通过的
                                        streamBovwImage = new FileStream(thuBovwImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);  //上传本地图片
                                    else  //曾经没参与鉴黄的
                                    {
                                        byte[] bovwImageByte = File.ReadAllBytes(thuBovwImgCacheFiles[0]);
                                        imageBovwMessage = CheckPornSearch(thuBovwImgCacheFiles[0], bovwImageByte);
                                        if (imageBovwMessage == null)
                                            streamBovwImage = new MemoryStream(bovwImageByte);  //上传本地图片
                                    }
                                }
                                else if (BotInfo.SearchNoCheckPorn == 0)  //不鉴黄也发图, 直接读取本地图片
                                    streamBovwImage = new FileStream(thuBovwImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                            }
                            else
                            {
                                string thuBovwImgCache = Path.Combine(ImageHelper.ImagePath, $"Thu_{nodeBovwHash.InnerHtml}.png");
                                if ((BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled) || BotInfo.SearchNoCheckPorn == 0)
                                {
                                    streamBovwImage = await HttpHelper.DownloadImageAsMemoryStream("https://ascii2d.net" + nodeBovwImage.Attributes["src"].Value);
                                    if (streamBovwImage != null)
                                    {
                                        if (BotInfo.CheckPornEnabled && BotInfo.SearchCheckPornEnabled)
                                            imageBovwMessage = CheckPornSearch(thuBovwImgCache, (streamBovwImage as MemoryStream).ToArray());
                                    }
                                }
                            }
                            if (streamBovwImage != null)
                            {
                                if (imageBovwMessage == null)
                                    imageBovwMessage = await UploadPicture(streamBovwImage);
                                streamBovwImage?.Dispose();
                            }
                            if (imageBovwMessage != null)
                                await SendMessage(new[] { new PlainMessage(stringBuilderBovw.ToString()), imageBovwMessage }, true);
                            else
                                await SendMessage(new[] { new PlainMessage(stringBuilderBovw.ToString()) }, true);
                        }
                    }
                    #endregion -- 特征搜索 --
                }
                catch (Exception ex)
                {
                    bBovwError = true;
                    ErrorHelper.WriteErrorLogWithUserMessage("Ascii2D特征搜索失败", ex, $"请求地址为：{strAscii2dBovwResult}");
                }

                if (bColorError && bBovwError)
                    _ = SendMessage(new[] { new PlainMessage("Ascii2D搜索失败。") }, true);
            }
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

        public static async Task DownloadPixivOriginPicture(Func<string[], Task<string[]>> SendImage, Func<Stream, Task<IImageMessage>> UploadPicture, Func<IChatMessage[], bool, Task<int>> SendMessage, long id, int p = -1)
        {
            string msg = await CheckCatRoute(id, p);
            string index = "";
            if (p != -1)
                index = $"-{p + 1}";

            if (string.IsNullOrEmpty(msg))
            {
                string url = $"https://pixiv.re/{id}{index}.png";
                string imgName = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{id}_p{p}.png");
                MemoryStream imageMs = await HttpHelper.DownloadImageAsMemoryStream(url);
                MemoryStream ms = new MemoryStream(imageMs.ToArray());
                imageMs.Dispose();
                IImageMessage imgMsg = await UploadPicture(ms);
                if (BotInfo.CheckPornEnabled && BotInfo.OriginPictureCheckPornEnabled)
                {
                    switch (CheckPorn(imgName, ms.ToArray(), out string errorMessage))
                    {
                        case 0:  //鉴黄通过
                            await SendImage(new[] { url });
                            break;
                        case 1:  //鉴黄不通过
                            switch (BotInfo.OriginPictureCheckPornEvent)
                            {
                                case 0:  //合并转发
                                    SendByForward(imgMsg);
                                    break;
                                case 2:  //回复消息
                                    _ = SendMessage(new[] { new PlainMessage(BotInfo.OriginPictureCheckPornIllegalReply) }, true);
                                    break;
                            }
                            break;
                        case 2:  //鉴黄错误
                            switch (BotInfo.OriginPictureCheckPornEvent)
                            {
                                case 0:  //合并转发
                                    SendByForward(imgMsg);
                                    break;
                                case 2:  //回复消息
                                    _ = SendMessage(new[] { new PlainMessage(BotInfo.OriginPictureCheckPornErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", errorMessage))) }, true);
                                    break;
                            }
                            break;
                    }
                    ms.Dispose();
                }
                else
                {
                    await SendImage(new[] { url });
                }

                void SendByForward(IImageMessage imgMsg)  //以合并转发的方式发送
                {
                    Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage forwardMessage = new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.ForwardMessageNode()
                   {
                       Id = 0,
                       Name = BotInfo.BotName,
                       QQNumber = BotInfo.QQId,
                       Time = DateTime.Now,
                       Chain = new []{ imgMsg as Mirai.CSharp.HttpApi.Models.ChatMessages.IImageMessage },
                   }});
                   SendMessage(new[] { forwardMessage }, false);
                }
            }
            else
                _ = SendMessage(new[] { new PlainMessage(msg) }, false);
        }

        private static IChatMessage CheckPornSearch(string cacheImageName, byte[] image)
        {
            IChatMessage IImageMessage = null;
            if (Cache.CheckPornCounting > BotInfo.CheckPornLimitCount)
            {
                switch (BotInfo.SearchCheckPornOutOfLimitEvent)
                {
                    case 0:
                        return null;
                    case 1:
                        return new PlainMessage("");
                    case 2:
                        return new PlainMessage(BotInfo.SearchCheckPornOutOfLimitReply);
                }
            }
            switch (CheckPorn(cacheImageName, image, out string errorMessage))
            {
                case 1:
                    IImageMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply);
                    break;
                case 2:
                    IImageMessage = new PlainMessage(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", errorMessage)));
                    break;
            }
            return IImageMessage;
        }

        /// <summary>
        /// 鉴黄指定的图片
        /// </summary>
        /// <returns>0.鉴黄通过 1.鉴黄不通过 2.鉴黄发生错误</returns>
        private static int CheckPorn(string cacheImageName, byte[] image, out string errorMessage)
        {
            errorMessage = null;
            int checkPornType = 0;
            string path = Path.GetDirectoryName(cacheImageName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(cacheImageName);
            string healthFileName = Path.Combine(path, fileNameWithoutExtension + "_IsHealth.png");
            if (File.Exists(healthFileName) && new FileInfo(healthFileName).Length > 0)
                return 0;
            string notHealthFileName = Path.Combine(path, fileNameWithoutExtension + "_NotHealth.png");
            if (File.Exists(notHealthFileName) && new FileInfo(notHealthFileName).Length > 0)
                return 1;

            try
            {
                if (!File.Exists(cacheImageName))
                    File.WriteAllBytes(cacheImageName, image);
                bool bHealth = TencentCloudHelper.CheckImageHealth(image);
                Cache.CheckPornCounting++;
                if (bHealth)
                {
                    File.Move(cacheImageName, healthFileName, true);
                }
                else
                {
                    checkPornType = 1;
                    File.Move(cacheImageName, notHealthFileName, true);
                }
            }
            catch (Exception ex)
            {
                checkPornType = 2;
                errorMessage = ex.Message;
            }
            return checkPornType;
        }

        public static async Task SuccessiveSearchPicture(IImageMessage imgMsg, long qqId, Func<Stream, Task<IImageMessage>> UploadPicture, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<string[], Task<string[]>> SendImage)
        {
            Cache.SearchingPicturesUsers[qqId] = DateTime.Now.AddMinutes(1);
            await SearchPicture(imgMsg, UploadPicture, SendMessage, SendImage);
        }
    }
}
