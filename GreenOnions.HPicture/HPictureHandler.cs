using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Microsoft.Win32.SafeHandles;
using Mirai.CSharp.Models.ChatMessages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenOnions.HPicture
{
    public static class HPictureHandler
    {
        public static void SendHPictures(string message, PictureSource pictureSource, bool isAllowR18, string PictureEndCmd, Func<Stream, Task<IImageMessage>> UploadPicture, Action<IChatMessage[], bool> SendMessage, Action<LimitType> Record)
        {
            try
            {
                string strHttpRequest;
                if (BotInfo.HPictureUserCmd.Contains(message))
                {
                    strHttpRequest = $@"https://api.lolicon.app/setu/?{ (BotInfo.HPictureSize1200 ? "size1200=true" : "") }";
                    SendLoliconHPhicture(strHttpRequest);
                }
                else
                {
                    //分割请求接口所需的参数
                    long lImgCount = 1;
                    string size1200 = "";
                    string strR18 = "0";

                    #region -- R18 --
                    Regex rxR18 = new Regex(BotInfo.HPictureR18Cmd);
                    foreach (Match mchR18 in rxR18.Matches(message))
                    {
                        strR18 = "1";
                        message = message.Replace(mchR18.Value, "");  //无论是否允许R18都现将命令中的R18移除, 避免和数量混淆
                    }
                    if (!isAllowR18)
                        strR18 = "0";//如果不允许R18
                    #endregion -- R18 --

                    #region -- 色图数量 -- 
                    string strCount = StringHelper.GetRegex(message, BotInfo.HPictureBeginCmd, BotInfo.HPictureCountCmd, BotInfo.HPictureUnitCmd);

                    if (!long.TryParse(strCount, out lImgCount) && !string.IsNullOrEmpty(strCount)) lImgCount = StringHelper.Chinese2Num(strCount);

                    if (string.IsNullOrEmpty(strCount)) lImgCount = 1;

                    if (lImgCount <= 0)   //犯贱呢要0张或以下色图
                        return;

                    if (lImgCount > 10) lImgCount = 10;

                    #endregion -- 色图数量 -- 

                    #region -- 关键词 --
                    string strKeyword = StringHelper.GetRegex(message, BotInfo.HPictureUnitCmd, BotInfo.HPictureKeywordCmd, PictureEndCmd);


                    #endregion -- 关键词 --

                    if (BotInfo.HPictureSize1200)
                        size1200 = "&size1200=true";

                    if (pictureSource == PictureSource.Lolicon)
                    {
                        string keyword = "";
                        if (!string.IsNullOrWhiteSpace(strKeyword))
                        {
                            if (strKeyword.EndsWith("的"))
                                strKeyword = strKeyword.Substring(0, strKeyword.Length - 1);
                            keyword = "&keyword=" + strKeyword;
                        }

                        strHttpRequest = $@"https://api.lolicon.app/setu/?apikey={BotInfo.HPictureApiKey}&num={lImgCount}&r18={strR18}{keyword}{size1200}";
                        SendLoliconHPhicture(strHttpRequest);
                    }
                    else if (pictureSource == PictureSource.ELF)
                    {
                        strHttpRequest = string.IsNullOrEmpty(strKeyword) ? $@"http://img.shab.fun:5000/api/img/{lImgCount},{strR18}" : $@"http://img.shab.fun:5000/api/tag/{strKeyword},{lImgCount},{strR18}";
                        SendShabHPicture(strHttpRequest);
                    }
                    else if (pictureSource == PictureSource.GreenOnions)
                    {

                    }
                }

                async void SendLoliconHPhicture(string strHttpRequestUrl)
                {
                    string resultValue = "";
                    try
                    {
                        resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);
                    }
                    catch (Exception ex)
                    {
                        SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, false);
                        return;
                    }

                    JObject jo = (JObject)JsonConvert.DeserializeObject(resultValue);
                    JToken jt = jo["data"];

                    if (jo["code"].ToString() == "404")//没找到对应词条的色图;
                    {
                        SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureNoResultReply) }, false);
                        return;
                    }

                    IEnumerable<LoliconHPictureItem> enumImg = jt.Select(i => new LoliconHPictureItem(i["p"].ToString(), i["pid"].ToString(), i["url"].ToString(), @$"https://www.pixiv.net/artworks/{i["pid"]}(p{i["p"]}"));

                    if (enumImg == null)
                    {
                        SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply) }, false);
                        return;
                    }

                    string addresses = string.Join("\r\n", enumImg.Select(i => @"https://www.pixiv.net/artworks/" + i.ID + $" (p{i.P})"));
                    SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(addresses) }, false);
                    Record(LimitType.Frequency);

                    foreach (LoliconHPictureItem imgItem in enumImg)
                    {
                        SendOnceHPicture(() => SendOnceLoliconHPicture(imgItem));
                    }
                }

                async void SendShabHPicture(string strHttpRequestUrl)
                {
                    string resultValue = "";
                    try
                    {
                        resultValue = await HttpHelper.GetHttpResponseStringAsync(strHttpRequestUrl);
                    }
                    catch (Exception ex)
                    {
                        SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, false);
                        return;
                    }

                    JArray ja = (JArray)JsonConvert.DeserializeObject(resultValue);
                    if (ja.Count == 0)
                    {
                        SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureNoResultReply) }, false);
                        return;
                    }
                    IEnumerable<ELFHPictureItem> enumImg = ja.Select(i => new ELFHPictureItem(i["id"].ToString(), i["link"].ToString(), i["source"].ToString(), string.Join(",", i["jp_tag"].Select(s => s.ToString())), string.Join(",", i["zh_tags"].Select(s => s.ToString())), i["author"].ToString()));
                    string addresses = string.Join("\r\n", enumImg.Select(l => l.Source));
                    SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(addresses) }, false);
                    //包含twimg.com的图墙内无法访问, 暂时不处理
                    SendOnceHPicture(() => SendOnceShabHPicture(enumImg));
                }

                void SendOnceHPicture(Action SendHPictureInner)
                {
                    if (BotInfo.HPictureMultithreading)
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                SendHPictureInner();
                            }
                            catch (Exception ex)
                            {
                                ErrorHelper.WriteErrorLog(ex);
                                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, false);
                            }
                        });
                    }
                    else
                    {
                        try
                        {
                            SendHPictureInner();
                        }
                        catch (Exception ex)
                        {
                            SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, false);
                        }
                    }
                }

                async void SendOnceLoliconHPicture(LoliconHPictureItem item)
                {
                    IImageMessage imageMessage = null;
                    string imgName = Path.Combine(ImageHelper.ImagePath, $"{item.ID}_{item.P}{(BotInfo.HPictureSize1200 ? "_1200" : "")}.png");
                    if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) //存在本地缓存时优先使用缓存
                    {
                        imageMessage = await UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read));  //上传图片
                    }
                    else
                    {
                        MemoryStream ms = HttpHelper.DownloadImageAsMemoryStream(item.URL, imgName);

                        if (ms == null)
                        {
                            if (BotInfo.HPictureAntiShielding)
                            {
                                ms = ms.StreamAntiShielding();
                            }
                            ms = new MemoryStream(ms.ToArray());  //不重新new一次的话上传的时候解码会为空

                            SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureDownloadFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("URL", item.Address))) }, false);
                            return;
                        }
                        imageMessage = await UploadPicture(ms);  //上传图片
                    }
                    SendMessage(new[] { imageMessage }, true);
                    Record(LimitType.Count);  //记录冷却时间
                }

                async void SendOnceShabHPicture(IEnumerable<ELFHPictureItem> items)
                {
                    foreach (var item in items)
                    {
                        IImageMessage imageMessage = null;
                        string imgName = Path.Combine(ImageHelper.ImagePath,$"Shab_{item.ID}.png");
                        if (File.Exists(imgName) && new FileInfo(imgName).Length > 0) //存在本地缓存时优先使用缓存
                        {
                            imageMessage = await UploadPicture(new FileStream(imgName, FileMode.Open, FileAccess.Read, FileShare.Read));  //上传图片
                        }
                        else
                        {
                            MemoryStream ms = HttpHelper.DownloadImageAsMemoryStream(item.Link, imgName);

                            if (BotInfo.HPictureAntiShielding)
                            {
                                ms = ms.StreamAntiShielding();
                            }

                            if (ms == null)
                            {
                                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureDownloadFailReply.ReplaceGreenOnionsTags(new KeyValuePair<string, string>("URL", item.Link))) }, false);
                                return;
                            }
                            imageMessage = await UploadPicture(ms);  //上传图片
                        }

                        SendMessage(new IChatMessage[] { imageMessage, new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage($"地址:{item.Source}\r\n日文标签:{item.Jp_Tag}\r\n中文标签:{item.Zh_Tags}\r\n作者:{item.Author}") }, true);
                        Record(LimitType.Count);  //记录冷却时间
                    }
                }
            }
            catch (Exception ex)
            {
                SendMessage(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.HPictureErrorReply + ex.Message) }, false);
            }
        }
    }
}
