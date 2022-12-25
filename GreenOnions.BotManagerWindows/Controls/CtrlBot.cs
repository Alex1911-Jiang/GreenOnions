using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlBot : UserControl, IConfigSetting
    {
        public CtrlBot()
        {
            InitializeComponent();

            for (int i = 0; i < 24; i++)
            {
                cboWorkingTimeFromHour.Items.Add(i);
                cboWorkingTimeToHour.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                cboWorkingTimeFromMinute.Items.Add(i);
                cboWorkingTimeToMinute.Items.Add(i);
            }
        }

        public void LoadConfig()
        {
            txbBotName.Text = BotInfo.Config.BotName;

            foreach (var item in BotInfo.Config.AdminQQ)
            {
                lstAdmins.Items.Add(item.ToString());
            }

            foreach (long item in BotInfo.Config.BannedGroup)
            {
                lstBannedGroup.Items.Add(item.ToString());
            }

            foreach (var item in BotInfo.Config.BannedUser)
            {
                lstBannedUser.Items.Add(item.ToString());
            }

            chkLeaveGroupAfterBeMushin.Checked = BotInfo.Config.LeaveGroupAfterBeMushin;

            chkDebugMode.Checked = BotInfo.Config.DebugMode;
            foreach (var item in BotInfo.Config.DebugGroups)
            {
                lstDebugGroups.Items.Add(item.ToString());
            }
            chkOnlyReplyDebugGroup.Checked = BotInfo.Config.OnlyReplyDebugGroup;
            chkDebugReplyAdminOnly.Checked = BotInfo.Config.DebugReplyAdminOnly;
            chkHttpRequestByWebBrowser.Checked = BotInfo.Config.HttpRequestByWebBrowser;
            chkDownloadImage4Caching.Checked = BotInfo.Config.DownloadImage4Caching;
            chkSendImageByFile.Checked = BotInfo.Config.SendImageByFile;
            chkCheckPornEnabled.Checked = BotInfo.Config.CheckPornEnabled; //是否启用腾讯云鉴黄

            #region -- 腾讯云相关设置 --
            txbTencentCloudAPPID.Text = BotInfo.Config.TencentCloudAPPID;
            txbTencentCloudRegion.Text = BotInfo.Config.TencentCloudRegion;
            txbTencentCloudSecretId.Text = BotInfo.Config.TencentCloudSecretId;
            txbTencentCloudSecretKey.Text = BotInfo.Config.TencentCloudSecretKey;
            txbTencentCloudBucket.Text = BotInfo.Config.TencentCloudBucket;
            #endregion -- 腾讯云相关设置 --

            //chkAutoConnectEnabled.Checked = BotInfo.Config.AutoConnectEnabled;
            //cboAutoConnectProtocol.SelectedIndex = BotInfo.Config.AutoConnectProtocol;
            txbAutoConnectDelay.Text = BotInfo.Config.AutoConnectDelay.ToString();
            cboPixivProxy.Text = BotInfo.Config.PixivProxy;

            chkWorkingTimeEnabled.Checked = BotInfo.Config.WorkingTimeEnabled;
            cboWorkingTimeFromHour.SelectedIndex = BotInfo.Config.WorkingTimeFromHour;
            cboWorkingTimeFromMinute.SelectedIndex = BotInfo.Config.WorkingTimeFromMinute;
            cboWorkingTimeToHour.SelectedIndex = BotInfo.Config.WorkingTimeToHour;
            cboWorkingTimeToMinute.SelectedIndex = BotInfo.Config.WorkingTimeToMinute;

            cboLogLevel.SelectedIndex = BotInfo.Config.LogLevel;
            cboReplaceImgRoute.SelectedIndex = BotInfo.Config.ReplaceImgRoute;

            chkSplitTextAndImageMessage.Checked = BotInfo.Config.SplitTextAndImageMessage;
        }

        public void SaveConfig()
        {
            BotInfo.Config.BotName = txbBotName.Text.Trim();
            HashSet<long> tempAdminQQ = new HashSet<long>();
            foreach (ListViewItem item in lstAdmins.Items)
            {
                tempAdminQQ.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.Config.AdminQQ = tempAdminQQ;
            HashSet<long> tempBannedGroup = new HashSet<long>();
            foreach (ListViewItem item in lstBannedGroup.Items)
            {
                tempBannedGroup.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.Config.BannedGroup = tempBannedGroup;
            HashSet<long> tempBannedUser = new HashSet<long>();
            foreach (ListViewItem item in lstBannedUser.Items)
            {
                tempBannedUser.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.Config.BannedUser = tempBannedUser;

            BotInfo.Config.LeaveGroupAfterBeMushin = chkLeaveGroupAfterBeMushin.Checked;

            BotInfo.Config.DebugMode = chkDebugMode.Checked;
            HashSet<long> tempDebugGroups = new HashSet<long>();
            foreach (ListViewItem item in lstDebugGroups.Items)
            {
                tempDebugGroups.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.Config.DebugGroups = tempDebugGroups;
            BotInfo.Config.OnlyReplyDebugGroup = chkOnlyReplyDebugGroup.Checked;
            BotInfo.Config.DebugReplyAdminOnly = chkDebugReplyAdminOnly.Checked;
            BotInfo.Config.HttpRequestByWebBrowser = chkHttpRequestByWebBrowser.Checked;
            BotInfo.Config.DownloadImage4Caching = chkDownloadImage4Caching.Checked;
            BotInfo.Config.SendImageByFile = chkSendImageByFile.Checked;

            //BotInfo.Config.AutoConnectEnabled = chkAutoConnectEnabled.Checked;
            //BotInfo.Config.AutoConnectProtocol = cboAutoConnectProtocol.SelectedIndex;
            BotInfo.Config.ReplaceImgRoute = cboReplaceImgRoute.SelectedIndex;
            BotInfo.Config.PixivProxy = cboPixivProxy.Text;

            BotInfo.Config.WorkingTimeEnabled = chkWorkingTimeEnabled.Checked;
            BotInfo.Config.WorkingTimeFromHour = cboWorkingTimeFromHour.SelectedIndex;
            BotInfo.Config.WorkingTimeFromMinute = cboWorkingTimeFromMinute.SelectedIndex;
            BotInfo.Config.WorkingTimeToHour = cboWorkingTimeToHour.SelectedIndex;
            BotInfo.Config.WorkingTimeToMinute = cboWorkingTimeToMinute.SelectedIndex;

            BotInfo.Config.AutoConnectDelay = Convert.ToInt32(txbAutoConnectDelay.Text);
            BotInfo.Config.LogLevel = cboLogLevel.SelectedIndex;

            #region -- 腾讯云相关设置 --
            BotInfo.Config.CheckPornEnabled = chkCheckPornEnabled.Checked;  //是否启用腾讯云鉴黄
            BotInfo.Config.TencentCloudAPPID = txbTencentCloudAPPID.Text;
            BotInfo.Config.TencentCloudRegion = txbTencentCloudRegion.Text;
            BotInfo.Config.TencentCloudSecretId = txbTencentCloudSecretId.Text;
            BotInfo.Config.TencentCloudSecretKey = txbTencentCloudSecretKey.Text;
            BotInfo.Config.TencentCloudBucket = txbTencentCloudBucket.Text;
            #endregion -- 腾讯云相关设置 --

            BotInfo.Config.SplitTextAndImageMessage = chkSplitTextAndImageMessage.Checked;
        }

        public void UpdateCache()
        {

        }

        private void checkNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
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
                    if (long.TryParse(Clipboard.GetText().Trim(), out long num))  //检查是否数字
                        ((TextBox)sender).SelectedText = num.ToString();//Ctrl+V 粘贴
                    e.Handled = true;
                }
            }
        }

        #region -- 添加或移除ListView --

        private void chkCheckPorn_CheckedChanged(object sender, EventArgs e) => pnlCheckPorn.Enabled = chkCheckPornEnabled.Checked;

        private void btnAddAdmin_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstAdmins, txbAddAdmin.Text);

        private void btnAddBanGroup_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstBannedGroup, txbBanGroup.Text);

        private void btnAddBanUser_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstBannedUser, txbBanUser.Text);

        private void btnAddDebugGroup_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstDebugGroups, txbAddDebugGroup.Text);

        private void btnRemoveAdmin_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstAdmins);

        private void btnRemoveBanGroup_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstBannedGroup);

        private void btnRemoveBanUser_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstBannedUser);

        private void btnRemoveDebugGroup_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstDebugGroups);

        private void chkDebugMode_CheckedChanged(object sender, EventArgs e) => pnlDebugMode.Enabled = chkDebugMode.Checked;

        private void chkAutoConnectEnabled_CheckedChanged(object sender, EventArgs e) => pnlAutoConnect.Enabled = chkAutoConnectEnabled.Checked;

        private void chkWorkingTimeEnabled_CheckedChanged(object sender, EventArgs e) => pnlWorkingTime.Enabled = chkWorkingTimeEnabled.Checked;

        #endregion -- 添加或移除ListView --
    }
}
