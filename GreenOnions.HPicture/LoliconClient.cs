using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GreenOnions.HPicture.Items;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.HPicture
{
    public static class LoliconClient
    {
        /// <summary>
        /// 请求Lolicon图库获取单张图片并反序列化成结构
        /// </summary>
        /// <returns>解析后的单个Lolicon结果</returns>
        public static async Task<LoliconHPictureItem> GetOnceLoliconItem()
        {
            await foreach (var item in GetLoliconItems(string.Empty, 1, false))
                return item;
            throw new Exception(BotInfo.Config.HPictureNoResultReply);  //没有结果
        }

        /// <summary>
        /// 请求Lolicon图库获取一组图片并反序列化成结构
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="imgCount">请求图片数量</param>
        /// <param name="r18">是否R18</param>
        /// <returns>解析后的Lolicon结果</returns>
        public static async IAsyncEnumerable<LoliconHPictureItem> GetLoliconItems(string keyword, int imgCount, bool r18)
        {
            string sizeName = BotInfo.Config.HPictureSize1200 ? "regular" : "original";

            string keywordParam = KeyworkToParams(keyword);
            string numParam = $"num={imgCount}";
            string sizeParam = $"size={sizeName}";
            string proxyParam = $"proxy=i.{BotInfo.Config.PixivProxy}";
            string r18Param = $"r18={(r18 ? 1 : 0)}";
            List<string> requestParams = new(5) { numParam, sizeParam, proxyParam, r18Param };
            if (!string.IsNullOrEmpty(keywordParam))
                requestParams.Add(keywordParam);
            string paramUrl = string.Join('&', requestParams);

            string strUrl = $@"https://api.lolicon.app/setu/v2?{paramUrl}";

            JToken jt = await RequestLolicon(strUrl);

            IEnumerable<LoliconHPictureItem> loliconItems = jt.Select(item =>
            {
                string strPid = item["pid"].ToString();
                string strP = item["p"].ToString();
                string url = item["urls"][sizeName].ToString();
                if (!BotInfo.Config.HPictureSize1200)
                {
                    int numP = Convert.ToInt32(strP);
                    string strIndex = numP > 0 ? $"-{numP + 1}" : string.Empty;
                    string ext = url.Substring(url.LastIndexOf('.'));
                    url = $"https://{BotInfo.Config.PixivProxy}/{strPid}{strIndex}{ext}";  //似乎使用id路由比日期路由速度快不少？？
                }
                return new LoliconHPictureItem(
                    strP,
                    strPid,
                    url,
                    item["title"].ToString(),
                    item["author"].ToString(),
                    string.Join(",", (item["tags"] as JArray)!),
                    @$"https://www.pixiv.net/artworks/{strPid}(p{strP})");
            });

            if (loliconItems is null)
            {
                LogHelper.WriteErrorLog("Lolicon 响应解析失败");
                throw new Exception(BotInfo.Config.HPictureErrorReply);
            }

            foreach (LoliconHPictureItem loliconItem in loliconItems)
            {
                yield return loliconItem;
            }
        }

        private static string KeyworkToParams(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return string.Empty;

            if (keyword.Contains('&') || keyword.Contains('|'))
            {
                string[] ands = keyword.Split('&');
                return "tag=" + string.Join("&tag=", ands);
            }
            else
                return "keyword=" + keyword;
        }

        private static async Task<JToken> RequestLolicon(string strUrl)
        {
            string resultValue;
            if (EventHelper.GetDocumentByBrowserEvent is not null && BotInfo.Config.HttpRequestByWebBrowser && BotInfo.Config.HPictureLoliconRequestByWebBrowser)
            {
                string doc = EventHelper.GetDocumentByBrowserEvent(strUrl).document;
                resultValue = doc[doc.IndexOf("{")..(doc.LastIndexOf("}") + 1)];
            }
            else
                resultValue = await HttpHelper.GetStringAsync(strUrl, BotInfo.Config.HPictureUseProxy);

            JObject jo = JsonConvert.DeserializeObject<JObject>(resultValue);
            string err = jo["error"].ToString();
            if (!string.IsNullOrWhiteSpace(err))
            {
                LogHelper.WriteErrorLog($"Lolicon 服务器返回了错误消息：{err}");
                throw new Exception(BotInfo.Config.HPictureErrorReply + err);    //Api返回错误
            }

            JToken jt = jo["data"];
            if (!jt.Any())//没找到对应词条的色图;
            {
                LogHelper.WriteInfoLog($"Lolicon 服务器返回了空数组");
                throw new Exception(BotInfo.Config.HPictureNoResultReply);  //没有结果
            }
            return jt;
        }
    }
}
