namespace GreenOnions.BotManagerWindows.Controls
{
    partial class CtrlBot
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components is not null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
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
            this.chkDownloadImage4Caching = new System.Windows.Forms.CheckBox();
            this.chkSendImageByFile = new System.Windows.Forms.CheckBox();
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
            this.txbAddAdmin = new System.Windows.Forms.TextBox();
            this.lblBotName = new System.Windows.Forms.Label();
            this.btnRemoveBanUser = new System.Windows.Forms.Button();
            this.btnRemoveBanGroup = new System.Windows.Forms.Button();
            this.txbBotName = new System.Windows.Forms.TextBox();
            this.btnRemoveAdmin = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
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
            this.chkSplitTextAndImageMessage = new System.Windows.Forms.CheckBox();
            this.chkLeaveGroupAfterBeMushin = new System.Windows.Forms.CheckBox();
            this.pnlWorkingTime.SuspendLayout();
            this.pnlAutoConnect.SuspendLayout();
            this.pnlDebugMode.SuspendLayout();
            this.pnlCheckPorn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWorkingTime
            // 
            this.lblWorkingTime.AutoSize = true;
            this.lblWorkingTime.Location = new System.Drawing.Point(133, 929);
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Size = new System.Drawing.Size(431, 17);
            this.lblWorkingTime.TabIndex = 91;
            this.lblWorkingTime.Text = "(启用用, 超出指定时段后会自动断开与平台的连接并在次日进入时段后重新连接)";
            // 
            // chkWorkingTimeEnabled
            // 
            this.chkWorkingTimeEnabled.AutoSize = true;
            this.chkWorkingTimeEnabled.Location = new System.Drawing.Point(4, 927);
            this.chkWorkingTimeEnabled.Name = "chkWorkingTimeEnabled";
            this.chkWorkingTimeEnabled.Size = new System.Drawing.Size(123, 21);
            this.chkWorkingTimeEnabled.TabIndex = 90;
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
            this.pnlWorkingTime.Location = new System.Drawing.Point(1, 954);
            this.pnlWorkingTime.Name = "pnlWorkingTime";
            this.pnlWorkingTime.Size = new System.Drawing.Size(600, 64);
            this.pnlWorkingTime.TabIndex = 89;
            // 
            // lblWorkingTimeToMinute
            // 
            this.lblWorkingTimeToMinute.AutoSize = true;
            this.lblWorkingTimeToMinute.Location = new System.Drawing.Point(396, 38);
            this.lblWorkingTimeToMinute.Name = "lblWorkingTimeToMinute";
            this.lblWorkingTimeToMinute.Size = new System.Drawing.Size(20, 17);
            this.lblWorkingTimeToMinute.TabIndex = 56;
            this.lblWorkingTimeToMinute.Text = "分";
            // 
            // lblWorkingTimeFromMinute
            // 
            this.lblWorkingTimeFromMinute.AutoSize = true;
            this.lblWorkingTimeFromMinute.Location = new System.Drawing.Point(396, 6);
            this.lblWorkingTimeFromMinute.Name = "lblWorkingTimeFromMinute";
            this.lblWorkingTimeFromMinute.Size = new System.Drawing.Size(20, 17);
            this.lblWorkingTimeFromMinute.TabIndex = 55;
            this.lblWorkingTimeFromMinute.Text = "分";
            // 
            // lblWorkingTimeToHour
            // 
            this.lblWorkingTimeToHour.AutoSize = true;
            this.lblWorkingTimeToHour.Location = new System.Drawing.Point(244, 38);
            this.lblWorkingTimeToHour.Name = "lblWorkingTimeToHour";
            this.lblWorkingTimeToHour.Size = new System.Drawing.Size(20, 17);
            this.lblWorkingTimeToHour.TabIndex = 54;
            this.lblWorkingTimeToHour.Text = "时";
            // 
            // lblWorkingTimeFromHour
            // 
            this.lblWorkingTimeFromHour.AutoSize = true;
            this.lblWorkingTimeFromHour.Location = new System.Drawing.Point(244, 6);
            this.lblWorkingTimeFromHour.Name = "lblWorkingTimeFromHour";
            this.lblWorkingTimeFromHour.Size = new System.Drawing.Size(20, 17);
            this.lblWorkingTimeFromHour.TabIndex = 53;
            this.lblWorkingTimeFromHour.Text = "时";
            // 
            // lblWorkingTimeTo
            // 
            this.lblWorkingTimeTo.AutoSize = true;
            this.lblWorkingTimeTo.Location = new System.Drawing.Point(3, 37);
            this.lblWorkingTimeTo.Name = "lblWorkingTimeTo";
            this.lblWorkingTimeTo.Size = new System.Drawing.Size(84, 17);
            this.lblWorkingTimeTo.TabIndex = 52;
            this.lblWorkingTimeTo.Text = "工作时间 到：";
            // 
            // lblWorkingTimeFrom
            // 
            this.lblWorkingTimeFrom.AutoSize = true;
            this.lblWorkingTimeFrom.Location = new System.Drawing.Point(3, 6);
            this.lblWorkingTimeFrom.Name = "lblWorkingTimeFrom";
            this.lblWorkingTimeFrom.Size = new System.Drawing.Size(84, 17);
            this.lblWorkingTimeFrom.TabIndex = 51;
            this.lblWorkingTimeFrom.Text = "工作时间 从：";
            // 
            // cboWorkingTimeFromHour
            // 
            this.cboWorkingTimeFromHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeFromHour.FormattingEnabled = true;
            this.cboWorkingTimeFromHour.Location = new System.Drawing.Point(116, 4);
            this.cboWorkingTimeFromHour.Name = "cboWorkingTimeFromHour";
            this.cboWorkingTimeFromHour.Size = new System.Drawing.Size(121, 25);
            this.cboWorkingTimeFromHour.TabIndex = 47;
            // 
            // cboWorkingTimeToHour
            // 
            this.cboWorkingTimeToHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeToHour.FormattingEnabled = true;
            this.cboWorkingTimeToHour.Location = new System.Drawing.Point(116, 35);
            this.cboWorkingTimeToHour.Name = "cboWorkingTimeToHour";
            this.cboWorkingTimeToHour.Size = new System.Drawing.Size(121, 25);
            this.cboWorkingTimeToHour.TabIndex = 49;
            // 
            // cboWorkingTimeToMinute
            // 
            this.cboWorkingTimeToMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeToMinute.FormattingEnabled = true;
            this.cboWorkingTimeToMinute.Location = new System.Drawing.Point(270, 35);
            this.cboWorkingTimeToMinute.Name = "cboWorkingTimeToMinute";
            this.cboWorkingTimeToMinute.Size = new System.Drawing.Size(121, 25);
            this.cboWorkingTimeToMinute.TabIndex = 50;
            // 
            // cboWorkingTimeFromMinute
            // 
            this.cboWorkingTimeFromMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkingTimeFromMinute.FormattingEnabled = true;
            this.cboWorkingTimeFromMinute.Location = new System.Drawing.Point(270, 4);
            this.cboWorkingTimeFromMinute.Name = "cboWorkingTimeFromMinute";
            this.cboWorkingTimeFromMinute.Size = new System.Drawing.Size(121, 25);
            this.cboWorkingTimeFromMinute.TabIndex = 48;
            // 
            // cboPixivProxy
            // 
            this.cboPixivProxy.FormattingEnabled = true;
            this.cboPixivProxy.Items.AddRange(new object[] {
            "pixiv.re",
            "pixiv.cat",
            "pixiv.nl"});
            this.cboPixivProxy.Location = new System.Drawing.Point(122, 533);
            this.cboPixivProxy.Name = "cboPixivProxy";
            this.cboPixivProxy.Size = new System.Drawing.Size(282, 25);
            this.cboPixivProxy.TabIndex = 88;
            // 
            // lblPixivProxy
            // 
            this.lblPixivProxy.AutoSize = true;
            this.lblPixivProxy.Location = new System.Drawing.Point(4, 536);
            this.lblPixivProxy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPixivProxy.Name = "lblPixivProxy";
            this.lblPixivProxy.Size = new System.Drawing.Size(93, 17);
            this.lblPixivProxy.TabIndex = 87;
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
            this.cboReplaceImgRoute.Location = new System.Drawing.Point(122, 502);
            this.cboReplaceImgRoute.Name = "cboReplaceImgRoute";
            this.cboReplaceImgRoute.Size = new System.Drawing.Size(282, 25);
            this.cboReplaceImgRoute.TabIndex = 86;
            // 
            // lblReplaceImgRoute
            // 
            this.lblReplaceImgRoute.AutoSize = true;
            this.lblReplaceImgRoute.Location = new System.Drawing.Point(4, 505);
            this.lblReplaceImgRoute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplaceImgRoute.Name = "lblReplaceImgRoute";
            this.lblReplaceImgRoute.Size = new System.Drawing.Size(116, 17);
            this.lblReplaceImgRoute.TabIndex = 85;
            this.lblReplaceImgRoute.Text = "图片外链路由替换：";
            // 
            // chkDownloadImage4Caching
            // 
            this.chkDownloadImage4Caching.AutoSize = true;
            this.chkDownloadImage4Caching.Location = new System.Drawing.Point(4, 587);
            this.chkDownloadImage4Caching.Name = "chkDownloadImage4Caching";
            this.chkDownloadImage4Caching.Size = new System.Drawing.Size(183, 21);
            this.chkDownloadImage4Caching.TabIndex = 84;
            this.chkDownloadImage4Caching.Text = "保留所有下载的图片用于缓存";
            this.chkDownloadImage4Caching.UseVisualStyleBackColor = true;
            // 
            // chkSendImageByFile
            // 
            this.chkSendImageByFile.AutoSize = true;
            this.chkSendImageByFile.Location = new System.Drawing.Point(4, 614);
            this.chkSendImageByFile.Name = "chkSendImageByFile";
            this.chkSendImageByFile.Size = new System.Drawing.Size(532, 21);
            this.chkSendImageByFile.TabIndex = 83;
            this.chkSendImageByFile.Text = "所有图片下载到本地再发送文件 (解决网络环境不佳导致将地址交由平台发送会TimeOut的问题)";
            this.chkSendImageByFile.UseVisualStyleBackColor = true;
            // 
            // pnlAutoConnect
            // 
            this.pnlAutoConnect.Controls.Add(this.txbAutoConnectDelay);
            this.pnlAutoConnect.Controls.Add(this.cboAutoConnectProtocol);
            this.pnlAutoConnect.Controls.Add(this.lblAutoConnectDelay);
            this.pnlAutoConnect.Controls.Add(this.lblAutoConnectProtocol);
            this.pnlAutoConnect.Enabled = false;
            this.pnlAutoConnect.Location = new System.Drawing.Point(1, 859);
            this.pnlAutoConnect.Name = "pnlAutoConnect";
            this.pnlAutoConnect.Size = new System.Drawing.Size(600, 62);
            this.pnlAutoConnect.TabIndex = 82;
            // 
            // txbAutoConnectDelay
            // 
            this.txbAutoConnectDelay.Location = new System.Drawing.Point(121, 34);
            this.txbAutoConnectDelay.Name = "txbAutoConnectDelay";
            this.txbAutoConnectDelay.Size = new System.Drawing.Size(185, 23);
            this.txbAutoConnectDelay.TabIndex = 50;
            // 
            // cboAutoConnectProtocol
            // 
            this.cboAutoConnectProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutoConnectProtocol.FormattingEnabled = true;
            this.cboAutoConnectProtocol.Items.AddRange(new object[] {
            "Mirai-Api-Http",
            "CqHttp"});
            this.cboAutoConnectProtocol.Location = new System.Drawing.Point(121, 3);
            this.cboAutoConnectProtocol.Name = "cboAutoConnectProtocol";
            this.cboAutoConnectProtocol.Size = new System.Drawing.Size(185, 25);
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
            this.chkAutoConnectEnabled.Location = new System.Drawing.Point(4, 832);
            this.chkAutoConnectEnabled.Name = "chkAutoConnectEnabled";
            this.chkAutoConnectEnabled.Size = new System.Drawing.Size(147, 21);
            this.chkAutoConnectEnabled.TabIndex = 81;
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
            this.cboLogLevel.Location = new System.Drawing.Point(117, 1024);
            this.cboLogLevel.Name = "cboLogLevel";
            this.cboLogLevel.Size = new System.Drawing.Size(190, 25);
            this.cboLogLevel.TabIndex = 80;
            // 
            // lblLogLevel
            // 
            this.lblLogLevel.AutoSize = true;
            this.lblLogLevel.Location = new System.Drawing.Point(4, 1027);
            this.lblLogLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogLevel.Name = "lblLogLevel";
            this.lblLogLevel.Size = new System.Drawing.Size(68, 17);
            this.lblLogLevel.TabIndex = 79;
            this.lblLogLevel.Text = "日志级别：";
            // 
            // chkHttpRequestByWebBrowser
            // 
            this.chkHttpRequestByWebBrowser.AutoSize = true;
            this.chkHttpRequestByWebBrowser.Location = new System.Drawing.Point(4, 475);
            this.chkHttpRequestByWebBrowser.Name = "chkHttpRequestByWebBrowser";
            this.chkHttpRequestByWebBrowser.Size = new System.Drawing.Size(269, 21);
            this.chkHttpRequestByWebBrowser.TabIndex = 78;
            this.chkHttpRequestByWebBrowser.Text = "允许调用浏览器执行Http请求(仅限Windows)";
            this.chkHttpRequestByWebBrowser.UseVisualStyleBackColor = true;
            // 
            // chkCheckPornEnabled
            // 
            this.chkCheckPornEnabled.AutoSize = true;
            this.chkCheckPornEnabled.Location = new System.Drawing.Point(4, 642);
            this.chkCheckPornEnabled.Name = "chkCheckPornEnabled";
            this.chkCheckPornEnabled.Size = new System.Drawing.Size(111, 21);
            this.chkCheckPornEnabled.TabIndex = 76;
            this.chkCheckPornEnabled.Text = "接入腾讯云鉴黄";
            this.chkCheckPornEnabled.UseVisualStyleBackColor = true;
            this.chkCheckPornEnabled.CheckedChanged += new System.EventHandler(this.chkCheckPorn_CheckedChanged);
            // 
            // pnlDebugMode
            // 
            this.pnlDebugMode.Controls.Add(this.chkOnlyReplyDebugGroup);
            this.pnlDebugMode.Controls.Add(this.lstDebugGroups);
            this.pnlDebugMode.Controls.Add(this.chkDebugReplyAdminOnly);
            this.pnlDebugMode.Controls.Add(this.lblAddDebugGroup);
            this.pnlDebugMode.Controls.Add(this.lblDebugGroup);
            this.pnlDebugMode.Controls.Add(this.btnAddDebugGroup);
            this.pnlDebugMode.Controls.Add(this.btnRemoveDebugGroup);
            this.pnlDebugMode.Controls.Add(this.txbAddDebugGroup);
            this.pnlDebugMode.Enabled = false;
            this.pnlDebugMode.Location = new System.Drawing.Point(1, 1088);
            this.pnlDebugMode.Name = "pnlDebugMode";
            this.pnlDebugMode.Size = new System.Drawing.Size(600, 153);
            this.pnlDebugMode.TabIndex = 75;
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
            this.lstDebugGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstDebugGroups.Name = "lstDebugGroups";
            this.lstDebugGroups.Size = new System.Drawing.Size(190, 85);
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
            this.lblAddDebugGroup.Location = new System.Drawing.Point(399, 8);
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
            this.btnAddDebugGroup.Location = new System.Drawing.Point(314, 30);
            this.btnAddDebugGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddDebugGroup.Name = "btnAddDebugGroup";
            this.btnAddDebugGroup.Size = new System.Drawing.Size(88, 23);
            this.btnAddDebugGroup.TabIndex = 4;
            this.btnAddDebugGroup.Text = "<<添加<<";
            this.btnAddDebugGroup.UseVisualStyleBackColor = true;
            this.btnAddDebugGroup.Click += new System.EventHandler(this.btnAddDebugGroup_Click);
            // 
            // btnRemoveDebugGroup
            // 
            this.btnRemoveDebugGroup.Location = new System.Drawing.Point(314, 61);
            this.btnRemoveDebugGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveDebugGroup.Name = "btnRemoveDebugGroup";
            this.btnRemoveDebugGroup.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveDebugGroup.TabIndex = 4;
            this.btnRemoveDebugGroup.Text = ">>移除>>";
            this.btnRemoveDebugGroup.UseVisualStyleBackColor = true;
            this.btnRemoveDebugGroup.Click += new System.EventHandler(this.btnRemoveDebugGroup_Click);
            // 
            // txbAddDebugGroup
            // 
            this.txbAddDebugGroup.Location = new System.Drawing.Point(410, 30);
            this.txbAddDebugGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbAddDebugGroup.Name = "txbAddDebugGroup";
            this.txbAddDebugGroup.ShortcutsEnabled = false;
            this.txbAddDebugGroup.Size = new System.Drawing.Size(186, 23);
            this.txbAddDebugGroup.TabIndex = 0;
            this.txbAddDebugGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbAddDebugGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbBanUser
            // 
            this.txbBanUser.Location = new System.Drawing.Point(412, 330);
            this.txbBanUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbBanUser.Name = "txbBanUser";
            this.txbBanUser.ShortcutsEnabled = false;
            this.txbBanUser.Size = new System.Drawing.Size(186, 23);
            this.txbBanUser.TabIndex = 57;
            this.txbBanUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbBanUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // pnlCheckPorn
            // 
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
            this.pnlCheckPorn.Location = new System.Drawing.Point(1, 669);
            this.pnlCheckPorn.Name = "pnlCheckPorn";
            this.pnlCheckPorn.Size = new System.Drawing.Size(600, 160);
            this.pnlCheckPorn.TabIndex = 77;
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
            this.txbTencentCloudBucket.Location = new System.Drawing.Point(121, 119);
            this.txbTencentCloudBucket.Name = "txbTencentCloudBucket";
            this.txbTencentCloudBucket.Size = new System.Drawing.Size(476, 23);
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
            this.txbTencentCloudRegion.Location = new System.Drawing.Point(121, 32);
            this.txbTencentCloudRegion.Name = "txbTencentCloudRegion";
            this.txbTencentCloudRegion.Size = new System.Drawing.Size(476, 23);
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
            this.txbTencentCloudSecretId.Location = new System.Drawing.Point(121, 61);
            this.txbTencentCloudSecretId.Name = "txbTencentCloudSecretId";
            this.txbTencentCloudSecretId.Size = new System.Drawing.Size(476, 23);
            this.txbTencentCloudSecretId.TabIndex = 16;
            // 
            // txbTencentCloudAPPID
            // 
            this.txbTencentCloudAPPID.Location = new System.Drawing.Point(121, 3);
            this.txbTencentCloudAPPID.Name = "txbTencentCloudAPPID";
            this.txbTencentCloudAPPID.Size = new System.Drawing.Size(476, 23);
            this.txbTencentCloudAPPID.TabIndex = 16;
            // 
            // txbTencentCloudSecretKey
            // 
            this.txbTencentCloudSecretKey.Location = new System.Drawing.Point(121, 90);
            this.txbTencentCloudSecretKey.Name = "txbTencentCloudSecretKey";
            this.txbTencentCloudSecretKey.Size = new System.Drawing.Size(476, 23);
            this.txbTencentCloudSecretKey.TabIndex = 16;
            // 
            // txbBanGroup
            // 
            this.txbBanGroup.Location = new System.Drawing.Point(412, 184);
            this.txbBanGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbBanGroup.Name = "txbBanGroup";
            this.txbBanGroup.ShortcutsEnabled = false;
            this.txbBanGroup.Size = new System.Drawing.Size(186, 23);
            this.txbBanGroup.TabIndex = 54;
            this.txbBanGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbBanGroup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // chkDebugMode
            // 
            this.chkDebugMode.AutoSize = true;
            this.chkDebugMode.Location = new System.Drawing.Point(3, 1059);
            this.chkDebugMode.Name = "chkDebugMode";
            this.chkDebugMode.Size = new System.Drawing.Size(75, 21);
            this.chkDebugMode.TabIndex = 74;
            this.chkDebugMode.Text = "调试模式";
            this.chkDebugMode.UseVisualStyleBackColor = true;
            this.chkDebugMode.CheckedChanged += new System.EventHandler(this.chkDebugMode_CheckedChanged);
            // 
            // txbAddAdmin
            // 
            this.txbAddAdmin.Location = new System.Drawing.Point(412, 56);
            this.txbAddAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbAddAdmin.Name = "txbAddAdmin";
            this.txbAddAdmin.ShortcutsEnabled = false;
            this.txbAddAdmin.Size = new System.Drawing.Size(186, 23);
            this.txbAddAdmin.TabIndex = 56;
            this.txbAddAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbAddAdmin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // lblBotName
            // 
            this.lblBotName.AutoSize = true;
            this.lblBotName.Location = new System.Drawing.Point(4, 8);
            this.lblBotName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBotName.Name = "lblBotName";
            this.lblBotName.Size = new System.Drawing.Size(80, 17);
            this.lblBotName.TabIndex = 63;
            this.lblBotName.Text = "机器人名称：";
            // 
            // btnRemoveBanUser
            // 
            this.btnRemoveBanUser.Location = new System.Drawing.Point(316, 371);
            this.btnRemoveBanUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveBanUser.Name = "btnRemoveBanUser";
            this.btnRemoveBanUser.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveBanUser.TabIndex = 73;
            this.btnRemoveBanUser.Text = ">>移除>>";
            this.btnRemoveBanUser.UseVisualStyleBackColor = true;
            this.btnRemoveBanUser.Click += new System.EventHandler(this.btnRemoveBanUser_Click);
            // 
            // btnRemoveBanGroup
            // 
            this.btnRemoveBanGroup.Location = new System.Drawing.Point(316, 225);
            this.btnRemoveBanGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveBanGroup.Name = "btnRemoveBanGroup";
            this.btnRemoveBanGroup.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveBanGroup.TabIndex = 72;
            this.btnRemoveBanGroup.Text = ">>移除>>";
            this.btnRemoveBanGroup.UseVisualStyleBackColor = true;
            this.btnRemoveBanGroup.Click += new System.EventHandler(this.btnRemoveBanGroup_Click);
            // 
            // txbBotName
            // 
            this.txbBotName.Location = new System.Drawing.Point(122, 3);
            this.txbBotName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbBotName.Name = "txbBotName";
            this.txbBotName.Size = new System.Drawing.Size(476, 23);
            this.txbBotName.TabIndex = 55;
            // 
            // btnRemoveAdmin
            // 
            this.btnRemoveAdmin.Location = new System.Drawing.Point(316, 87);
            this.btnRemoveAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveAdmin.Name = "btnRemoveAdmin";
            this.btnRemoveAdmin.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveAdmin.TabIndex = 68;
            this.btnRemoveAdmin.Text = ">>移除>>";
            this.btnRemoveAdmin.UseVisualStyleBackColor = true;
            this.btnRemoveAdmin.Click += new System.EventHandler(this.btnRemoveAdmin_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(4, 35);
            this.lblAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(112, 17);
            this.lblAdmin.TabIndex = 62;
            this.lblAdmin.Text = "机器人管理员QQ：";
            // 
            // btnAddBanUser
            // 
            this.btnAddBanUser.Location = new System.Drawing.Point(316, 330);
            this.btnAddBanUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddBanUser.Name = "btnAddBanUser";
            this.btnAddBanUser.Size = new System.Drawing.Size(88, 23);
            this.btnAddBanUser.TabIndex = 71;
            this.btnAddBanUser.Text = "<<添加<<";
            this.btnAddBanUser.UseVisualStyleBackColor = true;
            this.btnAddBanUser.Click += new System.EventHandler(this.btnAddBanUser_Click);
            // 
            // lblAddAdmin
            // 
            this.lblAddAdmin.AutoSize = true;
            this.lblAddAdmin.Location = new System.Drawing.Point(410, 35);
            this.lblAddAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddAdmin.Name = "lblAddAdmin";
            this.lblAddAdmin.Size = new System.Drawing.Size(100, 17);
            this.lblAddAdmin.TabIndex = 61;
            this.lblAddAdmin.Text = "添加管理员QQ：";
            // 
            // btnAddBanGroup
            // 
            this.btnAddBanGroup.Location = new System.Drawing.Point(316, 184);
            this.btnAddBanGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddBanGroup.Name = "btnAddBanGroup";
            this.btnAddBanGroup.Size = new System.Drawing.Size(88, 23);
            this.btnAddBanGroup.TabIndex = 70;
            this.btnAddBanGroup.Text = "<<添加<<";
            this.btnAddBanGroup.UseVisualStyleBackColor = true;
            this.btnAddBanGroup.Click += new System.EventHandler(this.btnAddBanGroup_Click);
            // 
            // lblBannedGroup
            // 
            this.lblBannedGroup.AutoSize = true;
            this.lblBannedGroup.Location = new System.Drawing.Point(4, 163);
            this.lblBannedGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBannedGroup.Name = "lblBannedGroup";
            this.lblBannedGroup.Size = new System.Drawing.Size(68, 17);
            this.lblBannedGroup.TabIndex = 60;
            this.lblBannedGroup.Text = "群黑名单：";
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.Location = new System.Drawing.Point(316, 56);
            this.btnAddAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddAdmin.Name = "btnAddAdmin";
            this.btnAddAdmin.Size = new System.Drawing.Size(88, 23);
            this.btnAddAdmin.TabIndex = 69;
            this.btnAddAdmin.Text = "<<添加<<";
            this.btnAddAdmin.UseVisualStyleBackColor = true;
            this.btnAddAdmin.Click += new System.EventHandler(this.btnAddAdmin_Click);
            // 
            // lstAdmins
            // 
            this.lstAdmins.FullRowSelect = true;
            this.lstAdmins.Location = new System.Drawing.Point(122, 34);
            this.lstAdmins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstAdmins.Name = "lstAdmins";
            this.lstAdmins.Size = new System.Drawing.Size(186, 85);
            this.lstAdmins.TabIndex = 66;
            this.lstAdmins.UseCompatibleStateImageBehavior = false;
            this.lstAdmins.View = System.Windows.Forms.View.List;
            // 
            // lstBannedUser
            // 
            this.lstBannedUser.FullRowSelect = true;
            this.lstBannedUser.Location = new System.Drawing.Point(122, 308);
            this.lstBannedUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBannedUser.Name = "lstBannedUser";
            this.lstBannedUser.Size = new System.Drawing.Size(186, 136);
            this.lstBannedUser.TabIndex = 65;
            this.lstBannedUser.UseCompatibleStateImageBehavior = false;
            this.lstBannedUser.View = System.Windows.Forms.View.List;
            // 
            // lblBannedUser
            // 
            this.lblBannedUser.AutoSize = true;
            this.lblBannedUser.Location = new System.Drawing.Point(4, 309);
            this.lblBannedUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBannedUser.Name = "lblBannedUser";
            this.lblBannedUser.Size = new System.Drawing.Size(80, 17);
            this.lblBannedUser.TabIndex = 59;
            this.lblBannedUser.Text = "用户黑名单：";
            // 
            // lblBanUser
            // 
            this.lblBanUser.AutoSize = true;
            this.lblBanUser.Location = new System.Drawing.Point(410, 309);
            this.lblBanUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanUser.Name = "lblBanUser";
            this.lblBanUser.Size = new System.Drawing.Size(116, 17);
            this.lblBanUser.TabIndex = 58;
            this.lblBanUser.Text = "添加到用户黑名单：";
            // 
            // lblBanGroup
            // 
            this.lblBanGroup.AutoSize = true;
            this.lblBanGroup.Location = new System.Drawing.Point(410, 163);
            this.lblBanGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanGroup.Name = "lblBanGroup";
            this.lblBanGroup.Size = new System.Drawing.Size(104, 17);
            this.lblBanGroup.TabIndex = 64;
            this.lblBanGroup.Text = "添加到群黑名单：";
            // 
            // lstBannedGroup
            // 
            this.lstBannedGroup.FullRowSelect = true;
            this.lstBannedGroup.Location = new System.Drawing.Point(122, 162);
            this.lstBannedGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBannedGroup.Name = "lstBannedGroup";
            this.lstBannedGroup.Size = new System.Drawing.Size(186, 136);
            this.lstBannedGroup.TabIndex = 67;
            this.lstBannedGroup.UseCompatibleStateImageBehavior = false;
            this.lstBannedGroup.View = System.Windows.Forms.View.List;
            // 
            // chkSplitTextAndImageMessage
            // 
            this.chkSplitTextAndImageMessage.AutoSize = true;
            this.chkSplitTextAndImageMessage.Location = new System.Drawing.Point(4, 562);
            this.chkSplitTextAndImageMessage.Name = "chkSplitTextAndImageMessage";
            this.chkSplitTextAndImageMessage.Size = new System.Drawing.Size(363, 21);
            this.chkSplitTextAndImageMessage.TabIndex = 84;
            this.chkSplitTextAndImageMessage.Text = "搜图和色图把文字消息和图片消息拆分开（合并转发模式无效）";
            this.chkSplitTextAndImageMessage.UseVisualStyleBackColor = true;
            // 
            // chkLeaveGroupAfterBeMushin
            // 
            this.chkLeaveGroupAfterBeMushin.AutoSize = true;
            this.chkLeaveGroupAfterBeMushin.Location = new System.Drawing.Point(4, 450);
            this.chkLeaveGroupAfterBeMushin.Name = "chkLeaveGroupAfterBeMushin";
            this.chkLeaveGroupAfterBeMushin.Size = new System.Drawing.Size(135, 21);
            this.chkLeaveGroupAfterBeMushin.TabIndex = 92;
            this.chkLeaveGroupAfterBeMushin.Text = "自动退出被禁言的群";
            this.chkLeaveGroupAfterBeMushin.UseVisualStyleBackColor = true;
            // 
            // CtrlBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkLeaveGroupAfterBeMushin);
            this.Controls.Add(this.lblWorkingTime);
            this.Controls.Add(this.chkWorkingTimeEnabled);
            this.Controls.Add(this.pnlWorkingTime);
            this.Controls.Add(this.cboPixivProxy);
            this.Controls.Add(this.lblPixivProxy);
            this.Controls.Add(this.cboReplaceImgRoute);
            this.Controls.Add(this.lblReplaceImgRoute);
            this.Controls.Add(this.chkSplitTextAndImageMessage);
            this.Controls.Add(this.chkDownloadImage4Caching);
            this.Controls.Add(this.chkSendImageByFile);
            this.Controls.Add(this.pnlAutoConnect);
            this.Controls.Add(this.chkAutoConnectEnabled);
            this.Controls.Add(this.cboLogLevel);
            this.Controls.Add(this.lblLogLevel);
            this.Controls.Add(this.chkHttpRequestByWebBrowser);
            this.Controls.Add(this.chkCheckPornEnabled);
            this.Controls.Add(this.pnlDebugMode);
            this.Controls.Add(this.txbBanUser);
            this.Controls.Add(this.pnlCheckPorn);
            this.Controls.Add(this.txbBanGroup);
            this.Controls.Add(this.chkDebugMode);
            this.Controls.Add(this.txbAddAdmin);
            this.Controls.Add(this.lblBotName);
            this.Controls.Add(this.btnRemoveBanUser);
            this.Controls.Add(this.btnRemoveBanGroup);
            this.Controls.Add(this.txbBotName);
            this.Controls.Add(this.btnRemoveAdmin);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.btnAddBanUser);
            this.Controls.Add(this.lblAddAdmin);
            this.Controls.Add(this.btnAddBanGroup);
            this.Controls.Add(this.lblBannedGroup);
            this.Controls.Add(this.btnAddAdmin);
            this.Controls.Add(this.lstAdmins);
            this.Controls.Add(this.lstBannedUser);
            this.Controls.Add(this.lblBannedUser);
            this.Controls.Add(this.lblBanUser);
            this.Controls.Add(this.lblBanGroup);
            this.Controls.Add(this.lstBannedGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CtrlBot";
            this.Size = new System.Drawing.Size(563, 588);
            this.pnlWorkingTime.ResumeLayout(false);
            this.pnlWorkingTime.PerformLayout();
            this.pnlAutoConnect.ResumeLayout(false);
            this.pnlAutoConnect.PerformLayout();
            this.pnlDebugMode.ResumeLayout(false);
            this.pnlDebugMode.PerformLayout();
            this.pnlCheckPorn.ResumeLayout(false);
            this.pnlCheckPorn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblWorkingTime;
        private CheckBox chkWorkingTimeEnabled;
        private Panel pnlWorkingTime;
        private Label lblWorkingTimeToMinute;
        private Label lblWorkingTimeFromMinute;
        private Label lblWorkingTimeToHour;
        private Label lblWorkingTimeFromHour;
        private Label lblWorkingTimeTo;
        private Label lblWorkingTimeFrom;
        private ComboBox cboWorkingTimeFromHour;
        private ComboBox cboWorkingTimeToHour;
        private ComboBox cboWorkingTimeToMinute;
        private ComboBox cboWorkingTimeFromMinute;
        private ComboBox cboPixivProxy;
        private Label lblPixivProxy;
        private ComboBox cboReplaceImgRoute;
        private Label lblReplaceImgRoute;
        private CheckBox chkDownloadImage4Caching;
        private CheckBox chkSendImageByFile;
        private Panel pnlAutoConnect;
        private TextBox txbAutoConnectDelay;
        private ComboBox cboAutoConnectProtocol;
        private Label lblAutoConnectDelay;
        private Label lblAutoConnectProtocol;
        private CheckBox chkAutoConnectEnabled;
        private ComboBox cboLogLevel;
        private Label lblLogLevel;
        private CheckBox chkHttpRequestByWebBrowser;
        private CheckBox chkCheckPornEnabled;
        private Panel pnlDebugMode;
        private CheckBox chkOnlyReplyDebugGroup;
        private ListView lstDebugGroups;
        private CheckBox chkDebugReplyAdminOnly;
        private Label lblAddDebugGroup;
        private Label lblDebugGroup;
        private Button btnAddDebugGroup;
        private Button btnRemoveDebugGroup;
        private TextBox txbAddDebugGroup;
        private TextBox txbBanUser;
        private Panel pnlCheckPorn;
        private Label lblTencentCloudBucket;
        private Label lblTencentCloudSecretKey;
        private TextBox txbTencentCloudBucket;
        private Label lblTencentCloudSecretId;
        private TextBox txbTencentCloudRegion;
        private Label lblTencentCloudRegion;
        private Label lblTencentCloudAPPID;
        private TextBox txbTencentCloudSecretId;
        private TextBox txbTencentCloudAPPID;
        private TextBox txbTencentCloudSecretKey;
        private TextBox txbBanGroup;
        private CheckBox chkDebugMode;
        private TextBox txbAddAdmin;
        private Label lblBotName;
        private Button btnRemoveBanUser;
        private Button btnRemoveBanGroup;
        private TextBox txbBotName;
        private Button btnRemoveAdmin;
        private Label lblAdmin;
        private Button btnAddBanUser;
        private Label lblAddAdmin;
        private Button btnAddBanGroup;
        private Label lblBannedGroup;
        private Button btnAddAdmin;
        private ListView lstAdmins;
        private ListView lstBannedUser;
        private Label lblBannedUser;
        private Label lblBanUser;
        private Label lblBanGroup;
        private ListView lstBannedGroup;
        private CheckBox chkSplitTextAndImageMessage;
        private CheckBox chkLeaveGroupAfterBeMushin;
    }
}
