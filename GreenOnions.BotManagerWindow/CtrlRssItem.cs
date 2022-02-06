using System;
using System.Linq;
using System.Windows.Forms;

namespace GreenOnions.BotManagerWindow
{
    public partial class CtrlRssItem : UserControl
    {
        public event EventHandler RemoveClick;
        public CtrlRssItem()
        {
            InitializeComponent();
        }
        public string RssSubscriptionUrl
        {
            get => txbRssSubscriptionUrl.Text;
            set => txbRssSubscriptionUrl.Text = value;
        }
        public long[] RssForwardGroups
        {
            get => txbRssForwardGroups.Text.Replace("\r","").Split('\n').Select(s => s = s.Trim()).Where(s => !string.IsNullOrEmpty(s)).Select(s => Convert.ToInt64(s)).ToArray();
            set => txbRssForwardGroups.Text = String.Join("\r\n", value);
        }
        public long[] RssForwardQQs
        {
            get => txbRssForwardQQs.Text.Replace("\r", "").Split('\n').Select(s => s = s.Trim()).Where(s => !string.IsNullOrEmpty(s)).Select(s => Convert.ToInt64(s)).ToArray();
            set => txbRssForwardQQs.Text = String.Join("\r\n", value);
        }
        public bool RssTranslate
        {
            get => txbRssTranslate.Checked;
            set => txbRssTranslate.Checked = value;
        }
        public string RssRemark
        {
            get => txbRssRemark.Text;
            set => txbRssRemark.Text = value;
        }
        public bool RssSendByForward
        {
            get => chkRssSendByForward.Checked;
            set => chkRssSendByForward.Checked = value;
        }
        
        private void btnRssRemoveItem_Click(object sender, EventArgs e) => RemoveClick?.Invoke(sender, e);

        private void checkNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == (char)13))
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
    }
}
