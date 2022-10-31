using System.Data;
using GreenOnions.BotManagerWindows.Controls;
using GreenOnions.Utility;
using GreenOnions.Utility.Items;

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
            if (BotInfo.RssSubscription != null)
            {
                pnlRssSubscriptionList.Controls.Remove(btnAddRssSubscription);
                foreach (RssSubscriptionItem item in BotInfo.RssSubscription)
                {
                    CtrlRssItem ctrlRssItem = new CtrlRssItem();
                    ctrlRssItem.Width = RssItemCtrlWidth;
                    ctrlRssItem.RssSubscriptionUrl = item.Url;
                    ctrlRssItem.RssRemark = item.Remark;
                    ctrlRssItem.RssForwardGroups = item.ForwardGroups == null ? new long[0] : item.ForwardGroups;
                    ctrlRssItem.RssForwardQQs = item.ForwardQQs == null ? new long[0] : item.ForwardQQs;
                    ctrlRssItem.RssTranslate = item.Translate;
                    ctrlRssItem.RssTranslateFromTo = item.TranslateFromTo;
                    ctrlRssItem.RssTranslateFrom = item.TranslateFrom;
                    ctrlRssItem.RssTranslateTo = item.TranslateTo;
                    ctrlRssItem.RssSendByForward = item.SendByForward;
                    ctrlRssItem.RssAtAll = item.AtAll;
                    ctrlRssItem.RssFilterMode = item.FilterMode;
                    ctrlRssItem.RssFilterKeyWords = item.FilterKeyWords;
                    ctrlRssItem.RemoveClick += (_, _) => pnlRssSubscriptionList.Controls.Remove(ctrlRssItem);
                    pnlRssSubscriptionList.Controls.Add(ctrlRssItem);
                }
                pnlRssSubscriptionList.Controls.Add(btnAddRssSubscription);
            }
            chkRssSendLiveCover.Checked = BotInfo.RssSendLiveCover;
            txbReadRssInterval.Text = BotInfo.ReadRssInterval.ToString();
            chkRssParallel.Checked = BotInfo.RssParallel;
        }

        public void SaveConfig()
        {
            BotInfo.RssSubscription = pnlRssSubscriptionList.Controls.OfType<CtrlRssItem>().Select(i => new RssSubscriptionItem()
            {
                Url = i.RssSubscriptionUrl,
                Remark = i.RssRemark,
                ForwardGroups = i.RssForwardGroups,
                ForwardQQs = i.RssForwardQQs,
                Translate = i.RssTranslate,
                TranslateFromTo = i.RssTranslateFromTo,
                TranslateFrom = i.RssTranslateFrom,
                TranslateTo = i.RssTranslateTo,
                AtAll = i.RssAtAll,
                SendByForward = i.RssSendByForward,
                FilterMode = i.RssFilterMode,
                FilterKeyWords = i.RssFilterKeyWords,
            }).ToList();
            BotInfo.ReadRssInterval = Convert.ToDouble(txbReadRssInterval.Text);
            BotInfo.RssSendLiveCover = chkRssSendLiveCover.Checked;
            BotInfo.RssParallel = chkRssParallel.Checked;
        }

        public void UpdateCache()
        {
        }

        #region -- RSS --

        private int RssItemCtrlWidth = 592;
        private void btnAddRssSubscription_Click(object sender, EventArgs e)
        {
            pnlRssSubscriptionList.Controls.Remove(btnAddRssSubscription);
            CtrlRssItem ctrlRssItem = new CtrlRssItem();
            ctrlRssItem.Width = RssItemCtrlWidth;
            ctrlRssItem.RemoveClick += (_, _) => pnlRssSubscriptionList.Controls.Remove(ctrlRssItem);
            pnlRssSubscriptionList.Controls.Add(ctrlRssItem);
            pnlRssSubscriptionList.Controls.Add(btnAddRssSubscription);
            pnlRssSubscriptionList.ScrollControlIntoView(btnAddRssSubscription);
        }

        private void pnlRssSubscriptionList_ControlChanged(object sender, ControlEventArgs e) => ComputeRssItemWidth();

        private void pnlRssSubscriptionList_SizeChanged(object sender, EventArgs e) => ComputeRssItemWidth();

        private void ComputeRssItemWidth()
        {
            RssItemCtrlWidth = pnlRssSubscriptionList.Controls.Count * btnAddRssSubscription.Height + pnlRssSubscriptionList.Controls.Count * btnAddRssSubscription.Margin.Top * 2 + btnAddRssSubscription.Margin.Top - 1 > pnlRssSubscriptionList.Height ? pnlRssSubscriptionList.Width - 25 : pnlRssSubscriptionList.Width - 8;
            foreach (Control item in pnlRssSubscriptionList.Controls)
                item.Width = RssItemCtrlWidth;
        }
        #endregion -- RSS --
    }
}
