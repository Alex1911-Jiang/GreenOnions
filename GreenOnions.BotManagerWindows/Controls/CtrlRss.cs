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
                    CtrlRssItem ctrlRssItem = new CtrlRssItem(item, pnlRssSubscriptionList.Controls.Remove);
                    pnlRssSubscriptionList.Controls.Add(ctrlRssItem);
                    ctrlRssItem.Width = ComputeRssItemWidth();
                }
                pnlRssSubscriptionList.Controls.Add(btnAddRssSubscription);
                btnAddRssSubscription.Width = ComputeRssItemWidth();
            }
            chkRssParallel.Checked = BotInfo.Config.RssParallel;
            chkRssUseProxy.Checked = BotInfo.Config.RssUseProxy;
            txbReadRssInterval.Text = BotInfo.Config.ReadRssInterval.ToString();
            txbRssTwimgProxyUrl.Text = BotInfo.Config.RssTwimgProxyUrl;
            chkRssMergeIntoOneMessage.Checked = BotInfo.Config.RssMergeIntoOneMessage;
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
            BotInfo.Config.RssTwimgProxyUrl = txbRssTwimgProxyUrl.Text;
            BotInfo.Config.RssMergeIntoOneMessage = chkRssMergeIntoOneMessage.Checked;
        }

        public void UpdateCache()
        {
        }

        private void btnAddRssSubscription_Click(object sender, EventArgs e)
        {
            pnlRssSubscriptionList.Controls.Remove(btnAddRssSubscription);
            CtrlRssItem ctrlRssItem = new CtrlRssItem(new RssSubscriptionItem(), pnlRssSubscriptionList.Controls.Remove);
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