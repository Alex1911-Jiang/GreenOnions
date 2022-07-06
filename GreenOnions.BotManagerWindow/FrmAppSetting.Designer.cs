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
            this.lblCheckPornLimitCountInfo = new System.Windows.Forms.Label();
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
            this.chkSearchPictureEnabled = new System.Windows.Forms.CheckBox();
            this.pnlSearchPicture = new System.Windows.Forms.Panel();
            this.cboSearchShowAscii2dCount = new System.Windows.Forms.ComboBox();
            this.lblSearchShowAscii2dCount = new System.Windows.Forms.Label();
            this.lblSearchingReply = new System.Windows.Forms.Label();
            this.txbSearchingReply = new System.Windows.Forms.TextBox();
            this.chkPmAutoSearch = new System.Windows.Forms.CheckBox();
            this.pnlSearchSauceNAO = new System.Windows.Forms.Panel();
            this.chkSearchSauceNAOSortByDesc = new System.Windows.Forms.CheckBox();
            this.lblSauceNAOApiKey = new System.Windows.Forms.Label();
            this.chkSearchSauceNAOSendPixivOriginalPicture = new System.Windows.Forms.CheckBox();
            this.txbSearchSauceNAOApiKey = new System.Windows.Forms.TextBox();
            this.lblSearchSauceNAOHighSimilarity = new System.Windows.Forms.Label();
            this.txbSearchSauceNAOLowSimilarity = new System.Windows.Forms.TextBox();
            this.txbSearchSauceNAOHighSimilarity = new System.Windows.Forms.TextBox();
            this.txbSearchLowSimilarityReply = new System.Windows.Forms.TextBox();
            this.lblSearchSauceNAOLowSimilarity = new System.Windows.Forms.Label();
            this.lblSearchSauceNAOLowSimilarityInfo = new System.Windows.Forms.Label();
            this.lblSearchSauceNAOHighSimilarityInfo = new System.Windows.Forms.Label();
            this.lblSearchLowSimilarityReply = new System.Windows.Forms.Label();
            this.lblSauceNAOApiKeyInfo = new System.Windows.Forms.Label();
            this.lblSearchDownloadThuImageFailReply = new System.Windows.Forms.Label();
            this.txbSearchDownloadThuImageFailReply = new System.Windows.Forms.TextBox();
            this.chkSearchSendByForward = new System.Windows.Forms.CheckBox();
            this.chkSauceNaoRequestByWebBrowser = new System.Windows.Forms.CheckBox();
            this.chkASCII2DRequestByWebBrowser = new System.Windows.Forms.CheckBox();
            this.pnlPictureSearcherCheckPorn = new System.Windows.Forms.Panel();
            this.lblSearchCheckPornOutOfLimitReply = new System.Windows.Forms.Label();
            this.txbSearchCheckPornOutOfLimitReply = new System.Windows.Forms.TextBox();
            this.txbSearchCheckPornIllegalReply = new System.Windows.Forms.TextBox();
            this.lblSearchCheckPornIllegalReply = new System.Windows.Forms.Label();
            this.lblSearchCheckPornErrorReply = new System.Windows.Forms.Label();
            this.txbSearchCheckPornErrorReply = new System.Windows.Forms.TextBox();
            this.chkSearchCheckPornEnabled = new System.Windows.Forms.CheckBox();
            this.chkSearchTraceMoeEnabled = new System.Windows.Forms.CheckBox();
            this.lblSearchErrorReply = new System.Windows.Forms.Label();
            this.lblSearchNoResultReply = new System.Windows.Forms.Label();
            this.lblSearchModeAlreadyOffReply = new System.Windows.Forms.Label();
            this.lblSearchModeTimeOutReply = new System.Windows.Forms.Label();
            this.lblSearchModeOffCmd = new System.Windows.Forms.Label();
            this.lblSearchModeOffReply = new System.Windows.Forms.Label();
            this.lblSearchModeAlreadyOnReply = new System.Windows.Forms.Label();
            this.lblSearchModeOnReply = new System.Windows.Forms.Label();
            this.lblTraceMoeSendThresholdInfo = new System.Windows.Forms.Label();
            this.lblTraceMoeSendThreshold = new System.Windows.Forms.Label();
            this.lblSearchModeOnCmd = new System.Windows.Forms.Label();
            this.txbSearchErrorReply = new System.Windows.Forms.TextBox();
            this.txbSearchNoResultReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeTimeOutReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeOffCmd = new System.Windows.Forms.TextBox();
            this.txbSearchModeAlreadyOffReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeOffReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeAlreadyOnReply = new System.Windows.Forms.TextBox();
            this.txbTraceMoeSendThreshold = new System.Windows.Forms.TextBox();
            this.txbSearchModeOnReply = new System.Windows.Forms.TextBox();
            this.txbSearchModeOnCmd = new System.Windows.Forms.TextBox();
            this.chkSearchASCII2DEnabled = new System.Windows.Forms.CheckBox();
            this.chkSearchSauceNAOEnabled = new System.Windows.Forms.CheckBox();
            this.pageOriginalPicture = new System.Windows.Forms.TabPage();
            this.lblOriginalPictureCommand = new System.Windows.Forms.Label();
            this.txbOriginalPictureCommand = new System.Windows.Forms.TextBox();
            this.pnlOriginalPicture = new System.Windows.Forms.Panel();
            this.chkOriginalPictureCheckPornEnabled = new System.Windows.Forms.CheckBox();
            this.pnlOriginalPictureCheckPorn = new System.Windows.Forms.Panel();
            this.pnlOriginalPictureCheckPornMessage = new System.Windows.Forms.Panel();
            this.lblOriginalPictureCheckPornIllegalReply = new System.Windows.Forms.Label();
            this.txbOriginalPictureCheckPornErrorReply = new System.Windows.Forms.TextBox();
            this.txbOriginalPictureCheckPornIllegalReply = new System.Windows.Forms.TextBox();
            this.lblOriginalPictureCheckPornErrorReply = new System.Windows.Forms.Label();
            this.pnlOriginalPictureCheckPornEvent = new System.Windows.Forms.Panel();
            this.rdoOriginalPictureCheckPornSendByForward = new System.Windows.Forms.RadioButton();
            this.rdoOriginalPictureCheckPornDoNothing = new System.Windows.Forms.RadioButton();
            this.rdoOriginalPictureCheckPornReply = new System.Windows.Forms.RadioButton();
            this.lblOriginalPictureCheckPornEvent = new System.Windows.Forms.Label();
            this.chkOriginalPictureEnabled = new System.Windows.Forms.CheckBox();
            this.pageHPicture = new System.Windows.Forms.TabPage();
            this.pnlHPictureEnabeled = new System.Windows.Forms.Panel();
            this.chkHPictureSendByForward = new System.Windows.Forms.CheckBox();
            this.chkHPictureSendTags = new System.Windows.Forms.CheckBox();
            this.chkHPictureSendUrl = new System.Windows.Forms.CheckBox();
            this.pnlHPictureCheckBoxes = new System.Windows.Forms.Panel();
            this.lnkResetHPicture = new System.Windows.Forms.LinkLabel();
            this.chkHPictureSize1200 = new System.Windows.Forms.CheckBox();
            this.chkRevokeBeautyPicture = new System.Windows.Forms.CheckBox();
            this.lblHPictureOnceMessageMaxImageCountHelp = new System.Windows.Forms.Label();
            this.txbHPictureOnceMessageMaxImageCount = new System.Windows.Forms.TextBox();
            this.lblHPictureOnceMessageMaxImageCount = new System.Windows.Forms.Label();
            this.lblBeautyPictureSource = new System.Windows.Forms.Label();
            this.lblHPictureSource = new System.Windows.Forms.Label();
            this.chkEnabledGreenOnionsBeautyPicture = new System.Windows.Forms.CheckBox();
            this.chkHPictureEnabledGreenOnionsSource = new System.Windows.Forms.CheckBox();
            this.chkEnabledELFBeautyPicture = new System.Windows.Forms.CheckBox();
            this.chkHPictureEnabledLoliconSource = new System.Windows.Forms.CheckBox();
            this.rodHPictureLimitCount = new System.Windows.Forms.RadioButton();
            this.rdoHPictureLimitFrequency = new System.Windows.Forms.RadioButton();
            this.txbAddToWhiteGroup = new System.Windows.Forms.TextBox();
            this.txbUserHPictureCmd = new System.Windows.Forms.TextBox();
            this.txbHPicturePMCD = new System.Windows.Forms.TextBox();
            this.txbHPictureWhiteCD = new System.Windows.Forms.TextBox();
            this.txbHPicturePMRevoke = new System.Windows.Forms.TextBox();
            this.txbHPictureWhiteRevoke = new System.Windows.Forms.TextBox();
            this.lstHPictureUserCmd = new System.Windows.Forms.ListView();
            this.lstHPictureWhiteGroup = new System.Windows.Forms.ListView();
            this.lblPMRevoke = new System.Windows.Forms.Label();
            this.lblWhiteRevoke = new System.Windows.Forms.Label();
            this.lblPMCD = new System.Windows.Forms.Label();
            this.lblWhiteCD = new System.Windows.Forms.Label();
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
            this.txbHPictureOutOfLimitReply = new System.Windows.Forms.TextBox();
            this.txbHPictureCDUnreadyReply = new System.Windows.Forms.TextBox();
            this.txbHPictureCD = new System.Windows.Forms.TextBox();
            this.txbHPictureLimit = new System.Windows.Forms.TextBox();
            this.txbHPictureRevoke = new System.Windows.Forms.TextBox();
            this.chkHPictureAllowR18 = new System.Windows.Forms.CheckBox();
            this.chkHPictureAdminNoLimit = new System.Windows.Forms.CheckBox();
            this.chkHPictureWhiteNoLimit = new System.Windows.Forms.CheckBox();
            this.chkHPicturePMNoLimit = new System.Windows.Forms.CheckBox();
            this.chkHPictureR18WhiteOnly = new System.Windows.Forms.CheckBox();
            this.chkHPictureWhiteOnly = new System.Windows.Forms.CheckBox();
            this.chkHPictureAllowPM = new System.Windows.Forms.CheckBox();
            this.lblUserCmdInformation = new System.Windows.Forms.Label();
            this.lblAddToWhiteGroupInformation = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.lblLoliconHPictureCmd = new System.Windows.Forms.Label();
            this.btnRemoveWhiteGroup = new System.Windows.Forms.Button();
            this.btnAddToWhiteGroup = new System.Windows.Forms.Button();
            this.btnRemoveUserHPictureCmd = new System.Windows.Forms.Button();
            this.btnAddUserHPictureCmd = new System.Windows.Forms.Button();
            this.lblUserHPictureCmd = new System.Windows.Forms.Label();
            this.lblLimitType = new System.Windows.Forms.Label();
            this.lblUserCmd = new System.Windows.Forms.Label();
            this.txbHPictureCmd = new System.Windows.Forms.TextBox();
            this.txbHPictureApiKey = new System.Windows.Forms.TextBox();
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
            this.pnlRssSubscriptionList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRssSubscription = new System.Windows.Forms.Button();
            this.txbReadRssInterval = new System.Windows.Forms.TextBox();
            this.lblReadRssInterval = new System.Windows.Forms.Label();
            this.chkRssSendLiveCover = new System.Windows.Forms.CheckBox();
            this.chkRssEnabled = new System.Windows.Forms.CheckBox();
            this.pageTicTacToe = new System.Windows.Forms.TabPage();
            this.pnlTicTacToe = new System.Windows.Forms.Panel();
            this.lblTicTacToeMoveFailReply = new System.Windows.Forms.Label();
            this.txbTicTacToeMoveFailReply = new System.Windows.Forms.TextBox();
            this.lblChessboard = new System.Windows.Forms.Label();
            this.imgChessboard = new System.Windows.Forms.Panel();
            this.lblTicTacToeIllegalMoveReply = new System.Windows.Forms.Label();
            this.txbTicTacToeIllegalMoveReply = new System.Windows.Forms.TextBox();
            this.lblTicTacToeNoMoveReply = new System.Windows.Forms.Label();
            this.txbTicTacToeNoMoveReply = new System.Windows.Forms.TextBox();
            this.lblTicTacToeDrawReply = new System.Windows.Forms.Label();
            this.lblTicTacToeBotWinReply = new System.Windows.Forms.Label();
            this.lblTicTacToePlayerWinReply = new System.Windows.Forms.Label();
            this.txbTicTacToeDrawReply = new System.Windows.Forms.TextBox();
            this.txbTicTacToeBotWinReply = new System.Windows.Forms.TextBox();
            this.lblTicTacToeTimeoutReply = new System.Windows.Forms.Label();
            this.txbTicTacToePlayerWinReply = new System.Windows.Forms.TextBox();
            this.txbTicTacToeTimeoutReply = new System.Windows.Forms.TextBox();
            this.pnlTicTacToeMoveMode = new System.Windows.Forms.Panel();
            this.chkTicTacToeMoveModeOpenCV = new System.Windows.Forms.CheckBox();
            this.chkTicTacToeMoveModeNomenclature = new System.Windows.Forms.CheckBox();
            this.txbTicTacToeAlreadStopReply = new System.Windows.Forms.TextBox();
            this.txbTicTacToeStoppedReply = new System.Windows.Forms.TextBox();
            this.txbStopTicTacToeCmd = new System.Windows.Forms.TextBox();
            this.txbTicTacToeAlreadyStartReply = new System.Windows.Forms.TextBox();
            this.txbTicTacToeStartedReply = new System.Windows.Forms.TextBox();
            this.txbStartTicTacToeCmd = new System.Windows.Forms.TextBox();
            this.lblTicTacToeMoveMode = new System.Windows.Forms.Label();
            this.lblTicTacToeAlreadStopReply = new System.Windows.Forms.Label();
            this.lblTicTacToeStartedReply = new System.Windows.Forms.Label();
            this.lblTicTacToeStoppedReply = new System.Windows.Forms.Label();
            this.lblTicTacToeAlreadyStartReply = new System.Windows.Forms.Label();
            this.lblStopTicTacToeCmd = new System.Windows.Forms.Label();
            this.lblStartTicTacToeCmd = new System.Windows.Forms.Label();
            this.chkTicTacToeEnabled = new System.Windows.Forms.CheckBox();
            this.pageAbout = new System.Windows.Forms.TabPage();
            this.txbContributorGroup = new System.Windows.Forms.TextBox();
            this.lblContributorGroup = new System.Windows.Forms.Label();
            this.txbContributorName = new System.Windows.Forms.TextBox();
            this.txbContributorQQ = new System.Windows.Forms.TextBox();
            this.lnkProjectURL = new System.Windows.Forms.LinkLabel();
            this.lnkContributorGithub = new System.Windows.Forms.LinkLabel();
            this.lblProjectURL = new System.Windows.Forms.Label();
            this.lblContributorGithub = new System.Windows.Forms.Label();
            this.lblContributorQQ = new System.Windows.Forms.Label();
            this.lblContributorName = new System.Windows.Forms.Label();
            this.cboReplaceImgRoute = new System.Windows.Forms.ComboBox();
            this.lblReplaceImgRoute = new System.Windows.Forms.Label();
            this.txbSearchAnimeModeOnCmd = new System.Windows.Forms.TextBox();
            this.lblSearchAnimeModeOnCmd = new System.Windows.Forms.Label();
            this.tabSettings.SuspendLayout();
            this.pageBot.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.pnlAutoConnect.SuspendLayout();
            this.pnlDebugMode.SuspendLayout();
            this.pnlCheckPorn.SuspendLayout();
            this.pageSearchPicture.SuspendLayout();
            this.pnlSearchPicture.SuspendLayout();
            this.pnlSearchSauceNAO.SuspendLayout();
            this.pnlPictureSearcherCheckPorn.SuspendLayout();
            this.pageOriginalPicture.SuspendLayout();
            this.pnlOriginalPicture.SuspendLayout();
            this.pnlOriginalPictureCheckPorn.SuspendLayout();
            this.pnlOriginalPictureCheckPornMessage.SuspendLayout();
            this.pnlOriginalPictureCheckPornEvent.SuspendLayout();
            this.pageHPicture.SuspendLayout();
            this.pnlHPictureEnabeled.SuspendLayout();
            this.pnlHPictureCheckBoxes.SuspendLayout();
            this.pageTranslate.SuspendLayout();
            this.pnlTranslate.SuspendLayout();
            this.pageRepeater.SuspendLayout();
            this.pageGroupMemberEvents.SuspendLayout();
            this.pageForgeMessage.SuspendLayout();
            this.pnlForgeMessage.SuspendLayout();
            this.pageRss.SuspendLayout();
            this.pnlRss.SuspendLayout();
            this.pnlRssSubscriptionList.SuspendLayout();
            this.pageTicTacToe.SuspendLayout();
            this.pnlTicTacToe.SuspendLayout();
            this.pnlTicTacToeMoveMode.SuspendLayout();
            this.pageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDownloadImage4Caching
            // 
            this.chkDownloadImage4Caching.AutoSize = true;
            this.chkDownloadImage4Caching.Location = new System.Drawing.Point(3, 512);
            this.chkDownloadImage4Caching.Name = "chkDownloadImage4Caching";
            this.chkDownloadImage4Caching.Size = new System.Drawing.Size(183, 21);
            this.chkDownloadImage4Caching.TabIndex = 42;
            this.chkDownloadImage4Caching.Text = "保留所有下载的图片用于缓存";
            this.chkDownloadImage4Caching.UseVisualStyleBackColor = true;
            // 
            // chkSendImageByFile
            // 
            this.chkSendImageByFile.AutoSize = true;
            this.chkSendImageByFile.Location = new System.Drawing.Point(3, 539);
            this.chkSendImageByFile.Name = "chkSendImageByFile";
            this.chkSendImageByFile.Size = new System.Drawing.Size(532, 21);
            this.chkSendImageByFile.TabIndex = 41;
            this.chkSendImageByFile.Text = "所有图片下载到本地再发送文件 (解决网络环境不佳导致将地址交由平台发送会TimeOut的问题)";
            this.chkSendImageByFile.UseVisualStyleBackColor = true;
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
            this.tabSettings.Controls.Add(this.pageTicTacToe);
            this.tabSettings.Controls.Add(this.pageAbout);
            this.tabSettings.Location = new System.Drawing.Point(14, 8);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(660, 717);
            this.tabSettings.TabIndex = 4;
            // 
            // pageBot
            // 
            this.pageBot.Controls.Add(this.pnlBot);
            this.pageBot.Location = new System.Drawing.Point(4, 26);
            this.pageBot.Margin = new System.Windows.Forms.Padding(4);
            this.pageBot.Name = "pageBot";
            this.pageBot.Padding = new System.Windows.Forms.Padding(4);
            this.pageBot.Size = new System.Drawing.Size(652, 687);
            this.pageBot.TabIndex = 1;
            this.pageBot.Text = "机器人设置";
            this.pageBot.UseVisualStyleBackColor = true;
            // 
            // pnlBot
            // 
            this.pnlBot.AutoScroll = true;
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
            this.pnlBot.Location = new System.Drawing.Point(4, 4);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(644, 679);
            this.pnlBot.TabIndex = 36;
            // 
            // pnlAutoConnect
            // 
            this.pnlAutoConnect.Controls.Add(this.txbAutoConnectDelay);
            this.pnlAutoConnect.Controls.Add(this.cboAutoConnectProtocol);
            this.pnlAutoConnect.Controls.Add(this.lblAutoConnectDelay);
            this.pnlAutoConnect.Controls.Add(this.lblAutoConnectProtocol);
            this.pnlAutoConnect.Enabled = false;
            this.pnlAutoConnect.Location = new System.Drawing.Point(0, 800);
            this.pnlAutoConnect.MinimumSize = new System.Drawing.Size(620, 0);
            this.pnlAutoConnect.Name = "pnlAutoConnect";
            this.pnlAutoConnect.Size = new System.Drawing.Size(620, 62);
            this.pnlAutoConnect.TabIndex = 40;
            // 
            // txbAutoConnectDelay
            // 
            this.txbAutoConnectDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAutoConnectDelay.Location = new System.Drawing.Point(116, 34);
            this.txbAutoConnectDelay.Name = "txbAutoConnectDelay";
            this.txbAutoConnectDelay.Size = new System.Drawing.Size(200, 23);
            this.txbAutoConnectDelay.TabIndex = 50;
            // 
            // cboAutoConnectProtocol
            // 
            this.cboAutoConnectProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutoConnectProtocol.FormattingEnabled = true;
            this.cboAutoConnectProtocol.Items.AddRange(new object[] {
            "Mirai-Api-Http",
            "CqHttp(OneBot)"});
            this.cboAutoConnectProtocol.Location = new System.Drawing.Point(116, 3);
            this.cboAutoConnectProtocol.Name = "cboAutoConnectProtocol";
            this.cboAutoConnectProtocol.Size = new System.Drawing.Size(200, 25);
            this.cboAutoConnectProtocol.TabIndex = 39;
            // 
            // lblAutoConnectDelay
            // 
            this.lblAutoConnectDelay.AutoSize = true;
            this.lblAutoConnectDelay.Location = new System.Drawing.Point(3, 37);
            this.lblAutoConnectDelay.Name = "lblAutoConnectDelay";
            this.lblAutoConnectDelay.Size = new System.Drawing.Size(91, 17);
            this.lblAutoConnectDelay.TabIndex = 1;
            this.lblAutoConnectDelay.Text = "连接前延时(秒):";
            // 
            // lblAutoConnectProtocol
            // 
            this.lblAutoConnectProtocol.AutoSize = true;
            this.lblAutoConnectProtocol.Location = new System.Drawing.Point(3, 6);
            this.lblAutoConnectProtocol.Name = "lblAutoConnectProtocol";
            this.lblAutoConnectProtocol.Size = new System.Drawing.Size(83, 17);
            this.lblAutoConnectProtocol.TabIndex = 0;
            this.lblAutoConnectProtocol.Text = "自动连接平台:";
            // 
            // chkAutoConnectEnabled
            // 
            this.chkAutoConnectEnabled.AutoSize = true;
            this.chkAutoConnectEnabled.Location = new System.Drawing.Point(3, 773);
            this.chkAutoConnectEnabled.Name = "chkAutoConnectEnabled";
            this.chkAutoConnectEnabled.Size = new System.Drawing.Size(147, 21);
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
            this.cboLogLevel.Location = new System.Drawing.Point(116, 868);
            this.cboLogLevel.Name = "cboLogLevel";
            this.cboLogLevel.Size = new System.Drawing.Size(200, 25);
            this.cboLogLevel.TabIndex = 38;
            // 
            // lblLogLevel
            // 
            this.lblLogLevel.AutoSize = true;
            this.lblLogLevel.Location = new System.Drawing.Point(3, 871);
            this.lblLogLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogLevel.Name = "lblLogLevel";
            this.lblLogLevel.Size = new System.Drawing.Size(68, 17);
            this.lblLogLevel.TabIndex = 37;
            this.lblLogLevel.Text = "日志级别：";
            // 
            // chkHttpRequestByWebBrowser
            // 
            this.chkHttpRequestByWebBrowser.AutoSize = true;
            this.chkHttpRequestByWebBrowser.Location = new System.Drawing.Point(3, 454);
            this.chkHttpRequestByWebBrowser.Name = "chkHttpRequestByWebBrowser";
            this.chkHttpRequestByWebBrowser.Size = new System.Drawing.Size(269, 21);
            this.chkHttpRequestByWebBrowser.TabIndex = 36;
            this.chkHttpRequestByWebBrowser.Text = "允许调用浏览器执行Http请求(仅限Windows)";
            this.chkHttpRequestByWebBrowser.UseVisualStyleBackColor = true;
            // 
            // chkCheckPornEnabled
            // 
            this.chkCheckPornEnabled.AutoSize = true;
            this.chkCheckPornEnabled.Location = new System.Drawing.Point(3, 566);
            this.chkCheckPornEnabled.Name = "chkCheckPornEnabled";
            this.chkCheckPornEnabled.Size = new System.Drawing.Size(111, 21);
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
            this.pnlDebugMode.Location = new System.Drawing.Point(0, 925);
            this.pnlDebugMode.MinimumSize = new System.Drawing.Size(620, 153);
            this.pnlDebugMode.Name = "pnlDebugMode";
            this.pnlDebugMode.Size = new System.Drawing.Size(620, 153);
            this.pnlDebugMode.TabIndex = 12;
            // 
            // chkOnlyReplyDebugGroup
            // 
            this.chkOnlyReplyDebugGroup.AutoSize = true;
            this.chkOnlyReplyDebugGroup.Location = new System.Drawing.Point(116, 101);
            this.chkOnlyReplyDebugGroup.Name = "chkOnlyReplyDebugGroup";
            this.chkOnlyReplyDebugGroup.Size = new System.Drawing.Size(147, 21);
            this.chkOnlyReplyDebugGroup.TabIndex = 12;
            this.chkOnlyReplyDebugGroup.Text = "只响应调试群组的消息";
            this.chkOnlyReplyDebugGroup.UseVisualStyleBackColor = true;
            // 
            // lstDebugGroups
            // 
            this.lstDebugGroups.FullRowSelect = true;
            this.lstDebugGroups.Location = new System.Drawing.Point(116, 9);
            this.lstDebugGroups.Margin = new System.Windows.Forms.Padding(4);
            this.lstDebugGroups.Name = "lstDebugGroups";
            this.lstDebugGroups.Size = new System.Drawing.Size(200, 85);
            this.lstDebugGroups.TabIndex = 3;
            this.lstDebugGroups.UseCompatibleStateImageBehavior = false;
            this.lstDebugGroups.View = System.Windows.Forms.View.List;
            // 
            // chkDebugReplyAdminOnly
            // 
            this.chkDebugReplyAdminOnly.AutoSize = true;
            this.chkDebugReplyAdminOnly.Location = new System.Drawing.Point(116, 128);
            this.chkDebugReplyAdminOnly.Name = "chkDebugReplyAdminOnly";
            this.chkDebugReplyAdminOnly.Size = new System.Drawing.Size(195, 21);
            this.chkDebugReplyAdminOnly.TabIndex = 11;
            this.chkDebugReplyAdminOnly.Text = "只响应来自机器人管理员的消息";
            this.chkDebugReplyAdminOnly.UseVisualStyleBackColor = true;
            // 
            // lblAddDebugGroup
            // 
            this.lblAddDebugGroup.AutoSize = true;
            this.lblAddDebugGroup.Location = new System.Drawing.Point(420, 9);
            this.lblAddDebugGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddDebugGroup.Name = "lblAddDebugGroup";
            this.lblAddDebugGroup.Size = new System.Drawing.Size(116, 17);
            this.lblAddDebugGroup.TabIndex = 1;
            this.lblAddDebugGroup.Text = "添加调试模式群号：";
            // 
            // lblDebugGroup
            // 
            this.lblDebugGroup.AutoSize = true;
            this.lblDebugGroup.Location = new System.Drawing.Point(3, 9);
            this.lblDebugGroup.Name = "lblDebugGroup";
            this.lblDebugGroup.Size = new System.Drawing.Size(68, 17);
            this.lblDebugGroup.TabIndex = 10;
            this.lblDebugGroup.Text = "调试群组：";
            // 
            // btnAddDebugGroup
            // 
            this.btnAddDebugGroup.Location = new System.Drawing.Point(324, 30);
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
            this.btnRemoveDebugGroup.Location = new System.Drawing.Point(324, 61);
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
            this.txbAddDebugGroup.Location = new System.Drawing.Point(420, 30);
            this.txbAddDebugGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddDebugGroup.Name = "txbAddDebugGroup";
            this.txbAddDebugGroup.ShortcutsEnabled = false;
            this.txbAddDebugGroup.Size = new System.Drawing.Size(177, 23);
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
            this.pnlCheckPorn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckPorn.Controls.Add(this.lblCheckPornLimitCountInfo);
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
            this.pnlCheckPorn.Location = new System.Drawing.Point(0, 593);
            this.pnlCheckPorn.MinimumSize = new System.Drawing.Size(620, 174);
            this.pnlCheckPorn.Name = "pnlCheckPorn";
            this.pnlCheckPorn.Size = new System.Drawing.Size(620, 174);
            this.pnlCheckPorn.TabIndex = 35;
            // 
            // lblCheckPornLimitCountInfo
            // 
            this.lblCheckPornLimitCountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckPornLimitCountInfo.AutoSize = true;
            this.lblCheckPornLimitCountInfo.Location = new System.Drawing.Point(241, 151);
            this.lblCheckPornLimitCountInfo.Name = "lblCheckPornLimitCountInfo";
            this.lblCheckPornLimitCountInfo.Size = new System.Drawing.Size(362, 17);
            this.lblCheckPornLimitCountInfo.TabIndex = 49;
            this.lblCheckPornLimitCountInfo.Text = "(建议按自己腾讯云购买次数填 2021-12-28 更新 每日免费2000次)";
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
            this.txbCheckPornLimitCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCheckPornLimitCount.Location = new System.Drawing.Point(116, 148);
            this.txbCheckPornLimitCount.Name = "txbCheckPornLimitCount";
            this.txbCheckPornLimitCount.Size = new System.Drawing.Size(119, 23);
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
            this.txbTencentCloudBucket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudBucket.Location = new System.Drawing.Point(116, 119);
            this.txbTencentCloudBucket.Name = "txbTencentCloudBucket";
            this.txbTencentCloudBucket.Size = new System.Drawing.Size(481, 23);
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
            this.txbTencentCloudRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudRegion.Location = new System.Drawing.Point(116, 32);
            this.txbTencentCloudRegion.Name = "txbTencentCloudRegion";
            this.txbTencentCloudRegion.Size = new System.Drawing.Size(481, 23);
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
            this.txbTencentCloudSecretId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudSecretId.Location = new System.Drawing.Point(116, 61);
            this.txbTencentCloudSecretId.Name = "txbTencentCloudSecretId";
            this.txbTencentCloudSecretId.Size = new System.Drawing.Size(481, 23);
            this.txbTencentCloudSecretId.TabIndex = 16;
            // 
            // txbTencentCloudAPPID
            // 
            this.txbTencentCloudAPPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudAPPID.Location = new System.Drawing.Point(116, 3);
            this.txbTencentCloudAPPID.Name = "txbTencentCloudAPPID";
            this.txbTencentCloudAPPID.Size = new System.Drawing.Size(481, 23);
            this.txbTencentCloudAPPID.TabIndex = 16;
            // 
            // txbTencentCloudSecretKey
            // 
            this.txbTencentCloudSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTencentCloudSecretKey.Location = new System.Drawing.Point(116, 90);
            this.txbTencentCloudSecretKey.Name = "txbTencentCloudSecretKey";
            this.txbTencentCloudSecretKey.Size = new System.Drawing.Size(481, 23);
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
            this.chkDebugMode.Location = new System.Drawing.Point(3, 899);
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
            this.lstBannedGroup.Location = new System.Drawing.Point(125, 165);
            this.lstBannedGroup.Margin = new System.Windows.Forms.Padding(4);
            this.lstBannedGroup.Name = "lstBannedGroup";
            this.lstBannedGroup.Size = new System.Drawing.Size(186, 136);
            this.lstBannedGroup.TabIndex = 3;
            this.lstBannedGroup.UseCompatibleStateImageBehavior = false;
            this.lstBannedGroup.View = System.Windows.Forms.View.List;
            // 
            // pageSearchPicture
            // 
            this.pageSearchPicture.Controls.Add(this.chkSearchPictureEnabled);
            this.pageSearchPicture.Controls.Add(this.pnlSearchPicture);
            this.pageSearchPicture.Location = new System.Drawing.Point(4, 26);
            this.pageSearchPicture.Name = "pageSearchPicture";
            this.pageSearchPicture.Size = new System.Drawing.Size(652, 687);
            this.pageSearchPicture.TabIndex = 3;
            this.pageSearchPicture.Text = "搜图设置";
            this.pageSearchPicture.UseVisualStyleBackColor = true;
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
            this.pnlSearchPicture.Controls.Add(this.cboSearchShowAscii2dCount);
            this.pnlSearchPicture.Controls.Add(this.lblSearchShowAscii2dCount);
            this.pnlSearchPicture.Controls.Add(this.lblSearchingReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchingReply);
            this.pnlSearchPicture.Controls.Add(this.chkPmAutoSearch);
            this.pnlSearchPicture.Controls.Add(this.pnlSearchSauceNAO);
            this.pnlSearchPicture.Controls.Add(this.lblSearchDownloadThuImageFailReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchDownloadThuImageFailReply);
            this.pnlSearchPicture.Controls.Add(this.chkSearchSendByForward);
            this.pnlSearchPicture.Controls.Add(this.chkSauceNaoRequestByWebBrowser);
            this.pnlSearchPicture.Controls.Add(this.chkASCII2DRequestByWebBrowser);
            this.pnlSearchPicture.Controls.Add(this.pnlPictureSearcherCheckPorn);
            this.pnlSearchPicture.Controls.Add(this.chkSearchCheckPornEnabled);
            this.pnlSearchPicture.Controls.Add(this.chkSearchTraceMoeEnabled);
            this.pnlSearchPicture.Controls.Add(this.lblSearchErrorReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchNoResultReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeAlreadyOffReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeTimeOutReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOffCmd);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOffReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeAlreadyOnReply);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOnReply);
            this.pnlSearchPicture.Controls.Add(this.lblTraceMoeSendThresholdInfo);
            this.pnlSearchPicture.Controls.Add(this.lblTraceMoeSendThreshold);
            this.pnlSearchPicture.Controls.Add(this.lblSearchAnimeModeOnCmd);
            this.pnlSearchPicture.Controls.Add(this.lblSearchModeOnCmd);
            this.pnlSearchPicture.Controls.Add(this.txbSearchErrorReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchNoResultReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeTimeOutReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOffCmd);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeAlreadyOffReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOffReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeAlreadyOnReply);
            this.pnlSearchPicture.Controls.Add(this.txbTraceMoeSendThreshold);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOnReply);
            this.pnlSearchPicture.Controls.Add(this.txbSearchAnimeModeOnCmd);
            this.pnlSearchPicture.Controls.Add(this.txbSearchModeOnCmd);
            this.pnlSearchPicture.Controls.Add(this.chkSearchASCII2DEnabled);
            this.pnlSearchPicture.Controls.Add(this.chkSearchSauceNAOEnabled);
            this.pnlSearchPicture.Enabled = false;
            this.pnlSearchPicture.Location = new System.Drawing.Point(3, 35);
            this.pnlSearchPicture.Name = "pnlSearchPicture";
            this.pnlSearchPicture.Size = new System.Drawing.Size(642, 649);
            this.pnlSearchPicture.TabIndex = 14;
            // 
            // cboSearchShowAscii2dCount
            // 
            this.cboSearchShowAscii2dCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchShowAscii2dCount.FormattingEnabled = true;
            this.cboSearchShowAscii2dCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cboSearchShowAscii2dCount.Location = new System.Drawing.Point(196, 438);
            this.cboSearchShowAscii2dCount.MaximumSize = new System.Drawing.Size(357, 0);
            this.cboSearchShowAscii2dCount.Name = "cboSearchShowAscii2dCount";
            this.cboSearchShowAscii2dCount.Size = new System.Drawing.Size(357, 25);
            this.cboSearchShowAscii2dCount.TabIndex = 63;
            // 
            // lblSearchShowAscii2dCount
            // 
            this.lblSearchShowAscii2dCount.AutoSize = true;
            this.lblSearchShowAscii2dCount.Location = new System.Drawing.Point(25, 441);
            this.lblSearchShowAscii2dCount.Name = "lblSearchShowAscii2dCount";
            this.lblSearchShowAscii2dCount.Size = new System.Drawing.Size(134, 17);
            this.lblSearchShowAscii2dCount.TabIndex = 62;
            this.lblSearchShowAscii2dCount.Text = "ASCII2D 显示结果数量:";
            // 
            // lblSearchingReply
            // 
            this.lblSearchingReply.AutoSize = true;
            this.lblSearchingReply.Location = new System.Drawing.Point(24, 588);
            this.lblSearchingReply.Name = "lblSearchingReply";
            this.lblSearchingReply.Size = new System.Drawing.Size(95, 17);
            this.lblSearchingReply.TabIndex = 60;
            this.lblSearchingReply.Text = "正在搜索回复语:";
            // 
            // txbSearchingReply
            // 
            this.txbSearchingReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchingReply.Location = new System.Drawing.Point(196, 585);
            this.txbSearchingReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchingReply.Name = "txbSearchingReply";
            this.txbSearchingReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchingReply.TabIndex = 59;
            // 
            // chkPmAutoSearch
            // 
            this.chkPmAutoSearch.AutoSize = true;
            this.chkPmAutoSearch.Location = new System.Drawing.Point(24, 3);
            this.chkPmAutoSearch.Name = "chkPmAutoSearch";
            this.chkPmAutoSearch.Size = new System.Drawing.Size(111, 21);
            this.chkPmAutoSearch.TabIndex = 58;
            this.chkPmAutoSearch.Text = "私聊时自动搜图";
            this.chkPmAutoSearch.UseVisualStyleBackColor = true;
            // 
            // pnlSearchSauceNAO
            // 
            this.pnlSearchSauceNAO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchSauceNAO.Controls.Add(this.chkSearchSauceNAOSortByDesc);
            this.pnlSearchSauceNAO.Controls.Add(this.lblSauceNAOApiKey);
            this.pnlSearchSauceNAO.Controls.Add(this.chkSearchSauceNAOSendPixivOriginalPicture);
            this.pnlSearchSauceNAO.Controls.Add(this.txbSearchSauceNAOApiKey);
            this.pnlSearchSauceNAO.Controls.Add(this.lblSearchSauceNAOHighSimilarity);
            this.pnlSearchSauceNAO.Controls.Add(this.txbSearchSauceNAOLowSimilarity);
            this.pnlSearchSauceNAO.Controls.Add(this.txbSearchSauceNAOHighSimilarity);
            this.pnlSearchSauceNAO.Controls.Add(this.txbSearchLowSimilarityReply);
            this.pnlSearchSauceNAO.Controls.Add(this.lblSearchSauceNAOLowSimilarity);
            this.pnlSearchSauceNAO.Controls.Add(this.lblSearchSauceNAOLowSimilarityInfo);
            this.pnlSearchSauceNAO.Controls.Add(this.lblSearchSauceNAOHighSimilarityInfo);
            this.pnlSearchSauceNAO.Controls.Add(this.lblSearchLowSimilarityReply);
            this.pnlSearchSauceNAO.Controls.Add(this.lblSauceNAOApiKeyInfo);
            this.pnlSearchSauceNAO.Enabled = false;
            this.pnlSearchSauceNAO.Location = new System.Drawing.Point(8, 130);
            this.pnlSearchSauceNAO.MinimumSize = new System.Drawing.Size(548, 245);
            this.pnlSearchSauceNAO.Name = "pnlSearchSauceNAO";
            this.pnlSearchSauceNAO.Size = new System.Drawing.Size(548, 275);
            this.pnlSearchSauceNAO.TabIndex = 57;
            // 
            // chkSearchSauceNAOSortByDesc
            // 
            this.chkSearchSauceNAOSortByDesc.AutoSize = true;
            this.chkSearchSauceNAOSortByDesc.Location = new System.Drawing.Point(16, 95);
            this.chkSearchSauceNAOSortByDesc.Name = "chkSearchSauceNAOSortByDesc";
            this.chkSearchSauceNAOSortByDesc.Size = new System.Drawing.Size(327, 21);
            this.chkSearchSauceNAOSortByDesc.TabIndex = 57;
            this.chkSearchSauceNAOSortByDesc.Text = "按相似度排序 (相似度最高的结果有时候反而会没有大图)";
            this.chkSearchSauceNAOSortByDesc.UseVisualStyleBackColor = true;
            // 
            // lblSauceNAOApiKey
            // 
            this.lblSauceNAOApiKey.AutoSize = true;
            this.lblSauceNAOApiKey.Location = new System.Drawing.Point(16, 6);
            this.lblSauceNAOApiKey.Name = "lblSauceNAOApiKey";
            this.lblSauceNAOApiKey.Size = new System.Drawing.Size(122, 17);
            this.lblSauceNAOApiKey.TabIndex = 17;
            this.lblSauceNAOApiKey.Text = "SauceNAO Api-Key:";
            // 
            // chkSearchSauceNAOSendPixivOriginalPicture
            // 
            this.chkSearchSauceNAOSendPixivOriginalPicture.AutoSize = true;
            this.chkSearchSauceNAOSendPixivOriginalPicture.Location = new System.Drawing.Point(16, 168);
            this.chkSearchSauceNAOSendPixivOriginalPicture.Name = "chkSearchSauceNAOSendPixivOriginalPicture";
            this.chkSearchSauceNAOSendPixivOriginalPicture.Size = new System.Drawing.Size(270, 21);
            this.chkSearchSauceNAOSendPixivOriginalPicture.TabIndex = 56;
            this.chkSearchSauceNAOSendPixivOriginalPicture.Text = "SauceNAO 搜图结果为 Pixiv 地址时发送原图";
            this.chkSearchSauceNAOSendPixivOriginalPicture.UseVisualStyleBackColor = true;
            // 
            // txbSearchSauceNAOApiKey
            // 
            this.txbSearchSauceNAOApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchSauceNAOApiKey.Location = new System.Drawing.Point(188, 3);
            this.txbSearchSauceNAOApiKey.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchSauceNAOApiKey.Multiline = true;
            this.txbSearchSauceNAOApiKey.Name = "txbSearchSauceNAOApiKey";
            this.txbSearchSauceNAOApiKey.Size = new System.Drawing.Size(357, 86);
            this.txbSearchSauceNAOApiKey.TabIndex = 16;
            // 
            // lblSearchSauceNAOHighSimilarity
            // 
            this.lblSearchSauceNAOHighSimilarity.AutoSize = true;
            this.lblSearchSauceNAOHighSimilarity.Location = new System.Drawing.Point(13, 227);
            this.lblSearchSauceNAOHighSimilarity.Name = "lblSearchSauceNAOHighSimilarity";
            this.lblSearchSauceNAOHighSimilarity.Size = new System.Drawing.Size(83, 17);
            this.lblSearchSauceNAOHighSimilarity.TabIndex = 54;
            this.lblSearchSauceNAOHighSimilarity.Text = "高相似度阈值:";
            // 
            // txbSearchSauceNAOLowSimilarity
            // 
            this.txbSearchSauceNAOLowSimilarity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchSauceNAOLowSimilarity.Location = new System.Drawing.Point(188, 122);
            this.txbSearchSauceNAOLowSimilarity.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchSauceNAOLowSimilarity.Name = "txbSearchSauceNAOLowSimilarity";
            this.txbSearchSauceNAOLowSimilarity.Size = new System.Drawing.Size(357, 23);
            this.txbSearchSauceNAOLowSimilarity.TabIndex = 16;
            // 
            // txbSearchSauceNAOHighSimilarity
            // 
            this.txbSearchSauceNAOHighSimilarity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchSauceNAOHighSimilarity.Location = new System.Drawing.Point(188, 224);
            this.txbSearchSauceNAOHighSimilarity.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchSauceNAOHighSimilarity.Name = "txbSearchSauceNAOHighSimilarity";
            this.txbSearchSauceNAOHighSimilarity.Size = new System.Drawing.Size(357, 23);
            this.txbSearchSauceNAOHighSimilarity.TabIndex = 53;
            // 
            // txbSearchLowSimilarityReply
            // 
            this.txbSearchLowSimilarityReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchLowSimilarityReply.Location = new System.Drawing.Point(188, 195);
            this.txbSearchLowSimilarityReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchLowSimilarityReply.Name = "txbSearchLowSimilarityReply";
            this.txbSearchLowSimilarityReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchLowSimilarityReply.TabIndex = 16;
            // 
            // lblSearchSauceNAOLowSimilarity
            // 
            this.lblSearchSauceNAOLowSimilarity.AutoSize = true;
            this.lblSearchSauceNAOLowSimilarity.Location = new System.Drawing.Point(13, 125);
            this.lblSearchSauceNAOLowSimilarity.Name = "lblSearchSauceNAOLowSimilarity";
            this.lblSearchSauceNAOLowSimilarity.Size = new System.Drawing.Size(83, 17);
            this.lblSearchSauceNAOLowSimilarity.TabIndex = 24;
            this.lblSearchSauceNAOLowSimilarity.Text = "低相似度阈值:";
            // 
            // lblSearchSauceNAOLowSimilarityInfo
            // 
            this.lblSearchSauceNAOLowSimilarityInfo.AutoSize = true;
            this.lblSearchSauceNAOLowSimilarityInfo.Location = new System.Drawing.Point(185, 148);
            this.lblSearchSauceNAOLowSimilarityInfo.Name = "lblSearchSauceNAOLowSimilarityInfo";
            this.lblSearchSauceNAOLowSimilarityInfo.Size = new System.Drawing.Size(172, 17);
            this.lblSearchSauceNAOLowSimilarityInfo.TabIndex = 24;
            this.lblSearchSauceNAOLowSimilarityInfo.Text = "(低于此相似度时不发送缩略图)";
            // 
            // lblSearchSauceNAOHighSimilarityInfo
            // 
            this.lblSearchSauceNAOHighSimilarityInfo.AutoSize = true;
            this.lblSearchSauceNAOHighSimilarityInfo.Location = new System.Drawing.Point(185, 250);
            this.lblSearchSauceNAOHighSimilarityInfo.Name = "lblSearchSauceNAOHighSimilarityInfo";
            this.lblSearchSauceNAOHighSimilarityInfo.Size = new System.Drawing.Size(215, 17);
            this.lblSearchSauceNAOHighSimilarityInfo.TabIndex = 24;
            this.lblSearchSauceNAOHighSimilarityInfo.Text = "(高于此相似度时不使用 ASCII2D 搜索)";
            // 
            // lblSearchLowSimilarityReply
            // 
            this.lblSearchLowSimilarityReply.AutoSize = true;
            this.lblSearchLowSimilarityReply.Location = new System.Drawing.Point(13, 198);
            this.lblSearchLowSimilarityReply.Name = "lblSearchLowSimilarityReply";
            this.lblSearchLowSimilarityReply.Size = new System.Drawing.Size(131, 17);
            this.lblSearchLowSimilarityReply.TabIndex = 25;
            this.lblSearchLowSimilarityReply.Text = "低于相似度阈值回复语:";
            // 
            // lblSauceNAOApiKeyInfo
            // 
            this.lblSauceNAOApiKeyInfo.AutoSize = true;
            this.lblSauceNAOApiKeyInfo.Location = new System.Drawing.Point(45, 33);
            this.lblSauceNAOApiKeyInfo.Name = "lblSauceNAOApiKeyInfo";
            this.lblSauceNAOApiKeyInfo.Size = new System.Drawing.Size(64, 17);
            this.lblSauceNAOApiKeyInfo.TabIndex = 48;
            this.lblSauceNAOApiKeyInfo.Text = "(一行一个)";
            // 
            // lblSearchDownloadThuImageFailReply
            // 
            this.lblSearchDownloadThuImageFailReply.AutoSize = true;
            this.lblSearchDownloadThuImageFailReply.Location = new System.Drawing.Point(24, 791);
            this.lblSearchDownloadThuImageFailReply.Name = "lblSearchDownloadThuImageFailReply";
            this.lblSearchDownloadThuImageFailReply.Size = new System.Drawing.Size(155, 17);
            this.lblSearchDownloadThuImageFailReply.TabIndex = 52;
            this.lblSearchDownloadThuImageFailReply.Text = "下载缩略图失败时追加回复:";
            // 
            // txbSearchDownloadThuImageFailReply
            // 
            this.txbSearchDownloadThuImageFailReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchDownloadThuImageFailReply.Location = new System.Drawing.Point(196, 788);
            this.txbSearchDownloadThuImageFailReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchDownloadThuImageFailReply.Name = "txbSearchDownloadThuImageFailReply";
            this.txbSearchDownloadThuImageFailReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchDownloadThuImageFailReply.TabIndex = 51;
            // 
            // chkSearchSendByForward
            // 
            this.chkSearchSendByForward.AutoSize = true;
            this.chkSearchSendByForward.Location = new System.Drawing.Point(24, 817);
            this.chkSearchSendByForward.Name = "chkSearchSendByForward";
            this.chkSearchSendByForward.Size = new System.Drawing.Size(195, 21);
            this.chkSearchSendByForward.TabIndex = 50;
            this.chkSearchSendByForward.Text = "搜图结果以合并转发的方式发送";
            this.chkSearchSendByForward.UseVisualStyleBackColor = true;
            // 
            // chkSauceNaoRequestByWebBrowser
            // 
            this.chkSauceNaoRequestByWebBrowser.AutoSize = true;
            this.chkSauceNaoRequestByWebBrowser.Location = new System.Drawing.Point(196, 103);
            this.chkSauceNaoRequestByWebBrowser.Name = "chkSauceNaoRequestByWebBrowser";
            this.chkSauceNaoRequestByWebBrowser.Size = new System.Drawing.Size(392, 21);
            this.chkSauceNaoRequestByWebBrowser.TabIndex = 49;
            this.chkSauceNaoRequestByWebBrowser.Text = "SauceNAO 使用爬虫而非API (轻量服务器403再开, 不支持下载原图)";
            this.chkSauceNaoRequestByWebBrowser.UseVisualStyleBackColor = true;
            // 
            // chkASCII2DRequestByWebBrowser
            // 
            this.chkASCII2DRequestByWebBrowser.AutoSize = true;
            this.chkASCII2DRequestByWebBrowser.Location = new System.Drawing.Point(196, 411);
            this.chkASCII2DRequestByWebBrowser.Name = "chkASCII2DRequestByWebBrowser";
            this.chkASCII2DRequestByWebBrowser.Size = new System.Drawing.Size(360, 21);
            this.chkASCII2DRequestByWebBrowser.TabIndex = 41;
            this.chkASCII2DRequestByWebBrowser.Text = "ASCII2D 优先使用浏览器进行 Http 请求 (以应对近期403问题)";
            this.chkASCII2DRequestByWebBrowser.UseVisualStyleBackColor = true;
            // 
            // pnlPictureSearcherCheckPorn
            // 
            this.pnlPictureSearcherCheckPorn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.lblSearchCheckPornOutOfLimitReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.txbSearchCheckPornOutOfLimitReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.txbSearchCheckPornIllegalReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.lblSearchCheckPornIllegalReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.lblSearchCheckPornErrorReply);
            this.pnlPictureSearcherCheckPorn.Controls.Add(this.txbSearchCheckPornErrorReply);
            this.pnlPictureSearcherCheckPorn.Enabled = false;
            this.pnlPictureSearcherCheckPorn.Location = new System.Drawing.Point(5, 871);
            this.pnlPictureSearcherCheckPorn.MinimumSize = new System.Drawing.Size(551, 89);
            this.pnlPictureSearcherCheckPorn.Name = "pnlPictureSearcherCheckPorn";
            this.pnlPictureSearcherCheckPorn.Size = new System.Drawing.Size(551, 89);
            this.pnlPictureSearcherCheckPorn.TabIndex = 40;
            // 
            // lblSearchCheckPornOutOfLimitReply
            // 
            this.lblSearchCheckPornOutOfLimitReply.AutoSize = true;
            this.lblSearchCheckPornOutOfLimitReply.Location = new System.Drawing.Point(19, 64);
            this.lblSearchCheckPornOutOfLimitReply.Name = "lblSearchCheckPornOutOfLimitReply";
            this.lblSearchCheckPornOutOfLimitReply.Size = new System.Drawing.Size(119, 17);
            this.lblSearchCheckPornOutOfLimitReply.TabIndex = 43;
            this.lblSearchCheckPornOutOfLimitReply.Text = "鉴黄次数耗尽时回复:";
            // 
            // txbSearchCheckPornOutOfLimitReply
            // 
            this.txbSearchCheckPornOutOfLimitReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchCheckPornOutOfLimitReply.Location = new System.Drawing.Point(191, 61);
            this.txbSearchCheckPornOutOfLimitReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchCheckPornOutOfLimitReply.Name = "txbSearchCheckPornOutOfLimitReply";
            this.txbSearchCheckPornOutOfLimitReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchCheckPornOutOfLimitReply.TabIndex = 42;
            // 
            // txbSearchCheckPornIllegalReply
            // 
            this.txbSearchCheckPornIllegalReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchCheckPornIllegalReply.Location = new System.Drawing.Point(191, 3);
            this.txbSearchCheckPornIllegalReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchCheckPornIllegalReply.Name = "txbSearchCheckPornIllegalReply";
            this.txbSearchCheckPornIllegalReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchCheckPornIllegalReply.TabIndex = 35;
            // 
            // lblSearchCheckPornIllegalReply
            // 
            this.lblSearchCheckPornIllegalReply.AutoSize = true;
            this.lblSearchCheckPornIllegalReply.Location = new System.Drawing.Point(19, 6);
            this.lblSearchCheckPornIllegalReply.Name = "lblSearchCheckPornIllegalReply";
            this.lblSearchCheckPornIllegalReply.Size = new System.Drawing.Size(107, 17);
            this.lblSearchCheckPornIllegalReply.TabIndex = 37;
            this.lblSearchCheckPornIllegalReply.Text = "鉴黄不通过回复语:";
            // 
            // lblSearchCheckPornErrorReply
            // 
            this.lblSearchCheckPornErrorReply.AutoSize = true;
            this.lblSearchCheckPornErrorReply.Location = new System.Drawing.Point(19, 35);
            this.lblSearchCheckPornErrorReply.Name = "lblSearchCheckPornErrorReply";
            this.lblSearchCheckPornErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblSearchCheckPornErrorReply.TabIndex = 38;
            this.lblSearchCheckPornErrorReply.Text = "鉴黄错误回复语:";
            // 
            // txbSearchCheckPornErrorReply
            // 
            this.txbSearchCheckPornErrorReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchCheckPornErrorReply.Location = new System.Drawing.Point(191, 32);
            this.txbSearchCheckPornErrorReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchCheckPornErrorReply.Name = "txbSearchCheckPornErrorReply";
            this.txbSearchCheckPornErrorReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchCheckPornErrorReply.TabIndex = 36;
            // 
            // chkSearchCheckPornEnabled
            // 
            this.chkSearchCheckPornEnabled.AutoSize = true;
            this.chkSearchCheckPornEnabled.Location = new System.Drawing.Point(24, 844);
            this.chkSearchCheckPornEnabled.Name = "chkSearchCheckPornEnabled";
            this.chkSearchCheckPornEnabled.Size = new System.Drawing.Size(99, 21);
            this.chkSearchCheckPornEnabled.TabIndex = 39;
            this.chkSearchCheckPornEnabled.Text = "搜图启用鉴黄";
            this.chkSearchCheckPornEnabled.UseVisualStyleBackColor = true;
            this.chkSearchCheckPornEnabled.CheckedChanged += new System.EventHandler(this.chkPictureSearcherCheckPornEnabled_CheckedChanged);
            // 
            // chkSearchTraceMoeEnabled
            // 
            this.chkSearchTraceMoeEnabled.AutoSize = true;
            this.chkSearchTraceMoeEnabled.Location = new System.Drawing.Point(24, 30);
            this.chkSearchTraceMoeEnabled.Name = "chkSearchTraceMoeEnabled";
            this.chkSearchTraceMoeEnabled.Size = new System.Drawing.Size(142, 21);
            this.chkSearchTraceMoeEnabled.TabIndex = 34;
            this.chkSearchTraceMoeEnabled.Text = "启用 TraceMoe 搜番";
            this.chkSearchTraceMoeEnabled.UseVisualStyleBackColor = true;
            // 
            // lblSearchErrorReply
            // 
            this.lblSearchErrorReply.AutoSize = true;
            this.lblSearchErrorReply.Location = new System.Drawing.Point(24, 762);
            this.lblSearchErrorReply.Name = "lblSearchErrorReply";
            this.lblSearchErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblSearchErrorReply.TabIndex = 23;
            this.lblSearchErrorReply.Text = "搜索错误回复语:";
            // 
            // lblSearchNoResultReply
            // 
            this.lblSearchNoResultReply.AutoSize = true;
            this.lblSearchNoResultReply.Location = new System.Drawing.Point(24, 733);
            this.lblSearchNoResultReply.Name = "lblSearchNoResultReply";
            this.lblSearchNoResultReply.Size = new System.Drawing.Size(131, 17);
            this.lblSearchNoResultReply.TabIndex = 22;
            this.lblSearchNoResultReply.Text = "没有搜索到地址回复语:";
            // 
            // lblSearchModeAlreadyOffReply
            // 
            this.lblSearchModeAlreadyOffReply.AutoSize = true;
            this.lblSearchModeAlreadyOffReply.Location = new System.Drawing.Point(24, 704);
            this.lblSearchModeAlreadyOffReply.Name = "lblSearchModeAlreadyOffReply";
            this.lblSearchModeAlreadyOffReply.Size = new System.Drawing.Size(155, 17);
            this.lblSearchModeAlreadyOffReply.TabIndex = 21;
            this.lblSearchModeAlreadyOffReply.Text = "已退出连续搜图模式回复语:";
            // 
            // lblSearchModeTimeOutReply
            // 
            this.lblSearchModeTimeOutReply.AutoSize = true;
            this.lblSearchModeTimeOutReply.Location = new System.Drawing.Point(24, 646);
            this.lblSearchModeTimeOutReply.Name = "lblSearchModeTimeOutReply";
            this.lblSearchModeTimeOutReply.Size = new System.Drawing.Size(143, 17);
            this.lblSearchModeTimeOutReply.TabIndex = 20;
            this.lblSearchModeTimeOutReply.Text = "连续搜图模式超时回复语:";
            // 
            // lblSearchModeOffCmd
            // 
            this.lblSearchModeOffCmd.AutoSize = true;
            this.lblSearchModeOffCmd.Location = new System.Drawing.Point(24, 617);
            this.lblSearchModeOffCmd.Name = "lblSearchModeOffCmd";
            this.lblSearchModeOffCmd.Size = new System.Drawing.Size(131, 17);
            this.lblSearchModeOffCmd.TabIndex = 20;
            this.lblSearchModeOffCmd.Text = "退出连续搜图模式命令:";
            // 
            // lblSearchModeOffReply
            // 
            this.lblSearchModeOffReply.AutoSize = true;
            this.lblSearchModeOffReply.Location = new System.Drawing.Point(24, 675);
            this.lblSearchModeOffReply.Name = "lblSearchModeOffReply";
            this.lblSearchModeOffReply.Size = new System.Drawing.Size(143, 17);
            this.lblSearchModeOffReply.TabIndex = 20;
            this.lblSearchModeOffReply.Text = "退出连续搜图模式回复语:";
            // 
            // lblSearchModeAlreadyOnReply
            // 
            this.lblSearchModeAlreadyOnReply.AutoSize = true;
            this.lblSearchModeAlreadyOnReply.Location = new System.Drawing.Point(24, 559);
            this.lblSearchModeAlreadyOnReply.Name = "lblSearchModeAlreadyOnReply";
            this.lblSearchModeAlreadyOnReply.Size = new System.Drawing.Size(155, 17);
            this.lblSearchModeAlreadyOnReply.TabIndex = 19;
            this.lblSearchModeAlreadyOnReply.Text = "已进入连续搜图模式回复语:";
            // 
            // lblSearchModeOnReply
            // 
            this.lblSearchModeOnReply.AutoSize = true;
            this.lblSearchModeOnReply.Location = new System.Drawing.Point(24, 530);
            this.lblSearchModeOnReply.Name = "lblSearchModeOnReply";
            this.lblSearchModeOnReply.Size = new System.Drawing.Size(143, 17);
            this.lblSearchModeOnReply.TabIndex = 18;
            this.lblSearchModeOnReply.Text = "进入连续搜图模式回复语:";
            // 
            // lblTraceMoeSendThresholdInfo
            // 
            this.lblTraceMoeSendThresholdInfo.AutoSize = true;
            this.lblTraceMoeSendThresholdInfo.Location = new System.Drawing.Point(192, 83);
            this.lblTraceMoeSendThresholdInfo.Name = "lblTraceMoeSendThresholdInfo";
            this.lblTraceMoeSendThresholdInfo.Size = new System.Drawing.Size(380, 17);
            this.lblTraceMoeSendThresholdInfo.TabIndex = 17;
            this.lblTraceMoeSendThresholdInfo.Text = "相似度大于等于此数值时发送搜番结果(TraceMoe 官方参考值为87%)";
            // 
            // lblTraceMoeSendThreshold
            // 
            this.lblTraceMoeSendThreshold.AutoSize = true;
            this.lblTraceMoeSendThreshold.Location = new System.Drawing.Point(24, 60);
            this.lblTraceMoeSendThreshold.Name = "lblTraceMoeSendThreshold";
            this.lblTraceMoeSendThreshold.Size = new System.Drawing.Size(122, 17);
            this.lblTraceMoeSendThreshold.TabIndex = 17;
            this.lblTraceMoeSendThreshold.Text = "TraceMoe 发送阈值:";
            // 
            // lblSearchModeOnCmd
            // 
            this.lblSearchModeOnCmd.AutoSize = true;
            this.lblSearchModeOnCmd.Location = new System.Drawing.Point(24, 472);
            this.lblSearchModeOnCmd.Name = "lblSearchModeOnCmd";
            this.lblSearchModeOnCmd.Size = new System.Drawing.Size(131, 17);
            this.lblSearchModeOnCmd.TabIndex = 17;
            this.lblSearchModeOnCmd.Text = "开启连续搜图模式命令:";
            // 
            // txbSearchErrorReply
            // 
            this.txbSearchErrorReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchErrorReply.Location = new System.Drawing.Point(196, 759);
            this.txbSearchErrorReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchErrorReply.Name = "txbSearchErrorReply";
            this.txbSearchErrorReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchErrorReply.TabIndex = 16;
            // 
            // txbSearchNoResultReply
            // 
            this.txbSearchNoResultReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchNoResultReply.Location = new System.Drawing.Point(196, 730);
            this.txbSearchNoResultReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchNoResultReply.Name = "txbSearchNoResultReply";
            this.txbSearchNoResultReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchNoResultReply.TabIndex = 16;
            // 
            // txbSearchModeTimeOutReply
            // 
            this.txbSearchModeTimeOutReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchModeTimeOutReply.Location = new System.Drawing.Point(196, 643);
            this.txbSearchModeTimeOutReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchModeTimeOutReply.Name = "txbSearchModeTimeOutReply";
            this.txbSearchModeTimeOutReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchModeTimeOutReply.TabIndex = 16;
            // 
            // txbSearchModeOffCmd
            // 
            this.txbSearchModeOffCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchModeOffCmd.Location = new System.Drawing.Point(196, 614);
            this.txbSearchModeOffCmd.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchModeOffCmd.Name = "txbSearchModeOffCmd";
            this.txbSearchModeOffCmd.Size = new System.Drawing.Size(357, 23);
            this.txbSearchModeOffCmd.TabIndex = 16;
            // 
            // txbSearchModeAlreadyOffReply
            // 
            this.txbSearchModeAlreadyOffReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchModeAlreadyOffReply.Location = new System.Drawing.Point(196, 701);
            this.txbSearchModeAlreadyOffReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchModeAlreadyOffReply.Name = "txbSearchModeAlreadyOffReply";
            this.txbSearchModeAlreadyOffReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchModeAlreadyOffReply.TabIndex = 16;
            // 
            // txbSearchModeOffReply
            // 
            this.txbSearchModeOffReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchModeOffReply.Location = new System.Drawing.Point(196, 672);
            this.txbSearchModeOffReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchModeOffReply.Name = "txbSearchModeOffReply";
            this.txbSearchModeOffReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchModeOffReply.TabIndex = 16;
            // 
            // txbSearchModeAlreadyOnReply
            // 
            this.txbSearchModeAlreadyOnReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchModeAlreadyOnReply.Location = new System.Drawing.Point(196, 556);
            this.txbSearchModeAlreadyOnReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchModeAlreadyOnReply.Name = "txbSearchModeAlreadyOnReply";
            this.txbSearchModeAlreadyOnReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchModeAlreadyOnReply.TabIndex = 16;
            // 
            // txbTraceMoeSendThreshold
            // 
            this.txbTraceMoeSendThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTraceMoeSendThreshold.Location = new System.Drawing.Point(196, 57);
            this.txbTraceMoeSendThreshold.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbTraceMoeSendThreshold.Name = "txbTraceMoeSendThreshold";
            this.txbTraceMoeSendThreshold.Size = new System.Drawing.Size(357, 23);
            this.txbTraceMoeSendThreshold.TabIndex = 16;
            // 
            // txbSearchModeOnReply
            // 
            this.txbSearchModeOnReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchModeOnReply.Location = new System.Drawing.Point(196, 527);
            this.txbSearchModeOnReply.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchModeOnReply.Name = "txbSearchModeOnReply";
            this.txbSearchModeOnReply.Size = new System.Drawing.Size(357, 23);
            this.txbSearchModeOnReply.TabIndex = 16;
            // 
            // txbSearchModeOnCmd
            // 
            this.txbSearchModeOnCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchModeOnCmd.Location = new System.Drawing.Point(196, 469);
            this.txbSearchModeOnCmd.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchModeOnCmd.Name = "txbSearchModeOnCmd";
            this.txbSearchModeOnCmd.Size = new System.Drawing.Size(357, 23);
            this.txbSearchModeOnCmd.TabIndex = 16;
            // 
            // chkSearchASCII2DEnabled
            // 
            this.chkSearchASCII2DEnabled.AutoSize = true;
            this.chkSearchASCII2DEnabled.Location = new System.Drawing.Point(24, 411);
            this.chkSearchASCII2DEnabled.Name = "chkSearchASCII2DEnabled";
            this.chkSearchASCII2DEnabled.Size = new System.Drawing.Size(130, 21);
            this.chkSearchASCII2DEnabled.TabIndex = 15;
            this.chkSearchASCII2DEnabled.Text = "启用 ASCII2D 搜索";
            this.chkSearchASCII2DEnabled.UseVisualStyleBackColor = true;
            // 
            // chkSearchSauceNAOEnabled
            // 
            this.chkSearchSauceNAOEnabled.AutoSize = true;
            this.chkSearchSauceNAOEnabled.Location = new System.Drawing.Point(24, 103);
            this.chkSearchSauceNAOEnabled.Name = "chkSearchSauceNAOEnabled";
            this.chkSearchSauceNAOEnabled.Size = new System.Drawing.Size(145, 21);
            this.chkSearchSauceNAOEnabled.TabIndex = 15;
            this.chkSearchSauceNAOEnabled.Text = "启用 SauceNAO 搜图";
            this.chkSearchSauceNAOEnabled.UseVisualStyleBackColor = true;
            this.chkSearchSauceNAOEnabled.CheckedChanged += new System.EventHandler(this.chkSearchSauceNAOEnabled_CheckedChanged);
            // 
            // pageOriginalPicture
            // 
            this.pageOriginalPicture.Controls.Add(this.lblOriginalPictureCommand);
            this.pageOriginalPicture.Controls.Add(this.txbOriginalPictureCommand);
            this.pageOriginalPicture.Controls.Add(this.pnlOriginalPicture);
            this.pageOriginalPicture.Controls.Add(this.chkOriginalPictureEnabled);
            this.pageOriginalPicture.Location = new System.Drawing.Point(4, 26);
            this.pageOriginalPicture.Name = "pageOriginalPicture";
            this.pageOriginalPicture.Size = new System.Drawing.Size(652, 687);
            this.pageOriginalPicture.TabIndex = 9;
            this.pageOriginalPicture.Text = "下载原图";
            this.pageOriginalPicture.UseVisualStyleBackColor = true;
            // 
            // lblOriginalPictureCommand
            // 
            this.lblOriginalPictureCommand.AutoSize = true;
            this.lblOriginalPictureCommand.Location = new System.Drawing.Point(16, 183);
            this.lblOriginalPictureCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOriginalPictureCommand.Name = "lblOriginalPictureCommand";
            this.lblOriginalPictureCommand.Size = new System.Drawing.Size(59, 17);
            this.lblOriginalPictureCommand.TabIndex = 15;
            this.lblOriginalPictureCommand.Text = "完整命令:";
            // 
            // txbOriginalPictureCommand
            // 
            this.txbOriginalPictureCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOriginalPictureCommand.BackColor = System.Drawing.SystemColors.Control;
            this.txbOriginalPictureCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbOriginalPictureCommand.Location = new System.Drawing.Point(83, 181);
            this.txbOriginalPictureCommand.Margin = new System.Windows.Forms.Padding(4);
            this.txbOriginalPictureCommand.Name = "txbOriginalPictureCommand";
            this.txbOriginalPictureCommand.ReadOnly = true;
            this.txbOriginalPictureCommand.Size = new System.Drawing.Size(552, 23);
            this.txbOriginalPictureCommand.TabIndex = 16;
            this.txbOriginalPictureCommand.Text = "<机器人名称>下[載载][Pp]([Ii][Xx][Ii][Vv]|站)原[圖图][:：]<PixivID>";
            // 
            // pnlOriginalPicture
            // 
            this.pnlOriginalPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOriginalPicture.Controls.Add(this.chkOriginalPictureCheckPornEnabled);
            this.pnlOriginalPicture.Controls.Add(this.pnlOriginalPictureCheckPorn);
            this.pnlOriginalPicture.Enabled = false;
            this.pnlOriginalPicture.Location = new System.Drawing.Point(3, 35);
            this.pnlOriginalPicture.Name = "pnlOriginalPicture";
            this.pnlOriginalPicture.Size = new System.Drawing.Size(646, 139);
            this.pnlOriginalPicture.TabIndex = 3;
            // 
            // chkOriginalPictureCheckPornEnabled
            // 
            this.chkOriginalPictureCheckPornEnabled.AutoSize = true;
            this.chkOriginalPictureCheckPornEnabled.Location = new System.Drawing.Point(12, 3);
            this.chkOriginalPictureCheckPornEnabled.Name = "chkOriginalPictureCheckPornEnabled";
            this.chkOriginalPictureCheckPornEnabled.Size = new System.Drawing.Size(75, 21);
            this.chkOriginalPictureCheckPornEnabled.TabIndex = 1;
            this.chkOriginalPictureCheckPornEnabled.Text = "启用鉴黄";
            this.chkOriginalPictureCheckPornEnabled.UseVisualStyleBackColor = true;
            this.chkOriginalPictureCheckPornEnabled.CheckedChanged += new System.EventHandler(this.chkOriginalPictureCheckPornEnabled_CheckedChanged);
            // 
            // pnlOriginalPictureCheckPorn
            // 
            this.pnlOriginalPictureCheckPorn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOriginalPictureCheckPorn.Controls.Add(this.pnlOriginalPictureCheckPornMessage);
            this.pnlOriginalPictureCheckPorn.Controls.Add(this.pnlOriginalPictureCheckPornEvent);
            this.pnlOriginalPictureCheckPorn.Controls.Add(this.lblOriginalPictureCheckPornEvent);
            this.pnlOriginalPictureCheckPorn.Enabled = false;
            this.pnlOriginalPictureCheckPorn.Location = new System.Drawing.Point(0, 30);
            this.pnlOriginalPictureCheckPorn.Name = "pnlOriginalPictureCheckPorn";
            this.pnlOriginalPictureCheckPorn.Size = new System.Drawing.Size(643, 105);
            this.pnlOriginalPictureCheckPorn.TabIndex = 2;
            // 
            // pnlOriginalPictureCheckPornMessage
            // 
            this.pnlOriginalPictureCheckPornMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOriginalPictureCheckPornMessage.Controls.Add(this.lblOriginalPictureCheckPornIllegalReply);
            this.pnlOriginalPictureCheckPornMessage.Controls.Add(this.txbOriginalPictureCheckPornErrorReply);
            this.pnlOriginalPictureCheckPornMessage.Controls.Add(this.txbOriginalPictureCheckPornIllegalReply);
            this.pnlOriginalPictureCheckPornMessage.Controls.Add(this.lblOriginalPictureCheckPornErrorReply);
            this.pnlOriginalPictureCheckPornMessage.Enabled = false;
            this.pnlOriginalPictureCheckPornMessage.Location = new System.Drawing.Point(3, 39);
            this.pnlOriginalPictureCheckPornMessage.Name = "pnlOriginalPictureCheckPornMessage";
            this.pnlOriginalPictureCheckPornMessage.Size = new System.Drawing.Size(640, 63);
            this.pnlOriginalPictureCheckPornMessage.TabIndex = 6;
            // 
            // lblOriginalPictureCheckPornIllegalReply
            // 
            this.lblOriginalPictureCheckPornIllegalReply.AutoSize = true;
            this.lblOriginalPictureCheckPornIllegalReply.Location = new System.Drawing.Point(13, 6);
            this.lblOriginalPictureCheckPornIllegalReply.Name = "lblOriginalPictureCheckPornIllegalReply";
            this.lblOriginalPictureCheckPornIllegalReply.Size = new System.Drawing.Size(107, 17);
            this.lblOriginalPictureCheckPornIllegalReply.TabIndex = 2;
            this.lblOriginalPictureCheckPornIllegalReply.Text = "鉴黄不通过回复语:";
            // 
            // txbOriginalPictureCheckPornErrorReply
            // 
            this.txbOriginalPictureCheckPornErrorReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOriginalPictureCheckPornErrorReply.Location = new System.Drawing.Point(126, 32);
            this.txbOriginalPictureCheckPornErrorReply.Name = "txbOriginalPictureCheckPornErrorReply";
            this.txbOriginalPictureCheckPornErrorReply.Size = new System.Drawing.Size(503, 23);
            this.txbOriginalPictureCheckPornErrorReply.TabIndex = 5;
            // 
            // txbOriginalPictureCheckPornIllegalReply
            // 
            this.txbOriginalPictureCheckPornIllegalReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOriginalPictureCheckPornIllegalReply.Location = new System.Drawing.Point(126, 3);
            this.txbOriginalPictureCheckPornIllegalReply.Name = "txbOriginalPictureCheckPornIllegalReply";
            this.txbOriginalPictureCheckPornIllegalReply.Size = new System.Drawing.Size(503, 23);
            this.txbOriginalPictureCheckPornIllegalReply.TabIndex = 3;
            // 
            // lblOriginalPictureCheckPornErrorReply
            // 
            this.lblOriginalPictureCheckPornErrorReply.AutoSize = true;
            this.lblOriginalPictureCheckPornErrorReply.Location = new System.Drawing.Point(13, 35);
            this.lblOriginalPictureCheckPornErrorReply.Name = "lblOriginalPictureCheckPornErrorReply";
            this.lblOriginalPictureCheckPornErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblOriginalPictureCheckPornErrorReply.TabIndex = 4;
            this.lblOriginalPictureCheckPornErrorReply.Text = "鉴黄错误回复语:";
            // 
            // pnlOriginalPictureCheckPornEvent
            // 
            this.pnlOriginalPictureCheckPornEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOriginalPictureCheckPornEvent.Controls.Add(this.rdoOriginalPictureCheckPornSendByForward);
            this.pnlOriginalPictureCheckPornEvent.Controls.Add(this.rdoOriginalPictureCheckPornDoNothing);
            this.pnlOriginalPictureCheckPornEvent.Controls.Add(this.rdoOriginalPictureCheckPornReply);
            this.pnlOriginalPictureCheckPornEvent.Location = new System.Drawing.Point(101, 3);
            this.pnlOriginalPictureCheckPornEvent.Name = "pnlOriginalPictureCheckPornEvent";
            this.pnlOriginalPictureCheckPornEvent.Size = new System.Drawing.Size(531, 30);
            this.pnlOriginalPictureCheckPornEvent.TabIndex = 1;
            // 
            // rdoOriginalPictureCheckPornSendByForward
            // 
            this.rdoOriginalPictureCheckPornSendByForward.AutoSize = true;
            this.rdoOriginalPictureCheckPornSendByForward.Checked = true;
            this.rdoOriginalPictureCheckPornSendByForward.Location = new System.Drawing.Point(3, 5);
            this.rdoOriginalPictureCheckPornSendByForward.Name = "rdoOriginalPictureCheckPornSendByForward";
            this.rdoOriginalPictureCheckPornSendByForward.Size = new System.Drawing.Size(146, 21);
            this.rdoOriginalPictureCheckPornSendByForward.TabIndex = 0;
            this.rdoOriginalPictureCheckPornSendByForward.TabStop = true;
            this.rdoOriginalPictureCheckPornSendByForward.Tag = "0";
            this.rdoOriginalPictureCheckPornSendByForward.Text = "以合并转发的方式发送";
            this.rdoOriginalPictureCheckPornSendByForward.UseVisualStyleBackColor = true;
            this.rdoOriginalPictureCheckPornSendByForward.CheckedChanged += new System.EventHandler(this.rdoOriginalPictureCheckPornSendByForward_CheckedChanged);
            // 
            // rdoOriginalPictureCheckPornDoNothing
            // 
            this.rdoOriginalPictureCheckPornDoNothing.AutoSize = true;
            this.rdoOriginalPictureCheckPornDoNothing.Location = new System.Drawing.Point(172, 5);
            this.rdoOriginalPictureCheckPornDoNothing.Name = "rdoOriginalPictureCheckPornDoNothing";
            this.rdoOriginalPictureCheckPornDoNothing.Size = new System.Drawing.Size(86, 21);
            this.rdoOriginalPictureCheckPornDoNothing.TabIndex = 0;
            this.rdoOriginalPictureCheckPornDoNothing.Tag = "1";
            this.rdoOriginalPictureCheckPornDoNothing.Text = "不发送图片";
            this.rdoOriginalPictureCheckPornDoNothing.UseVisualStyleBackColor = true;
            this.rdoOriginalPictureCheckPornDoNothing.CheckedChanged += new System.EventHandler(this.rdoOriginalPictureCheckPornSendByForward_CheckedChanged);
            // 
            // rdoOriginalPictureCheckPornReply
            // 
            this.rdoOriginalPictureCheckPornReply.AutoSize = true;
            this.rdoOriginalPictureCheckPornReply.Location = new System.Drawing.Point(283, 5);
            this.rdoOriginalPictureCheckPornReply.Name = "rdoOriginalPictureCheckPornReply";
            this.rdoOriginalPictureCheckPornReply.Size = new System.Drawing.Size(98, 21);
            this.rdoOriginalPictureCheckPornReply.TabIndex = 0;
            this.rdoOriginalPictureCheckPornReply.Tag = "2";
            this.rdoOriginalPictureCheckPornReply.Text = "回复以下消息";
            this.rdoOriginalPictureCheckPornReply.UseVisualStyleBackColor = true;
            this.rdoOriginalPictureCheckPornReply.CheckedChanged += new System.EventHandler(this.rdoOriginalPictureCheckPornSendByForward_CheckedChanged);
            // 
            // lblOriginalPictureCheckPornEvent
            // 
            this.lblOriginalPictureCheckPornEvent.AutoSize = true;
            this.lblOriginalPictureCheckPornEvent.Location = new System.Drawing.Point(12, 10);
            this.lblOriginalPictureCheckPornEvent.Name = "lblOriginalPictureCheckPornEvent";
            this.lblOriginalPictureCheckPornEvent.Size = new System.Drawing.Size(83, 17);
            this.lblOriginalPictureCheckPornEvent.TabIndex = 0;
            this.lblOriginalPictureCheckPornEvent.Text = "鉴黄不通过时:";
            // 
            // chkOriginalPictureEnabled
            // 
            this.chkOriginalPictureEnabled.AutoSize = true;
            this.chkOriginalPictureEnabled.Location = new System.Drawing.Point(9, 8);
            this.chkOriginalPictureEnabled.Name = "chkOriginalPictureEnabled";
            this.chkOriginalPictureEnabled.Size = new System.Drawing.Size(124, 21);
            this.chkOriginalPictureEnabled.TabIndex = 0;
            this.chkOriginalPictureEnabled.Text = "启用下载Pixiv原图";
            this.chkOriginalPictureEnabled.UseVisualStyleBackColor = true;
            this.chkOriginalPictureEnabled.CheckedChanged += new System.EventHandler(this.chkOriginalPictureEnabled_CheckedChanged);
            // 
            // pageHPicture
            // 
            this.pageHPicture.AutoScroll = true;
            this.pageHPicture.Controls.Add(this.pnlHPictureEnabeled);
            this.pageHPicture.Controls.Add(this.chkHPictureEnabled);
            this.pageHPicture.Location = new System.Drawing.Point(4, 26);
            this.pageHPicture.Margin = new System.Windows.Forms.Padding(4);
            this.pageHPicture.Name = "pageHPicture";
            this.pageHPicture.Padding = new System.Windows.Forms.Padding(4);
            this.pageHPicture.Size = new System.Drawing.Size(652, 687);
            this.pageHPicture.TabIndex = 0;
            this.pageHPicture.Text = "色图设置";
            this.pageHPicture.UseVisualStyleBackColor = true;
            // 
            // pnlHPictureEnabeled
            // 
            this.pnlHPictureEnabeled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHPictureEnabeled.AutoScroll = true;
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureSendByForward);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureSendTags);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureSendUrl);
            this.pnlHPictureEnabeled.Controls.Add(this.pnlHPictureCheckBoxes);
            this.pnlHPictureEnabeled.Controls.Add(this.lblHPictureOnceMessageMaxImageCountHelp);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureOnceMessageMaxImageCount);
            this.pnlHPictureEnabeled.Controls.Add(this.lblHPictureOnceMessageMaxImageCount);
            this.pnlHPictureEnabeled.Controls.Add(this.lblBeautyPictureSource);
            this.pnlHPictureEnabeled.Controls.Add(this.lblHPictureSource);
            this.pnlHPictureEnabeled.Controls.Add(this.chkEnabledGreenOnionsBeautyPicture);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureEnabledGreenOnionsSource);
            this.pnlHPictureEnabeled.Controls.Add(this.chkEnabledELFBeautyPicture);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureEnabledLoliconSource);
            this.pnlHPictureEnabeled.Controls.Add(this.rodHPictureLimitCount);
            this.pnlHPictureEnabeled.Controls.Add(this.rdoHPictureLimitFrequency);
            this.pnlHPictureEnabeled.Controls.Add(this.txbAddToWhiteGroup);
            this.pnlHPictureEnabeled.Controls.Add(this.txbUserHPictureCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPicturePMCD);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureWhiteCD);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPicturePMRevoke);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureWhiteRevoke);
            this.pnlHPictureEnabeled.Controls.Add(this.lstHPictureUserCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.lstHPictureWhiteGroup);
            this.pnlHPictureEnabeled.Controls.Add(this.lblPMRevoke);
            this.pnlHPictureEnabeled.Controls.Add(this.lblWhiteRevoke);
            this.pnlHPictureEnabeled.Controls.Add(this.lblPMCD);
            this.pnlHPictureEnabeled.Controls.Add(this.lblWhiteCD);
            this.pnlHPictureEnabeled.Controls.Add(this.lblCD);
            this.pnlHPictureEnabeled.Controls.Add(this.lblDownloadFail);
            this.pnlHPictureEnabeled.Controls.Add(this.lblNoResult);
            this.pnlHPictureEnabeled.Controls.Add(this.lblErrorReply);
            this.pnlHPictureEnabeled.Controls.Add(this.lblOutOfLimitReply);
            this.pnlHPictureEnabeled.Controls.Add(this.lblCDUnreadyReply);
            this.pnlHPictureEnabeled.Controls.Add(this.lblLimit);
            this.pnlHPictureEnabeled.Controls.Add(this.lblRevoke);
            this.pnlHPictureEnabeled.Controls.Add(this.lblWhiteGroup);
            this.pnlHPictureEnabeled.Controls.Add(this.txbDownloadFailReply);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureNoResultReply);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureErrorReplyReply);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureOutOfLimitReply);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureCDUnreadyReply);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureCD);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureLimit);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureRevoke);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureAllowR18);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureAdminNoLimit);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureWhiteNoLimit);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPicturePMNoLimit);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureR18WhiteOnly);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureWhiteOnly);
            this.pnlHPictureEnabeled.Controls.Add(this.chkHPictureAllowPM);
            this.pnlHPictureEnabeled.Controls.Add(this.lblUserCmdInformation);
            this.pnlHPictureEnabeled.Controls.Add(this.lblAddToWhiteGroupInformation);
            this.pnlHPictureEnabeled.Controls.Add(this.lblApiKey);
            this.pnlHPictureEnabeled.Controls.Add(this.lblLoliconHPictureCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.btnRemoveWhiteGroup);
            this.pnlHPictureEnabeled.Controls.Add(this.btnAddToWhiteGroup);
            this.pnlHPictureEnabeled.Controls.Add(this.btnRemoveUserHPictureCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.btnAddUserHPictureCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.lblUserHPictureCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.lblLimitType);
            this.pnlHPictureEnabeled.Controls.Add(this.lblUserCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureCmd);
            this.pnlHPictureEnabeled.Controls.Add(this.txbHPictureApiKey);
            this.pnlHPictureEnabeled.Enabled = false;
            this.pnlHPictureEnabeled.Location = new System.Drawing.Point(4, 37);
            this.pnlHPictureEnabeled.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHPictureEnabeled.Name = "pnlHPictureEnabeled";
            this.pnlHPictureEnabeled.Size = new System.Drawing.Size(644, 642);
            this.pnlHPictureEnabeled.TabIndex = 8;
            // 
            // chkHPictureSendByForward
            // 
            this.chkHPictureSendByForward.AutoSize = true;
            this.chkHPictureSendByForward.Location = new System.Drawing.Point(462, 485);
            this.chkHPictureSendByForward.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureSendByForward.Name = "chkHPictureSendByForward";
            this.chkHPictureSendByForward.Size = new System.Drawing.Size(147, 21);
            this.chkHPictureSendByForward.TabIndex = 22;
            this.chkHPictureSendByForward.Text = "以合并转发的方式发送";
            this.chkHPictureSendByForward.UseVisualStyleBackColor = true;
            // 
            // chkHPictureSendTags
            // 
            this.chkHPictureSendTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHPictureSendTags.AutoSize = true;
            this.chkHPictureSendTags.Enabled = false;
            this.chkHPictureSendTags.Location = new System.Drawing.Point(535, 629);
            this.chkHPictureSendTags.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureSendTags.Name = "chkHPictureSendTags";
            this.chkHPictureSendTags.Size = new System.Drawing.Size(75, 21);
            this.chkHPictureSendTags.TabIndex = 21;
            this.chkHPictureSendTags.Text = "发送标签";
            this.chkHPictureSendTags.UseVisualStyleBackColor = true;
            // 
            // chkHPictureSendUrl
            // 
            this.chkHPictureSendUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHPictureSendUrl.AutoSize = true;
            this.chkHPictureSendUrl.Location = new System.Drawing.Point(436, 629);
            this.chkHPictureSendUrl.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureSendUrl.Name = "chkHPictureSendUrl";
            this.chkHPictureSendUrl.Size = new System.Drawing.Size(75, 21);
            this.chkHPictureSendUrl.TabIndex = 20;
            this.chkHPictureSendUrl.Text = "发送地址";
            this.chkHPictureSendUrl.UseVisualStyleBackColor = true;
            this.chkHPictureSendUrl.CheckedChanged += new System.EventHandler(this.chkHPictureSendUrl_CheckedChanged);
            // 
            // pnlHPictureCheckBoxes
            // 
            this.pnlHPictureCheckBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHPictureCheckBoxes.Controls.Add(this.lnkResetHPicture);
            this.pnlHPictureCheckBoxes.Controls.Add(this.chkHPictureSize1200);
            this.pnlHPictureCheckBoxes.Controls.Add(this.chkRevokeBeautyPicture);
            this.pnlHPictureCheckBoxes.Location = new System.Drawing.Point(519, 3);
            this.pnlHPictureCheckBoxes.MinimumSize = new System.Drawing.Size(105, 0);
            this.pnlHPictureCheckBoxes.Name = "pnlHPictureCheckBoxes";
            this.pnlHPictureCheckBoxes.Size = new System.Drawing.Size(105, 132);
            this.pnlHPictureCheckBoxes.TabIndex = 19;
            // 
            // lnkResetHPicture
            // 
            this.lnkResetHPicture.AutoSize = true;
            this.lnkResetHPicture.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkResetHPicture.Location = new System.Drawing.Point(4, 76);
            this.lnkResetHPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkResetHPicture.Name = "lnkResetHPicture";
            this.lnkResetHPicture.Size = new System.Drawing.Size(32, 17);
            this.lnkResetHPicture.TabIndex = 5;
            this.lnkResetHPicture.TabStop = true;
            this.lnkResetHPicture.Text = "还原";
            this.lnkResetHPicture.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkResetHPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetHPicture_LinkClicked);
            // 
            // chkHPictureSize1200
            // 
            this.chkHPictureSize1200.AutoSize = true;
            this.chkHPictureSize1200.Location = new System.Drawing.Point(4, 35);
            this.chkHPictureSize1200.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureSize1200.Name = "chkHPictureSize1200";
            this.chkHPictureSize1200.Size = new System.Drawing.Size(103, 21);
            this.chkHPictureSize1200.TabIndex = 7;
            this.chkHPictureSize1200.Text = "1200像素模式";
            this.chkHPictureSize1200.UseVisualStyleBackColor = true;
            // 
            // chkRevokeBeautyPicture
            // 
            this.chkRevokeBeautyPicture.AutoSize = true;
            this.chkRevokeBeautyPicture.Location = new System.Drawing.Point(4, 111);
            this.chkRevokeBeautyPicture.Name = "chkRevokeBeautyPicture";
            this.chkRevokeBeautyPicture.Size = new System.Drawing.Size(75, 21);
            this.chkRevokeBeautyPicture.TabIndex = 14;
            this.chkRevokeBeautyPicture.Text = "撤回美图";
            this.chkRevokeBeautyPicture.UseVisualStyleBackColor = true;
            // 
            // lblHPictureOnceMessageMaxImageCountHelp
            // 
            this.lblHPictureOnceMessageMaxImageCountHelp.AutoSize = true;
            this.lblHPictureOnceMessageMaxImageCountHelp.Location = new System.Drawing.Point(137, 224);
            this.lblHPictureOnceMessageMaxImageCountHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureOnceMessageMaxImageCountHelp.Name = "lblHPictureOnceMessageMaxImageCountHelp";
            this.lblHPictureOnceMessageMaxImageCountHelp.Size = new System.Drawing.Size(261, 17);
            this.lblHPictureOnceMessageMaxImageCountHelp.TabIndex = 18;
            this.lblHPictureOnceMessageMaxImageCountHelp.Text = "支持1-100, 建议不超过10个, 否则可能无法撤回";
            // 
            // txbHPictureOnceMessageMaxImageCount
            // 
            this.txbHPictureOnceMessageMaxImageCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHPictureOnceMessageMaxImageCount.Location = new System.Drawing.Point(139, 197);
            this.txbHPictureOnceMessageMaxImageCount.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureOnceMessageMaxImageCount.MinimumSize = new System.Drawing.Size(60, 0);
            this.txbHPictureOnceMessageMaxImageCount.Name = "txbHPictureOnceMessageMaxImageCount";
            this.txbHPictureOnceMessageMaxImageCount.Size = new System.Drawing.Size(60, 23);
            this.txbHPictureOnceMessageMaxImageCount.TabIndex = 17;
            // 
            // lblHPictureOnceMessageMaxImageCount
            // 
            this.lblHPictureOnceMessageMaxImageCount.AutoSize = true;
            this.lblHPictureOnceMessageMaxImageCount.Location = new System.Drawing.Point(9, 200);
            this.lblHPictureOnceMessageMaxImageCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureOnceMessageMaxImageCount.Name = "lblHPictureOnceMessageMaxImageCount";
            this.lblHPictureOnceMessageMaxImageCount.Size = new System.Drawing.Size(131, 17);
            this.lblHPictureOnceMessageMaxImageCount.TabIndex = 16;
            this.lblHPictureOnceMessageMaxImageCount.Text = "单次请求最大图片数量:";
            // 
            // lblBeautyPictureSource
            // 
            this.lblBeautyPictureSource.AutoSize = true;
            this.lblBeautyPictureSource.Location = new System.Drawing.Point(8, 170);
            this.lblBeautyPictureSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBeautyPictureSource.Name = "lblBeautyPictureSource";
            this.lblBeautyPictureSource.Size = new System.Drawing.Size(59, 17);
            this.lblBeautyPictureSource.TabIndex = 15;
            this.lblBeautyPictureSource.Text = "美图图库:";
            // 
            // lblHPictureSource
            // 
            this.lblHPictureSource.AutoSize = true;
            this.lblHPictureSource.Location = new System.Drawing.Point(8, 143);
            this.lblHPictureSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPictureSource.Name = "lblHPictureSource";
            this.lblHPictureSource.Size = new System.Drawing.Size(59, 17);
            this.lblHPictureSource.TabIndex = 15;
            this.lblHPictureSource.Text = "色图图库:";
            // 
            // chkEnabledGreenOnionsBeautyPicture
            // 
            this.chkEnabledGreenOnionsBeautyPicture.AutoSize = true;
            this.chkEnabledGreenOnionsBeautyPicture.Location = new System.Drawing.Point(364, 169);
            this.chkEnabledGreenOnionsBeautyPicture.Name = "chkEnabledGreenOnionsBeautyPicture";
            this.chkEnabledGreenOnionsBeautyPicture.Size = new System.Drawing.Size(99, 21);
            this.chkEnabledGreenOnionsBeautyPicture.TabIndex = 14;
            this.chkEnabledGreenOnionsBeautyPicture.Text = "启用葱葱图库";
            this.chkEnabledGreenOnionsBeautyPicture.UseVisualStyleBackColor = true;
            this.chkEnabledGreenOnionsBeautyPicture.Visible = false;
            // 
            // chkHPictureEnabledGreenOnionsSource
            // 
            this.chkHPictureEnabledGreenOnionsSource.AutoSize = true;
            this.chkHPictureEnabledGreenOnionsSource.Location = new System.Drawing.Point(364, 142);
            this.chkHPictureEnabledGreenOnionsSource.Name = "chkHPictureEnabledGreenOnionsSource";
            this.chkHPictureEnabledGreenOnionsSource.Size = new System.Drawing.Size(99, 21);
            this.chkHPictureEnabledGreenOnionsSource.TabIndex = 14;
            this.chkHPictureEnabledGreenOnionsSource.Text = "启用葱葱图库";
            this.chkHPictureEnabledGreenOnionsSource.UseVisualStyleBackColor = true;
            this.chkHPictureEnabledGreenOnionsSource.Visible = false;
            // 
            // chkEnabledELFBeautyPicture
            // 
            this.chkEnabledELFBeautyPicture.AutoSize = true;
            this.chkEnabledELFBeautyPicture.Location = new System.Drawing.Point(254, 169);
            this.chkEnabledELFBeautyPicture.Name = "chkEnabledELFBeautyPicture";
            this.chkEnabledELFBeautyPicture.Size = new System.Drawing.Size(94, 21);
            this.chkEnabledELFBeautyPicture.TabIndex = 14;
            this.chkEnabledELFBeautyPicture.Text = "启用ELF图库";
            this.chkEnabledELFBeautyPicture.UseVisualStyleBackColor = true;
            // 
            // chkHPictureEnabledLoliconSource
            // 
            this.chkHPictureEnabledLoliconSource.AutoSize = true;
            this.chkHPictureEnabledLoliconSource.Location = new System.Drawing.Point(137, 142);
            this.chkHPictureEnabledLoliconSource.Name = "chkHPictureEnabledLoliconSource";
            this.chkHPictureEnabledLoliconSource.Size = new System.Drawing.Size(116, 21);
            this.chkHPictureEnabledLoliconSource.TabIndex = 14;
            this.chkHPictureEnabledLoliconSource.Text = "启用Lolicon图库";
            this.chkHPictureEnabledLoliconSource.UseVisualStyleBackColor = true;
            // 
            // rodHPictureLimitCount
            // 
            this.rodHPictureLimitCount.AutoSize = true;
            this.rodHPictureLimitCount.Location = new System.Drawing.Point(264, 593);
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
            this.rdoHPictureLimitFrequency.Location = new System.Drawing.Point(203, 593);
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
            this.txbAddToWhiteGroup.Location = new System.Drawing.Point(425, 397);
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
            this.txbUserHPictureCmd.Location = new System.Drawing.Point(427, 276);
            this.txbUserHPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserHPictureCmd.Name = "txbUserHPictureCmd";
            this.txbUserHPictureCmd.Size = new System.Drawing.Size(186, 23);
            this.txbUserHPictureCmd.TabIndex = 2;
            // 
            // txbHPicturePMCD
            // 
            this.txbHPicturePMCD.Location = new System.Drawing.Point(515, 514);
            this.txbHPicturePMCD.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPicturePMCD.Name = "txbHPicturePMCD";
            this.txbHPicturePMCD.ShortcutsEnabled = false;
            this.txbHPicturePMCD.Size = new System.Drawing.Size(93, 23);
            this.txbHPicturePMCD.TabIndex = 8;
            this.txbHPicturePMCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHPicturePMCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHPictureWhiteCD
            // 
            this.txbHPictureWhiteCD.Location = new System.Drawing.Point(309, 514);
            this.txbHPictureWhiteCD.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureWhiteCD.Name = "txbHPictureWhiteCD";
            this.txbHPictureWhiteCD.ShortcutsEnabled = false;
            this.txbHPictureWhiteCD.Size = new System.Drawing.Size(93, 23);
            this.txbHPictureWhiteCD.TabIndex = 8;
            this.txbHPictureWhiteCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHPictureWhiteCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHPicturePMRevoke
            // 
            this.txbHPicturePMRevoke.Location = new System.Drawing.Point(515, 552);
            this.txbHPicturePMRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPicturePMRevoke.Name = "txbHPicturePMRevoke";
            this.txbHPicturePMRevoke.ShortcutsEnabled = false;
            this.txbHPicturePMRevoke.Size = new System.Drawing.Size(93, 23);
            this.txbHPicturePMRevoke.TabIndex = 8;
            this.txbHPicturePMRevoke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHPicturePMRevoke.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHPictureWhiteRevoke
            // 
            this.txbHPictureWhiteRevoke.Location = new System.Drawing.Point(309, 553);
            this.txbHPictureWhiteRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureWhiteRevoke.Name = "txbHPictureWhiteRevoke";
            this.txbHPictureWhiteRevoke.ShortcutsEnabled = false;
            this.txbHPictureWhiteRevoke.Size = new System.Drawing.Size(93, 23);
            this.txbHPictureWhiteRevoke.TabIndex = 8;
            this.txbHPictureWhiteRevoke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHPictureWhiteRevoke.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // lstHPictureUserCmd
            // 
            this.lstHPictureUserCmd.FullRowSelect = true;
            this.lstHPictureUserCmd.Location = new System.Drawing.Point(137, 255);
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
            this.lstHPictureWhiteGroup.Location = new System.Drawing.Point(135, 379);
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
            this.lblPMRevoke.Location = new System.Drawing.Point(417, 556);
            this.lblPMRevoke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPMRevoke.Name = "lblPMRevoke";
            this.lblPMRevoke.Size = new System.Drawing.Size(83, 17);
            this.lblPMRevoke.TabIndex = 9;
            this.lblPMRevoke.Text = "私聊撤回时间:";
            // 
            // lblWhiteRevoke
            // 
            this.lblWhiteRevoke.AutoSize = true;
            this.lblWhiteRevoke.Location = new System.Drawing.Point(199, 555);
            this.lblWhiteRevoke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhiteRevoke.Name = "lblWhiteRevoke";
            this.lblWhiteRevoke.Size = new System.Drawing.Size(95, 17);
            this.lblWhiteRevoke.TabIndex = 9;
            this.lblWhiteRevoke.Text = "白名单撤回时间:";
            // 
            // lblPMCD
            // 
            this.lblPMCD.AutoSize = true;
            this.lblPMCD.Location = new System.Drawing.Point(417, 518);
            this.lblPMCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPMCD.Name = "lblPMCD";
            this.lblPMCD.Size = new System.Drawing.Size(83, 17);
            this.lblPMCD.TabIndex = 9;
            this.lblPMCD.Text = "私聊冷却时间:";
            // 
            // lblWhiteCD
            // 
            this.lblWhiteCD.AutoSize = true;
            this.lblWhiteCD.Location = new System.Drawing.Point(199, 518);
            this.lblWhiteCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhiteCD.Name = "lblWhiteCD";
            this.lblWhiteCD.Size = new System.Drawing.Size(95, 17);
            this.lblWhiteCD.TabIndex = 9;
            this.lblWhiteCD.Text = "白名单冷却时间:";
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Location = new System.Drawing.Point(5, 518);
            this.lblCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(71, 17);
            this.lblCD.TabIndex = 9;
            this.lblCD.Text = "群冷却时间:";
            // 
            // lblDownloadFail
            // 
            this.lblDownloadFail.AutoSize = true;
            this.lblDownloadFail.Location = new System.Drawing.Point(5, 786);
            this.lblDownloadFail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadFail.Name = "lblDownloadFail";
            this.lblDownloadFail.Size = new System.Drawing.Size(119, 17);
            this.lblDownloadFail.TabIndex = 9;
            this.lblDownloadFail.Text = "图片下载失败回复语:";
            // 
            // lblNoResult
            // 
            this.lblNoResult.AutoSize = true;
            this.lblNoResult.Location = new System.Drawing.Point(5, 756);
            this.lblNoResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoResult.Name = "lblNoResult";
            this.lblNoResult.Size = new System.Drawing.Size(83, 17);
            this.lblNoResult.TabIndex = 9;
            this.lblNoResult.Text = "无结果回复语:";
            // 
            // lblErrorReply
            // 
            this.lblErrorReply.AutoSize = true;
            this.lblErrorReply.Location = new System.Drawing.Point(5, 726);
            this.lblErrorReply.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorReply.Name = "lblErrorReply";
            this.lblErrorReply.Size = new System.Drawing.Size(95, 17);
            this.lblErrorReply.TabIndex = 9;
            this.lblErrorReply.Text = "发生错误回复语:";
            // 
            // lblOutOfLimitReply
            // 
            this.lblOutOfLimitReply.AutoSize = true;
            this.lblOutOfLimitReply.Location = new System.Drawing.Point(5, 696);
            this.lblOutOfLimitReply.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutOfLimitReply.Name = "lblOutOfLimitReply";
            this.lblOutOfLimitReply.Size = new System.Drawing.Size(95, 17);
            this.lblOutOfLimitReply.TabIndex = 9;
            this.lblOutOfLimitReply.Text = "超过次数回复语:";
            // 
            // lblCDUnreadyReply
            // 
            this.lblCDUnreadyReply.AutoSize = true;
            this.lblCDUnreadyReply.Location = new System.Drawing.Point(5, 667);
            this.lblCDUnreadyReply.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCDUnreadyReply.Name = "lblCDUnreadyReply";
            this.lblCDUnreadyReply.Size = new System.Drawing.Size(107, 17);
            this.lblCDUnreadyReply.TabIndex = 9;
            this.lblCDUnreadyReply.Text = "冷却时间内回复语:";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(5, 595);
            this.lblLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(59, 17);
            this.lblLimit.TabIndex = 9;
            this.lblLimit.Text = "次数限制:";
            // 
            // lblRevoke
            // 
            this.lblRevoke.AutoSize = true;
            this.lblRevoke.Location = new System.Drawing.Point(5, 556);
            this.lblRevoke.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevoke.Name = "lblRevoke";
            this.lblRevoke.Size = new System.Drawing.Size(71, 17);
            this.lblRevoke.TabIndex = 9;
            this.lblRevoke.Text = "群撤回时间:";
            // 
            // lblWhiteGroup
            // 
            this.lblWhiteGroup.AutoSize = true;
            this.lblWhiteGroup.Location = new System.Drawing.Point(4, 391);
            this.lblWhiteGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhiteGroup.Name = "lblWhiteGroup";
            this.lblWhiteGroup.Size = new System.Drawing.Size(59, 17);
            this.lblWhiteGroup.TabIndex = 9;
            this.lblWhiteGroup.Text = "群白名单:";
            // 
            // txbDownloadFailReply
            // 
            this.txbDownloadFailReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDownloadFailReply.Location = new System.Drawing.Point(140, 783);
            this.txbDownloadFailReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbDownloadFailReply.MinimumSize = new System.Drawing.Size(473, 0);
            this.txbDownloadFailReply.Multiline = true;
            this.txbDownloadFailReply.Name = "txbDownloadFailReply";
            this.txbDownloadFailReply.Size = new System.Drawing.Size(473, 23);
            this.txbDownloadFailReply.TabIndex = 8;
            // 
            // txbHPictureNoResultReply
            // 
            this.txbHPictureNoResultReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHPictureNoResultReply.Location = new System.Drawing.Point(140, 753);
            this.txbHPictureNoResultReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureNoResultReply.MinimumSize = new System.Drawing.Size(473, 0);
            this.txbHPictureNoResultReply.Multiline = true;
            this.txbHPictureNoResultReply.Name = "txbHPictureNoResultReply";
            this.txbHPictureNoResultReply.Size = new System.Drawing.Size(473, 23);
            this.txbHPictureNoResultReply.TabIndex = 8;
            // 
            // txbHPictureErrorReplyReply
            // 
            this.txbHPictureErrorReplyReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHPictureErrorReplyReply.Location = new System.Drawing.Point(140, 723);
            this.txbHPictureErrorReplyReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureErrorReplyReply.MinimumSize = new System.Drawing.Size(473, 0);
            this.txbHPictureErrorReplyReply.Multiline = true;
            this.txbHPictureErrorReplyReply.Name = "txbHPictureErrorReplyReply";
            this.txbHPictureErrorReplyReply.Size = new System.Drawing.Size(473, 23);
            this.txbHPictureErrorReplyReply.TabIndex = 8;
            // 
            // txbHPictureOutOfLimitReply
            // 
            this.txbHPictureOutOfLimitReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHPictureOutOfLimitReply.Location = new System.Drawing.Point(140, 693);
            this.txbHPictureOutOfLimitReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureOutOfLimitReply.MinimumSize = new System.Drawing.Size(473, 0);
            this.txbHPictureOutOfLimitReply.Multiline = true;
            this.txbHPictureOutOfLimitReply.Name = "txbHPictureOutOfLimitReply";
            this.txbHPictureOutOfLimitReply.Size = new System.Drawing.Size(473, 23);
            this.txbHPictureOutOfLimitReply.TabIndex = 8;
            // 
            // txbHPictureCDUnreadyReply
            // 
            this.txbHPictureCDUnreadyReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHPictureCDUnreadyReply.Location = new System.Drawing.Point(140, 663);
            this.txbHPictureCDUnreadyReply.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureCDUnreadyReply.MinimumSize = new System.Drawing.Size(473, 0);
            this.txbHPictureCDUnreadyReply.Multiline = true;
            this.txbHPictureCDUnreadyReply.Name = "txbHPictureCDUnreadyReply";
            this.txbHPictureCDUnreadyReply.Size = new System.Drawing.Size(473, 23);
            this.txbHPictureCDUnreadyReply.TabIndex = 8;
            // 
            // txbHPictureCD
            // 
            this.txbHPictureCD.Location = new System.Drawing.Point(91, 514);
            this.txbHPictureCD.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureCD.Name = "txbHPictureCD";
            this.txbHPictureCD.ShortcutsEnabled = false;
            this.txbHPictureCD.Size = new System.Drawing.Size(93, 23);
            this.txbHPictureCD.TabIndex = 8;
            this.txbHPictureCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHPictureCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHPictureLimit
            // 
            this.txbHPictureLimit.Location = new System.Drawing.Point(92, 590);
            this.txbHPictureLimit.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureLimit.Name = "txbHPictureLimit";
            this.txbHPictureLimit.ShortcutsEnabled = false;
            this.txbHPictureLimit.Size = new System.Drawing.Size(93, 23);
            this.txbHPictureLimit.TabIndex = 8;
            this.txbHPictureLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHPictureLimit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHPictureRevoke
            // 
            this.txbHPictureRevoke.Location = new System.Drawing.Point(91, 552);
            this.txbHPictureRevoke.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureRevoke.Name = "txbHPictureRevoke";
            this.txbHPictureRevoke.ShortcutsEnabled = false;
            this.txbHPictureRevoke.Size = new System.Drawing.Size(93, 23);
            this.txbHPictureRevoke.TabIndex = 8;
            this.txbHPictureRevoke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHPictureRevoke.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // chkHPictureAllowR18
            // 
            this.chkHPictureAllowR18.AutoSize = true;
            this.chkHPictureAllowR18.Location = new System.Drawing.Point(120, 485);
            this.chkHPictureAllowR18.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureAllowR18.Name = "chkHPictureAllowR18";
            this.chkHPictureAllowR18.Size = new System.Drawing.Size(78, 21);
            this.chkHPictureAllowR18.TabIndex = 7;
            this.chkHPictureAllowR18.Text = "允许R-18";
            this.chkHPictureAllowR18.UseVisualStyleBackColor = true;
            // 
            // chkHPictureAdminNoLimit
            // 
            this.chkHPictureAdminNoLimit.AutoSize = true;
            this.chkHPictureAdminNoLimit.Location = new System.Drawing.Point(118, 629);
            this.chkHPictureAdminNoLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureAdminNoLimit.Name = "chkHPictureAdminNoLimit";
            this.chkHPictureAdminNoLimit.Size = new System.Drawing.Size(135, 21);
            this.chkHPictureAdminNoLimit.TabIndex = 7;
            this.chkHPictureAdminNoLimit.Text = "机器人管理员无限制";
            this.chkHPictureAdminNoLimit.UseVisualStyleBackColor = true;
            // 
            // chkHPictureWhiteNoLimit
            // 
            this.chkHPictureWhiteNoLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHPictureWhiteNoLimit.AutoSize = true;
            this.chkHPictureWhiteNoLimit.Location = new System.Drawing.Point(277, 629);
            this.chkHPictureWhiteNoLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureWhiteNoLimit.Name = "chkHPictureWhiteNoLimit";
            this.chkHPictureWhiteNoLimit.Size = new System.Drawing.Size(135, 21);
            this.chkHPictureWhiteNoLimit.TabIndex = 7;
            this.chkHPictureWhiteNoLimit.Text = "白名单群无次数限制";
            this.chkHPictureWhiteNoLimit.UseVisualStyleBackColor = true;
            // 
            // chkHPicturePMNoLimit
            // 
            this.chkHPicturePMNoLimit.AutoSize = true;
            this.chkHPicturePMNoLimit.Location = new System.Drawing.Point(7, 629);
            this.chkHPicturePMNoLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPicturePMNoLimit.Name = "chkHPicturePMNoLimit";
            this.chkHPicturePMNoLimit.Size = new System.Drawing.Size(87, 21);
            this.chkHPicturePMNoLimit.TabIndex = 7;
            this.chkHPicturePMNoLimit.Text = "私聊无限制";
            this.chkHPicturePMNoLimit.UseVisualStyleBackColor = true;
            // 
            // chkHPictureR18WhiteOnly
            // 
            this.chkHPictureR18WhiteOnly.AutoSize = true;
            this.chkHPictureR18WhiteOnly.Location = new System.Drawing.Point(223, 485);
            this.chkHPictureR18WhiteOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureR18WhiteOnly.Name = "chkHPictureR18WhiteOnly";
            this.chkHPictureR18WhiteOnly.Size = new System.Drawing.Size(114, 21);
            this.chkHPictureR18WhiteOnly.TabIndex = 7;
            this.chkHPictureR18WhiteOnly.Text = "R-18仅限白名单";
            this.chkHPictureR18WhiteOnly.UseVisualStyleBackColor = true;
            // 
            // chkHPictureWhiteOnly
            // 
            this.chkHPictureWhiteOnly.AutoSize = true;
            this.chkHPictureWhiteOnly.Location = new System.Drawing.Point(8, 485);
            this.chkHPictureWhiteOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureWhiteOnly.Name = "chkHPictureWhiteOnly";
            this.chkHPictureWhiteOnly.Size = new System.Drawing.Size(87, 21);
            this.chkHPictureWhiteOnly.TabIndex = 7;
            this.chkHPictureWhiteOnly.Text = "仅限白名单";
            this.chkHPictureWhiteOnly.UseVisualStyleBackColor = true;
            // 
            // chkHPictureAllowPM
            // 
            this.chkHPictureAllowPM.AutoSize = true;
            this.chkHPictureAllowPM.Location = new System.Drawing.Point(362, 485);
            this.chkHPictureAllowPM.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureAllowPM.Name = "chkHPictureAllowPM";
            this.chkHPictureAllowPM.Size = new System.Drawing.Size(75, 21);
            this.chkHPictureAllowPM.TabIndex = 7;
            this.chkHPictureAllowPM.Text = "允许私聊";
            this.chkHPictureAllowPM.UseVisualStyleBackColor = true;
            // 
            // lblUserCmdInformation
            // 
            this.lblUserCmdInformation.AutoSize = true;
            this.lblUserCmdInformation.Location = new System.Drawing.Point(430, 255);
            this.lblUserCmdInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserCmdInformation.Name = "lblUserCmdInformation";
            this.lblUserCmdInformation.Size = new System.Drawing.Size(155, 17);
            this.lblUserCmdInformation.TabIndex = 0;
            this.lblUserCmdInformation.Text = "添加到自定义色图命令列表:";
            // 
            // lblAddToWhiteGroupInformation
            // 
            this.lblAddToWhiteGroupInformation.AutoSize = true;
            this.lblAddToWhiteGroupInformation.Location = new System.Drawing.Point(428, 379);
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
            // lblLoliconHPictureCmd
            // 
            this.lblLoliconHPictureCmd.AutoSize = true;
            this.lblLoliconHPictureCmd.Location = new System.Drawing.Point(8, 79);
            this.lblLoliconHPictureCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoliconHPictureCmd.Name = "lblLoliconHPictureCmd";
            this.lblLoliconHPictureCmd.Size = new System.Drawing.Size(88, 17);
            this.lblLoliconHPictureCmd.TabIndex = 0;
            this.lblLoliconHPictureCmd.Text = "色图/美图命令:";
            // 
            // btnRemoveWhiteGroup
            // 
            this.btnRemoveWhiteGroup.Location = new System.Drawing.Point(331, 428);
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
            this.btnAddToWhiteGroup.Location = new System.Drawing.Point(331, 397);
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
            this.btnRemoveUserHPictureCmd.Location = new System.Drawing.Point(333, 307);
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
            this.btnAddUserHPictureCmd.Location = new System.Drawing.Point(333, 276);
            this.btnAddUserHPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUserHPictureCmd.Name = "btnAddUserHPictureCmd";
            this.btnAddUserHPictureCmd.Size = new System.Drawing.Size(88, 23);
            this.btnAddUserHPictureCmd.TabIndex = 6;
            this.btnAddUserHPictureCmd.Text = "<<添加<<";
            this.btnAddUserHPictureCmd.UseVisualStyleBackColor = true;
            this.btnAddUserHPictureCmd.Click += new System.EventHandler(this.btnAddUserHPictureCmd_Click);
            // 
            // lblUserHPictureCmd
            // 
            this.lblUserHPictureCmd.AutoSize = true;
            this.lblUserHPictureCmd.Location = new System.Drawing.Point(6, 266);
            this.lblUserHPictureCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserHPictureCmd.Name = "lblUserHPictureCmd";
            this.lblUserHPictureCmd.Size = new System.Drawing.Size(95, 17);
            this.lblUserHPictureCmd.TabIndex = 0;
            this.lblUserHPictureCmd.Text = "自定义色图命令:";
            // 
            // lblLimitType
            // 
            this.lblLimitType.AutoSize = true;
            this.lblLimitType.Location = new System.Drawing.Point(336, 594);
            this.lblLimitType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLimitType.Name = "lblLimitType";
            this.lblLimitType.Size = new System.Drawing.Size(258, 17);
            this.lblLimitType.TabIndex = 0;
            this.lblLimitType.Text = "提示:记次模式下单次请求多少张色图都只记1次";
            // 
            // lblUserCmd
            // 
            this.lblUserCmd.AutoSize = true;
            this.lblUserCmd.Location = new System.Drawing.Point(135, 358);
            this.lblUserCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserCmd.Name = "lblUserCmd";
            this.lblUserCmd.Size = new System.Drawing.Size(381, 17);
            this.lblUserCmd.TabIndex = 0;
            this.lblUserCmd.Text = "提示:自定义命令只能完整匹配时生效，返回单张不含R18的随机色图。";
            // 
            // txbHPictureCmd
            // 
            this.txbHPictureCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHPictureCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbHPictureCmd.Location = new System.Drawing.Point(137, 37);
            this.txbHPictureCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureCmd.MinimumSize = new System.Drawing.Size(375, 0);
            this.txbHPictureCmd.Multiline = true;
            this.txbHPictureCmd.Name = "txbHPictureCmd";
            this.txbHPictureCmd.Size = new System.Drawing.Size(375, 98);
            this.txbHPictureCmd.TabIndex = 1;
            // 
            // txbHPictureApiKey
            // 
            this.txbHPictureApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHPictureApiKey.Enabled = false;
            this.txbHPictureApiKey.Location = new System.Drawing.Point(137, 6);
            this.txbHPictureApiKey.Margin = new System.Windows.Forms.Padding(4);
            this.txbHPictureApiKey.MinimumSize = new System.Drawing.Size(375, 0);
            this.txbHPictureApiKey.Name = "txbHPictureApiKey";
            this.txbHPictureApiKey.Size = new System.Drawing.Size(375, 23);
            this.txbHPictureApiKey.TabIndex = 2;
            // 
            // chkHPictureEnabled
            // 
            this.chkHPictureEnabled.AutoSize = true;
            this.chkHPictureEnabled.Location = new System.Drawing.Point(9, 8);
            this.chkHPictureEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.chkHPictureEnabled.Name = "chkHPictureEnabled";
            this.chkHPictureEnabled.Size = new System.Drawing.Size(99, 21);
            this.chkHPictureEnabled.TabIndex = 7;
            this.chkHPictureEnabled.Text = "启用色图功能";
            this.chkHPictureEnabled.UseVisualStyleBackColor = true;
            this.chkHPictureEnabled.CheckedChanged += new System.EventHandler(this.chkEnableHPicture_CheckedChanged);
            // 
            // pageTranslate
            // 
            this.pageTranslate.Controls.Add(this.pnlTranslate);
            this.pageTranslate.Controls.Add(this.chkTranslateEnabled);
            this.pageTranslate.Location = new System.Drawing.Point(4, 26);
            this.pageTranslate.Name = "pageTranslate";
            this.pageTranslate.Size = new System.Drawing.Size(652, 687);
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
            this.pnlTranslate.Location = new System.Drawing.Point(3, 35);
            this.pnlTranslate.Name = "pnlTranslate";
            this.pnlTranslate.Size = new System.Drawing.Size(646, 277);
            this.pnlTranslate.TabIndex = 1;
            // 
            // txbTranslateFromToCMD
            // 
            this.txbTranslateFromToCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblTranslateEngineHelp.Size = new System.Drawing.Size(394, 17);
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
            this.txbTranslateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTranslateTo.Location = new System.Drawing.Point(197, 95);
            this.txbTranslateTo.Name = "txbTranslateTo";
            this.txbTranslateTo.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateTo.TabIndex = 3;
            // 
            // txbTranslateToChinese
            // 
            this.txbTranslateToChinese.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.chkTranslateEnabled.Location = new System.Drawing.Point(9, 8);
            this.chkTranslateEnabled.Name = "chkTranslateEnabled";
            this.chkTranslateEnabled.Size = new System.Drawing.Size(99, 21);
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
            this.pageRepeater.Location = new System.Drawing.Point(4, 26);
            this.pageRepeater.Name = "pageRepeater";
            this.pageRepeater.Size = new System.Drawing.Size(652, 687);
            this.pageRepeater.TabIndex = 5;
            this.pageRepeater.Text = "复读设置";
            this.pageRepeater.UseVisualStyleBackColor = true;
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
            this.txbRewindGifProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txbVerticalMirrorImageProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbVerticalMirrorImageProbability.Location = new System.Drawing.Point(264, 185);
            this.txbVerticalMirrorImageProbability.Name = "txbVerticalMirrorImageProbability";
            this.txbVerticalMirrorImageProbability.Size = new System.Drawing.Size(359, 23);
            this.txbVerticalMirrorImageProbability.TabIndex = 1;
            this.txbVerticalMirrorImageProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbVerticalMirrorImageProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbHorizontalMirrorImageProbability
            // 
            this.txbHorizontalMirrorImageProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbHorizontalMirrorImageProbability.Location = new System.Drawing.Point(264, 145);
            this.txbHorizontalMirrorImageProbability.Name = "txbHorizontalMirrorImageProbability";
            this.txbHorizontalMirrorImageProbability.Size = new System.Drawing.Size(359, 23);
            this.txbHorizontalMirrorImageProbability.TabIndex = 1;
            this.txbHorizontalMirrorImageProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbHorizontalMirrorImageProbability.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbSuccessiveRepeatCount
            // 
            this.txbSuccessiveRepeatCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSuccessiveRepeatCount.Location = new System.Drawing.Point(264, 62);
            this.txbSuccessiveRepeatCount.Name = "txbSuccessiveRepeatCount";
            this.txbSuccessiveRepeatCount.Size = new System.Drawing.Size(359, 23);
            this.txbSuccessiveRepeatCount.TabIndex = 1;
            this.txbSuccessiveRepeatCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbSuccessiveRepeatCount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbRandomRepeatProbability
            // 
            this.txbRandomRepeatProbability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // pageGroupMemberEvents
            // 
            this.pageGroupMemberEvents.Controls.Add(this.txbMemberBeKickedMessage);
            this.pageGroupMemberEvents.Controls.Add(this.txbMemberPositiveLeaveMessage);
            this.pageGroupMemberEvents.Controls.Add(this.txbMemberJoinedMessage);
            this.pageGroupMemberEvents.Controls.Add(this.chkSendMemberBeKickedMessage);
            this.pageGroupMemberEvents.Controls.Add(this.chkSendMemberPositiveLeaveMessage);
            this.pageGroupMemberEvents.Controls.Add(this.chkSendMemberJoinedMessage);
            this.pageGroupMemberEvents.Location = new System.Drawing.Point(4, 26);
            this.pageGroupMemberEvents.Name = "pageGroupMemberEvents";
            this.pageGroupMemberEvents.Size = new System.Drawing.Size(652, 687);
            this.pageGroupMemberEvents.TabIndex = 6;
            this.pageGroupMemberEvents.Text = "进/退群提醒";
            this.pageGroupMemberEvents.UseVisualStyleBackColor = true;
            // 
            // txbMemberBeKickedMessage
            // 
            this.txbMemberBeKickedMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMemberBeKickedMessage.Location = new System.Drawing.Point(244, 110);
            this.txbMemberBeKickedMessage.Name = "txbMemberBeKickedMessage";
            this.txbMemberBeKickedMessage.Size = new System.Drawing.Size(379, 23);
            this.txbMemberBeKickedMessage.TabIndex = 3;
            // 
            // txbMemberPositiveLeaveMessage
            // 
            this.txbMemberPositiveLeaveMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMemberPositiveLeaveMessage.Location = new System.Drawing.Point(244, 68);
            this.txbMemberPositiveLeaveMessage.Name = "txbMemberPositiveLeaveMessage";
            this.txbMemberPositiveLeaveMessage.Size = new System.Drawing.Size(379, 23);
            this.txbMemberPositiveLeaveMessage.TabIndex = 3;
            // 
            // txbMemberJoinedMessage
            // 
            this.txbMemberJoinedMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // pageForgeMessage
            // 
            this.pageForgeMessage.Controls.Add(this.pnlForgeMessage);
            this.pageForgeMessage.Controls.Add(this.chkEnabledForgeMessage);
            this.pageForgeMessage.Location = new System.Drawing.Point(4, 26);
            this.pageForgeMessage.Name = "pageForgeMessage";
            this.pageForgeMessage.Size = new System.Drawing.Size(652, 687);
            this.pageForgeMessage.TabIndex = 7;
            this.pageForgeMessage.Text = "伪造消息";
            this.pageForgeMessage.UseVisualStyleBackColor = true;
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
            this.pnlForgeMessage.Location = new System.Drawing.Point(3, 36);
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
            this.txbForgeMessageCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txbRefuseForgeBotReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txbRefuseForgeAdminReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRefuseForgeAdminReply.Location = new System.Drawing.Point(247, 155);
            this.txbRefuseForgeAdminReply.Name = "txbRefuseForgeAdminReply";
            this.txbRefuseForgeAdminReply.Size = new System.Drawing.Size(363, 23);
            this.txbRefuseForgeAdminReply.TabIndex = 12;
            // 
            // txbForgeMessageAppendMessage
            // 
            this.txbForgeMessageAppendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txbForgeMessageCmdNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txbForgeMessageCmdBegin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbForgeMessageCmdBegin.Location = new System.Drawing.Point(151, 10);
            this.txbForgeMessageCmdBegin.Name = "txbForgeMessageCmdBegin";
            this.txbForgeMessageCmdBegin.Size = new System.Drawing.Size(459, 23);
            this.txbForgeMessageCmdBegin.TabIndex = 10;
            this.txbForgeMessageCmdBegin.TextChanged += new System.EventHandler(this.txbForgeMessageCmd_TextChanged);
            // 
            // chkEnabledForgeMessage
            // 
            this.chkEnabledForgeMessage.AutoSize = true;
            this.chkEnabledForgeMessage.Location = new System.Drawing.Point(9, 8);
            this.chkEnabledForgeMessage.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnabledForgeMessage.Name = "chkEnabledForgeMessage";
            this.chkEnabledForgeMessage.Size = new System.Drawing.Size(123, 21);
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
            this.pageRss.Location = new System.Drawing.Point(4, 26);
            this.pageRss.Name = "pageRss";
            this.pageRss.Size = new System.Drawing.Size(652, 687);
            this.pageRss.TabIndex = 8;
            this.pageRss.Text = "RSS转发";
            this.pageRss.UseVisualStyleBackColor = true;
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
            this.pnlRss.Location = new System.Drawing.Point(3, 35);
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
            // chkRssSendLiveCover
            // 
            this.chkRssSendLiveCover.AutoSize = true;
            this.chkRssSendLiveCover.Location = new System.Drawing.Point(518, 11);
            this.chkRssSendLiveCover.Name = "chkRssSendLiveCover";
            this.chkRssSendLiveCover.Size = new System.Drawing.Size(131, 21);
            this.chkRssSendLiveCover.TabIndex = 0;
            this.chkRssSendLiveCover.Text = "获取B站直播间封面";
            this.chkRssSendLiveCover.UseVisualStyleBackColor = true;
            this.chkRssSendLiveCover.CheckedChanged += new System.EventHandler(this.chkRssEnabled_CheckedChanged);
            // 
            // chkRssEnabled
            // 
            this.chkRssEnabled.AutoSize = true;
            this.chkRssEnabled.Location = new System.Drawing.Point(9, 8);
            this.chkRssEnabled.Name = "chkRssEnabled";
            this.chkRssEnabled.Size = new System.Drawing.Size(121, 21);
            this.chkRssEnabled.TabIndex = 0;
            this.chkRssEnabled.Text = "启用RSS订阅转发";
            this.chkRssEnabled.UseVisualStyleBackColor = true;
            this.chkRssEnabled.CheckedChanged += new System.EventHandler(this.chkRssEnabled_CheckedChanged);
            // 
            // pageTicTacToe
            // 
            this.pageTicTacToe.Controls.Add(this.pnlTicTacToe);
            this.pageTicTacToe.Controls.Add(this.chkTicTacToeEnabled);
            this.pageTicTacToe.Location = new System.Drawing.Point(4, 26);
            this.pageTicTacToe.Name = "pageTicTacToe";
            this.pageTicTacToe.Size = new System.Drawing.Size(652, 687);
            this.pageTicTacToe.TabIndex = 10;
            this.pageTicTacToe.Text = "井字棋";
            this.pageTicTacToe.UseVisualStyleBackColor = true;
            // 
            // pnlTicTacToe
            // 
            this.pnlTicTacToe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeMoveFailReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeMoveFailReply);
            this.pnlTicTacToe.Controls.Add(this.lblChessboard);
            this.pnlTicTacToe.Controls.Add(this.imgChessboard);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeIllegalMoveReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeIllegalMoveReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeNoMoveReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeNoMoveReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeDrawReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeBotWinReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToePlayerWinReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeDrawReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeBotWinReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeTimeoutReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToePlayerWinReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeTimeoutReply);
            this.pnlTicTacToe.Controls.Add(this.pnlTicTacToeMoveMode);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeAlreadStopReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeStoppedReply);
            this.pnlTicTacToe.Controls.Add(this.txbStopTicTacToeCmd);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeAlreadyStartReply);
            this.pnlTicTacToe.Controls.Add(this.txbTicTacToeStartedReply);
            this.pnlTicTacToe.Controls.Add(this.txbStartTicTacToeCmd);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeMoveMode);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeAlreadStopReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeStartedReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeStoppedReply);
            this.pnlTicTacToe.Controls.Add(this.lblTicTacToeAlreadyStartReply);
            this.pnlTicTacToe.Controls.Add(this.lblStopTicTacToeCmd);
            this.pnlTicTacToe.Controls.Add(this.lblStartTicTacToeCmd);
            this.pnlTicTacToe.Enabled = false;
            this.pnlTicTacToe.Location = new System.Drawing.Point(3, 35);
            this.pnlTicTacToe.Name = "pnlTicTacToe";
            this.pnlTicTacToe.Size = new System.Drawing.Size(646, 645);
            this.pnlTicTacToe.TabIndex = 1;
            // 
            // lblTicTacToeMoveFailReply
            // 
            this.lblTicTacToeMoveFailReply.AutoSize = true;
            this.lblTicTacToeMoveFailReply.Location = new System.Drawing.Point(10, 360);
            this.lblTicTacToeMoveFailReply.Name = "lblTicTacToeMoveFailReply";
            this.lblTicTacToeMoveFailReply.Size = new System.Drawing.Size(159, 17);
            this.lblTicTacToeMoveFailReply.TabIndex = 29;
            this.lblTicTacToeMoveFailReply.Text = "识别到格子已有棋子回复语: ";
            // 
            // txbTicTacToeMoveFailReply
            // 
            this.txbTicTacToeMoveFailReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeMoveFailReply.Location = new System.Drawing.Point(178, 357);
            this.txbTicTacToeMoveFailReply.Name = "txbTicTacToeMoveFailReply";
            this.txbTicTacToeMoveFailReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeMoveFailReply.TabIndex = 28;
            // 
            // lblChessboard
            // 
            this.lblChessboard.AutoSize = true;
            this.lblChessboard.Location = new System.Drawing.Point(10, 520);
            this.lblChessboard.Name = "lblChessboard";
            this.lblChessboard.Size = new System.Drawing.Size(107, 17);
            this.lblChessboard.TabIndex = 27;
            this.lblChessboard.Text = "棋盘编号命名示例:";
            // 
            // imgChessboard
            // 
            this.imgChessboard.BackgroundImage = global::GreenOnions.BotManagerWindow.Properties.Resources.Chessboard;
            this.imgChessboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgChessboard.Location = new System.Drawing.Point(220, 422);
            this.imgChessboard.Name = "imgChessboard";
            this.imgChessboard.Size = new System.Drawing.Size(220, 220);
            this.imgChessboard.TabIndex = 26;
            // 
            // lblTicTacToeIllegalMoveReply
            // 
            this.lblTicTacToeIllegalMoveReply.AutoSize = true;
            this.lblTicTacToeIllegalMoveReply.Location = new System.Drawing.Point(10, 331);
            this.lblTicTacToeIllegalMoveReply.Name = "lblTicTacToeIllegalMoveReply";
            this.lblTicTacToeIllegalMoveReply.Size = new System.Drawing.Size(159, 17);
            this.lblTicTacToeIllegalMoveReply.TabIndex = 25;
            this.lblTicTacToeIllegalMoveReply.Text = "识别到下子多于一格回复语: ";
            // 
            // txbTicTacToeIllegalMoveReply
            // 
            this.txbTicTacToeIllegalMoveReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeIllegalMoveReply.Location = new System.Drawing.Point(178, 328);
            this.txbTicTacToeIllegalMoveReply.Name = "txbTicTacToeIllegalMoveReply";
            this.txbTicTacToeIllegalMoveReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeIllegalMoveReply.TabIndex = 24;
            // 
            // lblTicTacToeNoMoveReply
            // 
            this.lblTicTacToeNoMoveReply.AutoSize = true;
            this.lblTicTacToeNoMoveReply.Location = new System.Drawing.Point(10, 302);
            this.lblTicTacToeNoMoveReply.Name = "lblTicTacToeNoMoveReply";
            this.lblTicTacToeNoMoveReply.Size = new System.Drawing.Size(135, 17);
            this.lblTicTacToeNoMoveReply.TabIndex = 23;
            this.lblTicTacToeNoMoveReply.Text = "没有识别到下子回复语: ";
            // 
            // txbTicTacToeNoMoveReply
            // 
            this.txbTicTacToeNoMoveReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeNoMoveReply.Location = new System.Drawing.Point(178, 299);
            this.txbTicTacToeNoMoveReply.Name = "txbTicTacToeNoMoveReply";
            this.txbTicTacToeNoMoveReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeNoMoveReply.TabIndex = 22;
            // 
            // lblTicTacToeDrawReply
            // 
            this.lblTicTacToeDrawReply.AutoSize = true;
            this.lblTicTacToeDrawReply.Location = new System.Drawing.Point(10, 273);
            this.lblTicTacToeDrawReply.Name = "lblTicTacToeDrawReply";
            this.lblTicTacToeDrawReply.Size = new System.Drawing.Size(75, 17);
            this.lblTicTacToeDrawReply.TabIndex = 21;
            this.lblTicTacToeDrawReply.Text = "平局回复语: ";
            // 
            // lblTicTacToeBotWinReply
            // 
            this.lblTicTacToeBotWinReply.AutoSize = true;
            this.lblTicTacToeBotWinReply.Location = new System.Drawing.Point(10, 244);
            this.lblTicTacToeBotWinReply.Name = "lblTicTacToeBotWinReply";
            this.lblTicTacToeBotWinReply.Size = new System.Drawing.Size(111, 17);
            this.lblTicTacToeBotWinReply.TabIndex = 20;
            this.lblTicTacToeBotWinReply.Text = "机器人获胜回复语: ";
            // 
            // lblTicTacToePlayerWinReply
            // 
            this.lblTicTacToePlayerWinReply.AutoSize = true;
            this.lblTicTacToePlayerWinReply.Location = new System.Drawing.Point(10, 215);
            this.lblTicTacToePlayerWinReply.Name = "lblTicTacToePlayerWinReply";
            this.lblTicTacToePlayerWinReply.Size = new System.Drawing.Size(99, 17);
            this.lblTicTacToePlayerWinReply.TabIndex = 19;
            this.lblTicTacToePlayerWinReply.Text = "玩家获胜回复语: ";
            // 
            // txbTicTacToeDrawReply
            // 
            this.txbTicTacToeDrawReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeDrawReply.Location = new System.Drawing.Point(178, 270);
            this.txbTicTacToeDrawReply.Name = "txbTicTacToeDrawReply";
            this.txbTicTacToeDrawReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeDrawReply.TabIndex = 18;
            // 
            // txbTicTacToeBotWinReply
            // 
            this.txbTicTacToeBotWinReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeBotWinReply.Location = new System.Drawing.Point(178, 241);
            this.txbTicTacToeBotWinReply.Name = "txbTicTacToeBotWinReply";
            this.txbTicTacToeBotWinReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeBotWinReply.TabIndex = 17;
            // 
            // lblTicTacToeTimeoutReply
            // 
            this.lblTicTacToeTimeoutReply.AutoSize = true;
            this.lblTicTacToeTimeoutReply.Location = new System.Drawing.Point(10, 186);
            this.lblTicTacToeTimeoutReply.Name = "lblTicTacToeTimeoutReply";
            this.lblTicTacToeTimeoutReply.Size = new System.Drawing.Size(99, 17);
            this.lblTicTacToeTimeoutReply.TabIndex = 16;
            this.lblTicTacToeTimeoutReply.Text = "对局超时回复语: ";
            // 
            // txbTicTacToePlayerWinReply
            // 
            this.txbTicTacToePlayerWinReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToePlayerWinReply.Location = new System.Drawing.Point(178, 212);
            this.txbTicTacToePlayerWinReply.Name = "txbTicTacToePlayerWinReply";
            this.txbTicTacToePlayerWinReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToePlayerWinReply.TabIndex = 15;
            // 
            // txbTicTacToeTimeoutReply
            // 
            this.txbTicTacToeTimeoutReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeTimeoutReply.Location = new System.Drawing.Point(178, 183);
            this.txbTicTacToeTimeoutReply.Name = "txbTicTacToeTimeoutReply";
            this.txbTicTacToeTimeoutReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeTimeoutReply.TabIndex = 14;
            // 
            // pnlTicTacToeMoveMode
            // 
            this.pnlTicTacToeMoveMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTicTacToeMoveMode.Controls.Add(this.chkTicTacToeMoveModeOpenCV);
            this.pnlTicTacToeMoveMode.Controls.Add(this.chkTicTacToeMoveModeNomenclature);
            this.pnlTicTacToeMoveMode.Location = new System.Drawing.Point(178, 386);
            this.pnlTicTacToeMoveMode.Name = "pnlTicTacToeMoveMode";
            this.pnlTicTacToeMoveMode.Size = new System.Drawing.Size(451, 30);
            this.pnlTicTacToeMoveMode.TabIndex = 13;
            // 
            // chkTicTacToeMoveModeOpenCV
            // 
            this.chkTicTacToeMoveModeOpenCV.AutoSize = true;
            this.chkTicTacToeMoveModeOpenCV.Location = new System.Drawing.Point(3, 6);
            this.chkTicTacToeMoveModeOpenCV.Name = "chkTicTacToeMoveModeOpenCV";
            this.chkTicTacToeMoveModeOpenCV.Size = new System.Drawing.Size(75, 21);
            this.chkTicTacToeMoveModeOpenCV.TabIndex = 5;
            this.chkTicTacToeMoveModeOpenCV.Tag = "2";
            this.chkTicTacToeMoveModeOpenCV.Text = "图像识别";
            this.chkTicTacToeMoveModeOpenCV.UseVisualStyleBackColor = true;
            // 
            // chkTicTacToeMoveModeNomenclature
            // 
            this.chkTicTacToeMoveModeNomenclature.AutoSize = true;
            this.chkTicTacToeMoveModeNomenclature.Location = new System.Drawing.Point(84, 6);
            this.chkTicTacToeMoveModeNomenclature.Name = "chkTicTacToeMoveModeNomenclature";
            this.chkTicTacToeMoveModeNomenclature.Size = new System.Drawing.Size(75, 21);
            this.chkTicTacToeMoveModeNomenclature.TabIndex = 5;
            this.chkTicTacToeMoveModeNomenclature.Tag = "4";
            this.chkTicTacToeMoveModeNomenclature.Text = "回复格号";
            this.chkTicTacToeMoveModeNomenclature.UseVisualStyleBackColor = true;
            // 
            // txbTicTacToeAlreadStopReply
            // 
            this.txbTicTacToeAlreadStopReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeAlreadStopReply.Location = new System.Drawing.Point(178, 154);
            this.txbTicTacToeAlreadStopReply.Name = "txbTicTacToeAlreadStopReply";
            this.txbTicTacToeAlreadStopReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeAlreadStopReply.TabIndex = 12;
            // 
            // txbTicTacToeStoppedReply
            // 
            this.txbTicTacToeStoppedReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeStoppedReply.Location = new System.Drawing.Point(178, 125);
            this.txbTicTacToeStoppedReply.Name = "txbTicTacToeStoppedReply";
            this.txbTicTacToeStoppedReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeStoppedReply.TabIndex = 11;
            // 
            // txbStopTicTacToeCmd
            // 
            this.txbStopTicTacToeCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTicTacToeCmd.Location = new System.Drawing.Point(178, 96);
            this.txbStopTicTacToeCmd.Name = "txbStopTicTacToeCmd";
            this.txbStopTicTacToeCmd.Size = new System.Drawing.Size(451, 23);
            this.txbStopTicTacToeCmd.TabIndex = 10;
            // 
            // txbTicTacToeAlreadyStartReply
            // 
            this.txbTicTacToeAlreadyStartReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeAlreadyStartReply.Location = new System.Drawing.Point(178, 67);
            this.txbTicTacToeAlreadyStartReply.Name = "txbTicTacToeAlreadyStartReply";
            this.txbTicTacToeAlreadyStartReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeAlreadyStartReply.TabIndex = 9;
            // 
            // txbTicTacToeStartedReply
            // 
            this.txbTicTacToeStartedReply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicTacToeStartedReply.Location = new System.Drawing.Point(178, 38);
            this.txbTicTacToeStartedReply.Name = "txbTicTacToeStartedReply";
            this.txbTicTacToeStartedReply.Size = new System.Drawing.Size(451, 23);
            this.txbTicTacToeStartedReply.TabIndex = 8;
            // 
            // txbStartTicTacToeCmd
            // 
            this.txbStartTicTacToeCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTicTacToeCmd.Location = new System.Drawing.Point(178, 9);
            this.txbStartTicTacToeCmd.Name = "txbStartTicTacToeCmd";
            this.txbStartTicTacToeCmd.Size = new System.Drawing.Size(451, 23);
            this.txbStartTicTacToeCmd.TabIndex = 7;
            // 
            // lblTicTacToeMoveMode
            // 
            this.lblTicTacToeMoveMode.AutoSize = true;
            this.lblTicTacToeMoveMode.Location = new System.Drawing.Point(10, 393);
            this.lblTicTacToeMoveMode.Name = "lblTicTacToeMoveMode";
            this.lblTicTacToeMoveMode.Size = new System.Drawing.Size(107, 17);
            this.lblTicTacToeMoveMode.TabIndex = 6;
            this.lblTicTacToeMoveMode.Text = "允许玩家下子方式:";
            // 
            // lblTicTacToeAlreadStopReply
            // 
            this.lblTicTacToeAlreadStopReply.AutoSize = true;
            this.lblTicTacToeAlreadStopReply.Location = new System.Drawing.Point(10, 157);
            this.lblTicTacToeAlreadStopReply.Name = "lblTicTacToeAlreadStopReply";
            this.lblTicTacToeAlreadStopReply.Size = new System.Drawing.Size(111, 17);
            this.lblTicTacToeAlreadStopReply.TabIndex = 4;
            this.lblTicTacToeAlreadStopReply.Text = "未在对局中回复语: ";
            // 
            // lblTicTacToeStartedReply
            // 
            this.lblTicTacToeStartedReply.AutoSize = true;
            this.lblTicTacToeStartedReply.Location = new System.Drawing.Point(10, 41);
            this.lblTicTacToeStartedReply.Name = "lblTicTacToeStartedReply";
            this.lblTicTacToeStartedReply.Size = new System.Drawing.Size(123, 17);
            this.lblTicTacToeStartedReply.TabIndex = 3;
            this.lblTicTacToeStartedReply.Text = "开启对局成功回复语: ";
            // 
            // lblTicTacToeStoppedReply
            // 
            this.lblTicTacToeStoppedReply.AutoSize = true;
            this.lblTicTacToeStoppedReply.Location = new System.Drawing.Point(10, 128);
            this.lblTicTacToeStoppedReply.Name = "lblTicTacToeStoppedReply";
            this.lblTicTacToeStoppedReply.Size = new System.Drawing.Size(123, 17);
            this.lblTicTacToeStoppedReply.TabIndex = 2;
            this.lblTicTacToeStoppedReply.Text = "中止对局成功回复语: ";
            // 
            // lblTicTacToeAlreadyStartReply
            // 
            this.lblTicTacToeAlreadyStartReply.AutoSize = true;
            this.lblTicTacToeAlreadyStartReply.Location = new System.Drawing.Point(10, 70);
            this.lblTicTacToeAlreadyStartReply.Name = "lblTicTacToeAlreadyStartReply";
            this.lblTicTacToeAlreadyStartReply.Size = new System.Drawing.Size(111, 17);
            this.lblTicTacToeAlreadyStartReply.TabIndex = 1;
            this.lblTicTacToeAlreadyStartReply.Text = "已在对局中回复语: ";
            // 
            // lblStopTicTacToeCmd
            // 
            this.lblStopTicTacToeCmd.AutoSize = true;
            this.lblStopTicTacToeCmd.Location = new System.Drawing.Point(10, 99);
            this.lblStopTicTacToeCmd.Name = "lblStopTicTacToeCmd";
            this.lblStopTicTacToeCmd.Size = new System.Drawing.Size(87, 17);
            this.lblStopTicTacToeCmd.TabIndex = 0;
            this.lblStopTicTacToeCmd.Text = "中止对局命令: ";
            // 
            // lblStartTicTacToeCmd
            // 
            this.lblStartTicTacToeCmd.AutoSize = true;
            this.lblStartTicTacToeCmd.Location = new System.Drawing.Point(10, 12);
            this.lblStartTicTacToeCmd.Name = "lblStartTicTacToeCmd";
            this.lblStartTicTacToeCmd.Size = new System.Drawing.Size(87, 17);
            this.lblStartTicTacToeCmd.TabIndex = 0;
            this.lblStartTicTacToeCmd.Text = "开启对局命令: ";
            // 
            // chkTicTacToeEnabled
            // 
            this.chkTicTacToeEnabled.AutoSize = true;
            this.chkTicTacToeEnabled.Location = new System.Drawing.Point(9, 8);
            this.chkTicTacToeEnabled.Name = "chkTicTacToeEnabled";
            this.chkTicTacToeEnabled.Size = new System.Drawing.Size(111, 21);
            this.chkTicTacToeEnabled.TabIndex = 0;
            this.chkTicTacToeEnabled.Text = "启用井字棋功能";
            this.chkTicTacToeEnabled.UseVisualStyleBackColor = true;
            this.chkTicTacToeEnabled.CheckedChanged += new System.EventHandler(this.chkTicTacToeEnabled_CheckedChanged);
            // 
            // pageAbout
            // 
            this.pageAbout.Controls.Add(this.txbContributorGroup);
            this.pageAbout.Controls.Add(this.lblContributorGroup);
            this.pageAbout.Controls.Add(this.txbContributorName);
            this.pageAbout.Controls.Add(this.txbContributorQQ);
            this.pageAbout.Controls.Add(this.lnkProjectURL);
            this.pageAbout.Controls.Add(this.lnkContributorGithub);
            this.pageAbout.Controls.Add(this.lblProjectURL);
            this.pageAbout.Controls.Add(this.lblContributorGithub);
            this.pageAbout.Controls.Add(this.lblContributorQQ);
            this.pageAbout.Controls.Add(this.lblContributorName);
            this.pageAbout.Location = new System.Drawing.Point(4, 26);
            this.pageAbout.Margin = new System.Windows.Forms.Padding(4);
            this.pageAbout.Name = "pageAbout";
            this.pageAbout.Size = new System.Drawing.Size(652, 687);
            this.pageAbout.TabIndex = 2;
            this.pageAbout.Text = "关于";
            this.pageAbout.UseVisualStyleBackColor = true;
            // 
            // txbContributorGroup
            // 
            this.txbContributorGroup.BackColor = System.Drawing.Color.White;
            this.txbContributorGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbContributorGroup.Location = new System.Drawing.Point(116, 111);
            this.txbContributorGroup.Name = "txbContributorGroup";
            this.txbContributorGroup.ReadOnly = true;
            this.txbContributorGroup.Size = new System.Drawing.Size(100, 16);
            this.txbContributorGroup.TabIndex = 4;
            this.txbContributorGroup.Text = "550398174";
            // 
            // lblContributorGroup
            // 
            this.lblContributorGroup.AutoSize = true;
            this.lblContributorGroup.Location = new System.Drawing.Point(36, 111);
            this.lblContributorGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContributorGroup.Name = "lblContributorGroup";
            this.lblContributorGroup.Size = new System.Drawing.Size(43, 17);
            this.lblContributorGroup.TabIndex = 3;
            this.lblContributorGroup.Text = "QQ群:";
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
            this.txbContributorQQ.Location = new System.Drawing.Point(116, 76);
            this.txbContributorQQ.Name = "txbContributorQQ";
            this.txbContributorQQ.ReadOnly = true;
            this.txbContributorQQ.Size = new System.Drawing.Size(100, 16);
            this.txbContributorQQ.TabIndex = 2;
            this.txbContributorQQ.Text = "774345562";
            // 
            // lnkProjectURL
            // 
            this.lnkProjectURL.AutoSize = true;
            this.lnkProjectURL.Location = new System.Drawing.Point(116, 182);
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
            this.lnkContributorGithub.Location = new System.Drawing.Point(116, 146);
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
            this.lblProjectURL.Location = new System.Drawing.Point(36, 182);
            this.lblProjectURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectURL.Name = "lblProjectURL";
            this.lblProjectURL.Size = new System.Drawing.Size(59, 17);
            this.lblProjectURL.TabIndex = 0;
            this.lblProjectURL.Text = "项目地址:";
            // 
            // lblContributorGithub
            // 
            this.lblContributorGithub.AutoSize = true;
            this.lblContributorGithub.Location = new System.Drawing.Point(36, 146);
            this.lblContributorGithub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContributorGithub.Name = "lblContributorGithub";
            this.lblContributorGithub.Size = new System.Drawing.Size(73, 17);
            this.lblContributorGithub.TabIndex = 0;
            this.lblContributorGithub.Text = "Github主页:";
            // 
            // lblContributorQQ
            // 
            this.lblContributorQQ.AutoSize = true;
            this.lblContributorQQ.Location = new System.Drawing.Point(36, 76);
            this.lblContributorQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContributorQQ.Name = "lblContributorQQ";
            this.lblContributorQQ.Size = new System.Drawing.Size(31, 17);
            this.lblContributorQQ.TabIndex = 0;
            this.lblContributorQQ.Text = "QQ:";
            // 
            // lblContributorName
            // 
            this.lblContributorName.AutoSize = true;
            this.lblContributorName.Location = new System.Drawing.Point(36, 41);
            this.lblContributorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContributorName.Name = "lblContributorName";
            this.lblContributorName.Size = new System.Drawing.Size(35, 17);
            this.lblContributorName.TabIndex = 0;
            this.lblContributorName.Text = "作者:";
            // 
            // cboReplaceImgRoute
            // 
            this.cboReplaceImgRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReplaceImgRoute.FormattingEnabled = true;
            this.cboReplaceImgRoute.Items.AddRange(new object[] {
            "不替换",
            "替换为 c2cpicdw.qpic.cn/offpic_new",
            "替换为 gchat.qpic.cn/gchatpic_new"});
            this.cboReplaceImgRoute.Location = new System.Drawing.Point(127, 481);
            this.cboReplaceImgRoute.Name = "cboReplaceImgRoute";
            this.cboReplaceImgRoute.Size = new System.Drawing.Size(200, 25);
            this.cboReplaceImgRoute.TabIndex = 44;
            // 
            // lblReplaceImgRoute
            // 
            this.lblReplaceImgRoute.AutoSize = true;
            this.lblReplaceImgRoute.Location = new System.Drawing.Point(4, 484);
            this.lblReplaceImgRoute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplaceImgRoute.Name = "lblReplaceImgRoute";
            this.lblReplaceImgRoute.Size = new System.Drawing.Size(116, 17);
            this.lblReplaceImgRoute.TabIndex = 43;
            this.lblReplaceImgRoute.Text = "图片外链路由替换：";
            // 
            // txbSearchAnimeModeOnCmd
            // 
            this.txbSearchAnimeModeOnCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchAnimeModeOnCmd.Location = new System.Drawing.Point(196, 498);
            this.txbSearchAnimeModeOnCmd.MinimumSize = new System.Drawing.Size(357, 0);
            this.txbSearchAnimeModeOnCmd.Name = "txbSearchAnimeModeOnCmd";
            this.txbSearchAnimeModeOnCmd.Size = new System.Drawing.Size(357, 23);
            this.txbSearchAnimeModeOnCmd.TabIndex = 16;
            // 
            // lblSearchAnimeModeOnCmd
            // 
            this.lblSearchAnimeModeOnCmd.AutoSize = true;
            this.lblSearchAnimeModeOnCmd.Location = new System.Drawing.Point(24, 501);
            this.lblSearchAnimeModeOnCmd.Name = "lblSearchAnimeModeOnCmd";
            this.lblSearchAnimeModeOnCmd.Size = new System.Drawing.Size(131, 17);
            this.lblSearchAnimeModeOnCmd.TabIndex = 17;
            this.lblSearchAnimeModeOnCmd.Text = "开启连续搜番模式命令:";
            // 
            // FrmAppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 761);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.btnOk);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用设置";
            this.tabSettings.ResumeLayout(false);
            this.pageBot.ResumeLayout(false);
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            this.pnlAutoConnect.ResumeLayout(false);
            this.pnlAutoConnect.PerformLayout();
            this.pnlDebugMode.ResumeLayout(false);
            this.pnlDebugMode.PerformLayout();
            this.pnlCheckPorn.ResumeLayout(false);
            this.pnlCheckPorn.PerformLayout();
            this.pageSearchPicture.ResumeLayout(false);
            this.pageSearchPicture.PerformLayout();
            this.pnlSearchPicture.ResumeLayout(false);
            this.pnlSearchPicture.PerformLayout();
            this.pnlSearchSauceNAO.ResumeLayout(false);
            this.pnlSearchSauceNAO.PerformLayout();
            this.pnlPictureSearcherCheckPorn.ResumeLayout(false);
            this.pnlPictureSearcherCheckPorn.PerformLayout();
            this.pageOriginalPicture.ResumeLayout(false);
            this.pageOriginalPicture.PerformLayout();
            this.pnlOriginalPicture.ResumeLayout(false);
            this.pnlOriginalPicture.PerformLayout();
            this.pnlOriginalPictureCheckPorn.ResumeLayout(false);
            this.pnlOriginalPictureCheckPorn.PerformLayout();
            this.pnlOriginalPictureCheckPornMessage.ResumeLayout(false);
            this.pnlOriginalPictureCheckPornMessage.PerformLayout();
            this.pnlOriginalPictureCheckPornEvent.ResumeLayout(false);
            this.pnlOriginalPictureCheckPornEvent.PerformLayout();
            this.pageHPicture.ResumeLayout(false);
            this.pageHPicture.PerformLayout();
            this.pnlHPictureEnabeled.ResumeLayout(false);
            this.pnlHPictureEnabeled.PerformLayout();
            this.pnlHPictureCheckBoxes.ResumeLayout(false);
            this.pnlHPictureCheckBoxes.PerformLayout();
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
            this.pageTicTacToe.ResumeLayout(false);
            this.pageTicTacToe.PerformLayout();
            this.pnlTicTacToe.ResumeLayout(false);
            this.pnlTicTacToe.PerformLayout();
            this.pnlTicTacToeMoveMode.ResumeLayout(false);
            this.pnlTicTacToeMoveMode.PerformLayout();
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
        private System.Windows.Forms.Label lblLoliconHPictureCmd;
        private System.Windows.Forms.TextBox txbHPictureCmd;
        private System.Windows.Forms.LinkLabel lnkResetHPicture;
        private System.Windows.Forms.Button btnAddUserHPictureCmd;
        private System.Windows.Forms.TextBox txbUserHPictureCmd;
        private System.Windows.Forms.Label lblUserHPictureCmd;
        private System.Windows.Forms.Label lblUserCmd;
        private System.Windows.Forms.CheckBox chkHPictureEnabled;
        private System.Windows.Forms.Panel pnlHPictureEnabeled;
        private System.Windows.Forms.Label lblRevoke;
        private System.Windows.Forms.Label lblWhiteGroup;
        private System.Windows.Forms.TextBox txbAddToWhiteGroup;
        private System.Windows.Forms.TextBox txbHPictureRevoke;
        private System.Windows.Forms.CheckBox chkHPictureWhiteOnly;
        private System.Windows.Forms.CheckBox chkHPictureSize1200;
        private System.Windows.Forms.CheckBox chkHPictureAllowPM;
        private System.Windows.Forms.ListView lstHPictureWhiteGroup;
        private System.Windows.Forms.Label lblAddToWhiteGroupInformation;
        private System.Windows.Forms.Button btnAddToWhiteGroup;
        private System.Windows.Forms.CheckBox chkHPictureR18WhiteOnly;
        private System.Windows.Forms.Label lblWhiteRevoke;
        private System.Windows.Forms.Label lblCD;
        private System.Windows.Forms.TextBox txbHPictureWhiteRevoke;
        private System.Windows.Forms.TextBox txbHPictureCD;
        private System.Windows.Forms.TextBox txbHPictureWhiteCD;
        private System.Windows.Forms.Label lblWhiteCD;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.TextBox txbHPictureLimit;
        private System.Windows.Forms.ListView lstHPictureUserCmd;
        private System.Windows.Forms.Label lblErrorReply;
        private System.Windows.Forms.Label lblOutOfLimitReply;
        private System.Windows.Forms.Label lblCDUnreadyReply;
        private System.Windows.Forms.TextBox txbHPictureErrorReplyReply;
        private System.Windows.Forms.TextBox txbHPictureOutOfLimitReply;
        private System.Windows.Forms.TextBox txbHPictureCDUnreadyReply;
        private System.Windows.Forms.Label lblUserCmdInformation;
        private System.Windows.Forms.CheckBox chkHPictureAllowR18;
        private System.Windows.Forms.TextBox txbHPicturePMCD;
        private System.Windows.Forms.TextBox txbHPicturePMRevoke;
        private System.Windows.Forms.Label lblPMRevoke;
        private System.Windows.Forms.Label lblPMCD;
        private System.Windows.Forms.CheckBox chkHPictureAdminNoLimit;
        private System.Windows.Forms.CheckBox chkHPicturePMNoLimit;
        private System.Windows.Forms.Button btnRemoveAdmin;
        private System.Windows.Forms.Button btnRemoveWhiteGroup;
        private System.Windows.Forms.Button btnRemoveUserHPictureCmd;
        private System.Windows.Forms.Label lblNoResult;
        private System.Windows.Forms.TextBox txbHPictureNoResultReply;
        private System.Windows.Forms.RadioButton rodHPictureLimitCount;
        private System.Windows.Forms.RadioButton rdoHPictureLimitFrequency;
        private System.Windows.Forms.Label lblLimitType;
        private System.Windows.Forms.CheckBox chkHPictureWhiteNoLimit;
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
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txbHPictureApiKey;
        private System.Windows.Forms.Label lblDownloadFail;
        private System.Windows.Forms.TextBox txbDownloadFailReply;
        private System.Windows.Forms.TabPage pageSearchPicture;
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
        private System.Windows.Forms.Label lblSearchLowSimilarityReply;
        private System.Windows.Forms.Label lblSearchSauceNAOLowSimilarity;
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
        private System.Windows.Forms.Label lblSauceNAOApiKey;
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
        private System.Windows.Forms.LinkLabel lnkProjectURL;
        private System.Windows.Forms.Label lblProjectURL;
        private System.Windows.Forms.CheckBox chkHPictureEnabledLoliconSource;
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
        private System.Windows.Forms.Label lblTraceMoeSendThreshold;
        private System.Windows.Forms.TextBox txbTraceMoeSendThreshold;
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
        private System.Windows.Forms.Label lblBeautyPictureSource;
        private System.Windows.Forms.Label lblHPictureSource;
        private System.Windows.Forms.CheckBox chkEnabledGreenOnionsBeautyPicture;
        private System.Windows.Forms.CheckBox chkHPictureEnabledGreenOnionsSource;
        private System.Windows.Forms.CheckBox chkEnabledELFBeautyPicture;
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
        private System.Windows.Forms.TabPage pageOriginalPicture;
        private System.Windows.Forms.CheckBox chkOriginalPictureEnabled;
        private System.Windows.Forms.CheckBox chkOriginalPictureCheckPornEnabled;
        private System.Windows.Forms.Panel pnlOriginalPictureCheckPorn;
        private System.Windows.Forms.Label lblOriginalPictureCheckPornEvent;
        private System.Windows.Forms.Panel pnlOriginalPictureCheckPornEvent;
        private System.Windows.Forms.RadioButton rdoOriginalPictureCheckPornReply;
        private System.Windows.Forms.RadioButton rdoOriginalPictureCheckPornDoNothing;
        private System.Windows.Forms.RadioButton rdoOriginalPictureCheckPornSendByForward;
        private System.Windows.Forms.Label lblOriginalPictureCheckPornIllegalReply;
        private System.Windows.Forms.TextBox txbOriginalPictureCheckPornIllegalReply;
        private System.Windows.Forms.TextBox txbOriginalPictureCheckPornErrorReply;
        private System.Windows.Forms.Label lblOriginalPictureCheckPornErrorReply;
        private System.Windows.Forms.Panel pnlOriginalPictureCheckPornMessage;
        private System.Windows.Forms.Panel pnlOriginalPicture;
        private System.Windows.Forms.CheckBox chkReplaceMeToYou;
        private System.Windows.Forms.CheckBox chkHttpRequestByWebBrowser;
        private System.Windows.Forms.CheckBox chkASCII2DRequestByWebBrowser;
        private System.Windows.Forms.Label lblSearchCheckPornOutOfLimitReply;
        private System.Windows.Forms.TextBox txbSearchCheckPornOutOfLimitReply;
        private System.Windows.Forms.Label lblCheckPornLimitCountInfo;
        private System.Windows.Forms.Label lblCheckPornLimitCount;
        private System.Windows.Forms.TextBox txbCheckPornLimitCount;
        private System.Windows.Forms.TextBox txbTranslateFromToCMD;
        private System.Windows.Forms.Label lblTranslateFromTo;
        private System.Windows.Forms.Label lblSauceNAOApiKeyInfo;
        private System.Windows.Forms.Label lblTraceMoeSendThresholdInfo;
        private System.Windows.Forms.TabPage pageTicTacToe;
        private System.Windows.Forms.Panel pnlTicTacToe;
        private System.Windows.Forms.CheckBox chkTicTacToeEnabled;
        private System.Windows.Forms.Label lblStartTicTacToeCmd;
        private System.Windows.Forms.TextBox txbTicTacToeAlreadStopReply;
        private System.Windows.Forms.TextBox txbTicTacToeStoppedReply;
        private System.Windows.Forms.TextBox txbStopTicTacToeCmd;
        private System.Windows.Forms.TextBox txbTicTacToeAlreadyStartReply;
        private System.Windows.Forms.TextBox txbTicTacToeStartedReply;
        private System.Windows.Forms.TextBox txbStartTicTacToeCmd;
        private System.Windows.Forms.Label lblTicTacToeMoveMode;
        private System.Windows.Forms.CheckBox chkTicTacToeMoveModeNomenclature;
        private System.Windows.Forms.CheckBox chkTicTacToeMoveModeOpenCV;
        private System.Windows.Forms.Label lblTicTacToeAlreadStopReply;
        private System.Windows.Forms.Label lblTicTacToeStartedReply;
        private System.Windows.Forms.Label lblTicTacToeStoppedReply;
        private System.Windows.Forms.Label lblTicTacToeAlreadyStartReply;
        private System.Windows.Forms.Label lblStopTicTacToeCmd;
        private System.Windows.Forms.Panel pnlTicTacToeMoveMode;
        private System.Windows.Forms.Label lblTicTacToeDrawReply;
        private System.Windows.Forms.Label lblTicTacToeBotWinReply;
        private System.Windows.Forms.Label lblTicTacToePlayerWinReply;
        private System.Windows.Forms.TextBox txbTicTacToeDrawReply;
        private System.Windows.Forms.TextBox txbTicTacToeBotWinReply;
        private System.Windows.Forms.Label lblTicTacToeTimeoutReply;
        private System.Windows.Forms.TextBox txbTicTacToePlayerWinReply;
        private System.Windows.Forms.TextBox txbTicTacToeTimeoutReply;
        private System.Windows.Forms.Label lblTicTacToeIllegalMoveReply;
        private System.Windows.Forms.TextBox txbTicTacToeIllegalMoveReply;
        private System.Windows.Forms.Label lblTicTacToeNoMoveReply;
        private System.Windows.Forms.TextBox txbTicTacToeNoMoveReply;
        private System.Windows.Forms.Panel imgChessboard;
        private System.Windows.Forms.Label lblChessboard;
        private System.Windows.Forms.Label lblTicTacToeMoveFailReply;
        private System.Windows.Forms.TextBox txbTicTacToeMoveFailReply;
        private System.Windows.Forms.Label lblLogLevel;
        private System.Windows.Forms.ComboBox cboLogLevel;
        private System.Windows.Forms.CheckBox chkSauceNaoRequestByWebBrowser;
        private System.Windows.Forms.TextBox txbContributorGroup;
        private System.Windows.Forms.Label lblContributorGroup;
        private System.Windows.Forms.CheckBox chkSearchSendByForward;
        private System.Windows.Forms.Label lblSearchDownloadThuImageFailReply;
        private System.Windows.Forms.TextBox txbSearchDownloadThuImageFailReply;
        private System.Windows.Forms.Label lblSearchSauceNAOHighSimilarity;
        private System.Windows.Forms.TextBox txbSearchSauceNAOHighSimilarity;
        private System.Windows.Forms.Label lblSearchSauceNAOHighSimilarityInfo;
        private System.Windows.Forms.Label lblSearchSauceNAOLowSimilarityInfo;
        private System.Windows.Forms.CheckBox chkSearchCheckPornEnabled;
        private System.Windows.Forms.CheckBox chkSearchTraceMoeEnabled;
        private System.Windows.Forms.TextBox txbSearchSauceNAOLowSimilarity;
        private System.Windows.Forms.TextBox txbSearchSauceNAOApiKey;
        private System.Windows.Forms.Label lblOriginalPictureCommand;
        private System.Windows.Forms.TextBox txbOriginalPictureCommand;
        private System.Windows.Forms.CheckBox chkSearchSauceNAOSendPixivOriginalPicture;
        private System.Windows.Forms.Panel pnlSearchSauceNAO;
        private System.Windows.Forms.Panel pnlHPictureCheckBoxes;
        private System.Windows.Forms.CheckBox chkHPictureSendTags;
        private System.Windows.Forms.CheckBox chkHPictureSendUrl;
        private System.Windows.Forms.CheckBox chkHPictureSendByForward;
        private System.Windows.Forms.CheckBox chkPmAutoSearch;
        private System.Windows.Forms.Label lblSearchingReply;
        private System.Windows.Forms.TextBox txbSearchingReply;
        private System.Windows.Forms.CheckBox chkSearchSauceNAOSortByDesc;
        private System.Windows.Forms.ComboBox cboSearchShowAscii2dCount;
        private System.Windows.Forms.Label lblSearchShowAscii2dCount;
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
        private System.Windows.Forms.Label lblSearchAnimeModeOnCmd;
        private System.Windows.Forms.TextBox txbSearchAnimeModeOnCmd;
    }
}