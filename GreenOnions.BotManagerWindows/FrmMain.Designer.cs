
namespace GreenOnions.BotManagerWindows
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblQQ = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblVerifyKey = new System.Windows.Forms.Label();
            this.txbQQ = new System.Windows.Forms.TextBox();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.txbVerifyKey = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnBotSettings = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.btnPlugins = new System.Windows.Forms.Button();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.rdoMiraiApiHttp = new System.Windows.Forms.RadioButton();
            this.rdoOneBot = new System.Windows.Forms.RadioButton();
            this.rdoKonata = new System.Windows.Forms.RadioButton();
            this.lblConnectProtocol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQQ
            // 
            this.lblQQ.AutoSize = true;
            this.lblQQ.Location = new System.Drawing.Point(69, 42);
            this.lblQQ.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(62, 24);
            this.lblQQ.TabIndex = 0;
            this.lblQQ.Text = "QQ号:";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(69, 121);
            this.lblIP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(68, 24);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "地址号:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(69, 159);
            this.lblPort.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(68, 24);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "端口号:";
            // 
            // lblVerifyKey
            // 
            this.lblVerifyKey.AutoSize = true;
            this.lblVerifyKey.Location = new System.Drawing.Point(69, 200);
            this.lblVerifyKey.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVerifyKey.Name = "lblVerifyKey";
            this.lblVerifyKey.Size = new System.Drawing.Size(230, 24);
            this.lblVerifyKey.TabIndex = 0;
            this.lblVerifyKey.Text = "VerifyKey / Access-Token:";
            // 
            // txbQQ
            // 
            this.txbQQ.Location = new System.Drawing.Point(181, 38);
            this.txbQQ.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbQQ.Name = "txbQQ";
            this.txbQQ.Size = new System.Drawing.Size(430, 30);
            this.txbQQ.TabIndex = 1;
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(181, 117);
            this.txbIP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(430, 30);
            this.txbIP.TabIndex = 2;
            this.txbIP.Text = "127.0.0.1";
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(181, 155);
            this.txbPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(430, 30);
            this.txbPort.TabIndex = 3;
            this.txbPort.Text = "33111";
            // 
            // txbVerifyKey
            // 
            this.txbVerifyKey.Location = new System.Drawing.Point(321, 196);
            this.txbVerifyKey.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbVerifyKey.Name = "txbVerifyKey";
            this.txbVerifyKey.Size = new System.Drawing.Size(290, 30);
            this.txbVerifyKey.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(69, 328);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(542, 35);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "连接/登录";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnBotSettings
            // 
            this.btnBotSettings.Location = new System.Drawing.Point(69, 372);
            this.btnBotSettings.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBotSettings.Name = "btnBotSettings";
            this.btnBotSettings.Size = new System.Drawing.Size(542, 35);
            this.btnBotSettings.TabIndex = 7;
            this.btnBotSettings.Text = "机器人设置";
            this.btnBotSettings.UseVisualStyleBackColor = true;
            this.btnBotSettings.Click += new System.EventHandler(this.btnBotSettings_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Red;
            this.lblState.Location = new System.Drawing.Point(69, 300);
            this.lblState.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(315, 24);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "连接状态: 未连接到机器人平台/未登录";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "葱葱机器人";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // chkMinimizeToTray
            // 
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Checked = true;
            this.chkMinimizeToTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinimizeToTray.Location = new System.Drawing.Point(525, 0);
            this.chkMinimizeToTray.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.Size = new System.Drawing.Size(144, 28);
            this.chkMinimizeToTray.TabIndex = 0;
            this.chkMinimizeToTray.Text = "最小化到托盘";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // btnPlugins
            // 
            this.btnPlugins.Location = new System.Drawing.Point(69, 415);
            this.btnPlugins.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPlugins.Name = "btnPlugins";
            this.btnPlugins.Size = new System.Drawing.Size(542, 35);
            this.btnPlugins.TabIndex = 8;
            this.btnPlugins.Text = "插件列表(0)";
            this.btnPlugins.UseVisualStyleBackColor = true;
            this.btnPlugins.Click += new System.EventHandler(this.btnPlugins_Click);
            // 
            // txbPassword
            // 
            this.txbPassword.Enabled = false;
            this.txbPassword.Location = new System.Drawing.Point(181, 76);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(430, 30);
            this.txbPassword.TabIndex = 10;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(69, 80);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 24);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "密   码:";
            // 
            // rdoMiraiApiHttp
            // 
            this.rdoMiraiApiHttp.AutoSize = true;
            this.rdoMiraiApiHttp.Location = new System.Drawing.Point(69, 265);
            this.rdoMiraiApiHttp.Name = "rdoMiraiApiHttp";
            this.rdoMiraiApiHttp.Size = new System.Drawing.Size(159, 28);
            this.rdoMiraiApiHttp.TabIndex = 11;
            this.rdoMiraiApiHttp.TabStop = true;
            this.rdoMiraiApiHttp.Text = "mirai-api-http";
            this.rdoMiraiApiHttp.UseVisualStyleBackColor = true;
            this.rdoMiraiApiHttp.CheckedChanged += new System.EventHandler(this.rdoProtocol_CheckedChanged);
            // 
            // rdoOneBot
            // 
            this.rdoOneBot.AutoSize = true;
            this.rdoOneBot.Location = new System.Drawing.Point(262, 265);
            this.rdoOneBot.Name = "rdoOneBot";
            this.rdoOneBot.Size = new System.Drawing.Size(176, 28);
            this.rdoOneBot.TabIndex = 12;
            this.rdoOneBot.TabStop = true;
            this.rdoOneBot.Text = "OneBot(CqHttp)";
            this.rdoOneBot.UseVisualStyleBackColor = true;
            this.rdoOneBot.CheckedChanged += new System.EventHandler(this.rdoProtocol_CheckedChanged);
            // 
            // rdoKonata
            // 
            this.rdoKonata.AutoSize = true;
            this.rdoKonata.Location = new System.Drawing.Point(472, 265);
            this.rdoKonata.Name = "rdoKonata";
            this.rdoKonata.Size = new System.Drawing.Size(139, 28);
            this.rdoKonata.TabIndex = 13;
            this.rdoKonata.TabStop = true;
            this.rdoKonata.Text = "Konata.Core";
            this.rdoKonata.UseVisualStyleBackColor = true;
            this.rdoKonata.CheckedChanged += new System.EventHandler(this.rdoProtocol_CheckedChanged);
            // 
            // lblConnectProtocol
            // 
            this.lblConnectProtocol.AutoSize = true;
            this.lblConnectProtocol.Location = new System.Drawing.Point(69, 238);
            this.lblConnectProtocol.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConnectProtocol.Name = "lblConnectProtocol";
            this.lblConnectProtocol.Size = new System.Drawing.Size(176, 24);
            this.lblConnectProtocol.TabIndex = 14;
            this.lblConnectProtocol.Text = "连接到的机器人平台:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 468);
            this.Controls.Add(this.lblConnectProtocol);
            this.Controls.Add(this.rdoKonata);
            this.Controls.Add(this.rdoOneBot);
            this.Controls.Add(this.rdoMiraiApiHttp);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnPlugins);
            this.Controls.Add(this.chkMinimizeToTray);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnBotSettings);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txbVerifyKey);
            this.Controls.Add(this.txbPort);
            this.Controls.Add(this.txbIP);
            this.Controls.Add(this.txbQQ);
            this.Controls.Add(this.lblVerifyKey);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblQQ);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "葱葱机器人主窗口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQQ;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblVerifyKey;
        private System.Windows.Forms.TextBox txbQQ;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.TextBox txbVerifyKey;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnBotSettings;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.Button btnPlugins;
        private TextBox txbPassword;
        private Label lblPassword;
        private RadioButton rdoMiraiApiHttp;
        private RadioButton rdoOneBot;
        private RadioButton rdoKonata;
        private Label lblConnectProtocol;
    }
}