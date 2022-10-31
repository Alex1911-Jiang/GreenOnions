using System.Diagnostics;
using GreenOnions.BotMain;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using GreenOnions.Utility.Items;

namespace GreenOnions.BotManagerWindows
{
    public partial class FrmAppSetting : Form
    {
        public FrmAppSetting() => InitializeComponent();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

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

            #region -- 通用设置 --

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

            #endregion -- 通用设置 --

            #region -- 搜图设置 --
            chkSearchPictureEnabled.Checked = BotInfo.SearchEnabled;  //是否启用搜图功能
            pnlSearchPicture.LoadConfig();
            #endregion -- 搜图设置 --

            #region -- 下载原图设置 --
            chkOriginalPictureEnabled.Checked = BotInfo.OriginalPictureEnabled;
            pnlOriginalPicture.LoadConfig();
            #endregion -- 下载原图设置 --

            #region -- 翻译设置 --

            chkTranslateEnabled.Checked = BotInfo.TranslateEnabled;
            cboTranslateEngine.SelectedIndex = (int)BotInfo.TranslateEngineType;
            txbTranslateToChinese.Text = BotInfo.TranslateToChineseCMD;
            txbTranslateTo.Text = BotInfo.TranslateToCMD;
            txbTranslateFromToCMD.Text = BotInfo.TranslateFromToCMD;

            foreach (long item in BotInfo.AutoTranslateGroupMemoriesQQ)
                lstAutoTranslateGroupMemoriesQQ.Items.Add(item.ToString());

            #endregion -- 翻译设置 --

            #region -- 色图设置 --
            chkHPictureEnabled.Checked = BotInfo.HPictureEnabled;
            pnlHPicture.LoadConfig();
            #endregion -- 色图设置 --

            #region -- 复读设置 --
            chkRandomRepeat.Checked = BotInfo.RandomRepeatEnabled;
            txbRandomRepeatProbability.Text = BotInfo.RandomRepeatProbability.ToString();
            chkSuccessiveRepeat.Checked = BotInfo.SuccessiveRepeatEnabled;
            txbSuccessiveRepeatCount.Text = BotInfo.SuccessiveRepeatCount.ToString();
            chkRewindGif.Checked = BotInfo.RewindGifEnabled;
            txbRewindGifProbability.Text = BotInfo.RewindGifProbability.ToString();
            chkHorizontalMirrorImage.Checked = BotInfo.HorizontalMirrorImageEnabled;
            txbHorizontalMirrorImageProbability.Text = BotInfo.HorizontalMirrorImageProbability.ToString();
            chkVerticalMirrorImage.Checked = BotInfo.VerticalMirrorImageEnabled;
            chkReplaceMeToYou.Checked = BotInfo.ReplaceMeToYou;
            txbVerticalMirrorImageProbability.Text = BotInfo.VerticalMirrorImageProbability.ToString();
            #endregion -- 复读设置 --

            #region -- 进/退群消息设置 --
            chkSendMemberJoinedMessage.Checked = BotInfo.SendMemberJoinedMessage;
            chkSendMemberPositiveLeaveMessage.Checked = BotInfo.SendMemberPositiveLeaveMessage;
            chkSendMemberBeKickedMessage.Checked = BotInfo.SendMemberBeKickedMessage;
            txbMemberJoinedMessage.Text = BotInfo.MemberJoinedMessage;
            txbMemberPositiveLeaveMessage.Text = BotInfo.MemberPositiveLeaveMessage;
            txbMemberBeKickedMessage.Text = BotInfo.MemberBeKickedMessage;
            #endregion  -- 进/退群消息设置 --

            #region -- 伪造消息 --

