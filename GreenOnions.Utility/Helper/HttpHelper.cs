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
        public static HttpClient CreateClient(bool useProxy = false)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            if (!string.IsNullOrWhiteSpace(BotInfo.Config.ProxyUrl))
            {
                httpClientHandler.UseProxy = useProxy;
                httpClientHandler.Proxy = new WebProxy(BotInfo.Config.ProxyUrl);
            }
            return new HttpClient(httpClientHandler) { Timeout = Timeout.InfiniteTimeSpan };
        }

        public async static Task<(string document, string jumpUrl)> GetHttpResponseStringAndJumpUrlAsync(string url)
        {
            using HttpClient client = CreateClient();
            using HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Content.Headers.TryAddWithoutValidation("ContentType", "text/html;charset=UTF-8");
            request.Content.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.Content.Headers.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0");
            var resp = await client.SendAsync(request);
            return (await resp.Content.ReadAsStringAsync(), request.RequestUri.ToString());
        }

        public static async Task<string> GetStringAsync(string url)
        {
            using HttpClient client = CreateClient();
            return await client.GetStringAsync(url);
        }

        public static async Task<Stream> GetStreamAsync(string url)
        {
            using HttpClient httpClient = CreateClient();
            var resp = await httpClient.GetAsync(url);
            return resp.Content.ReadAsStream();
        }
    }
}
