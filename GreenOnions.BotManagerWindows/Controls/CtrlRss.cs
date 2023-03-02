using System.Data;
using GreenOnions.BotManagerWindows.ItemFroms;
using GreenOnions.Interface.Items;
using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlRss : UserControl, IConfigSetting
    {
        public CtrlRss()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            if (BotInfo.Config.RssSubscription is not null)
            {
                pnlRssSubscriptionList.Controls.Remove(btnAddRssSubscription);
                foreach (RssSubscriptionItem item in BotInfo.Config.RssSubscription)
                {
                    CtrlRssItem ctrlRssItem = new CtrlRssItem(pnlRssSubscriptionList.Controls.Remove);
                    ctrlRssItem.RssSubscriptionUrl = item.Url;
                    ctrlRssItem.RssRemark = item.Remark;
                    ctrlRssItem.RssForwardGroups = item.ForwardGroups is null ? new long[0] : item.ForwardGroups;
                    ctrlRssItem.RssForwardQQs = item.ForwardQQs is null ? new long[0] : item.ForwardQQs;
                    ctrlRssItem.RssTranslate = item.Translate;
                    ctrlRssItem.RssTranslateFromTo = item.TranslateFromTo;
                    ctrlRssItem.RssTranslateFrom = item.TranslateFrom;
                    ctrlRssItem.RssTranslateTo = item.TranslateTo;
                    ctrlRssItem.RssSendByForward = item.SendByForward;
                    ctrlRssItem.RssFilterMode = item.FilterMode;
                    ctrlRssItem.RssFilterKeyWords = item.FilterKeyWords;
                    ctrlRssItem.RssHeders = item.Headers;
                    ctrlRssItem.RssFormat = item.Format;
                    ctrlRssItem.RssSourceIsStream = item.SourceIsStream;
                    pnlRssSubscriptionList.Controls.Add(ctrlRssItem);
                    ctrlRssItem.Width = ComputeRssItemWidth();
                }
                pnlRssSubscriptionList.Controls.Add(btnAddRssSubscription);
                btnAddRssSubscription.Width = ComputeRssItemWidth();
            }
            chkRssParallel.Checked = BotInfo.Config.RssParallel;
            chkRssUseProxy.Checked = BotInfo.Config.RssUseProxy;
            txbReadRssInterval.Text = BotInfo.Config.ReadRssInterval.ToString();
        }

        public void SaveConfig()
        {
            BotInfo.Config.RssSubscription = pnlRssSubscriptionList.Controls.OfType<CtrlRssItem>().Select(i => new RssSubscriptionItem()
            {
                Url = i.RssSubscriptionUrl,
                Remark = i.RssRemark,
                ForwardGroups = i.RssForwardGroups,
                ForwardQQs = i.RssForwardQQs,
                Translate = i.RssTranslate,
                TranslateFromTo = i.RssTranslateFromTo,
                TranslateFrom = i.RssTranslateFrom,
                TranslateTo = i.RssTranslateTo,
                SendByForward = i.RssSendByForward,
                FilterMode = i.RssFilterMode,
                FilterKeyWords = i.RssFilterKeyWords,
                Headers = i.RssHeders,
                Format = i.RssFormat,
                SourceIsStream = i.RssSourceIsStream,
            }).ToHashSet();
            BotInfo.Config.RssParallel = chkRssParallel.Checked;
            BotInfo.Config.RssUseProxy = chkRssUseProxy.Checked;
            BotInfo.Config.ReadRssInterval = Convert.ToDouble(txbReadRssInterval.Text);
        }

        public void UpdateCache()
        {
        }

        private void btnAddRssSubscription_Click(object sender, EventArgs e)
        {
            pnlRssSubscriptionList.Controls.Remove(btnAddRssSubscription);
            CtrlRssItem ctrlRssItem = new CtrlRssItem(pnlRssSubscriptionList.Controls.Remove);
            pnlRssSubscriptionList.Controls.Add(ctrlRssItem);
            pnlRssSubscriptionList.Controls.Add(btnAddRssSubscription);
            ctrlRssItem.Width = ComputeRssItemWidth();
            btnAddRssSubscription.Width = ComputeRssItemWidth();
            pnlRssSubscriptionList.ScrollControlIntoView(btnAddRssSubscription);
        }

        private void pnlRssSubscriptionList_ControlChanged(object sender, ControlEventArgs e) => ResetRssItemWidth(ComputeRssItemWidth());

        private void pnlRssSubscriptionList_SizeChanged(object sender, EventArgs e) => ResetRssItemWidth(ComputeRssItemWidth());

        private int  ComputeRssItemWidth()
        {
            int dpiScale = (int)Math.Ceiling(Graphics.FromHwnd(Handle).DpiX / 96);
            return pnlRssSubscriptionList.Controls.Count * btnAddRssSubscription.Height + pnlRssSubscriptionList.Controls.Count * btnAddRssSubscription.Margin.Top * 2 + btnAddRssSubscription.Margin.Top - 1 > pnlRssSubscriptionList.Height ? pnlRssSubscriptionList.Width - 25 * dpiScale : pnlRssSubscriptionList.Width - 8 * dpiScale;
        }

        private void ResetRssItemWidth(int rssItemCtrlWidth)
        {
            foreach (Control item in pnlRssSubscriptionList.Controls)
                item.Width = rssItemCtrlWidth;
        }

        private void btnRssLogViewer_Click(object sender, EventArgs e)
        {
            btnRssLogViewer.Enabled = false;
            FrmRssLogViewer viewer = new FrmRssLogViewer();
            viewer.FormClosed += (_, _) => btnRssLogViewer.Enabled = true;
            viewer.Show();
        }
    }
}