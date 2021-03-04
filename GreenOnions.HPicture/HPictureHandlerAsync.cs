using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.HPicture
{
    [Obsolete("由于未知原因下载流或byte[]有时会出现永久性卡死的情况, 请改为使用HPictureHandler")]
    public static class HPictureHandlerAsync
    {
        [Obsolete("由于未知原因下载流或byte[]有时会出现永久性卡死的情况, 请改为使用HPictureHandler")]
        public static async IAsyncEnumerable<IMessageBase> SendHPictures(this MiraiHttpSession session, string command, bool isAllowR18)
        {
            string strHttpRequest;
            if (BotInfo.HPictureUserCmd != null && BotInfo.HPictureUserCmd.Contains(command))
            {
                strHttpRequest = $@"https://api.lolicon.app/setu/?{ (BotInfo.HPictureSize1200 ? "size1200=true" : "") }";
            }
            else
            {
                //分割请求接口所需的参数
                long lImgCount = 1;
                string keyword = "";
                string size1200 = "";
                string strR18 = "0";

                #region -- R18 --
                Regex rxR18 = new Regex(BotInfo.HPictureR18Cmd);
                foreach (Match mchR18 in rxR18.Matches(command))
                {
                    strR18 = "1";
                    command = command.Replace(mchR18.Value, "");  //无论是否允许R18都现将命令中的R18移除, 避免和数量混淆
                }
                if (!isAllowR18) strR18 = "0";//如果不允许R18
                #endregion -- R18 --

                #region -- 色图数量 -- ;
                string strCount = StringHelper.GetRegex(command, BotInfo.HPictureBeginCmd, BotInfo.HPictureCountCmd, BotInfo.HPictureUnitCmd);

                if (!long.TryParse(strCount, out lImgCount) && !string.IsNullOrEmpty(strCount)) lImgCount = StringHelper.Chinese2Num(strCount);

                if (string.IsNullOrEmpty(strCount)) lImgCount = 1;

                if (lImgCount <= 0) yield break;  //犯贱呢要0张或以下色图

                if (lImgCount > 10) lImgCount = 10;

                #endregion -- 色图数量 -- 

                #region -- 关键词 --
                string strKeyword = StringHelper.GetRegex(command, BotInfo.HPictureUnitCmd, BotInfo.HPictureKeywordCmd, BotInfo.HPictureEndCmd);

                if (!string.IsNullOrWhiteSpace(strKeyword))
                {
                    if (strKeyword.EndsWith("的"))
                    {
                        strKeyword = strKeyword.Substring(0, strKeyword.Length - 1);
                    }
                    keyword = "&keyword=" + strKeyword;
                }
                #endregion -- 关键词 --

                if (BotInfo.HPictureSize1200) size1200 = "&size1200=true";

                strHttpRequest = $@"https://api.lolicon.app/setu/?apikey={BotInfo.HPictureApiKey}&num={lImgCount}&r18={strR18}{keyword}{size1200}";
            }

            string strFail = null;
            string resultValue = "";
            try
            {
                resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequest, out _);
            }
            catch (Exception ex)
            {
                strFail = ex.Message;
            }
            if (!string.IsNullOrEmpty(strFail))
            {
                yield return new PlainMessage(BotInfo.SearchErrorReply + strFail);  //没找到对应词条的色图
            }


            JObject jo = (JObject)JsonConvert.DeserializeObject(resultValue);
            JToken jt = jo["data"];

            if (jo["code"].ToString() == "1")
            {
                yield return new PlainMessage(BotInfo.HPictureNoResultReply);  //没找到对应词条的色图
                yield break;
            }

            IEnumerable<LoliconHPictureItem> enumImg = jt.Select(i => new LoliconHPictureItem(i["p"].ToString(), i["pid"].ToString(), i["url"].ToString(), @$"https://www.pixiv.net/artworks/{i["pid"].ToString()}(p{i["p"].ToString()}"));

            if (enumImg == null) yield break;  //一般不会出现这个情况, 但是防止它报错

            StringBuilder sbAddress = new StringBuilder();
            foreach (var item in enumImg)
            {
                string strAddress = @"https://www.pixiv.net/artworks/" + item.ID + $" (p{item.P})";
                sbAddress.AppendLine(strAddress);
            }

            if (string.IsNullOrEmpty(sbAddress.ToString())) yield break;  //一般不会出现这个情况, 但是防止它报错

            yield return new PlainMessage(sbAddress.ToString());  //第一条地址

            string imagePath = Environment.CurrentDirectory + "\\Image\\";
            if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);

            foreach (var pair in enumImg)
            {
                string imgName = $"{imagePath} {pair.ID}  _{ pair.P }{(BotInfo.HPictureSize1200 ? "_1200" : "")} .png";
                if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) yield return await session.UploadPictureAsync(UploadTarget.Group, imgName);  //存在本地缓存时优先使用缓存

                Stream ms = HttpHelper.DownloadImageAsMemoryStream(pair.URL, imgName);

                if (ms == null) yield return new PlainMessage(BotInfo.HPictureDownloadFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("URL", pair.Address)));

                yield return await session.UploadPictureAsync(UploadTarget.Group, ms);  //上传图片
            }
        }

        public static void RevokeHPicture(this MiraiHttpSession message, int messageId, int delay)
        {
            if (delay > 0)
            {
                Task.Delay(delay * 1000).Wait();
                message.RevokeMessageAsync(messageId);
            }
        }
    }
}
