using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using HtmlAgilityPack;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace GreenOnions.PictureSearcher
{
    public static class SearchPictureHandler
    {
        private static readonly string imagePath = Environment.CurrentDirectory + "\\Image\\";
        public static async Task SearchPicture(ImageMessage inImgMsg, Func<Stream, Task<ImageMessage>> UploadPicture, Action<IMessageBase[]> SendMessage)
        {
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
                SendMessage(new[] { new PlainMessage(BotInfo.SearchErrorReply + ex.Message) });
            }

            async Task SearchTraceMoe()
            {
                string TraceMoeUrl = @$"https://trace.moe/api/search?url={inImgMsg.Url}";
                try
                {
                    string strSauceTraceMoe = await HttpHelper.GetHttpResponseStringAsync(TraceMoeUrl, out _);
                    JToken json = JsonConvert.DeserializeObject<JToken>(strSauceTraceMoe);
                    JArray jResults = json["docs"] as JArray;
                    if (jResults.Count > 0)
                    {
                        double similarity = Math.Round(Convert.ToDouble(jResults[0]["similarity"]), 2) * 100; //相似度
                        if (similarity >= BotInfo.TraceMoeSendThreshold)
                        {
                            //string anilist_id = jResults[0]["anilist_id"].ToString();
                            //string filename = HttpUtility.UrlEncode(jResults[0]["filename"].ToString());
                            //string tokenthumb = jResults[0]["tokenthumb"].ToString();
                            string anime = jResults[0]["anime"].ToString();         //动画名称
                            string title = jResults[0]["title"].ToString();         //标题
                                                                                    //string title_chinese = jResults[0]["title_chinese"].ToString(); //中文标题
                                                                                    //string title_english = jResults[0]["title_english"].ToString(); //英文标题
                            string episode = jResults[0]["episode"].ToString();  //集数
                            string at = jResults[0]["at"].ToString(); //时间
                            int seconds = (int)Convert.ToSingle(at); //时间
                            TimeSpan timeSpan = new TimeSpan(0, 0, seconds);
                            string time = $"{timeSpan.Hours}小时{timeSpan.Minutes}分{timeSpan.Seconds}秒";
                            SendMessage(new[] { new PlainMessage($"动画名称:{anime}\r\n标题:{title}\r\n相似度:{similarity}% (trace.moe)\r\n第{episode}集 {time}处") });
                            //if (similarity >= BotInfo.TraceMoeStopThreshold) return;
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
                string SauceNaoUrl = @$"https://saucenao.com/search.php?db=999&output_type=2&api_key={BotInfo.SauceNAOApiKey}&testmode=1&numres=16&url={inImgMsg.Url}";
                string strSauceNaoResult;
                try
                {
                    strSauceNaoResult = await HttpHelper.GetHttpResponseStringAsync(SauceNaoUrl, out _);
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

                    IMessageBase imageMessage = null;
                    //相似度大于设定的阈值
                    if (sauceNaoItem.similarity > BotInfo.SearchLowSimilarity)
                    {
                        if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
                        string[] thuImgCacheFiles = sauceNaoItem.pixiv_id == null ? Directory.GetFiles(imagePath, $"Thu_Other_{sauceNaoItem.thumbnail.Substring(sauceNaoItem.thumbnail.LastIndexOf("=") + 1)}*") : Directory.GetFiles(imagePath, $"Thu_{sauceNaoItem.pixiv_id}*");
                        Stream stream = null;
                        if (thuImgCacheFiles.Length > 0 && new FileInfo(thuImgCacheFiles[0]).Length > 0)  //存在本地缓存
                        {
                            if (BotInfo.SearchCheckPornEnabled)
                            {
                                if (thuImgCacheFiles[0].Contains("_NotHealth"))  //曾经鉴黄不通过的
                                    imageMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply); //直接返回鉴黄不通过
                                else if (thuImgCacheFiles[0].Contains("_IsHealth"))  //曾经鉴黄通过的
                                    stream = new FileStream(thuImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);  //上传本地图片
                                else  //曾经没参与鉴黄的
                                    imageMessage = CheckPorn(thuImgCacheFiles[0], File.ReadAllBytes(thuImgCacheFiles[0]));
                            }
                            else
                            {
                                stream = new FileStream(thuImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                            }
                        }
                        else  //没有本地缓存
                        {
                            string cacheImageName = Path.Combine(imagePath, $"Thu_{sauceNaoItem.pixiv_id}.png");
                            stream = HttpHelper.DownloadImageAsMemoryStream(sauceNaoItem.thumbnail, cacheImageName);
                            if (BotInfo.SearchCheckPornEnabled)
                                imageMessage = CheckPorn(cacheImageName, (stream as MemoryStream).ToArray());
                        }

                        if (imageMessage == null)
                        {
                            imageMessage = await UploadPicture(stream);

                            //如果是pixiv体系尝试下载原图
                            if (sauceNaoItem.pixiv_id != null)
                            {
                                string getP = @$".+{sauceNaoItem.pixiv_id}_p([0-9]+)[_\.].+";
                                Match matchBigImg = Regex.Match(sauceNaoItem.index_name, getP);
                                int p = 0;
                                //在p0的情况下暂时还不知道怎么判断是单图ID还是多图ID, 就都请求一次
                                if (matchBigImg.Groups.Count > 1)
                                {
                                    p = Convert.ToInt32(matchBigImg.Groups[1].Value);
                                    if (p == 0)
                                    {
                                        _ = Task.Run(() =>
                                        {
                                            try
                                            {
                                                string imgName = $"{imagePath}Pixiv_{sauceNaoItem.pixiv_id}_p0.png";
                                                if (File.Exists(imgName) && new FileInfo(imgName).Length > 0)  //如果存在本地缓存
                                                        UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).ContinueWith(uploaded => SendMessage(new[] { uploaded.Result }));
                                                else
                                                    UploadPicture(HttpHelper.DownloadImageAsMemoryStream($"https://pixiv.cat/{sauceNaoItem.pixiv_id}.png", imgName)).ContinueWith(uploaded => SendMessage(new[] { uploaded.Result }));
                                            }
                                            catch (Exception ex)
                                            {
                                                ErrorHelper.WriteErrorLog(ex);  //异常只是不发送原图, 不需要返回消息
                                                }
                                        });
                                    }
                                }
                                _ = Task.Run(() =>
                                {
                                    try
                                    {
                                        string imgName = $"{imagePath}Pixiv_{sauceNaoItem.pixiv_id}_p{p}.png";
                                        if (File.Exists(imgName) && new FileInfo(imgName).Length > 0)  //如果存在本地缓存
                                                UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).ContinueWith(uploaded => SendMessage(new[] { uploaded.Result }));
                                        else
                                            UploadPicture(HttpHelper.DownloadImageAsMemoryStream($"https://pixiv.cat/{sauceNaoItem.pixiv_id}-{p + 1}.png", imgName)).ContinueWith(uploaded => SendMessage(new[] { uploaded.Result }));
                                    }
                                    catch (Exception ex)
                                    {
                                        ErrorHelper.WriteErrorLog(ex);  //异常只是不发送原图, 不需要返回消息
                                        }
                                });
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
                        imageMessage = new PlainMessage(strLowSimilarity);
                    }
                    SendMessage(new[] { plain, imageMessage });
                    return;
                }
                string strNoResult = BotInfo.SearchNoResultReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("搜索类型", "SauceNao"));
                if (BotInfo.SearchEnabledASCII2D)
                {
                    strNoResult += "\r\n自动使用ASCII2D搜索。";
                    _ = SearchAscii2D();
                }
                SendMessage(new[] { new PlainMessage(strNoResult) });
            }

            async Task SearchAscii2D()
            {
                string strAscii2dColorResult = await HttpHelper.GetHttpResponseStringAsync(@$"https://ascii2d.net/search/url/{inImgMsg.Url}", out string colorUrl);
                string strAscii2dBovwResult = await HttpHelper.GetHttpResponseStringAsync(colorUrl.Replace("/color/", "/bovw/"), out _);

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
                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }
                    string[] thuColorImgCacheFiles = Directory.GetFiles(imagePath, $"Thu_{nodeColorHash.InnerHtml}*");
                    IMessageBase imageColorMessage = null;
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
                        {
                            streamColorImage = new FileStream(thuColorImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                        }
                    }
                    else
                    {
                        string thuColorImgCache = Path.Combine(imagePath, $"Thu_{nodeColorHash.InnerHtml}.png");
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
                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }
                    string[] thuBovwImgCacheFiles = Directory.GetFiles(imagePath, $"Thu_{nodeBovwHash.InnerHtml}*");
                    IMessageBase imageBovwMessage = null;
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
                        {
                            streamBovwImage = new FileStream(thuBovwImgCacheFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                        }
                    }
                    else
                    {
                        string thuBovwImgCache = Path.Combine(imagePath, $"Thu_{nodeBovwHash.InnerHtml}.png");
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
                {
                    SendMessage(new[] { new PlainMessage("Ascii2D搜索失败。") });
                }
            }
        }

        private static IMessageBase CheckPorn(string cacheImageName, byte[] image)
        {
            IMessageBase imageMessage = null;
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
                    imageMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply);
                    if (File.Exists(cacheImageName))
                        File.Move(cacheImageName, notHealthFileName, true);
                }
            }
            catch (Exception ex)
            {
                imageMessage = new PlainMessage(BotInfo.SearchCheckPornErrorReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("错误信息", ex.Message)));
            }
            return imageMessage;
        }

        public static async Task SuccessiveSearchPicture(MiraiHttpSession session, ImageMessage imgMsg, IGroupMemberInfo sender, Func<Stream, Task<ImageMessage>> UploadPicture, Action<IMessageBase[]> SendMessage)
        {
            Cache.SearchingPictures[sender.Id] = DateTime.Now.AddMinutes(1);
            await SearchPicture(imgMsg, UploadPicture, SendMessage);
        }
    }
}
