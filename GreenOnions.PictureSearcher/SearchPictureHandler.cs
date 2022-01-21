using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using HtmlAgilityPack;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static async Task SearchPicture(IImageMessage inImgMsg, Func<Stream, Task<IImageMessage>> UploadPicture, Action<IChatMessage[]> SendMessage)
        {
            string qqImgUrl = inImgMsg.Url.Replace("/gchat.qpic.cn/gchatpic_new/", "/c2cpicdw.qpic.cn/offpic_new/");
            try
            {
                if (BotInfo.SearchEnabledTraceMoe)
                {
                    _ = SearchTraceMoe();
                }
                if (BotInfo.SearchEnabledSauceNao && !string.IsNullOrWhiteSpace(BotInfo.SauceNAOApiKey))
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
                SendMessage(new [] { new PlainMessage(BotInfo.SearchErrorReply + ex.Message) });
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
                            string previewSize = "m";  //TODO:选择是否发送缩略图和尺寸
                            string previewURL = jResults[0]["image"].ToString() + $"&size={previewSize}";
                            string imgName = Path.Combine(ImageHelper.ImagePath, $"TraceMoe_{id}_{previewSize}.png");

                            _ = Task.Run(() =>
                            {
                                try
                                {
                                    if (File.Exists(imgName))
                                        UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }));
                                    else
                                        UploadPicture(HttpHelper.DownloadImageAsMemoryStream(previewURL, imgName)).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }));
                                }
                                catch (Exception ex)
                                {
                                    ErrorHelper.WriteErrorLog(ex);  //异常只是不发送缩略图, 不需要返回消息
                                }
                            });
                            SendMessage(new[] { new PlainMessage($"动画名称:{anime}\r\n其他名称:{synonyms}\r\n相似度:{similarity}% (trace.moe)\r\n里:{(isAdult ? "是" : "否")}\r\n第{episode}集 {time}处") });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorHelper.WriteErrorLogWithUserMessage("TraceMoe搜番失败", ex, $"请求地址为：{TraceMoeUrl}");
                    SendMessage(new[] { new PlainMessage("TraceMoe搜番失败，" + ex.Message) });
                }
            }

            async Task SearchSauceNao()
            {
                string SauceNaoUrl = @$"https://saucenao.com/search.php?db=999&output_type=2&api_key={BotInfo.SauceNAOApiKey}&testmode=1&numres=16&url={qqImgUrl}";
                string strSauceNaoResult;
                try
                {
                    strSauceNaoResult = await HttpHelper.GetHttpResponseStringAsync(SauceNaoUrl);
                }
                catch (Exception ex)
                {
                    ErrorHelper.WriteErrorLogWithUserMessage("SauceNao搜图失败", ex, $"请求地址为：{SauceNaoUrl}");
                    SendMessage(new[] { new PlainMessage("SauceNao搜图失败，" + ex.Message) });
                    return;
                }
                JToken json = JsonConvert.DeserializeObject<JToken>(strSauceNaoResult);
                JArray jResults = json["results"] as JArray;

                //jResults = new JArray(jResults.OrderByDescending(x => x["header"]["similarity"]));  //按相似度排序

                if (jResults == null)
                {
                    ErrorHelper.WriteErrorLogWithUserMessage("SauceNao没有搜索到结果", null, $"请求地址为：{SauceNaoUrl}");
                    SendMessage(new[] { new PlainMessage(BotInfo.SearchNoResultReply.Replace("<搜索类型>", "SauceNao")) });
                    return;
                }

                for (int j = 0; j < jResults.Count; j++)
                {
                    JToken jHeader = jResults[j]["header"];
                    JToken jData = jResults[j]["data"];

                    SauceNaoItem sauceNaoItem = new SauceNaoItem();

                    sauceNaoItem.similarity = Convert.ToSingle(jHeader["similarity"]);
                    sauceNaoItem.thumbnail = jHeader["thumbnail"].ToString();  //缩略图地址
                    sauceNaoItem.index_name = jHeader["index_name"].ToString();  //index_name

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

                    PlainMessage plain = new PlainMessage(stringBuilder.ToString());

                    IChatMessage IImageMessage = null;
                    //相似度大于设定的阈值
                    if (sauceNaoItem.similarity > BotInfo.SearchLowSimilarity)
                    {
                        string[] thuImgCacheFiles = sauceNaoItem.pixiv_id == null ? Directory.GetFiles(ImageHelper.ImagePath, $"Thu_Other_{sauceNaoItem.thumbnail.Substring(sauceNaoItem.thumbnail.LastIndexOf("=") + 1)}*") : Directory.GetFiles(ImageHelper.ImagePath, $"Thu_{sauceNaoItem.pixiv_id}*");
                        Stream stream = null;
                        if (thuImgCacheFiles.Length > 0 && new FileInfo(thuImgCacheFiles[0]).Length > 0)  //存在本地缓存
                        {
                            if (BotInfo.SearchCheckPornEnabled)
                            {
                                if (thuImgCacheFiles[0].Contains("_NotHealth"))  //曾经鉴黄不通过的
                                    IImageMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply); //直接返回鉴黄不通过
                                else if (thuImgCacheFiles[0].Contains("_IsHealth"))  //曾经鉴黄通过的
                                    stream = new FileStream(thuImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);  //上传本地图片
                                else  //曾经没参与鉴黄的
                                    IImageMessage = CheckPorn(thuImgCacheFiles[0], File.ReadAllBytes(thuImgCacheFiles[0]));
                            }
                            else
                            {
                                stream = new FileStream(thuImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                            }
                        }
                        else  //没有本地缓存
                        {
                            string cacheImageName = Path.Combine(ImageHelper.ImagePath, $"Thu_{sauceNaoItem.pixiv_id}.png");
                            stream = HttpHelper.DownloadImageAsMemoryStream(sauceNaoItem.thumbnail, cacheImageName);
                            if (BotInfo.SearchCheckPornEnabled)
                                IImageMessage = CheckPorn(cacheImageName, (stream as MemoryStream).ToArray());
                        }

                        if (IImageMessage == null)
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
                                            string imgUrlNoP = $"https://pixiv.re/{sauceNaoItem.pixiv_id}.png";
                                            using (var request = new HttpRequestMessage(new HttpMethod("GET"), imgUrlHasP))  //尝试带着P请求一次cat
                                            {
                                                HttpResponseMessage response = await httpClient.SendAsync(request);
                                                HtmlDocument docColor = new HtmlDocument();
                                                docColor.LoadHtml(await response.Content.ReadAsStringAsync());
                                                if (docColor.DocumentNode.ChildNodes.Count == 3)  //Body三个标签说明返回的是路由错误的提示, 真实地址没有P
                                                    SendOriginImage(imgUrlNoP, sauceNaoItem.pixiv_id);
                                                else  //真实地址有P=0
                                                    SendOriginImage(imgUrlHasP, sauceNaoItem.pixiv_id);
                                            }
                                        }
                                    }
                                    else  //地址有P且>0
                                        SendOriginImage(imgUrlHasP, sauceNaoItem.pixiv_id);
                                }
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
                    SendMessage(new[] { plain, IImageMessage });
                    return;
                }
                string strNoResult = BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("<搜索类型>", "SauceNao"));
                if (BotInfo.SearchEnabledASCII2D)
                {
                    strNoResult += "\r\n自动使用ASCII2D搜索。";
                    _ = SearchAscii2D();
                }
                SendMessage(new[] { new PlainMessage(strNoResult) });

                void SendOriginImage(string url, string pixivID)
                {
                    Task.Run(() =>
                    {
                        try
                        {
                            string imgName = Path.Combine(ImageHelper.ImagePath, $"Pixiv_{pixivID}_p0.png");
                            if (File.Exists(imgName) && new FileInfo(imgName).Length > 0)  //如果存在本地缓存
                                UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }));
                            else
                                UploadPicture(HttpHelper.DownloadImageAsMemoryStream(url, imgName)).ContinueWith(async uploaded => SendMessage(new[] { await uploaded }));  //请求不含P的地址
                        }
                        catch (Exception ex)
                        {
                            ErrorHelper.WriteErrorLog(ex);  //异常只是不发送原图, 不需要返回消息
                        }
                    });
                }
            }

            async Task SearchAscii2D()
            {
                var response = await HttpHelper.GetHttpResponseStringAndJumpUrlAsync(@$"https://ascii2d.net/search/url/{qqImgUrl}");
                string strAscii2dColorResult = response.response;
                string strAscii2dBovwResult = await HttpHelper.GetHttpResponseStringAsync(response.jumpUrl.Replace("/color/", "/bovw/"));

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
                    stringBuilderColor.AppendLine("ASCII2D 颜色搜索");
                    stringBuilderColor.AppendLine($"标题:{nodeColorUrl.InnerText}");
                    stringBuilderColor.AppendLine($"地址:{nodeColorUrl.Attributes["href"].Value}");
                    stringBuilderColor.AppendLine($"作者:{nodeColorMember.InnerText}");
                    stringBuilderColor.AppendLine($"主页:{nodeColorMember.Attributes["href"].Value}");

                    string[] thuColorImgCacheFiles = Directory.GetFiles(ImageHelper.ImagePath, $"Thu_{nodeColorHash.InnerHtml}*");
                    IChatMessage imageColorMessage = null;
                    Stream streamColorImage = null;
                    if (thuColorImgCacheFiles.Length > 0 && new FileInfo(thuColorImgCacheFiles[0]).Length > 0)  //如果存在本地缓存
                    {
                        if (BotInfo.SearchCheckPornEnabled)
                        {
                            if (thuColorImgCacheFiles[0].Contains("_NotHealth"))  //曾经鉴黄不通过的
                                imageColorMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply); //直接返回鉴黄不通过
                            else if (thuColorImgCacheFiles[0].Contains("_IsHealth"))  //曾经鉴黄通过的
                                streamColorImage = new FileStream(thuColorImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);  //上传本地图片
                            else  //曾经没参与鉴黄的
                            {
                                byte[] colorImageByte = File.ReadAllBytes(thuColorImgCacheFiles[0]);
                                imageColorMessage = CheckPorn(thuColorImgCacheFiles[0], colorImageByte);
                                if (imageColorMessage == null)
                                    streamColorImage = new MemoryStream(colorImageByte);  //上传本地图片
                            }
                        }
                        else
                            streamColorImage = new FileStream(thuColorImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                    }
                    else
                    {
                        string thuColorImgCache = Path.Combine(ImageHelper.ImagePath, $"Thu_{nodeColorHash.InnerHtml}.png");
                        streamColorImage = HttpHelper.DownloadImageAsMemoryStream("https://ascii2d.net" + nodeColorImage.Attributes["src"].Value, thuColorImgCache);
                        if (BotInfo.SearchCheckPornEnabled)
                            imageColorMessage = CheckPorn(thuColorImgCache, (streamColorImage as MemoryStream).ToArray());
                    }

                    if (imageColorMessage == null)
                        imageColorMessage = await UploadPicture(streamColorImage);

                    SendMessage(new[] { new PlainMessage(stringBuilderColor.ToString()), imageColorMessage });
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
                    StringBuilder stringBuilderBovw = new StringBuilder();
                    stringBuilderBovw.AppendLine("ASCII2D 特征搜索");
                    stringBuilderBovw.AppendLine($"标题:{nodeBovwUrl.InnerText}");
                    stringBuilderBovw.AppendLine($"地址:{nodeBovwUrl.Attributes["href"].Value}");
                    stringBuilderBovw.AppendLine($"作者:{nodeBovwMember.InnerText}");
                    stringBuilderBovw.AppendLine($"主页:{nodeBovwMember.Attributes["href"].Value}");

                    string[] thuBovwImgCacheFiles = Directory.GetFiles(ImageHelper.ImagePath, $"Thu_{nodeBovwHash.InnerHtml}*");
                    IChatMessage imageBovwMessage = null;
                    Stream streamBovwImage = null;
                    if (thuBovwImgCacheFiles.Length > 0 && new FileInfo(thuBovwImgCacheFiles[0]).Length > 0)  //如果存在本地缓存
                    {
                        if (BotInfo.SearchCheckPornEnabled)
                        {
                            if (thuBovwImgCacheFiles[0].Contains("_NotHealth"))  //曾经鉴黄不通过的
                                imageBovwMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply); //直接返回鉴黄不通过
                            else if (thuBovwImgCacheFiles[0].Contains("_IsHealth"))  //曾经鉴黄通过的
                                streamBovwImage = new FileStream(thuBovwImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);  //上传本地图片
                            else  //曾经没参与鉴黄的
                            {
                                byte[] bovwImageByte = File.ReadAllBytes(thuBovwImgCacheFiles[0]);
                                if (BotInfo.SearchCheckPornEnabled)
                                    imageBovwMessage = CheckPorn(thuBovwImgCacheFiles[0], bovwImageByte);
                                if (imageBovwMessage == null)
                                    streamBovwImage = new MemoryStream(bovwImageByte);  //上传本地图片
                            }
                        }
                        else
                            streamBovwImage = new FileStream(thuBovwImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                    }
                    else
                    {
                        string thuBovwImgCache = Path.Combine(ImageHelper.ImagePath, $"Thu_{nodeBovwHash.InnerHtml}.png");
                        streamBovwImage = HttpHelper.DownloadImageAsMemoryStream("https://ascii2d.net" + nodeBovwImage.Attributes["src"].Value, thuBovwImgCache);
                        if (BotInfo.SearchCheckPornEnabled)
                            imageBovwMessage = CheckPorn(thuBovwImgCache, (streamBovwImage as MemoryStream).ToArray());
                    }
                    if (imageBovwMessage == null)
                        imageBovwMessage = await UploadPicture(streamBovwImage);

                    SendMessage(new[] { new PlainMessage(stringBuilderBovw.ToString()), imageBovwMessage });
                    #endregion -- 特征搜索 --

                }
                catch (Exception ex)
                {
                    bBovwError = true;
                    ErrorHelper.WriteErrorLogWithUserMessage("Ascii2D特征搜索失败", ex, $"请求地址为：{strAscii2dBovwResult}");
                }

                if (bColorError && bBovwError)
                    SendMessage(new[] { new PlainMessage("Ascii2D搜索失败。") });
            }
        }

        private static IChatMessage CheckPorn(string cacheImageName, byte[] image)
        {
            IChatMessage IImageMessage = null;
            string path = Path.GetDirectoryName(cacheImageName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(cacheImageName);
            string healthFileName = Path.Combine(path, fileNameWithoutExtension + "_IsHealth.png");
            string notHealthFileName = Path.Combine(path, fileNameWithoutExtension + "_NotHealth.png");
            try
            {
                bool bHealth = TencentCloudHelper.CheckImageHealth(image);
                if (bHealth)
                {
                    if (File.Exists(cacheImageName))
                        File.Move(cacheImageName, healthFileName, true);
                }
                else
                {
                    IImageMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply);
                    if (File.Exists(cacheImageName))
                        File.Move(cacheImageName, notHealthFileName, true);
                }
            }
            catch (Exception ex)
            {
                IImageMessage = new PlainMessage(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", ex.Message)));
            }
            return IImageMessage;
        }

        public static async Task SuccessiveSearchPicture(IImageMessage imgMsg, long qqId, Func<Stream, Task<IImageMessage>> UploadPicture, Action<IChatMessage[]> SendMessage)
        {
            Cache.SearchingPictures[qqId] = DateTime.Now.AddMinutes(1);
            await SearchPicture(imgMsg, UploadPicture, SendMessage);
        }
    }
}
