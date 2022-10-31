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
            txbBotName.Text = BotInfo.BotName;

            foreach (var item in BotInfo.AdminQQ)
            {
                lstAdmins.Items.Add(item.ToString());
            }

            foreach (long item in BotInfo.BannedGroup)
            {
                lstBannedGroup.Items.Add(item.ToString());
            }

            foreach (var item in BotInfo.BannedUser)
            {
                lstBannedUser.Items.Add(item.ToString());
            }

            chkDebugMode.Checked = BotInfo.DebugMode;
            foreach (var item in BotInfo.DebugGroups)
            {
                lstDebugGroups.Items.Add(item.ToString());
            }
            chkOnlyReplyDebugGroup.Checked = BotInfo.OnlyReplyDebugGroup;
            chkDebugReplyAdminOnly.Checked = BotInfo.DebugReplyAdminOnly;
            chkHttpRequestByWebBrowser.Checked = BotInfo.HttpRequestByWebBrowser;
            chkDownloadImage4Caching.Checked = BotInfo.DownloadImage4Caching;
            chkSendImageByFile.Checked = BotInfo.SendImageByFile;
            chkCheckPornEnabled.Checked = BotInfo.CheckPornEnabled; //是否启用腾讯云鉴黄

            #region -- 腾讯云相关设置 --
            txbTencentCloudAPPID.Text = BotInfo.TencentCloudAPPID;
            txbTencentCloudRegion.Text = BotInfo.TencentCloudRegion;
            txbTencentCloudSecretId.Text = BotInfo.TencentCloudSecretId;
            txbTencentCloudSecretKey.Text = BotInfo.TencentCloudSecretKey;
            txbTencentCloudBucket.Text = BotInfo.TencentCloudBucket;
            #endregion -- 腾讯云相关设置 --

            chkAutoConnectEnabled.Checked = BotInfo.AutoConnectEnabled;
            cboAutoConnectProtocol.SelectedIndex = BotInfo.AutoConnectProtocol;
            txbAutoConnectDelay.Text = BotInfo.AutoConnectDelay.ToString();
            cboPixivProxy.Text = BotInfo.PixivProxy;

            chkWorkingTimeEnabled.Checked = BotInfo.WorkingTimeEnabled;
            cboWorkingTimeFromHour.SelectedIndex = BotInfo.WorkingTimeFromHour;
            cboWorkingTimeFromMinute.SelectedIndex = BotInfo.WorkingTimeFromMinute;
            cboWorkingTimeToHour.SelectedIndex = BotInfo.WorkingTimeToHour;
            cboWorkingTimeToMinute.SelectedIndex = BotInfo.WorkingTimeToMinute;

            cboLogLevel.SelectedIndex = BotInfo.LogLevel;
            cboReplaceImgRoute.SelectedIndex = BotInfo.ReplaceImgRoute;
        }

        public void SaveConfig()
        {
            BotInfo.BotName = txbBotName.Text.Trim();
            List<long> tempAdminQQ = new List<long>();
            foreach (ListViewItem item in lstAdmins.Items)
            {
                tempAdminQQ.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.AdminQQ = tempAdminQQ;
            List<long> tempBannedGroup = new List<long>();
            foreach (ListViewItem item in lstBannedGroup.Items)
            {
                tempBannedGroup.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.BannedGroup = tempBannedGroup;
            List<long> tempBannedUser = new List<long>();
            foreach (ListViewItem item in lstBannedUser.Items)
            {
                tempBannedUser.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.BannedUser = tempBannedUser;

            BotInfo.DebugMode = chkDebugMode.Checked;
            List<long> tempDebugGroups = new List<long>();
            foreach (ListViewItem item in lstDebugGroups.Items)
            {
                tempDebugGroups.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.DebugGroups = tempDebugGroups;
            BotInfo.OnlyReplyDebugGroup = chkOnlyReplyDebugGroup.Checked;
            BotInfo.DebugReplyAdminOnly = chkDebugReplyAdminOnly.Checked;
            BotInfo.HttpRequestByWebBrowser = chkHttpRequestByWebBrowser.Checked;
            BotInfo.DownloadImage4Caching = chkDownloadImage4Caching.Checked;
            BotInfo.SendImageByFile = chkSendImageByFile.Checked;

            BotInfo.AutoConnectEnabled = chkAutoConnectEnabled.Checked;
            BotInfo.AutoConnectProtocol = cboAutoConnectProtocol.SelectedIndex;
            BotInfo.ReplaceImgRoute = cboReplaceImgRoute.SelectedIndex;
            BotInfo.PixivProxy = cboPixivProxy.Text;

            BotInfo.WorkingTimeEnabled = chkWorkingTimeEnabled.Checked;
            BotInfo.WorkingTimeFromHour = cboWorkingTimeFromHour.SelectedIndex;
            BotInfo.WorkingTimeFromMinute = cboWorkingTimeFromMinute.SelectedIndex;
            BotInfo.WorkingTimeToHour = cboWorkingTimeToHour.SelectedIndex;
            BotInfo.WorkingTimeToMinute = cboWorkingTimeToMinute.SelectedIndex;

            BotInfo.AutoConnectDelay = Convert.ToInt32(txbAutoConnectDelay.Text);
            BotInfo.LogLevel = cboLogLevel.SelectedIndex;

            #region -- 腾讯云相关设置 --
            BotInfo.CheckPornEnabled = chkCheckPornEnabled.Checked;  //是否启用腾讯云鉴黄
            BotInfo.TencentCloudAPPID = txbTencentCloudAPPID.Text;
            BotInfo.TencentCloudRegion = txbTencentCloudRegion.Text;
            BotInfo.TencentCloudSecretId = txbTencentCloudSecretId.Text;
            BotInfo.TencentCloudSecretKey = txbTencentCloudSecretKey.Text;
            BotInfo.TencentCloudBucket = txbTencentCloudBucket.Text;
            #endregion -- 腾讯云相关设置 --
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
