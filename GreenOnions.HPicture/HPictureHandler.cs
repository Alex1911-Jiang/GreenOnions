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
    public static class HPictureHandler
    {
        public static void SendHPictures(MiraiHttpSession session, string message, bool isAllowR18, Func<Stream,Task<ImageMessage>> UploadPicture, Func<IMessageBase[],Task<int>> SendMessage, Action<LimitType> Record, int RevokeSecond)
        {
            try
            {
                string strHttpRequest;
                if (BotInfo.HPictureUserCmd.Contains(message))
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
                    foreach (Match mchR18 in rxR18.Matches(message))
                    {
                        strR18 = "1";
                        message = message.Replace(mchR18.Value, "");  //无论是否允许R18都现将命令中的R18移除, 避免和数量混淆
                    }
                    if (!isAllowR18) strR18 = "0";//如果不允许R18
                    #endregion -- R18 --

                    #region -- 色图数量 -- ;
                    string strCount = StringHelper.GetRegex(message, BotInfo.HPictureBeginCmd, BotInfo.HPictureCountCmd, BotInfo.HPictureUnitCmd);

                    if (!long.TryParse(strCount, out lImgCount) && !string.IsNullOrEmpty(strCount)) lImgCount = StringHelper.Chinese2Num(strCount);

                    if (string.IsNullOrEmpty(strCount)) lImgCount = 1;

                    if (lImgCount <= 0) return;  //犯贱呢要0张或以下色图

                    if (lImgCount > 10) lImgCount = 10;

                    #endregion -- 色图数量 -- 

                    #region -- 关键词 --
                    string strKeyword = StringHelper.GetRegex(message, BotInfo.HPictureUnitCmd, BotInfo.HPictureKeywordCmd, BotInfo.HPictureEndCmd);

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

                string resultValue = "";
                try
                {
                    resultValue = HttpHelper.GetHttpResponseStringAsync(strHttpRequest, out _).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    SendMessage(new[] { new PlainMessage(BotInfo.HPictureErrorReply + ex.Message) });
                    return;
                }

                JObject jo = (JObject)JsonConvert.DeserializeObject(resultValue);
                JToken jt = jo["data"];

                if (jo["code"].ToString() == "1")//没找到对应词条的色图;
                {
                    SendMessage(new[] {new PlainMessage(BotInfo.SearchNoResultReply) });
                    return;
                }

                IEnumerable<HPictureItem> enumImg = jt.Select(i => new HPictureItem(i["p"].ToString(), i["pid"].ToString(), i["url"].ToString()));

                if (enumImg == null)
                {
                    SendMessage(new[] { new PlainMessage(BotInfo.HPictureErrorReply)});
                    return;
                }

                Dictionary<string, string> dicAddress = new Dictionary<string, string>();
                StringBuilder sbAddress = new StringBuilder();
                foreach (var item in enumImg)
                {
                    string strAddress = @"https://www.pixiv.net/artworks/" + item.ID + $" (p{item.P})";
                    dicAddress.Add(item.ID, strAddress);
                    sbAddress.AppendLine(strAddress);
                }

                if (string.IsNullOrEmpty(sbAddress.ToString()))  //一般不会出现这个情况
                {
                    SendMessage(new[] { new PlainMessage(BotInfo.HPictureErrorReply)});
                    return;
                }

                SendMessage(new[] { new PlainMessage(sbAddress.ToString()) }).GetAwaiter().GetResult();
                Record(LimitType.Frequency);

                string imagePath = Environment.CurrentDirectory + "\\Image\\";
                if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);

                foreach (var pair in enumImg)
                {
                    if (BotInfo.HPictureMultithreading)
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                SendOnceHPicture(pair);
                            }
                            catch (Exception ex)
                            {
                                //TODO:记录错误信息
                                SendMessage(new[] { new PlainMessage(BotInfo.HPictureErrorReply + ex.Message) });
                            }
                        });
                    }
                    else
                    {
                        try
                        {
                            SendOnceHPicture(pair);
                        }
                        catch (Exception ex)
                        {
                            SendMessage(new[] { new PlainMessage(BotInfo.HPictureErrorReply + ex.Message)});
                        }
                    }
                }

                void SendOnceHPicture(HPictureItem pair)
                {
                    ImageMessage imageMessage = null;
                    string imgName = $"{imagePath}{pair.ID}_{pair.P}{(BotInfo.HPictureSize1200 ? "_1200" : "")}.png";
                    if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) //存在本地缓存时优先使用缓存
                    {
                        imageMessage = UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read)).GetAwaiter().GetResult();  //上传图片
                    }
                    else
                    {
                        Stream ms = HttpHelper.DownloadImageAsMemoryStream(pair.URL, imgName);
                        if (ms == null)
                        {
                            SendMessage(new[] { new PlainMessage(BotInfo.HPictureDownloadFailReply.Replace("<URL>", dicAddress[pair.URL]))});
                            return;
                        }
                        imageMessage = UploadPicture(ms).GetAwaiter().GetResult();  //上传图片
                    }

                    int messageID = SendMessage(new[] {imageMessage }).GetAwaiter().GetResult();
                    Record(LimitType.Count);
                    RevokeHPicture(session, messageID, RevokeSecond);
                }

                void RevokeHPicture(MiraiHttpSession message, int messageId, int delay)
                {
                    if (delay > 0)
                    {
                        Task.Delay(delay * 1000).Wait();
                        message.RevokeMessageAsync(messageId);
                    }
                }
            }
            catch (Exception ex)
            {
                SendMessage(new[] { new PlainMessage(BotInfo.HPictureErrorReply + ex.Message) });
            }
        }
    }
}
