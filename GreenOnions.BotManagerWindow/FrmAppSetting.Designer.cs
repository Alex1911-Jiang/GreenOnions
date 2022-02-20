namespace GreenOnions.BotManagerWindow
{
    partial class FrmAppSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txbBotName = new System.Windows.Forms.TextBox();
            this.lblBotName = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txbAddAdmin = new System.Windows.Forms.TextBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBot = new System.Windows.Forms.TabPage();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.chkHttpRequestByWebBrowser = new System.Windows.Forms.CheckBox();
            this.chkCheckPornEnabled = new System.Windows.Forms.CheckBox();
            this.chkImageCache = new System.Windows.Forms.CheckBox();
            this.pnlDebugMode = new System.Windows.Forms.Panel();
            this.chkOnlyReplyDebugGroup = new System.Windows.Forms.CheckBox();
            this.lstDebugGroups = new System.Windows.Forms.ListView();
            this.chkDebugReplyAdminOnly = new System.Windows.Forms.CheckBox();
            this.lblAddDebugGroup = new System.Windows.Forms.Label();
            this.lblDebugGroup = new System.Windows.Forms.Label();
            this.btnAddDebugGroup = new System.Windows.Forms.Button();
            this.btnRemoveDebugGroup = new System.Windows.Forms.Button();
            this.txbAddDebugGroup = new System.Windows.Forms.TextBox();
            this.txbBanUser = new System.Windows.Forms.TextBox();
            this.pnlCheckPorn = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCheckPornLimitCount = new System.Windows.Forms.Label();
            this.txbCheckPornLimitCount = new System.Windows.Forms.TextBox();
            this.lblTencentCloudBucket = new System.Windows.Forms.Label();
            this.lblTencentCloudSecretKey = new System.Windows.Forms.Label();
            this.txbTencentCloudBucket = new System.Windows.Forms.TextBox();
            this.lblTencentCloudSecretId = new System.Windows.Forms.Label();
            this.txbTencentCloudRegion = new System.Windows.Forms.TextBox();
            this.lblTencentCloudRegion = new System.Windows.Forms.Label();
            this.lblTencentCloudAPPID = new System.Windows.Forms.Label();
            this.txbTencentCloudSecretId = new System.Windows.Forms.TextBox();
            this.txbTencentCloudAPPID = new System.Windows.Forms.TextBox();
            this.txbTencentCloudSecretKey = new System.Windows.Forms.TextBox();
            this.txbBanGroup = new System.Windows.Forms.TextBox();
            this.chkDebugMode = new System.Windows.Forms.CheckBox();
            this.btnRemoveBanUser = new System.Windows.Forms.Button();
            this.lblImageCache = new System.Windows.Forms.Label();
            this.btnRemoveBanGroup = new System.Windows.Forms.Button();
            this.btnRemoveAdmin = new System.Windows.Forms.Button();
            this.btnAddBanUser = new System.Windows.Forms.Button();
            this.lblAddAdmin = new System.Windows.Forms.Label();
            this.btnAddBanGroup = new System.Windows.Forms.Button();
            this.lblBannedGroup = new System.Windows.Forms.Label();
            this.btnAddAdmin = new System.Windows.Forms.Button();
            this.lstAdmins = new System.Windows.Forms.ListView();
            this.lstBannedUser = new System.Windows.Forms.ListView();
            this.lblBannedUser = new System.Windows.Forms.Label();
            this.lblBanUser = new System.Windows.Forms.Label();
            this.lblBanGroup = new System.Windows.Forms.Label();
            this.lstBannedGroup = new System.Windows.Forms.ListView();
            this.tabSearchPicture = new System.Windows.Forms.TabPage();
            this.chkSearchPictureEnabled = new System.Windows.Forms.CheckBox();
            this.pnlSearchPicture = new System.Windows.Forms.Panel();
            this.pnlNoCheckPorn = new System.Windows.Forms.Panel();
            this.lblSearchNoCheckPorn = new System.Windows.Forms.Label();
            this.rdoNoCheckPornDontSend = new System.Windows.Forms.RadioButton();
            this.rdoNoCheckPornSend = new System.Windows.Forms.RadioButton();
            this.chkASCII2DRequestByWebBrowser = new System.Windows.Forms.CheckBox();
            this.pnlPictureSearcherCheckPorn = new System.Windows.Forms.Panel();
            this.lblSearchCheckPornOutOfLimitReply = new System.Windows.Forms.Label();
            this.txbSearchCheckPornOutOfLimitReply = new System.Windows.Forms.TextBox();
            this.rdoSearchCheckPornOutOfLimitAppend = new System.Windows.Forms.RadioButton();
            this.rdoSearchCheckPornOutOfLimitDontSend = new System.Windows.Forms.RadioButton();
            this.rdoSearchCheckPornOutOfLimitSend = new System.Windows.Forms.RadioButton();
            this.lblSearchCheckPornOutOfLimit = new System.Windows.Forms.Label();
            this.txbSearchCheckPornIllegalReply = new System.Windows.Forms.TextBox();
            this.lblSearchCheckPornIllegalReply = new System.Windows.Forms.Label();
            this.lblSearchCheckPornErrorReply = new System.Windows.Forms.Label();
            this.txbSearchCheckPornErrorReply = new System.Windows.Forms.TextBox();
            this.chkPictureSearcherCheckPornEnabled = new System.Windows.Forms.CheckBox();
            this.chkTraceMoeEnabled = new System.Windows.Forms.CheckBox();
            this.lblSearchLowSimilarityReply = new System.Windows.Forms.Label();
            this.lblSearchLowSimilarity = new System.Windows.Forms.Label();
            this.lblSearchErrorReply = new System.Windows.Forms.Label();
            this.lblSearchNoResultReply = new System.Windows.Forms.Label();
            this.lblSearchModeAlreadyOffReply = new System.Windows.Forms.Label();
            this.lblSearchModeTimeOutReply = new System.Windows.Forms.Label();
            this.lblSearchModeOffCmd = new System.Windows.Forms.Label();
            this.lblSearchModeOffReply = new System.Windows.Forms.Label();
            this.lblSearchModeAlreadyOnReply = new System.Windows.Forms.Label();
            this.lblSearchModeOnReply = new System.Windows.Forms.Label();
            this.lblTraceMoeSendThreshold = new System.Windows.Forms.Label();
            this.lblSauceNAOApiKey = new System.Windows.Forms.Label();
            this.lblSearchModeOnCmd = new System.Windows.Forms.Label();
            this.txbSearchLowSimilarityReply = new System.Windows.Forms.TextBox();
            this.txbSearchLowSimilarity = new System.Windows.Forms.TextBox();
            this.txbSearchErrorReply = new System.Windows.Forms.TextBox();
            this.txbSearchNoResultReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeTimeOutReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeOffCmd = new System.Windows.Forms.TextBox();
            this.txbSearchModeAlreadyOffReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeOffReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeAlreadyOnReply = new System.Windows.Forms.TextBox();
            this.txbTraceMoeSendThreshold = new System.Windows.Forms.TextBox();
            this.txbSearchModeOnReply = new System.Windows.Forms.TextBox();
            this.txbSauceNAOApiKey = new System.Windows.Forms.TextBox();
            this.txbSearchModeOnCmd = new System.Windows.Forms.TextBox();
            this.chkSearchASCII2DEnabled = new System.Windows.Forms.CheckBox();
            this.chkSearchSauceNAOEnabled = new System.Windows.Forms.CheckBox();
            this.tabOriginPicture = new System.Windows.Forms.TabPage();
            this.pnlOriginPicture = new System.Windows.Forms.Panel();
            this.chkOriginPictureCheckPornEnabled = new System.Windows.Forms.CheckBox();
            this.pnlOriginPictureCheckPorn = new System.Windows.Forms.Panel();
            this.pnlOriginPictureCheckPornMessage = new System.Windows.Forms.Panel();
            this.lblOriginPictureCheckPornIllegalReply = new System.Windows.Forms.Label();
            this.txbOriginPictureCheckPornErrorReply = new System.Windows.Forms.TextBox();
            this.txbOriginPictureCheckPornIllegalReply = new System.Windows.Forms.TextBox();
            this.lblOriginPictureCheckPornErrorReply = new System.Windows.Forms.Label();
            this.pnlOriginPictureCheckPornEvent = new System.Windows.Forms.Panel();
            this.rdoOriginPictureCheckPornSendByForward = new System.Windows.Forms.RadioButton();
            this.rdoOriginPictureCheckPornDoNothing = new System.Windows.Forms.RadioButton();
            this.rdoOriginPictureCheckPornReply = new System.Windows.Forms.RadioButton();
            this.lblOriginPictureCheckPornEvent = new System.Windows.Forms.Label();
            this.chkOriginPictureEnabled = new System.Windows.Forms.CheckBox();
            this.tabTranslate = new System.Windows.Forms.TabPage();
            this.pnlTranslate = new System.Windows.Forms.Panel();
            this.txbTranslateFromToCMD = new System.Windows.Forms.TextBox();
            this.lblTranslateFromTo = new System.Windows.Forms.Label();
            this.lblTranslateEngineHelp = new System.Windows.Forms.Label();
            this.cboTranslateEngine = new System.Windows.Forms.ComboBox();
            this.lblTranslateEngine = new System.Windows.Forms.Label();
            this.txbAddAutoTranslateGroupMemoryQQ = new System.Windows.Forms.TextBox();
            this.btnRemoveAutoTranslateGroupMemoryQQ = new System.Windows.Forms.Button();
            this.btnAddAutoTranslateGroupMemoryQQ = new System.Windows.Forms.Button();
            this.lstAutoTranslateGroupMemoriesQQ = new System.Windows.Forms.ListView();
            this.lblAddAutoTranslateGroupMemoryQQ = new System.Windows.Forms.Label();
            this.lblAutoTranslateGroupMemoriesQQ = new System.Windows.Forms.Label();
            this.txbTranslateTo = new System.Windows.Forms.TextBox();
            this.txbTranslateToChinese = new System.Windows.Forms.TextBox();
            this.lblTranslateTo = new System.Windows.Forms.Label();
            this.lblTranslateToChinese = new System.Windows.Forms.Label();
            this.chkTranslateEnabled = new System.Windows.Forms.CheckBox();
            this.tabHPicture = new System.Windows.Forms.TabPage();
            this.pnlEnabelHPicture = new System.Windows.Forms.Panel();
            this.lblHPictureOnceMessageMaxImageCountHelp = new System.Windows.Forms.Label();
            this.txbHPictureOnceMessageMaxImageCount = new System.Windows.Forms.TextBox();
            this.lblHPictureOnceMessageMaxImageCount = new System.Windows.Forms.Label();
            this.lblBeautyPictureSource = new System.Windows.Forms.Label();
            this.lblHPictureSource = new System.Windows.Forms.Label();
            this.chkEnabledGreenOnionsBeautyPicture = new System.Windows.Forms.CheckBox();
            this.chkEnabledGreenOnionsHPicture = new System.Windows.Forms.CheckBox();
            this.chkEnabledELFBeautyPicture = new System.Windows.Forms.CheckBox();
            this.chkRevokeBeautyPicture = new System.Windows.Forms.CheckBox();
            this.chkEnabledLoliconHPicture = new System.Windows.Forms.CheckBox();
            this.lblMultithreading = new System.Windows.Forms.Label();
            this.chkMultithreading = new System.Windows.Forms.CheckBox();
            this.rodHPictureLimitCount = new System.Windows.Forms.RadioButton();
            this.rdoHPictureLimitFrequency = new System.Windows.Forms.RadioButton();
            this.txbAddToWhiteGroup = new System.Windows.Forms.TextBox();
            this.txbUserHPictureCmd = new System.Windows.Forms.TextBox();
            this.txbPMCD = new System.Windows.Forms.TextBox();
            this.txbWhiteCD = new System.Windows.Forms.TextBox();
            this.txbPMRevoke = new System.Windows.Forms.TextBox();
            this.txbWhiteRevoke = new System.Windows.Forms.TextBox();
            this.lstHPictureUserCmd = new System.Windows.Forms.ListView();
            this.lstHPictureWhiteGroup = new System.Windows.Forms.ListView();
            this.lblPMRevoke = new System.Windows.Forms.Label();
            this.lblWhiteRevoke = new System.Windows.Forms.Label();
            this.lblPMCD = new System.Windows.Forms.Label();
            this.lblWhiteCD = new System.Windows.Forms.Label();
            this.lblDownloadAccelerate = new System.Windows.Forms.Label();
            this.lblCD = new System.Windows.Forms.Label();
            this.lblDownloadFail = new System.Windows.Forms.Label();
            this.lblNoResult = new System.Windows.Forms.Label();
            this.lblErrorReply = new System.Windows.Forms.Label();
            this.lblOutOfLimitReply = new System.Windows.Forms.Label();
            this.lblCDUnreadyReply = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.lblRevoke = new System.Windows.Forms.Label();
            this.lblWhiteGroup = new System.Windows.Forms.Label();
            this.txbDownloadFailReply = new System.Windows.Forms.TextBox();
            this.txbHPictureNoResultReply = new System.Windows.Forms.TextBox();
            this.txbHPictureErrorReplyReply = new System.Windows.Forms.TextBox();
            this.txbOutOfLimitReply = new System.Windows.Forms.TextBox();
            this.txbDownloadAccelerateUrl = new System.Windows.Forms.TextBox();
            this.txbCDUnreadyReply = new System.Windows.Forms.TextBox();
            this.txbCD = new System.Windows.Forms.TextBox();
            this.txbLimit = new System.Windows.Forms.TextBox();
            this.txbRevoke = new System.Windows.Forms.TextBox();
            this.chkAllowR18 = new System.Windows.Forms.CheckBox();
            this.chkManageNoLimit = new System.Windows.Forms.CheckBox();
            this.chkAdminNoLimit = new System.Windows.Forms.CheckBox();
            this.chkWhiteNoLimit = new System.Windows.Forms.CheckBox();
            this.chkPMNoLimit = new System.Windows.Forms.CheckBox();
            this.chkR18WhiteOnly = new System.Windows.Forms.CheckBox();
            this.chkWhiteOnly = new System.Windows.Forms.CheckBox();
            this.chkDownloadAccelerate = new System.Windows.Forms.CheckBox();
            this.chkSize1200 = new System.Windows.Forms.CheckBox();
            this.chkPM = new System.Windows.Forms.CheckBox();
            this.chkAntiShielding = new System.Windows.Forms.CheckBox();
            this.lblUserCmdInformation = new System.Windows.Forms.Label();
            this.lblAddToWhiteGroupInformation = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.lblHPictureBegin = new System.Windows.Forms.Label();
            this.lblBeautyPictureCmd = new System.Windows.Forms.Label();
            this.lblLoliconHPictureCmd = new System.Windows.Forms.Label();
            this.btnRemoveWhiteGroup = new System.Windows.Forms.Button();
            this.btnAddToWhiteGroup = new System.Windows.Forms.Button();
            this.btnRemoveUserHPictureCmd = new System.Windows.Forms.Button();
            this.btnAddUserHPictureCmd = new System.Windows.Forms.Button();
            this.lblHPictureCount = new System.Windows.Forms.Label();
            this.lnkResetHPicture = new System.Windows.Forms.LinkLabel();
            this.lblHPictureUnit = new System.Windows.Forms.Label();
            this.chkBeautyPictureEndNull = new System.Windows.Forms.CheckBox();
            this.chkHPictureEndNull = new System.Windows.Forms.CheckBox();
            this.lblHPictureR18 = new System.Windows.Forms.Label();
            this.chkHPictureKeywordNull = new System.Windows.Forms.CheckBox();
            this.lblHPictureKeyword = new System.Windows.Forms.Label();
            this.chkHPictureR18Null = new System.Windows.Forms.CheckBox();
            this.lblShabHPictureEnd = new System.Windows.Forms.Label();
            this.lblHPictureEnd = new System.Windows.Forms.Label();
            this.chkHPictureUnitNull = new System.Windows.Forms.CheckBox();
            this.lblUserHPictureCmd = new System.Windows.Forms.Label();
            this.chkHPictureCountNull = new System.Windows.Forms.CheckBox();
            this.lblLimitType = new System.Windows.Forms.Label();
            this.lblUserCmd = new System.Windows.Forms.Label();
            this.chkHPictureBeginNull = new System.Windows.Forms.CheckBox();
            this.txbBeautyPictureCmd = new System.Windows.Forms.TextBox();
            this.txbHPictureCmd = new System.Windows.Forms.TextBox();
            this.txbHPictureApiKey = new System.Windows.Forms.TextBox();
            this.txbBeautyPictureEnd = new System.Windows.Forms.TextBox();
            this.txbHPictureEnd = new System.Windows.Forms.TextBox();
            this.txbHPictureBegin = new System.Windows.Forms.TextBox();
            this.txbHPictureKeyword = new System.Windows.Forms.TextBox();
            this.txbHPictureCount = new System.Windows.Forms.TextBox();
            this.txbHPictureR18 = new System.Windows.Forms.TextBox();
            this.txbHPictureUnit = new System.Windows.Forms.TextBox();
            this.chkEnabledHPicture = new System.Windows.Forms.CheckBox();
            this.tabRepeater = new System.Windows.Forms.TabPage();
            this.chkReplaceMeToYou = new System.Windows.Forms.CheckBox();
            this.chkRewindGif = new System.Windows.Forms.CheckBox();
            this.lblRewindGifProbability = new System.Windows.Forms.Label();
            this.lblVerticalMirrorImageProbability = new System.Windows.Forms.Label();
            this.lblHorizontalMirrorImageProbability = new System.Windows.Forms.Label();
            this.lblSuccessiveRepeatCount = new System.Windows.Forms.Label();
            this.txbRewindGifProbability = new System.Windows.Forms.TextBox();
            this.lblRandomRepeatProbability = new System.Windows.Forms.Label();
            this.txbVerticalMirrorImageProbability = new System.Windows.Forms.TextBox();
            this.txbHorizontalMirrorImageProbability = new System.Windows.Forms.TextBox();
            this.txbSuccessiveRepeatCount = new System.Windows.Forms.TextBox();
            this.txbRandomRepeatProbability = new System.Windows.Forms.TextBox();
            this.chkVerticalMirrorImage = new System.Windows.Forms.CheckBox();
            this.chkHorizontalMirrorImage = new System.Windows.Forms.CheckBox();
            this.chkSuccessiveRepeat = new System.Windows.Forms.CheckBox();
            this.chkRandomRepeat = new System.Windows.Forms.CheckBox();
            this.tabGroupMemberEvents = new System.Windows.Forms.TabPage();
            this.txbMemberBeKickedMessage = new System.Windows.Forms.TextBox();
            this.txbMemberPositiveLeaveMessage = new System.Windows.Forms.TextBox();
            this.txbMemberJoinedMessage = new System.Windows.Forms.TextBox();
            this.chkSendMemberBeKickedMessage = new System.Windows.Forms.CheckBox();
            this.chkSendMemberPositiveLeaveMessage = new System.Windows.Forms.CheckBox();
            this.chkSendMemberJoinedMessage = new System.Windows.Forms.CheckBox();
            this.tabForgeMessage = new System.Windows.Forms.TabPage();
            this.pnlForgeMessage = new System.Windows.Forms.Panel();
            this.lblForgeMessageCmd = new System.Windows.Forms.Label();
            this.txbForgeMessageCmd = new System.Windows.Forms.TextBox();
            this.chkForgeMessageAdminDontAppend = new System.Windows.Forms.CheckBox();
            this.chkForgeMessageAdminOnly = new System.Windows.Forms.CheckBox();
            this.chkRefuseForgeBot = new System.Windows.Forms.CheckBox();
            this.chkRefuseForgeAdmin = new System.Windows.Forms.CheckBox();
            this.lblRefuseForgeBotReply = new System.Windows.Forms.Label();
            this.chkForgeMessageAppendBotMessageEnabled = new System.Windows.Forms.CheckBox();
            this.lblRefuseForgeAdminReply = new System.Windows.Forms.Label();
            this.txbRefuseForgeBotReply = new System.Windows.Forms.TextBox();
            this.lblForgeMessageAppendSelfMessage = new System.Windows.Forms.Label();
            this.txbRefuseForgeAdminReply = new System.Windows.Forms.TextBox();
            this.txbForgeMessageAppendMessage = new System.Windows.Forms.TextBox();
            this.lblForgeMessageCmdNewLine = new System.Windows.Forms.Label();
            this.txbForgeMessageCmdNewLine = new System.Windows.Forms.TextBox();
            this.lblForgeMessageCmdBegin = new System.Windows.Forms.Label();
            this.txbForgeMessageCmdBegin = new System.Windows.Forms.TextBox();
            this.chkEnabledForgeMessage = new System.Windows.Forms.CheckBox();
            this.tabRss = new System.Windows.Forms.TabPage();
            this.pnlRss = new System.Windows.Forms.Panel();
            this.pnlRssSubscriptionList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRssSubscription = new System.Windows.Forms.Button();
            this.txbReadRssInterval = new System.Windows.Forms.TextBox();
            this.lblReadRssInterval = new System.Windows.Forms.Label();
            this.chkRssEnabled = new System.Windows.Forms.CheckBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.txbContributorName = new System.Windows.Forms.TextBox();
            this.txbContributorQQ = new System.Windows.Forms.TextBox();
            this.lnkProjectURL = new System.Windows.Forms.LinkLabel();
            this.lnkContributorGithub = new System.Windows.Forms.LinkLabel();
            this.lblProjectURL = new System.Windows.Forms.Label();
            this.lblContributorGithub = new System.Windows.Forms.Label();
            this.lblContributorQQ = new System.Windows.Forms.Label();
            this.lblContributorName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabBot.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.pnlDebugMode.SuspendLayout();
            this.pnlCheckPorn.SuspendLayout();
            this.tabSearchPicture.SuspendLayout();
            this.pnlSearchPicture.SuspendLayout();
            this.pnlNoCheckPorn.SuspendLayout();
            this.pnlPictureSearcherCheckPorn.SuspendLayout();
            this.tabOriginPicture.SuspendLayout();
            this.pnlOriginPicture.SuspendLayout();
            this.pnlOriginPictureCheckPorn.SuspendLayout();
            this.pnlOriginPictureCheckPornMessage.SuspendLayout();
            this.pnlOriginPictureCheckPornEvent.SuspendLayout();
            this.tabTranslate.SuspendLayout();
            this.pnlTranslate.SuspendLayout();
            this.tabHPicture.SuspendLayout();
            this.pnlEnabelHPicture.SuspendLayout();
            this.tabRepeater.SuspendLayout();
            this.tabGroupMemberEvents.SuspendLayout();
            this.tabForgeMessage.SuspendLayout();
            this.pnlForgeMessage.SuspendLayout();
            this.tabRss.SuspendLayout();
            this.pnlRss.SuspendLayout();
            this.pnlRssSubscriptionList.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbBotName
            // 
            this.txbBotName.Location = new System.Drawing.Point(125, 6);
            this.txbBotName.Margin = new System.Windows.Forms.Padding(4);
            this.txbBotName.Name = "txbBotName";
            this.txbBotName.Size = new System.Drawing.Size(480, 23);
            this.txbBotName.TabIndex = 0;
            // 
            // lblBotName
            // 
            this.lblBotName.AutoSize = true;
            this.lblBotName.Location = new System.Drawing.Point(7, 11);
            this.lblBotName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBotName.Name = "lblBotName";
            this.lblBotName.Size = new System.Drawing.Size(80, 17);
            this.lblBotName.TabIndex = 1;
            this.lblBotName.Text = "机器人名称：";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(305, 729);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txbAddAdmin
            // 
            this.txbAddAdmin.Location = new System.Drawing.Point(415, 59);
            this.txbAddAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddAdmin.Name = "txbAddAdmin";
            this.txbAddAdmin.ShortcutsEnabled = false;
            this.txbAddAdmin.Size = new System.Drawing.Size(186, 23);
            this.txbAddAdmin.TabIndex = 0;
            this.txbAddAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbAddAdmin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(7, 38);
            this.lblAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(112, 17);
            this.lblAdmin.TabIndex = 1;
            this.lblAdmin.Text = "机器人管理员QQ：";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabBot);
            this.tabControl1.Controls.Add(this.tabSearchPicture);
            this.tabControl1.Controls.Add(this.tabOriginPicture);
            this.tabControl1.Controls.Add(this.tabTranslate);
            this.tabControl1.Controls.Add(this.tabHPicture);
            this.tabControl1.Controls.Add(this.tabRepeater);
            this.tabControl1.Controls.Add(this.tabGroupMemberEvents);
            this.tabControl1.Controls.Add(this.tabForgeMessage);
            this.tabControl1.Controls.Add(this.tabRss);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Location = new System.Drawing.Point(14, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 717);
            this.tabControl1.TabIndex = 4;
            // 
            // tabBot
            // 
            this.tabBot.Controls.Add(this.pnlBot);
            this.tabBot.Location = new System.Drawing.Point(4, 26);
            this.tabBot.Margin = new System.Windows.Forms.Padding(4);
            this.tabBot.Name = "tabBot";
            this.tabBot.Padding = new System.Windows.Forms.Padding(4);
            this.tabBot.Size = new System.Drawing.Size(652, 687);
            this.tabBot.TabIndex = 1;
            this.tabBot.Text = "机器人设置";
            this.tabBot.UseVisualStyleBackColor = true;
            // 
            // pnlBot
            // 
            this.pnlBot.AutoScroll = true;
            this.pnlBot.Controls.Add(this.chkHttpRequestByWebBrowser);
            this.pnlBot.Controls.Add(this.chkCheckPornEnabled);
            this.pnlBot.Controls.Add(this.chkImageCache);
            this.pnlBot.Controls.Add(this.pnlDebugMode);
            this.pnlBot.Controls.Add(this.txbBanUser);
            this.pnlBot.Controls.Add(this.pnlCheckPorn);
            this.pnlBot.Controls.Add(this.txbBanGroup);
            this.pnlBot.Controls.Add(this.chkDebugMode);
            this.pnlBot.Controls.Add(this.txbAddAdmin);
            this.pnlBot.Controls.Add(this.lblBotName);
            this.pnlBot.Controls.Add(this.btnRemoveBanUser);
            this.pnlBot.Controls.Add(this.lblImageCache);
            this.pnlBot.Controls.Add(this.btnRemoveBanGroup);
            this.pnlBot.Controls.Add(this.txbBotName);
            this.pnlBot.Controls.Add(this.btnRemoveAdmin);
            this.pnlBot.Controls.Add(this.lblAdmin);
            this.pnlBot.Controls.Add(this.btnAddBanUser);
            this.pnlBot.Controls.Add(this.lblAddAdmin);
            this.pnlBot.Controls.Add(this.btnAddBanGroup);
            this.pnlBot.Controls.Add(this.lblBannedGroup);
            this.pnlBot.Controls.Add(this.btnAddAdmin);
            this.pnlBot.Controls.Add(this.lstAdmins);
            this.pnlBot.Controls.Add(this.lstBannedUser);
            this.pnlBot.Controls.Add(this.lblBannedUser);
            this.pnlBot.Controls.Add(this.lblBanUser);
            this.pnlBot.Controls.Add(this.lblBanGroup);
            this.pnlBot.Controls.Add(this.lstBannedGroup);
            this.pnlBot.Location = new System.Drawing.Point(3, 7);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(642, 677);
            this.pnlBot.TabIndex = 36;
            // 
            // chkHttpRequestByWebBrowser
            // 
            this.chkHttpRequestByWebBrowser.AutoSize = true;
            this.chkHttpRequestByWebBrowser.Location = new System.Drawing.Point(7, 454);
            this.chkHttpRequestByWebBrowser.Name = "chkHttpRequestByWebBrowser";
            this.chkHttpRequestByWebBrowser.Size = new System.Drawing.Size(269, 21);
            this.chkHttpRequestByWebBrowser.TabIndex = 36;
            this.chkHttpRequestByWebBrowser.Text = "允许调用浏览器执行Http请求(仅限Windows)";
            this.chkHttpRequestByWebBrowser.UseVisualStyleBackColor = true;
            // 
            // chkCheckPornEnabled
            // 
            this.chkCheckPornEnabled.AutoSize = true;
            this.chkCheckPornEnabled.Location = new System.Drawing.Point(7, 481);
            this.chkCheckPornEnabled.Name = "chkCheckPornEnabled";
            this.chkCheckPornEnabled.Size = new System.Drawing.Size(111, 21);
            this.chkCheckPornEnabled.TabIndex = 34;
            this.chkCheckPornEnabled.Text = "接入腾讯云鉴黄";
            this.chkCheckPornEnabled.UseVisualStyleBackColor = true;
            this.chkCheckPornEnabled.CheckedChanged += new System.EventHandler(this.chkCheckPorn_CheckedChanged);
            // 
            // chkImageCache
            // 
            this.chkImageCache.AutoSize = true;
            this.chkImageCache.Location = new System.Drawing.Point(7, 138);
            this.chkImageCache.Name = "chkImageCache";
            this.chkImageCache.Size = new System.Drawing.Size(111, 21);
            this.chkImageCache.TabIndex = 8;
            this.chkImageCache.Text = "储存图片到硬盘";
            this.chkImageCache.UseVisualStyleBackColor = true;
            // 
            // pnlDebugMode
            // 
            this.pnlDebugMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDebugMode.Controls.Add(this.chkOnlyReplyDebugGroup);
            this.pnlDebugMode.Controls.Add(this.lstDebugGroups);
            this.pnlDebugMode.Controls.Add(this.chkDebugReplyAdminOnly);
            this.pnlDebugMode.Controls.Add(this.lblAddDebugGroup);
            this.pnlDebugMode.Controls.Add(this.lblDebugGroup);
            this.pnlDebugMode.Controls.Add(this.btnAddDebugGroup);
            this.pnlDebugMode.Controls.Add(this.btnRemoveDebugGroup);
            this.pnlDebugMode.Controls.Add(this.txbAddDebugGroup);
            this.pnlDebugMode.Enabled = false;
            this.pnlDebugMode.Location = new System.Drawing.Point(4, 712);
            this.pnlDebugMode.Name = "pnlDebugMode";
            this.pnlDebugMode.Size = new System.Drawing.Size(533, 153);
            this.pnlDebugMode.TabIndex = 12;
            // 
            // chkOnlyReplyDebugGroup
            // 
            this.chkOnlyReplyDebugGroup.AutoSize = true;
            this.chkOnlyReplyDebugGroup.Location = new System.Drawing.Point(125, 101);
            this.chkOnlyReplyDebugGroup.Name = "chkOnlyReplyDebugGroup";
            this.chkOnlyReplyDebugGroup.Size = new System.Drawing.Size(147, 21);
            this.chkOnlyReplyDebugGroup.TabIndex = 12;
            this.chkOnlyReplyDebugGroup.Text = "只响应调试群组的消息";
            this.chkOnlyReplyDebugGroup.UseVisualStyleBackColor = true;
            // 
            // lstDebugGroups
            // 
            this.lstDebugGroups.FullRowSelect = true;
            this.lstDebugGroups.HideSelection = false;
            this.lstDebugGroups.Location = new System.Drawing.Point(125, 9);
            this.lstDebugGroups.Margin = new System.Windows.Forms.Padding(4);
            this.lstDebugGroups.Name = "lstDebugGroups";
            this.lstDebugGroups.Size = new System.Drawing.Size(186, 85);
            this.lstDebugGroups.TabIndex = 3;
            this.lstDebugGroups.UseCompatibleStateImageBehavior = false;
            this.lstDebugGroups.View = System.Windows.Forms.View.List;
            // 
            // chkDebugReplyAdminOnly
            // 
            this.chkDebugReplyAdminOnly.AutoSize = true;
            this.chkDebugReplyAdminOnly.Location = new System.Drawing.Point(125, 128);
            this.chkDebugReplyAdminOnly.Name = "chkDebugReplyAdminOnly";
            this.chkDebugReplyAdminOnly.Size = new System.Drawing.Size(195, 21);
            this.chkDebugReplyAdminOnly.TabIndex = 11;
            this.chkDebugReplyAdminOnly.Text = "只响应来自机器人管理员的消息";
            this.chkDebugReplyAdminOnly.UseVisualStyleBackColor = true;
            // 
            // lblAddDebugGroup
            // 
            this.lblAddDebugGroup.AutoSize = true;
            this.lblAddDebugGroup.Location = new System.Drawing.Point(413, 9);
            this.lblAddDebugGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddDebugGroup.Name = "lblAddDebugGroup";
            this.lblAddDebugGroup.Size = new System.Drawing.Size(116, 17);
            this.lblAddDebugGroup.TabIndex = 1;
            this.lblAddDebugGroup.Text = "添加调试模式群号：";
            // 
            // lblDebugGroup
            // 
            this.lblDebugGroup.AutoSize = true;
            this.lblDebugGroup.Location = new System.Drawing.Point(5, 20);
            this.lblDebugGroup.Name = "lblDebugGroup";
            this.lblDebugGroup.Size = new System.Drawing.Size(68, 17);
            this.lblDebugGroup.TabIndex = 10;
            this.lblDebugGroup.Text = "调试群组：";
            // 
            // btnAddDebugGroup
            // 
            this.btnAddDebugGroup.Location = new System.Drawing.Point(319, 30);
            this.btnAddDebugGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDebugGroup.Name = "btnAddDebugGroup";
            this.btnAddDebugGroup.Size = new System.Drawing.Size(88, 23);
            this.btnAddDebugGroup.TabIndex = 4;
            this.btnAddDebugGroup.Text = "<<添加<<";
            this.btnAddDebugGroup.UseVisualStyleBackColor = true;
            this.btnAddDebugGroup.Click += new System.EventHandler(this.btnAddDebugGroup_Click);
            // 
            // btnRemoveDebugGroup
            // 
            this.btnRemoveDebugGroup.Location = new System.Drawing.Point(319, 61);
            this.btnRemoveDebugGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveDebugGroup.Name = "btnRemoveDebugGroup";
            this.btnRemoveDebugGroup.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveDebugGroup.TabIndex = 4;
            this.btnRemoveDebugGroup.Text = ">>移除>>";
            this.btnRemoveDebugGroup.UseVisualStyleBackColor = true;
            this.btnRemoveDebugGroup.Click += new System.EventHandler(this.btnRemoveDebugGroup_Click);
            // 
            // txbAddDebugGroup
            // 
            this.txbAddDebugGroup.Location = new System.Drawing.Point(415, 30);
            this.txbAddDebugGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddDebugGroup.Name = "txbAddDebugGroup";
            this.txbAddDebugGroup.ShortcutsEnabled = false;
            this.txbAddDebugGroup.Size = new System.Drawing.Size(186, 23);
            this.txbAddDebugGroup.TabIndex = 0;
            this.txbAddDebugGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbAddDebugGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbBanUser
            // 
            this.txbBanUser.Location = new System.Drawing.Point(415, 333);
            this.txbBanUser.Margin = new System.Windows.Forms.Padding(4);
            this.txbBanUser.Name = "txbBanUser";
            this.txbBanUser.ShortcutsEnabled = false;
            this.txbBanUser.Size = new System.Drawing.Size(186, 23);
            this.txbBanUser.TabIndex = 0;
            this.txbBanUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbBanUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // pnlCheckPorn
            // 
            this.pnlCheckPorn.Controls.Add(this.label1);
            this.pnlCheckPorn.Controls.Add(this.lblCheckPornLimitCount);
            this.pnlCheckPorn.Controls.Add(this.txbCheckPornLimitCount);
            this.pnlCheckPorn.Controls.Add(this.lblTencentCloudBucket);
            this.pnlCheckPorn.Controls.Add(this.lblTencentCloudSecretKey);
            this.pnlCheckPorn.Controls.Add(this.txbTencentCloudBucket);
            this.pnlCheckPorn.Controls.Add(this.lblTencentCloudSecretId);
            this.pnlCheckPorn.Controls.Add(this.txbTencentCloudRegion);
            this.pnlCheckPorn.Controls.Add(this.lblTencentCloudRegion);
            this.pnlCheckPorn.Controls.Add(this.lblTencentCloudAPPID);
            this.pnlCheckPorn.Controls.Add(this.txbTencentCloudSecretId);
            this.pnlCheckPorn.Controls.Add(this.txbTencentCloudAPPID);
            this.pnlCheckPorn.Controls.Add(this.txbTencentCloudSecretKey);
            this.pnlCheckPorn.Enabled = false;
            this.pnlCheckPorn.Location = new System.Drawing.Point(4, 508);
            this.pnlCheckPorn.Name = "pnlCheckPorn";
            this.pnlCheckPorn.Size = new System.Drawing.Size(618, 174);
            this.pnlCheckPorn.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "(建议按自己腾讯云购买次数填 2021-12-28 更新 每日免费2000次)";
            // 
            // lblCheckPornLimitCount
            // 
            this.lblCheckPornLimitCount.AutoSize = true;
            this.lblCheckPornLimitCount.Location = new System.Drawing.Point(3, 151);
            this.lblCheckPornLimitCount.Name = "lblCheckPornLimitCount";
            this.lblCheckPornLimitCount.Size = new System.Drawing.Size(107, 17);
            this.lblCheckPornLimitCount.TabIndex = 48;
            this.lblCheckPornLimitCount.Text = "每日鉴黄次数限制:";
            // 
            // txbCheckPornLimitCount
            // 
            this.txbCheckPornLimitCount.Location = new System.Drawing.Point(161, 148);
            this.txbCheckPornLimitCount.Name = "txbCheckPornLimitCount";
            this.txbCheckPornLimitCount.Size = new System.Drawing.Size(74, 23);
            this.txbCheckPornLimitCount.TabIndex = 47;
            // 
            // lblTencentCloudBucket
            // 
            this.lblTencentCloudBucket.AutoSize = true;
            this.lblTencentCloudBucket.Location = new System.Drawing.Point(3, 122);
            this.lblTencentCloudBucket.Name = "lblTencentCloudBucket";
            this.lblTencentCloudBucket.Size = new System.Drawing.Size(86, 17);
            this.lblTencentCloudBucket.TabIndex = 32;
            this.lblTencentCloudBucket.Text = "腾讯云Bucket:";
            // 
            // lblTencentCloudSecretKey
            // 
            this.lblTencentCloudSecretKey.AutoSize = true;
            this.lblTencentCloudSecretKey.Location = new System.Drawing.Point(3, 93);
            this.lblTencentCloudSecretKey.Name = "lblTencentCloudSecretKey";
            this.lblTencentCloudSecretKey.Size = new System.Drawing.Size(104, 17);
            this.lblTencentCloudSecretKey.TabIndex = 31;
            this.lblTencentCloudSecretKey.Text = "腾讯云SecretKey:";
            // 
            // txbTencentCloudBucket
            // 
            this.txbTencentCloudBucket.Location = new System.Drawing.Point(161, 119);
            this.txbTencentCloudBucket.Name = "txbTencentCloudBucket";
            this.txbTencentCloudBucket.Size = new System.Drawing.Size(440, 23);
            this.txbTencentCloudBucket.TabIndex = 16;
            // 
            // lblTencentCloudSecretId
            // 
            this.lblTencentCloudSecretId.AutoSize = true;
            this.lblTencentCloudSecretId.Location = new System.Drawing.Point(3, 64);
            this.lblTencentCloudSecretId.Name = "lblTencentCloudSecretId";
            this.lblTencentCloudSecretId.Size = new System.Drawing.Size(95, 17);
            this.lblTencentCloudSecretId.TabIndex = 30;
            this.lblTencentCloudSecretId.Text = "腾讯云SecretId:";
            // 
            // txbTencentCloudRegion
            // 
            this.txbTencentCloudRegion.Location = new System.Drawing.Point(161, 32);
            this.txbTencentCloudRegion.Name = "txbTencentCloudRegion";
            this.txbTencentCloudRegion.Size = new System.Drawing.Size(440, 23);
            this.txbTencentCloudRegion.TabIndex = 16;
            // 
            // lblTencentCloudRegion
            // 
            this.lblTencentCloudRegion.AutoSize = true;
            this.lblTencentCloudRegion.Location = new System.Drawing.Point(3, 35);
            this.lblTencentCloudRegion.Name = "lblTencentCloudRegion";
            this.lblTencentCloudRegion.Size = new System.Drawing.Size(85, 17);
            this.lblTencentCloudRegion.TabIndex = 29;
            this.lblTencentCloudRegion.Text = "腾讯云Region";
            // 
            // lblTencentCloudAPPID
            // 
            this.lblTencentCloudAPPID.AutoSize = true;
            this.lblTencentCloudAPPID.Location = new System.Drawing.Point(3, 6);
            this.lblTencentCloudAPPID.Name = "lblTencentCloudAPPID";
            this.lblTencentCloudAPPID.Size = new System.Drawing.Size(82, 17);
            this.lblTencentCloudAPPID.TabIndex = 28;
            this.lblTencentCloudAPPID.Text = "腾讯云APPID:";
            // 
            // txbTencentCloudSecretId
            // 
            this.txbTencentCloudSecretId.Location = new System.Drawing.Point(161, 61);
            this.txbTencentCloudSecretId.Name = "txbTencentCloudSecretId";
            this.txbTencentCloudSecretId.Size = new System.Drawing.Size(440, 23);
            this.txbTencentCloudSecretId.TabIndex = 16;
            // 
            // txbTencentCloudAPPID
            // 
            this.txbTencentCloudAPPID.Location = new System.Drawing.Point(161, 3);
            this.txbTencentCloudAPPID.Name = "txbTencentCloudAPPID";
            this.txbTencentCloudAPPID.Size = new System.Drawing.Size(440, 23);
            this.txbTencentCloudAPPID.TabIndex = 16;
            // 
            // txbTencentCloudSecretKey
            // 
            this.txbTencentCloudSecretKey.Location = new System.Drawing.Point(161, 90);
            this.txbTencentCloudSecretKey.Name = "txbTencentCloudSecretKey";
            this.txbTencentCloudSecretKey.Size = new System.Drawing.Size(440, 23);
            this.txbTencentCloudSecretKey.TabIndex = 16;
            // 
            // txbBanGroup
            // 
            this.txbBanGroup.Location = new System.Drawing.Point(415, 187);
            this.txbBanGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txbBanGroup.Name = "txbBanGroup";
            this.txbBanGroup.ShortcutsEnabled = false;
            this.txbBanGroup.Size = new System.Drawing.Size(186, 23);
            this.txbBanGroup.TabIndex = 0;
            this.txbBanGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbBanGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // chkDebugMode
            // 
            this.chkDebugMode.AutoSize = true;
            this.chkDebugMode.Location = new System.Drawing.Point(7, 688);
            this.chkDebugMode.Name = "chkDebugMode";
            this.chkDebugMode.Size = new System.Drawing.Size(75, 21);
            this.chkDebugMode.TabIndex = 9;
            this.chkDebugMode.Text = "调试模式";
            this.chkDebugMode.UseVisualStyleBackColor = true;
            this.chkDebugMode.CheckedChanged += new System.EventHandler(this.chkDebugMode_CheckedChanged);
            // 
            // btnRemoveBanUser
            // 
            this.btnRemoveBanUser.Location = new System.Drawing.Point(319, 374);
            this.btnRemoveBanUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveBanUser.Name = "btnRemoveBanUser";
            this.btnRemoveBanUser.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveBanUser.TabIndex = 4;
            this.btnRemoveBanUser.Text = ">>移除>>";
            this.btnRemoveBanUser.UseVisualStyleBackColor = true;
            this.btnRemoveBanUser.Click += new System.EventHandler(this.btnRemoveBanUser_Click);
            // 
            // lblImageCache
            // 
            this.lblImageCache.AutoSize = true;
            this.lblImageCache.Location = new System.Drawing.Point(125, 138);
            this.lblImageCache.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImageCache.Name = "lblImageCache";
            this.lblImageCache.Size = new System.Drawing.Size(314, 17);
            this.lblImageCache.TabIndex = 2;
            this.lblImageCache.Text = "启用后，下载的所有图片都会储存在机器人目录\\Image下";
            // 
            // btnRemoveBanGroup
            // 
            this.btnRemoveBanGroup.Location = new System.Drawing.Point(319, 228);
            this.btnRemoveBanGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveBanGroup.Name = "btnRemoveBanGroup";
            this.btnRemoveBanGroup.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveBanGroup.TabIndex = 4;
            this.btnRemoveBanGroup.Text = ">>移除>>";
            this.btnRemoveBanGroup.UseVisualStyleBackColor = true;
            this.btnRemoveBanGroup.Click += new System.EventHandler(this.btnRemoveBanGroup_Click);
            // 
            // btnRemoveAdmin
            // 
            this.btnRemoveAdmin.Location = new System.Drawing.Point(319, 90);
            this.btnRemoveAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAdmin.Name = "btnRemoveAdmin";
            this.btnRemoveAdmin.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveAdmin.TabIndex = 4;
            this.btnRemoveAdmin.Text = ">>移除>>";
            this.btnRemoveAdmin.UseVisualStyleBackColor = true;
            this.btnRemoveAdmin.Click += new System.EventHandler(this.btnRemoveAdmin_Click);
            // 
            // btnAddBanUser
            // 
            this.btnAddBanUser.Location = new System.Drawing.Point(319, 333);
            this.btnAddBanUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBanUser.Name = "btnAddBanUser";
            this.btnAddBanUser.Size = new System.Drawing.Size(88, 23);
            this.btnAddBanUser.TabIndex = 4;
            this.btnAddBanUser.Text = "<<添加<<";
            this.btnAddBanUser.UseVisualStyleBackColor = true;
            this.btnAddBanUser.Click += new System.EventHandler(this.btnAddBanUser_Click);
            // 
            // lblAddAdmin
            // 
            this.lblAddAdmin.AutoSize = true;
            this.lblAddAdmin.Location = new System.Drawing.Point(413, 38);
            this.lblAddAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddAdmin.Name = "lblAddAdmin";
            this.lblAddAdmin.Size = new System.Drawing.Size(100, 17);
            this.lblAddAdmin.TabIndex = 1;
            this.lblAddAdmin.Text = "添加管理员QQ：";
            // 
            // btnAddBanGroup
            // 
            this.btnAddBanGroup.Location = new System.Drawing.Point(319, 187);
            this.btnAddBanGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBanGroup.Name = "btnAddBanGroup";
            this.btnAddBanGroup.Size = new System.Drawing.Size(88, 23);
            this.btnAddBanGroup.TabIndex = 4;
            this.btnAddBanGroup.Text = "<<添加<<";
            this.btnAddBanGroup.UseVisualStyleBackColor = true;
            this.btnAddBanGroup.Click += new System.EventHandler(this.btnAddBanGroup_Click);
            // 
            // lblBannedGroup
            // 
            this.lblBannedGroup.AutoSize = true;
            this.lblBannedGroup.Location = new System.Drawing.Point(7, 166);
            this.lblBannedGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBannedGroup.Name = "lblBannedGroup";
            this.lblBannedGroup.Size = new System.Drawing.Size(68, 17);
            this.lblBannedGroup.TabIndex = 1;
            this.lblBannedGroup.Text = "群黑名单：";
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.Location = new System.Drawing.Point(319, 59);
            this.btnAddAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAdmin.Name = "btnAddAdmin";
            this.btnAddAdmin.Size = new System.Drawing.Size(88, 23);
            this.btnAddAdmin.TabIndex = 4;
            this.btnAddAdmin.Text = "<<添加<<";
            this.btnAddAdmin.UseVisualStyleBackColor = true;
            this.btnAddAdmin.Click += new System.EventHandler(this.btnAddAdmin_Click);
            // 
            // lstAdmins
            // 
            this.lstAdmins.FullRowSelect = true;
            this.lstAdmins.HideSelection = false;
            this.lstAdmins.Location = new System.Drawing.Point(125, 37);
            this.lstAdmins.Margin = new System.Windows.Forms.Padding(4);
            this.lstAdmins.Name = "lstAdmins";
            this.lstAdmins.Size = new System.Drawing.Size(186, 85);
            this.lstAdmins.TabIndex = 3;
            this.lstAdmins.UseCompatibleStateImageBehavior = false;
            this.lstAdmins.View = System.Windows.Forms.View.List;
            // 
            // lstBannedUser
            // 
            this.lstBannedUser.FullRowSelect = true;
            this.lstBannedUser.HideSelection = false;
            this.lstBannedUser.Location = new System.Drawing.Point(125, 311);
            this.lstBannedUser.Margin = new System.Windows.Forms.Padding(4);
            this.lstBannedUser.Name = "lstBannedUser";
            this.lstBannedUser.Size = new System.Drawing.Size(186, 136);
            this.lstBannedUser.TabIndex = 3;
            this.lstBannedUser.UseCompatibleStateImageBehavior = false;
            this.lstBannedUser.View = System.Windows.Forms.View.List;
            // 
            // lblBannedUser
            // 
            this.lblBannedUser.AutoSize = true;
            this.lblBannedUser.Location = new System.Drawing.Point(7, 312);
            this.lblBannedUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBannedUser.Name = "lblBannedUser";
            this.lblBannedUser.Size = new System.Drawing.Size(80, 17);
            this.lblBannedUser.TabIndex = 1;
            this.lblBannedUser.Text = "用户黑名单：";
            // 
            // lblBanUser
            // 
            this.lblBanUser.AutoSize = true;
            this.lblBanUser.Location = new System.Drawing.Point(413, 312);
            this.lblBanUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanUser.Name = "lblBanUser";
            this.lblBanUser.Size = new System.Drawing.Size(116, 17);
            this.lblBanUser.TabIndex = 1;
            this.lblBanUser.Text = "添加到用户黑名单：";
            // 
            // lblBanGroup
            // 
            this.lblBanGroup.AutoSize = true;
            this.lblBanGroup.Location = new System.Drawing.Point(413, 166);
            this.lblBanGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanGroup.Name = "lblBanGroup";
            this.lblBanGroup.Size = new System.Drawing.Size(104, 17);
            this.lblBanGroup.TabIndex = 1;
            this.lblBanGroup.Text = "添加到群黑名单：";
            // 
            // lstBannedGroup
            // 
            this.lstBannedGroup.FullRowSelect = true;
            this.lstBannedGroup.HideSelection = false;
            this.lstBannedGroup.Location = new System.Drawing.Point(125, 165);
            this.lstBannedGroup.Margin = new System.Windows.Forms.Padding(4);
            this.lstBannedGroup.Name = "lstBannedGroup";
            this.lstBannedGroup.Size = new System.Drawing.Size(186, 136);
            this.lstBannedGroup.TabIndex = 3;
            this.lstBannedGroup.UseCompatibleStateImageBehavior = false;
            this.lstBannedGroup.View = System.Windows.Forms.View.List;
            // 
            // tabSearchPicture
            // 
            this.tabSearchPicture.Controls.Add(this.chkSearchPictureEnabled);
            this.tabSearchPicture.Controls.Add(this.pnlSearchPicture);
            this.tabSearchPicture.Location = new System.Drawing.Point(4, 26);
            this.tabSearchPicture.Name = "tabSearchPicture";
            this.tabSearchPicture.Size = new System.Drawing.Size(652, 687);
            this.tabSearchPicture.TabIndex = 3;
            this.tabSearchPicture.Text = "搜图设置";
            this.tabSearchPicture.UseVisualStyleBackColor = true;
            // 
            // chkSearchPictureEnabled
            // 
            this.chkSearchPictureEnabled.AutoSize = true;
            this.chkSearchPictureEnabled.Location = new System.Drawing.Point(9, 8);
            this.chkSearchPictureEnabled.Name = "chkSearchPictureEnabled";
            this.chkSearchPictureEnabled.Size = new System.Drawing.Size(99, 21);
            this.chkSearchPictureEnabled.TabIndex = 15;
            this.chkSearchPictureEnabled.Text = "启用搜图功能";
            this.chkSearchPictureEnabled.UseVisualStyleBackColor = true;
            this.chkSearchPictureEnabled.CheckedChanged += new System.EventHandler(this.chkSearchPictureEnabled_CheckedChanged);
            // 
            // pnlSearchPicture
            // 
            this.pnlSearchPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchPicture.AutoScroll = true;
            this.pnlSearchPicture.Controls.Add(this.label3);
            this.pnlSearchPicture.Controls.Add(this.pnlNoCheckPorn);
            this.pnlSearchPicture.Controls.Add(this.chkASCII2DRequestByWebBrowser);
            this.pnlSearchPicture.Controls.Add(this.pnlPictureSearcherCheckPorn);
            this.pnlSearchPicture.Controls.Add(this.chkPictureSearcherCheckPornEnabled);
            this.pnlSearchPicture.Controls.Add(this.chkTraceMoeEnabled);
            this.pnlSearchPicture.Controls.Add(this.lblSearchLowSimilarityReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchLowSimilarity);
            this.pnlSearchPicture.Controls.Add(this.lblSearchErrorReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchNoResultReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeAlreadyOffReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeTimeOutReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOffCmd);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOffReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeAlreadyOnReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOnReply);
            this.pnlSearchPicture.Controls.Add(this.lblTraceMoeSendThreshold);
            this.pnlSearchPicture.Controls.Add(this.lblSauceNAOApiKey);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOnCmd);
            this.pnlSearchPicture.Controls.Add(this.txbSearchLowSimilarityReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchLowSimilarity);
            this.pnlSearchPicture.Controls.Add(this.txbSearchErrorReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchNoResultReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeTimeOutReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOffCmd);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeAlreadyOffReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOffReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeAlreadyOnReply);
            this.pnlSearchPicture.Controls.Add(this.txbTraceMoeSendThreshold);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOnReply);
            this.pnlSearchPicture.Controls.Add(this.txbSauceNAOApiKey);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOnCmd);
            this.pnlSearchPicture.Controls.Add(this.chkSearchASCII2DEnabled);
            this.pnlSearchPicture.Controls.Add(this.chkSearchSauceNAOEnabled);
            this.pnlSearchPicture.Enabled = false;
            this.pnlSearchPicture.Location = new System.Drawing.Point(3, 35);
            this.pnlSearchPicture.Name = "pnlSearchPicture";
            this.pnlSearchPicture.Size = new System.Drawing.Size(642, 649);
            this.pnlSearchPicture.TabIndex = 14;
            // 
            // pnlNoCheckPorn
            // 
            this.pnlNoCheckPorn.Controls.Add(this.lblSearchNoCheckPorn);
            this.pnlNoCheckPorn.Controls.Add(this.rdoNoCheckPornDontSend);
            this.pnlNoCheckPorn.Controls.Add(this.rdoNoCheckPornSend);
            this.pnlNoCheckPorn.Enabled = false;
            this.pnlNoCheckPorn.Location = new System.Drawing.Point(3, 664);
            this.pnlNoCheckPorn.Name = "pnlNoCheckPorn";
            this.pnlNoCheckPorn.Size = new System.Drawing.Size(616, 29);
            this.pnlNoCheckPorn.TabIndex = 47;
            // 
            // lblSearchNoCheckPorn
            // 
            this.lblSearchNoCheckPorn.AutoSize = true;
            this.lblSearchNoCheckPorn.Location = new System.Drawing.Point(15, 5);
            this.lblSearchNoCheckPorn.Name = "lblSearchNoCheckPorn";
            this.lblSearchNoCheckPorn.Size = new System.Drawing.Size(83, 17);
            this.lblSearchNoCheckPorn.TabIndex = 44;
            this.lblSearchNoCheckPorn.Text = "不启用鉴黄时:";
            // 
            // rdoNoCheckPornDontSend
            // 
            this.rdoNoCheckPornDontSend.AutoSize = true;
            this.rdoNoCheckPornDontSend.Location = new System.Drawing.Point(256, 3);
            this.rdoNoCheckPornDontSend.Name = "rdoNoCheckPornDontSend";
            this.rdoNoCheckPornDontSend.Size = new System.Drawing.Size(86, 21);
            this.rdoNoCheckPornDontSend.TabIndex = 46;
            this.rdoNoCheckPornDontSend.TabStop = true;
            this.rdoNoCheckPornDontSend.Tag = "1";
            this.rdoNoCheckPornDontSend.Text = "不发送图片";
            this.rdoNoCheckPornDontSend.UseVisualStyleBackColor = true;
            // 
            // rdoNoCheckPornSend
            // 
            this.rdoNoCheckPornSend.AutoSize = true;
            this.rdoNoCheckPornSend.Location = new System.Drawing.Point(176, 3);
            this.rdoNoCheckPornSend.Name = "rdoNoCheckPornSend";
            this.rdoNoCheckPornSend.Size = new System.Drawing.Size(74, 21);
            this.rdoNoCheckPornSend.TabIndex = 45;
            this.rdoNoCheckPornSend.TabStop = true;
            this.rdoNoCheckPornSend.Tag = "0";
            this.rdoNoCheckPornSend.Text = "发送图片";
            this.rdoNoCheckPornSend.UseVisualStyleBackColor = true;
            // 
            // chkASCII2DRequestByWebBrowser
            // 
            this.chkASCII2DRequestByWebBrowser.AutoSize = true;
            this.chkASCII2DRequestByWebBrowser.Location = new System.Drawing.Point(179, 169);
            this.chkASCII2DRequestByWebBrowser.Name = "chkASCII2DRequestByWebBrowser";
            this.chkASCII2DRequestByWebBrowser.Size = new System.Drawing.Size(344, 21);
            this.chkASCII2DRequestByWebBrowser.TabIndex = 41;
            this.chkASCII2DRequestByWebBrowser.Text = "ASCII2D优先使用浏览器进行Http请求(以应对近期403问题)";
            this.chkASCII2DRequestByWebBrowser.UseVisualStyleBackColor = true;
            // 
            // pnlPictureSearcherCheckPorn
            // 
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.lblSearchCheckPornOutOfLimitReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.txbSearchCheckPornOutOfLimitReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.rdoSearchCheckPornOutOfLimitAppend);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.rdoSearchCheckPornOutOfLimitDontSend);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.rdoSearchCheckPornOutOfLimitSend);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.lblSearchCheckPornOutOfLimit);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.txbSearchCheckPornIllegalReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.lblSearchCheckPornIllegalReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.lblSearchCheckPornErrorReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.txbSearchCheckPornErrorReply);
            this.pnlPictureSearcherCheckPorn.Location = new System.Drawing.Point(3, 547);
            this.pnlPictureSearcherCheckPorn.Name = "pnlPictureSearcherCheckPorn";
            this.pnlPictureSearcherCheckPorn.Size = new System.Drawing.Size(616, 114);
            this.pnlPictureSearcherCheckPorn.TabIndex = 40;
            // 
            // lblSearchCheckPornOutOfLimitReply
            // 
            this.lblSearchCheckPornOutOfLimitReply.AutoSize = true;
            this.lblSearchCheckPornOutOfLimitReply.Location = new System.Drawing.Point(15, 91);
            this.lblSearchCheckPornOutOfLimitReply.Name = "lblSearchCheckPornOutOfLimitReply";
            this.lblSearchCheckPornOutOfLimitReply.Size = new System.Drawing.Size(119, 17);
            this.lblSearchCheckPornOutOfLimitReply.TabIndex = 43;
            this.lblSearchCheckPornOutOfLimitReply.Text = "鉴黄次数耗尽时回复:";
            // 
            // txbSearchCheckPornOutOfLimitReply
            // 
            this.txbSearchCheckPornOutOfLimitReply.Location = new System.Drawing.Point(176, 88);
            this.txbSearchCheckPornOutOfLimitReply.Name = "txbSearchCheckPornOutOfLimitReply";
            this.txbSearchCheckPornOutOfLimitReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchCheckPornOutOfLimitReply.TabIndex = 42;
            // 
            // rdoSearchCheckPornOutOfLimitAppend
            // 
            this.rdoSearchCheckPornOutOfLimitAppend.AutoSize = true;
            this.rdoSearchCheckPornOutOfLimitAppend.Checked = true;
            this.rdoSearchCheckPornOutOfLimitAppend.Location = new System.Drawing.Point(348, 61);
            this.rdoSearchCheckPornOutOfLimitAppend.Name = "rdoSearchCheckPornOutOfLimitAppend";
            this.rdoSearchCheckPornOutOfLimitAppend.Size = new System.Drawing.Size(146, 21);
            this.rdoSearchCheckPornOutOfLimitAppend.TabIndex = 41;
            this.rdoSearchCheckPornOutOfLimitAppend.TabStop = true;
            this.rdoSearchCheckPornOutOfLimitAppend.Tag = "2";
            this.rdoSearchCheckPornOutOfLimitAppend.Text = "不发送图片且追加回复";
            this.rdoSearchCheckPornOutOfLimitAppend.UseVisualStyleBackColor = true;
            // 
            // rdoSearchCheckPornOutOfLimitDontSend
            // 
            this.rdoSearchCheckPornOutOfLimitDontSend.AutoSize = true;
            this.rdoSearchCheckPornOutOfLimitDontSend.Location = new System.Drawing.Point(256, 61);
            this.rdoSearchCheckPornOutOfLimitDontSend.Name = "rdoSearchCheckPornOutOfLimitDontSend";
            this.rdoSearchCheckPornOutOfLimitDontSend.Size = new System.Drawing.Size(86, 21);
            this.rdoSearchCheckPornOutOfLimitDontSend.TabIndex = 40;
            this.rdoSearchCheckPornOutOfLimitDontSend.Tag = "1";
            this.rdoSearchCheckPornOutOfLimitDontSend.Text = "不发送图片";
            this.rdoSearchCheckPornOutOfLimitDontSend.UseVisualStyleBackColor = true;
            // 
            // rdoSearchCheckPornOutOfLimitSend
            // 
            this.rdoSearchCheckPornOutOfLimitSend.AutoSize = true;
            this.rdoSearchCheckPornOutOfLimitSend.Location = new System.Drawing.Point(176, 61);
            this.rdoSearchCheckPornOutOfLimitSend.Name = "rdoSearchCheckPornOutOfLimitSend";
            this.rdoSearchCheckPornOutOfLimitSend.Size = new System.Drawing.Size(74, 21);
            this.rdoSearchCheckPornOutOfLimitSend.TabIndex = 40;
            this.rdoSearchCheckPornOutOfLimitSend.Tag = "0";
            this.rdoSearchCheckPornOutOfLimitSend.Text = "发送图片";
            this.rdoSearchCheckPornOutOfLimitSend.UseVisualStyleBackColor = true;
            // 
            // lblSearchCheckPornOutOfLimit
            // 
            this.lblSearchCheckPornOutOfLimit.AutoSize = true;
            this.lblSearchCheckPornOutOfLimit.Location = new System.Drawing.Point(15, 63);
            this.lblSearchCheckPornOutOfLimit.Name = "lblSearchCheckPornOutOfLimit";
            this.lblSearchCheckPornOutOfLimit.Size = new System.Drawing.Size(95, 17);
            this.lblSearchCheckPornOutOfLimit.TabIndex = 39;
            this.lblSearchCheckPornOutOfLimit.Text = "鉴黄次数耗尽时:";
            // 
            // txbSearchCheckPornIllegalReply
            // 
            this.txbSearchCheckPornIllegalReply.Location = new System.Drawing.Point(176, 3);
            this.txbSearchCheckPornIllegalReply.Name = "txbSearchCheckPornIllegalReply";
            this.txbSearchCheckPornIllegalReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchCheckPornIllegalReply.TabIndex = 35;
            // 
            // lblSearchCheckPornIllegalReply
            // 
            this.lblSearchCheckPornIllegalReply.AutoSize = true;
            this.lblSearchCheckPornIllegalReply.Location = new System.Drawing.Point(15, 6);
            this.lblSearchCheckPornIllegalReply.Name = "lblSearchCheckPornIllegalReply";
            this.lblSearchCheckPornIllegalReply.Size = new System.Drawing.Size(107, 17);
            this.lblSearchCheckPornIllegalReply.TabIndex = 37;
            this.lblSearchCheckPornIllegalReply.Text = "鉴黄不通过回复语:";
            // 
            // lblSearchCheckPornErrorReply
            // 
            this.lblSearchCheckPornErrorReply.AutoSize = true;
            this.lblSearchCheckPornErrorReply.Location = new System.Drawing.Point(15, 35);
            this.lblSearchCheckPornErrorReply.Name = "lblSearchCheckPornErrorReply";
            this.lblSearchCheckPornErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblSearchCheckPornErrorReply.TabIndex = 38;
            this.lblSearchCheckPornErrorReply.Text = "鉴黄错误回复语:";
            // 
            // txbSearchCheckPornErrorReply
            // 
            this.txbSearchCheckPornErrorReply.Location = new System.Drawing.Point(176, 32);
            this.txbSearchCheckPornErrorReply.Name = "txbSearchCheckPornErrorReply";
            this.txbSearchCheckPornErrorReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchCheckPornErrorReply.TabIndex = 36;
            // 
            // chkPictureSearcherCheckPornEnabled
            // 
            this.chkPictureSearcherCheckPornEnabled.AutoSize = true;
            this.chkPictureSearcherCheckPornEnabled.Location = new System.Drawing.Point(18, 520);
            this.chkPictureSearcherCheckPornEnabled.Name = "chkPictureSearcherCheckPornEnabled";
            this.chkPictureSearcherCheckPornEnabled.Size = new System.Drawing.Size(75, 21);
            this.chkPictureSearcherCheckPornEnabled.TabIndex = 39;
            this.chkPictureSearcherCheckPornEnabled.Text = "启用鉴黄";
            this.chkPictureSearcherCheckPornEnabled.UseVisualStyleBackColor = true;
            this.chkPictureSearcherCheckPornEnabled.CheckedChanged += new System.EventHandler(this.chkPictureSearcherCheckPornEnabled_CheckedChanged);
            // 
            // chkTraceMoeEnabled
            // 
            this.chkTraceMoeEnabled.AutoSize = true;
            this.chkTraceMoeEnabled.Location = new System.Drawing.Point(18, 3);
            this.chkTraceMoeEnabled.Name = "chkTraceMoeEnabled";
            this.chkTraceMoeEnabled.Size = new System.Drawing.Size(138, 21);
            this.chkTraceMoeEnabled.TabIndex = 34;
            this.chkTraceMoeEnabled.Text = "启用Trace Moe搜番";
            this.chkTraceMoeEnabled.UseVisualStyleBackColor = true;
            // 
            // lblSearchLowSimilarityReply
            // 
            this.lblSearchLowSimilarityReply.AutoSize = true;
            this.lblSearchLowSimilarityReply.Location = new System.Drawing.Point(18, 489);
            this.lblSearchLowSimilarityReply.Name = "lblSearchLowSimilarityReply";
            this.lblSearchLowSimilarityReply.Size = new System.Drawing.Size(131, 17);
            this.lblSearchLowSimilarityReply.TabIndex = 25;
            this.lblSearchLowSimilarityReply.Text = "低于相似度阈值回复语:";
            // 
            // lblSearchLowSimilarity
            // 
            this.lblSearchLowSimilarity.AutoSize = true;
            this.lblSearchLowSimilarity.Location = new System.Drawing.Point(18, 460);
            this.lblSearchLowSimilarity.Name = "lblSearchLowSimilarity";
            this.lblSearchLowSimilarity.Size = new System.Drawing.Size(71, 17);
            this.lblSearchLowSimilarity.TabIndex = 24;
            this.lblSearchLowSimilarity.Text = "相似度阈值:";
            // 
            // lblSearchErrorReply
            // 
            this.lblSearchErrorReply.AutoSize = true;
            this.lblSearchErrorReply.Location = new System.Drawing.Point(18, 431);
            this.lblSearchErrorReply.Name = "lblSearchErrorReply";
            this.lblSearchErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblSearchErrorReply.TabIndex = 23;
            this.lblSearchErrorReply.Text = "搜索错误回复语:";
            // 
            // lblSearchNoResultReply
            // 
            this.lblSearchNoResultReply.AutoSize = true;
            this.lblSearchNoResultReply.Location = new System.Drawing.Point(18, 402);
            this.lblSearchNoResultReply.Name = "lblSearchNoResultReply";
            this.lblSearchNoResultReply.Size = new System.Drawing.Size(131, 17);
            this.lblSearchNoResultReply.TabIndex = 22;
            this.lblSearchNoResultReply.Text = "没有搜索到地址回复语:";
            // 
            // lblSearchModeAlreadyOffReply
            // 
            this.lblSearchModeAlreadyOffReply.AutoSize = true;
            this.lblSearchModeAlreadyOffReply.Location = new System.Drawing.Point(18, 373);
            this.lblSearchModeAlreadyOffReply.Name = "lblSearchModeAlreadyOffReply";
            this.lblSearchModeAlreadyOffReply.Size = new System.Drawing.Size(155, 17);
            this.lblSearchModeAlreadyOffReply.TabIndex = 21;
            this.lblSearchModeAlreadyOffReply.Text = "已退出连续搜图模式回复语:";
            // 
            // lblSearchModeTimeOutReply
            // 
            this.lblSearchModeTimeOutReply.AutoSize = true;
            this.lblSearchModeTimeOutReply.Location = new System.Drawing.Point(18, 315);
            this.lblSearchModeTimeOutReply.Name = "lblSearchModeTimeOutReply";
            this.lblSearchModeTimeOutReply.Size = new System.Drawing.Size(143, 17);
            this.lblSearchModeTimeOutReply.TabIndex = 20;
            this.lblSearchModeTimeOutReply.Text = "连续搜图模式超时回复语:";
            // 
            // lblSearchModeOffCmd
            // 
            this.lblSearchModeOffCmd.AutoSize = true;
            this.lblSearchModeOffCmd.Location = new System.Drawing.Point(18, 286);
            this.lblSearchModeOffCmd.Name = "lblSearchModeOffCmd";
            this.lblSearchModeOffCmd.Size = new System.Drawing.Size(131, 17);
            this.lblSearchModeOffCmd.TabIndex = 20;
            this.lblSearchModeOffCmd.Text = "退出连续搜图模式命令:";
            // 
            // lblSearchModeOffReply
            // 
            this.lblSearchModeOffReply.AutoSize = true;
            this.lblSearchModeOffReply.Location = new System.Drawing.Point(18, 344);
            this.lblSearchModeOffReply.Name = "lblSearchModeOffReply";
            this.lblSearchModeOffReply.Size = new System.Drawing.Size(143, 17);
            this.lblSearchModeOffReply.TabIndex = 20;
            this.lblSearchModeOffReply.Text = "退出连续搜图模式回复语:";
            // 
            // lblSearchModeAlreadyOnReply
            // 
            this.lblSearchModeAlreadyOnReply.AutoSize = true;
            this.lblSearchModeAlreadyOnReply.Location = new System.Drawing.Point(18, 257);
            this.lblSearchModeAlreadyOnReply.Name = "lblSearchModeAlreadyOnReply";
            this.lblSearchModeAlreadyOnReply.Size = new System.Drawing.Size(155, 17);
            this.lblSearchModeAlreadyOnReply.TabIndex = 19;
            this.lblSearchModeAlreadyOnReply.Text = "已开启连续搜图模式回复语:";
            // 
            // lblSearchModeOnReply
            // 
            this.lblSearchModeOnReply.AutoSize = true;
            this.lblSearchModeOnReply.Location = new System.Drawing.Point(18, 228);
            this.lblSearchModeOnReply.Name = "lblSearchModeOnReply";
            this.lblSearchModeOnReply.Size = new System.Drawing.Size(143, 17);
            this.lblSearchModeOnReply.TabIndex = 18;
            this.lblSearchModeOnReply.Text = "开启连续搜图模式提示语:";
            // 
            // lblTraceMoeSendThreshold
            // 
            this.lblTraceMoeSendThreshold.AutoSize = true;
            this.lblTraceMoeSendThreshold.Location = new System.Drawing.Point(18, 27);
            this.lblTraceMoeSendThreshold.Name = "lblTraceMoeSendThreshold";
            this.lblTraceMoeSendThreshold.Size = new System.Drawing.Size(118, 17);
            this.lblTraceMoeSendThreshold.TabIndex = 17;
            this.lblTraceMoeSendThreshold.Text = "TraceMoe发送阈值:";
            this.toolTip1.SetToolTip(this.lblTraceMoeSendThreshold, "相似度大于等于此数值时发送搜番结果(TraceMoe官方参考值为87%)");
            // 
            // lblSauceNAOApiKey
            // 
            this.lblSauceNAOApiKey.AutoSize = true;
            this.lblSauceNAOApiKey.Location = new System.Drawing.Point(18, 80);
            this.lblSauceNAOApiKey.Name = "lblSauceNAOApiKey";
            this.lblSauceNAOApiKey.Size = new System.Drawing.Size(122, 17);
            this.lblSauceNAOApiKey.TabIndex = 17;
            this.lblSauceNAOApiKey.Text = "SauceNAO Api-Key:";
            // 
            // lblSearchModeOnCmd
            // 
            this.lblSearchModeOnCmd.AutoSize = true;
            this.lblSearchModeOnCmd.Location = new System.Drawing.Point(18, 199);
            this.lblSearchModeOnCmd.Name = "lblSearchModeOnCmd";
            this.lblSearchModeOnCmd.Size = new System.Drawing.Size(131, 17);
            this.lblSearchModeOnCmd.TabIndex = 17;
            this.lblSearchModeOnCmd.Text = "开启连续搜图模式命令:";
            // 
            // txbSearchLowSimilarityReply
            // 
            this.txbSearchLowSimilarityReply.Location = new System.Drawing.Point(179, 486);
            this.txbSearchLowSimilarityReply.Name = "txbSearchLowSimilarityReply";
            this.txbSearchLowSimilarityReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchLowSimilarityReply.TabIndex = 16;
            // 
            // txbSearchLowSimilarity
            // 
            this.txbSearchLowSimilarity.Location = new System.Drawing.Point(179, 457);
            this.txbSearchLowSimilarity.Name = "txbSearchLowSimilarity";
            this.txbSearchLowSimilarity.Size = new System.Drawing.Size(437, 23);
            this.txbSearchLowSimilarity.TabIndex = 16;
            // 
            // txbSearchErrorReply
            // 
            this.txbSearchErrorReply.Location = new System.Drawing.Point(179, 428);
            this.txbSearchErrorReply.Name = "txbSearchErrorReply";
            this.txbSearchErrorReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchErrorReply.TabIndex = 16;
            // 
            // txbSearchNoResultReply
            // 
            this.txbSearchNoResultReply.Location = new System.Drawing.Point(179, 399);
            this.txbSearchNoResultReply.Name = "txbSearchNoResultReply";
            this.txbSearchNoResultReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchNoResultReply.TabIndex = 16;
            // 
            // txbSearchModeTimeOutReply
            // 
            this.txbSearchModeTimeOutReply.Location = new System.Drawing.Point(179, 312);
            this.txbSearchModeTimeOutReply.Name = "txbSearchModeTimeOutReply";
            this.txbSearchModeTimeOutReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchModeTimeOutReply.TabIndex = 16;
            // 
            // txbSearchModeOffCmd
            // 
            this.txbSearchModeOffCmd.Location = new System.Drawing.Point(179, 283);
            this.txbSearchModeOffCmd.Name = "txbSearchModeOffCmd";
            this.txbSearchModeOffCmd.Size = new System.Drawing.Size(437, 23);
            this.txbSearchModeOffCmd.TabIndex = 16;
            // 
            // txbSearchModeAlreadyOffReply
            // 
            this.txbSearchModeAlreadyOffReply.Location = new System.Drawing.Point(179, 370);
            this.txbSearchModeAlreadyOffReply.Name = "txbSearchModeAlreadyOffReply";
            this.txbSearchModeAlreadyOffReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchModeAlreadyOffReply.TabIndex = 16;
            // 
            // txbSearchModeOffReply
            // 
            this.txbSearchModeOffReply.Location = new System.Drawing.Point(179, 341);
            this.txbSearchModeOffReply.Name = "txbSearchModeOffReply";
            this.txbSearchModeOffReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchModeOffReply.TabIndex = 16;
            // 
            // txbSearchModeAlreadyOnReply
            // 
            this.txbSearchModeAlreadyOnReply.Location = new System.Drawing.Point(179, 254);
            this.txbSearchModeAlreadyOnReply.Name = "txbSearchModeAlreadyOnReply";
            this.txbSearchModeAlreadyOnReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchModeAlreadyOnReply.TabIndex = 16;
            // 
            // txbTraceMoeSendThreshold
            // 
            this.txbTraceMoeSendThreshold.Location = new System.Drawing.Point(179, 24);
            this.txbTraceMoeSendThreshold.Name = "txbTraceMoeSendThreshold";
            this.txbTraceMoeSendThreshold.Size = new System.Drawing.Size(440, 23);
            this.txbTraceMoeSendThreshold.TabIndex = 16;
            this.toolTip1.SetToolTip(this.txbTraceMoeSendThreshold, "相似度大于等于此数值时发送搜番结果(TraceMoe官方参考值为87%)");
            // 
            // txbSearchModeOnReply
            // 
            this.txbSearchModeOnReply.Location = new System.Drawing.Point(179, 225);
            this.txbSearchModeOnReply.Name = "txbSearchModeOnReply";
            this.txbSearchModeOnReply.Size = new System.Drawing.Size(437, 23);
            this.txbSearchModeOnReply.TabIndex = 16;
            // 
            // txbSauceNAOApiKey
            // 
            this.txbSauceNAOApiKey.Location = new System.Drawing.Point(179, 77);
            this.txbSauceNAOApiKey.Multiline = true;
            this.txbSauceNAOApiKey.Name = "txbSauceNAOApiKey";
            this.txbSauceNAOApiKey.Size = new System.Drawing.Size(437, 86);
            this.txbSauceNAOApiKey.TabIndex = 16;
            // 
            // txbSearchModeOnCmd
            // 
            this.txbSearchModeOnCmd.Location = new System.Drawing.Point(179, 196);
            this.txbSearchModeOnCmd.Name = "txbSearchModeOnCmd";
            this.txbSearchModeOnCmd.Size = new System.Drawing.Size(437, 23);
            this.txbSearchModeOnCmd.TabIndex = 16;
            // 
            // chkSearchASCII2DEnabled
            // 
            this.chkSearchASCII2DEnabled.AutoSize = true;
            this.chkSearchASCII2DEnabled.Location = new System.Drawing.Point(18, 169);
            this.chkSearchASCII2DEnabled.Name = "chkSearchASCII2DEnabled";
            this.chkSearchASCII2DEnabled.Size = new System.Drawing.Size(122, 21);
            this.chkSearchASCII2DEnabled.TabIndex = 15;
            this.chkSearchASCII2DEnabled.Text = "启用ASCII2D搜索";
            this.chkSearchASCII2DEnabled.UseVisualStyleBackColor = true;
            // 
            // chkSearchSauceNAOEnabled
            // 
            this.chkSearchSauceNAOEnabled.AutoSize = true;
            this.chkSearchSauceNAOEnabled.Location = new System.Drawing.Point(18, 56);
            this.chkSearchSauceNAOEnabled.Name = "chkSearchSauceNAOEnabled";
            this.chkSearchSauceNAOEnabled.Size = new System.Drawing.Size(137, 21);
            this.chkSearchSauceNAOEnabled.TabIndex = 15;
            this.chkSearchSauceNAOEnabled.Text = "启用SauceNAO搜图";
            this.chkSearchSauceNAOEnabled.UseVisualStyleBackColor = true;
            this.chkSearchSauceNAOEnabled.CheckedChanged += new System.EventHandler(this.chkSearchSauceNAOEnabled_CheckedChanged);
            // 
            // tabOriginPicture
            // 
            this.tabOriginPicture.Controls.Add(this.pnlOriginPicture);
            this.tabOriginPicture.Controls.Add(this.chkOriginPictureEnabled);
            this.tabOriginPicture.Location = new System.Drawing.Point(4, 26);
            this.tabOriginPicture.Name = "tabOriginPicture";
            this.tabOriginPicture.Size = new System.Drawing.Size(652, 687);
            this.tabOriginPicture.TabIndex = 9;
            this.tabOriginPicture.Text = "下载原图";
            this.tabOriginPicture.UseVisualStyleBackColor = true;
            // 
            // pnlOriginPicture
            // 
            this.pnlOriginPicture.Controls.Add(this.chkOriginPictureCheckPornEnabled);
            this.pnlOriginPicture.Controls.Add(this.pnlOriginPictureCheckPorn);
            this.pnlOriginPicture.Enabled = false;
            this.pnlOriginPicture.Location = new System.Drawing.Point(3, 43);
            this.pnlOriginPicture.Name = "pnlOriginPicture";
            this.pnlOriginPicture.Size = new System.Drawing.Size(646, 139);
            this.pnlOriginPicture.TabIndex = 3;
            // 
            // chkOriginPictureCheckPornEnabled
            // 
            this.chkOriginPictureCheckPornEnabled.AutoSize = true;
            this.chkOriginPictureCheckPornEnabled.Location = new System.Drawing.Point(12, 3);
            this.chkOriginPictureCheckPornEnabled.Name = "chkOriginPictureCheckPornEnabled";
            this.chkOriginPictureCheckPornEnabled.Size = new System.Drawing.Size(75, 21);
            this.chkOriginPictureCheckPornEnabled.TabIndex = 1;
            this.chkOriginPictureCheckPornEnabled.Text = "启用鉴黄";
            this.chkOriginPictureCheckPornEnabled.UseVisualStyleBackColor = true;
            this.chkOriginPictureCheckPornEnabled.CheckedChanged += new System.EventHandler(this.chkOriginPictureCheckPornEnabled_CheckedChanged);
            // 
            // pnlOriginPictureCheckPorn
            // 
            this.pnlOriginPictureCheckPorn.Controls.Add(this.pnlOriginPictureCheckPornMessage);
            this.pnlOriginPictureCheckPorn.Controls.Add(this.pnlOriginPictureCheckPornEvent);
            this.pnlOriginPictureCheckPorn.Controls.Add(this.lblOriginPictureCheckPornEvent);
            this.pnlOriginPictureCheckPorn.Enabled = false;
            this.pnlOriginPictureCheckPorn.Location = new System.Drawing.Point(0, 30);
            this.pnlOriginPictureCheckPorn.Name = "pnlOriginPictureCheckPorn";
            this.pnlOriginPictureCheckPorn.Size = new System.Drawing.Size(643, 105);
            this.pnlOriginPictureCheckPorn.TabIndex = 2;
            // 
            // pnlOriginPictureCheckPornMessage
            // 
            this.pnlOriginPictureCheckPornMessage.Controls.Add(this.lblOriginPictureCheckPornIllegalReply);
            this.pnlOriginPictureCheckPornMessage.Controls.Add(this.txbOriginPictureCheckPornErrorReply);
            this.pnlOriginPictureCheckPornMessage.Controls.Add(this.txbOriginPictureCheckPornIllegalReply);
            this.pnlOriginPictureCheckPornMessage.Controls.Add(this.lblOriginPictureCheckPornErrorReply);
            this.pnlOriginPictureCheckPornMessage.Enabled = false;
            this.pnlOriginPictureCheckPornMessage.Location = new System.Drawing.Point(3, 39);
            this.pnlOriginPictureCheckPornMessage.Name = "pnlOriginPictureCheckPornMessage";
            this.pnlOriginPictureCheckPornMessage.Size = new System.Drawing.Size(640, 63);
            this.pnlOriginPictureCheckPornMessage.TabIndex = 6;
            // 
            // lblOriginPictureCheckPornIllegalReply
            // 
            this.lblOriginPictureCheckPornIllegalReply.AutoSize = true;
            this.lblOriginPictureCheckPornIllegalReply.Location = new System.Drawing.Point(13, 6);
            this.lblOriginPictureCheckPornIllegalReply.Name = "lblOriginPictureCheckPornIllegalReply";
            this.lblOriginPictureCheckPornIllegalReply.Size = new System.Drawing.Size(107, 17);
            this.lblOriginPictureCheckPornIllegalReply.TabIndex = 2;
            this.lblOriginPictureCheckPornIllegalReply.Text = "鉴黄不通过回复语:";
            // 
            // txbOriginPictureCheckPornErrorReply
            // 
            this.txbOriginPictureCheckPornErrorReply.Location = new System.Drawing.Point(126, 32);
            this.txbOriginPictureCheckPornErrorReply.Name = "txbOriginPictureCheckPornErrorReply";
            this.txbOriginPictureCheckPornErrorReply.Size = new System.Drawing.Size(503, 23);
            this.txbOriginPictureCheckPornErrorReply.TabIndex = 5;
            // 
            // txbOriginPictureCheckPornIllegalReply
            // 
            this.txbOriginPictureCheckPornIllegalReply.Location = new System.Drawing.Point(126, 3);
            this.txbOriginPictureCheckPornIllegalReply.Name = "txbOriginPictureCheckPornIllegalReply";
            this.txbOriginPictureCheckPornIllegalReply.Size = new System.Drawing.Size(503, 23);
            this.txbOriginPictureCheckPornIllegalReply.TabIndex = 3;
            // 
            // lblOriginPictureCheckPornErrorReply
            // 
            this.lblOriginPictureCheckPornErrorReply.AutoSize = true;
            this.lblOriginPictureCheckPornErrorReply.Location = new System.Drawing.Point(13, 35);
            this.lblOriginPictureCheckPornErrorReply.Name = "lblOriginPictureCheckPornErrorReply";
            this.lblOriginPictureCheckPornErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblOriginPictureCheckPornErrorReply.TabIndex = 4;
            this.lblOriginPictureCheckPornErrorReply.Text = "鉴黄错误回复语:";
            // 
            // pnlOriginPictureCheckPornEvent
            // 
            this.pnlOriginPictureCheckPornEvent.Controls.Add(this.rdoOriginPictureCheckPornSendByForward);
            this.pnlOriginPictureCheckPornEvent.Controls.Add(this.rdoOriginPictureCheckPornDoNothing);
            this.pnlOriginPictureCheckPornEvent.Controls.Add(this.rdoOriginPictureCheckPornReply);
            this.pnlOriginPictureCheckPornEvent.Location = new System.Drawing.Point(101, 3);
            this.pnlOriginPictureCheckPornEvent.Name = "pnlOriginPictureCheckPornEvent";
            this.pnlOriginPictureCheckPornEvent.Size = new System.Drawing.Size(531, 30);
            this.pnlOriginPictureCheckPornEvent.TabIndex = 1;
            // 
            // rdoOriginPictureCheckPornSendByForward
            // 
            this.rdoOriginPictureCheckPornSendByForward.AutoSize = true;
            this.rdoOriginPictureCheckPornSendByForward.Checked = true;
            this.rdoOriginPictureCheckPornSendByForward.Location = new System.Drawing.Point(3, 5);
            this.rdoOriginPictureCheckPornSendByForward.Name = "rdoOriginPictureCheckPornSendByForward";
            this.rdoOriginPictureCheckPornSendByForward.Size = new System.Drawing.Size(146, 21);
            this.rdoOriginPictureCheckPornSendByForward.TabIndex = 0;
            this.rdoOriginPictureCheckPornSendByForward.TabStop = true;
            this.rdoOriginPictureCheckPornSendByForward.Tag = "0";
            this.rdoOriginPictureCheckPornSendByForward.Text = "以合并转发的方式发送";
            this.rdoOriginPictureCheckPornSendByForward.UseVisualStyleBackColor = true;
            this.rdoOriginPictureCheckPornSendByForward.CheckedChanged += new System.EventHandler(this.rdoOriginPictureCheckPornSendByForward_CheckedChanged);
            // 
            // rdoOriginPictureCheckPornDoNothing
            // 
            this.rdoOriginPictureCheckPornDoNothing.AutoSize = true;
            this.rdoOriginPictureCheckPornDoNothing.Location = new System.Drawing.Point(172, 5);
            this.rdoOriginPictureCheckPornDoNothing.Name = "rdoOriginPictureCheckPornDoNothing";
            this.rdoOriginPictureCheckPornDoNothing.Size = new System.Drawing.Size(86, 21);
            this.rdoOriginPictureCheckPornDoNothing.TabIndex = 0;
            this.rdoOriginPictureCheckPornDoNothing.Tag = "1";
            this.rdoOriginPictureCheckPornDoNothing.Text = "不发送消息";
            this.rdoOriginPictureCheckPornDoNothing.UseVisualStyleBackColor = true;
            this.rdoOriginPictureCheckPornDoNothing.CheckedChanged += new System.EventHandler(this.rdoOriginPictureCheckPornSendByForward_CheckedChanged);
            // 
            // rdoOriginPictureCheckPornReply
            // 
            this.rdoOriginPictureCheckPornReply.AutoSize = true;
            this.rdoOriginPictureCheckPornReply.Location = new System.Drawing.Point(283, 5);
            this.rdoOriginPictureCheckPornReply.Name = "rdoOriginPictureCheckPornReply";
            this.rdoOriginPictureCheckPornReply.Size = new System.Drawing.Size(98, 21);
            this.rdoOriginPictureCheckPornReply.TabIndex = 0;
            this.rdoOriginPictureCheckPornReply.Tag = "2";
            this.rdoOriginPictureCheckPornReply.Text = "回复以下消息";
            this.rdoOriginPictureCheckPornReply.UseVisualStyleBackColor = true;
            this.rdoOriginPictureCheckPornReply.CheckedChanged += new System.EventHandler(this.rdoOriginPictureCheckPornSendByForward_CheckedChanged);
            // 
            // lblOriginPictureCheckPornEvent
            // 
            this.lblOriginPictureCheckPornEvent.AutoSize = true;
            this.lblOriginPictureCheckPornEvent.Location = new System.Drawing.Point(12, 10);
            this.lblOriginPictureCheckPornEvent.Name = "lblOriginPictureCheckPornEvent";
            this.lblOriginPictureCheckPornEvent.Size = new System.Drawing.Size(83, 17);
            this.lblOriginPictureCheckPornEvent.TabIndex = 0;
            this.lblOriginPictureCheckPornEvent.Text = "鉴黄不通过时:";
            // 
            // chkOriginPictureEnabled
            // 
            this.chkOriginPictureEnabled.AutoSize = true;
            this.chkOriginPictureEnabled.Location = new System.Drawing.Point(15, 16);
            this.chkOriginPictureEnabled.Name = "chkOriginPictureEnabled";
            this.chkOriginPictureEnabled.Size = new System.Drawing.Size(124, 21);
            this.chkOriginPictureEnabled.TabIndex = 0;
            this.chkOriginPictureEnabled.Text = "启用下载Pixiv原图";
            this.chkOriginPictureEnabled.UseVisualStyleBackColor = true;
            this.chkOriginPictureEnabled.CheckedChanged += new System.EventHandler(this.chkOriginPictureEnabled_CheckedChanged);
            // 
            // tabTranslate
            // 
            this.tabTranslate.Controls.Add(this.pnlTranslate);
            this.tabTranslate.Controls.Add(this.chkTranslateEnabled);
            this.tabTranslate.Location = new System.Drawing.Point(4, 26);
            this.tabTranslate.Name = "tabTranslate";
            this.tabTranslate.Size = new System.Drawing.Size(652, 687);
            this.tabTranslate.TabIndex = 4;
            this.tabTranslate.Text = "翻译设置";
            this.tabTranslate.UseVisualStyleBackColor = true;
            // 
            // pnlTranslate
            // 
            this.pnlTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranslate.Controls.Add(this.txbTranslateFromToCMD);
            this.pnlTranslate.Controls.Add(this.lblTranslateFromTo);
            this.pnlTranslate.Controls.Add(this.lblTranslateEngineHelp);
            this.pnlTranslate.Controls.Add(this.cboTranslateEngine);
            this.pnlTranslate.Controls.Add(this.lblTranslateEngine);
            this.pnlTranslate.Controls.Add(this.txbAddAutoTranslateGroupMemoryQQ);
            this.pnlTranslate.Controls.Add(this.btnRemoveAutoTranslateGroupMemoryQQ);
            this.pnlTranslate.Controls.Add(this.btnAddAutoTranslateGroupMemoryQQ);
            this.pnlTranslate.Controls.Add(this.lstAutoTranslateGroupMemoriesQQ);
            this.pnlTranslate.Controls.Add(this.lblAddAutoTranslateGroupMemoryQQ);
            this.pnlTranslate.Controls.Add(this.lblAutoTranslateGroupMemoriesQQ);
            this.pnlTranslate.Controls.Add(this.txbTranslateTo);
            this.pnlTranslate.Controls.Add(this.txbTranslateToChinese);
            this.pnlTranslate.Controls.Add(this.lblTranslateTo);
            this.pnlTranslate.Controls.Add(this.lblTranslateToChinese);
            this.pnlTranslate.Enabled = false;
            this.pnlTranslate.Location = new System.Drawing.Point(3, 43);
            this.pnlTranslate.Name = "pnlTranslate";
            this.pnlTranslate.Size = new System.Drawing.Size(646, 277);
            this.pnlTranslate.TabIndex = 1;
            // 
            // txbTranslateFromToCMD
            // 
            this.txbTranslateFromToCMD.Location = new System.Drawing.Point(197, 124);
            this.txbTranslateFromToCMD.Name = "txbTranslateFromToCMD";
            this.txbTranslateFromToCMD.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateFromToCMD.TabIndex = 15;
            // 
            // lblTranslateFromTo
            // 
            this.lblTranslateFromTo.AutoSize = true;
            this.lblTranslateFromTo.Location = new System.Drawing.Point(12, 127);
            this.lblTranslateFromTo.Name = "lblTranslateFromTo";
            this.lblTranslateFromTo.Size = new System.Drawing.Size(179, 17);
            this.lblTranslateFromTo.TabIndex = 14;
            this.lblTranslateFromTo.Text = "从指定语言翻译为指定语言命令:";
            // 
            // lblTranslateEngineHelp
            // 
            this.lblTranslateEngineHelp.AutoSize = true;
            this.lblTranslateEngineHelp.Location = new System.Drawing.Point(137, 31);
            this.lblTranslateEngineHelp.Name = "lblTranslateEngineHelp";
            this.lblTranslateEngineHelp.Size = new System.Drawing.Size(483, 17);
            this.lblTranslateEngineHelp.TabIndex = 13;
            this.lblTranslateEngineHelp.Text = "提示: 谷歌翻译Api需翻墙, 有道翻译Api仅支持任意译中(其实还支持中译英, 但是我懒得做)";
            // 
            // cboTranslateEngine
            // 
            this.cboTranslateEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateEngine.FormattingEnabled = true;
            this.cboTranslateEngine.Items.AddRange(new object[] {
            "Google",
            "YouDao"});
            this.cboTranslateEngine.Location = new System.Drawing.Point(137, 3);
            this.cboTranslateEngine.Name = "cboTranslateEngine";
            this.cboTranslateEngine.Size = new System.Drawing.Size(485, 25);
            this.cboTranslateEngine.TabIndex = 12;
            this.cboTranslateEngine.SelectedIndexChanged += new System.EventHandler(this.cboTranslateEngine_SelectedIndexChanged);
            // 
            // lblTranslateEngine
            // 
            this.lblTranslateEngine.AutoSize = true;
            this.lblTranslateEngine.Location = new System.Drawing.Point(12, 6);
            this.lblTranslateEngine.Name = "lblTranslateEngine";
            this.lblTranslateEngine.Size = new System.Drawing.Size(59, 17);
            this.lblTranslateEngine.TabIndex = 11;
            this.lblTranslateEngine.Text = "翻译引擎:";
            // 
            // txbAddAutoTranslateGroupMemoryQQ
            // 
            this.txbAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(455, 200);
            this.txbAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddAutoTranslateGroupMemoryQQ.Name = "txbAddAutoTranslateGroupMemoryQQ";
            this.txbAddAutoTranslateGroupMemoryQQ.ShortcutsEnabled = false;
            this.txbAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(167, 23);
            this.txbAddAutoTranslateGroupMemoryQQ.TabIndex = 5;
            // 
            // btnRemoveAutoTranslateGroupMemoryQQ
            // 
            this.btnRemoveAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(347, 231);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Name = "btnRemoveAutoTranslateGroupMemoryQQ";
            this.btnRemoveAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveAutoTranslateGroupMemoryQQ.TabIndex = 9;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Text = ">>移除>>";
            this.btnRemoveAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnRemoveAutoTranslateGroupMemoryQQ_Click);
            // 
            // btnAddAutoTranslateGroupMemoryQQ
            // 
            this.btnAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(347, 200);
            this.btnAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAutoTranslateGroupMemoryQQ.Name = "btnAddAutoTranslateGroupMemoryQQ";
            this.btnAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(88, 23);
            this.btnAddAutoTranslateGroupMemoryQQ.TabIndex = 10;
            this.btnAddAutoTranslateGroupMemoryQQ.Text = "<<添加<<";
            this.btnAddAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnAddAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnAddAutoTranslateGroupMemoryQQ_Click);
            // 
            // lstAutoTranslateGroupMemoriesQQ
            // 
            this.lstAutoTranslateGroupMemoriesQQ.FullRowSelect = true;
            this.lstAutoTranslateGroupMemoriesQQ.HideSelection = false;
            this.lstAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(156, 179);
            this.lstAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(4);
            this.lstAutoTranslateGroupMemoriesQQ.Name = "lstAutoTranslateGroupMemoriesQQ";
            this.lstAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(167, 85);
            this.lstAutoTranslateGroupMemoriesQQ.TabIndex = 8;
            this.lstAutoTranslateGroupMemoriesQQ.UseCompatibleStateImageBehavior = false;
            this.lstAutoTranslateGroupMemoriesQQ.View = System.Windows.Forms.View.List;
            // 
            // lblAddAutoTranslateGroupMemoryQQ
            // 
            this.lblAddAutoTranslateGroupMemoryQQ.AutoSize = true;
            this.lblAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(453, 179);
            this.lblAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddAutoTranslateGroupMemoryQQ.Name = "lblAddAutoTranslateGroupMemoryQQ";
            this.lblAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(160, 17);
            this.lblAddAutoTranslateGroupMemoryQQ.TabIndex = 6;
            this.lblAddAutoTranslateGroupMemoryQQ.Text = "添加自动翻译群友消息QQ：";
            // 
            // lblAutoTranslateGroupMemoriesQQ
            // 
            this.lblAutoTranslateGroupMemoriesQQ.AutoSize = true;
            this.lblAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(12, 179);
            this.lblAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoTranslateGroupMemoriesQQ.Name = "lblAutoTranslateGroupMemoriesQQ";
            this.lblAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(136, 17);
            this.lblAutoTranslateGroupMemoriesQQ.TabIndex = 7;
            this.lblAutoTranslateGroupMemoriesQQ.Text = "自动翻译群友消息QQ：";
            // 
            // txbTranslateTo
            // 
            this.txbTranslateTo.Location = new System.Drawing.Point(197, 95);
            this.txbTranslateTo.Name = "txbTranslateTo";
            this.txbTranslateTo.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateTo.TabIndex = 3;
            // 
            // txbTranslateToChinese
            // 
            this.txbTranslateToChinese.Location = new System.Drawing.Point(197, 66);
            this.txbTranslateToChinese.Name = "txbTranslateToChinese";
            this.txbTranslateToChinese.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateToChinese.TabIndex = 2;
            // 
            // lblTranslateTo
            // 
            this.lblTranslateTo.AutoSize = true;
            this.lblTranslateTo.Location = new System.Drawing.Point(12, 98);
            this.lblTranslateTo.Name = "lblTranslateTo";
            this.lblTranslateTo.Size = new System.Drawing.Size(119, 17);
            this.lblTranslateTo.TabIndex = 1;
            this.lblTranslateTo.Text = "翻译为指定语言命令:";
            // 
            // lblTranslateToChinese
            // 
            this.lblTranslateToChinese.AutoSize = true;
            this.lblTranslateToChinese.Location = new System.Drawing.Point(12, 69);
            this.lblTranslateToChinese.Name = "lblTranslateToChinese";
            this.lblTranslateToChinese.Size = new System.Drawing.Size(95, 17);
            this.lblTranslateToChinese.TabIndex = 0;
            this.lblTranslateToChinese.Text = "翻译为中文命令:";
            // 
            // chkTranslateEnabled
            // 
            this.chkTranslateEnabled.AutoSize = true;
            this.chkTranslateEnabled.Location = new System.Drawing.Point(15, 16);
            this.chkTranslateEnabled.Name = "chkTranslateEnabled";
            this.chkTranslateEnabled.Size = new System.Drawing.Size(99, 21);
            this.chkTranslateEnabled.TabIndex = 0;
            this.chkTranslateEnabled.Text = "启用翻译功能";
            this.chkTranslateEnabled.UseVisualStyleBackColor = true;
            this.chkTranslateEnabled.CheckedChanged += new System.EventHandler(this.chkTranslateEnabled_CheckedChanged);
            // 
            // tabHPicture
            // 
            this.tabHPicture.AutoScroll = true;
            this.tabHPicture.Controls.Add(this.pnlEnabelHPicture);
            this.tabHPicture.Controls.Add(this.chkEnabledHPicture);
            this.tabHPicture.Location = new System.Drawing.Point(4, 26);
            this.tabHPicture.Margin = new System.Windows.Forms.Padding(4);
            this.tabHPicture.Name = "tabHPicture";
            this.tabHPicture.Padding = new System.Windows.Forms.Padding(4);
            this.tabHPicture.Size = new System.Drawing.Size(652, 687);
            this.tabHPicture.TabIndex = 0;
            this.tabHPicture.Text = "色图设置";
            this.tabHPicture.UseVisualStyleBackColor = true;
            // 
            // pnlEnabelHPicture
            // 
            this.pnlEnabelHPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEnabelHPicture.AutoScroll = true;
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureOnceMessageMaxImageCountHelp);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureOnceMessageMaxImageCount);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureOnceMessageMaxImageCount);
            this.pnlEnabelHPicture.Controls.Add(this.lblBeautyPictureSource);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureSource);
            this.pnlEnabelHPicture.Controls.Add(this.chkEnabledGreenOnionsBeautyPicture);
            this.pnlEnabelHPicture.Controls.Add(this.chkEnabledGreenOnionsHPicture);
            this.pnlEnabelHPicture.Controls.Add(this.chkEnabledELFBeautyPicture);
            this.pnlEnabelHPicture.Controls.Add(this.chkRevokeBeautyPicture);
            this.pnlEnabelHPicture.Controls.Add(this.chkEnabledLoliconHPicture);
            this.pnlEnabelHPicture.Controls.Add(this.lblMultithreading);
            this.pnlEnabelHPicture.Controls.Add(this.chkMultithreading);
            this.pnlEnabelHPicture.Controls.Add(this.rodHPictureLimitCount);
            this.pnlEnabelHPicture.Controls.Add(this.rdoHPictureLimitFrequency);
            this.pnlEnabelHPicture.Controls.Add(this.txbAddToWhiteGroup);
            this.pnlEnabelHPicture.Controls.Add(this.txbUserHPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.txbPMCD);
            this.pnlEnabelHPicture.Controls.Add(this.txbWhiteCD);
            this.pnlEnabelHPicture.Controls.Add(this.txbPMRevoke);
            this.pnlEnabelHPicture.Controls.Add(this.txbWhiteRevoke);
            this.pnlEnabelHPicture.Controls.Add(this.lstHPictureUserCmd);
            this.pnlEnabelHPicture.Controls.Add(this.lstHPictureWhiteGroup);
            this.pnlEnabelHPicture.Controls.Add(this.lblPMRevoke);
            this.pnlEnabelHPicture.Controls.Add(this.lblWhiteRevoke);
            this.pnlEnabelHPicture.Controls.Add(this.lblPMCD);
            this.pnlEnabelHPicture.Controls.Add(this.lblWhiteCD);
            this.pnlEnabelHPicture.Controls.Add(this.lblDownloadAccelerate);
            this.pnlEnabelHPicture.Controls.Add(this.lblCD);
            this.pnlEnabelHPicture.Controls.Add(this.lblDownloadFail);
            this.pnlEnabelHPicture.Controls.Add(this.lblNoResult);
            this.pnlEnabelHPicture.Controls.Add(this.lblErrorReply);
            this.pnlEnabelHPicture.Controls.Add(this.lblOutOfLimitReply);
            this.pnlEnabelHPicture.Controls.Add(this.lblCDUnreadyReply);
            this.pnlEnabelHPicture.Controls.Add(this.lblLimit);
            this.pnlEnabelHPicture.Controls.Add(this.lblRevoke);
            this.pnlEnabelHPicture.Controls.Add(this.lblWhiteGroup);
            this.pnlEnabelHPicture.Controls.Add(this.txbDownloadFailReply);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureNoResultReply);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureErrorReplyReply);
            this.pnlEnabelHPicture.Controls.Add(this.txbOutOfLimitReply);
            this.pnlEnabelHPicture.Controls.Add(this.txbDownloadAccelerateUrl);
            this.pnlEnabelHPicture.Controls.Add(this.txbCDUnreadyReply);
            this.pnlEnabelHPicture.Controls.Add(this.txbCD);
            this.pnlEnabelHPicture.Controls.Add(this.txbLimit);
            this.pnlEnabelHPicture.Controls.Add(this.txbRevoke);
            this.pnlEnabelHPicture.Controls.Add(this.chkAllowR18);
            this.pnlEnabelHPicture.Controls.Add(this.chkManageNoLimit);
            this.pnlEnabelHPicture.Controls.Add(this.chkAdminNoLimit);
            this.pnlEnabelHPicture.Controls.Add(this.chkWhiteNoLimit);
            this.pnlEnabelHPicture.Controls.Add(this.chkPMNoLimit);
            this.pnlEnabelHPicture.Controls.Add(this.chkR18WhiteOnly);
            this.pnlEnabelHPicture.Controls.Add(this.chkWhiteOnly);
            this.pnlEnabelHPicture.Controls.Add(this.chkDownloadAccelerate);
            this.pnlEnabelHPicture.Controls.Add(this.chkSize1200);
            this.pnlEnabelHPicture.Controls.Add(this.chkPM);
            this.pnlEnabelHPicture.Controls.Add(this.chkAntiShielding);
            this.pnlEnabelHPicture.Controls.Add(this.lblUserCmdInformation);
            this.pnlEnabelHPicture.Controls.Add(this.lblAddToWhiteGroupInformation);
            this.pnlEnabelHPicture.Controls.Add(this.lblApiKey);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureBegin);
            this.pnlEnabelHPicture.Controls.Add(this.lblBeautyPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.lblLoliconHPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.btnRemoveWhiteGroup);
            this.pnlEnabelHPicture.Controls.Add(this.btnAddToWhiteGroup);
            this.pnlEnabelHPicture.Controls.Add(this.btnRemoveUserHPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.btnAddUserHPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureCount);
            this.pnlEnabelHPicture.Controls.Add(this.lnkResetHPicture);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureUnit);
            this.pnlEnabelHPicture.Controls.Add(this.chkBeautyPictureEndNull);
            this.pnlEnabelHPicture.Controls.Add(this.chkHPictureEndNull);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureR18);
            this.pnlEnabelHPicture.Controls.Add(this.chkHPictureKeywordNull);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureKeyword);
            this.pnlEnabelHPicture.Controls.Add(this.chkHPictureR18Null);
            this.pnlEnabelHPicture.Controls.Add(this.lblShabHPictureEnd);
            this.pnlEnabelHPicture.Controls.Add(this.lblHPictureEnd);
            this.pnlEnabelHPicture.Controls.Add(this.chkHPictureUnitNull);
            this.pnlEnabelHPicture.Controls.Add(this.lblUserHPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.chkHPictureCountNull);
            this.pnlEnabelHPicture.Controls.Add(this.lblLimitType);
            this.pnlEnabelHPicture.Controls.Add(this.lblUserCmd);
            this.pnlEnabelHPicture.Controls.Add(this.chkHPictureBeginNull);
            this.pnlEnabelHPicture.Controls.Add(this.txbBeautyPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureCmd);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureApiKey);
            this.pnlEnabelHPicture.Controls.Add(this.txbBeautyPictureEnd);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureEnd);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureBegin);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureKeyword);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureCount);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureR18);
            this.pnlEnabelHPicture.Controls.Add(this.txbHPictureUnit);
            this.pnlEnabelHPicture.Enabled = false;
            this.pnlEnabelHPicture.Location = new System.Drawing.Point(4, 41);
            this.pnlEnabelHPicture.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEnabelHPicture.Name = "pnlEnabelHPicture";
            this.pnlEnabelHPicture.Size = new System.Drawing.Size(644, 642);
            this.pnlEnabelHPicture.TabIndex = 8;
            // 
            // lblHPictureOnceMessageMaxImageCountHelp
            // 
            this.lblHPictureOnceMessageMaxImageCountHelp.AutoSize = true;
            this.lblHPictureOnceMessageMaxImageCountHelp.Location = new System.Drawing.Point(137, 547);
            this.lblHPictureOnceMessageMaxImageCountHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureOnceMessageMaxImageCountHelp.Name = "lblHPictureOnceMessageMaxImageCountHelp";
            this.lblHPictureOnceMessageMaxImageCountHelp.Size = new System.Drawing.Size(261, 17);
            this.lblHPictureOnceMessageMaxImageCountHelp.TabIndex = 18;
            this.lblHPictureOnceMessageMaxImageCountHelp.Text = "支持1-100, 建议不超过10个, 否则可能无法撤回";
            // 
            // txbHPictureOnceMessageMaxImageCount
            // 
            this.txbHPictureOnceMessageMaxImageCount.Location = new System.Drawing.Point(137, 520);
            this.txbHPictureOnceMessageMaxImageCount.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureOnceMessageMaxImageCount.Name = "txbHPictureOnceMessageMaxImageCount";
            this.txbHPictureOnceMessageMaxImageCount.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureOnceMessageMaxImageCount.TabIndex = 17;
            // 
            // lblHPictureOnceMessageMaxImageCount
            // 
            this.lblHPictureOnceMessageMaxImageCount.AutoSize = true;
            this.lblHPictureOnceMessageMaxImageCount.Location = new System.Drawing.Point(9, 523);
            this.lblHPictureOnceMessageMaxImageCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureOnceMessageMaxImageCount.Name = "lblHPictureOnceMessageMaxImageCount";
            this.lblHPictureOnceMessageMaxImageCount.Size = new System.Drawing.Size(131, 17);
            this.lblHPictureOnceMessageMaxImageCount.TabIndex = 16;
            this.lblHPictureOnceMessageMaxImageCount.Text = "单次请求最大图片数量:";
            // 
            // lblBeautyPictureSource
            // 
            this.lblBeautyPictureSource.AutoSize = true;
            this.lblBeautyPictureSource.Location = new System.Drawing.Point(8, 493);
            this.lblBeautyPictureSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBeautyPictureSource.Name = "lblBeautyPictureSource";
            this.lblBeautyPictureSource.Size = new System.Drawing.Size(59, 17);
            this.lblBeautyPictureSource.TabIndex = 15;
            this.lblBeautyPictureSource.Text = "美图图库:";
            // 
            // lblHPictureSource
            // 
            this.lblHPictureSource.AutoSize = true;
            this.lblHPictureSource.Location = new System.Drawing.Point(8, 466);
            this.lblHPictureSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureSource.Name = "lblHPictureSource";
            this.lblHPictureSource.Size = new System.Drawing.Size(59, 17);
            this.lblHPictureSource.TabIndex = 15;
            this.lblHPictureSource.Text = "色图图库:";
            // 
            // chkEnabledGreenOnionsBeautyPicture
            // 
            this.chkEnabledGreenOnionsBeautyPicture.AutoSize = true;
            this.chkEnabledGreenOnionsBeautyPicture.Location = new System.Drawing.Point(364, 492);
            this.chkEnabledGreenOnionsBeautyPicture.Name = "chkEnabledGreenOnionsBeautyPicture";
            this.chkEnabledGreenOnionsBeautyPicture.Size = new System.Drawing.Size(99, 21);
            this.chkEnabledGreenOnionsBeautyPicture.TabIndex = 14;
            this.chkEnabledGreenOnionsBeautyPicture.Text = "启用葱葱图库";
            this.chkEnabledGreenOnionsBeautyPicture.UseVisualStyleBackColor = true;
            this.chkEnabledGreenOnionsBeautyPicture.Visible = false;
            // 
            // chkEnabledGreenOnionsHPicture
            // 
            this.chkEnabledGreenOnionsHPicture.AutoSize = true;
            this.chkEnabledGreenOnionsHPicture.Location = new System.Drawing.Point(364, 465);
            this.chkEnabledGreenOnionsHPicture.Name = "chkEnabledGreenOnionsHPicture";
            this.chkEnabledGreenOnionsHPicture.Size = new System.Drawing.Size(99, 21);
            this.chkEnabledGreenOnionsHPicture.TabIndex = 14;
            this.chkEnabledGreenOnionsHPicture.Text = "启用葱葱图库";
            this.chkEnabledGreenOnionsHPicture.UseVisualStyleBackColor = true;
            this.chkEnabledGreenOnionsHPicture.Visible = false;
            // 
            // chkEnabledELFBeautyPicture
            // 
            this.chkEnabledELFBeautyPicture.AutoSize = true;
            this.chkEnabledELFBeautyPicture.Location = new System.Drawing.Point(254, 492);
            this.chkEnabledELFBeautyPicture.Name = "chkEnabledELFBeautyPicture";
            this.chkEnabledELFBeautyPicture.Size = new System.Drawing.Size(104, 21);
            this.chkEnabledELFBeautyPicture.TabIndex = 14;
            this.chkEnabledELFBeautyPicture.Text = "启用Shab图库";
            this.chkEnabledELFBeautyPicture.UseVisualStyleBackColor = true;
            // 
            // chkRevokeBeautyPicture
            // 
            this.chkRevokeBeautyPicture.AutoSize = true;
            this.chkRevokeBeautyPicture.Location = new System.Drawing.Point(510, 401);
            this.chkRevokeBeautyPicture.Name = "chkRevokeBeautyPicture";
            this.chkRevokeBeautyPicture.Size = new System.Drawing.Size(51, 21);
            this.chkRevokeBeautyPicture.TabIndex = 14;
            this.chkRevokeBeautyPicture.Text = "撤回";
            this.chkRevokeBeautyPicture.UseVisualStyleBackColor = true;
            // 
            // chkEnabledLoliconHPicture
            // 
            this.chkEnabledLoliconHPicture.AutoSize = true;
            this.chkEnabledLoliconHPicture.Location = new System.Drawing.Point(137, 465);
            this.chkEnabledLoliconHPicture.Name = "chkEnabledLoliconHPicture";
            this.chkEnabledLoliconHPicture.Size = new System.Drawing.Size(116, 21);
            this.chkEnabledLoliconHPicture.TabIndex = 14;
            this.chkEnabledLoliconHPicture.Text = "启用Lolicon图库";
            this.chkEnabledLoliconHPicture.UseVisualStyleBackColor = true;
            // 
            // lblMultithreading
            // 
            this.lblMultithreading.AutoSize = true;
            this.lblMultithreading.Location = new System.Drawing.Point(180, 1174);
            this.lblMultithreading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMultithreading.Name = "lblMultithreading";
            this.lblMultithreading.Size = new System.Drawing.Size(378, 17);
            this.lblMultithreading.TabIndex = 13;
            this.lblMultithreading.Text = "提示:网络带宽较低的环境下请禁用该功能, 避免带宽占满导致下载超时";
            // 
            // chkMultithreading
            // 
            this.chkMultithreading.AutoSize = true;
            this.chkMultithreading.Location = new System.Drawing.Point(8, 1174);
            this.chkMultithreading.Name = "chkMultithreading";
            this.chkMultithreading.Size = new System.Drawing.Size(135, 21);
            this.chkMultithreading.TabIndex = 12;
            this.chkMultithreading.Text = "启用多线程并发下载";
            this.chkMultithreading.UseVisualStyleBackColor = true;
            // 
            // rodHPictureLimitCount
            // 
            this.rodHPictureLimitCount.AutoSize = true;
            this.rodHPictureLimitCount.Location = new System.Drawing.Point(255, 954);
            this.rodHPictureLimitCount.Margin = new System.Windows.Forms.Padding(4);
            this.rodHPictureLimitCount.Name = "rodHPictureLimitCount";
            this.rodHPictureLimitCount.Size = new System.Drawing.Size(50, 21);
            this.rodHPictureLimitCount.TabIndex = 11;
            this.rodHPictureLimitCount.Tag = "Count";
            this.rodHPictureLimitCount.Text = "记张";
            this.rodHPictureLimitCount.UseVisualStyleBackColor = true;
            // 
            // rdoHPictureLimitFrequency
            // 
            this.rdoHPictureLimitFrequency.AutoSize = true;
            this.rdoHPictureLimitFrequency.Location = new System.Drawing.Point(194, 954);
            this.rdoHPictureLimitFrequency.Margin = new System.Windows.Forms.Padding(4);
            this.rdoHPictureLimitFrequency.Name = "rdoHPictureLimitFrequency";
            this.rdoHPictureLimitFrequency.Size = new System.Drawing.Size(50, 21);
            this.rdoHPictureLimitFrequency.TabIndex = 11;
            this.rdoHPictureLimitFrequency.Tag = "Frequency";
            this.rdoHPictureLimitFrequency.Text = "记次";
            this.rdoHPictureLimitFrequency.UseVisualStyleBackColor = true;
            // 
            // txbAddToWhiteGroup
            // 
            this.txbAddToWhiteGroup.Location = new System.Drawing.Point(425, 720);
            this.txbAddToWhiteGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddToWhiteGroup.Name = "txbAddToWhiteGroup";
            this.txbAddToWhiteGroup.ShortcutsEnabled = false;
            this.txbAddToWhiteGroup.Size = new System.Drawing.Size(186, 23);
            this.txbAddToWhiteGroup.TabIndex = 8;
            this.txbAddToWhiteGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbAddToWhiteGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbUserHPictureCmd
            // 
            this.txbUserHPictureCmd.Location = new System.Drawing.Point(427, 599);
            this.txbUserHPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserHPictureCmd.Name = "txbUserHPictureCmd";
            this.txbUserHPictureCmd.Size = new System.Drawing.Size(186, 23);
            this.txbUserHPictureCmd.TabIndex = 2;
            // 
            // txbPMCD
            // 
            this.txbPMCD.Location = new System.Drawing.Point(518, 876);
            this.txbPMCD.Margin = new System.Windows.Forms.Padding(4);
            this.txbPMCD.Name = "txbPMCD";
            this.txbPMCD.ShortcutsEnabled = false;
            this.txbPMCD.Size = new System.Drawing.Size(93, 23);
            this.txbPMCD.TabIndex = 8;
            this.txbPMCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbPMCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbWhiteCD
            // 
            this.txbWhiteCD.Location = new System.Drawing.Point(309, 876);
            this.txbWhiteCD.Margin = new System.Windows.Forms.Padding(4);
            this.txbWhiteCD.Name = "txbWhiteCD";
            this.txbWhiteCD.ShortcutsEnabled = false;
            this.txbWhiteCD.Size = new System.Drawing.Size(93, 23);
            this.txbWhiteCD.TabIndex = 8;
            this.txbWhiteCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbWhiteCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbPMRevoke
            // 
            this.txbPMRevoke.Location = new System.Drawing.Point(518, 914);
            this.txbPMRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.txbPMRevoke.Name = "txbPMRevoke";
            this.txbPMRevoke.ShortcutsEnabled = false;
            this.txbPMRevoke.Size = new System.Drawing.Size(93, 23);
            this.txbPMRevoke.TabIndex = 8;
            this.txbPMRevoke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbPMRevoke.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbWhiteRevoke
            // 
            this.txbWhiteRevoke.Location = new System.Drawing.Point(309, 914);
            this.txbWhiteRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.txbWhiteRevoke.Name = "txbWhiteRevoke";
            this.txbWhiteRevoke.ShortcutsEnabled = false;
            this.txbWhiteRevoke.Size = new System.Drawing.Size(93, 23);
            this.txbWhiteRevoke.TabIndex = 8;
            this.txbWhiteRevoke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbWhiteRevoke.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // lstHPictureUserCmd
            // 
            this.lstHPictureUserCmd.FullRowSelect = true;
            this.lstHPictureUserCmd.HideSelection = false;
            this.lstHPictureUserCmd.Location = new System.Drawing.Point(137, 578);
            this.lstHPictureUserCmd.Margin = new System.Windows.Forms.Padding(4);
            this.lstHPictureUserCmd.Name = "lstHPictureUserCmd";
            this.lstHPictureUserCmd.Size = new System.Drawing.Size(186, 98);
            this.lstHPictureUserCmd.TabIndex = 10;
            this.lstHPictureUserCmd.UseCompatibleStateImageBehavior = false;
            this.lstHPictureUserCmd.View = System.Windows.Forms.View.List;
            // 
            // lstHPictureWhiteGroup
            // 
            this.lstHPictureWhiteGroup.FullRowSelect = true;
            this.lstHPictureWhiteGroup.HideSelection = false;
            this.lstHPictureWhiteGroup.Location = new System.Drawing.Point(135, 702);
            this.lstHPictureWhiteGroup.Margin = new System.Windows.Forms.Padding(4);
            this.lstHPictureWhiteGroup.Name = "lstHPictureWhiteGroup";
            this.lstHPictureWhiteGroup.Size = new System.Drawing.Size(186, 98);
            this.lstHPictureWhiteGroup.TabIndex = 10;
            this.lstHPictureWhiteGroup.UseCompatibleStateImageBehavior = false;
            this.lstHPictureWhiteGroup.View = System.Windows.Forms.View.List;
            // 
            // lblPMRevoke
            // 
            this.lblPMRevoke.AutoSize = true;
            this.lblPMRevoke.Location = new System.Drawing.Point(414, 918);
            this.lblPMRevoke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPMRevoke.Name = "lblPMRevoke";
            this.lblPMRevoke.Size = new System.Drawing.Size(83, 17);
            this.lblPMRevoke.TabIndex = 9;
            this.lblPMRevoke.Text = "私聊撤回时间:";
            // 
            // lblWhiteRevoke
            // 
            this.lblWhiteRevoke.AutoSize = true;
            this.lblWhiteRevoke.Location = new System.Drawing.Point(191, 918);
            this.lblWhiteRevoke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhiteRevoke.Name = "lblWhiteRevoke";
            this.lblWhiteRevoke.Size = new System.Drawing.Size(95, 17);
            this.lblWhiteRevoke.TabIndex = 9;
            this.lblWhiteRevoke.Text = "白名单撤回时间:";
            // 
            // lblPMCD
            // 
            this.lblPMCD.AutoSize = true;
            this.lblPMCD.Location = new System.Drawing.Point(414, 880);
            this.lblPMCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPMCD.Name = "lblPMCD";
            this.lblPMCD.Size = new System.Drawing.Size(83, 17);
            this.lblPMCD.TabIndex = 9;
            this.lblPMCD.Text = "私聊冷却时间:";
            // 
            // lblWhiteCD
            // 
            this.lblWhiteCD.AutoSize = true;
            this.lblWhiteCD.Location = new System.Drawing.Point(191, 880);
            this.lblWhiteCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhiteCD.Name = "lblWhiteCD";
            this.lblWhiteCD.Size = new System.Drawing.Size(95, 17);
            this.lblWhiteCD.TabIndex = 9;
            this.lblWhiteCD.Text = "白名单冷却时间:";
            // 
            // lblDownloadAccelerate
            // 
            this.lblDownloadAccelerate.AutoSize = true;
            this.lblDownloadAccelerate.Location = new System.Drawing.Point(6, 842);
            this.lblDownloadAccelerate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadAccelerate.Name = "lblDownloadAccelerate";
            this.lblDownloadAccelerate.Size = new System.Drawing.Size(107, 17);
            this.lblDownloadAccelerate.TabIndex = 9;
            this.lblDownloadAccelerate.Text = "图片下载加速地址:";
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Location = new System.Drawing.Point(6, 880);
            this.lblCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(59, 17);
            this.lblCD.TabIndex = 9;
            this.lblCD.Text = "冷却时间:";
            // 
            // lblDownloadFail
            // 
            this.lblDownloadFail.AutoSize = true;
            this.lblDownloadFail.Location = new System.Drawing.Point(6, 1148);
            this.lblDownloadFail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadFail.Name = "lblDownloadFail";
            this.lblDownloadFail.Size = new System.Drawing.Size(119, 17);
            this.lblDownloadFail.TabIndex = 9;
            this.lblDownloadFail.Text = "图片下载失败回复语:";
            // 
            // lblNoResult
            // 
            this.lblNoResult.AutoSize = true;
            this.lblNoResult.Location = new System.Drawing.Point(6, 1118);
            this.lblNoResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoResult.Name = "lblNoResult";
            this.lblNoResult.Size = new System.Drawing.Size(83, 17);
            this.lblNoResult.TabIndex = 9;
            this.lblNoResult.Text = "无结果回复语:";
            // 
            // lblErrorReply
            // 
            this.lblErrorReply.AutoSize = true;
            this.lblErrorReply.Location = new System.Drawing.Point(6, 1088);
            this.lblErrorReply.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorReply.Name = "lblErrorReply";
            this.lblErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblErrorReply.TabIndex = 9;
            this.lblErrorReply.Text = "发生错误回复语:";
            // 
            // lblOutOfLimitReply
            // 
            this.lblOutOfLimitReply.AutoSize = true;
            this.lblOutOfLimitReply.Location = new System.Drawing.Point(6, 1058);
            this.lblOutOfLimitReply.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutOfLimitReply.Name = "lblOutOfLimitReply";
            this.lblOutOfLimitReply.Size = new System.Drawing.Size(95, 17);
            this.lblOutOfLimitReply.TabIndex = 9;
            this.lblOutOfLimitReply.Text = "超过次数回复语:";
            // 
            // lblCDUnreadyReply
            // 
            this.lblCDUnreadyReply.AutoSize = true;
            this.lblCDUnreadyReply.Location = new System.Drawing.Point(6, 1029);
            this.lblCDUnreadyReply.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCDUnreadyReply.Name = "lblCDUnreadyReply";
            this.lblCDUnreadyReply.Size = new System.Drawing.Size(107, 17);
            this.lblCDUnreadyReply.TabIndex = 9;
            this.lblCDUnreadyReply.Text = "冷却时间内回复语:";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(6, 957);
            this.lblLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(59, 17);
            this.lblLimit.TabIndex = 9;
            this.lblLimit.Text = "次数限制:";
            // 
            // lblRevoke
            // 
            this.lblRevoke.AutoSize = true;
            this.lblRevoke.Location = new System.Drawing.Point(6, 918);
            this.lblRevoke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevoke.Name = "lblRevoke";
            this.lblRevoke.Size = new System.Drawing.Size(59, 17);
            this.lblRevoke.TabIndex = 9;
            this.lblRevoke.Text = "撤回时间:";
            // 
            // lblWhiteGroup
            // 
            this.lblWhiteGroup.AutoSize = true;
            this.lblWhiteGroup.Location = new System.Drawing.Point(4, 714);
            this.lblWhiteGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhiteGroup.Name = "lblWhiteGroup";
            this.lblWhiteGroup.Size = new System.Drawing.Size(59, 17);
            this.lblWhiteGroup.TabIndex = 9;
            this.lblWhiteGroup.Text = "群白名单:";
            // 
            // txbDownloadFailReply
            // 
            this.txbDownloadFailReply.Location = new System.Drawing.Point(141, 1145);
            this.txbDownloadFailReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbDownloadFailReply.Multiline = true;
            this.txbDownloadFailReply.Name = "txbDownloadFailReply";
            this.txbDownloadFailReply.Size = new System.Drawing.Size(469, 23);
            this.txbDownloadFailReply.TabIndex = 8;
            // 
            // txbHPictureNoResultReply
            // 
            this.txbHPictureNoResultReply.Location = new System.Drawing.Point(141, 1115);
            this.txbHPictureNoResultReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureNoResultReply.Multiline = true;
            this.txbHPictureNoResultReply.Name = "txbHPictureNoResultReply";
            this.txbHPictureNoResultReply.Size = new System.Drawing.Size(469, 23);
            this.txbHPictureNoResultReply.TabIndex = 8;
            // 
            // txbHPictureErrorReplyReply
            // 
            this.txbHPictureErrorReplyReply.Location = new System.Drawing.Point(141, 1085);
            this.txbHPictureErrorReplyReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureErrorReplyReply.Multiline = true;
            this.txbHPictureErrorReplyReply.Name = "txbHPictureErrorReplyReply";
            this.txbHPictureErrorReplyReply.Size = new System.Drawing.Size(469, 23);
            this.txbHPictureErrorReplyReply.TabIndex = 8;
            // 
            // txbOutOfLimitReply
            // 
            this.txbOutOfLimitReply.Location = new System.Drawing.Point(141, 1055);
            this.txbOutOfLimitReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbOutOfLimitReply.Multiline = true;
            this.txbOutOfLimitReply.Name = "txbOutOfLimitReply";
            this.txbOutOfLimitReply.Size = new System.Drawing.Size(469, 23);
            this.txbOutOfLimitReply.TabIndex = 8;
            // 
            // txbDownloadAccelerateUrl
            // 
            this.txbDownloadAccelerateUrl.Enabled = false;
            this.txbDownloadAccelerateUrl.Location = new System.Drawing.Point(141, 838);
            this.txbDownloadAccelerateUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txbDownloadAccelerateUrl.Name = "txbDownloadAccelerateUrl";
            this.txbDownloadAccelerateUrl.Size = new System.Drawing.Size(359, 23);
            this.txbDownloadAccelerateUrl.TabIndex = 8;
            // 
            // txbCDUnreadyReply
            // 
            this.txbCDUnreadyReply.Location = new System.Drawing.Point(141, 1025);
            this.txbCDUnreadyReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbCDUnreadyReply.Multiline = true;
            this.txbCDUnreadyReply.Name = "txbCDUnreadyReply";
            this.txbCDUnreadyReply.Size = new System.Drawing.Size(469, 23);
            this.txbCDUnreadyReply.TabIndex = 8;
            // 
            // txbCD
            // 
            this.txbCD.Location = new System.Drawing.Point(82, 876);
            this.txbCD.Margin = new System.Windows.Forms.Padding(4);
            this.txbCD.Name = "txbCD";
            this.txbCD.ShortcutsEnabled = false;
            this.txbCD.Size = new System.Drawing.Size(93, 23);
            this.txbCD.TabIndex = 8;
            this.txbCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbLimit
            // 
            this.txbLimit.Location = new System.Drawing.Point(82, 952);
            this.txbLimit.Margin = new System.Windows.Forms.Padding(4);
            this.txbLimit.Name = "txbLimit";
            this.txbLimit.ShortcutsEnabled = false;
            this.txbLimit.Size = new System.Drawing.Size(93, 23);
            this.txbLimit.TabIndex = 8;
            this.txbLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbLimit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbRevoke
            // 
            this.txbRevoke.Location = new System.Drawing.Point(82, 914);
            this.txbRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.txbRevoke.Name = "txbRevoke";
            this.txbRevoke.ShortcutsEnabled = false;
            this.txbRevoke.Size = new System.Drawing.Size(93, 23);
            this.txbRevoke.TabIndex = 8;
            this.txbRevoke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRevoke.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // chkAllowR18
            // 
            this.chkAllowR18.AutoSize = true;
            this.chkAllowR18.Location = new System.Drawing.Point(112, 808);
            this.chkAllowR18.Margin = new System.Windows.Forms.Padding(4);
            this.chkAllowR18.Name = "chkAllowR18";
            this.chkAllowR18.Size = new System.Drawing.Size(78, 21);
            this.chkAllowR18.TabIndex = 7;
            this.chkAllowR18.Text = "允许R-18";
            this.chkAllowR18.UseVisualStyleBackColor = true;
            // 
            // chkManageNoLimit
            // 
            this.chkManageNoLimit.AutoSize = true;
            this.chkManageNoLimit.Location = new System.Drawing.Point(270, 991);
            this.chkManageNoLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkManageNoLimit.Name = "chkManageNoLimit";
            this.chkManageNoLimit.Size = new System.Drawing.Size(187, 21);
            this.chkManageNoLimit.TabIndex = 7;
            this.chkManageNoLimit.Text = "QQ群主和QQ群管理员无限制";
            this.chkManageNoLimit.UseVisualStyleBackColor = true;
            // 
            // chkAdminNoLimit
            // 
            this.chkAdminNoLimit.AutoSize = true;
            this.chkAdminNoLimit.Location = new System.Drawing.Point(115, 991);
            this.chkAdminNoLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkAdminNoLimit.Name = "chkAdminNoLimit";
            this.chkAdminNoLimit.Size = new System.Drawing.Size(135, 21);
            this.chkAdminNoLimit.TabIndex = 7;
            this.chkAdminNoLimit.Text = "机器人管理员无限制";
            this.chkAdminNoLimit.UseVisualStyleBackColor = true;
            // 
            // chkWhiteNoLimit
            // 
            this.chkWhiteNoLimit.AutoSize = true;
            this.chkWhiteNoLimit.Location = new System.Drawing.Point(477, 991);
            this.chkWhiteNoLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkWhiteNoLimit.Name = "chkWhiteNoLimit";
            this.chkWhiteNoLimit.Size = new System.Drawing.Size(135, 21);
            this.chkWhiteNoLimit.TabIndex = 7;
            this.chkWhiteNoLimit.Text = "白名单群无次数限制";
            this.chkWhiteNoLimit.UseVisualStyleBackColor = true;
            // 
            // chkPMNoLimit
            // 
            this.chkPMNoLimit.AutoSize = true;
            this.chkPMNoLimit.Location = new System.Drawing.Point(8, 991);
            this.chkPMNoLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkPMNoLimit.Name = "chkPMNoLimit";
            this.chkPMNoLimit.Size = new System.Drawing.Size(87, 21);
            this.chkPMNoLimit.TabIndex = 7;
            this.chkPMNoLimit.Text = "私聊无限制";
            this.chkPMNoLimit.UseVisualStyleBackColor = true;
            // 
            // chkR18WhiteOnly
            // 
            this.chkR18WhiteOnly.AutoSize = true;
            this.chkR18WhiteOnly.Location = new System.Drawing.Point(207, 808);
            this.chkR18WhiteOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkR18WhiteOnly.Name = "chkR18WhiteOnly";
            this.chkR18WhiteOnly.Size = new System.Drawing.Size(114, 21);
            this.chkR18WhiteOnly.TabIndex = 7;
            this.chkR18WhiteOnly.Text = "R-18仅限白名单";
            this.chkR18WhiteOnly.UseVisualStyleBackColor = true;
            // 
            // chkWhiteOnly
            // 
            this.chkWhiteOnly.AutoSize = true;
            this.chkWhiteOnly.Location = new System.Drawing.Point(8, 808);
            this.chkWhiteOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkWhiteOnly.Name = "chkWhiteOnly";
            this.chkWhiteOnly.Size = new System.Drawing.Size(87, 21);
            this.chkWhiteOnly.TabIndex = 7;
            this.chkWhiteOnly.Text = "仅限白名单";
            this.chkWhiteOnly.UseVisualStyleBackColor = true;
            // 
            // chkDownloadAccelerate
            // 
            this.chkDownloadAccelerate.AutoSize = true;
            this.chkDownloadAccelerate.Location = new System.Drawing.Point(512, 840);
            this.chkDownloadAccelerate.Margin = new System.Windows.Forms.Padding(4);
            this.chkDownloadAccelerate.Name = "chkDownloadAccelerate";
            this.chkDownloadAccelerate.Size = new System.Drawing.Size(99, 21);
            this.chkDownloadAccelerate.TabIndex = 7;
            this.chkDownloadAccelerate.Text = "使用下载加速";
            this.chkDownloadAccelerate.UseVisualStyleBackColor = true;
            this.chkDownloadAccelerate.CheckedChanged += new System.EventHandler(this.chkDownloadAccelerate_CheckedChanged);
            // 
            // chkSize1200
            // 
            this.chkSize1200.AutoSize = true;
            this.chkSize1200.Location = new System.Drawing.Point(511, 296);
            this.chkSize1200.Margin = new System.Windows.Forms.Padding(4);
            this.chkSize1200.Name = "chkSize1200";
            this.chkSize1200.Size = new System.Drawing.Size(103, 21);
            this.chkSize1200.TabIndex = 7;
            this.chkSize1200.Text = "1200像素模式";
            this.chkSize1200.UseVisualStyleBackColor = true;
            // 
            // chkPM
            // 
            this.chkPM.AutoSize = true;
            this.chkPM.Location = new System.Drawing.Point(338, 808);
            this.chkPM.Margin = new System.Windows.Forms.Padding(4);
            this.chkPM.Name = "chkPM";
            this.chkPM.Size = new System.Drawing.Size(75, 21);
            this.chkPM.TabIndex = 7;
            this.chkPM.Text = "允许私聊";
            this.chkPM.UseVisualStyleBackColor = true;
            // 
            // chkAntiShielding
            // 
            this.chkAntiShielding.AutoSize = true;
            this.chkAntiShielding.Location = new System.Drawing.Point(430, 808);
            this.chkAntiShielding.Margin = new System.Windows.Forms.Padding(4);
            this.chkAntiShielding.Name = "chkAntiShielding";
            this.chkAntiShielding.Size = new System.Drawing.Size(63, 21);
            this.chkAntiShielding.TabIndex = 7;
            this.chkAntiShielding.Text = "反和谐";
            this.chkAntiShielding.UseVisualStyleBackColor = true;
            // 
            // lblUserCmdInformation
            // 
            this.lblUserCmdInformation.AutoSize = true;
            this.lblUserCmdInformation.Location = new System.Drawing.Point(430, 578);
            this.lblUserCmdInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserCmdInformation.Name = "lblUserCmdInformation";
            this.lblUserCmdInformation.Size = new System.Drawing.Size(155, 17);
            this.lblUserCmdInformation.TabIndex = 0;
            this.lblUserCmdInformation.Text = "添加到自定义色图命令列表:";
            // 
            // lblAddToWhiteGroupInformation
            // 
            this.lblAddToWhiteGroupInformation.AutoSize = true;
            this.lblAddToWhiteGroupInformation.Location = new System.Drawing.Point(428, 702);
            this.lblAddToWhiteGroupInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddToWhiteGroupInformation.Name = "lblAddToWhiteGroupInformation";
            this.lblAddToWhiteGroupInformation.Size = new System.Drawing.Size(119, 17);
            this.lblAddToWhiteGroupInformation.TabIndex = 0;
            this.lblAddToWhiteGroupInformation.Text = "添加到群白名单列表:";
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Enabled = false;
            this.lblApiKey.Location = new System.Drawing.Point(8, 9);
            this.lblApiKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(51, 17);
            this.lblApiKey.TabIndex = 0;
            this.lblApiKey.Text = "ApiKey:";
            // 
            // lblHPictureBegin
            // 
            this.lblHPictureBegin.AutoSize = true;
            this.lblHPictureBegin.Location = new System.Drawing.Point(8, 40);
            this.lblHPictureBegin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureBegin.Name = "lblHPictureBegin";
            this.lblHPictureBegin.Size = new System.Drawing.Size(83, 17);
            this.lblHPictureBegin.TabIndex = 0;
            this.lblHPictureBegin.Text = "色图命令前缀:";
            // 
            // lblBeautyPictureCmd
            // 
            this.lblBeautyPictureCmd.AutoSize = true;
            this.lblBeautyPictureCmd.Location = new System.Drawing.Point(8, 402);
            this.lblBeautyPictureCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBeautyPictureCmd.Name = "lblBeautyPictureCmd";
            this.lblBeautyPictureCmd.Size = new System.Drawing.Size(59, 17);
            this.lblBeautyPictureCmd.TabIndex = 0;
            this.lblBeautyPictureCmd.Text = "美图命令:";
            // 
            // lblLoliconHPictureCmd
            // 
            this.lblLoliconHPictureCmd.AutoSize = true;
            this.lblLoliconHPictureCmd.Location = new System.Drawing.Point(8, 297);
            this.lblLoliconHPictureCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoliconHPictureCmd.Name = "lblLoliconHPictureCmd";
            this.lblLoliconHPictureCmd.Size = new System.Drawing.Size(59, 17);
            this.lblLoliconHPictureCmd.TabIndex = 0;
            this.lblLoliconHPictureCmd.Text = "色图命令:";
            // 
            // btnRemoveWhiteGroup
            // 
            this.btnRemoveWhiteGroup.Location = new System.Drawing.Point(331, 751);
            this.btnRemoveWhiteGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveWhiteGroup.Name = "btnRemoveWhiteGroup";
            this.btnRemoveWhiteGroup.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveWhiteGroup.TabIndex = 6;
            this.btnRemoveWhiteGroup.Text = ">>移除>>";
            this.btnRemoveWhiteGroup.UseVisualStyleBackColor = true;
            this.btnRemoveWhiteGroup.Click += new System.EventHandler(this.btnRemoveWhiteGroup_Click);
            // 
            // btnAddToWhiteGroup
            // 
            this.btnAddToWhiteGroup.Location = new System.Drawing.Point(331, 720);
            this.btnAddToWhiteGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddToWhiteGroup.Name = "btnAddToWhiteGroup";
            this.btnAddToWhiteGroup.Size = new System.Drawing.Size(88, 23);
            this.btnAddToWhiteGroup.TabIndex = 6;
            this.btnAddToWhiteGroup.Text = "<<添加<<";
            this.btnAddToWhiteGroup.UseVisualStyleBackColor = true;
            this.btnAddToWhiteGroup.Click += new System.EventHandler(this.btnAddToWhiteGroup_Click);
            // 
            // btnRemoveUserHPictureCmd
            // 
            this.btnRemoveUserHPictureCmd.Location = new System.Drawing.Point(333, 630);
            this.btnRemoveUserHPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveUserHPictureCmd.Name = "btnRemoveUserHPictureCmd";
            this.btnRemoveUserHPictureCmd.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveUserHPictureCmd.TabIndex = 6;
            this.btnRemoveUserHPictureCmd.Text = ">>移除>>";
            this.btnRemoveUserHPictureCmd.UseVisualStyleBackColor = true;
            this.btnRemoveUserHPictureCmd.Click += new System.EventHandler(this.btnRemoveUserHPictureCmd_Click);
            // 
            // btnAddUserHPictureCmd
            // 
            this.btnAddUserHPictureCmd.Location = new System.Drawing.Point(333, 599);
            this.btnAddUserHPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUserHPictureCmd.Name = "btnAddUserHPictureCmd";
            this.btnAddUserHPictureCmd.Size = new System.Drawing.Size(88, 23);
            this.btnAddUserHPictureCmd.TabIndex = 6;
            this.btnAddUserHPictureCmd.Text = "<<添加<<";
            this.btnAddUserHPictureCmd.UseVisualStyleBackColor = true;
            this.btnAddUserHPictureCmd.Click += new System.EventHandler(this.btnAddUserHPictureCmd_Click);
            // 
            // lblHPictureCount
            // 
            this.lblHPictureCount.AutoSize = true;
            this.lblHPictureCount.Location = new System.Drawing.Point(8, 71);
            this.lblHPictureCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureCount.Name = "lblHPictureCount";
            this.lblHPictureCount.Size = new System.Drawing.Size(83, 17);
            this.lblHPictureCount.TabIndex = 0;
            this.lblHPictureCount.Text = "色图数量命令:";
            // 
            // lnkResetHPicture
            // 
            this.lnkResetHPicture.AutoSize = true;
            this.lnkResetHPicture.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkResetHPicture.Location = new System.Drawing.Point(551, 348);
            this.lnkResetHPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkResetHPicture.Name = "lnkResetHPicture";
            this.lnkResetHPicture.Size = new System.Drawing.Size(32, 17);
            this.lnkResetHPicture.TabIndex = 5;
            this.lnkResetHPicture.TabStop = true;
            this.lnkResetHPicture.Text = "还原";
            this.lnkResetHPicture.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkResetHPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetHPicture_LinkClicked);
            // 
            // lblHPictureUnit
            // 
            this.lblHPictureUnit.AutoSize = true;
            this.lblHPictureUnit.Location = new System.Drawing.Point(8, 102);
            this.lblHPictureUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureUnit.Name = "lblHPictureUnit";
            this.lblHPictureUnit.Size = new System.Drawing.Size(83, 17);
            this.lblHPictureUnit.TabIndex = 0;
            this.lblHPictureUnit.Text = "色图数量单位:";
            // 
            // chkBeautyPictureEndNull
            // 
            this.chkBeautyPictureEndNull.AutoSize = true;
            this.chkBeautyPictureEndNull.Location = new System.Drawing.Point(511, 225);
            this.chkBeautyPictureEndNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkBeautyPictureEndNull.Name = "chkBeautyPictureEndNull";
            this.chkBeautyPictureEndNull.Size = new System.Drawing.Size(63, 21);
            this.chkBeautyPictureEndNull.TabIndex = 4;
            this.chkBeautyPictureEndNull.Text = "可为空";
            this.chkBeautyPictureEndNull.UseVisualStyleBackColor = true;
            this.chkBeautyPictureEndNull.CheckedChanged += new System.EventHandler(this.chkHPictureBeginNull_CheckedChanged);
            // 
            // chkHPictureEndNull
            // 
            this.chkHPictureEndNull.AutoSize = true;
            this.chkHPictureEndNull.Location = new System.Drawing.Point(511, 194);
            this.chkHPictureEndNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureEndNull.Name = "chkHPictureEndNull";
            this.chkHPictureEndNull.Size = new System.Drawing.Size(63, 21);
            this.chkHPictureEndNull.TabIndex = 4;
            this.chkHPictureEndNull.Text = "可为空";
            this.chkHPictureEndNull.UseVisualStyleBackColor = true;
            this.chkHPictureEndNull.CheckedChanged += new System.EventHandler(this.chkHPictureBeginNull_CheckedChanged);
            // 
            // lblHPictureR18
            // 
            this.lblHPictureR18.AutoSize = true;
            this.lblHPictureR18.Location = new System.Drawing.Point(8, 133);
            this.lblHPictureR18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureR18.Name = "lblHPictureR18";
            this.lblHPictureR18.Size = new System.Drawing.Size(86, 17);
            this.lblHPictureR18.TabIndex = 0;
            this.lblHPictureR18.Text = "包含R-18命令:";
            // 
            // chkHPictureKeywordNull
            // 
            this.chkHPictureKeywordNull.AutoSize = true;
            this.chkHPictureKeywordNull.Location = new System.Drawing.Point(511, 164);
            this.chkHPictureKeywordNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureKeywordNull.Name = "chkHPictureKeywordNull";
            this.chkHPictureKeywordNull.Size = new System.Drawing.Size(63, 21);
            this.chkHPictureKeywordNull.TabIndex = 4;
            this.chkHPictureKeywordNull.Text = "可为空";
            this.chkHPictureKeywordNull.UseVisualStyleBackColor = true;
            this.chkHPictureKeywordNull.CheckedChanged += new System.EventHandler(this.chkHPictureBeginNull_CheckedChanged);
            // 
            // lblHPictureKeyword
            // 
            this.lblHPictureKeyword.AutoSize = true;
            this.lblHPictureKeyword.Location = new System.Drawing.Point(8, 164);
            this.lblHPictureKeyword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureKeyword.Name = "lblHPictureKeyword";
            this.lblHPictureKeyword.Size = new System.Drawing.Size(71, 17);
            this.lblHPictureKeyword.TabIndex = 0;
            this.lblHPictureKeyword.Text = "关键词命令:";
            // 
            // chkHPictureR18Null
            // 
            this.chkHPictureR18Null.AutoSize = true;
            this.chkHPictureR18Null.Location = new System.Drawing.Point(511, 133);
            this.chkHPictureR18Null.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureR18Null.Name = "chkHPictureR18Null";
            this.chkHPictureR18Null.Size = new System.Drawing.Size(63, 21);
            this.chkHPictureR18Null.TabIndex = 4;
            this.chkHPictureR18Null.Text = "可为空";
            this.chkHPictureR18Null.UseVisualStyleBackColor = true;
            this.chkHPictureR18Null.CheckedChanged += new System.EventHandler(this.chkHPictureBeginNull_CheckedChanged);
            // 
            // lblShabHPictureEnd
            // 
            this.lblShabHPictureEnd.AutoSize = true;
            this.lblShabHPictureEnd.Location = new System.Drawing.Point(8, 225);
            this.lblShabHPictureEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShabHPictureEnd.Name = "lblShabHPictureEnd";
            this.lblShabHPictureEnd.Size = new System.Drawing.Size(83, 17);
            this.lblShabHPictureEnd.TabIndex = 0;
            this.lblShabHPictureEnd.Text = "美图命令后缀:";
            // 
            // lblHPictureEnd
            // 
            this.lblHPictureEnd.AutoSize = true;
            this.lblHPictureEnd.Location = new System.Drawing.Point(8, 194);
            this.lblHPictureEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureEnd.Name = "lblHPictureEnd";
            this.lblHPictureEnd.Size = new System.Drawing.Size(83, 17);
            this.lblHPictureEnd.TabIndex = 0;
            this.lblHPictureEnd.Text = "色图命令后缀:";
            // 
            // chkHPictureUnitNull
            // 
            this.chkHPictureUnitNull.AutoSize = true;
            this.chkHPictureUnitNull.Location = new System.Drawing.Point(511, 102);
            this.chkHPictureUnitNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureUnitNull.Name = "chkHPictureUnitNull";
            this.chkHPictureUnitNull.Size = new System.Drawing.Size(63, 21);
            this.chkHPictureUnitNull.TabIndex = 4;
            this.chkHPictureUnitNull.Text = "可为空";
            this.chkHPictureUnitNull.UseVisualStyleBackColor = true;
            this.chkHPictureUnitNull.CheckedChanged += new System.EventHandler(this.chkHPictureBeginNull_CheckedChanged);
            // 
            // lblUserHPictureCmd
            // 
            this.lblUserHPictureCmd.AutoSize = true;
            this.lblUserHPictureCmd.Location = new System.Drawing.Point(6, 589);
            this.lblUserHPictureCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserHPictureCmd.Name = "lblUserHPictureCmd";
            this.lblUserHPictureCmd.Size = new System.Drawing.Size(95, 17);
            this.lblUserHPictureCmd.TabIndex = 0;
            this.lblUserHPictureCmd.Text = "自定义色图命令:";
            // 
            // chkHPictureCountNull
            // 
            this.chkHPictureCountNull.AutoSize = true;
            this.chkHPictureCountNull.Location = new System.Drawing.Point(511, 71);
            this.chkHPictureCountNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureCountNull.Name = "chkHPictureCountNull";
            this.chkHPictureCountNull.Size = new System.Drawing.Size(63, 21);
            this.chkHPictureCountNull.TabIndex = 4;
            this.chkHPictureCountNull.Text = "可为空";
            this.chkHPictureCountNull.UseVisualStyleBackColor = true;
            this.chkHPictureCountNull.CheckedChanged += new System.EventHandler(this.chkHPictureBeginNull_CheckedChanged);
            // 
            // lblLimitType
            // 
            this.lblLimitType.AutoSize = true;
            this.lblLimitType.Location = new System.Drawing.Point(327, 955);
            this.lblLimitType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLimitType.Name = "lblLimitType";
            this.lblLimitType.Size = new System.Drawing.Size(258, 17);
            this.lblLimitType.TabIndex = 0;
            this.lblLimitType.Text = "提示:记次模式下单次请求多少张色图都只记1次";
            // 
            // lblUserCmd
            // 
            this.lblUserCmd.AutoSize = true;
            this.lblUserCmd.Location = new System.Drawing.Point(135, 681);
            this.lblUserCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserCmd.Name = "lblUserCmd";
            this.lblUserCmd.Size = new System.Drawing.Size(381, 17);
            this.lblUserCmd.TabIndex = 0;
            this.lblUserCmd.Text = "提示:自定义命令只能完整匹配时生效，返回单张不含R18的随机色图。";
            // 
            // chkHPictureBeginNull
            // 
            this.chkHPictureBeginNull.AutoSize = true;
            this.chkHPictureBeginNull.Location = new System.Drawing.Point(511, 40);
            this.chkHPictureBeginNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureBeginNull.Name = "chkHPictureBeginNull";
            this.chkHPictureBeginNull.Size = new System.Drawing.Size(63, 21);
            this.chkHPictureBeginNull.TabIndex = 4;
            this.chkHPictureBeginNull.Text = "可为空";
            this.chkHPictureBeginNull.UseVisualStyleBackColor = true;
            this.chkHPictureBeginNull.CheckedChanged += new System.EventHandler(this.chkHPictureBeginNull_CheckedChanged);
            // 
            // txbBeautyPictureCmd
            // 
            this.txbBeautyPictureCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBeautyPictureCmd.Location = new System.Drawing.Point(137, 360);
            this.txbBeautyPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txbBeautyPictureCmd.Multiline = true;
            this.txbBeautyPictureCmd.Name = "txbBeautyPictureCmd";
            this.txbBeautyPictureCmd.ReadOnly = true;
            this.txbBeautyPictureCmd.Size = new System.Drawing.Size(366, 98);
            this.txbBeautyPictureCmd.TabIndex = 1;
            // 
            // txbHPictureCmd
            // 
            this.txbHPictureCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbHPictureCmd.Location = new System.Drawing.Point(137, 255);
            this.txbHPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureCmd.Multiline = true;
            this.txbHPictureCmd.Name = "txbHPictureCmd";
            this.txbHPictureCmd.ReadOnly = true;
            this.txbHPictureCmd.Size = new System.Drawing.Size(366, 98);
            this.txbHPictureCmd.TabIndex = 1;
            // 
            // txbHPictureApiKey
            // 
            this.txbHPictureApiKey.Enabled = false;
            this.txbHPictureApiKey.Location = new System.Drawing.Point(137, 6);
            this.txbHPictureApiKey.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureApiKey.Name = "txbHPictureApiKey";
            this.txbHPictureApiKey.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureApiKey.TabIndex = 2;
            this.txbHPictureApiKey.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // txbBeautyPictureEnd
            // 
            this.txbBeautyPictureEnd.Location = new System.Drawing.Point(137, 224);
            this.txbBeautyPictureEnd.Margin = new System.Windows.Forms.Padding(4);
            this.txbBeautyPictureEnd.Name = "txbBeautyPictureEnd";
            this.txbBeautyPictureEnd.Size = new System.Drawing.Size(366, 23);
            this.txbBeautyPictureEnd.TabIndex = 2;
            this.txbBeautyPictureEnd.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // txbHPictureEnd
            // 
            this.txbHPictureEnd.Location = new System.Drawing.Point(137, 193);
            this.txbHPictureEnd.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureEnd.Name = "txbHPictureEnd";
            this.txbHPictureEnd.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureEnd.TabIndex = 2;
            this.txbHPictureEnd.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // txbHPictureBegin
            // 
            this.txbHPictureBegin.Location = new System.Drawing.Point(137, 37);
            this.txbHPictureBegin.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureBegin.Name = "txbHPictureBegin";
            this.txbHPictureBegin.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureBegin.TabIndex = 2;
            this.txbHPictureBegin.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // txbHPictureKeyword
            // 
            this.txbHPictureKeyword.Location = new System.Drawing.Point(137, 161);
            this.txbHPictureKeyword.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureKeyword.Name = "txbHPictureKeyword";
            this.txbHPictureKeyword.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureKeyword.TabIndex = 2;
            this.txbHPictureKeyword.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // txbHPictureCount
            // 
            this.txbHPictureCount.Location = new System.Drawing.Point(137, 68);
            this.txbHPictureCount.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureCount.Name = "txbHPictureCount";
            this.txbHPictureCount.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureCount.TabIndex = 2;
            this.txbHPictureCount.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // txbHPictureR18
            // 
            this.txbHPictureR18.Location = new System.Drawing.Point(137, 130);
            this.txbHPictureR18.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureR18.Name = "txbHPictureR18";
            this.txbHPictureR18.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureR18.TabIndex = 2;
            this.txbHPictureR18.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // txbHPictureUnit
            // 
            this.txbHPictureUnit.Location = new System.Drawing.Point(137, 99);
            this.txbHPictureUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureUnit.Name = "txbHPictureUnit";
            this.txbHPictureUnit.Size = new System.Drawing.Size(366, 23);
            this.txbHPictureUnit.TabIndex = 2;
            this.txbHPictureUnit.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // chkEnabledHPicture
            // 
            this.chkEnabledHPicture.AutoSize = true;
            this.chkEnabledHPicture.Location = new System.Drawing.Point(13, 12);
            this.chkEnabledHPicture.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnabledHPicture.Name = "chkEnabledHPicture";
            this.chkEnabledHPicture.Size = new System.Drawing.Size(99, 21);
            this.chkEnabledHPicture.TabIndex = 7;
            this.chkEnabledHPicture.Text = "启用色图功能";
            this.chkEnabledHPicture.UseVisualStyleBackColor = true;
            this.chkEnabledHPicture.CheckedChanged += new System.EventHandler(this.chkEnableHPicture_CheckedChanged);
            // 
            // tabRepeater
            // 
            this.tabRepeater.Controls.Add(this.chkReplaceMeToYou);
            this.tabRepeater.Controls.Add(this.chkRewindGif);
            this.tabRepeater.Controls.Add(this.lblRewindGifProbability);
            this.tabRepeater.Controls.Add(this.lblVerticalMirrorImageProbability);
            this.tabRepeater.Controls.Add(this.lblHorizontalMirrorImageProbability);
            this.tabRepeater.Controls.Add(this.lblSuccessiveRepeatCount);
            this.tabRepeater.Controls.Add(this.txbRewindGifProbability);
            this.tabRepeater.Controls.Add(this.lblRandomRepeatProbability);
            this.tabRepeater.Controls.Add(this.txbVerticalMirrorImageProbability);
            this.tabRepeater.Controls.Add(this.txbHorizontalMirrorImageProbability);
            this.tabRepeater.Controls.Add(this.txbSuccessiveRepeatCount);
            this.tabRepeater.Controls.Add(this.txbRandomRepeatProbability);
            this.tabRepeater.Controls.Add(this.chkVerticalMirrorImage);
            this.tabRepeater.Controls.Add(this.chkHorizontalMirrorImage);
            this.tabRepeater.Controls.Add(this.chkSuccessiveRepeat);
            this.tabRepeater.Controls.Add(this.chkRandomRepeat);
            this.tabRepeater.Location = new System.Drawing.Point(4, 26);
            this.tabRepeater.Name = "tabRepeater";
            this.tabRepeater.Size = new System.Drawing.Size(652, 687);
            this.tabRepeater.TabIndex = 5;
            this.tabRepeater.Text = "复读设置";
            this.tabRepeater.UseVisualStyleBackColor = true;
            // 
            // chkReplaceMeToYou
            // 
            this.chkReplaceMeToYou.AutoSize = true;
            this.chkReplaceMeToYou.Location = new System.Drawing.Point(21, 227);
            this.chkReplaceMeToYou.Name = "chkReplaceMeToYou";
            this.chkReplaceMeToYou.Size = new System.Drawing.Size(155, 21);
            this.chkReplaceMeToYou.TabIndex = 4;
            this.chkReplaceMeToYou.Text = "复读时把\"我\"替换为\"你\"";
            this.chkReplaceMeToYou.UseVisualStyleBackColor = true;
            // 
            // chkRewindGif
            // 
            this.chkRewindGif.AutoSize = true;
            this.chkRewindGif.Location = new System.Drawing.Point(21, 105);
            this.chkRewindGif.Name = "chkRewindGif";
            this.chkRewindGif.Size = new System.Drawing.Size(67, 21);
            this.chkRewindGif.TabIndex = 3;
            this.chkRewindGif.Text = "倒放Gif";
            this.chkRewindGif.UseVisualStyleBackColor = true;
            // 
            // lblRewindGifProbability
            // 
            this.lblRewindGifProbability.AutoSize = true;
            this.lblRewindGifProbability.Location = new System.Drawing.Point(202, 106);
            this.lblRewindGifProbability.Name = "lblRewindGifProbability";
            this.lblRewindGifProbability.Size = new System.Drawing.Size(56, 17);
            this.lblRewindGifProbability.TabIndex = 2;
            this.lblRewindGifProbability.Text = "概率为：";
            // 
            // lblVerticalMirrorImageProbability
            // 
            this.lblVerticalMirrorImageProbability.AutoSize = true;
            this.lblVerticalMirrorImageProbability.Location = new System.Drawing.Point(202, 188);
            this.lblVerticalMirrorImageProbability.Name = "lblVerticalMirrorImageProbability";
            this.lblVerticalMirrorImageProbability.Size = new System.Drawing.Size(56, 17);
            this.lblVerticalMirrorImageProbability.TabIndex = 2;
            this.lblVerticalMirrorImageProbability.Text = "概率为：";
            // 
            // lblHorizontalMirrorImageProbability
            // 
            this.lblHorizontalMirrorImageProbability.AutoSize = true;
            this.lblHorizontalMirrorImageProbability.Location = new System.Drawing.Point(202, 148);
            this.lblHorizontalMirrorImageProbability.Name = "lblHorizontalMirrorImageProbability";
            this.lblHorizontalMirrorImageProbability.Size = new System.Drawing.Size(56, 17);
            this.lblHorizontalMirrorImageProbability.TabIndex = 2;
            this.lblHorizontalMirrorImageProbability.Text = "概率为：";
            // 
            // lblSuccessiveRepeatCount
            // 
            this.lblSuccessiveRepeatCount.AutoSize = true;
            this.lblSuccessiveRepeatCount.Location = new System.Drawing.Point(202, 65);
            this.lblSuccessiveRepeatCount.Name = "lblSuccessiveRepeatCount";
            this.lblSuccessiveRepeatCount.Size = new System.Drawing.Size(56, 17);
            this.lblSuccessiveRepeatCount.TabIndex = 2;
            this.lblSuccessiveRepeatCount.Text = "次数为：";
            // 
            // txbRewindGifProbability
            // 
            this.txbRewindGifProbability.Location = new System.Drawing.Point(264, 103);
            this.txbRewindGifProbability.Name = "txbRewindGifProbability";
            this.txbRewindGifProbability.Size = new System.Drawing.Size(359, 23);
            this.txbRewindGifProbability.TabIndex = 1;
            this.txbRewindGifProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRewindGifProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // lblRandomRepeatProbability
            // 
            this.lblRandomRepeatProbability.AutoSize = true;
            this.lblRandomRepeatProbability.Location = new System.Drawing.Point(202, 24);
            this.lblRandomRepeatProbability.Name = "lblRandomRepeatProbability";
            this.lblRandomRepeatProbability.Size = new System.Drawing.Size(56, 17);
            this.lblRandomRepeatProbability.TabIndex = 2;
            this.lblRandomRepeatProbability.Text = "概率为：";
            // 
            // txbVerticalMirrorImageProbability
            // 
            this.txbVerticalMirrorImageProbability.Location = new System.Drawing.Point(264, 185);
            this.txbVerticalMirrorImageProbability.Name = "txbVerticalMirrorImageProbability";
            this.txbVerticalMirrorImageProbability.Size = new System.Drawing.Size(359, 23);
            this.txbVerticalMirrorImageProbability.TabIndex = 1;
            this.txbVerticalMirrorImageProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbVerticalMirrorImageProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHorizontalMirrorImageProbability
            // 
            this.txbHorizontalMirrorImageProbability.Location = new System.Drawing.Point(264, 145);
            this.txbHorizontalMirrorImageProbability.Name = "txbHorizontalMirrorImageProbability";
            this.txbHorizontalMirrorImageProbability.Size = new System.Drawing.Size(359, 23);
            this.txbHorizontalMirrorImageProbability.TabIndex = 1;
            this.txbHorizontalMirrorImageProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHorizontalMirrorImageProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbSuccessiveRepeatCount
            // 
            this.txbSuccessiveRepeatCount.Location = new System.Drawing.Point(264, 62);
            this.txbSuccessiveRepeatCount.Name = "txbSuccessiveRepeatCount";
            this.txbSuccessiveRepeatCount.Size = new System.Drawing.Size(359, 23);
            this.txbSuccessiveRepeatCount.TabIndex = 1;
            this.txbSuccessiveRepeatCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbSuccessiveRepeatCount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbRandomRepeatProbability
            // 
            this.txbRandomRepeatProbability.Location = new System.Drawing.Point(264, 21);
            this.txbRandomRepeatProbability.Name = "txbRandomRepeatProbability";
            this.txbRandomRepeatProbability.Size = new System.Drawing.Size(359, 23);
            this.txbRandomRepeatProbability.TabIndex = 1;
            this.txbRandomRepeatProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRandomRepeatProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // chkVerticalMirrorImage
            // 
            this.chkVerticalMirrorImage.AutoSize = true;
            this.chkVerticalMirrorImage.Location = new System.Drawing.Point(21, 187);
            this.chkVerticalMirrorImage.Name = "chkVerticalMirrorImage";
            this.chkVerticalMirrorImage.Size = new System.Drawing.Size(147, 21);
            this.chkVerticalMirrorImage.TabIndex = 0;
            this.chkVerticalMirrorImage.Text = "启用垂直镜像复读图片";
            this.chkVerticalMirrorImage.UseVisualStyleBackColor = true;
            // 
            // chkHorizontalMirrorImage
            // 
            this.chkHorizontalMirrorImage.AutoSize = true;
            this.chkHorizontalMirrorImage.Location = new System.Drawing.Point(21, 147);
            this.chkHorizontalMirrorImage.Name = "chkHorizontalMirrorImage";
            this.chkHorizontalMirrorImage.Size = new System.Drawing.Size(147, 21);
            this.chkHorizontalMirrorImage.TabIndex = 0;
            this.chkHorizontalMirrorImage.Text = "启用水平镜像复读图片";
            this.chkHorizontalMirrorImage.UseVisualStyleBackColor = true;
            // 
            // chkSuccessiveRepeat
            // 
            this.chkSuccessiveRepeat.AutoSize = true;
            this.chkSuccessiveRepeat.Location = new System.Drawing.Point(21, 64);
            this.chkSuccessiveRepeat.Name = "chkSuccessiveRepeat";
            this.chkSuccessiveRepeat.Size = new System.Drawing.Size(99, 21);
            this.chkSuccessiveRepeat.TabIndex = 0;
            this.chkSuccessiveRepeat.Text = "启用连续复读";
            this.chkSuccessiveRepeat.UseVisualStyleBackColor = true;
            // 
            // chkRandomRepeat
            // 
            this.chkRandomRepeat.AutoSize = true;
            this.chkRandomRepeat.Location = new System.Drawing.Point(21, 23);
            this.chkRandomRepeat.Name = "chkRandomRepeat";
            this.chkRandomRepeat.Size = new System.Drawing.Size(99, 21);
            this.chkRandomRepeat.TabIndex = 0;
            this.chkRandomRepeat.Text = "启用随机复读";
            this.chkRandomRepeat.UseVisualStyleBackColor = true;
            // 
            // tabGroupMemberEvents
            // 
            this.tabGroupMemberEvents.Controls.Add(this.txbMemberBeKickedMessage);
            this.tabGroupMemberEvents.Controls.Add(this.txbMemberPositiveLeaveMessage);
            this.tabGroupMemberEvents.Controls.Add(this.txbMemberJoinedMessage);
            this.tabGroupMemberEvents.Controls.Add(this.chkSendMemberBeKickedMessage);
            this.tabGroupMemberEvents.Controls.Add(this.chkSendMemberPositiveLeaveMessage);
            this.tabGroupMemberEvents.Controls.Add(this.chkSendMemberJoinedMessage);
            this.tabGroupMemberEvents.Location = new System.Drawing.Point(4, 26);
            this.tabGroupMemberEvents.Name = "tabGroupMemberEvents";
            this.tabGroupMemberEvents.Size = new System.Drawing.Size(652, 687);
            this.tabGroupMemberEvents.TabIndex = 6;
            this.tabGroupMemberEvents.Text = "进/退群提醒";
            this.tabGroupMemberEvents.UseVisualStyleBackColor = true;
            // 
            // txbMemberBeKickedMessage
            // 
            this.txbMemberBeKickedMessage.Location = new System.Drawing.Point(244, 110);
            this.txbMemberBeKickedMessage.Name = "txbMemberBeKickedMessage";
            this.txbMemberBeKickedMessage.Size = new System.Drawing.Size(379, 23);
            this.txbMemberBeKickedMessage.TabIndex = 3;
            // 
            // txbMemberPositiveLeaveMessage
            // 
            this.txbMemberPositiveLeaveMessage.Location = new System.Drawing.Point(244, 68);
            this.txbMemberPositiveLeaveMessage.Name = "txbMemberPositiveLeaveMessage";
            this.txbMemberPositiveLeaveMessage.Size = new System.Drawing.Size(379, 23);
            this.txbMemberPositiveLeaveMessage.TabIndex = 3;
            // 
            // txbMemberJoinedMessage
            // 
            this.txbMemberJoinedMessage.Location = new System.Drawing.Point(244, 26);
            this.txbMemberJoinedMessage.Name = "txbMemberJoinedMessage";
            this.txbMemberJoinedMessage.Size = new System.Drawing.Size(379, 23);
            this.txbMemberJoinedMessage.TabIndex = 3;
            // 
            // chkSendMemberBeKickedMessage
            // 
            this.chkSendMemberBeKickedMessage.AutoSize = true;
            this.chkSendMemberBeKickedMessage.Location = new System.Drawing.Point(27, 112);
            this.chkSendMemberBeKickedMessage.Name = "chkSendMemberBeKickedMessage";
            this.chkSendMemberBeKickedMessage.Size = new System.Drawing.Size(123, 21);
            this.chkSendMemberBeKickedMessage.TabIndex = 0;
            this.chkSendMemberBeKickedMessage.Text = "发送群员被踢消息";
            this.chkSendMemberBeKickedMessage.UseVisualStyleBackColor = true;
            // 
            // chkSendMemberPositiveLeaveMessage
            // 
            this.chkSendMemberPositiveLeaveMessage.AutoSize = true;
            this.chkSendMemberPositiveLeaveMessage.Location = new System.Drawing.Point(27, 70);
            this.chkSendMemberPositiveLeaveMessage.Name = "chkSendMemberPositiveLeaveMessage";
            this.chkSendMemberPositiveLeaveMessage.Size = new System.Drawing.Size(123, 21);
            this.chkSendMemberPositiveLeaveMessage.TabIndex = 0;
            this.chkSendMemberPositiveLeaveMessage.Text = "发送群员退群消息";
            this.chkSendMemberPositiveLeaveMessage.UseVisualStyleBackColor = true;
            // 
            // chkSendMemberJoinedMessage
            // 
            this.chkSendMemberJoinedMessage.AutoSize = true;
            this.chkSendMemberJoinedMessage.Location = new System.Drawing.Point(27, 28);
            this.chkSendMemberJoinedMessage.Name = "chkSendMemberJoinedMessage";
            this.chkSendMemberJoinedMessage.Size = new System.Drawing.Size(123, 21);
            this.chkSendMemberJoinedMessage.TabIndex = 0;
            this.chkSendMemberJoinedMessage.Text = "发送新人入群消息";
            this.chkSendMemberJoinedMessage.UseVisualStyleBackColor = true;
            // 
            // tabForgeMessage
            // 
            this.tabForgeMessage.Controls.Add(this.pnlForgeMessage);
            this.tabForgeMessage.Controls.Add(this.chkEnabledForgeMessage);
            this.tabForgeMessage.Location = new System.Drawing.Point(4, 26);
            this.tabForgeMessage.Name = "tabForgeMessage";
            this.tabForgeMessage.Size = new System.Drawing.Size(652, 687);
            this.tabForgeMessage.TabIndex = 7;
            this.tabForgeMessage.Text = "伪造消息";
            this.tabForgeMessage.UseVisualStyleBackColor = true;
            // 
            // pnlForgeMessage
            // 
            this.pnlForgeMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForgeMessage.Controls.Add(this.lblForgeMessageCmd);
            this.pnlForgeMessage.Controls.Add(this.txbForgeMessageCmd);
            this.pnlForgeMessage.Controls.Add(this.chkForgeMessageAdminDontAppend);
            this.pnlForgeMessage.Controls.Add(this.chkForgeMessageAdminOnly);
            this.pnlForgeMessage.Controls.Add(this.chkRefuseForgeBot);
            this.pnlForgeMessage.Controls.Add(this.chkRefuseForgeAdmin);
            this.pnlForgeMessage.Controls.Add(this.lblRefuseForgeBotReply);
            this.pnlForgeMessage.Controls.Add(this.chkForgeMessageAppendBotMessageEnabled);
            this.pnlForgeMessage.Controls.Add(this.lblRefuseForgeAdminReply);
            this.pnlForgeMessage.Controls.Add(this.txbRefuseForgeBotReply);
            this.pnlForgeMessage.Controls.Add(this.lblForgeMessageAppendSelfMessage);
            this.pnlForgeMessage.Controls.Add(this.txbRefuseForgeAdminReply);
            this.pnlForgeMessage.Controls.Add(this.txbForgeMessageAppendMessage);
            this.pnlForgeMessage.Controls.Add(this.lblForgeMessageCmdNewLine);
            this.pnlForgeMessage.Controls.Add(this.txbForgeMessageCmdNewLine);
            this.pnlForgeMessage.Controls.Add(this.lblForgeMessageCmdBegin);
            this.pnlForgeMessage.Controls.Add(this.txbForgeMessageCmdBegin);
            this.pnlForgeMessage.Enabled = false;
            this.pnlForgeMessage.Location = new System.Drawing.Point(3, 40);
            this.pnlForgeMessage.Name = "pnlForgeMessage";
            this.pnlForgeMessage.Size = new System.Drawing.Size(646, 644);
            this.pnlForgeMessage.TabIndex = 11;
            // 
            // lblForgeMessageCmd
            // 
            this.lblForgeMessageCmd.AutoSize = true;
            this.lblForgeMessageCmd.Location = new System.Drawing.Point(26, 248);
            this.lblForgeMessageCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForgeMessageCmd.Name = "lblForgeMessageCmd";
            this.lblForgeMessageCmd.Size = new System.Drawing.Size(59, 17);
            this.lblForgeMessageCmd.TabIndex = 13;
            this.lblForgeMessageCmd.Text = "完整命令:";
            // 
            // txbForgeMessageCmd
            // 
            this.txbForgeMessageCmd.BackColor = System.Drawing.SystemColors.Control;
            this.txbForgeMessageCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbForgeMessageCmd.Location = new System.Drawing.Point(93, 246);
            this.txbForgeMessageCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txbForgeMessageCmd.Name = "txbForgeMessageCmd";
            this.txbForgeMessageCmd.ReadOnly = true;
            this.txbForgeMessageCmd.Size = new System.Drawing.Size(517, 23);
            this.txbForgeMessageCmd.TabIndex = 14;
            // 
            // chkForgeMessageAdminDontAppend
            // 
            this.chkForgeMessageAdminDontAppend.AutoSize = true;
            this.chkForgeMessageAdminDontAppend.Location = new System.Drawing.Point(360, 69);
            this.chkForgeMessageAdminDontAppend.Margin = new System.Windows.Forms.Padding(4);
            this.chkForgeMessageAdminDontAppend.Name = "chkForgeMessageAdminDontAppend";
            this.chkForgeMessageAdminDontAppend.Size = new System.Drawing.Size(195, 21);
            this.chkForgeMessageAdminDontAppend.TabIndex = 12;
            this.chkForgeMessageAdminDontAppend.Text = "机器人管理员使用时不追加消息";
            this.chkForgeMessageAdminDontAppend.UseVisualStyleBackColor = true;
            // 
            // chkForgeMessageAdminOnly
            // 
            this.chkForgeMessageAdminOnly.AutoSize = true;
            this.chkForgeMessageAdminOnly.Location = new System.Drawing.Point(205, 69);
            this.chkForgeMessageAdminOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkForgeMessageAdminOnly.Name = "chkForgeMessageAdminOnly";
            this.chkForgeMessageAdminOnly.Size = new System.Drawing.Size(147, 21);
            this.chkForgeMessageAdminOnly.TabIndex = 12;
            this.chkForgeMessageAdminOnly.Text = "仅限机器人管理员可用";
            this.chkForgeMessageAdminOnly.UseVisualStyleBackColor = true;
            // 
            // chkRefuseForgeBot
            // 
            this.chkRefuseForgeBot.AutoSize = true;
            this.chkRefuseForgeBot.Location = new System.Drawing.Point(26, 188);
            this.chkRefuseForgeBot.Margin = new System.Windows.Forms.Padding(4);
            this.chkRefuseForgeBot.Name = "chkRefuseForgeBot";
            this.chkRefuseForgeBot.Size = new System.Drawing.Size(147, 21);
            this.chkRefuseForgeBot.TabIndex = 12;
            this.chkRefuseForgeBot.Text = "拒绝伪造机器人的消息";
            this.chkRefuseForgeBot.UseVisualStyleBackColor = true;
            // 
            // chkRefuseForgeAdmin
            // 
            this.chkRefuseForgeAdmin.AutoSize = true;
            this.chkRefuseForgeAdmin.Location = new System.Drawing.Point(26, 127);
            this.chkRefuseForgeAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.chkRefuseForgeAdmin.Name = "chkRefuseForgeAdmin";
            this.chkRefuseForgeAdmin.Size = new System.Drawing.Size(183, 21);
            this.chkRefuseForgeAdmin.TabIndex = 12;
            this.chkRefuseForgeAdmin.Text = "拒绝伪造机器人管理员的消息";
            this.chkRefuseForgeAdmin.UseVisualStyleBackColor = true;
            // 
            // lblRefuseForgeBotReply
            // 
            this.lblRefuseForgeBotReply.AutoSize = true;
            this.lblRefuseForgeBotReply.Location = new System.Drawing.Point(26, 219);
            this.lblRefuseForgeBotReply.Name = "lblRefuseForgeBotReply";
            this.lblRefuseForgeBotReply.Size = new System.Drawing.Size(179, 17);
            this.lblRefuseForgeBotReply.TabIndex = 11;
            this.lblRefuseForgeBotReply.Text = "试图伪造机器人消息时的回复语:";
            // 
            // chkForgeMessageAppendBotMessageEnabled
            // 
            this.chkForgeMessageAppendBotMessageEnabled.AutoSize = true;
            this.chkForgeMessageAppendBotMessageEnabled.Location = new System.Drawing.Point(26, 69);
            this.chkForgeMessageAppendBotMessageEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.chkForgeMessageAppendBotMessageEnabled.Name = "chkForgeMessageAppendBotMessageEnabled";
            this.chkForgeMessageAppendBotMessageEnabled.Size = new System.Drawing.Size(171, 21);
            this.chkForgeMessageAppendBotMessageEnabled.TabIndex = 12;
            this.chkForgeMessageAppendBotMessageEnabled.Text = "在消息末尾追加机器人消息";
            this.chkForgeMessageAppendBotMessageEnabled.UseVisualStyleBackColor = true;
            // 
            // lblRefuseForgeAdminReply
            // 
            this.lblRefuseForgeAdminReply.AutoSize = true;
            this.lblRefuseForgeAdminReply.Location = new System.Drawing.Point(26, 158);
            this.lblRefuseForgeAdminReply.Name = "lblRefuseForgeAdminReply";
            this.lblRefuseForgeAdminReply.Size = new System.Drawing.Size(215, 17);
            this.lblRefuseForgeAdminReply.TabIndex = 11;
            this.lblRefuseForgeAdminReply.Text = "试图伪造机器人管理员消息时的回复语:";
            // 
            // txbRefuseForgeBotReply
            // 
            this.txbRefuseForgeBotReply.Location = new System.Drawing.Point(247, 216);
            this.txbRefuseForgeBotReply.Name = "txbRefuseForgeBotReply";
            this.txbRefuseForgeBotReply.Size = new System.Drawing.Size(363, 23);
            this.txbRefuseForgeBotReply.TabIndex = 12;
            // 
            // lblForgeMessageAppendSelfMessage
            // 
            this.lblForgeMessageAppendSelfMessage.AutoSize = true;
            this.lblForgeMessageAppendSelfMessage.Location = new System.Drawing.Point(26, 100);
            this.lblForgeMessageAppendSelfMessage.Name = "lblForgeMessageAppendSelfMessage";
            this.lblForgeMessageAppendSelfMessage.Size = new System.Drawing.Size(83, 17);
            this.lblForgeMessageAppendSelfMessage.TabIndex = 11;
            this.lblForgeMessageAppendSelfMessage.Text = "追加消息内容:";
            // 
            // txbRefuseForgeAdminReply
            // 
            this.txbRefuseForgeAdminReply.Location = new System.Drawing.Point(247, 155);
            this.txbRefuseForgeAdminReply.Name = "txbRefuseForgeAdminReply";
            this.txbRefuseForgeAdminReply.Size = new System.Drawing.Size(363, 23);
            this.txbRefuseForgeAdminReply.TabIndex = 12;
            // 
            // txbForgeMessageAppendMessage
            // 
            this.txbForgeMessageAppendMessage.Location = new System.Drawing.Point(151, 97);
            this.txbForgeMessageAppendMessage.Name = "txbForgeMessageAppendMessage";
            this.txbForgeMessageAppendMessage.Size = new System.Drawing.Size(459, 23);
            this.txbForgeMessageAppendMessage.TabIndex = 12;
            // 
            // lblForgeMessageCmdNewLine
            // 
            this.lblForgeMessageCmdNewLine.AutoSize = true;
            this.lblForgeMessageCmdNewLine.Location = new System.Drawing.Point(26, 42);
            this.lblForgeMessageCmdNewLine.Name = "lblForgeMessageCmdNewLine";
            this.lblForgeMessageCmdNewLine.Size = new System.Drawing.Size(95, 17);
            this.lblForgeMessageCmdNewLine.TabIndex = 11;
            this.lblForgeMessageCmdNewLine.Text = "伪造消息分行符:";
            // 
            // txbForgeMessageCmdNewLine
            // 
            this.txbForgeMessageCmdNewLine.Location = new System.Drawing.Point(151, 39);
            this.txbForgeMessageCmdNewLine.Name = "txbForgeMessageCmdNewLine";
            this.txbForgeMessageCmdNewLine.Size = new System.Drawing.Size(459, 23);
            this.txbForgeMessageCmdNewLine.TabIndex = 12;
            // 
            // lblForgeMessageCmdBegin
            // 
            this.lblForgeMessageCmdBegin.AutoSize = true;
            this.lblForgeMessageCmdBegin.Location = new System.Drawing.Point(26, 13);
            this.lblForgeMessageCmdBegin.Name = "lblForgeMessageCmdBegin";
            this.lblForgeMessageCmdBegin.Size = new System.Drawing.Size(107, 17);
            this.lblForgeMessageCmdBegin.TabIndex = 9;
            this.lblForgeMessageCmdBegin.Text = "伪造消息命令前缀:";
            // 
            // txbForgeMessageCmdBegin
            // 
            this.txbForgeMessageCmdBegin.Location = new System.Drawing.Point(151, 10);
            this.txbForgeMessageCmdBegin.Name = "txbForgeMessageCmdBegin";
            this.txbForgeMessageCmdBegin.Size = new System.Drawing.Size(459, 23);
            this.txbForgeMessageCmdBegin.TabIndex = 10;
            this.txbForgeMessageCmdBegin.TextChanged += new System.EventHandler(this.txbHPictureEnd_TextChanged);
            // 
            // chkEnabledForgeMessage
            // 
            this.chkEnabledForgeMessage.AutoSize = true;
            this.chkEnabledForgeMessage.Location = new System.Drawing.Point(13, 12);
            this.chkEnabledForgeMessage.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnabledForgeMessage.Name = "chkEnabledForgeMessage";
            this.chkEnabledForgeMessage.Size = new System.Drawing.Size(123, 21);
            this.chkEnabledForgeMessage.TabIndex = 8;
            this.chkEnabledForgeMessage.Text = "启用伪造消息功能";
            this.chkEnabledForgeMessage.UseVisualStyleBackColor = true;
            this.chkEnabledForgeMessage.CheckedChanged += new System.EventHandler(this.chkEnabledForgeMessage_CheckedChanged);
            // 
            // tabRss
            // 
            this.tabRss.Controls.Add(this.pnlRss);
            this.tabRss.Controls.Add(this.chkRssEnabled);
            this.tabRss.Location = new System.Drawing.Point(4, 26);
            this.tabRss.Name = "tabRss";
            this.tabRss.Size = new System.Drawing.Size(652, 687);
            this.tabRss.TabIndex = 8;
            this.tabRss.Text = "RSS转发";
            this.tabRss.UseVisualStyleBackColor = true;
            // 
            // pnlRss
            // 
            this.pnlRss.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRss.Controls.Add(this.pnlRssSubscriptionList);
            this.pnlRss.Controls.Add(this.txbReadRssInterval);
            this.pnlRss.Controls.Add(this.lblReadRssInterval);
            this.pnlRss.Enabled = false;
            this.pnlRss.Location = new System.Drawing.Point(3, 40);
            this.pnlRss.Name = "pnlRss";
            this.pnlRss.Size = new System.Drawing.Size(646, 644);
            this.pnlRss.TabIndex = 1;
            // 
            // pnlRssSubscriptionList
            // 
            this.pnlRssSubscriptionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRssSubscriptionList.AutoScroll = true;
            this.pnlRssSubscriptionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRssSubscriptionList.Controls.Add(this.btnAddRssSubscription);
            this.pnlRssSubscriptionList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlRssSubscriptionList.Location = new System.Drawing.Point(23, 32);
            this.pnlRssSubscriptionList.Name = "pnlRssSubscriptionList";
            this.pnlRssSubscriptionList.Size = new System.Drawing.Size(600, 609);
            this.pnlRssSubscriptionList.TabIndex = 2;
            this.pnlRssSubscriptionList.WrapContents = false;
            this.pnlRssSubscriptionList.SizeChanged += new System.EventHandler(this.pnlRssSubscriptionList_SizeChanged);
            this.pnlRssSubscriptionList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.PnlRssSubscriptionList_ControlChanged);
            this.pnlRssSubscriptionList.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.PnlRssSubscriptionList_ControlChanged);
            // 
            // btnAddRssSubscription
            // 
            this.btnAddRssSubscription.Image = global::GreenOnions.BotManagerWindow.Properties.Resources.add;
            this.btnAddRssSubscription.Location = new System.Drawing.Point(3, 3);
            this.btnAddRssSubscription.Name = "btnAddRssSubscription";
            this.btnAddRssSubscription.Size = new System.Drawing.Size(592, 150);
            this.btnAddRssSubscription.TabIndex = 0;
            this.btnAddRssSubscription.UseVisualStyleBackColor = true;
            this.btnAddRssSubscription.Click += new System.EventHandler(this.btnAddRssSubscription_Click);
            // 
            // txbReadRssInterval
            // 
            this.txbReadRssInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbReadRssInterval.Location = new System.Drawing.Point(169, 3);
            this.txbReadRssInterval.Name = "txbReadRssInterval";
            this.txbReadRssInterval.Size = new System.Drawing.Size(454, 23);
            this.txbReadRssInterval.TabIndex = 1;
            // 
            // lblReadRssInterval
            // 
            this.lblReadRssInterval.AutoSize = true;
            this.lblReadRssInterval.Location = new System.Drawing.Point(24, 6);
            this.lblReadRssInterval.Name = "lblReadRssInterval";
            this.lblReadRssInterval.Size = new System.Drawing.Size(139, 17);
            this.lblReadRssInterval.TabIndex = 0;
            this.lblReadRssInterval.Text = "获取内容时间间隔(分钟):";
            // 
            // chkRssEnabled
            // 
            this.chkRssEnabled.AutoSize = true;
            this.chkRssEnabled.Location = new System.Drawing.Point(13, 12);
            this.chkRssEnabled.Name = "chkRssEnabled";
            this.chkRssEnabled.Size = new System.Drawing.Size(121, 21);
            this.chkRssEnabled.TabIndex = 0;
            this.chkRssEnabled.Text = "启用RSS订阅转发";
            this.chkRssEnabled.UseVisualStyleBackColor = true;
            this.chkRssEnabled.CheckedChanged += new System.EventHandler(this.chkRssEnabled_CheckedChanged);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.txbContributorName);
            this.tabAbout.Controls.Add(this.txbContributorQQ);
            this.tabAbout.Controls.Add(this.lnkProjectURL);
            this.tabAbout.Controls.Add(this.lnkContributorGithub);
            this.tabAbout.Controls.Add(this.lblProjectURL);
            this.tabAbout.Controls.Add(this.lblContributorGithub);
            this.tabAbout.Controls.Add(this.lblContributorQQ);
            this.tabAbout.Controls.Add(this.lblContributorName);
            this.tabAbout.Location = new System.Drawing.Point(4, 26);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(4);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(652, 687);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "关于";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // txbContributorName
            // 
            this.txbContributorName.BackColor = System.Drawing.Color.White;
            this.txbContributorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbContributorName.Location = new System.Drawing.Point(116, 41);
            this.txbContributorName.Name = "txbContributorName";
            this.txbContributorName.ReadOnly = true;
            this.txbContributorName.Size = new System.Drawing.Size(100, 16);
            this.txbContributorName.TabIndex = 2;
            this.txbContributorName.Text = "Alex1911";
            // 
            // txbContributorQQ
            // 
            this.txbContributorQQ.BackColor = System.Drawing.Color.White;
            this.txbContributorQQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbContributorQQ.Location = new System.Drawing.Point(116, 74);
            this.txbContributorQQ.Name = "txbContributorQQ";
            this.txbContributorQQ.ReadOnly = true;
            this.txbContributorQQ.Size = new System.Drawing.Size(100, 16);
            this.txbContributorQQ.TabIndex = 2;
            this.txbContributorQQ.Text = "774345562";
            // 
            // lnkProjectURL
            // 
            this.lnkProjectURL.AutoSize = true;
            this.lnkProjectURL.Location = new System.Drawing.Point(116, 141);
            this.lnkProjectURL.Name = "lnkProjectURL";
            this.lnkProjectURL.Size = new System.Drawing.Size(288, 17);
            this.lnkProjectURL.TabIndex = 1;
            this.lnkProjectURL.TabStop = true;
            this.lnkProjectURL.Text = "https://github.com/Alex1911-Jiang/GreenOnions";
            this.lnkProjectURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContributorGithub_LinkClicked);
            // 
            // lnkContributorGithub
            // 
            this.lnkContributorGithub.AutoSize = true;
            this.lnkContributorGithub.Location = new System.Drawing.Point(116, 107);
            this.lnkContributorGithub.Name = "lnkContributorGithub";
            this.lnkContributorGithub.Size = new System.Drawing.Size(207, 17);
            this.lnkContributorGithub.TabIndex = 1;
            this.lnkContributorGithub.TabStop = true;
            this.lnkContributorGithub.Text = "https://github.com/Alex1911-Jiang";
            this.lnkContributorGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContributorGithub_LinkClicked);
            // 
            // lblProjectURL
            // 
            this.lblProjectURL.AutoSize = true;
            this.lblProjectURL.Location = new System.Drawing.Point(36, 142);
            this.lblProjectURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectURL.Name = "lblProjectURL";
            this.lblProjectURL.Size = new System.Drawing.Size(59, 17);
            this.lblProjectURL.TabIndex = 0;
            this.lblProjectURL.Text = "项目地址:";
            // 
            // lblContributorGithub
            // 
            this.lblContributorGithub.AutoSize = true;
            this.lblContributorGithub.Location = new System.Drawing.Point(36, 108);
            this.lblContributorGithub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContributorGithub.Name = "lblContributorGithub";
            this.lblContributorGithub.Size = new System.Drawing.Size(73, 17);
            this.lblContributorGithub.TabIndex = 0;
            this.lblContributorGithub.Text = "Github主页:";
            // 
            // lblContributorQQ
            // 
            this.lblContributorQQ.AutoSize = true;
            this.lblContributorQQ.Location = new System.Drawing.Point(36, 74);
            this.lblContributorQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContributorQQ.Name = "lblContributorQQ";
            this.lblContributorQQ.Size = new System.Drawing.Size(31, 17);
            this.lblContributorQQ.TabIndex = 0;
            this.lblContributorQQ.Text = "QQ:";
            // 
            // lblContributorName
            // 
            this.lblContributorName.AutoSize = true;
            this.lblContributorName.Location = new System.Drawing.Point(36, 40);
            this.lblContributorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContributorName.Name = "lblContributorName";
            this.lblContributorName.Size = new System.Drawing.Size(35, 17);
            this.lblContributorName.TabIndex = 0;
            this.lblContributorName.Text = "作者:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "(一行一个太长塞不下UI)";
            // 
            // FrmAppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 761);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOk);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用设置";
            this.tabControl1.ResumeLayout(false);
            this.tabBot.ResumeLayout(false);
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            this.pnlDebugMode.ResumeLayout(false);
            this.pnlDebugMode.PerformLayout();
            this.pnlCheckPorn.ResumeLayout(false);
            this.pnlCheckPorn.PerformLayout();
            this.tabSearchPicture.ResumeLayout(false);
            this.tabSearchPicture.PerformLayout();
            this.pnlSearchPicture.ResumeLayout(false);
            this.pnlSearchPicture.PerformLayout();
            this.pnlNoCheckPorn.ResumeLayout(false);
            this.pnlNoCheckPorn.PerformLayout();
            this.pnlPictureSearcherCheckPorn.ResumeLayout(false);
            this.pnlPictureSearcherCheckPorn.PerformLayout();
            this.tabOriginPicture.ResumeLayout(false);
            this.tabOriginPicture.PerformLayout();
            this.pnlOriginPicture.ResumeLayout(false);
            this.pnlOriginPicture.PerformLayout();
            this.pnlOriginPictureCheckPorn.ResumeLayout(false);
            this.pnlOriginPictureCheckPorn.PerformLayout();
            this.pnlOriginPictureCheckPornMessage.ResumeLayout(false);
            this.pnlOriginPictureCheckPornMessage.PerformLayout();
            this.pnlOriginPictureCheckPornEvent.ResumeLayout(false);
            this.pnlOriginPictureCheckPornEvent.PerformLayout();
            this.tabTranslate.ResumeLayout(false);
            this.tabTranslate.PerformLayout();
            this.pnlTranslate.ResumeLayout(false);
            this.pnlTranslate.PerformLayout();
            this.tabHPicture.ResumeLayout(false);
            this.tabHPicture.PerformLayout();
            this.pnlEnabelHPicture.ResumeLayout(false);
            this.pnlEnabelHPicture.PerformLayout();
            this.tabRepeater.ResumeLayout(false);
            this.tabRepeater.PerformLayout();
            this.tabGroupMemberEvents.ResumeLayout(false);
            this.tabGroupMemberEvents.PerformLayout();
            this.tabForgeMessage.ResumeLayout(false);
            this.tabForgeMessage.PerformLayout();
            this.pnlForgeMessage.ResumeLayout(false);
            this.pnlForgeMessage.PerformLayout();
            this.tabRss.ResumeLayout(false);
            this.tabRss.PerformLayout();
            this.pnlRss.ResumeLayout(false);
            this.pnlRss.PerformLayout();
            this.pnlRssSubscriptionList.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbBotName;
        private System.Windows.Forms.Label lblBotName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txbAddAdmin;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBot;
        private System.Windows.Forms.TabPage tabHPicture;
        private System.Windows.Forms.ListView lstAdmins;
        private System.Windows.Forms.Button btnAddAdmin;
        private System.Windows.Forms.Label lblAddAdmin;
        private System.Windows.Forms.Label lblLoliconHPictureCmd;
        private System.Windows.Forms.TextBox txbHPictureCmd;
        private System.Windows.Forms.TextBox txbHPictureBegin;
        private System.Windows.Forms.Label lblHPictureBegin;
        private System.Windows.Forms.TextBox txbHPictureR18;
        private System.Windows.Forms.TextBox txbHPictureUnit;
        private System.Windows.Forms.TextBox txbHPictureCount;
        private System.Windows.Forms.Label lblHPictureUnit;
        private System.Windows.Forms.Label lblHPictureCount;
        private System.Windows.Forms.CheckBox chkHPictureR18Null;
        private System.Windows.Forms.CheckBox chkHPictureUnitNull;
        private System.Windows.Forms.CheckBox chkHPictureCountNull;
        private System.Windows.Forms.CheckBox chkHPictureBeginNull;
        private System.Windows.Forms.Label lblHPictureR18;
        private System.Windows.Forms.TextBox txbHPictureKeyword;
        private System.Windows.Forms.CheckBox chkHPictureKeywordNull;
        private System.Windows.Forms.TextBox txbHPictureEnd;
        private System.Windows.Forms.LinkLabel lnkResetHPicture;
        private System.Windows.Forms.Label lblHPictureEnd;
        private System.Windows.Forms.Label lblHPictureKeyword;
        private System.Windows.Forms.Button btnAddUserHPictureCmd;
        private System.Windows.Forms.CheckBox chkHPictureEndNull;
        private System.Windows.Forms.TextBox txbUserHPictureCmd;
        private System.Windows.Forms.Label lblUserHPictureCmd;
        private System.Windows.Forms.Label lblUserCmd;
        private System.Windows.Forms.CheckBox chkEnabledHPicture;
        private System.Windows.Forms.Panel pnlEnabelHPicture;
        private System.Windows.Forms.Label lblRevoke;
        private System.Windows.Forms.Label lblWhiteGroup;
        private System.Windows.Forms.TextBox txbAddToWhiteGroup;
        private System.Windows.Forms.TextBox txbRevoke;
        private System.Windows.Forms.CheckBox chkWhiteOnly;
        private System.Windows.Forms.CheckBox chkSize1200;
        private System.Windows.Forms.CheckBox chkPM;
        private System.Windows.Forms.CheckBox chkAntiShielding;
        private System.Windows.Forms.ListView lstHPictureWhiteGroup;
        private System.Windows.Forms.Label lblAddToWhiteGroupInformation;
        private System.Windows.Forms.Button btnAddToWhiteGroup;
        private System.Windows.Forms.CheckBox chkR18WhiteOnly;
        private System.Windows.Forms.Label lblWhiteRevoke;
        private System.Windows.Forms.Label lblCD;
        private System.Windows.Forms.TextBox txbWhiteRevoke;
        private System.Windows.Forms.TextBox txbCD;
        private System.Windows.Forms.TextBox txbWhiteCD;
        private System.Windows.Forms.Label lblWhiteCD;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.TextBox txbLimit;
        private System.Windows.Forms.ListView lstHPictureUserCmd;
        private System.Windows.Forms.Label lblErrorReply;
        private System.Windows.Forms.Label lblOutOfLimitReply;
        private System.Windows.Forms.Label lblCDUnreadyReply;
        private System.Windows.Forms.TextBox txbHPictureErrorReplyReply;
        private System.Windows.Forms.TextBox txbOutOfLimitReply;
        private System.Windows.Forms.TextBox txbCDUnreadyReply;
        private System.Windows.Forms.Label lblUserCmdInformation;
        private System.Windows.Forms.Label lblDownloadAccelerate;
        private System.Windows.Forms.TextBox txbDownloadAccelerateUrl;
        private System.Windows.Forms.CheckBox chkDownloadAccelerate;
        private System.Windows.Forms.CheckBox chkAllowR18;
        private System.Windows.Forms.TextBox txbPMCD;
        private System.Windows.Forms.TextBox txbPMRevoke;
        private System.Windows.Forms.Label lblPMRevoke;
        private System.Windows.Forms.Label lblPMCD;
        private System.Windows.Forms.CheckBox chkManageNoLimit;
        private System.Windows.Forms.CheckBox chkAdminNoLimit;
        private System.Windows.Forms.CheckBox chkPMNoLimit;
        private System.Windows.Forms.Button btnRemoveAdmin;
        private System.Windows.Forms.Button btnRemoveWhiteGroup;
        private System.Windows.Forms.Button btnRemoveUserHPictureCmd;
        private System.Windows.Forms.Label lblNoResult;
        private System.Windows.Forms.TextBox txbHPictureNoResultReply;
        private System.Windows.Forms.RadioButton rodHPictureLimitCount;
        private System.Windows.Forms.RadioButton rdoHPictureLimitFrequency;
        private System.Windows.Forms.Label lblLimitType;
        private System.Windows.Forms.CheckBox chkWhiteNoLimit;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label lblContributorQQ;
        private System.Windows.Forms.Label lblContributorName;
        private System.Windows.Forms.TextBox txbBanUser;
        private System.Windows.Forms.TextBox txbBanGroup;
        private System.Windows.Forms.Button btnRemoveBanUser;
        private System.Windows.Forms.Button btnRemoveBanGroup;
        private System.Windows.Forms.Button btnAddBanUser;
        private System.Windows.Forms.Button btnAddBanGroup;
        private System.Windows.Forms.ListView lstBannedUser;
        private System.Windows.Forms.Label lblBanUser;
        private System.Windows.Forms.ListView lstBannedGroup;
        private System.Windows.Forms.Label lblBanGroup;
        private System.Windows.Forms.Label lblBannedUser;
        private System.Windows.Forms.Label lblBannedGroup;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txbHPictureApiKey;
        private System.Windows.Forms.CheckBox chkImageCache;
        private System.Windows.Forms.Label lblImageCache;
        private System.Windows.Forms.Label lblDownloadFail;
        private System.Windows.Forms.TextBox txbDownloadFailReply;
        private System.Windows.Forms.TabPage tabSearchPicture;
        private System.Windows.Forms.Panel pnlSearchPicture;
        private System.Windows.Forms.CheckBox chkSearchPictureEnabled;
        private System.Windows.Forms.CheckBox chkSearchASCII2DEnabled;
        private System.Windows.Forms.CheckBox chkSearchSauceNAOEnabled;
        private System.Windows.Forms.TextBox txbSearchLowSimilarityReply;
        private System.Windows.Forms.TextBox txbSearchErrorReply;
        private System.Windows.Forms.TextBox txbSearchNoResultReply;
        private System.Windows.Forms.TextBox txbSearchModeOffReply;
        private System.Windows.Forms.TextBox txbSearchModeAlreadyOnReply;
        private System.Windows.Forms.TextBox txbSearchModeOnReply;
        private System.Windows.Forms.TextBox txbSearchModeOnCmd;
        private System.Windows.Forms.TextBox txbSearchModeAlreadyOffReply;
        private System.Windows.Forms.TextBox txbSearchLowSimilarity;
        private System.Windows.Forms.Label lblSearchLowSimilarityReply;
        private System.Windows.Forms.Label lblSearchLowSimilarity;
        private System.Windows.Forms.Label lblSearchErrorReply;
        private System.Windows.Forms.Label lblSearchNoResultReply;
        private System.Windows.Forms.Label lblSearchModeAlreadyOffReply;
        private System.Windows.Forms.Label lblSearchModeOffReply;
        private System.Windows.Forms.Label lblSearchModeAlreadyOnReply;
        private System.Windows.Forms.Label lblSearchModeOnReply;
        private System.Windows.Forms.Label lblSearchModeOnCmd;
        private System.Windows.Forms.TextBox txbSearchModeTimeOutReply;
        private System.Windows.Forms.TextBox txbSearchModeOffCmd;
        private System.Windows.Forms.Label lblSearchModeTimeOutReply;
        private System.Windows.Forms.Label lblSearchModeOffCmd;
        private System.Windows.Forms.TextBox txbSauceNAOApiKey;
        private System.Windows.Forms.Label lblSauceNAOApiKey;
        private System.Windows.Forms.TabPage tabTranslate;
        private System.Windows.Forms.Panel pnlTranslate;
        private System.Windows.Forms.TextBox txbTranslateTo;
        private System.Windows.Forms.TextBox txbTranslateToChinese;
        private System.Windows.Forms.Label lblTranslateTo;
        private System.Windows.Forms.Label lblTranslateToChinese;
        private System.Windows.Forms.CheckBox chkTranslateEnabled;
        private System.Windows.Forms.Label lblContributorGithub;
        private System.Windows.Forms.TextBox txbContributorQQ;
        private System.Windows.Forms.LinkLabel lnkContributorGithub;
        private System.Windows.Forms.TextBox txbContributorName;
        private System.Windows.Forms.Label lblMultithreading;
        private System.Windows.Forms.CheckBox chkMultithreading;
        private System.Windows.Forms.LinkLabel lnkProjectURL;
        private System.Windows.Forms.Label lblProjectURL;
        private System.Windows.Forms.Label lblBeautyPictureCmd;
        private System.Windows.Forms.CheckBox chkBeautyPictureEndNull;
        private System.Windows.Forms.Label lblShabHPictureEnd;
        private System.Windows.Forms.TextBox txbBeautyPictureCmd;
        private System.Windows.Forms.TextBox txbBeautyPictureEnd;
        private System.Windows.Forms.CheckBox chkEnabledLoliconHPicture;
        private System.Windows.Forms.CheckBox chkRevokeBeautyPicture;
        private System.Windows.Forms.Panel pnlDebugMode;
        private System.Windows.Forms.ListView lstDebugGroups;
        private System.Windows.Forms.CheckBox chkDebugReplyAdminOnly;
        private System.Windows.Forms.Label lblAddDebugGroup;
        private System.Windows.Forms.Label lblDebugGroup;
        private System.Windows.Forms.Button btnAddDebugGroup;
        private System.Windows.Forms.Button btnRemoveDebugGroup;
        private System.Windows.Forms.TextBox txbAddDebugGroup;
        private System.Windows.Forms.CheckBox chkDebugMode;
        private System.Windows.Forms.CheckBox chkOnlyReplyDebugGroup;
        private System.Windows.Forms.CheckBox chkTraceMoeEnabled;
        private System.Windows.Forms.Label lblTraceMoeSendThreshold;
        private System.Windows.Forms.TextBox txbTraceMoeSendThreshold;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabRepeater;
        private System.Windows.Forms.Label lblVerticalMirrorImageProbability;
        private System.Windows.Forms.Label lblHorizontalMirrorImageProbability;
        private System.Windows.Forms.Label lblSuccessiveRepeatCount;
        private System.Windows.Forms.Label lblRandomRepeatProbability;
        private System.Windows.Forms.TextBox txbHorizontalMirrorImageProbability;
        private System.Windows.Forms.TextBox txbSuccessiveRepeatCount;
        private System.Windows.Forms.TextBox txbRandomRepeatProbability;
        private System.Windows.Forms.CheckBox chkVerticalMirrorImage;
        private System.Windows.Forms.CheckBox chkHorizontalMirrorImage;
        private System.Windows.Forms.CheckBox chkSuccessiveRepeat;
        private System.Windows.Forms.CheckBox chkRandomRepeat;
        private System.Windows.Forms.TextBox txbVerticalMirrorImageProbability;
        private System.Windows.Forms.CheckBox chkRewindGif;
        private System.Windows.Forms.Label lblRewindGifProbability;
        private System.Windows.Forms.TextBox txbRewindGifProbability;
        private System.Windows.Forms.TabPage tabGroupMemberEvents;
        private System.Windows.Forms.TextBox txbMemberJoinedMessage;
        private System.Windows.Forms.CheckBox chkSendMemberBeKickedMessage;
        private System.Windows.Forms.CheckBox chkSendMemberPositiveLeaveMessage;
        private System.Windows.Forms.CheckBox chkSendMemberJoinedMessage;
        private System.Windows.Forms.TextBox txbMemberBeKickedMessage;
        private System.Windows.Forms.TextBox txbMemberPositiveLeaveMessage;
        private System.Windows.Forms.Label lblBeautyPictureSource;
        private System.Windows.Forms.Label lblHPictureSource;
        private System.Windows.Forms.CheckBox chkEnabledGreenOnionsBeautyPicture;
        private System.Windows.Forms.CheckBox chkEnabledGreenOnionsHPicture;
        private System.Windows.Forms.CheckBox chkEnabledELFBeautyPicture;
        private System.Windows.Forms.TextBox txbAddAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.Button btnRemoveAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.Button btnAddAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.ListView lstAutoTranslateGroupMemoriesQQ;
        private System.Windows.Forms.Label lblAddAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.Label lblAutoTranslateGroupMemoriesQQ;
        private System.Windows.Forms.TabPage tabForgeMessage;
        private System.Windows.Forms.Panel pnlForgeMessage;
        private System.Windows.Forms.CheckBox chkForgeMessageAdminDontAppend;
        private System.Windows.Forms.CheckBox chkForgeMessageAdminOnly;
        private System.Windows.Forms.CheckBox chkRefuseForgeBot;
        private System.Windows.Forms.CheckBox chkRefuseForgeAdmin;
        private System.Windows.Forms.Label lblRefuseForgeBotReply;
        private System.Windows.Forms.CheckBox chkForgeMessageAppendBotMessageEnabled;
        private System.Windows.Forms.Label lblRefuseForgeAdminReply;
        private System.Windows.Forms.TextBox txbRefuseForgeBotReply;
        private System.Windows.Forms.Label lblForgeMessageAppendSelfMessage;
        private System.Windows.Forms.TextBox txbRefuseForgeAdminReply;
        private System.Windows.Forms.TextBox txbForgeMessageAppendMessage;
        private System.Windows.Forms.Label lblForgeMessageCmdNewLine;
        private System.Windows.Forms.TextBox txbForgeMessageCmdNewLine;
        private System.Windows.Forms.Label lblForgeMessageCmdBegin;
        private System.Windows.Forms.TextBox txbForgeMessageCmdBegin;
        private System.Windows.Forms.CheckBox chkEnabledForgeMessage;
        private System.Windows.Forms.Label lblForgeMessageCmdDemo;
        private System.Windows.Forms.Label lblForgeMessageCmd;
        private System.Windows.Forms.TextBox txbForgeMessageCmd;
        private System.Windows.Forms.TabPage tabRss;
        private System.Windows.Forms.CheckBox chkRssEnabled;
        private System.Windows.Forms.Panel pnlRss;
        private System.Windows.Forms.TextBox txbReadRssInterval;
        private System.Windows.Forms.Label lblReadRssInterval;
        private System.Windows.Forms.FlowLayoutPanel pnlRssSubscriptionList;
        private System.Windows.Forms.Button btnAddRssSubscription;
        private System.Windows.Forms.Label lblTranslateEngineHelp;
        private System.Windows.Forms.ComboBox cboTranslateEngine;
        private System.Windows.Forms.Label lblTranslateEngine;
        private System.Windows.Forms.TextBox txbHPictureOnceMessageMaxImageCount;
        private System.Windows.Forms.Label lblHPictureOnceMessageMaxImageCount;
        private System.Windows.Forms.Label lblHPictureOnceMessageMaxImageCountHelp;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.Panel pnlCheckPorn;
        private System.Windows.Forms.Label lblTencentCloudBucket;
        private System.Windows.Forms.Label lblTencentCloudSecretKey;
        private System.Windows.Forms.TextBox txbTencentCloudBucket;
        private System.Windows.Forms.Label lblTencentCloudSecretId;
        private System.Windows.Forms.TextBox txbTencentCloudRegion;
        private System.Windows.Forms.Label lblTencentCloudRegion;
        private System.Windows.Forms.Label lblTencentCloudAPPID;
        private System.Windows.Forms.TextBox txbTencentCloudSecretId;
        private System.Windows.Forms.TextBox txbTencentCloudAPPID;
        private System.Windows.Forms.TextBox txbTencentCloudSecretKey;
        private System.Windows.Forms.Panel pnlPictureSearcherCheckPorn;
        private System.Windows.Forms.TextBox txbSearchCheckPornIllegalReply;
        private System.Windows.Forms.Label lblSearchCheckPornIllegalReply;
        private System.Windows.Forms.Label lblSearchCheckPornErrorReply;
        private System.Windows.Forms.TextBox txbSearchCheckPornErrorReply;
        private System.Windows.Forms.CheckBox chkCheckPornEnabled;
        private System.Windows.Forms.CheckBox chkPictureSearcherCheckPornEnabled;
        private System.Windows.Forms.TabPage tabOriginPicture;
        private System.Windows.Forms.CheckBox chkOriginPictureEnabled;
        private System.Windows.Forms.CheckBox chkOriginPictureCheckPornEnabled;
        private System.Windows.Forms.Panel pnlOriginPictureCheckPorn;
        private System.Windows.Forms.Label lblOriginPictureCheckPornEvent;
        private System.Windows.Forms.Panel pnlOriginPictureCheckPornEvent;
        private System.Windows.Forms.RadioButton rdoOriginPictureCheckPornReply;
        private System.Windows.Forms.RadioButton rdoOriginPictureCheckPornDoNothing;
        private System.Windows.Forms.RadioButton rdoOriginPictureCheckPornSendByForward;
        private System.Windows.Forms.Label lblOriginPictureCheckPornIllegalReply;
        private System.Windows.Forms.TextBox txbOriginPictureCheckPornIllegalReply;
        private System.Windows.Forms.TextBox txbOriginPictureCheckPornErrorReply;
        private System.Windows.Forms.Label lblOriginPictureCheckPornErrorReply;
        private System.Windows.Forms.Panel pnlOriginPictureCheckPornMessage;
        private System.Windows.Forms.Panel pnlOriginPicture;
        private System.Windows.Forms.CheckBox chkReplaceMeToYou;
        private System.Windows.Forms.CheckBox chkHttpRequestByWebBrowser;
        private System.Windows.Forms.CheckBox chkASCII2DRequestByWebBrowser;
        private System.Windows.Forms.RadioButton rdoNoCheckPornDontSend;
        private System.Windows.Forms.RadioButton rdoNoCheckPornSend;
        private System.Windows.Forms.Label lblSearchNoCheckPorn;
        private System.Windows.Forms.Label lblSearchCheckPornOutOfLimitReply;
        private System.Windows.Forms.TextBox txbSearchCheckPornOutOfLimitReply;
        private System.Windows.Forms.RadioButton rdoSearchCheckPornOutOfLimitAppend;
        private System.Windows.Forms.RadioButton rdoSearchCheckPornOutOfLimitDontSend;
        private System.Windows.Forms.RadioButton rdoSearchCheckPornOutOfLimitSend;
        private System.Windows.Forms.Label lblSearchCheckPornOutOfLimit;
        private System.Windows.Forms.Panel pnlNoCheckPorn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCheckPornLimitCount;
        private System.Windows.Forms.TextBox txbCheckPornLimitCount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTranslateFromToCMD;
        private System.Windows.Forms.Label lblTranslateFromTo;
        private System.Windows.Forms.Label label3;
    }
}