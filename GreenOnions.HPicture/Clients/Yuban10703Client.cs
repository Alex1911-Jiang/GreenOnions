using System;
using System.Collections.Generic;
using System.Linq;
using GreenOnions.HPicture.Items;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json.Linq;

namespace GreenOnions.HPicture.Clients
{
    internal class Yuban10703Client : BaseLoliClient
    {
        protected override string ApiName => "Yuban10703";
        protected override string ApiUrl => "https://setu.yuban10703.xyz/setu";

        protected override IEnumerable<LoliHPictureItem> JTokenToItem(JToken jt)
        {
            string err = jt["detail"].ToString();
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
                string strPid = item["artwork"]["id"].ToString();
                string strP = item["page"].ToString();
                string url = item["urls"]["original"].ToString();

                int numP = Convert.ToInt32(strP);
                string strIndex = numP > 0 ? $"-{numP + 1}" : string.Empty;
                string ext = url.Substring(url.LastIndexOf('.'));
                url = $"https://{BotInfo.Config.PixivProxy}/{strPid}{strIndex}{ext}";

                return new LoliHPictureItem(
                    strP,
                    strPid,
                    url,
                    item["artwork"]["title"].ToString(),
                    item["author"]["name"].ToString(),
                    string.Join(",", (item["tags"] as JArray)!),
                    @$"https://www.pixiv.net/artworks/{strPid}(p{strP})");
            });
        }
    }
}
