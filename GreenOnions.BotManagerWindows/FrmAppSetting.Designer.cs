namespace GreenOnions.BotManagerWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAppSetting));
            this.chkDownloadImage4Caching = new System.Windows.Forms.CheckBox();
            this.chkSendImageByFile = new System.Windows.Forms.CheckBox();
            this.txbBotName = new System.Windows.Forms.TextBox();
            this.lblBotName = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txbAddAdmin = new System.Windows.Forms.TextBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.pageBot = new System.Windows.Forms.TabPage();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.chkWorkingTimeEnabled = new System.Windows.Forms.CheckBox();
            this.pnlWorkingTime = new System.Windows.Forms.Panel();
            this.lblWorkingTimeToMinute = new System.Windows.Forms.Label();
            this.lblWorkingTimeFromMinute = new System.Windows.Forms.Label();
            this.lblWorkingTimeToHour = new System.Windows.Forms.Label();
            this.lblWorkingTimeFromHour = new System.Windows.Forms.Label();
            this.lblWorkingTimeTo = new System.Windows.Forms.Label();
            this.lblWorkingTimeFrom = new System.Windows.Forms.Label();
            this.cboWorkingTimeFromHour = new System.Windows.Forms.ComboBox();
            this.cboWorkingTimeToHour = new System.Windows.Forms.ComboBox();
            this.cboWorkingTimeToMinute = new System.Windows.Forms.ComboBox();
            this.cboWorkingTimeFromMinute = new System.Windows.Forms.ComboBox();
            this.cboPixivProxy = new System.Windows.Forms.ComboBox();
            this.lblPixivProxy = new System.Windows.Forms.Label();
            this.cboReplaceImgRoute = new System.Windows.Forms.ComboBox();
            this.lblReplaceImgRoute = new System.Windows.Forms.Label();
            this.pnlAutoConnect = new System.Windows.Forms.Panel();
            this.txbAutoConnectDelay = new System.Windows.Forms.TextBox();
            this.cboAutoConnectProtocol = new System.Windows.Forms.ComboBox();
            this.lblAutoConnectDelay = new System.Windows.Forms.Label();
            this.lblAutoConnectProtocol = new System.Windows.Forms.Label();
            this.chkAutoConnectEnabled = new System.Windows.Forms.CheckBox();
            this.cboLogLevel = new System.Windows.Forms.ComboBox();
            this.lblLogLevel = new System.Windows.Forms.Label();
            this.chkHttpRequestByWebBrowser = new System.Windows.Forms.CheckBox();
            this.chkCheckPornEnabled = new System.Windows.Forms.CheckBox();
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
            this.pageSearchPicture = new System.Windows.Forms.TabPage();
            this.pnlSearchPicture = new GreenOnions.BotManagerWindows.Controls.CtrlSearchPicture();
            this.pnlSearchPictureEnabled = new System.Windows.Forms.Panel();
            this.chkSearchPictureEnabled = new System.Windows.Forms.CheckBox();
            this.pageOriginalPicture = new System.Windows.Forms.TabPage();
            this.pnlOriginalPicture = new GreenOnions.BotManagerWindows.Controls.CtrlOriginalPicture();
            this.pnlOriginalPictureEnabled = new System.Windows.Forms.Panel();
            this.chkOriginalPictureEnabled = new System.Windows.Forms.CheckBox();
            this.pageHPicture = new System.Windows.Forms.TabPage();
            this.pnlHPicture = new GreenOnions.BotManagerWindows.Controls.CtrlHPicture();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkHPictureEnabled = new System.Windows.Forms.CheckBox();
            this.pageTranslate = new System.Windows.Forms.TabPage();
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
            this.pageRepeater = new System.Windows.Forms.TabPage();
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
            this.pageGroupMemberEvents = new System.Windows.Forms.TabPage();
            this.txbMemberBeKickedMessage = new System.Windows.Forms.TextBox();
            this.txbMemberPositiveLeaveMessage = new System.Windows.Forms.TextBox();
            this.txbMemberJoinedMessage = new System.Windows.Forms.TextBox();
            this.chkSendMemberBeKickedMessage = new System.Windows.Forms.CheckBox();
            this.chkSendMemberPositiveLeaveMessage = new System.Windows.Forms.CheckBox();
            this.chkSendMemberJoinedMessage = new System.Windows.Forms.CheckBox();
            this.pageForgeMessage = new System.Windows.Forms.TabPage();
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
            this.pageRss = new System.Windows.Forms.TabPage();
            this.pnlRss = new System.Windows.Forms.Panel();
            this.chkRssParallel = new System.Windows.Forms.CheckBox();
            this.pnlRssSubscriptionList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRssSubscription = new System.Windows.Forms.Button();
            this.txbReadRssInterval = new System.Windows.Forms.TextBox();
            this.lblReadRssInterval = new System.Windows.Forms.Label();
            this.chkRssSendLiveCover = new System.Windows.Forms.CheckBox();
            this.chkRssEnabled = new System.Windows.Forms.CheckBox();
            this.pageAbout = new System.Windows.Forms.TabPage();
            this.lnkPluginsUrl = new System.Windows.Forms.LinkLabel();
            this.lblPlugins = new System.Windows.Forms.Label();
            this.lblContributorGroup = new System.Windows.Forms.Label();
            this.txbContributorName = new System.Windows.Forms.TextBox();
            this.txbContributorQQ = new System.Windows.Forms.TextBox();
            this.lnkProjectUrl = new System.Windows.Forms.LinkLabel();
            this.lnkJoinGroup = new System.Windows.Forms.LinkLabel();
            this.lnkContributorGithub = new System.Windows.Forms.LinkLabel();
            this.lblProjectURL = new System.Windows.Forms.Label();
            this.lblContributorGithub = new System.Windows.Forms.Label();
            this.lblContributorQQ = new System.Windows.Forms.Label();
            this.lblContributorName = new System.Windows.Forms.Label();
            this.tabSettings.SuspendLayout();
            this.pageBot.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.pnlWorkingTime.SuspendLayout();
            this.pnlAutoConnect.SuspendLayout();
            this.pnlDebugMode.SuspendLayout();
            this.pnlCheckPorn.SuspendLayout();
            this.pageSearchPicture.SuspendLayout();
            this.pnlSearchPictureEnabled.SuspendLayout();
            this.pageOriginalPicture.SuspendLayout();
            this.pnlOriginalPictureEnabled.SuspendLayout();
            this.pageHPicture.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pageTranslate.SuspendLayout();
            this.pnlTranslate.SuspendLayout();
            this.pageRepeater.SuspendLayout();
            this.pageGroupMemberEvents.SuspendLayout();
            this.pageForgeMessage.SuspendLayout();
            this.pnlForgeMessage.SuspendLayout();
            this.pageRss.SuspendLayout();
            this.pnlRss.SuspendLayout();
            this.pnlRssSubscriptionList.SuspendLayout();
            this.pageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDownloadImage4Caching
            // 
            this.chkDownloadImage4Caching.AutoSize = true;
            this.chkDownloadImage4Caching.Location = new System.Drawing.Point(11, 767);
            this.chkDownloadImage4Caching.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkDownloadImage4Caching.Name = "chkDownloadImage4Caching";
            this.chkDownloadImage4Caching.Size = new System.Drawing.Size(270, 28);
            this.chkDownloadImage4Caching.TabIndex = 42;
            this.chkDownloadImage4Caching.Text = "保留所有下载的图片用于缓存";
            this.chkDownloadImage4Caching.UseVisualStyleBackColor = true;
            // 
            // chkSendImageByFile
            // 
            this.chkSendImageByFile.AutoSize = true;
            this.chkSendImageByFile.Location = new System.Drawing.Point(11, 805);
            this.chkSendImageByFile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkSendImageByFile.Name = "chkSendImageByFile";
            this.chkSendImageByFile.Size = new System.Drawing.Size(794, 28);
            this.chkSendImageByFile.TabIndex = 41;
            this.chkSendImageByFile.Text = "所有图片下载到本地再发送文件 (解决网络环境不佳导致将地址交由平台发送会TimeOut的问题)";
            this.chkSendImageByFile.UseVisualStyleBackColor = true;
            // 
            // txbBotName
            // 
            this.txbBotName.Location = new System.Drawing.Point(196, 8);
            this.txbBotName.Margin = new System.Windows.Forms.Padding(6);
            this.txbBotName.Name = "txbBotName";
            this.txbBotName.Size = new System.Drawing.Size(745, 30);
            this.txbBotName.TabIndex = 0;
            // 
            // lblBotName
            // 
            this.lblBotName.AutoSize = true;
            this.lblBotName.Location = new System.Drawing.Point(11, 16);
            this.lblBotName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBotName.Name = "lblBotName";
            this.lblBotName.Size = new System.Drawing.Size(118, 24);
            this.lblBotName.TabIndex = 1;
            this.lblBotName.Text = "机器人名称：";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(479, 1029);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 32);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txbAddAdmin
            // 
            this.txbAddAdmin.Location = new System.Drawing.Point(652, 83);
            this.txbAddAdmin.Margin = new System.Windows.Forms.Padding(6);
            this.txbAddAdmin.Name = "txbAddAdmin";
            this.txbAddAdmin.ShortcutsEnabled = false;
            this.txbAddAdmin.Size = new System.Drawing.Size(290, 30);
            this.txbAddAdmin.TabIndex = 0;
            this.txbAddAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbAddAdmin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(11, 54);
            this.lblAdmin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(166, 24);
            this.lblAdmin.TabIndex = 1;
            this.lblAdmin.Text = "机器人管理员QQ：";
            // 
            // tabSettings
            // 
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.pageBot);
            this.tabSettings.Controls.Add(this.pageSearchPicture);
            this.tabSettings.Controls.Add(this.pageOriginalPicture);
            this.tabSettings.Controls.Add(this.pageHPicture);
            this.tabSettings.Controls.Add(this.pageTranslate);
            this.tabSettings.Controls.Add(this.pageRepeater);
            this.tabSettings.Controls.Add(this.pageGroupMemberEvents);
            this.tabSettings.Controls.Add(this.pageForgeMessage);
            this.tabSettings.Controls.Add(this.pageRss);
            this.tabSettings.Controls.Add(this.pageAbout);
            this.tabSettings.Location = new System.Drawing.Point(22, 11);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(6);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(1037, 1012);
            this.tabSettings.TabIndex = 4;
            // 
            // pageBot
            // 
            this.pageBot.Controls.Add(this.pnlBot);
            this.pageBot.Location = new System.Drawing.Point(4, 33);
            this.pageBot.Margin = new System.Windows.Forms.Padding(6);
            this.pageBot.Name = "pageBot";
            this.pageBot.Padding = new System.Windows.Forms.Padding(6);
            this.pageBot.Size = new System.Drawing.Size(1029, 975);
            this.pageBot.TabIndex = 1;
            this.pageBot.Text = "机器人设置";
            this.pageBot.UseVisualStyleBackColor = true;
            // 
            // pnlBot
            // 
            this.pnlBot.AutoScroll = true;
            this.pnlBot.Controls.Add(this.lblWorkingTime);
            this.pnlBot.Controls.Add(this.chkWorkingTimeEnabled);
            this.pnlBot.Controls.Add(this.pnlWorkingTime);
            this.pnlBot.Controls.Add(this.cboPixivProxy);
            this.pnlBot.Controls.Add(this.lblPixivProxy);
            this.pnlBot.Controls.Add(this.cboReplaceImgRoute);
            this.pnlBot.Controls.Add(this.lblReplaceImgRoute);
            this.pnlBot.Controls.Add(this.chkDownloadImage4Caching);
            this.pnlBot.Controls.Add(this.chkSendImageByFile);
            this.pnlBot.Controls.Add(this.pnlAutoConnect);
            this.pnlBot.Controls.Add(this.chkAutoConnectEnabled);
            this.pnlBot.Controls.Add(this.cboLogLevel);
            this.pnlBot.Controls.Add(this.lblLogLevel);
            this.pnlBot.Controls.Add(this.chkHttpRequestByWebBrowser);
            this.pnlBot.Controls.Add(this.chkCheckPornEnabled);
            this.pnlBot.Controls.Add(this.pnlDebugMode);
            this.pnlBot.Controls.Add(this.txbBanUser);
            this.pnlBot.Controls.Add(this.pnlCheckPorn);
            this.pnlBot.Controls.Add(this.txbBanGroup);
            this.pnlBot.Controls.Add(this.chkDebugMode);
            this.pnlBot.Controls.Add(this.txbAddAdmin);
            this.pnlBot.Controls.Add(this.lblBotName);
            this.pnlBot.Controls.Add(this.btnRemoveBanUser);
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
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBot.Location = new System.Drawing.Point(6, 6);
            this.pnlBot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(1017, 963);
            this.pnlBot.TabIndex = 36;
            // 
            // lblWorkingTime
            // 
            this.lblWorkingTime.AutoSize = true;
            this.lblWorkingTime.Location = new System.Drawing.Point(214, 1248);
            this.lblWorkingTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Size = new System.Drawing.Size(643, 24);
            this.lblWorkingTime.TabIndex = 53;
            this.lblWorkingTime.Text = "(启用用, 超出指定时段后会自动断开与平台的连接并在次日进入时段后重新连接)";
            // 
            // chkWorkingTimeEnabled
            // 
            this.chkWorkingTimeEnabled.AutoSize = true;
            this.chkWorkingTimeEnabled.Location = new System.Drawing.Point(11, 1247);
            this.chkWorkingTimeEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkWorkingTimeEnabled.Name = "chkWorkingTimeEnabled";
            this.chkWorkingTimeEnabled.Size = new System.Drawing.Size(180, 28);
            this.chkWorkingTimeEnabled.TabIndex = 52;
            this.chkWorkingTimeEnabled.Text = "仅在指定时段工作";
            this.chkWorkingTimeEnabled.UseVisualStyleBackColor = true;
            this.chkWorkingTimeEnabled.CheckedChanged += new System.EventHandler(this.chkWorkingTimeEnabled_CheckedChanged);
            // 
            // pnlWorkingTime
            // 
            this.pnlWorkingTime.Controls.Add(this.lblWorkingTimeToMinute);
            this.pnlWorkingTime.Controls.Add(this.lblWorkingTimeFromMinute);
            this.pnlWorkingTime.Controls.Add(this.lblWorkingTimeToHour);
            this.pnlWorkingTime.Controls.Add(this.lblWorkingTimeFromHour);
            this.pnlWorkingTime.Controls.Add(this.lblWorkingTimeTo);
            this.pnlWorkingTime.Controls.Add(this.lblWorkingTimeFrom);
            this.pnlWorkingTime.Controls.Add(this.cboWorkingTimeFromHour);
            this.pnlWorkingTime.Controls.Add(this.cboWorkingTimeToHour);
            this.pnlWorkingTime.Controls.Add(this.cboWorkingTimeToMinute);
            this.pnlWorkingTime.Controls.Add(this.cboWorkingTimeFromMinute);
            this.pnlWorkingTime.Enabled = false;
            this.pnlWorkingTime.Location = new System.Drawing.Point(6, 1285);
            this.pnlWorkingTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlWorkingTime.Name = "pnlWorkingTime";
            this.pnlWorkingTime.Size = new System.Drawing.Size(974, 90);
            this.pnlWorkingTime.TabIndex = 51;
            // 
            // lblWorkingTimeToMinute
            // 
            this.lblWorkingTimeToMinute.AutoSize = true;
            this.lblWorkingTimeToMinute.Location = new System.Drawing.Point(623, 53);
            this.lblWorkingTimeToMinute.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWorkingTimeToMinute.Name = "lblWorkingTimeToMinute";
            this.lblWorkingTimeToMinute.Size = new System.Drawing.Size(28, 24);
            this.lblWorkingTimeToMinute.TabIndex = 56;
            this.lblWorkingTimeToMinute.Text = "分";
            // 
            // lblWorkingTimeFromMinute
            // 
            this.lblWorkingTimeFromMinute.AutoSize = true;
            this.lblWorkingTimeFromMinute.Location = new System.Drawing.Point(623, 9);
            this.lblWorkingTimeFromMinute.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWorkingTimeFromMinute.Name = "lblWorkingTimeFromMinute";
            this.lblWorkingTimeFromMinute.Size = new System.Drawing.Size(28, 24);
            this.lblWorkingTimeFromMinute.TabIndex = 55;
            this.lblWorkingTimeFromMinute.Text = "分";
            // 
            // lblWorkingTimeToHour
            // 
            this.lblWorkingTimeToHour.AutoSize = true;
            this.lblWorkingTimeToHour.Location = new System.Drawing.Point(383, 53);
            this.lblWorkingTimeToHour.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWorkingTimeToHour.Name = "lblWorkingTimeToHour";
            this.lblWorkingTimeToHour.Size = new System.Drawing.Size(28, 24);
            this.lblWorkingTimeToHour.TabIndex = 54;
            this.lblWorkingTimeToHour.Text = "时";
            // 
            // lblWorkingTimeFromHour
            // 
            this.lblWorkingTimeFromHour.AutoSize = true;
            this.lblWorkingTimeFromHour.Location = new System.Drawing.Point(383, 9);
            this.lblWorkingTimeFromHour.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWorkingTimeFromHour.Name = "lblWorkingTimeFromHour";
            this.lblWorkingTimeFromHour.Size = new System.Drawing.Size(28, 24);
            this.lblWorkingTimeFromHour.TabIndex = 53;
            this.lblWorkingTimeFromHour.Text = "时";
            // 
            // lblWorkingTimeTo
            // 
            this.lblWorkingTimeTo.AutoSize = true;
            this.lblWorkingTimeTo.Location = new System.Drawing.Point(5, 52);
            this.lblWorkingTimeTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWorkingTimeTo.Name = "lblWorkingTimeTo";
            this.lblWorkingTimeTo.Size = new System.Drawing.Size(123, 24);
            this.lblWorkingTimeTo.TabIndex = 52;
            this.lblWorkingTimeTo.Text = "工作时间 到：";
            // 
            // lblWorkingTimeFrom
            // 
            this.lblWorkingTimeFrom.AutoSize = true;
            this.lblWorkingTimeFrom.Location = new System.Drawing.Point(5, 8);
            this.lblWorkingTimeFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWorkingTimeFrom.Name = "lblWorkingTimeFrom";
            this.lblWorkingTimeFrom.Size = new System.Drawing.Size(123, 24);
            this.lblWorkingTimeFrom.TabIndex = 51;
            this.lblWorkingTimeFrom.Text = "工作时间 从：";
            // 
            // cboWorkingTimeFromHour
            // 
            this.cboWorkingTimeFromHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeFromHour.FormattingEnabled = true;
            this.cboWorkingTimeFromHour.Location = new System.Drawing.Point(183, 5);
            this.cboWorkingTimeFromHour.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboWorkingTimeFromHour.Name = "cboWorkingTimeFromHour";
            this.cboWorkingTimeFromHour.Size = new System.Drawing.Size(188, 32);
            this.cboWorkingTimeFromHour.TabIndex = 47;
            // 
            // cboWorkingTimeToHour
            // 
            this.cboWorkingTimeToHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeToHour.FormattingEnabled = true;
            this.cboWorkingTimeToHour.Location = new System.Drawing.Point(183, 49);
            this.cboWorkingTimeToHour.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboWorkingTimeToHour.Name = "cboWorkingTimeToHour";
            this.cboWorkingTimeToHour.Size = new System.Drawing.Size(188, 32);
            this.cboWorkingTimeToHour.TabIndex = 49;
            // 
            // cboWorkingTimeToMinute
            // 
            this.cboWorkingTimeToMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeToMinute.FormattingEnabled = true;
            this.cboWorkingTimeToMinute.Location = new System.Drawing.Point(424, 49);
            this.cboWorkingTimeToMinute.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboWorkingTimeToMinute.Name = "cboWorkingTimeToMinute";
            this.cboWorkingTimeToMinute.Size = new System.Drawing.Size(188, 32);
            this.cboWorkingTimeToMinute.TabIndex = 50;
            // 
            // cboWorkingTimeFromMinute
            // 
            this.cboWorkingTimeFromMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeFromMinute.FormattingEnabled = true;
            this.cboWorkingTimeFromMinute.Location = new System.Drawing.Point(424, 5);
            this.cboWorkingTimeFromMinute.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboWorkingTimeFromMinute.Name = "cboWorkingTimeFromMinute";
            this.cboWorkingTimeFromMinute.Size = new System.Drawing.Size(188, 32);
            this.cboWorkingTimeFromMinute.TabIndex = 48;
            // 
            // cboPixivProxy
            // 
            this.cboPixivProxy.FormattingEnabled = true;
            this.cboPixivProxy.Items.AddRange(new object[] {
            "pixiv.re",
            "pixiv.cat",
            "pixiv.nl"});
            this.cboPixivProxy.Location = new System.Drawing.Point(196, 723);
            this.cboPixivProxy.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboPixivProxy.Name = "cboPixivProxy";
            this.cboPixivProxy.Size = new System.Drawing.Size(441, 32);
            this.cboPixivProxy.TabIndex = 46;
            // 
            // lblPixivProxy
            // 
            this.lblPixivProxy.AutoSize = true;
            this.lblPixivProxy.Location = new System.Drawing.Point(11, 727);
            this.lblPixivProxy.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPixivProxy.Name = "lblPixivProxy";
            this.lblPixivProxy.Size = new System.Drawing.Size(139, 24);
            this.lblPixivProxy.TabIndex = 45;
            this.lblPixivProxy.Text = "Pixiv代理地址：";
            // 
            // cboReplaceImgRoute
            // 
            this.cboReplaceImgRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReplaceImgRoute.FormattingEnabled = true;
            this.cboReplaceImgRoute.Items.AddRange(new object[] {
            "不替换",
            "替换为 c2cpicdw.qpic.cn/offpic_new",
            "替换为 gchat.qpic.cn/gchatpic_new"});
            this.cboReplaceImgRoute.Location = new System.Drawing.Point(196, 679);
            this.cboReplaceImgRoute.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboReplaceImgRoute.Name = "cboReplaceImgRoute";
            this.cboReplaceImgRoute.Size = new System.Drawing.Size(441, 32);
            this.cboReplaceImgRoute.TabIndex = 44;
            // 
            // lblReplaceImgRoute
            // 
            this.lblReplaceImgRoute.AutoSize = true;
            this.lblReplaceImgRoute.Location = new System.Drawing.Point(11, 683);
            this.lblReplaceImgRoute.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReplaceImgRoute.Name = "lblReplaceImgRoute";
            this.lblReplaceImgRoute.Size = new System.Drawing.Size(172, 24);
            this.lblReplaceImgRoute.TabIndex = 43;
            this.lblReplaceImgRoute.Text = "图片外链路由替换：";
            // 
            // pnlAutoConnect
            // 
            this.pnlAutoConnect.Controls.Add(this.txbAutoConnectDelay);
            this.pnlAutoConnect.Controls.Add(this.cboAutoConnectProtocol);
            this.pnlAutoConnect.Controls.Add(this.lblAutoConnectDelay);
            this.pnlAutoConnect.Controls.Add(this.lblAutoConnectProtocol);
            this.pnlAutoConnect.Enabled = false;
            this.pnlAutoConnect.Location = new System.Drawing.Point(6, 1151);
            this.pnlAutoConnect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlAutoConnect.MinimumSize = new System.Drawing.Size(974, 0);
            this.pnlAutoConnect.Name = "pnlAutoConnect";
            this.pnlAutoConnect.Size = new System.Drawing.Size(974, 88);
            this.pnlAutoConnect.TabIndex = 40;
            // 
            // txbAutoConnectDelay
            // 
            this.txbAutoConnectDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAutoConnectDelay.Location = new System.Drawing.Point(182, 48);
            this.txbAutoConnectDelay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbAutoConnectDelay.Name = "txbAutoConnectDelay";
            this.txbAutoConnectDelay.Size = new System.Drawing.Size(312, 30);
            this.txbAutoConnectDelay.TabIndex = 50;
            // 
            // cboAutoConnectProtocol
            // 
            this.cboAutoConnectProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutoConnectProtocol.FormattingEnabled = true;
            this.cboAutoConnectProtocol.Items.AddRange(new object[] {
            "Mirai-Api-Http",
            "CqHttp"});
            this.cboAutoConnectProtocol.Location = new System.Drawing.Point(182, 4);
            this.cboAutoConnectProtocol.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboAutoConnectProtocol.Name = "cboAutoConnectProtocol";
            this.cboAutoConnectProtocol.Size = new System.Drawing.Size(312, 32);
            this.cboAutoConnectProtocol.TabIndex = 39;
            // 
            // lblAutoConnectDelay
            // 
            this.lblAutoConnectDelay.AutoSize = true;
            this.lblAutoConnectDelay.Location = new System.Drawing.Point(5, 52);
            this.lblAutoConnectDelay.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAutoConnectDelay.Name = "lblAutoConnectDelay";
            this.lblAutoConnectDelay.Size = new System.Drawing.Size(134, 24);
            this.lblAutoConnectDelay.TabIndex = 1;
            this.lblAutoConnectDelay.Text = "连接前延时(秒):";
            // 
            // lblAutoConnectProtocol
            // 
            this.lblAutoConnectProtocol.AutoSize = true;
            this.lblAutoConnectProtocol.Location = new System.Drawing.Point(5, 8);
            this.lblAutoConnectProtocol.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAutoConnectProtocol.Name = "lblAutoConnectProtocol";
            this.lblAutoConnectProtocol.Size = new System.Drawing.Size(122, 24);
            this.lblAutoConnectProtocol.TabIndex = 0;
            this.lblAutoConnectProtocol.Text = "自动连接平台:";
            // 
            // chkAutoConnectEnabled
            // 
            this.chkAutoConnectEnabled.AutoSize = true;
            this.chkAutoConnectEnabled.Location = new System.Drawing.Point(11, 1112);
            this.chkAutoConnectEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkAutoConnectEnabled.Name = "chkAutoConnectEnabled";
            this.chkAutoConnectEnabled.Size = new System.Drawing.Size(216, 28);
            this.chkAutoConnectEnabled.TabIndex = 39;
            this.chkAutoConnectEnabled.Text = "自动连接到机器人平台";
            this.chkAutoConnectEnabled.UseVisualStyleBackColor = true;
            this.chkAutoConnectEnabled.CheckedChanged += new System.EventHandler(this.chkAutoConnectEnabled_CheckedChanged);
            // 
            // cboLogLevel
            // 
            this.cboLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLogLevel.FormattingEnabled = true;
            this.cboLogLevel.Items.AddRange(new object[] {
            "消息",
            "警告",
            "错误"});
            this.cboLogLevel.Location = new System.Drawing.Point(189, 1384);
            this.cboLogLevel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboLogLevel.Name = "cboLogLevel";
            this.cboLogLevel.Size = new System.Drawing.Size(312, 32);
            this.cboLogLevel.TabIndex = 38;
            // 
            // lblLogLevel
            // 
            this.lblLogLevel.AutoSize = true;
            this.lblLogLevel.Location = new System.Drawing.Point(11, 1388);
            this.lblLogLevel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLogLevel.Name = "lblLogLevel";
            this.lblLogLevel.Size = new System.Drawing.Size(100, 24);
            this.lblLogLevel.TabIndex = 37;
            this.lblLogLevel.Text = "日志级别：";
            // 
            // chkHttpRequestByWebBrowser
            // 
            this.chkHttpRequestByWebBrowser.AutoSize = true;
            this.chkHttpRequestByWebBrowser.Location = new System.Drawing.Point(11, 641);
            this.chkHttpRequestByWebBrowser.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkHttpRequestByWebBrowser.Name = "chkHttpRequestByWebBrowser";
            this.chkHttpRequestByWebBrowser.Size = new System.Drawing.Size(401, 28);
            this.chkHttpRequestByWebBrowser.TabIndex = 36;
            this.chkHttpRequestByWebBrowser.Text = "允许调用浏览器执行Http请求(仅限Windows)";
            this.chkHttpRequestByWebBrowser.UseVisualStyleBackColor = true;
            // 
            // chkCheckPornEnabled
            // 
            this.chkCheckPornEnabled.AutoSize = true;
            this.chkCheckPornEnabled.Location = new System.Drawing.Point(11, 843);
            this.chkCheckPornEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkCheckPornEnabled.Name = "chkCheckPornEnabled";
            this.chkCheckPornEnabled.Size = new System.Drawing.Size(162, 28);
            this.chkCheckPornEnabled.TabIndex = 34;
            this.chkCheckPornEnabled.Text = "接入腾讯云鉴黄";
            this.chkCheckPornEnabled.UseVisualStyleBackColor = true;
            this.chkCheckPornEnabled.CheckedChanged += new System.EventHandler(this.chkCheckPorn_CheckedChanged);
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
            this.pnlDebugMode.Location = new System.Drawing.Point(6, 1465);
            this.pnlDebugMode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlDebugMode.MinimumSize = new System.Drawing.Size(974, 216);
            this.pnlDebugMode.Name = "pnlDebugMode";
            this.pnlDebugMode.Size = new System.Drawing.Size(974, 216);
            this.pnlDebugMode.TabIndex = 12;
            // 
            // chkOnlyReplyDebugGroup
            // 
            this.chkOnlyReplyDebugGroup.AutoSize = true;
            this.chkOnlyReplyDebugGroup.Location = new System.Drawing.Point(182, 143);
            this.chkOnlyReplyDebugGroup.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkOnlyReplyDebugGroup.Name = "chkOnlyReplyDebugGroup";
            this.chkOnlyReplyDebugGroup.Size = new System.Drawing.Size(216, 28);
            this.chkOnlyReplyDebugGroup.TabIndex = 12;
            this.chkOnlyReplyDebugGroup.Text = "只响应调试群组的消息";
            this.chkOnlyReplyDebugGroup.UseVisualStyleBackColor = true;
            // 
            // lstDebugGroups
            // 
            this.lstDebugGroups.FullRowSelect = true;
            this.lstDebugGroups.Location = new System.Drawing.Point(182, 13);
            this.lstDebugGroups.Margin = new System.Windows.Forms.Padding(6);
            this.lstDebugGroups.Name = "lstDebugGroups";
            this.lstDebugGroups.Size = new System.Drawing.Size(312, 118);
            this.lstDebugGroups.TabIndex = 3;
            this.lstDebugGroups.UseCompatibleStateImageBehavior = false;
            this.lstDebugGroups.View = System.Windows.Forms.View.List;
            // 
            // chkDebugReplyAdminOnly
            // 
            this.chkDebugReplyAdminOnly.AutoSize = true;
            this.chkDebugReplyAdminOnly.Location = new System.Drawing.Point(182, 181);
            this.chkDebugReplyAdminOnly.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkDebugReplyAdminOnly.Name = "chkDebugReplyAdminOnly";
            this.chkDebugReplyAdminOnly.Size = new System.Drawing.Size(288, 28);
            this.chkDebugReplyAdminOnly.TabIndex = 11;
            this.chkDebugReplyAdminOnly.Text = "只响应来自机器人管理员的消息";
            this.chkDebugReplyAdminOnly.UseVisualStyleBackColor = true;
            // 
            // lblAddDebugGroup
            // 
            this.lblAddDebugGroup.AutoSize = true;
            this.lblAddDebugGroup.Location = new System.Drawing.Point(660, 13);
            this.lblAddDebugGroup.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddDebugGroup.Name = "lblAddDebugGroup";
            this.lblAddDebugGroup.Size = new System.Drawing.Size(172, 24);
            this.lblAddDebugGroup.TabIndex = 1;
            this.lblAddDebugGroup.Text = "添加调试模式群号：";
            // 
            // lblDebugGroup
            // 
            this.lblDebugGroup.AutoSize = true;
            this.lblDebugGroup.Location = new System.Drawing.Point(5, 13);
            this.lblDebugGroup.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDebugGroup.Name = "lblDebugGroup";
            this.lblDebugGroup.Size = new System.Drawing.Size(100, 24);
            this.lblDebugGroup.TabIndex = 10;
            this.lblDebugGroup.Text = "调试群组：";
            // 
            // btnAddDebugGroup
            // 
            this.btnAddDebugGroup.Location = new System.Drawing.Point(509, 42);
            this.btnAddDebugGroup.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddDebugGroup.Name = "btnAddDebugGroup";
            this.btnAddDebugGroup.Size = new System.Drawing.Size(138, 32);
            this.btnAddDebugGroup.TabIndex = 4;
            this.btnAddDebugGroup.Text = "<<添加<<";
            this.btnAddDebugGroup.UseVisualStyleBackColor = true;
            this.btnAddDebugGroup.Click += new System.EventHandler(this.btnAddDebugGroup_Click);
            // 
            // btnRemoveDebugGroup
            // 
            this.btnRemoveDebugGroup.Location = new System.Drawing.Point(509, 86);
            this.btnRemoveDebugGroup.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveDebugGroup.Name = "btnRemoveDebugGroup";
            this.btnRemoveDebugGroup.Size = new System.Drawing.Size(138, 32);
            this.btnRemoveDebugGroup.TabIndex = 4;
            this.btnRemoveDebugGroup.Text = ">>移除>>";
            this.btnRemoveDebugGroup.UseVisualStyleBackColor = true;
            this.btnRemoveDebugGroup.Click += new System.EventHandler(this.btnRemoveDebugGroup_Click);
            // 
            // txbAddDebugGroup
            // 
            this.txbAddDebugGroup.Location = new System.Drawing.Point(660, 42);
            this.txbAddDebugGroup.Margin = new System.Windows.Forms.Padding(6);
            this.txbAddDebugGroup.Name = "txbAddDebugGroup";
            this.txbAddDebugGroup.ShortcutsEnabled = false;
            this.txbAddDebugGroup.Size = new System.Drawing.Size(276, 30);
            this.txbAddDebugGroup.TabIndex = 0;
            this.txbAddDebugGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbAddDebugGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbBanUser
            // 
            this.txbBanUser.Location = new System.Drawing.Point(652, 470);
            this.txbBanUser.Margin = new System.Windows.Forms.Padding(6);
            this.txbBanUser.Name = "txbBanUser";
            this.txbBanUser.ShortcutsEnabled = false;
            this.txbBanUser.Size = new System.Drawing.Size(290, 30);
            this.txbBanUser.TabIndex = 0;
            this.txbBanUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbBanUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // pnlCheckPorn
            // 
            this.pnlCheckPorn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pnlCheckPorn.Location = new System.Drawing.Point(6, 881);
            this.pnlCheckPorn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlCheckPorn.MinimumSize = new System.Drawing.Size(974, 226);
            this.pnlCheckPorn.Name = "pnlCheckPorn";
            this.pnlCheckPorn.Size = new System.Drawing.Size(974, 226);
            this.pnlCheckPorn.TabIndex = 35;
            // 
            // lblTencentCloudBucket
            // 
            this.lblTencentCloudBucket.AutoSize = true;
            this.lblTencentCloudBucket.Location = new System.Drawing.Point(5, 172);
            this.lblTencentCloudBucket.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTencentCloudBucket.Name = "lblTencentCloudBucket";
            this.lblTencentCloudBucket.Size = new System.Drawing.Size(126, 24);
            this.lblTencentCloudBucket.TabIndex = 32;
            this.lblTencentCloudBucket.Text = "腾讯云Bucket:";
            // 
            // lblTencentCloudSecretKey
            // 
            this.lblTencentCloudSecretKey.AutoSize = true;
            this.lblTencentCloudSecretKey.Location = new System.Drawing.Point(5, 131);
            this.lblTencentCloudSecretKey.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTencentCloudSecretKey.Name = "lblTencentCloudSecretKey";
            this.lblTencentCloudSecretKey.Size = new System.Drawing.Size(152, 24);
            this.lblTencentCloudSecretKey.TabIndex = 31;
            this.lblTencentCloudSecretKey.Text = "腾讯云SecretKey:";
            // 
            // txbTencentCloudBucket
            // 
            this.txbTencentCloudBucket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudBucket.Location = new System.Drawing.Point(182, 168);
            this.txbTencentCloudBucket.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTencentCloudBucket.Name = "txbTencentCloudBucket";
            this.txbTencentCloudBucket.Size = new System.Drawing.Size(753, 30);
            this.txbTencentCloudBucket.TabIndex = 16;
            // 
            // lblTencentCloudSecretId
            // 
            this.lblTencentCloudSecretId.AutoSize = true;
            this.lblTencentCloudSecretId.Location = new System.Drawing.Point(5, 90);
            this.lblTencentCloudSecretId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTencentCloudSecretId.Name = "lblTencentCloudSecretId";
            this.lblTencentCloudSecretId.Size = new System.Drawing.Size(138, 24);
            this.lblTencentCloudSecretId.TabIndex = 30;
            this.lblTencentCloudSecretId.Text = "腾讯云SecretId:";
            // 
            // txbTencentCloudRegion
            // 
            this.txbTencentCloudRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudRegion.Location = new System.Drawing.Point(182, 45);
            this.txbTencentCloudRegion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTencentCloudRegion.Name = "txbTencentCloudRegion";
            this.txbTencentCloudRegion.Size = new System.Drawing.Size(753, 30);
            this.txbTencentCloudRegion.TabIndex = 16;
            // 
            // lblTencentCloudRegion
            // 
            this.lblTencentCloudRegion.AutoSize = true;
            this.lblTencentCloudRegion.Location = new System.Drawing.Point(5, 49);
            this.lblTencentCloudRegion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTencentCloudRegion.Name = "lblTencentCloudRegion";
            this.lblTencentCloudRegion.Size = new System.Drawing.Size(125, 24);
            this.lblTencentCloudRegion.TabIndex = 29;
            this.lblTencentCloudRegion.Text = "腾讯云Region";
            // 
            // lblTencentCloudAPPID
            // 
            this.lblTencentCloudAPPID.AutoSize = true;
            this.lblTencentCloudAPPID.Location = new System.Drawing.Point(5, 8);
            this.lblTencentCloudAPPID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTencentCloudAPPID.Name = "lblTencentCloudAPPID";
            this.lblTencentCloudAPPID.Size = new System.Drawing.Size(122, 24);
            this.lblTencentCloudAPPID.TabIndex = 28;
            this.lblTencentCloudAPPID.Text = "腾讯云APPID:";
            // 
            // txbTencentCloudSecretId
            // 
            this.txbTencentCloudSecretId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudSecretId.Location = new System.Drawing.Point(182, 86);
            this.txbTencentCloudSecretId.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTencentCloudSecretId.Name = "txbTencentCloudSecretId";
            this.txbTencentCloudSecretId.Size = new System.Drawing.Size(753, 30);
            this.txbTencentCloudSecretId.TabIndex = 16;
            // 
            // txbTencentCloudAPPID
            // 
            this.txbTencentCloudAPPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudAPPID.Location = new System.Drawing.Point(182, 4);
            this.txbTencentCloudAPPID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTencentCloudAPPID.Name = "txbTencentCloudAPPID";
            this.txbTencentCloudAPPID.Size = new System.Drawing.Size(753, 30);
            this.txbTencentCloudAPPID.TabIndex = 16;
            // 
            // txbTencentCloudSecretKey
            // 
            this.txbTencentCloudSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudSecretKey.Location = new System.Drawing.Point(182, 127);
            this.txbTencentCloudSecretKey.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTencentCloudSecretKey.Name = "txbTencentCloudSecretKey";
            this.txbTencentCloudSecretKey.Size = new System.Drawing.Size(753, 30);
            this.txbTencentCloudSecretKey.TabIndex = 16;
            // 
            // txbBanGroup
            // 
            this.txbBanGroup.Location = new System.Drawing.Point(652, 264);
            this.txbBanGroup.Margin = new System.Windows.Forms.Padding(6);
            this.txbBanGroup.Name = "txbBanGroup";
            this.txbBanGroup.ShortcutsEnabled = false;
            this.txbBanGroup.Size = new System.Drawing.Size(290, 30);
            this.txbBanGroup.TabIndex = 0;
            this.txbBanGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbBanGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // chkDebugMode
            // 
            this.chkDebugMode.AutoSize = true;
            this.chkDebugMode.Location = new System.Drawing.Point(11, 1427);
            this.chkDebugMode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkDebugMode.Name = "chkDebugMode";
            this.chkDebugMode.Size = new System.Drawing.Size(108, 28);
            this.chkDebugMode.TabIndex = 9;
            this.chkDebugMode.Text = "调试模式";
            this.chkDebugMode.UseVisualStyleBackColor = true;
            this.chkDebugMode.CheckedChanged += new System.EventHandler(this.chkDebugMode_CheckedChanged);
            // 
            // btnRemoveBanUser
            // 
            this.btnRemoveBanUser.Location = new System.Drawing.Point(501, 528);
            this.btnRemoveBanUser.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveBanUser.Name = "btnRemoveBanUser";
            this.btnRemoveBanUser.Size = new System.Drawing.Size(138, 32);
            this.btnRemoveBanUser.TabIndex = 4;
            this.btnRemoveBanUser.Text = ">>移除>>";
            this.btnRemoveBanUser.UseVisualStyleBackColor = true;
            this.btnRemoveBanUser.Click += new System.EventHandler(this.btnRemoveBanUser_Click);
            // 
            // btnRemoveBanGroup
            // 
            this.btnRemoveBanGroup.Location = new System.Drawing.Point(501, 322);
            this.btnRemoveBanGroup.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveBanGroup.Name = "btnRemoveBanGroup";
            this.btnRemoveBanGroup.Size = new System.Drawing.Size(138, 32);
            this.btnRemoveBanGroup.TabIndex = 4;
            this.btnRemoveBanGroup.Text = ">>移除>>";
            this.btnRemoveBanGroup.UseVisualStyleBackColor = true;
            this.btnRemoveBanGroup.Click += new System.EventHandler(this.btnRemoveBanGroup_Click);
            // 
            // btnRemoveAdmin
            // 
            this.btnRemoveAdmin.Location = new System.Drawing.Point(501, 127);
            this.btnRemoveAdmin.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveAdmin.Name = "btnRemoveAdmin";
            this.btnRemoveAdmin.Size = new System.Drawing.Size(138, 32);
            this.btnRemoveAdmin.TabIndex = 4;
            this.btnRemoveAdmin.Text = ">>移除>>";
            this.btnRemoveAdmin.UseVisualStyleBackColor = true;
            this.btnRemoveAdmin.Click += new System.EventHandler(this.btnRemoveAdmin_Click);
            // 
            // btnAddBanUser
            // 
            this.btnAddBanUser.Location = new System.Drawing.Point(501, 470);
            this.btnAddBanUser.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddBanUser.Name = "btnAddBanUser";
            this.btnAddBanUser.Size = new System.Drawing.Size(138, 32);
            this.btnAddBanUser.TabIndex = 4;
            this.btnAddBanUser.Text = "<<添加<<";
            this.btnAddBanUser.UseVisualStyleBackColor = true;
            this.btnAddBanUser.Click += new System.EventHandler(this.btnAddBanUser_Click);
            // 
            // lblAddAdmin
            // 
            this.lblAddAdmin.AutoSize = true;
            this.lblAddAdmin.Location = new System.Drawing.Point(649, 54);
            this.lblAddAdmin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddAdmin.Name = "lblAddAdmin";
            this.lblAddAdmin.Size = new System.Drawing.Size(148, 24);
            this.lblAddAdmin.TabIndex = 1;
            this.lblAddAdmin.Text = "添加管理员QQ：";
            // 
            // btnAddBanGroup
            // 
            this.btnAddBanGroup.Location = new System.Drawing.Point(501, 264);
            this.btnAddBanGroup.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddBanGroup.Name = "btnAddBanGroup";
            this.btnAddBanGroup.Size = new System.Drawing.Size(138, 32);
            this.btnAddBanGroup.TabIndex = 4;
            this.btnAddBanGroup.Text = "<<添加<<";
            this.btnAddBanGroup.UseVisualStyleBackColor = true;
            this.btnAddBanGroup.Click += new System.EventHandler(this.btnAddBanGroup_Click);
            // 
            // lblBannedGroup
            // 
            this.lblBannedGroup.AutoSize = true;
            this.lblBannedGroup.Location = new System.Drawing.Point(11, 234);
            this.lblBannedGroup.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBannedGroup.Name = "lblBannedGroup";
            this.lblBannedGroup.Size = new System.Drawing.Size(100, 24);
            this.lblBannedGroup.TabIndex = 1;
            this.lblBannedGroup.Text = "群黑名单：";
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.Location = new System.Drawing.Point(501, 83);
            this.btnAddAdmin.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddAdmin.Name = "btnAddAdmin";
            this.btnAddAdmin.Size = new System.Drawing.Size(138, 32);
            this.btnAddAdmin.TabIndex = 4;
            this.btnAddAdmin.Text = "<<添加<<";
            this.btnAddAdmin.UseVisualStyleBackColor = true;
            this.btnAddAdmin.Click += new System.EventHandler(this.btnAddAdmin_Click);
            // 
            // lstAdmins
            // 
            this.lstAdmins.FullRowSelect = true;
            this.lstAdmins.Location = new System.Drawing.Point(196, 52);
            this.lstAdmins.Margin = new System.Windows.Forms.Padding(6);
            this.lstAdmins.Name = "lstAdmins";
            this.lstAdmins.Size = new System.Drawing.Size(290, 118);
            this.lstAdmins.TabIndex = 3;
            this.lstAdmins.UseCompatibleStateImageBehavior = false;
            this.lstAdmins.View = System.Windows.Forms.View.List;
            // 
            // lstBannedUser
            // 
            this.lstBannedUser.FullRowSelect = true;
            this.lstBannedUser.Location = new System.Drawing.Point(196, 439);
            this.lstBannedUser.Margin = new System.Windows.Forms.Padding(6);
            this.lstBannedUser.Name = "lstBannedUser";
            this.lstBannedUser.Size = new System.Drawing.Size(290, 190);
            this.lstBannedUser.TabIndex = 3;
            this.lstBannedUser.UseCompatibleStateImageBehavior = false;
            this.lstBannedUser.View = System.Windows.Forms.View.List;
            // 
            // lblBannedUser
            // 
            this.lblBannedUser.AutoSize = true;
            this.lblBannedUser.Location = new System.Drawing.Point(11, 440);
            this.lblBannedUser.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBannedUser.Name = "lblBannedUser";
            this.lblBannedUser.Size = new System.Drawing.Size(118, 24);
            this.lblBannedUser.TabIndex = 1;
            this.lblBannedUser.Text = "用户黑名单：";
            // 
            // lblBanUser
            // 
            this.lblBanUser.AutoSize = true;
            this.lblBanUser.Location = new System.Drawing.Point(649, 440);
            this.lblBanUser.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBanUser.Name = "lblBanUser";
            this.lblBanUser.Size = new System.Drawing.Size(172, 24);
            this.lblBanUser.TabIndex = 1;
            this.lblBanUser.Text = "添加到用户黑名单：";
            // 
            // lblBanGroup
            // 
            this.lblBanGroup.AutoSize = true;
            this.lblBanGroup.Location = new System.Drawing.Point(649, 234);
            this.lblBanGroup.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBanGroup.Name = "lblBanGroup";
            this.lblBanGroup.Size = new System.Drawing.Size(154, 24);
            this.lblBanGroup.TabIndex = 1;
            this.lblBanGroup.Text = "添加到群黑名单：";
            // 
            // lstBannedGroup
            // 
            this.lstBannedGroup.FullRowSelect = true;
            this.lstBannedGroup.Location = new System.Drawing.Point(196, 233);
            this.lstBannedGroup.Margin = new System.Windows.Forms.Padding(6);
            this.lstBannedGroup.Name = "lstBannedGroup";
            this.lstBannedGroup.Size = new System.Drawing.Size(290, 190);
            this.lstBannedGroup.TabIndex = 3;
            this.lstBannedGroup.UseCompatibleStateImageBehavior = false;
            this.lstBannedGroup.View = System.Windows.Forms.View.List;
            // 
            // pageSearchPicture
            // 
            this.pageSearchPicture.Controls.Add(this.pnlSearchPicture);
            this.pageSearchPicture.Controls.Add(this.pnlSearchPictureEnabled);
            this.pageSearchPicture.Location = new System.Drawing.Point(4, 33);
            this.pageSearchPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageSearchPicture.Name = "pageSearchPicture";
            this.pageSearchPicture.Size = new System.Drawing.Size(1029, 975);
            this.pageSearchPicture.TabIndex = 3;
            this.pageSearchPicture.Text = "搜图设置";
            this.pageSearchPicture.UseVisualStyleBackColor = true;
            // 
            // pnlSearchPicture
            // 
            this.pnlSearchPicture.AutoScroll = true;
            this.pnlSearchPicture.BackColor = System.Drawing.Color.White;
            this.pnlSearchPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchPicture.Enabled = false;
            this.pnlSearchPicture.Location = new System.Drawing.Point(0, 40);
            this.pnlSearchPicture.MinimumSize = new System.Drawing.Size(1015, 906);
            this.pnlSearchPicture.Name = "pnlSearchPicture";
            this.pnlSearchPicture.Size = new System.Drawing.Size(1029, 935);
            this.pnlSearchPicture.TabIndex = 16;
            // 
            // pnlSearchPictureEnabled
            // 
            this.pnlSearchPictureEnabled.Controls.Add(this.chkSearchPictureEnabled);
            this.pnlSearchPictureEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchPictureEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchPictureEnabled.Name = "pnlSearchPictureEnabled";
            this.pnlSearchPictureEnabled.Size = new System.Drawing.Size(1029, 40);
            this.pnlSearchPictureEnabled.TabIndex = 17;
            // 
            // chkSearchPictureEnabled
            // 
            this.chkSearchPictureEnabled.AutoSize = true;
            this.chkSearchPictureEnabled.Location = new System.Drawing.Point(5, 4);
            this.chkSearchPictureEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkSearchPictureEnabled.Name = "chkSearchPictureEnabled";
            this.chkSearchPictureEnabled.Size = new System.Drawing.Size(144, 28);
            this.chkSearchPictureEnabled.TabIndex = 15;
            this.chkSearchPictureEnabled.Text = "启用搜图功能";
            this.chkSearchPictureEnabled.UseVisualStyleBackColor = true;
            this.chkSearchPictureEnabled.CheckedChanged += new System.EventHandler(this.chkSearchPictureEnabled_CheckedChanged);
            // 
            // pageOriginalPicture
            // 
            this.pageOriginalPicture.Controls.Add(this.pnlOriginalPicture);
            this.pageOriginalPicture.Controls.Add(this.pnlOriginalPictureEnabled);
            this.pageOriginalPicture.Location = new System.Drawing.Point(4, 33);
            this.pageOriginalPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageOriginalPicture.Name = "pageOriginalPicture";
            this.pageOriginalPicture.Size = new System.Drawing.Size(1029, 975);
            this.pageOriginalPicture.TabIndex = 9;
            this.pageOriginalPicture.Text = "下载原图";
            this.pageOriginalPicture.UseVisualStyleBackColor = true;
            // 
            // pnlOriginalPicture
            // 
            this.pnlOriginalPicture.BackColor = System.Drawing.Color.White;
            this.pnlOriginalPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOriginalPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOriginalPicture.Enabled = false;
            this.pnlOriginalPicture.Location = new System.Drawing.Point(0, 40);
            this.pnlOriginalPicture.MinimumSize = new System.Drawing.Size(1015, 0);
            this.pnlOriginalPicture.Name = "pnlOriginalPicture";
            this.pnlOriginalPicture.Size = new System.Drawing.Size(1029, 935);
            this.pnlOriginalPicture.TabIndex = 1;
            // 
            // pnlOriginalPictureEnabled
            // 
            this.pnlOriginalPictureEnabled.Controls.Add(this.chkOriginalPictureEnabled);
            this.pnlOriginalPictureEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOriginalPictureEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlOriginalPictureEnabled.Name = "pnlOriginalPictureEnabled";
            this.pnlOriginalPictureEnabled.Size = new System.Drawing.Size(1029, 40);
            this.pnlOriginalPictureEnabled.TabIndex = 2;
            // 
            // chkOriginalPictureEnabled
            // 
            this.chkOriginalPictureEnabled.AutoSize = true;
            this.chkOriginalPictureEnabled.Location = new System.Drawing.Point(5, 4);
            this.chkOriginalPictureEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkOriginalPictureEnabled.Name = "chkOriginalPictureEnabled";
            this.chkOriginalPictureEnabled.Size = new System.Drawing.Size(256, 28);
            this.chkOriginalPictureEnabled.TabIndex = 0;
            this.chkOriginalPictureEnabled.Text = "启用按ID下载Pixiv原图功能";
            this.chkOriginalPictureEnabled.UseVisualStyleBackColor = true;
            this.chkOriginalPictureEnabled.CheckedChanged += new System.EventHandler(this.chkOriginalPictureEnabled_CheckedChanged);
            // 
            // pageHPicture
            // 
            this.pageHPicture.AutoScroll = true;
            this.pageHPicture.Controls.Add(this.pnlHPicture);
            this.pageHPicture.Controls.Add(this.panel1);
            this.pageHPicture.Location = new System.Drawing.Point(4, 33);
            this.pageHPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageHPicture.Name = "pageHPicture";
            this.pageHPicture.Size = new System.Drawing.Size(1029, 975);
            this.pageHPicture.TabIndex = 0;
            this.pageHPicture.Text = "色图设置";
            this.pageHPicture.UseVisualStyleBackColor = true;
            // 
            // pnlHPicture
            // 
            this.pnlHPicture.AutoScroll = true;
            this.pnlHPicture.BackColor = System.Drawing.Color.White;
            this.pnlHPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHPicture.Enabled = false;
            this.pnlHPicture.Location = new System.Drawing.Point(0, 40);
            this.pnlHPicture.MinimumSize = new System.Drawing.Size(1015, 902);
            this.pnlHPicture.Name = "pnlHPicture";
            this.pnlHPicture.Size = new System.Drawing.Size(1029, 935);
            this.pnlHPicture.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkHPictureEnabled);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 40);
            this.panel1.TabIndex = 9;
            // 
            // chkHPictureEnabled
            // 
            this.chkHPictureEnabled.AutoSize = true;
            this.chkHPictureEnabled.Location = new System.Drawing.Point(5, 4);
            this.chkHPictureEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkHPictureEnabled.Name = "chkHPictureEnabled";
            this.chkHPictureEnabled.Size = new System.Drawing.Size(144, 28);
            this.chkHPictureEnabled.TabIndex = 7;
            this.chkHPictureEnabled.Text = "启用色图功能";
            this.chkHPictureEnabled.UseVisualStyleBackColor = true;
            this.chkHPictureEnabled.CheckedChanged += new System.EventHandler(this.chkEnableHPicture_CheckedChanged);
            // 
            // pageTranslate
            // 
            this.pageTranslate.Controls.Add(this.pnlTranslate);
            this.pageTranslate.Controls.Add(this.chkTranslateEnabled);
            this.pageTranslate.Location = new System.Drawing.Point(4, 33);
            this.pageTranslate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageTranslate.Name = "pageTranslate";
            this.pageTranslate.Size = new System.Drawing.Size(192, 63);
            this.pageTranslate.TabIndex = 4;
            this.pageTranslate.Text = "翻译设置";
            this.pageTranslate.UseVisualStyleBackColor = true;
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
            this.pnlTranslate.Location = new System.Drawing.Point(5, 49);
            this.pnlTranslate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlTranslate.Name = "pnlTranslate";
            this.pnlTranslate.Size = new System.Drawing.Size(178, 0);
            this.pnlTranslate.TabIndex = 1;
            // 
            // txbTranslateFromToCMD
            // 
            this.txbTranslateFromToCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTranslateFromToCMD.Location = new System.Drawing.Point(310, 175);
            this.txbTranslateFromToCMD.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTranslateFromToCMD.Name = "txbTranslateFromToCMD";
            this.txbTranslateFromToCMD.Size = new System.Drawing.Size(0, 30);
            this.txbTranslateFromToCMD.TabIndex = 15;
            // 
            // lblTranslateFromTo
            // 
            this.lblTranslateFromTo.AutoSize = true;
            this.lblTranslateFromTo.Location = new System.Drawing.Point(19, 179);
            this.lblTranslateFromTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateFromTo.Name = "lblTranslateFromTo";
            this.lblTranslateFromTo.Size = new System.Drawing.Size(266, 24);
            this.lblTranslateFromTo.TabIndex = 14;
            this.lblTranslateFromTo.Text = "从指定语言翻译为指定语言命令:";
            // 
            // lblTranslateEngineHelp
            // 
            this.lblTranslateEngineHelp.AutoSize = true;
            this.lblTranslateEngineHelp.Location = new System.Drawing.Point(215, 44);
            this.lblTranslateEngineHelp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateEngineHelp.Name = "lblTranslateEngineHelp";
            this.lblTranslateEngineHelp.Size = new System.Drawing.Size(587, 24);
            this.lblTranslateEngineHelp.TabIndex = 13;
            this.lblTranslateEngineHelp.Text = "提示: 谷歌翻译 Api 需翻墙，有道翻译识别语言经常出错，建议手动指定)";
            // 
            // cboTranslateEngine
            // 
            this.cboTranslateEngine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTranslateEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateEngine.FormattingEnabled = true;
            this.cboTranslateEngine.Items.AddRange(new object[] {
            "Google",
            "YouDao"});
            this.cboTranslateEngine.Location = new System.Drawing.Point(215, 4);
            this.cboTranslateEngine.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboTranslateEngine.Name = "cboTranslateEngine";
            this.cboTranslateEngine.Size = new System.Drawing.Size(0, 32);
            this.cboTranslateEngine.TabIndex = 12;
            this.cboTranslateEngine.SelectedIndexChanged += new System.EventHandler(this.cboTranslateEngine_SelectedIndexChanged);
            // 
            // lblTranslateEngine
            // 
            this.lblTranslateEngine.AutoSize = true;
            this.lblTranslateEngine.Location = new System.Drawing.Point(19, 8);
            this.lblTranslateEngine.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateEngine.Name = "lblTranslateEngine";
            this.lblTranslateEngine.Size = new System.Drawing.Size(86, 24);
            this.lblTranslateEngine.TabIndex = 11;
            this.lblTranslateEngine.Text = "翻译引擎:";
            // 
            // txbAddAutoTranslateGroupMemoryQQ
            // 
            this.txbAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(715, 282);
            this.txbAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6);
            this.txbAddAutoTranslateGroupMemoryQQ.Name = "txbAddAutoTranslateGroupMemoryQQ";
            this.txbAddAutoTranslateGroupMemoryQQ.ShortcutsEnabled = false;
            this.txbAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(260, 30);
            this.txbAddAutoTranslateGroupMemoryQQ.TabIndex = 5;
            // 
            // btnRemoveAutoTranslateGroupMemoryQQ
            // 
            this.btnRemoveAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(545, 326);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Name = "btnRemoveAutoTranslateGroupMemoryQQ";
            this.btnRemoveAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(138, 32);
            this.btnRemoveAutoTranslateGroupMemoryQQ.TabIndex = 9;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Text = ">>移除>>";
            this.btnRemoveAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnRemoveAutoTranslateGroupMemoryQQ_Click);
            // 
            // btnAddAutoTranslateGroupMemoryQQ
            // 
            this.btnAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(545, 282);
            this.btnAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddAutoTranslateGroupMemoryQQ.Name = "btnAddAutoTranslateGroupMemoryQQ";
            this.btnAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(138, 32);
            this.btnAddAutoTranslateGroupMemoryQQ.TabIndex = 10;
            this.btnAddAutoTranslateGroupMemoryQQ.Text = "<<添加<<";
            this.btnAddAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnAddAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnAddAutoTranslateGroupMemoryQQ_Click);
            // 
            // lstAutoTranslateGroupMemoriesQQ
            // 
            this.lstAutoTranslateGroupMemoriesQQ.FullRowSelect = true;
            this.lstAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(245, 253);
            this.lstAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(6);
            this.lstAutoTranslateGroupMemoriesQQ.Name = "lstAutoTranslateGroupMemoriesQQ";
            this.lstAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(260, 118);
            this.lstAutoTranslateGroupMemoriesQQ.TabIndex = 8;
            this.lstAutoTranslateGroupMemoriesQQ.UseCompatibleStateImageBehavior = false;
            this.lstAutoTranslateGroupMemoriesQQ.View = System.Windows.Forms.View.List;
            // 
            // lblAddAutoTranslateGroupMemoryQQ
            // 
            this.lblAddAutoTranslateGroupMemoryQQ.AutoSize = true;
            this.lblAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(712, 253);
            this.lblAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddAutoTranslateGroupMemoryQQ.Name = "lblAddAutoTranslateGroupMemoryQQ";
            this.lblAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(238, 24);
            this.lblAddAutoTranslateGroupMemoryQQ.TabIndex = 6;
            this.lblAddAutoTranslateGroupMemoryQQ.Text = "添加自动翻译群友消息QQ：";
            // 
            // lblAutoTranslateGroupMemoriesQQ
            // 
            this.lblAutoTranslateGroupMemoriesQQ.AutoSize = true;
            this.lblAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(19, 253);
            this.lblAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAutoTranslateGroupMemoriesQQ.Name = "lblAutoTranslateGroupMemoriesQQ";
            this.lblAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(202, 24);
            this.lblAutoTranslateGroupMemoriesQQ.TabIndex = 7;
            this.lblAutoTranslateGroupMemoriesQQ.Text = "自动翻译群友消息QQ：";
            // 
            // txbTranslateTo
            // 
            this.txbTranslateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTranslateTo.Location = new System.Drawing.Point(310, 134);
            this.txbTranslateTo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTranslateTo.Name = "txbTranslateTo";
            this.txbTranslateTo.Size = new System.Drawing.Size(0, 30);
            this.txbTranslateTo.TabIndex = 3;
            // 
            // txbTranslateToChinese
            // 
            this.txbTranslateToChinese.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTranslateToChinese.Location = new System.Drawing.Point(310, 93);
            this.txbTranslateToChinese.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTranslateToChinese.Name = "txbTranslateToChinese";
            this.txbTranslateToChinese.Size = new System.Drawing.Size(0, 30);
            this.txbTranslateToChinese.TabIndex = 2;
            // 
            // lblTranslateTo
            // 
            this.lblTranslateTo.AutoSize = true;
            this.lblTranslateTo.Location = new System.Drawing.Point(19, 138);
            this.lblTranslateTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateTo.Name = "lblTranslateTo";
            this.lblTranslateTo.Size = new System.Drawing.Size(176, 24);
            this.lblTranslateTo.TabIndex = 1;
            this.lblTranslateTo.Text = "翻译为指定语言命令:";
            // 
            // lblTranslateToChinese
            // 
            this.lblTranslateToChinese.AutoSize = true;
            this.lblTranslateToChinese.Location = new System.Drawing.Point(19, 97);
            this.lblTranslateToChinese.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateToChinese.Name = "lblTranslateToChinese";
            this.lblTranslateToChinese.Size = new System.Drawing.Size(140, 24);
            this.lblTranslateToChinese.TabIndex = 0;
            this.lblTranslateToChinese.Text = "翻译为中文命令:";
            // 
            // chkTranslateEnabled
            // 
            this.chkTranslateEnabled.AutoSize = true;
            this.chkTranslateEnabled.Location = new System.Drawing.Point(14, 11);
            this.chkTranslateEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkTranslateEnabled.Name = "chkTranslateEnabled";
            this.chkTranslateEnabled.Size = new System.Drawing.Size(144, 28);
            this.chkTranslateEnabled.TabIndex = 0;
            this.chkTranslateEnabled.Text = "启用翻译功能";
            this.chkTranslateEnabled.UseVisualStyleBackColor = true;
            this.chkTranslateEnabled.CheckedChanged += new System.EventHandler(this.chkTranslateEnabled_CheckedChanged);
            // 
            // pageRepeater
            // 
            this.pageRepeater.Controls.Add(this.chkReplaceMeToYou);
            this.pageRepeater.Controls.Add(this.chkRewindGif);
            this.pageRepeater.Controls.Add(this.lblRewindGifProbability);
            this.pageRepeater.Controls.Add(this.lblVerticalMirrorImageProbability);
            this.pageRepeater.Controls.Add(this.lblHorizontalMirrorImageProbability);
            this.pageRepeater.Controls.Add(this.lblSuccessiveRepeatCount);
            this.pageRepeater.Controls.Add(this.txbRewindGifProbability);
            this.pageRepeater.Controls.Add(this.lblRandomRepeatProbability);
            this.pageRepeater.Controls.Add(this.txbVerticalMirrorImageProbability);
            this.pageRepeater.Controls.Add(this.txbHorizontalMirrorImageProbability);
            this.pageRepeater.Controls.Add(this.txbSuccessiveRepeatCount);
            this.pageRepeater.Controls.Add(this.txbRandomRepeatProbability);
            this.pageRepeater.Controls.Add(this.chkVerticalMirrorImage);
            this.pageRepeater.Controls.Add(this.chkHorizontalMirrorImage);
            this.pageRepeater.Controls.Add(this.chkSuccessiveRepeat);
            this.pageRepeater.Controls.Add(this.chkRandomRepeat);
            this.pageRepeater.Location = new System.Drawing.Point(4, 33);
            this.pageRepeater.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageRepeater.Name = "pageRepeater";
            this.pageRepeater.Size = new System.Drawing.Size(192, 63);
            this.pageRepeater.TabIndex = 5;
            this.pageRepeater.Text = "复读设置";
            this.pageRepeater.UseVisualStyleBackColor = true;
            // 
            // chkReplaceMeToYou
            // 
            this.chkReplaceMeToYou.AutoSize = true;
            this.chkReplaceMeToYou.Location = new System.Drawing.Point(33, 320);
            this.chkReplaceMeToYou.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkReplaceMeToYou.Name = "chkReplaceMeToYou";
            this.chkReplaceMeToYou.Size = new System.Drawing.Size(230, 28);
            this.chkReplaceMeToYou.TabIndex = 4;
            this.chkReplaceMeToYou.Text = "复读时把\"我\"替换为\"你\"";
            this.chkReplaceMeToYou.UseVisualStyleBackColor = true;
            // 
            // chkRewindGif
            // 
            this.chkRewindGif.AutoSize = true;
            this.chkRewindGif.Location = new System.Drawing.Point(33, 148);
            this.chkRewindGif.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRewindGif.Name = "chkRewindGif";
            this.chkRewindGif.Size = new System.Drawing.Size(96, 28);
            this.chkRewindGif.TabIndex = 3;
            this.chkRewindGif.Text = "倒放Gif";
            this.chkRewindGif.UseVisualStyleBackColor = true;
            // 
            // lblRewindGifProbability
            // 
            this.lblRewindGifProbability.AutoSize = true;
            this.lblRewindGifProbability.Location = new System.Drawing.Point(317, 150);
            this.lblRewindGifProbability.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRewindGifProbability.Name = "lblRewindGifProbability";
            this.lblRewindGifProbability.Size = new System.Drawing.Size(82, 24);
            this.lblRewindGifProbability.TabIndex = 2;
            this.lblRewindGifProbability.Text = "概率为：";
            // 
            // lblVerticalMirrorImageProbability
            // 
            this.lblVerticalMirrorImageProbability.AutoSize = true;
            this.lblVerticalMirrorImageProbability.Location = new System.Drawing.Point(317, 265);
            this.lblVerticalMirrorImageProbability.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVerticalMirrorImageProbability.Name = "lblVerticalMirrorImageProbability";
            this.lblVerticalMirrorImageProbability.Size = new System.Drawing.Size(82, 24);
            this.lblVerticalMirrorImageProbability.TabIndex = 2;
            this.lblVerticalMirrorImageProbability.Text = "概率为：";
            // 
            // lblHorizontalMirrorImageProbability
            // 
            this.lblHorizontalMirrorImageProbability.AutoSize = true;
            this.lblHorizontalMirrorImageProbability.Location = new System.Drawing.Point(317, 209);
            this.lblHorizontalMirrorImageProbability.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHorizontalMirrorImageProbability.Name = "lblHorizontalMirrorImageProbability";
            this.lblHorizontalMirrorImageProbability.Size = new System.Drawing.Size(82, 24);
            this.lblHorizontalMirrorImageProbability.TabIndex = 2;
            this.lblHorizontalMirrorImageProbability.Text = "概率为：";
            // 
            // lblSuccessiveRepeatCount
            // 
            this.lblSuccessiveRepeatCount.AutoSize = true;
            this.lblSuccessiveRepeatCount.Location = new System.Drawing.Point(317, 92);
            this.lblSuccessiveRepeatCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSuccessiveRepeatCount.Name = "lblSuccessiveRepeatCount";
            this.lblSuccessiveRepeatCount.Size = new System.Drawing.Size(82, 24);
            this.lblSuccessiveRepeatCount.TabIndex = 2;
            this.lblSuccessiveRepeatCount.Text = "次数为：";
            // 
            // txbRewindGifProbability
            // 
            this.txbRewindGifProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRewindGifProbability.Location = new System.Drawing.Point(415, 145);
            this.txbRewindGifProbability.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRewindGifProbability.Name = "txbRewindGifProbability";
            this.txbRewindGifProbability.Size = new System.Drawing.Size(0, 30);
            this.txbRewindGifProbability.TabIndex = 1;
            this.txbRewindGifProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRewindGifProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // lblRandomRepeatProbability
            // 
            this.lblRandomRepeatProbability.AutoSize = true;
            this.lblRandomRepeatProbability.Location = new System.Drawing.Point(317, 34);
            this.lblRandomRepeatProbability.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRandomRepeatProbability.Name = "lblRandomRepeatProbability";
            this.lblRandomRepeatProbability.Size = new System.Drawing.Size(82, 24);
            this.lblRandomRepeatProbability.TabIndex = 2;
            this.lblRandomRepeatProbability.Text = "概率为：";
            // 
            // txbVerticalMirrorImageProbability
            // 
            this.txbVerticalMirrorImageProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbVerticalMirrorImageProbability.Location = new System.Drawing.Point(415, 261);
            this.txbVerticalMirrorImageProbability.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbVerticalMirrorImageProbability.Name = "txbVerticalMirrorImageProbability";
            this.txbVerticalMirrorImageProbability.Size = new System.Drawing.Size(0, 30);
            this.txbVerticalMirrorImageProbability.TabIndex = 1;
            this.txbVerticalMirrorImageProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbVerticalMirrorImageProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHorizontalMirrorImageProbability
            // 
            this.txbHorizontalMirrorImageProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHorizontalMirrorImageProbability.Location = new System.Drawing.Point(415, 205);
            this.txbHorizontalMirrorImageProbability.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbHorizontalMirrorImageProbability.Name = "txbHorizontalMirrorImageProbability";
            this.txbHorizontalMirrorImageProbability.Size = new System.Drawing.Size(0, 30);
            this.txbHorizontalMirrorImageProbability.TabIndex = 1;
            this.txbHorizontalMirrorImageProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHorizontalMirrorImageProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbSuccessiveRepeatCount
            // 
            this.txbSuccessiveRepeatCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSuccessiveRepeatCount.Location = new System.Drawing.Point(415, 88);
            this.txbSuccessiveRepeatCount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbSuccessiveRepeatCount.Name = "txbSuccessiveRepeatCount";
            this.txbSuccessiveRepeatCount.Size = new System.Drawing.Size(0, 30);
            this.txbSuccessiveRepeatCount.TabIndex = 1;
            this.txbSuccessiveRepeatCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbSuccessiveRepeatCount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbRandomRepeatProbability
            // 
            this.txbRandomRepeatProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRandomRepeatProbability.Location = new System.Drawing.Point(415, 30);
            this.txbRandomRepeatProbability.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRandomRepeatProbability.Name = "txbRandomRepeatProbability";
            this.txbRandomRepeatProbability.Size = new System.Drawing.Size(0, 30);
            this.txbRandomRepeatProbability.TabIndex = 1;
            this.txbRandomRepeatProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRandomRepeatProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // chkVerticalMirrorImage
            // 
            this.chkVerticalMirrorImage.AutoSize = true;
            this.chkVerticalMirrorImage.Location = new System.Drawing.Point(33, 264);
            this.chkVerticalMirrorImage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkVerticalMirrorImage.Name = "chkVerticalMirrorImage";
            this.chkVerticalMirrorImage.Size = new System.Drawing.Size(180, 28);
            this.chkVerticalMirrorImage.TabIndex = 0;
            this.chkVerticalMirrorImage.Text = "垂直镜像复读图片";
            this.chkVerticalMirrorImage.UseVisualStyleBackColor = true;
            // 
            // chkHorizontalMirrorImage
            // 
            this.chkHorizontalMirrorImage.AutoSize = true;
            this.chkHorizontalMirrorImage.Location = new System.Drawing.Point(33, 208);
            this.chkHorizontalMirrorImage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkHorizontalMirrorImage.Name = "chkHorizontalMirrorImage";
            this.chkHorizontalMirrorImage.Size = new System.Drawing.Size(180, 28);
            this.chkHorizontalMirrorImage.TabIndex = 0;
            this.chkHorizontalMirrorImage.Text = "水平镜像复读图片";
            this.chkHorizontalMirrorImage.UseVisualStyleBackColor = true;
            // 
            // chkSuccessiveRepeat
            // 
            this.chkSuccessiveRepeat.AutoSize = true;
            this.chkSuccessiveRepeat.Location = new System.Drawing.Point(33, 90);
            this.chkSuccessiveRepeat.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkSuccessiveRepeat.Name = "chkSuccessiveRepeat";
            this.chkSuccessiveRepeat.Size = new System.Drawing.Size(108, 28);
            this.chkSuccessiveRepeat.TabIndex = 0;
            this.chkSuccessiveRepeat.Text = "连续复读";
            this.chkSuccessiveRepeat.UseVisualStyleBackColor = true;
            // 
            // chkRandomRepeat
            // 
            this.chkRandomRepeat.AutoSize = true;
            this.chkRandomRepeat.Location = new System.Drawing.Point(33, 32);
            this.chkRandomRepeat.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRandomRepeat.Name = "chkRandomRepeat";
            this.chkRandomRepeat.Size = new System.Drawing.Size(108, 28);
            this.chkRandomRepeat.TabIndex = 0;
            this.chkRandomRepeat.Text = "随机复读";
            this.chkRandomRepeat.UseVisualStyleBackColor = true;
            // 
            // pageGroupMemberEvents
            // 
            this.pageGroupMemberEvents.Controls.Add(this.txbMemberBeKickedMessage);
            this.pageGroupMemberEvents.Controls.Add(this.txbMemberPositiveLeaveMessage);
            this.pageGroupMemberEvents.Controls.Add(this.txbMemberJoinedMessage);
            this.pageGroupMemberEvents.Controls.Add(this.chkSendMemberBeKickedMessage);
            this.pageGroupMemberEvents.Controls.Add(this.chkSendMemberPositiveLeaveMessage);
            this.pageGroupMemberEvents.Controls.Add(this.chkSendMemberJoinedMessage);
            this.pageGroupMemberEvents.Location = new System.Drawing.Point(4, 33);
            this.pageGroupMemberEvents.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageGroupMemberEvents.Name = "pageGroupMemberEvents";
            this.pageGroupMemberEvents.Size = new System.Drawing.Size(192, 63);
            this.pageGroupMemberEvents.TabIndex = 6;
            this.pageGroupMemberEvents.Text = "进/退群提醒";
            this.pageGroupMemberEvents.UseVisualStyleBackColor = true;
            // 
            // txbMemberBeKickedMessage
            // 
            this.txbMemberBeKickedMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMemberBeKickedMessage.Location = new System.Drawing.Point(383, 155);
            this.txbMemberBeKickedMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbMemberBeKickedMessage.Name = "txbMemberBeKickedMessage";
            this.txbMemberBeKickedMessage.Size = new System.Drawing.Size(0, 30);
            this.txbMemberBeKickedMessage.TabIndex = 3;
            // 
            // txbMemberPositiveLeaveMessage
            // 
            this.txbMemberPositiveLeaveMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMemberPositiveLeaveMessage.Location = new System.Drawing.Point(383, 96);
            this.txbMemberPositiveLeaveMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbMemberPositiveLeaveMessage.Name = "txbMemberPositiveLeaveMessage";
            this.txbMemberPositiveLeaveMessage.Size = new System.Drawing.Size(0, 30);
            this.txbMemberPositiveLeaveMessage.TabIndex = 3;
            // 
            // txbMemberJoinedMessage
            // 
            this.txbMemberJoinedMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMemberJoinedMessage.Location = new System.Drawing.Point(383, 37);
            this.txbMemberJoinedMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbMemberJoinedMessage.Name = "txbMemberJoinedMessage";
            this.txbMemberJoinedMessage.Size = new System.Drawing.Size(0, 30);
            this.txbMemberJoinedMessage.TabIndex = 3;
            // 
            // chkSendMemberBeKickedMessage
            // 
            this.chkSendMemberBeKickedMessage.AutoSize = true;
            this.chkSendMemberBeKickedMessage.Location = new System.Drawing.Point(42, 158);
            this.chkSendMemberBeKickedMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkSendMemberBeKickedMessage.Name = "chkSendMemberBeKickedMessage";
            this.chkSendMemberBeKickedMessage.Size = new System.Drawing.Size(180, 28);
            this.chkSendMemberBeKickedMessage.TabIndex = 0;
            this.chkSendMemberBeKickedMessage.Text = "发送群员被踢消息";
            this.chkSendMemberBeKickedMessage.UseVisualStyleBackColor = true;
            // 
            // chkSendMemberPositiveLeaveMessage
            // 
            this.chkSendMemberPositiveLeaveMessage.AutoSize = true;
            this.chkSendMemberPositiveLeaveMessage.Location = new System.Drawing.Point(42, 99);
            this.chkSendMemberPositiveLeaveMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkSendMemberPositiveLeaveMessage.Name = "chkSendMemberPositiveLeaveMessage";
            this.chkSendMemberPositiveLeaveMessage.Size = new System.Drawing.Size(180, 28);
            this.chkSendMemberPositiveLeaveMessage.TabIndex = 0;
            this.chkSendMemberPositiveLeaveMessage.Text = "发送群员退群消息";
            this.chkSendMemberPositiveLeaveMessage.UseVisualStyleBackColor = true;
            // 
            // chkSendMemberJoinedMessage
            // 
            this.chkSendMemberJoinedMessage.AutoSize = true;
            this.chkSendMemberJoinedMessage.Location = new System.Drawing.Point(42, 40);
            this.chkSendMemberJoinedMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkSendMemberJoinedMessage.Name = "chkSendMemberJoinedMessage";
            this.chkSendMemberJoinedMessage.Size = new System.Drawing.Size(180, 28);
            this.chkSendMemberJoinedMessage.TabIndex = 0;
            this.chkSendMemberJoinedMessage.Text = "发送新人入群消息";
            this.chkSendMemberJoinedMessage.UseVisualStyleBackColor = true;
            // 
            // pageForgeMessage
            // 
            this.pageForgeMessage.Controls.Add(this.pnlForgeMessage);
            this.pageForgeMessage.Controls.Add(this.chkEnabledForgeMessage);
            this.pageForgeMessage.Location = new System.Drawing.Point(4, 33);
            this.pageForgeMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageForgeMessage.Name = "pageForgeMessage";
            this.pageForgeMessage.Size = new System.Drawing.Size(192, 63);
            this.pageForgeMessage.TabIndex = 7;
            this.pageForgeMessage.Text = "伪造消息";
            this.pageForgeMessage.UseVisualStyleBackColor = true;
            // 
            // pnlForgeMessage
            // 
            this.pnlForgeMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForgeMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.pnlForgeMessage.Location = new System.Drawing.Point(5, 51);
            this.pnlForgeMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlForgeMessage.Name = "pnlForgeMessage";
            this.pnlForgeMessage.Size = new System.Drawing.Size(178, 0);
            this.pnlForgeMessage.TabIndex = 11;
            // 
            // lblForgeMessageCmd
            // 
            this.lblForgeMessageCmd.AutoSize = true;
            this.lblForgeMessageCmd.Location = new System.Drawing.Point(41, 350);
            this.lblForgeMessageCmd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblForgeMessageCmd.Name = "lblForgeMessageCmd";
            this.lblForgeMessageCmd.Size = new System.Drawing.Size(86, 24);
            this.lblForgeMessageCmd.TabIndex = 13;
            this.lblForgeMessageCmd.Text = "完整命令:";
            // 
            // txbForgeMessageCmd
            // 
            this.txbForgeMessageCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbForgeMessageCmd.BackColor = System.Drawing.SystemColors.Control;
            this.txbForgeMessageCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbForgeMessageCmd.Location = new System.Drawing.Point(146, 347);
            this.txbForgeMessageCmd.Margin = new System.Windows.Forms.Padding(6);
            this.txbForgeMessageCmd.Name = "txbForgeMessageCmd";
            this.txbForgeMessageCmd.ReadOnly = true;
            this.txbForgeMessageCmd.Size = new System.Drawing.Size(24, 30);
            this.txbForgeMessageCmd.TabIndex = 14;
            // 
            // chkForgeMessageAdminDontAppend
            // 
            this.chkForgeMessageAdminDontAppend.AutoSize = true;
            this.chkForgeMessageAdminDontAppend.Location = new System.Drawing.Point(566, 97);
            this.chkForgeMessageAdminDontAppend.Margin = new System.Windows.Forms.Padding(6);
            this.chkForgeMessageAdminDontAppend.Name = "chkForgeMessageAdminDontAppend";
            this.chkForgeMessageAdminDontAppend.Size = new System.Drawing.Size(288, 28);
            this.chkForgeMessageAdminDontAppend.TabIndex = 12;
            this.chkForgeMessageAdminDontAppend.Text = "机器人管理员使用时不追加消息";
            this.chkForgeMessageAdminDontAppend.UseVisualStyleBackColor = true;
            // 
            // chkForgeMessageAdminOnly
            // 
            this.chkForgeMessageAdminOnly.AutoSize = true;
            this.chkForgeMessageAdminOnly.Location = new System.Drawing.Point(322, 97);
            this.chkForgeMessageAdminOnly.Margin = new System.Windows.Forms.Padding(6);
            this.chkForgeMessageAdminOnly.Name = "chkForgeMessageAdminOnly";
            this.chkForgeMessageAdminOnly.Size = new System.Drawing.Size(216, 28);
            this.chkForgeMessageAdminOnly.TabIndex = 12;
            this.chkForgeMessageAdminOnly.Text = "仅限机器人管理员可用";
            this.chkForgeMessageAdminOnly.UseVisualStyleBackColor = true;
            // 
            // chkRefuseForgeBot
            // 
            this.chkRefuseForgeBot.AutoSize = true;
            this.chkRefuseForgeBot.Location = new System.Drawing.Point(41, 265);
            this.chkRefuseForgeBot.Margin = new System.Windows.Forms.Padding(6);
            this.chkRefuseForgeBot.Name = "chkRefuseForgeBot";
            this.chkRefuseForgeBot.Size = new System.Drawing.Size(216, 28);
            this.chkRefuseForgeBot.TabIndex = 12;
            this.chkRefuseForgeBot.Text = "拒绝伪造机器人的消息";
            this.chkRefuseForgeBot.UseVisualStyleBackColor = true;
            // 
            // chkRefuseForgeAdmin
            // 
            this.chkRefuseForgeAdmin.AutoSize = true;
            this.chkRefuseForgeAdmin.Location = new System.Drawing.Point(41, 179);
            this.chkRefuseForgeAdmin.Margin = new System.Windows.Forms.Padding(6);
            this.chkRefuseForgeAdmin.Name = "chkRefuseForgeAdmin";
            this.chkRefuseForgeAdmin.Size = new System.Drawing.Size(270, 28);
            this.chkRefuseForgeAdmin.TabIndex = 12;
            this.chkRefuseForgeAdmin.Text = "拒绝伪造机器人管理员的消息";
            this.chkRefuseForgeAdmin.UseVisualStyleBackColor = true;
            // 
            // lblRefuseForgeBotReply
            // 
            this.lblRefuseForgeBotReply.AutoSize = true;
            this.lblRefuseForgeBotReply.Location = new System.Drawing.Point(41, 309);
            this.lblRefuseForgeBotReply.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRefuseForgeBotReply.Name = "lblRefuseForgeBotReply";
            this.lblRefuseForgeBotReply.Size = new System.Drawing.Size(266, 24);
            this.lblRefuseForgeBotReply.TabIndex = 11;
            this.lblRefuseForgeBotReply.Text = "试图伪造机器人消息时的回复语:";
            // 
            // chkForgeMessageAppendBotMessageEnabled
            // 
            this.chkForgeMessageAppendBotMessageEnabled.AutoSize = true;
            this.chkForgeMessageAppendBotMessageEnabled.Location = new System.Drawing.Point(41, 97);
            this.chkForgeMessageAppendBotMessageEnabled.Margin = new System.Windows.Forms.Padding(6);
            this.chkForgeMessageAppendBotMessageEnabled.Name = "chkForgeMessageAppendBotMessageEnabled";
            this.chkForgeMessageAppendBotMessageEnabled.Size = new System.Drawing.Size(252, 28);
            this.chkForgeMessageAppendBotMessageEnabled.TabIndex = 12;
            this.chkForgeMessageAppendBotMessageEnabled.Text = "在消息末尾追加机器人消息";
            this.chkForgeMessageAppendBotMessageEnabled.UseVisualStyleBackColor = true;
            // 
            // lblRefuseForgeAdminReply
            // 
            this.lblRefuseForgeAdminReply.AutoSize = true;
            this.lblRefuseForgeAdminReply.Location = new System.Drawing.Point(41, 223);
            this.lblRefuseForgeAdminReply.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRefuseForgeAdminReply.Name = "lblRefuseForgeAdminReply";
            this.lblRefuseForgeAdminReply.Size = new System.Drawing.Size(320, 24);
            this.lblRefuseForgeAdminReply.TabIndex = 11;
            this.lblRefuseForgeAdminReply.Text = "试图伪造机器人管理员消息时的回复语:";
            // 
            // txbRefuseForgeBotReply
            // 
            this.txbRefuseForgeBotReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRefuseForgeBotReply.Location = new System.Drawing.Point(388, 305);
            this.txbRefuseForgeBotReply.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRefuseForgeBotReply.Name = "txbRefuseForgeBotReply";
            this.txbRefuseForgeBotReply.Size = new System.Drawing.Size(0, 30);
            this.txbRefuseForgeBotReply.TabIndex = 12;
            // 
            // lblForgeMessageAppendSelfMessage
            // 
            this.lblForgeMessageAppendSelfMessage.AutoSize = true;
            this.lblForgeMessageAppendSelfMessage.Location = new System.Drawing.Point(41, 141);
            this.lblForgeMessageAppendSelfMessage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblForgeMessageAppendSelfMessage.Name = "lblForgeMessageAppendSelfMessage";
            this.lblForgeMessageAppendSelfMessage.Size = new System.Drawing.Size(122, 24);
            this.lblForgeMessageAppendSelfMessage.TabIndex = 11;
            this.lblForgeMessageAppendSelfMessage.Text = "追加消息内容:";
            // 
            // txbRefuseForgeAdminReply
            // 
            this.txbRefuseForgeAdminReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRefuseForgeAdminReply.Location = new System.Drawing.Point(388, 219);
            this.txbRefuseForgeAdminReply.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRefuseForgeAdminReply.Name = "txbRefuseForgeAdminReply";
            this.txbRefuseForgeAdminReply.Size = new System.Drawing.Size(0, 30);
            this.txbRefuseForgeAdminReply.TabIndex = 12;
            // 
            // txbForgeMessageAppendMessage
            // 
            this.txbForgeMessageAppendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbForgeMessageAppendMessage.Location = new System.Drawing.Point(237, 137);
            this.txbForgeMessageAppendMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbForgeMessageAppendMessage.Name = "txbForgeMessageAppendMessage";
            this.txbForgeMessageAppendMessage.Size = new System.Drawing.Size(0, 30);
            this.txbForgeMessageAppendMessage.TabIndex = 12;
            // 
            // lblForgeMessageCmdNewLine
            // 
            this.lblForgeMessageCmdNewLine.AutoSize = true;
            this.lblForgeMessageCmdNewLine.Location = new System.Drawing.Point(41, 59);
            this.lblForgeMessageCmdNewLine.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblForgeMessageCmdNewLine.Name = "lblForgeMessageCmdNewLine";
            this.lblForgeMessageCmdNewLine.Size = new System.Drawing.Size(140, 24);
            this.lblForgeMessageCmdNewLine.TabIndex = 11;
            this.lblForgeMessageCmdNewLine.Text = "伪造消息分行符:";
            // 
            // txbForgeMessageCmdNewLine
            // 
            this.txbForgeMessageCmdNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbForgeMessageCmdNewLine.Location = new System.Drawing.Point(237, 55);
            this.txbForgeMessageCmdNewLine.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbForgeMessageCmdNewLine.Name = "txbForgeMessageCmdNewLine";
            this.txbForgeMessageCmdNewLine.Size = new System.Drawing.Size(0, 30);
            this.txbForgeMessageCmdNewLine.TabIndex = 12;
            // 
            // lblForgeMessageCmdBegin
            // 
            this.lblForgeMessageCmdBegin.AutoSize = true;
            this.lblForgeMessageCmdBegin.Location = new System.Drawing.Point(41, 18);
            this.lblForgeMessageCmdBegin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblForgeMessageCmdBegin.Name = "lblForgeMessageCmdBegin";
            this.lblForgeMessageCmdBegin.Size = new System.Drawing.Size(158, 24);
            this.lblForgeMessageCmdBegin.TabIndex = 9;
            this.lblForgeMessageCmdBegin.Text = "伪造消息命令前缀:";
            // 
            // txbForgeMessageCmdBegin
            // 
            this.txbForgeMessageCmdBegin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbForgeMessageCmdBegin.Location = new System.Drawing.Point(237, 14);
            this.txbForgeMessageCmdBegin.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbForgeMessageCmdBegin.Name = "txbForgeMessageCmdBegin";
            this.txbForgeMessageCmdBegin.Size = new System.Drawing.Size(0, 30);
            this.txbForgeMessageCmdBegin.TabIndex = 10;
            this.txbForgeMessageCmdBegin.TextChanged += new System.EventHandler(this.txbForgeMessageCmd_TextChanged);
            // 
            // chkEnabledForgeMessage
            // 
            this.chkEnabledForgeMessage.AutoSize = true;
            this.chkEnabledForgeMessage.Location = new System.Drawing.Point(14, 11);
            this.chkEnabledForgeMessage.Margin = new System.Windows.Forms.Padding(6);
            this.chkEnabledForgeMessage.Name = "chkEnabledForgeMessage";
            this.chkEnabledForgeMessage.Size = new System.Drawing.Size(180, 28);
            this.chkEnabledForgeMessage.TabIndex = 8;
            this.chkEnabledForgeMessage.Text = "启用伪造消息功能";
            this.chkEnabledForgeMessage.UseVisualStyleBackColor = true;
            this.chkEnabledForgeMessage.CheckedChanged += new System.EventHandler(this.chkEnabledForgeMessage_CheckedChanged);
            // 
            // pageRss
            // 
            this.pageRss.Controls.Add(this.pnlRss);
            this.pageRss.Controls.Add(this.chkRssSendLiveCover);
            this.pageRss.Controls.Add(this.chkRssEnabled);
            this.pageRss.Location = new System.Drawing.Point(4, 33);
            this.pageRss.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageRss.Name = "pageRss";
            this.pageRss.Size = new System.Drawing.Size(192, 63);
            this.pageRss.TabIndex = 8;
            this.pageRss.Text = "RSS转发";
            this.pageRss.UseVisualStyleBackColor = true;
            // 
            // pnlRss
            // 
            this.pnlRss.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRss.Controls.Add(this.chkRssParallel);
            this.pnlRss.Controls.Add(this.pnlRssSubscriptionList);
            this.pnlRss.Controls.Add(this.txbReadRssInterval);
            this.pnlRss.Controls.Add(this.lblReadRssInterval);
            this.pnlRss.Enabled = false;
            this.pnlRss.Location = new System.Drawing.Point(5, 49);
            this.pnlRss.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRss.Name = "pnlRss";
            this.pnlRss.Size = new System.Drawing.Size(177, 0);
            this.pnlRss.TabIndex = 1;
            // 
            // chkRssParallel
            // 
            this.chkRssParallel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRssParallel.AutoSize = true;
            this.chkRssParallel.Location = new System.Drawing.Point(-93, 7);
            this.chkRssParallel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssParallel.Name = "chkRssParallel";
            this.chkRssParallel.Size = new System.Drawing.Size(234, 28);
            this.chkRssParallel.TabIndex = 3;
            this.chkRssParallel.Text = "每条订阅各占用一个线程";
            this.chkRssParallel.UseVisualStyleBackColor = true;
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
            this.pnlRssSubscriptionList.Location = new System.Drawing.Point(36, 45);
            this.pnlRssSubscriptionList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRssSubscriptionList.Name = "pnlRssSubscriptionList";
            this.pnlRssSubscriptionList.Size = new System.Drawing.Size(105, 0);
            this.pnlRssSubscriptionList.TabIndex = 2;
            this.pnlRssSubscriptionList.WrapContents = false;
            this.pnlRssSubscriptionList.SizeChanged += new System.EventHandler(this.pnlRssSubscriptionList_SizeChanged);
            this.pnlRssSubscriptionList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.PnlRssSubscriptionList_ControlChanged);
            this.pnlRssSubscriptionList.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.PnlRssSubscriptionList_ControlChanged);
            // 
            // btnAddRssSubscription
            // 
            this.btnAddRssSubscription.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRssSubscription.Image")));
            this.btnAddRssSubscription.Location = new System.Drawing.Point(5, 4);
            this.btnAddRssSubscription.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAddRssSubscription.Name = "btnAddRssSubscription";
            this.btnAddRssSubscription.Size = new System.Drawing.Size(930, 212);
            this.btnAddRssSubscription.TabIndex = 0;
            this.btnAddRssSubscription.UseVisualStyleBackColor = true;
            this.btnAddRssSubscription.Click += new System.EventHandler(this.btnAddRssSubscription_Click);
            // 
            // txbReadRssInterval
            // 
            this.txbReadRssInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbReadRssInterval.Location = new System.Drawing.Point(266, 4);
            this.txbReadRssInterval.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbReadRssInterval.Name = "txbReadRssInterval";
            this.txbReadRssInterval.Size = new System.Drawing.Size(0, 30);
            this.txbReadRssInterval.TabIndex = 1;
            // 
            // lblReadRssInterval
            // 
            this.lblReadRssInterval.AutoSize = true;
            this.lblReadRssInterval.Location = new System.Drawing.Point(38, 8);
            this.lblReadRssInterval.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReadRssInterval.Name = "lblReadRssInterval";
            this.lblReadRssInterval.Size = new System.Drawing.Size(206, 24);
            this.lblReadRssInterval.TabIndex = 0;
            this.lblReadRssInterval.Text = "获取内容时间间隔(分钟):";
            // 
            // chkRssSendLiveCover
            // 
            this.chkRssSendLiveCover.AutoSize = true;
            this.chkRssSendLiveCover.Location = new System.Drawing.Point(814, 16);
            this.chkRssSendLiveCover.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssSendLiveCover.Name = "chkRssSendLiveCover";
            this.chkRssSendLiveCover.Size = new System.Drawing.Size(191, 28);
            this.chkRssSendLiveCover.TabIndex = 0;
            this.chkRssSendLiveCover.Text = "获取B站直播间封面";
            this.chkRssSendLiveCover.UseVisualStyleBackColor = true;
            this.chkRssSendLiveCover.CheckedChanged += new System.EventHandler(this.chkRssEnabled_CheckedChanged);
            // 
            // chkRssEnabled
            // 
            this.chkRssEnabled.AutoSize = true;
            this.chkRssEnabled.Location = new System.Drawing.Point(14, 11);
            this.chkRssEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssEnabled.Name = "chkRssEnabled";
            this.chkRssEnabled.Size = new System.Drawing.Size(176, 28);
            this.chkRssEnabled.TabIndex = 0;
            this.chkRssEnabled.Text = "启用RSS订阅转发";
            this.chkRssEnabled.UseVisualStyleBackColor = true;
            this.chkRssEnabled.CheckedChanged += new System.EventHandler(this.chkRssEnabled_CheckedChanged);
            // 
            // pageAbout
            // 
            this.pageAbout.Controls.Add(this.lnkPluginsUrl);
            this.pageAbout.Controls.Add(this.lblPlugins);
            this.pageAbout.Controls.Add(this.lblContributorGroup);
            this.pageAbout.Controls.Add(this.txbContributorName);
            this.pageAbout.Controls.Add(this.txbContributorQQ);
            this.pageAbout.Controls.Add(this.lnkProjectUrl);
            this.pageAbout.Controls.Add(this.lnkJoinGroup);
            this.pageAbout.Controls.Add(this.lnkContributorGithub);
            this.pageAbout.Controls.Add(this.lblProjectURL);
            this.pageAbout.Controls.Add(this.lblContributorGithub);
            this.pageAbout.Controls.Add(this.lblContributorQQ);
            this.pageAbout.Controls.Add(this.lblContributorName);
            this.pageAbout.Location = new System.Drawing.Point(4, 33);
            this.pageAbout.Margin = new System.Windows.Forms.Padding(6);
            this.pageAbout.Name = "pageAbout";
            this.pageAbout.Size = new System.Drawing.Size(192, 63);
            this.pageAbout.TabIndex = 2;
            this.pageAbout.Text = "关于";
            this.pageAbout.UseVisualStyleBackColor = true;
            // 
            // lnkPluginsUrl
            // 
            this.lnkPluginsUrl.AutoSize = true;
            this.lnkPluginsUrl.Location = new System.Drawing.Point(182, 308);
            this.lnkPluginsUrl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lnkPluginsUrl.Name = "lnkPluginsUrl";
            this.lnkPluginsUrl.Size = new System.Drawing.Size(503, 24);
            this.lnkPluginsUrl.TabIndex = 6;
            this.lnkPluginsUrl.TabStop = true;
            this.lnkPluginsUrl.Text = "https://github.com/Alex1911-Jiang/GreenOnions.Plugins";
            this.lnkPluginsUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContributorGithub_LinkClicked);
            // 
            // lblPlugins
            // 
            this.lblPlugins.AutoSize = true;
            this.lblPlugins.Location = new System.Drawing.Point(57, 308);
            this.lblPlugins.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlugins.Name = "lblPlugins";
            this.lblPlugins.Size = new System.Drawing.Size(86, 24);
            this.lblPlugins.TabIndex = 5;
            this.lblPlugins.Text = "插件列表:";
            // 
            // lblContributorGroup
            // 
            this.lblContributorGroup.AutoSize = true;
            this.lblContributorGroup.Location = new System.Drawing.Point(57, 157);
            this.lblContributorGroup.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContributorGroup.Name = "lblContributorGroup";
            this.lblContributorGroup.Size = new System.Drawing.Size(62, 24);
            this.lblContributorGroup.TabIndex = 3;
            this.lblContributorGroup.Text = "QQ群:";
            // 
            // txbContributorName
            // 
            this.txbContributorName.BackColor = System.Drawing.Color.White;
            this.txbContributorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbContributorName.Location = new System.Drawing.Point(182, 58);
            this.txbContributorName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbContributorName.Name = "txbContributorName";
            this.txbContributorName.ReadOnly = true;
            this.txbContributorName.Size = new System.Drawing.Size(157, 23);
            this.txbContributorName.TabIndex = 2;
            this.txbContributorName.Text = "Alex1911";
            // 
            // txbContributorQQ
            // 
            this.txbContributorQQ.BackColor = System.Drawing.Color.White;
            this.txbContributorQQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbContributorQQ.Location = new System.Drawing.Point(182, 107);
            this.txbContributorQQ.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbContributorQQ.Name = "txbContributorQQ";
            this.txbContributorQQ.ReadOnly = true;
            this.txbContributorQQ.Size = new System.Drawing.Size(157, 23);
            this.txbContributorQQ.TabIndex = 2;
            this.txbContributorQQ.Text = "774345562";
            // 
            // lnkProjectUrl
            // 
            this.lnkProjectUrl.AutoSize = true;
            this.lnkProjectUrl.Location = new System.Drawing.Point(182, 257);
            this.lnkProjectUrl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lnkProjectUrl.Name = "lnkProjectUrl";
            this.lnkProjectUrl.Size = new System.Drawing.Size(436, 24);
            this.lnkProjectUrl.TabIndex = 1;
            this.lnkProjectUrl.TabStop = true;
            this.lnkProjectUrl.Text = "https://github.com/Alex1911-Jiang/GreenOnions";
            this.lnkProjectUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContributorGithub_LinkClicked);
            // 
            // lnkJoinGroup
            // 
            this.lnkJoinGroup.AutoSize = true;
            this.lnkJoinGroup.Location = new System.Drawing.Point(182, 157);
            this.lnkJoinGroup.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lnkJoinGroup.Name = "lnkJoinGroup";
            this.lnkJoinGroup.Size = new System.Drawing.Size(109, 24);
            this.lnkJoinGroup.TabIndex = 1;
            this.lnkJoinGroup.TabStop = true;
            this.lnkJoinGroup.Text = "550398174";
            this.lnkJoinGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkJoinGroup_LinkClicked);
            // 
            // lnkContributorGithub
            // 
            this.lnkContributorGithub.AutoSize = true;
            this.lnkContributorGithub.Location = new System.Drawing.Point(182, 206);
            this.lnkContributorGithub.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lnkContributorGithub.Name = "lnkContributorGithub";
            this.lnkContributorGithub.Size = new System.Drawing.Size(316, 24);
            this.lnkContributorGithub.TabIndex = 1;
            this.lnkContributorGithub.TabStop = true;
            this.lnkContributorGithub.Text = "https://github.com/Alex1911-Jiang";
            this.lnkContributorGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContributorGithub_LinkClicked);
            // 
            // lblProjectURL
            // 
            this.lblProjectURL.AutoSize = true;
            this.lblProjectURL.Location = new System.Drawing.Point(57, 257);
            this.lblProjectURL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProjectURL.Name = "lblProjectURL";
            this.lblProjectURL.Size = new System.Drawing.Size(86, 24);
            this.lblProjectURL.TabIndex = 0;
            this.lblProjectURL.Text = "项目地址:";
            // 
            // lblContributorGithub
            // 
            this.lblContributorGithub.AutoSize = true;
            this.lblContributorGithub.Location = new System.Drawing.Point(57, 206);
            this.lblContributorGithub.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContributorGithub.Name = "lblContributorGithub";
            this.lblContributorGithub.Size = new System.Drawing.Size(109, 24);
            this.lblContributorGithub.TabIndex = 0;
            this.lblContributorGithub.Text = "Github主页:";
            // 
            // lblContributorQQ
            // 
            this.lblContributorQQ.AutoSize = true;
            this.lblContributorQQ.Location = new System.Drawing.Point(57, 107);
            this.lblContributorQQ.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContributorQQ.Name = "lblContributorQQ";
            this.lblContributorQQ.Size = new System.Drawing.Size(44, 24);
            this.lblContributorQQ.TabIndex = 0;
            this.lblContributorQQ.Text = "QQ:";
            // 
            // lblContributorName
            // 
            this.lblContributorName.AutoSize = true;
            this.lblContributorName.Location = new System.Drawing.Point(57, 58);
            this.lblContributorName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContributorName.Name = "lblContributorName";
            this.lblContributorName.Size = new System.Drawing.Size(50, 24);
            this.lblContributorName.TabIndex = 0;
            this.lblContributorName.Text = "作者:";
            // 
            // FrmAppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 1074);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.btnOk);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用设置";
            this.tabSettings.ResumeLayout(false);
            this.pageBot.ResumeLayout(false);
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            this.pnlWorkingTime.ResumeLayout(false);
            this.pnlWorkingTime.PerformLayout();
            this.pnlAutoConnect.ResumeLayout(false);
            this.pnlAutoConnect.PerformLayout();
            this.pnlDebugMode.ResumeLayout(false);
            this.pnlDebugMode.PerformLayout();
            this.pnlCheckPorn.ResumeLayout(false);
            this.pnlCheckPorn.PerformLayout();
            this.pageSearchPicture.ResumeLayout(false);
            this.pnlSearchPictureEnabled.ResumeLayout(false);
            this.pnlSearchPictureEnabled.PerformLayout();
            this.pageOriginalPicture.ResumeLayout(false);
            this.pnlOriginalPictureEnabled.ResumeLayout(false);
            this.pnlOriginalPictureEnabled.PerformLayout();
            this.pageHPicture.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pageTranslate.ResumeLayout(false);
            this.pageTranslate.PerformLayout();
            this.pnlTranslate.ResumeLayout(false);
            this.pnlTranslate.PerformLayout();
            this.pageRepeater.ResumeLayout(false);
            this.pageRepeater.PerformLayout();
            this.pageGroupMemberEvents.ResumeLayout(false);
            this.pageGroupMemberEvents.PerformLayout();
            this.pageForgeMessage.ResumeLayout(false);
            this.pageForgeMessage.PerformLayout();
            this.pnlForgeMessage.ResumeLayout(false);
            this.pnlForgeMessage.PerformLayout();
            this.pageRss.ResumeLayout(false);
            this.pageRss.PerformLayout();
            this.pnlRss.ResumeLayout(false);
            this.pnlRss.PerformLayout();
            this.pnlRssSubscriptionList.ResumeLayout(false);
            this.pageAbout.ResumeLayout(false);
            this.pageAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbBotName;
        private System.Windows.Forms.Label lblBotName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txbAddAdmin;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage pageBot;
        private System.Windows.Forms.TabPage pageHPicture;
        private System.Windows.Forms.ListView lstAdmins;
        private System.Windows.Forms.Button btnAddAdmin;
        private System.Windows.Forms.Label lblAddAdmin;
        private System.Windows.Forms.CheckBox chkHPictureEnabled;
        private System.Windows.Forms.Button btnRemoveAdmin;
        private System.Windows.Forms.TabPage pageAbout;
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
        private System.Windows.Forms.TabPage pageSearchPicture;
        private System.Windows.Forms.CheckBox chkSearchPictureEnabled;
        private System.Windows.Forms.TabPage pageTranslate;
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
        private System.Windows.Forms.LinkLabel lnkProjectUrl;
        private System.Windows.Forms.Label lblProjectURL;
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
        private System.Windows.Forms.TabPage pageRepeater;
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
        private System.Windows.Forms.TabPage pageGroupMemberEvents;
        private System.Windows.Forms.TextBox txbMemberJoinedMessage;
        private System.Windows.Forms.CheckBox chkSendMemberBeKickedMessage;
        private System.Windows.Forms.CheckBox chkSendMemberPositiveLeaveMessage;
        private System.Windows.Forms.CheckBox chkSendMemberJoinedMessage;
        private System.Windows.Forms.TextBox txbMemberBeKickedMessage;
        private System.Windows.Forms.TextBox txbMemberPositiveLeaveMessage;
        private System.Windows.Forms.TextBox txbAddAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.Button btnRemoveAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.Button btnAddAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.ListView lstAutoTranslateGroupMemoriesQQ;
        private System.Windows.Forms.Label lblAddAutoTranslateGroupMemoryQQ;
        private System.Windows.Forms.Label lblAutoTranslateGroupMemoriesQQ;
        private System.Windows.Forms.TabPage pageForgeMessage;
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
        private System.Windows.Forms.Label lblForgeMessageCmd;
        private System.Windows.Forms.TextBox txbForgeMessageCmd;
        private System.Windows.Forms.TabPage pageRss;
        private System.Windows.Forms.CheckBox chkRssEnabled;
        private System.Windows.Forms.Panel pnlRss;
        private System.Windows.Forms.TextBox txbReadRssInterval;
        private System.Windows.Forms.Label lblReadRssInterval;
        private System.Windows.Forms.FlowLayoutPanel pnlRssSubscriptionList;
        private System.Windows.Forms.Button btnAddRssSubscription;
        private System.Windows.Forms.Label lblTranslateEngineHelp;
        private System.Windows.Forms.ComboBox cboTranslateEngine;
        private System.Windows.Forms.Label lblTranslateEngine;
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
        private System.Windows.Forms.CheckBox chkCheckPornEnabled;
        private System.Windows.Forms.TabPage pageOriginalPicture;
        private System.Windows.Forms.CheckBox chkOriginalPictureEnabled;
        private System.Windows.Forms.CheckBox chkReplaceMeToYou;
        private System.Windows.Forms.CheckBox chkHttpRequestByWebBrowser;
        private System.Windows.Forms.TextBox txbTranslateFromToCMD;
        private System.Windows.Forms.Label lblTranslateFromTo;
        private System.Windows.Forms.Label lblLogLevel;
        private System.Windows.Forms.ComboBox cboLogLevel;
        private System.Windows.Forms.Label lblContributorGroup;
        private System.Windows.Forms.CheckBox chkAutoConnectEnabled;
        private System.Windows.Forms.Panel pnlAutoConnect;
        private System.Windows.Forms.Label lblAutoConnectDelay;
        private System.Windows.Forms.Label lblAutoConnectProtocol;
        private System.Windows.Forms.TextBox txbAutoConnectDelay;
        private System.Windows.Forms.ComboBox cboAutoConnectProtocol;
        private System.Windows.Forms.CheckBox chkRssSendLiveCover;
        private System.Windows.Forms.CheckBox chkDownloadImage4Caching;
        private System.Windows.Forms.CheckBox chkSendImageByFile;
        private System.Windows.Forms.ComboBox cboReplaceImgRoute;
        private System.Windows.Forms.Label lblReplaceImgRoute;
        private System.Windows.Forms.CheckBox chkRssParallel;
        private System.Windows.Forms.ComboBox cboPixivProxy;
        private System.Windows.Forms.Label lblPixivProxy;
        private System.Windows.Forms.Label lblWorkingTime;
        private System.Windows.Forms.CheckBox chkWorkingTimeEnabled;
        private System.Windows.Forms.Panel pnlWorkingTime;
        private System.Windows.Forms.Label lblWorkingTimeToMinute;
        private System.Windows.Forms.Label lblWorkingTimeFromMinute;
        private System.Windows.Forms.Label lblWorkingTimeToHour;
        private System.Windows.Forms.Label lblWorkingTimeFromHour;
        private System.Windows.Forms.Label lblWorkingTimeTo;
        private System.Windows.Forms.Label lblWorkingTimeFrom;
        private System.Windows.Forms.ComboBox cboWorkingTimeFromHour;
        private System.Windows.Forms.ComboBox cboWorkingTimeToHour;
        private System.Windows.Forms.ComboBox cboWorkingTimeToMinute;
        private System.Windows.Forms.ComboBox cboWorkingTimeFromMinute;
        private LinkLabel lnkPluginsUrl;
        private Label lblPlugins;
        private LinkLabel lnkJoinGroup;
        private Controls.CtrlSearchPicture pnlSearchPicture;
        private Controls.CtrlOriginalPicture pnlOriginalPicture;
        private Controls.CtrlHPicture pnlHPicture;
        private Panel pnlSearchPictureEnabled;
        private Panel pnlOriginalPictureEnabled;
        private Panel panel1;
    }
}