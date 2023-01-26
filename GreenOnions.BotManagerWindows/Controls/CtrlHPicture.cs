using GreenOnions.Interface.Configs;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlHPicture : UserControl, IConfigSetting
    {
        public CtrlHPicture()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            foreach (var hSource in BotInfo.Config.EnabledHPictureSource)
            {
                if (hSource == PictureSource.Lolicon)
                    chkHPictureEnabledLoliconSource.Checked = true;
                if (hSource == PictureSource.Yande_re)
                    chkHPictureYande_reSource.Checked = true;
                if (hSource == PictureSource.Lolisuki)
                    chkHPictureEnabledLolisukiSource.Checked = true;
                if (hSource == PictureSource.Yuban10703)
                    chkHPictureEnabledYuban10703Source.Checked = true;
                if (hSource == PictureSource.Konachan_net)
                    chkHPictureKonachan_netSource.Checked = true;
                if (hSource == PictureSource.Lolibooru)
                    chkHPictureLolibooruSource.Checked = true;
            }
            txbHPictureOnceMessageMaxImageCount.Text = BotInfo.Config.HPictureOnceMessageMaxImageCount.ToString();
            txbHPictureCmd.Text = BotInfo.Config.HPictureCmd;
            if (BotInfo.Config.HPictureUserCmd is not null)
            {
                foreach (var item in BotInfo.Config.HPictureUserCmd)
                    lstHPictureUserCmd.Items.Add(item);
            }
            if (BotInfo.Config.HPictureShieldingWords is not null)
            {
                foreach (var item in BotInfo.Config.HPictureShieldingWords)
                    lstShieldingWords.Items.Add(item.ToString());
            }
            if (BotInfo.Config.HPictureWhiteGroup is not null)
            {
                foreach (var item in BotInfo.Config.HPictureWhiteGroup)
                    lstHPictureWhiteGroup.Items.Add(item.ToString());
            }
            chkHPictureUseProxy.Checked = BotInfo.Config.HPictureUseProxy;
            chkHPictureAntiShielding.Checked = BotInfo.Config.HPictureAntiShielding;
            chkLoliconRequestByBrowser.Checked = BotInfo.Config.HPictureLoliconRequestByWebBrowser;
            chkHPictureWhiteOnly.Checked = BotInfo.Config.HPictureWhiteOnly;
            chkHPictureAllowR18.Checked = BotInfo.Config.HPictureAllowR18;
            chkHPictureR18WhiteOnly.Checked = BotInfo.Config.HPictureR18WhiteOnly;
            chkHPictureAllowPM.Checked = BotInfo.Config.HPictureAllowPM;
            txbHPictureLimit.Text = BotInfo.Config.HPictureLimit.ToString();
            chkHPicturePMNoLimit.Checked = BotInfo.Config.HPicturePMNoLimit;
            chkHPictureAdminNoLimit.Checked = BotInfo.Config.HPictureAdminNoLimit;
            chkHPictureWhiteNoLimit.Checked = BotInfo.Config.HPictureWhiteNoLimit;
            txbHPictureCD.Text = BotInfo.Config.HPictureCD.ToString();
            txbHPictureRevoke.Text = BotInfo.Config.HPictureRevoke.ToString();
            txbHPictureWhiteCD.Text = BotInfo.Config.HPictureWhiteCD.ToString();
            txbHPictureWhiteRevoke.Text = BotInfo.Config.HPictureWhiteRevoke.ToString();
            txbHPicturePMCD.Text = BotInfo.Config.HPicturePMCD.ToString();
            txbHPicturePMRevoke.Text = BotInfo.Config.HPicturePMRevoke.ToString();
            txbHPictureDownloadingReply.Text = BotInfo.Config.HPictureDownloadingReply;
            txbHPictureCDUnreadyReply.Text = BotInfo.Config.HPictureCDUnreadyReply;
            txbHPictureOutOfLimitReply.Text = BotInfo.Config.HPictureOutOfLimitReply;
            txbHPictureErrorReplyReply.Text = BotInfo.Config.HPictureErrorReply;
            txbHPictureNoResultReply.Text = BotInfo.Config.HPictureNoResultReply;
            txbDownloadFailReply.Text = BotInfo.Config.HPictureDownloadFailReply;
            if (BotInfo.Config.HPictureLimitType == LimitType.Count)
                rodHPictureLimitCount.Checked = true;
            else
                rdoHPictureLimitFrequency.Checked = true;
            chkHPictureSendUrl.Checked = BotInfo.Config.HPictureSendUrl;
            chkHPictureSendProxyUrl.Checked = BotInfo.Config.HPictureSendProxyUrl;
            chkHPictureSendTitle.Checked = BotInfo.Config.HPictureSendTitle;
            chkHPictureSendTags.Checked = BotInfo.Config.HPictureSendTags;
            chkHPictureSendByForward.Checked = BotInfo.Config.HPictureSendByForward;
        }

        public void SaveConfig()
        {
            HashSet<PictureSource> EnabledHPictureSource = new HashSet<PictureSource>();
            if (chkHPictureEnabledLoliconSource.Checked)
                EnabledHPictureSource.Add(PictureSource.Lolicon);
            if (chkHPictureYande_reSource.Checked)
                EnabledHPictureSource.Add(PictureSource.Yande_re);
            if (chkHPictureEnabledLolisukiSource.Checked)
                EnabledHPictureSource.Add(PictureSource.Lolisuki);
            if (chkHPictureEnabledYuban10703Source.Checked)
                EnabledHPictureSource.Add(PictureSource.Yuban10703);
            if (chkHPictureKonachan_netSource.Checked)
                EnabledHPictureSource.Add(PictureSource.Konachan_net);
            if (chkHPictureLolibooruSource.Checked)
                EnabledHPictureSource.Add(PictureSource.Lolibooru);

            BotInfo.Config.EnabledHPictureSource = EnabledHPictureSource;
            BotInfo.Config.HPictureAntiShielding = chkHPictureAntiShielding.Checked;
            BotInfo.Config.HPictureLoliconRequestByWebBrowser = chkLoliconRequestByBrowser.Checked;
            BotInfo.Config.HPictureCmd = txbHPictureCmd.Text;
            BotInfo.Config.HPictureOnceMessageMaxImageCount = string.IsNullOrEmpty(txbHPictureOnceMessageMaxImageCount.Text) ? 10 : Convert.ToInt32(txbHPictureOnceMessageMaxImageCount.Text);
            HashSet<string> tempHPictureUserCmd = new HashSet<string>();
            foreach (ListViewItem item in lstHPictureUserCmd.Items)
                tempHPictureUserCmd.Add(item.SubItems[0].Text);
            BotInfo.Config.HPictureUserCmd = tempHPictureUserCmd;
            HashSet<string> tempShieldingWords = new HashSet<string>();
            foreach (ListViewItem item in lstShieldingWords.Items)
                tempShieldingWords.Add(item.SubItems[0].Text);
            BotInfo.Config.HPictureShieldingWords = tempShieldingWords;
            HashSet<long> tempHPictureWhiteGroup = new HashSet<long>();
            foreach (ListViewItem item in lstHPictureWhiteGroup.Items)
                tempHPictureWhiteGroup.Add(Convert.ToInt64(item.SubItems[0].Text));
            BotInfo.Config.HPictureUseProxy = chkHPictureUseProxy.Checked;
            BotInfo.Config.HPictureWhiteGroup = tempHPictureWhiteGroup;
            BotInfo.Config.HPictureWhiteOnly = chkHPictureWhiteOnly.Checked;
            BotInfo.Config.HPictureAllowR18 = chkHPictureAllowR18.Checked;
            BotInfo.Config.HPictureR18WhiteOnly = chkHPictureR18WhiteOnly.Checked;
            BotInfo.Config.HPictureAllowPM = chkHPictureAllowPM.Checked;
            BotInfo.Config.HPictureLimit = string.IsNullOrEmpty(txbHPictureLimit.Text) ? 0 : Convert.ToInt32(txbHPictureLimit.Text);
            BotInfo.Config.HPicturePMNoLimit = chkHPicturePMNoLimit.Checked;
            BotInfo.Config.HPictureAdminNoLimit = chkHPictureAdminNoLimit.Checked;
            BotInfo.Config.HPictureCD = string.IsNullOrEmpty(txbHPictureCD.Text) ? 0 : Convert.ToInt32(txbHPictureCD.Text);
            BotInfo.Config.HPictureRevoke = string.IsNullOrEmpty(txbHPictureRevoke.Text) ? 0 : Convert.ToInt32(txbHPictureRevoke.Text);
            BotInfo.Config.HPictureWhiteCD = string.IsNullOrEmpty(txbHPictureWhiteCD.Text) ? 0 : Convert.ToInt32(txbHPictureWhiteCD.Text);
            BotInfo.Config.HPictureWhiteRevoke = string.IsNullOrEmpty(txbHPictureWhiteRevoke.Text) ? 0 : Convert.ToInt32(txbHPictureWhiteRevoke.Text);
            BotInfo.Config.HPicturePMCD = string.IsNullOrEmpty(txbHPicturePMCD.Text) ? 0 : Convert.ToInt32(txbHPicturePMCD.Text);
            BotInfo.Config.HPicturePMRevoke = string.IsNullOrEmpty(txbHPicturePMRevoke.Text) ? 0 : Convert.ToInt32(txbHPicturePMRevoke.Text);
            BotInfo.Config.HPictureDownloadingReply = txbHPictureDownloadingReply.Text;
            BotInfo.Config.HPictureCDUnreadyReply = txbHPictureCDUnreadyReply.Text;
            BotInfo.Config.HPictureOutOfLimitReply = txbHPictureOutOfLimitReply.Text;
            BotInfo.Config.HPictureErrorReply = txbHPictureErrorReplyReply.Text;
            BotInfo.Config.HPictureNoResultReply = txbHPictureNoResultReply.Text;
            BotInfo.Config.HPictureDownloadFailReply = txbDownloadFailReply.Text;
            BotInfo.Config.HPictureLimitType = rdoHPictureLimitFrequency.Checked ? LimitType.Frequency : LimitType.Count;
            BotInfo.Config.HPictureWhiteNoLimit = chkHPictureWhiteNoLimit.Checked;
            BotInfo.Config.HPictureSendUrl = chkHPictureSendUrl.Checked;
            BotInfo.Config.HPictureSendProxyUrl = chkHPictureSendProxyUrl.Checked;
            BotInfo.Config.HPictureSendTitle = chkHPictureSendTitle.Checked;
            BotInfo.Config.HPictureSendTags = chkHPictureSendTags.Checked;
            BotInfo.Config.HPictureSendByForward = chkHPictureSendByForward.Checked;
        }

        public void UpdateCache()
        {
        }

        private void lnkResetHPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txbHPictureCmd.Text = IBotConfig.DefaultHPictureCmd;
            chkHPictureEnabledLoliconSource.Checked = true;
            chkHPictureYande_reSource.Checked = false;
            chkHPictureEnabledLolisukiSource.Checked = true;
        }

        private void btnAddUserHPictureCmd_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstHPictureUserCmd, txbUserHPictureCmd.Text);

        private void btnAddWhiteGroup_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstHPictureWhiteGroup, txbWhiteGroup.Text);

        private void btnRemoveUserHPictureCmd_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstHPictureUserCmd);

        private void btnRemoveWhiteGroup_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstHPictureWhiteGroup);

        private void btnAddShieldingWords_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstShieldingWords, txbShieldingWords.Text);

        private void btnRemoveShieldingWords_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstShieldingWords);
    }
}
