﻿using System;
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
            return new HttpClient(httpClientHandler) { Timeout = Timeout.InfiniteTimeSpan, DefaultRequestVersion = new Version(2, 0) };
        }

        public async static Task<(string document, string redirectUrl)> GetHttpResponseStringAndRedirectUrlAsync(HttpClient client, string url)
        {
            HttpRequestMessage request = new(HttpMethod.Get, url);
            client.DefaultRequestHeaders.TryAddWithoutValidation("ContentType", "text/html;charset=UTF-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0");
            var resp = await client.SendAsync(request);
            if (resp.StatusCode == HttpStatusCode.Forbidden)
                throw new HttpRequestException(" 访问被拒绝", null, resp.StatusCode);  //403
            string document = await resp.Content.ReadAsStringAsync();
            string redirectUrl = request.RequestUri.ToString();
            return (document, redirectUrl);
        }


        public static async Task<HttpResponseMessage> GetAsync(string url, bool useProxy)
        {
            using HttpClient client = CreateClient(useProxy);
            return await client.GetAsync(url);
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
            if (resp.StatusCode == HttpStatusCode.ServiceUnavailable)
                throw new HttpRequestException(" API速率限制 请稍后再试", null, resp.StatusCode);  //503
            return resp.Content.ReadAsStream();
        }

        public static Task<string> GetStringAsync(HttpClient client, string url)
        {
            return client.GetStringAsync(url);
        }
    }
}
