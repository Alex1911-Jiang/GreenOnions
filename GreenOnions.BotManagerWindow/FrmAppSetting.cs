using GreenOnions.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GreenOnions.BotMainManagerWindow
{
    public partial class FrmAppSetting : Form
    {
        public FrmAppSetting() => InitializeComponent();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            #region -- 通用设置 --

            txbBotName.Text = BotInfo.BotName;
            chkImageCache.Checked = BotInfo.ImageCache;

            if (BotInfo.AdminQQ != null)
            {
                foreach (var item in BotInfo.AdminQQ)
                {
                    lstAdmins.Items.Add(item.ToString());
                }
            }
            if (BotInfo.BannedGroup != null)
            {
                foreach (long item in BotInfo.BannedGroup)
                {
                    lstBannedGroup.Items.Add(item.ToString());
                }
            }
            if (BotInfo.BannedUser != null)
            {
                foreach (var item in BotInfo.BannedUser)
                {
                    lstBannedUser.Items.Add(item.ToString());
                }
            }

            #endregion -- 通用设置 --

            #region -- 搜图设置 --
            chkSearchPictureEnabled.Checked = BotInfo.SearchEnabled;  //是否启用搜图功能
            chkSearchSauceNAOEnabled.Checked = BotInfo.SearchEnabledSauceNao;  //SauceNao Api-Key
            txbSauceNAOApiKey.Text = BotInfo.SauceNAOApiKey;
            chkSearchASCII2DEnabled.Checked = BotInfo.SearchEnabledASCII2D;  //是否启用ASCII2D搜图
            txbSearchModeOnCmd.Text = BotInfo.SearchModeOnCmd;
            txbSearchModeOffCmd.Text = BotInfo.SearchModeOffCmd;
            txbSearchModeTimeOutReply.Text = BotInfo.SearchModeTimeOutReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchModeOnReply.Text = BotInfo.SearchModeOnReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchModeAlreadyOnReply.Text = BotInfo.SearchModeAlreadyOnReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchModeOffReply.Text = BotInfo.SearchModeOffReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchModeAlreadyOffReply.Text = BotInfo.SearchModeAlreadyOffReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchNoResultReply.Text = BotInfo.SearchNoResultReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchErrorReply.Text = BotInfo.SearchErrorReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchLowSimilarity.Text = BotInfo.SearchLowSimilarity.ToString();
            txbSearchLowSimilarityReply.Text = BotInfo.SearchLowSimilarityReply.Replace("\r", "\\r").Replace("\n", "\\n");
            chkCheckPorn.Checked = BotInfo.SearchCheckPornEnabled;  //是否启用腾讯云鉴黄
            txbSearchCheckPornIllegalReply.Text = BotInfo.SearchCheckPornIllegalReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbSearchCheckPornErrorReply.Text = BotInfo.SearchCheckPornErrorReply.Replace("\r", "\\r").Replace("\n", "\\n");
            #region -- 腾讯云相关设置 --
            txbTencentCloudAPPID.Text = BotInfo.TencentCloudAPPID;
            txbTencentCloudRegion.Text = BotInfo.TencentCloudRegion;
            txbTencentCloudSecretId.Text = BotInfo.TencentCloudSecretId;
            txbTencentCloudSecretKey.Text = BotInfo.TencentCloudSecretKey;
            txbTencentCloudBucket.Text = BotInfo.TencentCloudBucket;
            #endregion -- 腾讯云相关设置 --

            #endregion -- 搜图设置 --

            #region -- 翻译设置 --

            chkTranslateEnabled.Checked = BotInfo.TranslateEnabled;
            txbTranslateToChinese.Text = BotInfo.TranslateToChineseCMD;
            txbTranslateTo.Text = BotInfo.TranslateToCMD;

            #endregion -- 翻译设置 --

            #region -- 色图设置 --
            chkEnabledLoliconHPicture.Checked = BotInfo.EnabledLoliconDataBase;
            chkEnabledShabHPicture.Checked = BotInfo.EnabledShabDataBase;
            chkEnabledHPicture.Checked = BotInfo.HPictureEnabled;
            txbHPictureApiKey.Text = BotInfo.HPictureApiKey;
            txbHPictureCmd.Text = BotInfo.HPictureCmd;
            txbHPictureBegin.Text = BotInfo.HPictureBeginCmd;
            txbHPictureCount.Text = BotInfo.HPictureCountCmd;
            txbHPictureUnit.Text = BotInfo.HPictureUnitCmd;
            txbHPictureR18.Text = BotInfo.HPictureR18Cmd;
            txbHPictureKeyword.Text = BotInfo.HPictureKeywordCmd;
            txbHPictureEnd.Text = BotInfo.HPictureEndCmd;
            txbShabHPictureEnd.Text = BotInfo.ShabHPictureEndCmd;
            chkHPictureBeginNull.Checked = BotInfo.HPictureBeginCmdNull;
            chkHPictureCountNull.Checked = BotInfo.HPictureCountCmdNull;
            chkHPictureUnitNull.Checked = BotInfo.HPictureUnitCmdNull;
            chkHPictureR18Null.Checked = BotInfo.HPictureR18CmdNull;
            chkHPictureKeywordNull.Checked = BotInfo.HPictureKeywordCmdNull;
            chkHPictureEndNull.Checked = BotInfo.HPictureEndCmdNull;
            chkShabHPictureEndNull.Checked = BotInfo.ShabHPictureEndCmdNull;
            if (BotInfo.HPictureUserCmd != null)
            {
                foreach (var item in BotInfo.HPictureUserCmd)
                {
                    lstHPictureUserCmd.Items.Add(item);
                }
            }
            if (BotInfo.HPictureWhiteGroup != null)
            {
                foreach (var item in BotInfo.HPictureWhiteGroup)
                {
                    lstHPictureWhiteGroup.Items.Add(item.ToString());
                }
            }
            chkWhiteOnly.Checked = BotInfo.HPictureWhiteOnly;
            chkAllowR18.Checked = BotInfo.HPictureAllowR18;
            chkR18WhiteOnly.Checked = BotInfo.HPictureR18WhiteOnly;
            chkPM.Checked = BotInfo.HPictureAllowPM;
            chkAntiShielding.Checked = BotInfo.HPictureAntiShielding;
            chkSize1200.Checked = BotInfo.HPictureSize1200;
            chkDownloadAccelerate.Checked = BotInfo.EnabledAccelerate;
            txbDownloadAccelerateUrl.Text = BotInfo.AccelerateUrl;
            txbLimit.Text = BotInfo.HPictureLimit.ToString();
            chkPMNoLimit.Checked = BotInfo.HPicturePMNoLimit;
            chkAdminNoLimit.Checked = BotInfo.HPictureAdminNoLimit;
            chkManageNoLimit.Checked = BotInfo.HPictureManageNoLimit;
            chkWhiteNoLimit.Checked = BotInfo.HPictureWhiteNoLimit;
            txbCD.Text = BotInfo.HPictureCD.ToString();
            txbRevoke.Text = BotInfo.HPictureRevoke.ToString();
            txbWhiteCD.Text = BotInfo.HPictureWhiteCD.ToString();
            txbWhiteRevoke.Text = BotInfo.HPictureWhiteRevoke.ToString();
            txbPMCD.Text = BotInfo.HPicturePMCD.ToString();
            txbPMRevoke.Text = BotInfo.HPicturePMRevoke.ToString();
            txbCDUnreadyReply.Text = BotInfo.HPictureCDUnreadyReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbOutOfLimitReply.Text = BotInfo.HPictureOutOfLimitReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbHPictureErrorReplyReply.Text = BotInfo.HPictureErrorReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbHPictureNoResultReply.Text = BotInfo.HPictureNoResultReply.Replace("\r", "\\r").Replace("\n", "\\n");
            txbDownloadFailReply.Text = BotInfo.HPictureDownloadFailReply.Replace("\r", "\\r").Replace("\n", "\\n");
            if (BotInfo.HPictureLimitType == LimitType.Count)
            {
                rodHPictureLimitCount.Checked = true;
            }
            else
            {
                rdoHPictureLimitFrequency.Checked = true;
            }
            chkMultithreading.Checked = BotInfo.HPictureMultithreading;

            #endregion -- 色图设置 --

            pnlSearchPicture.Enabled = chkSearchPictureEnabled.Checked;
            txbSauceNAOApiKey.Enabled = chkSearchSauceNAOEnabled.Checked;
            pnlCheckPorn.Enabled = chkCheckPorn.Checked;
            pnlTranslate.Enabled = chkTranslateEnabled.Checked;
            pnlEnabelHPicture.Enabled = chkEnabledHPicture.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            #region -- 通用设置 --
            BotInfo.BotName = txbBotName.Text.Trim();
            BotInfo.ImageCache = chkImageCache.Checked;
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
            BotInfo.EnabledAccelerate = chkDownloadAccelerate.Checked;
            BotInfo.AccelerateUrl = txbDownloadAccelerateUrl.Text;
            #endregion -- 通用设置 --

            #region -- 搜图设置 --
            BotInfo.SearchEnabled = chkSearchPictureEnabled.Checked;  //是否启用搜图功能
            BotInfo.SearchEnabledSauceNao = chkSearchSauceNAOEnabled.Checked;  //是否启用SauceNao搜图
            BotInfo.SauceNAOApiKey = txbSauceNAOApiKey.Text;
            BotInfo.SearchEnabledASCII2D = chkSearchASCII2DEnabled.Checked;  //是否启用ASCII2D搜图
            BotInfo.SearchModeOnCmd = txbSearchModeOnCmd.Text;
            BotInfo.SearchModeOffCmd = txbSearchModeOffCmd.Text;
            BotInfo.SearchModeTimeOutReply = txbSearchModeTimeOutReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchModeOnReply = txbSearchModeOnReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchModeAlreadyOnReply = txbSearchModeAlreadyOnReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchModeOffReply = txbSearchModeOffReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchModeAlreadyOffReply = txbSearchModeAlreadyOffReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchNoResultReply = txbSearchNoResultReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchErrorReply = txbSearchErrorReply.Text;
            int iLowSimilarity;
            if (!int.TryParse(txbSearchLowSimilarity.Text, out iLowSimilarity))
            {
                iLowSimilarity = 50;
            }
            BotInfo.SearchLowSimilarity = iLowSimilarity;  //相似度阈值
            BotInfo.SearchLowSimilarityReply = txbSearchLowSimilarityReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchCheckPornEnabled = chkCheckPorn.Checked;  //是否启用腾讯云鉴黄
            BotInfo.SearchCheckPornIllegalReply = txbSearchCheckPornIllegalReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.SearchCheckPornErrorReply = txbSearchCheckPornErrorReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            #region -- 腾讯云相关设置 --
            BotInfo.TencentCloudAPPID = txbTencentCloudAPPID.Text;
            BotInfo.TencentCloudRegion = txbTencentCloudRegion.Text;
            BotInfo.TencentCloudSecretId = txbTencentCloudSecretId.Text;
            BotInfo.TencentCloudSecretKey = txbTencentCloudSecretKey.Text;
            BotInfo.TencentCloudBucket = txbTencentCloudBucket.Text;
            #endregion -- 腾讯云相关设置 --

            #endregion -- 搜图设置 --

            #region -- 翻译设置 --

            BotInfo.TranslateEnabled = chkTranslateEnabled.Checked;
            BotInfo.TranslateToChineseCMD = txbTranslateToChinese.Text;
            BotInfo.TranslateToCMD = txbTranslateTo.Text;

            #endregion  -- 翻译设置 --

            #region -- 色图设置 --
            BotInfo.EnabledLoliconDataBase = chkEnabledLoliconHPicture.Checked;
            BotInfo.EnabledShabDataBase = chkEnabledShabHPicture.Checked;
            BotInfo.HPictureEnabled = chkEnabledHPicture.Checked;
            BotInfo.HPictureApiKey = txbHPictureApiKey.Text;
            BotInfo.HPictureBeginCmd = txbHPictureBegin.Text;
            BotInfo.HPictureCountCmd = txbHPictureCount.Text;
            BotInfo.HPictureUnitCmd = txbHPictureUnit.Text;
            BotInfo.HPictureR18Cmd = txbHPictureR18.Text;
            BotInfo.HPictureKeywordCmd = txbHPictureKeyword.Text;
            BotInfo.HPictureEndCmd = txbHPictureEnd.Text;
            BotInfo.ShabHPictureEndCmd = txbShabHPictureEnd.Text;
            BotInfo.HPictureBeginCmdNull = chkHPictureBeginNull.Checked;
            BotInfo.HPictureCountCmdNull = chkHPictureCountNull.Checked;
            BotInfo.HPictureUnitCmdNull = chkHPictureUnitNull.Checked;
            BotInfo.HPictureR18CmdNull = chkHPictureR18Null.Checked;
            BotInfo.HPictureKeywordCmdNull = chkHPictureKeywordNull.Checked;
            BotInfo.HPictureEndCmdNull = chkHPictureEndNull.Checked;
            BotInfo.ShabHPictureEndCmdNull = chkShabHPictureEndNull.Checked;
            List<string> tempHPictureUserCmd = new List<string>();
            foreach (ListViewItem item in lstHPictureUserCmd.Items)
            {
                tempHPictureUserCmd.Add(item.SubItems[0].Text);
            }
            BotInfo.HPictureUserCmd = tempHPictureUserCmd;
            List<long> tempHPictureWhiteGroup = new List<long>();
            foreach (ListViewItem item in lstHPictureWhiteGroup.Items)
            {
                tempHPictureWhiteGroup.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.HPictureWhiteGroup = tempHPictureWhiteGroup;
            BotInfo.HPictureWhiteOnly = chkWhiteOnly.Checked;
            BotInfo.HPictureAllowR18 = chkAllowR18.Checked;
            BotInfo.HPictureR18WhiteOnly = chkR18WhiteOnly.Checked;
            BotInfo.HPictureAllowPM = chkPM.Checked;
            BotInfo.HPictureAntiShielding = chkAntiShielding.Checked;
            BotInfo.HPictureSize1200 = chkSize1200.Checked;
            BotInfo.HPictureLimit = string.IsNullOrEmpty(txbLimit.Text) ? 0 : Convert.ToInt32(txbLimit.Text);
            BotInfo.HPicturePMNoLimit = chkPMNoLimit.Checked;
            BotInfo.HPictureAdminNoLimit = chkAdminNoLimit.Checked;
            BotInfo.HPictureManageNoLimit = chkManageNoLimit.Checked;
            BotInfo.HPictureCD = string.IsNullOrEmpty(txbCD.Text) ? 0 : Convert.ToInt32(txbCD.Text);
            BotInfo.HPictureRevoke = string.IsNullOrEmpty(txbRevoke.Text) ? 0 : Convert.ToInt32(txbRevoke.Text);
            BotInfo.HPictureWhiteCD = string.IsNullOrEmpty(txbWhiteCD.Text) ? 0 : Convert.ToInt32(txbWhiteCD.Text);
            BotInfo.HPictureWhiteRevoke = string.IsNullOrEmpty(txbWhiteRevoke.Text) ? 0 : Convert.ToInt32(txbWhiteRevoke.Text);
            BotInfo.HPicturePMCD = string.IsNullOrEmpty(txbPMCD.Text) ? 0 : Convert.ToInt32(txbPMCD.Text);
            BotInfo.HPicturePMRevoke = string.IsNullOrEmpty(txbPMRevoke.Text) ? 0 : Convert.ToInt32(txbPMRevoke.Text);
            BotInfo.HPictureCDUnreadyReply = txbCDUnreadyReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.HPictureOutOfLimitReply = txbOutOfLimitReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.HPictureErrorReply = txbHPictureErrorReplyReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.HPictureNoResultReply = txbHPictureNoResultReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.HPictureDownloadFailReply = txbDownloadFailReply.Text.Replace("\\r", "\r").Replace("\\n", "\n");
            BotInfo.HPictureLimitType = rdoHPictureLimitFrequency.Checked ? LimitType.Frequency : LimitType.Count;
            BotInfo.HPictureWhiteNoLimit = chkWhiteNoLimit.Checked;
            BotInfo.HPictureMultithreading = chkMultithreading.Checked;
            #endregion -- 色图设置 --

            Close();
        }

        private void txbHPictureEnd_TextChanged(object sender, EventArgs e) => AddStringToCmd();

        private void AddStringToCmd()
        {
            string Begin, Count, Unit, R18, Keyword, LoliconEnd, ShabEnd;

            Begin = txbHPictureBegin.Text;
            if (chkHPictureBeginNull.Checked)
            {
                Begin = $"({Begin})?";
            }
            Count = txbHPictureCount.Text;
            if (chkHPictureCountNull.Checked)
            {
                Count = $"({Count})?";
            }
            Unit = txbHPictureUnit.Text;
            if (chkHPictureUnitNull.Checked)
            {
                Unit = $"({Unit})?";
            }
            R18 = txbHPictureR18.Text;
            if (chkHPictureR18Null.Checked)
            {
                R18 = $"({R18})?";
            }
            Keyword = txbHPictureKeyword.Text;
            if (chkHPictureKeywordNull.Checked)
            {
                Keyword = $"({Keyword})?";
            }
            LoliconEnd = txbHPictureEnd.Text;
            if (chkHPictureEndNull.Checked)
            {
                LoliconEnd = $"({LoliconEnd})?";
            }
            ShabEnd = txbShabHPictureEnd.Text;
            if (chkShabHPictureEndNull.Checked)
            {
                ShabEnd = $"({ShabEnd})?";
            }

            txbHPictureCmd.Text = $"^<机器人名称>{Begin}{Count}{Unit}{R18}{Keyword}{R18}{LoliconEnd}$";
            txbShabHPictureCmd.Text = $"^<机器人名称>{Begin}{Count}{Unit}{R18}{Keyword}{R18}{ShabEnd}$";
        }

        private void chkEnableHPicture_CheckedChanged(object sender, EventArgs e)
        {
            pnlEnabelHPicture.Enabled = chkEnabledHPicture.Checked;
        }

        private void btnAddUserHPictureCmd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbUserHPictureCmd.Text))
            {
                foreach (ListViewItem item in lstHPictureUserCmd.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text == txbAddAdmin.Text)
                        {
                            return;
                        }
                    }
                }
                lstHPictureUserCmd.Items.Add(txbUserHPictureCmd.Text);
            }
        }

        private void btnAddToWhiteGroup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbAddToWhiteGroup.Text))
            {
                foreach (ListViewItem item in lstHPictureWhiteGroup.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text == txbAddAdmin.Text)
                        {
                            return;
                        }
                    }
                }
                lstHPictureWhiteGroup.Items.Add(txbAddToWhiteGroup.Text);
            }
        }

        private void txbUserHPictureCmd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void txbUserHPictureCmd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText())
                {
                    try
                    {
                        Convert.ToInt64(Clipboard.GetText());  //检查是否数字
                        ((TextBox)sender).SelectedText = Clipboard.GetText().Trim(); //Ctrl+V 粘贴  
                        if (((TextBox)sender).TextLength > 10)
                        {
                            ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(10); //TextBox最大长度为10  移除多余的
                        }
                    }
                    catch (Exception)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void lnkResetHPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chkHPictureBeginNull.Checked = false;
            chkHPictureCountNull.Checked = true;
            chkHPictureUnitNull.Checked = false;
            chkHPictureR18Null.Checked = true;
            chkHPictureKeywordNull.Checked = true;
            chkHPictureEndNull.Checked = false;

            txbHPictureBegin.Text = "[我再]?[要来來发發给給]";
            txbHPictureCount.Text = "[0-9零一壹二两贰兩三叁四肆五伍六陆陸七柒八捌九玖十拾百佰千仟万萬亿]+?";
            txbHPictureUnit.Text = "[张張个個幅份]";
            txbHPictureR18.Text = "[Rr]-?18的?";
            txbHPictureKeyword.Text = ".+?";
            txbHPictureEnd.Text = "的?[色瑟][图圖]";
            txbShabHPictureEnd.Text = "的?美[图圖]";
            chkEnabledLoliconHPicture.Checked = true;
            chkEnabledShabHPicture.Checked = true;
            AddStringToCmd();
        }

        private void chkDownloadAccelerate_CheckedChanged(object sender, EventArgs e)
        {
            txbDownloadAccelerateUrl.Enabled = chkDownloadAccelerate.Checked;
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbAddAdmin.Text))
            {
                foreach (ListViewItem item in lstAdmins.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text == txbAddAdmin.Text)
                        {
                            return;
                        }
                    }
                }
                lstAdmins.Items.Add(txbAddAdmin.Text);
            }
        }

        private void btnRemoveAdmin_Click(object sender, EventArgs e)
        {
            if (lstAdmins.SelectedItems.Count > 0)
            {
                lstAdmins.Items.Remove(lstAdmins.SelectedItems[0]);
            }
        }

        private void btnRemoveUserHPictureCmd_Click(object sender, EventArgs e)
        {
            if (lstHPictureUserCmd.SelectedItems.Count > 0)
            {
                lstHPictureUserCmd.Items.Remove(lstHPictureUserCmd.SelectedItems[0]);
            }
        }

        private void btnRemoveWhiteGroup_Click(object sender, EventArgs e)
        {
            if (lstHPictureWhiteGroup.SelectedItems.Count > 0)
            {
                lstHPictureWhiteGroup.Items.Remove(lstHPictureWhiteGroup.SelectedItems[0]);
            }
        }

        private void chkHPictureBeginNull_CheckedChanged(object sender, EventArgs e) => AddStringToCmd();

        private void btnAddBanGroup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbBanGroup.Text))
            {
                foreach (ListViewItem item in lstBannedGroup.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text == txbBanGroup.Text)
                        {
                            return;
                        }
                    }
                }
                lstBannedGroup.Items.Add(txbBanGroup.Text);
            }
        }

        private void btnRemoveBanGroup_Click(object sender, EventArgs e)
        {
            if (lstBannedGroup.SelectedItems.Count > 0)
            {
                lstBannedGroup.Items.Remove(lstBannedGroup.SelectedItems[0]);
            }
        }

        private void btnAddBanUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbBanUser.Text))
            {
                foreach (ListViewItem item in lstBannedUser.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text == txbBanUser.Text)
                        {
                            return;
                        }
                    }
                }
                lstBannedUser.Items.Add(txbBanUser.Text);
            }
        }

        private void btnRemoveBanUser_Click(object sender, EventArgs e)
        {
            if (lstBannedUser.SelectedItems.Count > 0)
            {
                lstBannedUser.Items.Remove(lstBannedUser.SelectedItems[0]);
            }
        }

        private void chkSearchPictureEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchPicture.Enabled = chkSearchPictureEnabled.Checked;

        private void chkCheckPorn_CheckedChanged(object sender, EventArgs e) => pnlCheckPorn.Enabled = chkCheckPorn.Checked;

        private void lnkContributorGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", (sender as Control).Text);
        }

        private void chkSearchSauceNAOEnabled_CheckedChanged(object sender, EventArgs e) => txbSauceNAOApiKey.Enabled = chkSearchSauceNAOEnabled.Checked;
    }
}