            chkEnabledForgeMessage.Checked = BotInfo.ForgeMessageEnabled;
            txbForgeMessageCmdBegin.Text = BotInfo.ForgeMessageCmdBegin;
            txbForgeMessageCmdNewLine.Text = BotInfo.ForgeMessageCmdNewLine;
            chkForgeMessageAppendBotMessageEnabled.Checked = BotInfo.ForgeMessageAppendBotMessageEnabled;
            chkForgeMessageAdminOnly.Checked = BotInfo.ForgeMessageAdminOnly;
            chkForgeMessageAdminDontAppend.Checked = BotInfo.ForgeMessageAdminDontAppend;
            txbForgeMessageAppendMessage.Text = BotInfo.ForgeMessageAppendMessage;
            chkRefuseForgeAdmin.Checked = BotInfo.RefuseForgeAdmin;
            txbRefuseForgeAdminReply.Text = BotInfo.RefuseForgeAdminReply;
            chkRefuseForgeBot.Checked = BotInfo.RefuseForgeBot;
            txbRefuseForgeBotReply.Text = BotInfo.RefuseForgeBotReply;

            #endregion -- 伪造消息 --

            #region -- RSS --
            chkRssEnabled.Checked = BotInfo.RssEnabled;
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
            #endregion  -- RSS --

            if (tabSettings.Width > Width || tabSettings.Height > Height)
                ResetCtrlSize();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            #region -- 通用设置 --
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

            #endregion -- 通用设置 --

            #region -- 搜图设置 --
            BotInfo.SearchEnabled = chkSearchPictureEnabled.Checked;  //是否启用搜图功能
            pnlSearchPicture.SaveConfig();
            #region -- 腾讯云相关设置 --
            BotInfo.CheckPornEnabled = chkCheckPornEnabled.Checked;  //是否启用腾讯云鉴黄
            BotInfo.TencentCloudAPPID = txbTencentCloudAPPID.Text;
            BotInfo.TencentCloudRegion = txbTencentCloudRegion.Text;
            BotInfo.TencentCloudSecretId = txbTencentCloudSecretId.Text;
            BotInfo.TencentCloudSecretKey = txbTencentCloudSecretKey.Text;
            BotInfo.TencentCloudBucket = txbTencentCloudBucket.Text;
            #endregion -- 腾讯云相关设置 --
            #endregion -- 搜图设置 --

            #region -- 下载原图设置 --
            BotInfo.OriginalPictureEnabled = chkOriginalPictureEnabled.Checked;
            pnlOriginalPicture.SaveConfig();
            #endregion -- 下载原图设置 --

            #region -- 翻译设置 --

            BotInfo.TranslateEnabled = chkTranslateEnabled.Checked;
            BotInfo.TranslateEngineType = (TranslateEngine)cboTranslateEngine.SelectedIndex;
            BotInfo.TranslateToChineseCMD = txbTranslateToChinese.Text;
            BotInfo.TranslateToCMD = txbTranslateTo.Text;
            BotInfo.TranslateFromToCMD = txbTranslateFromToCMD.Text;

