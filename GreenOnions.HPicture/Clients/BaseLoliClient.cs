using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenOnions.HPicture.Items;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.HPicture.Clients
{
    internal abstract class BaseLoliClient
    {
        protected abstract string ApiName { get;}
        protected abstract string ApiUrl{ get;}

        /// <summary>
        /// 请求Api图库获取单张图片并反序列化成结构
        /// </summary>
        /// <returns>解析后的单个Api结果</returns>
        internal virtual async Task<LoliHPictureItem> GetOnceLoliItem()
        {
            await foreach (var item in GetLoliItems(string.Empty, 1, false))
                return item;
            throw new Exception(BotInfo.Config.HPictureNoResultReply);  //没有结果
        }

        /// <summary>
        /// 请求Api图库获取一组图片并反序列化成结构
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="imgCount">请求图片数量</param>
        /// <param name="r18">是否R18</param>
        /// <returns>解析后的Api结果</returns>
        internal virtual async IAsyncEnumerable<LoliHPictureItem> GetLoliItems(string keyword, int imgCount, bool r18)
        {
            string keywordParam = KeyworkToParams(keyword);
            string numParam = $"num={imgCount}";
            string r18Param = $"r18={(r18 ? 1 : 0)}";
            List<string> requestParams = new(2) { numParam, r18Param };
            if (!string.IsNullOrEmpty(keywordParam))
                requestParams.Add(keywordParam);
            string paramUrl = string.Join('&', requestParams);

            string strUrl = $@"{ApiUrl}?{paramUrl}";

            JToken jt = await RequestLoli(strUrl);
            IEnumerable<LoliHPictureItem> loliItems = JTokenToItem(jt);

            if (loliItems is null)
            {
                LogHelper.WriteWarningLog($"{ApiName} 响应解析失败");
                throw new Exception(BotInfo.Config.HPictureErrorReply);
            }

            foreach (LoliHPictureItem loliItem in loliItems)
            {
                yield return loliItem;
            }
        }

        protected virtual IEnumerable<LoliHPictureItem> JTokenToItem(JToken jt)
        {
            string err = jt["error"].ToString();
            if (!string.IsNullOrWhiteSpace(err))
            {
                LogHelper.WriteErrorLog($"{ApiName} 服务器返回了错误消息", new Exception(err));
                throw new Exception(BotInfo.Config.HPictureErrorReply + err);    //Api返回错误
            }

            JToken data = jt["data"];
            if (!data.Any())//没找到对应词条的色图;
            {
                LogHelper.WriteInfoLog($"{ApiName} 服务器返回了空数组");
                throw new Exception(BotInfo.Config.HPictureNoResultReply);  //没有结果
            }

            return data.Select(item =>
            {
                string strPid = item["pid"].ToString();
                string strP = item["p"].ToString();
                string url = item["urls"]["original"].ToString();

                int numP = Convert.ToInt32(strP);
                string strIndex = numP > 0 ? $"-{numP + 1}" : string.Empty;
                string ext = url.Substring(url.LastIndexOf('.'));
                url = $"https://{BotInfo.Config.PixivProxy}/{strPid}{strIndex}{ext}";  //似乎使用id路由比日期路由速度快不少？？

                return new LoliHPictureItem(
                    strP,
                    strPid,
                    url,
                    item["title"].ToString(),
                    item["author"].ToString(),
                    string.Join(",", (item["tags"] as JArray)!),
                    @$"https://www.pixiv.net/artworks/{strPid}(p{strP})");
            });
        }

        protected virtual string KeyworkToParams(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return string.Empty;

            if (keyword.Contains('&') || keyword.Contains('|'))
            {
                string[] ands = keyword.Split('&');
                return "tag=" + string.Join("&tag=", ands);
            }
            else
                return "&tag=" + keyword;
        }

        protected virtual async Task<JToken> RequestLoli(string strUrl)
        {
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(strUrl, BotInfo.Config.HPictureUseProxy));
        }
    }
}
