using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GreenOnions.Utility.Helper
{
    public static class HttpHelper
    {
        public static HttpClient CreateClient(bool useProxy)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            if (!string.IsNullOrWhiteSpace(BotInfo.Config.ProxyUrl))
            {
                httpClientHandler.UseProxy = useProxy;
                httpClientHandler.Proxy = new WebProxy(BotInfo.Config.ProxyUrl);
            }
            return new HttpClient(httpClientHandler) { Timeout = Timeout.InfiniteTimeSpan };
        }

        public async static Task<(string document, string redirectUrl)> GetHttpResponseStringAndRedirectUrlAsync(HttpClient client, string url)
        {
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Content.Headers.TryAddWithoutValidation("ContentType", "text/html;charset=UTF-8");
            request.Content.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.Content.Headers.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0");
            var resp = await client.SendAsync(request);
            return (await resp.Content.ReadAsStringAsync(), request.RequestUri.ToString());
        }

        public static async Task<string> GetStringAsync(string url, bool useProxy)
        {
            using HttpClient client = CreateClient(useProxy);
            return await client.GetStringAsync(url);
        }

        public static async Task<Stream> GetStreamAsync(string url, bool useProxy)
        {
            using HttpClient client = CreateClient(useProxy);
            var resp = await client.GetAsync(url);
            return resp.Content.ReadAsStream();
        }

        public static async Task<string> GetStringAsync(HttpClient client, string url)
        {
            return await client.GetStringAsync(url);
        }

        public static async Task<Stream> GetStreamAsync(HttpClient client, string url)
        {
            var resp = await client.GetAsync(url);
            return resp.Content.ReadAsStream();
        }
    }
}
