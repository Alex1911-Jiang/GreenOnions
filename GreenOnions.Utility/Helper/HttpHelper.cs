using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.Utility.Helper
{
    public static class HttpHelper
    {
        #region -- Https请求 --
        public static HttpClient CreateHttpClient(string url, IDictionary<string, string> headers = null)
        {
            HttpClient httpClient = new HttpClient();
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            return httpClient;
        }

        public static string GetHttpResponseString(string url, out string jumpUrl, IDictionary<string, string> headers = null)
        {
            using (Stream stream = GetHttpResponseStream(url, out jumpUrl, headers))
            {
                using (StreamReader streamReader = new StreamReader(stream)) // Encoding.GetEncoding("utf-8")
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public async static Task<(string document, string jumpUrl)> GetHttpResponseStringAndJumpUrlAsync(string url, IDictionary<string, string> headers = null)
        {
            Stream stream = GetHttpResponseStream(url, out string jumpUrl, headers);
            return (await GetStreamToStringAsync(stream), jumpUrl);
        }

        public async static Task<string> GetHttpResponseStringAsync(string url, IDictionary<string, string> headers = null)
        {
            try
            {
                return await CreateHttpClient(url, headers).GetStringAsync(url);
            }
            catch (Exception ex)
            {
                ErrorHelper.WriteErrorLog(ex);
                throw;
            }
        }

        private static Task<string> GetStreamToStringAsync(Stream stream)
        {
            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEndAsync();
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
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        SetHeaderValue(request.Headers, header.Key, header.Value);
                    }
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                jumpUrl = response.ResponseUri.ToString();
                return response.GetResponseStream();
            }
            catch (Exception ex)
            {
                ErrorHelper.WriteErrorLog(ex);
                throw;
            }
        }

        public async static Task<Stream> GetHttpResponseStreamAsync(string url, IDictionary<string, string> headers = null)
        {
            try
            {
                return await CreateHttpClient(url, headers).GetStreamAsync(url);
            }
            catch (Exception ex)
            {
                ErrorHelper.WriteErrorLog(ex);
                throw;
            }
        }

        /// <summary>
        /// post方法
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postString">post数据的字符串</param>
        /// <param name="headers">头部信息的键值对</param>
        /// <param name="timeout">超时时间，默认为60000毫秒（1分钟）</param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, IDictionary<string, string> parameters, IDictionary<string, string> headers = null)
        {
            //HTTPSQ请求
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Timeout = 60000;

            //往头部加入自定义验证信息 Authorization
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    SetHeaderValue(request.Headers, header.Key, header.Value);
                }
            }

            //如果需要POST数据
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = Encoding.GetEncoding("utf-8").GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            var resultStream = (request.GetResponse() as HttpWebResponse);
            string result = "";
            //获取响应内容
            using (StreamReader reader = new StreamReader(resultStream.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// post方法（使用该方法请求Api时，Api中参数前需要加[FromBody]）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="PostData">post数据对象</param>
        /// <param name="headers">头部信息的键值对</param>
        /// <param name="timeout">超时时间，默认为60000毫秒（1分钟）</param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, object PostData, IDictionary<string, string> headers = null)
        {
            //HTTPSQ请求
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Timeout = 60000;

            //往头部加入自定义验证信息 Authorization
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    SetHeaderValue(request.Headers, header.Key, header.Value);
                }
            }

            //如果需要POST数据
            string str = JsonConvert.SerializeObject(PostData);
            byte[] data = Encoding.GetEncoding("utf-8").GetBytes(str);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var resultStream = (request.GetResponse() as HttpWebResponse);
            string result = "";
            //获取响应内容
            using (StreamReader reader = new StreamReader(resultStream.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 往头部加信息
        /// </summary>
        /// <param name="header">头部对象</param>
        /// <param name="name">键</param>
        /// <param name="value">值</param>
        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }
        #endregion -- Https请求 --

        public static async Task<byte[]> DownloadImageAsBytes(string url)
        {
            bool retry = true;
        IL_Retry:;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var t = await httpClient.GetAsync(url);
                    byte[] bytes = await t.Content.ReadAsByteArrayAsync();
                    return bytes;
                }
                catch (Exception ex)
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

        public static async Task<MemoryStream> DownloadImageAsMemoryStream(string url)
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
                catch (Exception ex)
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

        public static void DownloadImageFile(string url, string fileName)
        {
            string cacheDir = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(cacheDir))
                Directory.CreateDirectory(cacheDir);
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(url, fileName);
                webClient.Dispose();
            }
        }
    }
}