            List<long> tempAutoTranslateGroupMemoriesQQ = new List<long>();
            foreach (ListViewItem item in lstAutoTranslateGroupMemoriesQQ.Items)
            {
                tempAutoTranslateGroupMemoriesQQ.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.AutoTranslateGroupMemoriesQQ = tempAutoTranslateGroupMemoriesQQ;

            #endregion  -- 翻译设置 --

            #region -- 色图设置 --
            BotInfo.HPictureEnabled = chkHPictureEnabled.Checked;
            pnlHPicture.SaveConfig();
            #endregion -- 色图设置 --

            #region -- 复读设置 --
            BotInfo.RandomRepeatEnabled = chkRandomRepeat.Checked;
            BotInfo.RandomRepeatProbability = string.IsNullOrEmpty(txbRandomRepeatProbability.Text) ? 0 : Convert.ToInt32(txbRandomRepeatProbability.Text);
            BotInfo.SuccessiveRepeatEnabled = chkSuccessiveRepeat.Checked;
            BotInfo.SuccessiveRepeatCount = string.IsNullOrEmpty(txbSuccessiveRepeatCount.Text) ? 0 : Convert.ToInt32(txbSuccessiveRepeatCount.Text);
            BotInfo.RewindGifEnabled = chkRewindGif.Checked;
            BotInfo.RewindGifProbability = Convert.ToInt32(txbRewindGifProbability.Text);
            BotInfo.HorizontalMirrorImageEnabled = chkHorizontalMirrorImage.Checked;
            BotInfo.HorizontalMirrorImageProbability = string.IsNullOrEmpty(txbHorizontalMirrorImageProbability.Text) ? 0 : Convert.ToInt32(txbHorizontalMirrorImageProbability.Text);
            BotInfo.VerticalMirrorImageEnabled = chkVerticalMirrorImage.Checked;
            BotInfo.ReplaceMeToYou = chkReplaceMeToYou.Checked;
            BotInfo.VerticalMirrorImageProbability = string.IsNullOrEmpty(txbVerticalMirrorImageProbability.Text) ? 0 : Convert.ToInt32(txbVerticalMirrorImageProbability.Text);
            #endregion -- 复读设置 --

            #region -- 进/退群消息设置 --

            BotInfo.SendMemberJoinedMessage = chkSendMemberJoinedMessage.Checked;
            BotInfo.SendMemberPositiveLeaveMessage = chkSendMemberPositiveLeaveMessage.Checked;
            BotInfo.SendMemberBeKickedMessage = chkSendMemberBeKickedMessage.Checked;
            BotInfo.MemberJoinedMessage = txbMemberJoinedMessage.Text;
            BotInfo.MemberPositiveLeaveMessage = txbMemberPositiveLeaveMessage.Text;
            BotInfo.MemberBeKickedMessage = txbMemberBeKickedMessage.Text;

            #endregion  -- 进/退群消息设置 --

            #region -- 伪造消息 --

            BotInfo.ForgeMessageEnabled = chkEnabledForgeMessage.Checked;
            BotInfo.ForgeMessageCmdBegin = txbForgeMessageCmdBegin.Text;
            BotInfo.ForgeMessageCmdNewLine = txbForgeMessageCmdNewLine.Text;
            BotInfo.ForgeMessageAppendBotMessageEnabled = chkForgeMessageAppendBotMessageEnabled.Checked;
            BotInfo.ForgeMessageAdminOnly = chkForgeMessageAdminOnly.Checked;
            BotInfo.ForgeMessageAdminDontAppend = chkForgeMessageAdminDontAppend.Checked;
            BotInfo.ForgeMessageAppendMessage = txbForgeMessageAppendMessage.Text;
            BotInfo.RefuseForgeAdmin = chkRefuseForgeAdmin.Checked;
            BotInfo.RefuseForgeAdminReply = txbRefuseForgeAdminReply.Text;
            BotInfo.RefuseForgeBot = chkRefuseForgeBot.Checked;
            BotInfo.RefuseForgeBotReply = txbRefuseForgeBotReply.Text;

            #endregion -- 伪造消息 --

            #region -- RSS --

            BotInfo.RssEnabled = chkRssEnabled.Checked;
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

            #endregion -- RSS --

            ConfigHelper.SaveConfigFile();

            pnlSearchPicture.UpdateCache();

            string regexMsg = MessageHandler.UpdateRegexs();
            if (regexMsg == null)
                Close();
            else
                MessageBox.Show($"应用{regexMsg}命令失败，请检查命令的正则表达式格式。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            WorkingTimeRecorder.UpdateWorkingTime();
        }

        private void txbForgeMessageCmd_TextChanged(object? sender, EventArgs e)
        {
            txbForgeMessageCmdBegin.TextChanged -= txbForgeMessageCmd_TextChanged;
            txbForgeMessageCmd.Text = $"{txbForgeMessageCmdBegin.Text}<@QQ><伪造内容>";
            txbForgeMessageCmdBegin.TextChanged += txbForgeMessageCmd_TextChanged;
        }

        private void chkEnableHPicture_CheckedChanged(object sender, EventArgs e) => pnlHPicture.Enabled = chkHPictureEnabled.Checked;

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

        private void chkSearchPictureEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchPicture.Enabled = chkSearchPictureEnabled.Checked;

        private void chkCheckPorn_CheckedChanged(object sender, EventArgs e) => pnlCheckPorn.Enabled = chkCheckPornEnabled.Checked;

        private void lnkContributorGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", (sender as Control).Text);
        }


        #region -- 添加或移除ListView --

        private void btnAddAdmin_Click(object sender, EventArgs e) => AddItemToListView(lstAdmins, txbAddAdmin.Text);

