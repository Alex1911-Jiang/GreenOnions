using System.Xml;
using GreenOnions.BotManagerWindows.ItemFroms;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlRssItem : UserControl
    {
        private event Action<Control> RemoveClick;
        public CtrlRssItem(Action<Control> removeClick )
        {
            RemoveClick = removeClick;
            InitializeComponent();
            btnRssRemoveItem.Click += (_, _) => RemoveClick(this);
        }
        public string? RssSubscriptionUrl
        {
            get => txbRssSubscriptionUrl.Text;
            set => txbRssSubscriptionUrl.Text = value;
        }
        public long[] RssForwardGroups
        {
            get => txbRssForwardGroups.Text.Replace("\r","").Split('\n').Select(s => s = s.Trim()).Where(s => !string.IsNullOrEmpty(s)).Select(s => Convert.ToInt64(s)).ToArray();
            set => txbRssForwardGroups.Text = string.Join("\r\n", value);
        }
        public long[] RssForwardQQs
        {
            get => txbRssForwardQQs.Text.Replace("\r", "").Split('\n').Select(s => s = s.Trim()).Where(s => !string.IsNullOrEmpty(s)).Select(s => Convert.ToInt64(s)).ToArray();
            set => txbRssForwardQQs.Text = string.Join("\r\n", value);
        }
        public bool RssTranslate
        {
            get => chkRssTranslate.Checked;
            set => chkRssTranslate.Checked = value;
        }
        public bool RssTranslateFromTo
        {
            get => chkTranslateFromTo.Checked;
            set => chkTranslateFromTo.Checked = value;
        }
        public string? RssTranslateFrom
        {
            get => cboTranslateFrom.Text;
            set => SetComboBoxIndex(cboTranslateFrom, value);
        }
        public string? RssTranslateTo
        {
            get => cboTranslateTo.Text;
            set => SetComboBoxIndex(cboTranslateTo, value);
        }
        public string? RssRemark
        {
            get => txbRssRemark.Text;
            set => txbRssRemark.Text = value;
        }
        public bool RssSendByForward
        {
            get => chkRssSendByForward.Checked;
            set => chkRssSendByForward.Checked = value;
        }

        public bool RssSourceIsStream
        {
            get => chkSourceIsStream.Checked;
            set => chkSourceIsStream.Checked = value;
        }

        public int RssFilterMode { get; set; }
        public string[]? RssFilterKeyWords { get; set; }
        public Dictionary<string,string>? RssHeders { get; set; }
        public string[] RssFormat { get; set; }

        private void LoadLanguageList()
        {
            switch (BotInfo.Config.TranslateEngineType)
            {
                //case TranslateEngine.Google:
                //    cboTranslateFrom.DataSource = Constants.GoogleLanguages.Keys.ToList();
                //    cboTranslateTo.DataSource = Constants.GoogleLanguages.Keys.ToList();
                //    break;
                case TranslateEngine.YouDao:
                    cboTranslateFrom.DataSource = Constants.YouDaoWebLanguages.Keys.ToList();
                    cboTranslateTo.DataSource = Constants.YouDaoWebLanguages.Keys.ToList();
                    break;
                case TranslateEngine.YouDaoApi:
                    cboTranslateFrom.DataSource = Constants.YouDaoLanguages.Keys.ToList();
                    cboTranslateTo.DataSource = Constants.YouDaoLanguages.Keys.ToList();
                    break;
                case TranslateEngine.BaiduApi:
                    cboTranslateFrom.DataSource = Constants.BaiduLanguages.Keys.ToList();
                    cboTranslateTo.DataSource = Constants.BaiduLanguages.Keys.ToList();
                    break;
                case TranslateEngine.TencentApi:
                    cboTranslateFrom.DataSource = Constants.TencentLanguages.Keys.ToList();
                    cboTranslateTo.DataSource = Constants.TencentLanguages.Keys.ToList();
                    break;
            }
        }

        private void SetComboBoxIndex(ComboBox ctrl, string? value)
        {
            if (ctrl.DataSource is null)
                LoadLanguageList();

            if (ctrl.DataSource is List<string> source)
            {
                for (int i = 0; i < source.Count; i++)
                {
                    if (source[i] == value)
                    {
                        ctrl.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void checkNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)3 || e.KeyChar == (char)26 || e.KeyChar == (char)8 || e.KeyChar == (char)13)
            {
                return;
            }
            if (!char.IsNumber(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
        private void checkNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText())
                {
                    try
                    {
                        Convert.ToInt64(Clipboard.GetText());  //检查是否数字
                        ((TextBox)sender).SelectedText = Clipboard.GetText().Trim(); //Ctrl+V 粘贴
                    }
                    catch (Exception)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void chkRssTranslate_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRssTranslate.Checked)
                chkTranslateFromTo.Checked = false;
            chkTranslateFromTo.Enabled = chkRssTranslate.Checked;
        }

        private void chkTranslateFromTo_CheckedChanged(object sender, EventArgs e)
        {
            pnlTranslateFromTo.Enabled = chkTranslateFromTo.Checked;
            if (chkTranslateFromTo.Checked && BotInfo.Config.TranslateEnabled)
                LoadLanguageList();
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            FrmRssFilter frmFilter = new FrmRssFilter(RssFilterMode, RssFilterKeyWords);
            frmFilter.ShowDialog();
            RssFilterMode = frmFilter.FilterMode;
            RssFilterKeyWords = frmFilter.FilterKeyWords;
        }

        private void btnHeaders_Click(object sender, EventArgs e)
        {
            FrmRssHeders frmRssHeders = new FrmRssHeders(RssHeders);
            frmRssHeders.ShowDialog();
            RssHeders = frmRssHeders.Headers;
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new();
            string? xml;
            try
            {
                using HttpClient client = HttpHelper.CreateClient(BotInfo.Config.RssUseProxy);
                if (RssHeders is not null)
                {
                    foreach (var header in RssHeders)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                var resp = await client.GetAsync(txbRssSubscriptionUrl.Text);
                xml = await resp.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"地址访问失败，{ex.Message}", "失败");
                return;
            }
            try
            {
                xmlDoc.LoadXml(xml);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"解析失败，内容可能不是XML。\r\n{ex.Message}", "失败");
            }
            MessageBox.Show(xmlDoc.InnerText, "成功");
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            FrmRssFromat frmFormat = new FrmRssFromat(RssFormat);
            frmFormat.ShowDialog();
            RssFormat = frmFormat.Format;
        }
    }
}
