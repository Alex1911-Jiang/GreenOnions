using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.Utility.Helper
{
    public static class HttpHelper
    {
        #region -- Https请求 --
        public static string GetHttpResponseString(string url, out string jumpUrl, Dictionary<string, string> headers = null, int timeout = 60000)
        {
            using (Stream stream = GetHttpResponseStream(url, out jumpUrl, headers, timeout))
            {
                using (StreamReader streamReader = new StreamReader(stream)) // Encoding.GetEncoding("utf-8")
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public static Task<string> GetHttpResponseStringAsync(string url, out string jumpUrl, Dictionary<string, string> headers = null, int timeout = 60000)
        {
            Stream stream = GetHttpResponseStream(url, out jumpUrl, headers, timeout);
            return GetStreamToStringAsync(stream);
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

        /// <summary>
        /// post方法
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postString">post数据的字符串</param>
        /// <param name="headers">头部信息的键值对</param>
        /// <param name="timeout">超时时间，默认为60000毫秒（1分钟）</param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, IDictionary<string, string> parameters, IDictionary<string, string> headers = null, int timeout = 60000)
        {
            //HTTPSQ请求
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Timeout = timeout;

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
        public static string PostHttpResponse(string url, object PostData, IDictionary<string, string> headers = null, int timeout = 60000)
        {
            //HTTPSQ请求
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Timeout = timeout;

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

        private static byte[] DownloadImageData(string url, string cacheImageName)
        {
            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData(url);

            if (BotInfo.ImageCache)
            {
                File.WriteAllBytes(cacheImageName, bytes);
            }

            return bytes;
        }

        private static byte[] DownloadImageFile(string url, string cacheImageName)
        {
            string cacheDir = Path.GetDirectoryName(cacheImageName);
            if (!Directory.Exists(cacheDir))
            {
                Directory.CreateDirectory(cacheDir);
            }
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, cacheImageName);
            byte[] bytes = File.ReadAllBytes(cacheImageName);
            if (!BotInfo.ImageCache)
            {
                File.Delete(cacheImageName);
            }
            return bytes;
        }

        private static async Task<byte[]> DownloadImageDataAsync(string url)
        {
            WebClient webClient = new WebClient();
            byte[] bytes = await webClient.DownloadDataTaskAsync(url);
            return bytes;
        }

        public static MemoryStream DownloadImageAsMemoryStream(string url, string cacheImageName)
        {
            bool retry = true;
            byte[] imageByte;
        ILRetry:;
            try
            {
                if (BotInfo.EnabledAccelerate)
                    imageByte = DownloadImageFile(BotInfo.AccelerateUrl + url, cacheImageName);
                else
                    imageByte = DownloadImageFile(url, cacheImageName);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)  //404
                {
                    retry = false;
                }
                if (retry)  //ex.Status == WebExceptionStatus.Timeout
                {
                    retry = false;
                    goto ILRetry;
                }
                ErrorHelper.WriteErrorLog(ex);
                throw;
            }
            catch (Exception ex)  //下载图片失败
            {
                ErrorHelper.WriteErrorLog(ex);
                throw;
            }
            MemoryStream ms = new MemoryStream(imageByte);
            return ms;
        }
    }
}
