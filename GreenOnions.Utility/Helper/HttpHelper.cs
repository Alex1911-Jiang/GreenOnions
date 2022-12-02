using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace GreenOnions.Utility.Helper
{
    public static class HttpHelper
    {
        #region -- Https请求 --

        static HttpHelper()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
        }

        public async static Task<(string document, string jumpUrl)> GetHttpResponseStringAndJumpUrlAsync(string url, IDictionary<string, string> headers = null)
        {
            Stream stream = GetHttpResponseStream(url, out string jumpUrl, headers);
            using (StreamReader streamReader = new StreamReader(stream))
                return (await streamReader.ReadToEndAsync(), jumpUrl);
        }

        public static async Task<string> GetHttpResponseStringAsync(string url, IDictionary<string, string> headers = null)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (headers is not null)
                    {
                        foreach (var header in headers)
                            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    return await httpClient.GetStringAsync(url);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                throw;
            }
        }

        /// <summary>
        /// get方法
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="headers">头部信息的键值对</param>
        /// <param name="timeout">超时时间，默认为60000毫秒（1分钟）</param>
        /// <returns></returns>
        public static Stream GetHttpResponseStream(string url, out string jumpUrl, IDictionary<string, string> headers = null, int timeout = 60000)
        {
            try
            {
                ServicePointManager.DefaultConnectionLimit = 50;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.KeepAlive = false;
                request.ContentType = "text/html;charset=UTF-8";
                request.Timeout = timeout;
                request.Method = "GET";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
                request.UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0";

                //request.ContentType = "application/x-www-form-urlencoded";

                //往头部加入自定义验证信息 Authorization
                if (headers is not null)
                {
                    var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (property is not null)
                    {
                        //往头部加信息
                        foreach (KeyValuePair<string, string> header in headers)
                        {
                            if (property.GetValue(header, null) is NameValueCollection collection)
                                collection[header.Key] = header.Value;
                        }
                    }
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                jumpUrl = response.ResponseUri.ToString();
                return response.GetResponseStream();
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                throw;
            }
        }

        #endregion -- Https请求 --

        public static async Task<MemoryStream> DownloadImageAsMemoryStreamAsync(string url)
        {
            bool retry = true;
        IL_Retry:;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var t = await httpClient.GetAsync(url);
                    byte[] bytes = await t.Content.ReadAsByteArrayAsync();
                    MemoryStream ms = new MemoryStream(bytes);
                    if (ms.Length == 0)
                    {
                        if (retry)
                        {
                            retry = false;
                            goto IL_Retry;
                        }
                        else
                        {
                            ms.Dispose();
                            ms = null;
                        }
                    }
                    return ms;
                }
                catch (Exception)
                {
                    if (retry)
                    {
                        retry = false;
                        goto IL_Retry;
                    }
                    return null;
                }
            }
        }

        public static async Task DownloadImageFileAsync(string url, string fileName)
        {
            using (HttpClient client = new HttpClient())
            {
                byte[] file = await client.GetByteArrayAsync(url);
                string cacheDir = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(cacheDir) && !Directory.Exists(cacheDir))
                    Directory.CreateDirectory(cacheDir);
                await File.WriteAllBytesAsync(fileName, file);
            }
        }
    }
}
