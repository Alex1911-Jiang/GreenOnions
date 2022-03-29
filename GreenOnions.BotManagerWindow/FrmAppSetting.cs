using GreenOnions.BotMain;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using GreenOnions.Utility.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace GreenOnions.BotManagerWindow
{
    public partial class FrmAppSetting : Form
    {
        public FrmAppSetting() => InitializeComponent();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

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
            #endregion -- 通用设置 --

            #region -- 搜图设置 --
            txbTraceMoeSendThreshold.Text = BotInfo.TraceMoeSendThreshold.ToString();
            //txbTraceMoeStopThreshold.Text = BotInfo.TraceMoeStopThreshold.ToString();
            chkSearchPictureEnabled.Checked = BotInfo.SearchEnabled;  //是否启用搜图功能
            chkSearchSauceNAOEnabled.Checked = BotInfo.SearchEnabledSauceNao;  //SauceNao Api-Key
            txbSauceNAOApiKey.Text = string.Join("\r\n", BotInfo.SauceNAOApiKey);
            chkSearchASCII2DEnabled.Checked = BotInfo.SearchEnabledASCII2D;  //是否启用ASCII2D搜图
            chkTraceMoeEnabled.Checked = BotInfo.SearchEnabledTraceMoe;  //是否启用TraceMoe搜番
            txbSearchModeOnCmd.Text = BotInfo.SearchModeOnCmd;
            txbSearchModeOffCmd.Text = BotInfo.SearchModeOffCmd;
            txbSearchModeTimeOutReply.Text = BotInfo.SearchModeTimeOutReply;
            txbSearchModeOnReply.Text = BotInfo.SearchModeOnReply;
            txbSearchModeAlreadyOnReply.Text = BotInfo.SearchModeAlreadyOnReply;
            txbSearchModeOffReply.Text = BotInfo.SearchModeOffReply;
            txbSearchModeAlreadyOffReply.Text = BotInfo.SearchModeAlreadyOffReply;
            txbSearchNoResultReply.Text = BotInfo.SearchNoResultReply;
            txbSearchErrorReply.Text = BotInfo.SearchErrorReply;
            txbSearchLowSimilarity.Text = BotInfo.SearchLowSimilarity.ToString();
            txbSearchLowSimilarityReply.Text = BotInfo.SearchLowSimilarityReply;

            chkCheckPornEnabled.Checked = BotInfo.CheckPornEnabled; //是否启用腾讯云鉴黄
            chkPictureSearcherCheckPornEnabled.Checked = BotInfo.SearchCheckPornEnabled;  //是否在搜图启用鉴黄
            txbSearchCheckPornIllegalReply.Text = BotInfo.SearchCheckPornIllegalReply;
            txbSearchCheckPornErrorReply.Text = BotInfo.SearchCheckPornErrorReply;
            txbCheckPornLimitCount.Text = BotInfo.CheckPornLimitCount.ToString();
            switch (BotInfo.SearchCheckPornOutOfLimitEvent)
            {
                case 0:
                    rdoSearchCheckPornOutOfLimitSend.Checked = true;
                    break;
                case 1:
                    rdoSearchCheckPornOutOfLimitDontSend.Checked = true;
                    break;
                case 2:
                    rdoSearchCheckPornOutOfLimitAppend.Checked = true;
                    break;
            }
            txbSearchCheckPornOutOfLimitReply.Text = BotInfo.SearchCheckPornOutOfLimitReply;
            switch (BotInfo.SearchNoCheckPorn)
            {
                case 0:
                    rdoNoCheckPornSend.Checked = true;
                    break;
                case 1:
                    rdoNoCheckPornDontSend.Checked = true;
                    break;
            }

            chkOriginPictureEnabled.Checked = BotInfo.OriginPictureEnabled;
            chkOriginPictureCheckPornEnabled.Checked = BotInfo.OriginPictureCheckPornEnabled;  //是否在下载原图启用鉴黄
            switch (BotInfo.OriginPictureCheckPornEvent)  //鉴黄不通过的行为
            {
                case 0:
                    rdoOriginPictureCheckPornSendByForward.Checked = true;
                    break;
                case 1:
                    rdoOriginPictureCheckPornDoNothing.Checked = true;
                    break;
                case 2:
                    rdoOriginPictureCheckPornReply.Checked = true;
                    break;
            }
            txbOriginPictureCheckPornIllegalReply.Text = BotInfo.OriginPictureCheckPornIllegalReply;
            txbOriginPictureCheckPornErrorReply.Text = BotInfo.OriginPictureCheckPornErrorReply;
            chkASCII2DRequestByWebBrowser.Checked = BotInfo.ASCII2DRequestByWebBrowser;

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
            cboTranslateEngine.SelectedIndex = (int)BotInfo.TranslateEngineType;
            txbTranslateToChinese.Text = BotInfo.TranslateToChineseCMD;
            txbTranslateTo.Text = BotInfo.TranslateToCMD;
            txbTranslateFromToCMD.Text = BotInfo.TranslateFromToCMD;

            foreach (long item in BotInfo.AutoTranslateGroupMemoriesQQ)
                lstAutoTranslateGroupMemoriesQQ.Items.Add(item.ToString());

            #endregion -- 翻译设置 --

            #region -- 色图设置 --

            foreach (var hSource in BotInfo.EnabledHPictureSource)
            {
                if (hSource == PictureSource.Lolicon)
                    chkEnabledLoliconHPicture.Checked = true;
                if (hSource == PictureSource.GreenOnions)
                    chkEnabledGreenOnionsHPicture.Checked = true;
            }
            foreach (var beautySource in BotInfo.EnabledBeautyPictureSource)
            {
                if (beautySource == PictureSource.ELF)
                    chkEnabledELFBeautyPicture.Checked = true;
                if (beautySource == PictureSource.GreenOnions)
                    chkEnabledGreenOnionsBeautyPicture.Checked = true;
            }
            txbHPictureOnceMessageMaxImageCount.Text = BotInfo.HPictureOnceMessageMaxImageCount.ToString();
            chkEnabledHPicture.Checked = BotInfo.HPictureEnabled;
            txbHPictureApiKey.Text = BotInfo.HPictureApiKey;
            txbHPictureCmd.Text = BotInfo.HPictureCmd;
            txbHPictureBegin.Text = BotInfo.HPictureBeginCmd;
            txbHPictureCount.Text = BotInfo.HPictureCountCmd;
            txbHPictureUnit.Text = BotInfo.HPictureUnitCmd;
            txbHPictureR18.Text = BotInfo.HPictureR18Cmd;
            txbHPictureKeyword.Text = BotInfo.HPictureKeywordCmd;
            txbHPictureEnd.Text = BotInfo.HPictureEndCmd;
            txbBeautyPictureEnd.Text = BotInfo.BeautyPictureEndCmd;
            chkHPictureBeginNull.Checked = BotInfo.HPictureBeginCmdNull;
            chkHPictureCountNull.Checked = BotInfo.HPictureCountCmdNull;
            chkHPictureUnitNull.Checked = BotInfo.HPictureUnitCmdNull;
            chkHPictureR18Null.Checked = BotInfo.HPictureR18CmdNull;
            chkHPictureKeywordNull.Checked = BotInfo.HPictureKeywordCmdNull;
            chkHPictureEndNull.Checked = BotInfo.HPictureEndCmdNull;
            chkBeautyPictureEndNull.Checked = BotInfo.BeautyPictureEndCmdNull;
            chkRevokeBeautyPicture.Checked = BotInfo.RevokeBeautyPicture;
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
            txbCDUnreadyReply.Text = BotInfo.HPictureCDUnreadyReply;
            txbOutOfLimitReply.Text = BotInfo.HPictureOutOfLimitReply;
            txbHPictureErrorReplyReply.Text = BotInfo.HPictureErrorReply;
            txbHPictureNoResultReply.Text = BotInfo.HPictureNoResultReply;
            txbDownloadFailReply.Text = BotInfo.HPictureDownloadFailReply;
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
                    ctrlRssItem.RssForwardGroups = item.ForwardGroups;
                    ctrlRssItem.RssForwardQQs = item.ForwardQQs;
                    ctrlRssItem.RssTranslate = item.Translate;
                    ctrlRssItem.RssTranslateFromTo = item.TranslateFromTo;
                    ctrlRssItem.RssTranslateFrom = item.TranslateFrom;
                    ctrlRssItem.RssTranslateTo = item.TranslateTo;
                    ctrlRssItem.RssSendByForward = item.SendByForward;
                    ctrlRssItem.RemoveClick += (_, _) => pnlRssSubscriptionList.Controls.Remove(ctrlRssItem);
                    pnlRssSubscriptionList.Controls.Add(ctrlRssItem);
                }
                pnlRssSubscriptionList.Controls.Add(btnAddRssSubscription);
            }
            txbReadRssInterval.Text = BotInfo.ReadRssInterval.ToString();
            #endregion  -- RSS --

            #region -- 井字棋 --
            chkTicTacToeEnabled.Checked = BotInfo.TicTacToeEnabled;
            txbStartTicTacToeCmd.Text = BotInfo.StartTicTacToeCmd;
            txbTicTacToeStartedReply.Text = BotInfo.TicTacToeStartedReply;
            txbTicTacToeAlreadyStartReply.Text = BotInfo.TicTacToeAlreadyStartReply;
            txbStopTicTacToeCmd.Text = BotInfo.StopTicTacToeCmd;
            txbTicTacToeStoppedReply.Text = BotInfo.TicTacToeStoppedReply;
            txbTicTacToeAlreadStopReply.Text = BotInfo.TicTacToeAlreadStopReply;
            txbTicTacToeTimeoutReply.Text = BotInfo.TicTacToeTimeoutReply;
            txbTicTacToePlayerWinReply.Text = BotInfo.TicTacToePlayerWinReply;
            txbTicTacToeBotWinReply.Text = BotInfo.TicTacToeBotWinReply;
            txbTicTacToeDrawReply.Text = BotInfo.TicTacToeDrawReply;
            txbTicTacToeNoMoveReply.Text = BotInfo.TicTacToeNoMoveReply;
            txbTicTacToeIllegalMoveReply.Text = BotInfo.TicTacToeIllegalMoveReply;
            txbTicTacToeMoveFailReply.Text = BotInfo.TicTacToeMoveFailReply;
            foreach (CheckBox moveMode in pnlTicTacToeMoveMode.Controls.OfType<CheckBox>())
                moveMode.Checked = (BotInfo.TicTacToeMoveMode & Convert.ToInt32(moveMode.Tag)) != 0;
            #endregion -- 井字棋 --
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
            BotInfo.EnabledAccelerate = chkDownloadAccelerate.Checked;
            BotInfo.AccelerateUrl = txbDownloadAccelerateUrl.Text;

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

            #endregion -- 通用设置 --

            #region -- 搜图设置 --
            int iTraceMoeSendThreshold;
            if (!int.TryParse(txbTraceMoeSendThreshold.Text, out iTraceMoeSendThreshold))
                iTraceMoeSendThreshold = 87;
            BotInfo.TraceMoeSendThreshold = iTraceMoeSendThreshold;
            BotInfo.SearchEnabled = chkSearchPictureEnabled.Checked;  //是否启用搜图功能
            BotInfo.SearchEnabledSauceNao = chkSearchSauceNAOEnabled.Checked;  //是否启用SauceNao搜图
            BotInfo.SauceNAOApiKey = txbSauceNAOApiKey.Text.Split("\r\n");
            BotInfo.SearchEnabledASCII2D = chkSearchASCII2DEnabled.Checked;  //是否启用ASCII2D搜图
            BotInfo.SearchEnabledTraceMoe = chkTraceMoeEnabled.Checked;  //是否启用TraceMoe搜番
            BotInfo.SearchModeOnCmd = txbSearchModeOnCmd.Text;
            BotInfo.SearchModeOffCmd = txbSearchModeOffCmd.Text;
            BotInfo.SearchModeTimeOutReply = txbSearchModeTimeOutReply.Text;
            BotInfo.SearchModeOnReply = txbSearchModeOnReply.Text;
            BotInfo.SearchModeAlreadyOnReply = txbSearchModeAlreadyOnReply.Text;
            BotInfo.SearchModeOffReply = txbSearchModeOffReply.Text;
            BotInfo.SearchModeAlreadyOffReply = txbSearchModeAlreadyOffReply.Text;
            BotInfo.SearchNoResultReply = txbSearchNoResultReply.Text;
            BotInfo.SearchErrorReply = txbSearchErrorReply.Text;
            int iLowSimilarity;
            if (!int.TryParse(txbSearchLowSimilarity.Text, out iLowSimilarity))
                iLowSimilarity = 60;
            BotInfo.SearchLowSimilarity = iLowSimilarity;  //相似度阈值
            BotInfo.SearchLowSimilarityReply = txbSearchLowSimilarityReply.Text;
            BotInfo.CheckPornEnabled = chkCheckPornEnabled.Checked;  //是否启用腾讯云鉴黄
            BotInfo.SearchCheckPornEnabled = chkPictureSearcherCheckPornEnabled.Checked;  //是否在搜图启用鉴黄
            BotInfo.SearchCheckPornIllegalReply = txbSearchCheckPornIllegalReply.Text;
            BotInfo.SearchCheckPornErrorReply = txbSearchCheckPornErrorReply.Text;
            BotInfo.ASCII2DRequestByWebBrowser = chkASCII2DRequestByWebBrowser.Checked;

            int iCheckPornLimitCount;
            if (!int.TryParse(txbCheckPornLimitCount.Text, out iCheckPornLimitCount))
                iCheckPornLimitCount = 2000;
            BotInfo.CheckPornLimitCount = iCheckPornLimitCount;
            BotInfo.SearchCheckPornOutOfLimitEvent = Convert.ToInt32(pnlPictureSearcherCheckPorn.Controls.OfType<RadioButton>().Where(x => x.Checked).First().Tag);
            BotInfo.SearchCheckPornOutOfLimitReply = txbSearchCheckPornOutOfLimitReply.Text;
            BotInfo.SearchNoCheckPorn = Convert.ToInt32(pnlNoCheckPorn.Controls.OfType<RadioButton>().Where(x => x.Checked).First().Tag); 

            #region -- 腾讯云相关设置 --
            BotInfo.TencentCloudAPPID = txbTencentCloudAPPID.Text;
            BotInfo.TencentCloudRegion = txbTencentCloudRegion.Text;
            BotInfo.TencentCloudSecretId = txbTencentCloudSecretId.Text;
            BotInfo.TencentCloudSecretKey = txbTencentCloudSecretKey.Text;
            BotInfo.TencentCloudBucket = txbTencentCloudBucket.Text;
            #endregion -- 腾讯云相关设置 --
            #endregion -- 搜图设置 --

            #region -- 下载原图设置 --

            BotInfo.OriginPictureEnabled = chkOriginPictureEnabled.Checked;
            BotInfo.OriginPictureCheckPornEnabled = chkOriginPictureCheckPornEnabled.Checked;  //是否在搜图启用鉴黄
            BotInfo.OriginPictureCheckPornEvent = Convert.ToInt32(pnlOriginPictureCheckPornEvent.Controls.OfType<RadioButton>().Where(x => x.Checked).First().Tag);
            BotInfo.OriginPictureCheckPornIllegalReply = txbOriginPictureCheckPornIllegalReply.Text;
            BotInfo.OriginPictureCheckPornErrorReply = txbOriginPictureCheckPornErrorReply.Text;

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

            List<PictureSource> EnabledHPictureSource = new List<PictureSource>();
            List<PictureSource> EnabledBeautyPictureSource = new List<PictureSource>();
            if (chkEnabledLoliconHPicture.Checked)
                EnabledHPictureSource.Add(PictureSource.Lolicon);
            if (chkEnabledGreenOnionsHPicture.Checked)
                EnabledHPictureSource.Add(PictureSource.GreenOnions);
            if (chkEnabledELFBeautyPicture.Checked)
                EnabledBeautyPictureSource.Add(PictureSource.ELF);
            if (chkEnabledGreenOnionsBeautyPicture.Checked)
                EnabledBeautyPictureSource.Add(PictureSource.GreenOnions);
            BotInfo.EnabledHPictureSource = EnabledHPictureSource;
            BotInfo.EnabledBeautyPictureSource = EnabledBeautyPictureSource;
            BotInfo.HPictureOnceMessageMaxImageCount = string.IsNullOrEmpty(txbHPictureOnceMessageMaxImageCount.Text) ? 10 : Convert.ToInt32(txbHPictureOnceMessageMaxImageCount.Text);
            BotInfo.HPictureEnabled = chkEnabledHPicture.Checked;
            BotInfo.HPictureApiKey = txbHPictureApiKey.Text;
            BotInfo.HPictureBeginCmd = txbHPictureBegin.Text;
            BotInfo.HPictureCountCmd = txbHPictureCount.Text;
            BotInfo.HPictureUnitCmd = txbHPictureUnit.Text;
            BotInfo.HPictureR18Cmd = txbHPictureR18.Text;
            BotInfo.HPictureKeywordCmd = txbHPictureKeyword.Text;
            BotInfo.HPictureEndCmd = txbHPictureEnd.Text;
            BotInfo.BeautyPictureEndCmd = txbBeautyPictureEnd.Text;
            BotInfo.HPictureBeginCmdNull = chkHPictureBeginNull.Checked;
            BotInfo.HPictureCountCmdNull = chkHPictureCountNull.Checked;
            BotInfo.HPictureUnitCmdNull = chkHPictureUnitNull.Checked;
            BotInfo.HPictureR18CmdNull = chkHPictureR18Null.Checked;
            BotInfo.HPictureKeywordCmdNull = chkHPictureKeywordNull.Checked;
            BotInfo.HPictureEndCmdNull = chkHPictureEndNull.Checked;
            BotInfo.BeautyPictureEndCmdNull = chkBeautyPictureEndNull.Checked;
            BotInfo.RevokeBeautyPicture = chkRevokeBeautyPicture.Checked;
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
            BotInfo.HPictureCDUnreadyReply = txbCDUnreadyReply.Text;
            BotInfo.HPictureOutOfLimitReply = txbOutOfLimitReply.Text;
            BotInfo.HPictureErrorReply = txbHPictureErrorReplyReply.Text;
            BotInfo.HPictureNoResultReply = txbHPictureNoResultReply.Text;
            BotInfo.HPictureDownloadFailReply = txbDownloadFailReply.Text;
            BotInfo.HPictureLimitType = rdoHPictureLimitFrequency.Checked ? LimitType.Frequency : LimitType.Count;
            BotInfo.HPictureWhiteNoLimit = chkWhiteNoLimit.Checked;
            BotInfo.HPictureMultithreading = chkMultithreading.Checked;
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
                SendByForward = i.RssSendByForward,
            });
            BotInfo.ReadRssInterval = Convert.ToInt32(txbReadRssInterval.Text);

            #endregion -- RSS --

            #region -- 井字棋 --

            BotInfo.TicTacToeEnabled = chkTicTacToeEnabled.Checked;
            BotInfo.StartTicTacToeCmd = txbStartTicTacToeCmd.Text;
            BotInfo.TicTacToeStartedReply = txbTicTacToeStartedReply.Text;
            BotInfo.TicTacToeAlreadyStartReply = txbTicTacToeAlreadyStartReply.Text;
            BotInfo.StopTicTacToeCmd = txbStopTicTacToeCmd.Text;
            BotInfo.TicTacToeStoppedReply = txbTicTacToeStoppedReply.Text;
            BotInfo.TicTacToeAlreadStopReply = txbTicTacToeAlreadStopReply.Text;
            BotInfo.TicTacToeTimeoutReply = txbTicTacToeTimeoutReply.Text;
            BotInfo.TicTacToePlayerWinReply = txbTicTacToePlayerWinReply.Text;
            BotInfo.TicTacToeBotWinReply = txbTicTacToeBotWinReply.Text;
            BotInfo.TicTacToeDrawReply = txbTicTacToeDrawReply.Text;

            BotInfo.TicTacToeNoMoveReply = txbTicTacToeNoMoveReply.Text;
            BotInfo.TicTacToeIllegalMoveReply = txbTicTacToeIllegalMoveReply.Text;
            BotInfo.TicTacToeMoveFailReply = txbTicTacToeMoveFailReply.Text;
            BotInfo.TicTacToeMoveMode = 0;
            foreach (CheckBox moveMode in pnlTicTacToeMoveMode.Controls.OfType<CheckBox>())
            {
                if (moveMode.Checked)
                    BotInfo.TicTacToeMoveMode |= Convert.ToInt32(moveMode.Tag);
            }

            #endregion -- 井字棋 --

            JsonHelper.SaveConfigFile();

            PlainMessageHandler.UpdateRegexs();

            Close();
        }

        private void txbHPictureEnd_TextChanged(object sender, EventArgs e) => AddStringToCmd();

        private void AddStringToCmd()
        {
            txbForgeMessageCmdBegin.TextChanged -= txbHPictureEnd_TextChanged;
            txbHPictureApiKey.TextChanged -= txbHPictureEnd_TextChanged;
            txbBeautyPictureEnd.TextChanged -=txbHPictureEnd_TextChanged;
            txbHPictureEnd.TextChanged -= txbHPictureEnd_TextChanged;
            txbHPictureBegin.TextChanged -=txbHPictureEnd_TextChanged;
            txbHPictureKeyword.TextChanged -= txbHPictureEnd_TextChanged;
            txbHPictureCount.TextChanged -= txbHPictureEnd_TextChanged;
            txbHPictureR18.TextChanged -=txbHPictureEnd_TextChanged;
            txbHPictureUnit.TextChanged -=txbHPictureEnd_TextChanged;

            if (chkHPictureBeginNull.Checked)
                txbHPictureBegin.Text = SetNullRegex(txbHPictureBegin.Text);
            else
                txbHPictureBegin.Text = RemoveNullRegex(txbHPictureBegin.Text);

            if (chkHPictureCountNull.Checked)
                txbHPictureCount.Text = SetNullRegex(txbHPictureCount.Text);
            else
                txbHPictureCount.Text = RemoveNullRegex(txbHPictureCount.Text);

            if (chkHPictureUnitNull.Checked)
                txbHPictureUnit.Text = SetNullRegex(txbHPictureUnit.Text);
            else
                txbHPictureUnit.Text = RemoveNullRegex(txbHPictureUnit.Text);

            if (chkHPictureR18Null.Checked)
                txbHPictureR18.Text = SetNullRegex(txbHPictureR18.Text);
            else
                txbHPictureR18.Text = RemoveNullRegex(txbHPictureR18.Text);


            if (chkHPictureKeywordNull.Checked)
                txbHPictureKeyword.Text = SetNullRegex(txbHPictureKeyword.Text);
            else
                txbHPictureKeyword.Text = RemoveNullRegex(txbHPictureKeyword.Text);

            if (chkHPictureEndNull.Checked)
                txbHPictureEnd.Text = SetNullRegex(txbHPictureEnd.Text);
            else
                txbHPictureEnd.Text = RemoveNullRegex(txbHPictureEnd.Text);


            if (chkBeautyPictureEndNull.Checked)
                txbBeautyPictureEnd.Text = SetNullRegex(txbBeautyPictureEnd.Text);
            else
                txbBeautyPictureEnd.Text = RemoveNullRegex(txbBeautyPictureEnd.Text);

            txbHPictureCmd.Text = $"^{txbHPictureBegin.Text}{txbHPictureCount.Text}{txbHPictureUnit.Text }{txbHPictureR18.Text}{txbHPictureKeyword.Text}{txbHPictureR18.Text}{txbHPictureEnd.Text}$";
            txbBeautyPictureCmd.Text = $"^{txbHPictureBegin.Text}{txbHPictureCount.Text}{txbHPictureUnit.Text }{txbHPictureR18.Text}{txbHPictureKeyword.Text }{txbHPictureR18.Text}{txbBeautyPictureEnd.Text}$";

            txbForgeMessageCmd.Text = $"{txbForgeMessageCmdBegin.Text}<@QQ><伪造内容>";

            txbForgeMessageCmdBegin.TextChanged += txbHPictureEnd_TextChanged;
            txbHPictureApiKey.TextChanged += txbHPictureEnd_TextChanged;
            txbBeautyPictureEnd.TextChanged += txbHPictureEnd_TextChanged;
            txbHPictureEnd.TextChanged += txbHPictureEnd_TextChanged;
            txbHPictureBegin.TextChanged += txbHPictureEnd_TextChanged;
            txbHPictureKeyword.TextChanged += txbHPictureEnd_TextChanged;
            txbHPictureCount.TextChanged += txbHPictureEnd_TextChanged;
            txbHPictureR18.TextChanged += txbHPictureEnd_TextChanged;
            txbHPictureUnit.TextChanged += txbHPictureEnd_TextChanged;

            string SetNullRegex(string str)
            {
                if (string.IsNullOrEmpty(str))
                    return str;
                if (str[0] == '(' && str[str.Length - 2] == ')' && str[str.Length - 1] == '?')
                    return str;
                return $"({str})?";
            }

            string RemoveNullRegex(string str)
            {
                if (string.IsNullOrEmpty(str))
                    return str;
                if (str.Length < 3)
                    return str;
                if (str[0] == '(' && str[str.Length -2]== ')' && str[str.Length -1] =='?')
                    return str.Substring(1, str.Length - 3);
                return str;
            }
        }

        private void chkEnableHPicture_CheckedChanged(object sender, EventArgs e) => pnlEnabelHPicture.Enabled = chkEnabledHPicture.Checked;

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

        private void lnkResetHPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chkHPictureBeginNull.Checked = false;
            chkHPictureCountNull.Checked = true;
            chkHPictureUnitNull.Checked = false;
            chkHPictureR18Null.Checked = true;
            chkHPictureKeywordNull.Checked = true;
            chkHPictureEndNull.Checked = false;

            txbHPictureBegin.Text = "<机器人名称>[我再]?[要来來发發给給]";
            txbHPictureCount.Text = "[0-9零一壹二两贰兩三叁四肆五伍六陆陸七柒八捌九玖十拾百佰千仟万萬亿億]+?";
            txbHPictureUnit.Text = "[张張个個幅份]";
            txbHPictureR18.Text = "[Rr]-?18的?";
            txbHPictureKeyword.Text = ".+?";
            txbHPictureEnd.Text = "的?[色瑟][图圖図]";
            txbBeautyPictureEnd.Text = "的?美[图圖図]";
            chkEnabledLoliconHPicture.Checked = true;
            AddStringToCmd();
        }

        private void chkDownloadAccelerate_CheckedChanged(object sender, EventArgs e) => txbDownloadAccelerateUrl.Enabled = chkDownloadAccelerate.Checked;

        private void chkHPictureBeginNull_CheckedChanged(object sender, EventArgs e) => AddStringToCmd();

        private void chkSearchPictureEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchPicture.Enabled = chkSearchPictureEnabled.Checked;

        private void chkCheckPorn_CheckedChanged(object sender, EventArgs e) => pnlCheckPorn.Enabled = chkCheckPornEnabled.Checked;

        private void lnkContributorGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", (sender as Control).Text);
        }

        private void chkSearchSauceNAOEnabled_CheckedChanged(object sender, EventArgs e) => txbSauceNAOApiKey.Enabled = chkSearchSauceNAOEnabled.Checked;

        #region -- 添加或移除ListView --

        private void btnAddUserHPictureCmd_Click(object sender, EventArgs e) => AddItemToListView(lstHPictureUserCmd, txbUserHPictureCmd.Text);

        private void btnAddToWhiteGroup_Click(object sender, EventArgs e) => AddItemToListView(lstHPictureWhiteGroup, txbAddToWhiteGroup.Text);

        private void btnAddAdmin_Click(object sender, EventArgs e) => AddItemToListView(lstAdmins, txbAddAdmin.Text);

        private void btnAddBanGroup_Click(object sender, EventArgs e) => AddItemToListView(lstBannedGroup, txbBanGroup.Text);

        private void btnAddBanUser_Click(object sender, EventArgs e) => AddItemToListView(lstBannedUser, txbBanUser.Text);

        private void btnAddDebugGroup_Click(object sender, EventArgs e) => AddItemToListView(lstDebugGroups, txbAddDebugGroup.Text);

        private void btnRemoveAdmin_Click(object sender, EventArgs e) => RemoveItemFromListView(lstAdmins);

        private void btnRemoveUserHPictureCmd_Click(object sender, EventArgs e) => RemoveItemFromListView(lstHPictureUserCmd);

        private void btnRemoveWhiteGroup_Click(object sender, EventArgs e) => RemoveItemFromListView(lstHPictureWhiteGroup);

        private void btnRemoveBanGroup_Click(object sender, EventArgs e) => RemoveItemFromListView(lstBannedGroup);

        private void btnRemoveBanUser_Click(object sender, EventArgs e) => RemoveItemFromListView(lstBannedUser);

        private void btnRemoveDebugGroup_Click(object sender, EventArgs e) => RemoveItemFromListView(lstDebugGroups);

        private void AddItemToListView(ListView listView, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                foreach (ListViewItem item in listView.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text == value)
                        {
                            return;
                        }
                    }
                }
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

        private void btnAddAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => AddItemToListView(lstAutoTranslateGroupMemoriesQQ, txbAddAutoTranslateGroupMemoryQQ.Text);

        private void btnRemoveAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => RemoveItemFromListView(lstAutoTranslateGroupMemoriesQQ);

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

        private void chkPictureSearcherCheckPornEnabled_CheckedChanged(object sender, EventArgs e)
        {
            pnlPictureSearcherCheckPorn.Enabled = chkPictureSearcherCheckPornEnabled.Checked;
            pnlNoCheckPorn.Enabled = !chkPictureSearcherCheckPornEnabled.Checked;
        } 

        private void chkOriginPictureEnabled_CheckedChanged(object sender, EventArgs e) => pnlOriginPicture.Enabled = chkOriginPictureEnabled.Checked;

        private void chkOriginPictureCheckPornEnabled_CheckedChanged(object sender, EventArgs e) => pnlOriginPictureCheckPorn.Enabled = chkOriginPictureCheckPornEnabled.Checked;

        private void rdoOriginPictureCheckPornSendByForward_CheckedChanged(object sender, EventArgs e) => pnlOriginPictureCheckPornMessage.Enabled = rdoOriginPictureCheckPornReply.Checked;

        private void chkTranslateEnabled_CheckedChanged(object sender, EventArgs e) => pnlTranslate.Enabled = chkTranslateEnabled.Checked;

        private void chkTicTacToeEnabled_CheckedChanged(object sender, EventArgs e) => pnlTicTacToe.Enabled = chkTicTacToeEnabled.Checked;
    }
}
