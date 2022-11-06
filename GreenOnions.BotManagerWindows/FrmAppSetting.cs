using System.Diagnostics;
using GreenOnions.BotMain;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotManagerWindows
{
    public partial class FrmAppSetting : Form
    {
        public FrmAppSetting() => InitializeComponent();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            #region -- 基本设置 --
            pnlBot.LoadConfig();
            #endregion -- 基本设置 --

            #region -- 搜图设置 --
            chkSearchPictureEnabled.Checked = BotInfo.SearchEnabled;  //是否启用搜图功能
            pnlSearchPicture.LoadConfig();
            #endregion -- 搜图设置 --

            #region -- 下载原图设置 --
            chkOriginalPictureEnabled.Checked = BotInfo.OriginalPictureEnabled;
            pnlOriginalPicture.LoadConfig();
            #endregion -- 下载原图设置 --

            #region -- 色图设置 --
            chkHPictureEnabled.Checked = BotInfo.HPictureEnabled;
            pnlHPicture.LoadConfig();
            #endregion -- 色图设置 --

            #region -- 翻译设置 --
            chkTranslateEnabled.Checked = BotInfo.TranslateEnabled;
            pnlTranslate.LoadConfig();
            #endregion -- 翻译设置 --

            #region -- 复读设置 --
            pnlRepeater.LoadConfig();
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
            pnlForgeMessage.LoadConfig();
            #endregion -- 伪造消息 --

            #region -- RSS --
            chkRssEnabled.Checked = BotInfo.RssEnabled;
            pnlRss.LoadConfig();
            #endregion  -- RSS --

            if (tabSettings.Width > Width || tabSettings.Height > Height)
                ResetCtrlSize();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            #region -- 基本设置 --
            pnlBot.SaveConfig();
            #endregion -- 基本设置 --

            #region -- 搜图设置 --
            BotInfo.SearchEnabled = chkSearchPictureEnabled.Checked;  //是否启用搜图功能
            pnlSearchPicture.SaveConfig();
            #endregion -- 搜图设置 --

            #region -- 下载原图设置 --
            BotInfo.OriginalPictureEnabled = chkOriginalPictureEnabled.Checked;
            pnlOriginalPicture.SaveConfig();
            #endregion -- 下载原图设置 --

            #region -- 色图设置 --
            BotInfo.HPictureEnabled = chkHPictureEnabled.Checked;
            pnlHPicture.SaveConfig();
            #endregion -- 色图设置 --

            #region -- 翻译设置 --
            BotInfo.TranslateEnabled = chkTranslateEnabled.Checked;
            pnlTranslate.SaveConfig();
            #endregion  -- 翻译设置 --

            #region -- 复读设置 --
            pnlRepeater.SaveConfig();
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
            pnlForgeMessage.SaveConfig();
            #endregion -- 伪造消息 --

            #region -- RSS --
            BotInfo.RssEnabled = chkRssEnabled.Checked;
            pnlRss.SaveConfig();
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


        private void chkEnableHPicture_CheckedChanged(object sender, EventArgs e) => pnlHPicture.Enabled = chkHPictureEnabled.Checked;
        
        private void chkSearchPictureEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchPicture.Enabled = chkSearchPictureEnabled.Checked;

        private void lnkContributorGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("explorer.exe", (sender as Control)!.Text);

        private void chkEnabledForgeMessage_CheckedChanged(object sender, EventArgs e) => pnlForgeMessage.Enabled = chkEnabledForgeMessage.Checked;

        private void chkRssEnabled_CheckedChanged(object sender, EventArgs e) => pnlRss.Enabled = chkRssEnabled.Checked;

        private void chkOriginalPictureEnabled_CheckedChanged(object sender, EventArgs e) => pnlOriginalPicture.Enabled = chkOriginalPictureEnabled.Checked;

        private void chkTranslateEnabled_CheckedChanged(object sender, EventArgs e) => pnlTranslate.Enabled = chkTranslateEnabled.Checked;

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
