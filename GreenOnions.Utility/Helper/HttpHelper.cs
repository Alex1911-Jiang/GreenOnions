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

        public async static Task<(string document, string jumpUrl)> GetHttpResponseStringAndJumpUrlAsync(string url)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            if (!string.IsNullOrWhiteSpace(BotInfo.Config.ProxyUrl))
            {
                httpClientHandler.UseProxy = true;
                httpClientHandler.Proxy = new WebProxy(BotInfo.Config.ProxyUrl);
            }
            using (HttpClient client = new(httpClientHandler))
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    request.Content.Headers.TryAddWithoutValidation("ContentType", "text/html;charset=UTF-8");
                    request.Content.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                    request.Content.Headers.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0");
                    var resp = await client.SendAsync(request);
                    return  (await resp.Content.ReadAsStringAsync(), request.RequestUri.ToString());
                }
            }
        }

        public static async Task<string> GetHttpResponseStringAsync(string url)
        {
            try
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                if (!string.IsNullOrWhiteSpace(BotInfo.Config.ProxyUrl))
                {
                    httpClientHandler.UseProxy = true;
                    httpClientHandler.Proxy = new WebProxy(BotInfo.Config.ProxyUrl);
                }
                using (HttpClient client = new (httpClientHandler))
                {
                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        request.Content.Headers.TryAddWithoutValidation("ContentType", "text/html;charset=UTF-8");
                        request.Content.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                        request.Content.Headers.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0");
                        var resp = await client.SendAsync(request);
                        return await resp.Content.ReadAsStringAsync();
                    }
                }
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
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            if (!string.IsNullOrWhiteSpace(BotInfo.Config.ProxyUrl))
            {
                httpClientHandler.UseProxy = true;
                httpClientHandler.Proxy = new WebProxy(BotInfo.Config.ProxyUrl);
            }
            using (HttpClient httpClient = new HttpClient(httpClientHandler))
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
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            if (!string.IsNullOrWhiteSpace(BotInfo.Config.ProxyUrl))
            {
                httpClientHandler.UseProxy = true;
                httpClientHandler.Proxy = new WebProxy(BotInfo.Config.ProxyUrl);
            }
            using (HttpClient client = new HttpClient(httpClientHandler))
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
