using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using GreenOnions.Interface;
using GreenOnions.Translate;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.RSS
{
    internal class RssResult
    {
        internal string Url { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        internal string Title { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        internal string InnerTitle { get; set; }
        /// <summary>
        /// 原始排版完整正文
        /// </summary>
        internal GreenOnionsMessages Body { get; set; } = new GreenOnionsMessages();
        /// <summary>
        /// 正文文字部分
        /// </summary>
        internal string Text { get; set; }

        private List<GreenOnionsBaseMessage>? _images = null;
        /// <summary>
        /// 正文图片部分
        /// </summary>
        internal async Task<List<GreenOnionsBaseMessage>?> Images()
        {
            if (_images is null && ImageUrls.Count > 0)
                _images = await RssDownloadImagesAsync();
            return _images;
        }

        /// <summary>
        /// 正文图片地址
        /// </summary>
        internal List<string> ImageUrls { get; set; } = new List<string>();
        /// <summary>
        /// 正文视频地址
        /// </summary>
        internal List<string> VideoUrls { get; set; } = new List<string>();
        /// <summary>
        /// 正文其他地址
        /// </summary>
        internal List<string> IFrameUrls { get; set; } = new List<string>();

        private string? _translatedText = null;

        /// <summary>
        /// 正文文本翻译
        /// </summary>
        internal async Task<string> TranslatedText(string text, bool fromTo, string? from, string? to)
        {
            if (string.IsNullOrEmpty(_translatedText))
            {
                string translatedText;
                if (fromTo)
                    translatedText = await TranslateHandler.TranslateFromTo(text, from!, to!);
                else
                    translatedText = await TranslateHandler.TranslateToChinese(text);
                _translatedText = translatedText;
            }
            return _translatedText;
        }
        /// <summary>
        /// 作者名
        /// </summary>
        internal string Author { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        internal DateTime PubDate { get; set; }
        /// <summary>
        /// 原文地址
        /// </summary>
        internal string Link { get; set; }
        /// <summary>
        /// 附带媒体内容
        /// </summary>
        internal GreenOnionsBaseMessage? Media { get; set; }

        /// <summary>
        /// 获取B站封面
        /// </summary>
        /// <returns></returns>
        internal async Task<GreenOnionsImageMessage?> BilibiliLiveCover()
        {
            if (Url.Contains("bilibili") && Url.Contains("/room/"))
            {
                string roomId = Url[(Url.LastIndexOf("/room/") + "/room/".Length)..];
                string apiResult = await HttpHelper.GetStringAsync($@"https://api.live.bilibili.com/xlive/web-room/v1/index/getInfoByRoom?room_id={roomId}", false);
                JObject jo = JsonConvert.DeserializeObject<JObject>(apiResult);
                string? imgUrl = jo?["data"]?["room_info"]?["cover"]?.ToString();
                if (imgUrl is null)
                    return null;
                return await ImageHelper.CreateImageMessageByUrlAsync(imgUrl, false, false);
            }
            return null;
        }

        internal static async Task<GreenOnionsBaseMessage> RssDownloadImageAsync(string imgUrl)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(BotInfo.Config.RssTwimgProxyUrl) && imgUrl.StartsWith("https://pbs.twimg.com/"))
                {
                    try
                    {
                        string urlParam = HttpUtility.UrlEncode(imgUrl);
                        Stream imgStream = await HttpHelper.GetStreamAsync($"{BotInfo.Config.RssTwimgProxyUrl}{urlParam}", false);
                        return new GreenOnionsImageMessage(imgStream);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLog("使用推特代理下载图片错误。", ex);
                        return await ImageHelper.CreateImageMessageByUrlAsync(imgUrl, BotInfo.Config.RssUseProxy, false);
                    }
                }
                else
                {
                    return await ImageHelper.CreateImageMessageByUrlAsync(imgUrl, BotInfo.Config.RssUseProxy, false);
                }
            }
            catch
            {
                return $"图片下载失败：{imgUrl}";
            }
        }

        private async Task<List<GreenOnionsBaseMessage>> RssDownloadImagesAsync()
        {
            List<GreenOnionsBaseMessage> imgMsgs = new List<GreenOnionsBaseMessage>();
            for (int i = 0; i < ImageUrls.Count; i++)
                imgMsgs.Add(await RssDownloadImageAsync(ImageUrls[i]));
            return imgMsgs;
        }
    }
}
