using GreenOnions.Utility;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace GreenOnions.BotManagerWindow
{
    public partial class WebBrowserForm : Form
    {
        private string _document = "";
        private string _jumpUrl = "";
        private Encoding _encoding = Encoding.UTF8;
        private int waitTime = 15000;
        private bool unlock = true;

        public WebBrowserForm()
        {
            InitializeComponent();
        }

        public new void CreateHandle()
        {
            if (BotInfo.DebugMode)
                Show();
            else
            {
                if (!IsHandleCreated)
                    base.CreateHandle();
                Hide();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = true;
            Hide();
        }

        public (string Document, string JumpUrl) GetDocumentAsync(string url)
        {
            return GetDocumentAsync(url, Encoding.UTF8);
        }

        public (string Document, string JumpUrl) GetDocumentAsync(string url, Encoding encode)
        {
            _encoding = encode;
            _jumpUrl = "";
            _document = "";
            WebBrowser webBrowser = null;
            Invoke(new Action(() =>
            {
                webBrowser = new WebBrowser();
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.Dock = DockStyle.Fill;
                pnlBrowser.Controls.Add(webBrowser);
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
                webBrowser.ProgressChanged += WebBrowser1_ProgressChanged;
                webBrowser.Navigate(url.ToString());
            }));

            int waitedTime = 0;
            while (string.IsNullOrEmpty(_document) || string.IsNullOrEmpty(_jumpUrl))
            {
                Task.Delay(100).Wait();
                waitedTime += 100;
                if (waitedTime > waitTime)
                    break;
            }
            if (!BotInfo.DebugMode)
            {
                Invoke(new Action(() =>
                {
                    pnlBrowser.Controls.Remove(webBrowser);
                    webBrowser.Dispose();
                }));
            }
            return (_document, _jumpUrl);
        }

        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            WebBrowser browser = (WebBrowser)sender;
            if (browser.ReadyState == WebBrowserReadyState.Complete || browser.ReadyState == WebBrowserReadyState.Interactive)
                GetDocumentByIE(browser);
        }

        private void GetDocumentByIE(WebBrowser browser)
        {
            _jumpUrl = browser.Url.ToString();
            StreamReader getReader = new StreamReader(browser.DocumentStream, _encoding);
            string document = getReader.ReadToEnd();
            CheckCloudflare(document, browser, 6000);
        }

        private void CheckCloudflare(string document, WebBrowser browser, int nowWaitTime)
        {
            if (unlock)
            {
                unlock = false;

                if (browser == null)
                {
                    throw new ArgumentNullException(nameof(browser));
                }

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(document);
                var cloudflareHtml = doc.DocumentNode.SelectNodes("/html");
                if (cloudflareHtml != null && (cloudflareHtml[0].InnerText.Contains("Please Wait") || cloudflareHtml[0].InnerText.Contains("Cloudflare")))
                {
                    waitTime += nowWaitTime;
                    if (nowWaitTime > 6000)
                        txbMessage.AppendText($"疑似人机验证, 请在{(nowWaitTime / 1000)}秒内手动通过人机验证...\r\n");
                    else
                        txbMessage.AppendText($"被Cloudflare五秒盾拦截, 等待{(nowWaitTime / 1000)}秒后自动重试...\r\n");

                    Task.Delay(nowWaitTime).ContinueWith(_ =>
                    {
                        Invoke(new Action(() =>
                        {
                            StreamReader getReader = new StreamReader(browser.DocumentStream, _encoding);
                            string document = getReader.ReadToEnd();
                            unlock = true;
                            CheckCloudflare(document, browser, 120000);
                        }));
                    });
                }
                else
                {
                    txbMessage.AppendText("成功通过Cloudflare盾。(您现在可以禁用调试模式并关闭此窗口)\r\n");
                    waitTime = 15000;
                    _document = document;
                    unlock = true;
                }
            }
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            GetDocumentByIE((WebBrowser)sender);
        }
    }
}
