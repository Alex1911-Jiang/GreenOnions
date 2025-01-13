using PuppeteerSharp;

namespace GreenOnions.NT.Base
{
    public static class Chromium
    {
        public static async Task<string> GetStringAsync(string url)
        {
            BrowserFetcher fetcher = new BrowserFetcher();
            await fetcher.DownloadAsync();

            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true, IgnoredDefaultArgs = ["--disable-extensions"], Args = ["--disable-gpu"] });
            using IPage page = (await browser.PagesAsync()).First();
            await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36 Edg/131.0.0.0");
            IResponse resp = await page.GoToAsync(url, Timeout.Infinite);
            if ((int)resp.Status > 399)
                throw new HttpRequestException(resp.Status.ToString(), null, resp.Status);
            while (resp.Status != System.Net.HttpStatusCode.OK)
                resp = await page.WaitForNavigationAsync();
            var html = await page.EvaluateFunctionAsync<string>("() => document.body.innerHTML");
            if (html.StartsWith("<pre>"))
                html = await page.EvaluateFunctionAsync<string>("() => document.querySelector('body > pre').innerHTML");
            return html;
        }
        
        public static async Task<string> GetNavigationUrlAsync(string url)
        {
            BrowserFetcher fetcher = new BrowserFetcher();
            await fetcher.DownloadAsync();

            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true, IgnoredDefaultArgs = ["--disable-extensions"], Args = ["--disable-gpu"] });
            using IPage page = (await browser.PagesAsync()).First();
            await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36 Edg/131.0.0.0");
            IResponse resp = await page.GoToAsync(url, Timeout.Infinite);
            if ((int)resp.Status > 399)
                return page.Url;
            while (resp.Status != System.Net.HttpStatusCode.OK)
                resp = await page.WaitForNavigationAsync();
            return page.Url;
        }
    }
}
