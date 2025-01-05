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
            using IPage page = await browser.NewPageAsync();
            IResponse resp = await page.GoToAsync(url);
            if ((int)resp.Status > 399)
                throw new HttpRequestException(null, null, resp.Status);
            while (resp.Status != System.Net.HttpStatusCode.OK)
                resp = await page.WaitForNavigationAsync();
            var html = await page.EvaluateFunctionAsync<string>("() => document.querySelector('body > pre').innerHTML");
            return html;
        }
    }
}
