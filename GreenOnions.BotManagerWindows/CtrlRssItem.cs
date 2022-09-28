﻿using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows
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
            get => chkRssTranslate.Checked;
            set => chkRssTranslate.Checked = value;
        }
        public bool RssTranslateFromTo
        {
            get => chkTranslateFromTo.Checked;
            set => chkTranslateFromTo.Checked = value;
        }
        public string RssTranslateFrom
        {
            get => cboTranslateFrom.Text;
            set => SetComboBoxIndex(cboTranslateFrom, value);
        }
        public string RssTranslateTo
        {
            get => cboTranslateTo.Text;
            set => SetComboBoxIndex(cboTranslateTo, value);
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
        public bool RssAtAll
        {
            get => chkRssAtAll.Checked;
            set => chkRssAtAll.Checked = value;
        }
        public int RssFilterMode { get; set; }
        public string[] RssFilterKeyWords { get; set; }

        private void SetComboBoxIndex(ComboBox ctrl, string value)
        {
            if (ctrl.DataSource == null)
            {
                switch (BotInfo.TranslateEngineType)
                {
                    case TranslateEngine.Google:
                        cboTranslateFrom.DataSource = Constants.GoogleLanguages.Keys.ToList();
                        cboTranslateTo.DataSource = Constants.GoogleLanguages.Keys.ToList();
                        break;
                    case TranslateEngine.YouDao:
                        cboTranslateFrom.DataSource = Constants.YouDaoLanguages.Keys.ToList();
                        cboTranslateTo.DataSource = Constants.YouDaoLanguages.Keys.ToList();
                        break;
                }
            }
            List<string> source = (ctrl.DataSource as List<string>);
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] == value)
                {
                    ctrl.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnRssRemoveItem_Click(object sender, EventArgs e) => RemoveClick?.Invoke(sender, e);

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
            if (chkTranslateFromTo.Checked && BotInfo.TranslateEnabled)
            {
                switch (BotInfo.TranslateEngineType)
                {
                    case TranslateEngine.Google:
                        cboTranslateFrom.DataSource = Constants.GoogleLanguages.Keys.ToList();
                        cboTranslateTo.DataSource = Constants.GoogleLanguages.Keys.ToList();
                        break;
                    case TranslateEngine.YouDao:
                        cboTranslateFrom.DataSource = Constants.YouDaoLanguages.Keys.ToList();
                        cboTranslateTo.DataSource = Constants.YouDaoLanguages.Keys.ToList();
                        break;
                }
            }
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            FrmRssFilter frmFilter = new FrmRssFilter(RssFilterMode, RssFilterKeyWords);
            frmFilter.ShowDialog();
            RssFilterMode = frmFilter.FilterMode;
            RssFilterKeyWords = frmFilter.FilterKeyWords;
        }
    }
}