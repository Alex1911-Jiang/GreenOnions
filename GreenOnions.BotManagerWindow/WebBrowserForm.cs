using CefSharp;
using CefSharp.WinForms;
using GreenOnions.Utility;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace GreenOnions.BotManagerWindow
{
    public partial class WebBrowserForm : Form
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        private ChromiumWebBrowser _webBrowser = null;
        private string _document = "";
        private string _jumpUrl = "";
        private Encoding _encoding = Encoding.UTF8;
        private int waitTime = 60000;
        private bool unlock = true;

        public WebBrowserForm()
        {
            InitializeComponent();

            CefSettings settings = new CefSettings{CefCommandLineArgs = { ["disable-gpu-shader-disk-cache"] = "1" }};
            settings.RemoteDebuggingPort = 8080;
            string cefCachePath = Path.Combine(Application.StartupPath, "Cef");
            if (!Directory.Exists(cefCachePath))
                Directory.CreateDirectory(cefCachePath);
            settings.CachePath = cefCachePath;
            Cef.Initialize(settings, false, browserProcessHandler: null);

            _webBrowser = new ChromiumWebBrowser();
            _webBrowser.Dock = DockStyle.Fill;
            pnlBrowser.Controls.Add(_webBrowser);
        }

        protected override void CreateHandle()
        {
        }

        public new void Show()
        {
            if (BotInfo.DebugMode && !IsHandleCreated)
                base.CreateHandle();
            if (!Visible)
                base.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = true;
            Hide();
        }

        public (string Document, string JumpUrl) GetDocument(string url)
        {
            return GetDocumentAsync(url, Encoding.UTF8).GetAwaiter().GetResult();
        }

        public async Task<(string Document, string JumpUrl)> GetDocumentAsync(string url, Encoding encode)
        {
            _encoding = encode;
            _jumpUrl = "";
            _document = "";

            LoadUrlAsyncResponse loading = await _webBrowser.LoadUrlAsync(url);

            int waitedTime = 0;
            while (_webBrowser.IsLoading && !loading.Success)
            {
                Task.Delay(100).Wait();
                waitedTime += 100;
                if (IsHandleCreated)
                    Invoke(new Action(() => txbMessage.AppendText($"网站未加载完, 等待1秒, Url={url}\r\n")));
                if (waitedTime > waitTime)
                {
                    if (IsHandleCreated)
                        Invoke(new Action(() => txbMessage.AppendText($"等待时间超过{waitTime}, 强制返回\r\n")));
                    break;
                }
            }

            IFrame frame = _webBrowser.GetMainFrame();

            if (IsHandleCreated)
                Invoke(new Action(() => txbMessage.AppendText($"Chrome浏览器网页加载完毕, 跳转Url={frame.Url}\r\n")));

            _jumpUrl = frame.Url;
            _document = await frame.GetSourceAsync();

            return (_document, _jumpUrl);
        }

        private void SaveCookie(WebBrowser browser)
        {
            string cookieStr = browser.Document.Cookie;
            if (cookieStr == null)
            {
                txbMessage.AppendText($"网站{browser.Url.Host}没有需要保存的Cookie\r\n");
                return;
            }
            string[] cookstr = cookieStr.Split(';');
            foreach (string str in cookstr)
            {
                string[] cookieNameValue = str.Split('=');
                txbMessage.AppendText($"网站{browser.Url.Host}保存了一个Cookie:{cookieNameValue[0].Trim().ToString()}\r\n");
                InternetSetCookie(browser.Url.Host, cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
            }
        }

        private void CheckCloudflare(string document, WebBrowser browser, int nowWaitTime)
        {
            if (unlock)
            {
                unlock = false;

                if (browser == null)
                    throw new ArgumentNullException(nameof(browser));

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(document);
                var cloudflareHtml = doc.DocumentNode.SelectNodes("/html");
                if (cloudflareHtml != null && (cloudflareHtml[0].InnerText.Contains("Please Wait") || cloudflareHtml[0].InnerText.Contains("Cloudflare")))
                {
                    txbMessage.AppendText($"当前请求地址为: {browser.Url.ToString()}\r\n");
                    waitTime += nowWaitTime;
                    if (nowWaitTime > 6000)
                        txbMessage.AppendText($"疑似人机验证, 请在{(nowWaitTime / 1000)}秒内手动通过人机验证...\r\n");
                    else
                        txbMessage.AppendText($"被Cloudflare五秒盾拦截, 等待{(nowWaitTime / 1000)}秒后自动重试...\r\n");

                    Task.Delay(nowWaitTime).ContinueWith(_ =>
                    {
                        if (IsHandleCreated)
                        {
                            Invoke(new Action(() =>
                            {
                                StreamReader getReader = new StreamReader(browser.DocumentStream, _encoding);
                                string document = getReader.ReadToEnd();
                                unlock = true;
                                CheckCloudflare(document, browser, 120000);
                            }));
                        }
                    });
                }
                else
                {
                    SaveCookie(browser);
                    txbMessage.AppendText("成功通过Cloudflare盾。(您现在可以禁用调试模式并关闭此窗口)\r\n");
                    waitTime = 15000;
                    _document = document;
                    unlock = true;
                }
            }
        }

        private void btnLoadUrl_Click(object sender, EventArgs e)
        {
            foreach (ChromiumWebBrowser item in pnlBrowser.Controls.OfType<ChromiumWebBrowser>())
            {
                pnlBrowser.Controls.Remove(item);
                item.Dispose();
            }

            ChromiumWebBrowser webBrowser = new ChromiumWebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            pnlBrowser.Controls.Add(webBrowser);
            webBrowser.Load(txbUrl.Text);
        }
    }
}
