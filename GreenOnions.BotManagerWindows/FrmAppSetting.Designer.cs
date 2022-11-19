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
            if (disposing && (components is not null))
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
            this.btnOk = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.pageBot = new System.Windows.Forms.TabPage();
            this.pnlBot = new GreenOnions.BotManagerWindows.Controls.CtrlBot();
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
            this.pnlHPictureEnabled = new System.Windows.Forms.Panel();
            this.chkHPictureEnabled = new System.Windows.Forms.CheckBox();
            this.pageTranslate = new System.Windows.Forms.TabPage();
            this.pnlTranslate = new GreenOnions.BotManagerWindows.Controls.CtrlTranslate();
            this.pnlTranslateEnabled = new System.Windows.Forms.Panel();
            this.chkTranslateEnabled = new System.Windows.Forms.CheckBox();
            this.pageRepeater = new System.Windows.Forms.TabPage();
            this.pnlRepeater = new GreenOnions.BotManagerWindows.Controls.CtrlRepeater();
            this.pageGroupMemberEvents = new System.Windows.Forms.TabPage();
            this.txbMemberBeKickedMessage = new System.Windows.Forms.TextBox();
            this.txbMemberPositiveLeaveMessage = new System.Windows.Forms.TextBox();
            this.txbMemberJoinedMessage = new System.Windows.Forms.TextBox();
            this.chkSendMemberBeKickedMessage = new System.Windows.Forms.CheckBox();
            this.chkSendMemberPositiveLeaveMessage = new System.Windows.Forms.CheckBox();
            this.chkSendMemberJoinedMessage = new System.Windows.Forms.CheckBox();
            this.pageForgeMessage = new System.Windows.Forms.TabPage();
            this.pnlForgeMessage = new GreenOnions.BotManagerWindows.Controls.CtrlForgeMessage();
            this.pnlForgeMessageEnabled = new System.Windows.Forms.Panel();
            this.chkEnabledForgeMessage = new System.Windows.Forms.CheckBox();
            this.pageRss = new System.Windows.Forms.TabPage();
            this.pnlRss = new GreenOnions.BotManagerWindows.Controls.CtrlRss();
            this.pnlRssEnabled = new System.Windows.Forms.Panel();
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
            this.btnResetCtrlSize = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.pageBot.SuspendLayout();
            this.pageSearchPicture.SuspendLayout();
            this.pnlSearchPictureEnabled.SuspendLayout();
            this.pageOriginalPicture.SuspendLayout();
            this.pnlOriginalPictureEnabled.SuspendLayout();
            this.pageHPicture.SuspendLayout();
            this.pnlHPictureEnabled.SuspendLayout();
            this.pageTranslate.SuspendLayout();
            this.pnlTranslateEnabled.SuspendLayout();
            this.pageRepeater.SuspendLayout();
            this.pageGroupMemberEvents.SuspendLayout();
            this.pageForgeMessage.SuspendLayout();
            this.pnlForgeMessageEnabled.SuspendLayout();
            this.pageRss.SuspendLayout();
            this.pnlRssEnabled.SuspendLayout();
            this.pageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(479, 1024);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 32);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.tabSettings.Location = new System.Drawing.Point(20, 18);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(6);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(1034, 994);
            this.tabSettings.TabIndex = 4;
            // 
            // pageBot
            // 
            this.pageBot.Controls.Add(this.pnlBot);
            this.pageBot.Location = new System.Drawing.Point(4, 33);
            this.pageBot.Margin = new System.Windows.Forms.Padding(6);
            this.pageBot.Name = "pageBot";
            this.pageBot.Padding = new System.Windows.Forms.Padding(6);
            this.pageBot.Size = new System.Drawing.Size(1026, 957);
            this.pageBot.TabIndex = 1;
            this.pageBot.Text = "机器人设置";
            this.pageBot.UseVisualStyleBackColor = true;
            // 
            // pnlBot
            // 
            this.pnlBot.AutoScroll = true;
            this.pnlBot.BackColor = System.Drawing.Color.White;
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBot.Location = new System.Drawing.Point(6, 6);
            this.pnlBot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(1014, 945);
            this.pnlBot.TabIndex = 0;
            // 
            // pageSearchPicture
            // 
            this.pageSearchPicture.Controls.Add(this.pnlSearchPicture);
            this.pageSearchPicture.Controls.Add(this.pnlSearchPictureEnabled);
            this.pageSearchPicture.Location = new System.Drawing.Point(4, 33);
            this.pageSearchPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageSearchPicture.Name = "pageSearchPicture";
            this.pageSearchPicture.Size = new System.Drawing.Size(192, 63);
            this.pageSearchPicture.TabIndex = 3;
            this.pageSearchPicture.Text = "搜图设置";
            this.pageSearchPicture.UseVisualStyleBackColor = true;
            // 
            // pnlSearchPicture
            // 
            this.pnlSearchPicture.AutoScroll = true;
            this.pnlSearchPicture.BackColor = System.Drawing.Color.White;
            this.pnlSearchPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchPicture.Enabled = false;
            this.pnlSearchPicture.Location = new System.Drawing.Point(0, 56);
            this.pnlSearchPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlSearchPicture.Name = "pnlSearchPicture";
            this.pnlSearchPicture.Size = new System.Drawing.Size(192, 7);
            this.pnlSearchPicture.TabIndex = 18;
            // 
            // pnlSearchPictureEnabled
            // 
            this.pnlSearchPictureEnabled.Controls.Add(this.chkSearchPictureEnabled);
            this.pnlSearchPictureEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchPictureEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchPictureEnabled.Name = "pnlSearchPictureEnabled";
            this.pnlSearchPictureEnabled.Size = new System.Drawing.Size(192, 56);
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
            this.pageOriginalPicture.Size = new System.Drawing.Size(192, 63);
            this.pageOriginalPicture.TabIndex = 9;
            this.pageOriginalPicture.Text = "下载原图";
            this.pageOriginalPicture.UseVisualStyleBackColor = true;
            // 
            // pnlOriginalPicture
            // 
            this.pnlOriginalPicture.BackColor = System.Drawing.Color.White;
            this.pnlOriginalPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOriginalPicture.Enabled = false;
            this.pnlOriginalPicture.Location = new System.Drawing.Point(0, 56);
            this.pnlOriginalPicture.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlOriginalPicture.Name = "pnlOriginalPicture";
            this.pnlOriginalPicture.Size = new System.Drawing.Size(192, 7);
            this.pnlOriginalPicture.TabIndex = 3;
            // 
            // pnlOriginalPictureEnabled
            // 
            this.pnlOriginalPictureEnabled.Controls.Add(this.chkOriginalPictureEnabled);
            this.pnlOriginalPictureEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOriginalPictureEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlOriginalPictureEnabled.Name = "pnlOriginalPictureEnabled";
            this.pnlOriginalPictureEnabled.Size = new System.Drawing.Size(192, 56);
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
            this.pageHPicture.Controls.Add(this.pnlHPictureEnabled);
            this.pageHPicture.Location = new System.Drawing.Point(4, 33);
            this.pageHPicture.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pageHPicture.Name = "pageHPicture";
            this.pageHPicture.Size = new System.Drawing.Size(192, 63);
            this.pageHPicture.TabIndex = 0;
            this.pageHPicture.Text = "色图设置";
            this.pageHPicture.UseVisualStyleBackColor = true;
            // 
            // pnlHPicture
            // 
            this.pnlHPicture.AutoScroll = true;
            this.pnlHPicture.BackColor = System.Drawing.Color.White;
            this.pnlHPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHPicture.Enabled = false;
            this.pnlHPicture.Location = new System.Drawing.Point(0, 56);
            this.pnlHPicture.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlHPicture.Name = "pnlHPicture";
            this.pnlHPicture.Size = new System.Drawing.Size(192, 7);
            this.pnlHPicture.TabIndex = 10;
            // 
            // pnlHPictureEnabled
            // 
            this.pnlHPictureEnabled.Controls.Add(this.chkHPictureEnabled);
            this.pnlHPictureEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHPictureEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlHPictureEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlHPictureEnabled.Name = "pnlHPictureEnabled";
            this.pnlHPictureEnabled.Size = new System.Drawing.Size(192, 56);
            this.pnlHPictureEnabled.TabIndex = 9;
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
            this.pageTranslate.Controls.Add(this.pnlTranslateEnabled);
            this.pageTranslate.Location = new System.Drawing.Point(4, 33);
            this.pageTranslate.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pageTranslate.Name = "pageTranslate";
            this.pageTranslate.Size = new System.Drawing.Size(192, 63);
            this.pageTranslate.TabIndex = 4;
            this.pageTranslate.Text = "翻译设置";
            this.pageTranslate.UseVisualStyleBackColor = true;
            // 
            // pnlTranslate
            // 
            this.pnlTranslate.BackColor = System.Drawing.Color.White;
            this.pnlTranslate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranslate.Enabled = false;
            this.pnlTranslate.Location = new System.Drawing.Point(0, 56);
            this.pnlTranslate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlTranslate.Name = "pnlTranslate";
            this.pnlTranslate.Size = new System.Drawing.Size(192, 7);
            this.pnlTranslate.TabIndex = 2;
            // 
            // pnlTranslateEnabled
            // 
            this.pnlTranslateEnabled.Controls.Add(this.chkTranslateEnabled);
            this.pnlTranslateEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTranslateEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlTranslateEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlTranslateEnabled.Name = "pnlTranslateEnabled";
            this.pnlTranslateEnabled.Size = new System.Drawing.Size(192, 56);
            this.pnlTranslateEnabled.TabIndex = 1;
            // 
            // chkTranslateEnabled
            // 
            this.chkTranslateEnabled.AutoSize = true;
            this.chkTranslateEnabled.Location = new System.Drawing.Point(8, 6);
            this.chkTranslateEnabled.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chkTranslateEnabled.Name = "chkTranslateEnabled";
            this.chkTranslateEnabled.Size = new System.Drawing.Size(144, 28);
            this.chkTranslateEnabled.TabIndex = 0;
            this.chkTranslateEnabled.Text = "启用翻译功能";
            this.chkTranslateEnabled.UseVisualStyleBackColor = true;
            this.chkTranslateEnabled.CheckedChanged += new System.EventHandler(this.chkTranslateEnabled_CheckedChanged);
            // 
            // pageRepeater
            // 
            this.pageRepeater.Controls.Add(this.pnlRepeater);
            this.pageRepeater.Location = new System.Drawing.Point(4, 33);
            this.pageRepeater.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pageRepeater.Name = "pageRepeater";
            this.pageRepeater.Size = new System.Drawing.Size(192, 63);
            this.pageRepeater.TabIndex = 5;
            this.pageRepeater.Text = "复读设置";
            this.pageRepeater.UseVisualStyleBackColor = true;
            // 
            // pnlRepeater
            // 
            this.pnlRepeater.BackColor = System.Drawing.Color.White;
            this.pnlRepeater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRepeater.Location = new System.Drawing.Point(0, 0);
            this.pnlRepeater.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRepeater.Name = "pnlRepeater";
            this.pnlRepeater.Size = new System.Drawing.Size(192, 63);
            this.pnlRepeater.TabIndex = 0;
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
            this.pageForgeMessage.Controls.Add(this.pnlForgeMessageEnabled);
            this.pageForgeMessage.Location = new System.Drawing.Point(4, 33);
            this.pageForgeMessage.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pageForgeMessage.Name = "pageForgeMessage";
            this.pageForgeMessage.Size = new System.Drawing.Size(192, 63);
            this.pageForgeMessage.TabIndex = 7;
            this.pageForgeMessage.Text = "伪造消息";
            this.pageForgeMessage.UseVisualStyleBackColor = true;
            // 
            // pnlForgeMessage
            // 
            this.pnlForgeMessage.BackColor = System.Drawing.Color.White;
            this.pnlForgeMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForgeMessage.Enabled = false;
            this.pnlForgeMessage.Location = new System.Drawing.Point(0, 56);
            this.pnlForgeMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlForgeMessage.Name = "pnlForgeMessage";
            this.pnlForgeMessage.Size = new System.Drawing.Size(192, 7);
            this.pnlForgeMessage.TabIndex = 13;
            // 
            // pnlForgeMessageEnabled
            // 
            this.pnlForgeMessageEnabled.Controls.Add(this.chkEnabledForgeMessage);
            this.pnlForgeMessageEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlForgeMessageEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlForgeMessageEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlForgeMessageEnabled.Name = "pnlForgeMessageEnabled";
            this.pnlForgeMessageEnabled.Size = new System.Drawing.Size(192, 56);
            this.pnlForgeMessageEnabled.TabIndex = 12;
            // 
            // chkEnabledForgeMessage
            // 
            this.chkEnabledForgeMessage.AutoSize = true;
            this.chkEnabledForgeMessage.Location = new System.Drawing.Point(9, 8);
            this.chkEnabledForgeMessage.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
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
            this.pageRss.Controls.Add(this.pnlRssEnabled);
            this.pageRss.Location = new System.Drawing.Point(4, 33);
            this.pageRss.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pageRss.Name = "pageRss";
            this.pageRss.Size = new System.Drawing.Size(1026, 957);
            this.pageRss.TabIndex = 8;
            this.pageRss.Text = "RSS转发";
            this.pageRss.UseVisualStyleBackColor = true;
            // 
            // pnlRss
            // 
            this.pnlRss.BackColor = System.Drawing.Color.White;
            this.pnlRss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRss.Enabled = false;
            this.pnlRss.Location = new System.Drawing.Point(0, 56);
            this.pnlRss.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRss.Name = "pnlRss";
            this.pnlRss.Size = new System.Drawing.Size(1026, 901);
            this.pnlRss.TabIndex = 2;
            // 
            // pnlRssEnabled
            // 
            this.pnlRssEnabled.Controls.Add(this.chkRssEnabled);
            this.pnlRssEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRssEnabled.Location = new System.Drawing.Point(0, 0);
            this.pnlRssEnabled.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRssEnabled.Name = "pnlRssEnabled";
            this.pnlRssEnabled.Size = new System.Drawing.Size(1026, 56);
            this.pnlRssEnabled.TabIndex = 1;
            // 
            // chkRssEnabled
            // 
            this.chkRssEnabled.AutoSize = true;
            this.chkRssEnabled.Location = new System.Drawing.Point(8, 6);
            this.chkRssEnabled.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chkRssEnabled.Name = "chkRssEnabled";
            this.chkRssEnabled.Size = new System.Drawing.Size(176, 28);
            this.chkRssEnabled.TabIndex = 0;
            this.chkRssEnabled.Text = "启用RSS订阅转发";
            this.chkRssEnabled.UseVisualStyleBackColor = true;
            this.chkRssEnabled.CheckedChanged += new System.EventHandler(this.chkRssEnabled_CheckedChanged);
            // 
            // pageAbout
            // 
            this.pageAbout.BackColor = System.Drawing.Color.White;
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
            // btnResetCtrlSize
            // 
            this.btnResetCtrlSize.Location = new System.Drawing.Point(0, 0);
            this.btnResetCtrlSize.Name = "btnResetCtrlSize";
            this.btnResetCtrlSize.Size = new System.Drawing.Size(20, 20);
            this.btnResetCtrlSize.TabIndex = 5;
            this.btnResetCtrlSize.UseVisualStyleBackColor = true;
            this.btnResetCtrlSize.Click += new System.EventHandler(this.btnResetCtrlSize_Click);
            // 
            // FrmAppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 1074);
            this.Controls.Add(this.btnResetCtrlSize);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabSettings);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用设置";
            this.tabSettings.ResumeLayout(false);
            this.pageBot.ResumeLayout(false);
            this.pageSearchPicture.ResumeLayout(false);
            this.pnlSearchPictureEnabled.ResumeLayout(false);
            this.pnlSearchPictureEnabled.PerformLayout();
            this.pageOriginalPicture.ResumeLayout(false);
            this.pnlOriginalPictureEnabled.ResumeLayout(false);
            this.pnlOriginalPictureEnabled.PerformLayout();
            this.pageHPicture.ResumeLayout(false);
            this.pnlHPictureEnabled.ResumeLayout(false);
            this.pnlHPictureEnabled.PerformLayout();
            this.pageTranslate.ResumeLayout(false);
            this.pnlTranslateEnabled.ResumeLayout(false);
            this.pnlTranslateEnabled.PerformLayout();
            this.pageRepeater.ResumeLayout(false);
            this.pageGroupMemberEvents.ResumeLayout(false);
            this.pageGroupMemberEvents.PerformLayout();
            this.pageForgeMessage.ResumeLayout(false);
            this.pnlForgeMessageEnabled.ResumeLayout(false);
            this.pnlForgeMessageEnabled.PerformLayout();
            this.pageRss.ResumeLayout(false);
            this.pnlRssEnabled.ResumeLayout(false);
            this.pnlRssEnabled.PerformLayout();
            this.pageAbout.ResumeLayout(false);
            this.pageAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage pageBot;
        private System.Windows.Forms.TabPage pageHPicture;
        private System.Windows.Forms.CheckBox chkHPictureEnabled;
        private System.Windows.Forms.TabPage pageAbout;
        private System.Windows.Forms.Label lblContributorQQ;
        private System.Windows.Forms.Label lblContributorName;
        private System.Windows.Forms.TabPage pageSearchPicture;
        private System.Windows.Forms.CheckBox chkSearchPictureEnabled;
        private System.Windows.Forms.TabPage pageTranslate;
        private System.Windows.Forms.CheckBox chkTranslateEnabled;
        private System.Windows.Forms.Label lblContributorGithub;
        private System.Windows.Forms.TextBox txbContributorQQ;
        private System.Windows.Forms.LinkLabel lnkContributorGithub;
        private System.Windows.Forms.TextBox txbContributorName;
        private System.Windows.Forms.LinkLabel lnkProjectUrl;
        private System.Windows.Forms.Label lblProjectURL;
        private System.Windows.Forms.TabPage pageRepeater;
        private System.Windows.Forms.TabPage pageGroupMemberEvents;
        private System.Windows.Forms.TextBox txbMemberJoinedMessage;
        private System.Windows.Forms.CheckBox chkSendMemberBeKickedMessage;
        private System.Windows.Forms.CheckBox chkSendMemberPositiveLeaveMessage;
        private System.Windows.Forms.CheckBox chkSendMemberJoinedMessage;
        private System.Windows.Forms.TextBox txbMemberBeKickedMessage;
        private System.Windows.Forms.TextBox txbMemberPositiveLeaveMessage;
        private System.Windows.Forms.TabPage pageForgeMessage;
        private System.Windows.Forms.CheckBox chkEnabledForgeMessage;
        private System.Windows.Forms.TabPage pageRss;
        private System.Windows.Forms.CheckBox chkRssEnabled;
        private System.Windows.Forms.TabPage pageOriginalPicture;
        private System.Windows.Forms.CheckBox chkOriginalPictureEnabled;
        private System.Windows.Forms.Label lblContributorGroup;
        private LinkLabel lnkPluginsUrl;
        private Label lblPlugins;
        private LinkLabel lnkJoinGroup;
        private Panel pnlSearchPictureEnabled;
        private Panel pnlOriginalPictureEnabled;
        private Panel pnlHPictureEnabled;
        private Panel pnlTranslateEnabled;
        private Panel pnlForgeMessageEnabled;
        private Panel pnlRssEnabled;
        private Controls.CtrlSearchPicture pnlSearchPicture;
        private Controls.CtrlOriginalPicture pnlOriginalPicture;
        private Controls.CtrlHPicture pnlHPicture;
        private Controls.CtrlTranslate pnlTranslate;
        private Controls.CtrlRepeater ctrlRepeater1;
        private Controls.CtrlForgeMessage pnlForgeMessage;
        private Controls.CtrlRss pnlRss;
        private Controls.CtrlBot pnlBot;
        private Controls.CtrlRepeater pnlRepeater;
        private Button btnResetCtrlSize;
    }
}