using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenOnions.BotManagerWindow
{
    public partial class WebBrowserForm : Form
    {
        public WebBrowserForm()
        {
            InitializeComponent();
            CreateHandle();
        }

        private string _document = "";
        private string _jumpUrl = "";
        private Encoding _encoding = Encoding.UTF8;

        public (string Document, string JumpUrl) GetDocumentAsync(string url)
        {
            return GetDocumentAsync(url, Encoding.UTF8);
        }

        public (string Document, string JumpUrl) GetDocumentAsync(string url, Encoding encode)
        {
            _encoding = encode;
            _jumpUrl = "";
            _document = "";
            WebBrowser _webBrowser = null;
            Invoke(new Action(() =>
            {
                _webBrowser = new WebBrowser();
                _webBrowser.ScriptErrorsSuppressed = true;
                _webBrowser.Dock = DockStyle.Fill;
                Controls.Add(_webBrowser);
                _webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
                _webBrowser.ProgressChanged += WebBrowser1_ProgressChanged;
                _webBrowser.Navigate(url.ToString());
            }));

            int waitedTime = 0;
            while (string.IsNullOrEmpty(_document) || string.IsNullOrEmpty(_jumpUrl))
            {
                Task.Delay(100).Wait();
                waitedTime += 100;
                if (waitedTime > 15000)
                    break;
            }

            Invoke(new Action(() =>
            {
                Controls.Remove(_webBrowser);
                _webBrowser.Dispose();
            }));
            return (_document, _jumpUrl);
        }


        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            WebBrowser web = (WebBrowser)sender;
            if (web.ReadyState == WebBrowserReadyState.Complete || web.ReadyState == WebBrowserReadyState.Interactive)
                GetDocumentByIE(web);
        }

        private void GetDocumentByIE(WebBrowser web)
        {
            _jumpUrl = web.Url.ToString();
            StreamReader getReader = new StreamReader(web.DocumentStream, _encoding);
            _document = getReader.ReadToEnd();
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            GetDocumentByIE((WebBrowser)sender);
        }
    }
}