        private void btnAddBanGroup_Click(object sender, EventArgs e) => AddItemToListView(lstBannedGroup, txbBanGroup.Text);

        private void btnAddBanUser_Click(object sender, EventArgs e) => AddItemToListView(lstBannedUser, txbBanUser.Text);
        
        private void btnAddDebugGroup_Click(object sender, EventArgs e) => AddItemToListView(lstDebugGroups, txbAddDebugGroup.Text);

        private void btnRemoveAdmin_Click(object sender, EventArgs e) => RemoveItemFromListView(lstAdmins);

        private void btnRemoveBanGroup_Click(object sender, EventArgs e) => RemoveItemFromListView(lstBannedGroup);

        private void btnRemoveBanUser_Click(object sender, EventArgs e) => RemoveItemFromListView(lstBannedUser);

        private void btnRemoveDebugGroup_Click(object sender, EventArgs e) => RemoveItemFromListView(lstDebugGroups);

        private void btnAddAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => AddItemToListView(lstAutoTranslateGroupMemoriesQQ, txbAddAutoTranslateGroupMemoryQQ.Text);

        private void btnRemoveAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => RemoveItemFromListView(lstAutoTranslateGroupMemoriesQQ);

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

        #endregion -- 添加或移除ListView --

        private void chkDebugMode_CheckedChanged(object sender, EventArgs e) => pnlDebugMode.Enabled = chkDebugMode.Checked;

        private void chkEnabledForgeMessage_CheckedChanged(object sender, EventArgs e) => pnlForgeMessage.Enabled = chkEnabledForgeMessage.Checked;


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

        private void PnlRssSubscriptionList_ControlChanged(object sender, ControlEventArgs e) => ComputeRssItemWidth();

        private void pnlRssSubscriptionList_SizeChanged(object sender, EventArgs e) => ComputeRssItemWidth();

        private void ComputeRssItemWidth()
        {
            RssItemCtrlWidth = pnlRssSubscriptionList.Controls.Count * btnAddRssSubscription.Height + pnlRssSubscriptionList.Controls.Count * btnAddRssSubscription.Margin.Top * 2 + btnAddRssSubscription.Margin.Top - 1 > pnlRssSubscriptionList.Height ? pnlRssSubscriptionList.Width - 25 : pnlRssSubscriptionList.Width - 8;
            foreach (Control item in pnlRssSubscriptionList.Controls)
                item.Width = RssItemCtrlWidth;
        }
        #endregion -- RSS --

        private void cboTranslateEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbTranslateTo.Enabled = cboTranslateEngine.SelectedIndex == (int)TranslateEngine.Google;
            BotInfo.TranslateEngineType = (TranslateEngine)cboTranslateEngine.SelectedIndex;
        }

        private void chkRssEnabled_CheckedChanged(object sender, EventArgs e) => pnlRss.Enabled = chkRssEnabled.Checked;


        private void chkOriginalPictureEnabled_CheckedChanged(object sender, EventArgs e) => pnlOriginalPicture.Enabled = chkOriginalPictureEnabled.Checked;

        private void chkTranslateEnabled_CheckedChanged(object sender, EventArgs e) => pnlTranslate.Enabled = chkTranslateEnabled.Checked;

        private void chkAutoConnectEnabled_CheckedChanged(object sender, EventArgs e) => pnlAutoConnect.Enabled = chkAutoConnectEnabled.Checked;

        private void chkWorkingTimeEnabled_CheckedChanged(object sender, EventArgs e) => pnlWorkingTime.Enabled = chkWorkingTimeEnabled.Checked;

        private void lnkJoinGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("explorer.exe", "https://jq.qq.com/?_wv=1027&k=rJ7RA3SF");

        private void btnResetCtrlSize_Click(object sender, EventArgs e)
        {
            ResetCtrlSize();
        }

        private void ResetCtrlSize()
        {
            tabSettings.Size = new Size(Width - 50, Height - 100);
            tabSettings.Location = new Point(13, 13);
            btnOk.Location = new Point(Width / 2 - btnOk.Width / 2, Height - btnOk.Height - 50);
            btnOk.BringToFront();
        }
    }
}
