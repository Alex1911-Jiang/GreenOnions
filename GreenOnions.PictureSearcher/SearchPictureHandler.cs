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
        public static async Task SearchPicture(MiraiHttpSession session, ImageMessage inImgMsg, IGroupMemberInfo sender, QuoteMessage quoteMessage)
        {
            try
            {
                var v = await session.GetFriendListAsync();

                if (BotInfo.SearchEnabledSauceNao)
                {
                    await SearchSauceNao();
                }
                else if (BotInfo.SearchEnabledASCII2D)  //不启用SauceNao只启用ASCII2D
                {
                    await SearchAscii2D();
                }
            }
            catch (Exception)
            {
                await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(BotInfo.SearchErrorReply) }, quoteMessage.Id);
            }

            async Task SearchSauceNao()
            {
                if (BotInfo.SearchEnabledSauceNao)
                {
                    string strSauceNaoResult = await HttpHelper.GetHttpResponseStringAsync(@$"https://saucenao.com/search.php?db=999&output_type=2&api_key={BotInfo.SauceNAOApiKey}&testmode=1&numres=16&url={inImgMsg.Url}", out _);

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

                        //AtMessage atMember = new AtMessage(e.Sender.Id);

                        StringBuilder stringBuilder = new StringBuilder();

                        if (sauceNaoItem.ext_urls != null)
                        {
                            string url = "";
                            if (sauceNaoItem.ext_urls.Count == 1)
                            {
                                url = $"地址:{sauceNaoItem.ext_urls[0]}\r\n";
                            }
                            else
                            {
                                for (int k = 0; k < sauceNaoItem.ext_urls.Count; k++)
                                {
                                    url += $"地址{k + 1}:{sauceNaoItem.ext_urls[k]}\r\n";
                                }
                            }
                            stringBuilder.AppendLine(url);
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
                        //相似度大于50%
                        if (sauceNaoItem.similarity > BotInfo.SearchLowSimilarity)
                        {
                            if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
                            string thuImgCache = $"{imagePath}Thu_{sauceNaoItem.pixiv_id}.jpg";
                            MemoryStream ms = HttpHelper.DownloadImageAsMemoryStream(sauceNaoItem.thumbnail, thuImgCache);

                            imageMessage = CheckPorn(ms);

                            if (imageMessage == null)
                            {
                                imageMessage = await session.UploadPictureAsync(UploadTarget.Group, ms);

                                //如果是pixiv体系尝试下载原图
                                if (sauceNaoItem.pixiv_id != null)
                                {
                                    //TODO:优先读缓存

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
                                                    session.UploadPictureAsync(UploadTarget.Group, HttpHelper.DownloadImageAsMemoryStream($"https://pixiv.cat/{sauceNaoItem.pixiv_id}.jpg", $"{imagePath}Pixiv_{sauceNaoItem.pixiv_id}_p0.jpg")).ContinueWith(uploaded => session.SendGroupMessageAsync(sender.Group.Id, uploaded.Result));
                                                }
                                                catch
                                                {
                                                    //异常只是不发送原图, 不需要处理
                                                }
                                            });
                                        }
                                    }
                                    _ = Task.Run(() =>
                                    {
                                        try
                                        {
                                            session.UploadPictureAsync(UploadTarget.Group, HttpHelper.DownloadImageAsMemoryStream($"https://pixiv.cat/{sauceNaoItem.pixiv_id}-{p + 1}.jpg", $"{imagePath}Pixiv_{sauceNaoItem.pixiv_id}_p{p}.jpg")).ContinueWith(uploaded => session.SendGroupMessageAsync(sender.Group.Id, uploaded.Result));
                                        }
                                        catch
                                        {
                                            //异常只是不发送原图, 不需要处理
                                        }
                                    });
                                }
                            }
                        }
                        else
                        {
                            string strLowSimilarity = BotInfo.SearchLowSimilarityReply.Replace("<相似度阈值>", BotInfo.SearchLowSimilarity.ToString());
                            if (BotInfo.SearchEnabledASCII2D)
                            {
                                strLowSimilarity += "\r\n自动使用ASCII2D搜索。";
                                await SearchAscii2D();
                            }
                            imageMessage = new PlainMessage(strLowSimilarity);
                        }
                        await session.SendGroupMessageAsync(sender.Group.Id, new[] { plain, imageMessage }, quoteMessage.Id);
                        return;
                    }
                    string strNoResult = BotInfo.SearchNoResultReply.Replace("<搜索类型>", "SauceNao");
                    if (BotInfo.SearchEnabledASCII2D)
                    {
                        strNoResult += "\r\n自动使用ASCII2D搜索。";
                        await SearchAscii2D();
                    }
                    await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(strNoResult) }, quoteMessage.Id);
                }
            }

            async Task SearchAscii2D()
            {
                string strAscii2dColorResult = await HttpHelper.GetHttpResponseStringAsync(@$"https://ascii2d.net/search/url/{inImgMsg.Url}", out string colorUrl);
                string strAscii2dBovwResult = await HttpHelper.GetHttpResponseStringAsync(colorUrl.Replace("/color/", "/bovw/"), out string _);

                #region -- 颜色搜索 --
                HtmlDocument docColor = new HtmlDocument();
                docColor.LoadHtml(strAscii2dColorResult);
                string pathColorHash = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['hash']";
                string pathColorImage = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img";
                string pathColorUrl = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[1]";
                string pathColorMember = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[2]";
                HtmlNode nodeColorHash = docColor.DocumentNode.SelectSingleNode(pathColorHash);
                HtmlNode nodeColorImage = docColor.DocumentNode.SelectSingleNode(pathColorImage);
                HtmlNode nodeColorUrl = docColor.DocumentNode.SelectSingleNode(pathColorUrl);
                HtmlNode nodeColorMember = docColor.DocumentNode.SelectSingleNode(pathColorMember);
                StringBuilder stringBuilderColor = new StringBuilder();
                stringBuilderColor.AppendLine("ASCII2D 颜色搜索");
                stringBuilderColor.AppendLine($"标题:{nodeColorUrl.InnerText}");
                stringBuilderColor.AppendLine($"地址:{nodeColorUrl.Attributes["href"].Value}");
                stringBuilderColor.AppendLine($"作者:{nodeColorMember.InnerText}");
                stringBuilderColor.AppendLine($"主页:{nodeColorMember.Attributes["href"].Value}");
                string thuColorImgCache = $"{imagePath}Thu_{nodeColorHash.InnerHtml}.jpg";
                //TODO:优先读缓存
                MemoryStream msColorImage = HttpHelper.DownloadImageAsMemoryStream("https://ascii2d.net" + nodeColorImage.Attributes["src"].Value, thuColorImgCache);
                IMessageBase imageColorMessage = CheckPorn(msColorImage);
                if (imageColorMessage == null) imageColorMessage = await session.UploadPictureAsync(UploadTarget.Group, msColorImage);
                await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(stringBuilderColor.ToString()), imageColorMessage }, quoteMessage.Id);
                #endregion -- 颜色搜索 --

                #region -- 特征搜索 --
                HtmlDocument docBovw = new HtmlDocument();
                docBovw.LoadHtml(strAscii2dBovwResult);
                string pathBovwHash = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['hash']";
                string pathBovwImage = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-4 col-xl-4 text-xs-center image-box']/img";
                string pathBovwUrl = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[1]";
                string pathBovwMember = "/html/body/div['container']/div['row']/div['col-xs-12 col-lg-8 col-xl-8']/div['row item-box']/div['col-xs-12 col-sm-12 col-md-8 col-xl-8 info-box']/div['detail-box gray-link']/h6/a[2]";
                HtmlNode nodeBovwHash = docBovw.DocumentNode.SelectSingleNode(pathBovwHash);
                HtmlNode nodeBovwImage = docBovw.DocumentNode.SelectSingleNode(pathBovwImage);
                HtmlNode nodeBovwUrl = docBovw.DocumentNode.SelectSingleNode(pathBovwUrl);
                HtmlNode nodeBovwMember = docBovw.DocumentNode.SelectSingleNode(pathBovwMember);
                StringBuilder stringBuilderBovw = new StringBuilder();
                stringBuilderBovw.AppendLine("ASCII2D 特征搜索");
                stringBuilderBovw.AppendLine($"标题:{nodeBovwUrl.InnerText}");
                stringBuilderBovw.AppendLine($"地址:{nodeBovwUrl.Attributes["href"].Value}");
                stringBuilderBovw.AppendLine($"作者:{nodeBovwMember.InnerText}");
                stringBuilderBovw.AppendLine($"主页:{nodeBovwMember.Attributes["href"].Value}");
                string thuBovwImgCache = $"{imagePath}Thu_{nodeBovwHash.InnerHtml}.jpg";
                //TODO:优先读缓存
                MemoryStream msBovwImage = HttpHelper.DownloadImageAsMemoryStream("https://ascii2d.net" + nodeBovwImage.Attributes["src"].Value, thuBovwImgCache);
                IMessageBase imageBovwMessage = CheckPorn(msBovwImage);
                if (imageBovwMessage == null) imageBovwMessage = await session.UploadPictureAsync(UploadTarget.Group, msBovwImage);
                await session.SendGroupMessageAsync(sender.Group.Id, new[] { new PlainMessage(stringBuilderBovw.ToString()), imageBovwMessage }, quoteMessage.Id);
                #endregion -- 特征搜索 --
            }

            IMessageBase CheckPorn(MemoryStream ms)
            {
                IMessageBase imageMessage = null;
                if (BotInfo.SearchCheckPornEnabled)
                {
                    try
                    {
                        bool bHealth = TencentCloudHelper.CheckImageHealth(ms.ToArray());
                        if (!bHealth)
                        {
                            imageMessage = new PlainMessage(BotInfo.SearchCheckPornIllegalReply);
                        }
                    }
                    catch (Exception ex)
                    {
                        imageMessage = new PlainMessage(BotInfo.SearchCheckPornErrorReply.Replace("<错误信息>", ex.Message));
                    }
                }
                return imageMessage;
            }
        }



        public static async Task SuccessiveSearchPicture(MiraiHttpSession session, ImageMessage imgMsg, IGroupMemberInfo sender, QuoteMessage quoteMessage)
        {
            Cache.SearchingPictures[sender.Id] = DateTime.Now.AddMinutes(1);
            await SearchPicture(session, imgMsg, sender, quoteMessage);
        }
    }
}
