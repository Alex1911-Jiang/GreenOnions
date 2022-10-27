using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlHPicture : UserControl, IConfigSetting
    {
        public CtrlHPicture()
        {
            InitializeComponent();

            if (pnlHPictureCheckBoxes.Left < 519)  //狗屎设计器整天有Bug自动移动位置
                pnlHPictureCheckBoxes.Left = 519;
        }

        public void LoadConfig()
        {
            foreach (var hSource in BotInfo.EnabledHPictureSource)
            {
                if (hSource == PictureSource.Lolicon)
                    chkHPictureEnabledLoliconSource.Checked = true;
                if (hSource == PictureSource.Yande_re)
                    chkHPictureYande_reSource.Checked = true;
            }
            foreach (var beautySource in BotInfo.EnabledBeautyPictureSource)
            {
                if (beautySource == PictureSource.ELF)
                    chkBeautyPictureEnabledELFSource.Checked = true;
            }
            cboHPictureDefaultSource.DataSource = Enum.GetNames<PictureSource>();
            cboHPictureDefaultSource.SelectedIndex = BotInfo.HPictureDefaultSource;

            txbHPictureOnceMessageMaxImageCount.Text = BotInfo.HPictureOnceMessageMaxImageCount.ToString();
            txbHPictureCmd.Text = BotInfo.HPictureCmd;
            chkRevokeBeautyPicture.Checked = BotInfo.RevokeBeautyPicture;
            if (BotInfo.HPictureUserCmd != null)
            {
                foreach (var item in BotInfo.HPictureUserCmd)
                    lstHPictureUserCmd.Items.Add(item);
            }
            if (BotInfo.HPictureShieldingWords != null)
            {
                foreach (var item in BotInfo.HPictureShieldingWords)
                    lstShieldingWords.Items.Add(item.ToString());
            }
            if (BotInfo.HPictureWhiteGroup != null)
            {
                foreach (var item in BotInfo.HPictureWhiteGroup)
                    lstHPictureWhiteGroup.Items.Add(item.ToString());
            }
            chkHPictureWhiteOnly.Checked = BotInfo.HPictureWhiteOnly;
            chkHPictureAllowR18.Checked = BotInfo.HPictureAllowR18;
            chkHPictureR18WhiteOnly.Checked = BotInfo.HPictureR18WhiteOnly;
            chkHPictureAllowPM.Checked = BotInfo.HPictureAllowPM;
            chkHPictureSize1200.Checked = BotInfo.HPictureSize1200;
            txbHPictureLimit.Text = BotInfo.HPictureLimit.ToString();
            chkHPicturePMNoLimit.Checked = BotInfo.HPicturePMNoLimit;
            chkHPictureAdminNoLimit.Checked = BotInfo.HPictureAdminNoLimit;
            chkHPictureWhiteNoLimit.Checked = BotInfo.HPictureWhiteNoLimit;
            txbHPictureCD.Text = BotInfo.HPictureCD.ToString();
            txbHPictureRevoke.Text = BotInfo.HPictureRevoke.ToString();
            txbHPictureWhiteCD.Text = BotInfo.HPictureWhiteCD.ToString();
            txbHPictureWhiteRevoke.Text = BotInfo.HPictureWhiteRevoke.ToString();
            txbHPicturePMCD.Text = BotInfo.HPicturePMCD.ToString();
            txbHPicturePMRevoke.Text = BotInfo.HPicturePMRevoke.ToString();
            txbHPictureDownloadingReply.Text = BotInfo.HPictureDownloadingReply;
            txbHPictureCDUnreadyReply.Text = BotInfo.HPictureCDUnreadyReply;
            txbHPictureOutOfLimitReply.Text = BotInfo.HPictureOutOfLimitReply;
            txbHPictureErrorReplyReply.Text = BotInfo.HPictureErrorReply;
            txbHPictureNoResultReply.Text = BotInfo.HPictureNoResultReply;
            txbDownloadFailReply.Text = BotInfo.HPictureDownloadFailReply;
            if (BotInfo.HPictureLimitType == LimitType.Count)
                rodHPictureLimitCount.Checked = true;
            else
                rdoHPictureLimitFrequency.Checked = true;
            chkHPictureSendUrl.Checked = BotInfo.HPictureSendUrl;
            chkHPictureSendProxyUrl.Checked = BotInfo.HPictureSendProxyUrl;
            chkHPictureSendTitle.Checked = BotInfo.HPictureSendTitle;
            chkHPictureSendTags.Checked = BotInfo.HPictureSendTags;
            chkHPictureSendByForward.Checked = BotInfo.HPictureSendByForward;
        }

        public void SaveConfig()
        {
            List<PictureSource> EnabledHPictureSource = new List<PictureSource>();
            List<PictureSource> EnabledBeautyPictureSource = new List<PictureSource>();
            if (chkHPictureEnabledLoliconSource.Checked)
                EnabledHPictureSource.Add(PictureSource.Lolicon);
            if (chkHPictureYande_reSource.Checked)
                EnabledHPictureSource.Add(PictureSource.Yande_re);
            if (chkBeautyPictureEnabledELFSource.Checked)
                EnabledBeautyPictureSource.Add(PictureSource.ELF);
            BotInfo.EnabledHPictureSource = EnabledHPictureSource;
            BotInfo.EnabledBeautyPictureSource = EnabledBeautyPictureSource;
            BotInfo.HPictureDefaultSource = cboHPictureDefaultSource.SelectedIndex;
            BotInfo.HPictureCmd = txbHPictureCmd.Text;
            BotInfo.HPictureOnceMessageMaxImageCount = string.IsNullOrEmpty(txbHPictureOnceMessageMaxImageCount.Text) ? 10 : Convert.ToInt32(txbHPictureOnceMessageMaxImageCount.Text);
            BotInfo.RevokeBeautyPicture = chkRevokeBeautyPicture.Checked;
            List<string> tempHPictureUserCmd = new List<string>();
            foreach (ListViewItem item in lstHPictureUserCmd.Items)
                tempHPictureUserCmd.Add(item.SubItems[0].Text);
            BotInfo.HPictureUserCmd = tempHPictureUserCmd;
            List<string> tempShieldingWords = new List<string>();
            foreach (ListViewItem item in lstShieldingWords.Items)
                tempShieldingWords.Add(item.SubItems[0].Text);
            BotInfo.HPictureShieldingWords = tempShieldingWords;
            List<long> tempHPictureWhiteGroup = new List<long>();
            foreach (ListViewItem item in lstHPictureWhiteGroup.Items)
                tempHPictureWhiteGroup.Add(Convert.ToInt64(item.SubItems[0].Text));
            BotInfo.HPictureWhiteGroup = tempHPictureWhiteGroup;
            BotInfo.HPictureWhiteOnly = chkHPictureWhiteOnly.Checked;
            BotInfo.HPictureAllowR18 = chkHPictureAllowR18.Checked;
            BotInfo.HPictureR18WhiteOnly = chkHPictureR18WhiteOnly.Checked;
            BotInfo.HPictureAllowPM = chkHPictureAllowPM.Checked;
            BotInfo.HPictureSize1200 = chkHPictureSize1200.Checked;
            BotInfo.HPictureLimit = string.IsNullOrEmpty(txbHPictureLimit.Text) ? 0 : Convert.ToInt32(txbHPictureLimit.Text);
            BotInfo.HPicturePMNoLimit = chkHPicturePMNoLimit.Checked;
            BotInfo.HPictureAdminNoLimit = chkHPictureAdminNoLimit.Checked;
            BotInfo.HPictureCD = string.IsNullOrEmpty(txbHPictureCD.Text) ? 0 : Convert.ToInt32(txbHPictureCD.Text);
            BotInfo.HPictureRevoke = string.IsNullOrEmpty(txbHPictureRevoke.Text) ? 0 : Convert.ToInt32(txbHPictureRevoke.Text);
            BotInfo.HPictureWhiteCD = string.IsNullOrEmpty(txbHPictureWhiteCD.Text) ? 0 : Convert.ToInt32(txbHPictureWhiteCD.Text);
            BotInfo.HPictureWhiteRevoke = string.IsNullOrEmpty(txbHPictureWhiteRevoke.Text) ? 0 : Convert.ToInt32(txbHPictureWhiteRevoke.Text);
            BotInfo.HPicturePMCD = string.IsNullOrEmpty(txbHPicturePMCD.Text) ? 0 : Convert.ToInt32(txbHPicturePMCD.Text);
            BotInfo.HPicturePMRevoke = string.IsNullOrEmpty(txbHPicturePMRevoke.Text) ? 0 : Convert.ToInt32(txbHPicturePMRevoke.Text);
            BotInfo.HPictureDownloadingReply = txbHPictureDownloadingReply.Text;
            BotInfo.HPictureCDUnreadyReply = txbHPictureCDUnreadyReply.Text;
            BotInfo.HPictureOutOfLimitReply = txbHPictureOutOfLimitReply.Text;
            BotInfo.HPictureErrorReply = txbHPictureErrorReplyReply.Text;
            BotInfo.HPictureNoResultReply = txbHPictureNoResultReply.Text;
            BotInfo.HPictureDownloadFailReply = txbDownloadFailReply.Text;
            BotInfo.HPictureLimitType = rdoHPictureLimitFrequency.Checked ? LimitType.Frequency : LimitType.Count;
            BotInfo.HPictureWhiteNoLimit = chkHPictureWhiteNoLimit.Checked;
            BotInfo.HPictureSendUrl = chkHPictureSendUrl.Checked;
            BotInfo.HPictureSendProxyUrl = chkHPictureSendProxyUrl.Checked;
            BotInfo.HPictureSendTitle = chkHPictureSendTitle.Checked;
            BotInfo.HPictureSendTags = chkHPictureSendTags.Checked;
            BotInfo.HPictureSendByForward = chkHPictureSendByForward.Checked;
        }

        public void UpdateCache()
        {
        }

        private void lnkResetHPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txbHPictureCmd.Text = BotInfo.DefaultHPictureCmd;
            chkHPictureEnabledLoliconSource.Checked = true;
            chkHPictureYande_reSource.Checked = true;
        }

        private void AddItemToListView(ListView listView, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                foreach (ListViewItem item in listView.Items)
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        if (subItem.Text == value)
                            return;
                listView.Items.Add(value);
            }
        }

        private void RemoveItemFromListView(ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }

        private void btnAddUserHPictureCmd_Click(object sender, EventArgs e) => AddItemToListView(lstHPictureUserCmd, txbUserHPictureCmd.Text);

        private void btnAddWhiteGroup_Click(object sender, EventArgs e) => AddItemToListView(lstHPictureWhiteGroup, txbWhiteGroup.Text);

        private void btnRemoveUserHPictureCmd_Click(object sender, EventArgs e) => RemoveItemFromListView(lstHPictureUserCmd);

        private void btnRemoveWhiteGroup_Click(object sender, EventArgs e) => RemoveItemFromListView(lstHPictureWhiteGroup);

        private void btnAddShieldingWords_Click(object sender, EventArgs e) => AddItemToListView(lstShieldingWords, txbShieldingWords.Text);

        private void btnRemoveShieldingWords_Click(object sender, EventArgs e) => RemoveItemFromListView(lstShieldingWords);
    }
}
