
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
            this.txbQQ = new System.Windows.Forms.MaskedTextBox();
            this.txbIP = new System.Windows.Forms.MaskedTextBox();
            this.txbPort = new System.Windows.Forms.MaskedTextBox();
            this.txbVerifyKey = new System.Windows.Forms.MaskedTextBox();
            this.btnConnectToMiraiApiHttp = new System.Windows.Forms.Button();
            this.btnBotSettings = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.btnConnectToOneBot = new System.Windows.Forms.Button();
            this.btnPlugins = new System.Windows.Forms.Button();
            this.btnConnectToKnife = new System.Windows.Forms.Button();
            this.btnConnectToOicq = new System.Windows.Forms.Button();
            this.btnKonata = new System.Windows.Forms.Button();
            this.btnConnectToGoCqhttp = new System.Windows.Forms.Button();
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
            this.lblIP.Location = new System.Drawing.Point(69, 83);
            this.lblIP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(68, 24);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "地址号:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(69, 124);
            this.lblPort.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(68, 24);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "端口号:";
            // 
            // lblVerifyKey
            // 
            this.lblVerifyKey.AutoSize = true;
            this.lblVerifyKey.Location = new System.Drawing.Point(69, 165);
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
            this.txbIP.Location = new System.Drawing.Point(181, 79);
            this.txbIP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(430, 30);
            this.txbIP.TabIndex = 2;
            this.txbIP.Text = "127.0.0.1";
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(181, 120);
            this.txbPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(430, 30);
            this.txbPort.TabIndex = 3;
            this.txbPort.Text = "33111";
            // 
            // txbVerifyKey
            // 
            this.txbVerifyKey.Location = new System.Drawing.Point(321, 161);
            this.txbVerifyKey.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbVerifyKey.Name = "txbVerifyKey";
            this.txbVerifyKey.Size = new System.Drawing.Size(290, 30);
            this.txbVerifyKey.TabIndex = 4;
            // 
            // btnConnectToMiraiApiHttp
            // 
            this.btnConnectToMiraiApiHttp.Enabled = false;
            this.btnConnectToMiraiApiHttp.Location = new System.Drawing.Point(69, 240);
            this.btnConnectToMiraiApiHttp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConnectToMiraiApiHttp.Name = "btnConnectToMiraiApiHttp";
            this.btnConnectToMiraiApiHttp.Size = new System.Drawing.Size(267, 35);
            this.btnConnectToMiraiApiHttp.TabIndex = 5;
            this.btnConnectToMiraiApiHttp.Text = "连接到mirai-api-http";
            this.btnConnectToMiraiApiHttp.UseVisualStyleBackColor = true;
            this.btnConnectToMiraiApiHttp.Click += new System.EventHandler(this.btnConnectToMiraiApiHttp_Click);
            // 
            // btnBotSettings
            // 
            this.btnBotSettings.Location = new System.Drawing.Point(68, 283);
            this.btnBotSettings.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBotSettings.Name = "btnBotSettings";
            this.btnBotSettings.Size = new System.Drawing.Size(267, 35);
            this.btnBotSettings.TabIndex = 7;
            this.btnBotSettings.Text = "机器人设置";
            this.btnBotSettings.UseVisualStyleBackColor = true;
            this.btnBotSettings.Click += new System.EventHandler(this.btnBotSettings_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Red;
            this.lblState.Location = new System.Drawing.Point(68, 202);
            this.lblState.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(253, 24);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "连接状态: 未连接到机器人平台";
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
            // btnConnectToOneBot
            // 
            this.btnConnectToOneBot.Enabled = false;
            this.btnConnectToOneBot.Location = new System.Drawing.Point(345, 240);
            this.btnConnectToOneBot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConnectToOneBot.Name = "btnConnectToOneBot";
            this.btnConnectToOneBot.Size = new System.Drawing.Size(266, 35);
            this.btnConnectToOneBot.TabIndex = 6;
            this.btnConnectToOneBot.Text = "连接到OneBot";
            this.btnConnectToOneBot.UseVisualStyleBackColor = true;
            this.btnConnectToOneBot.Click += new System.EventHandler(this.btnConnectToOneBot_Click);
            // 
            // btnPlugins
            // 
            this.btnPlugins.Location = new System.Drawing.Point(345, 283);
            this.btnPlugins.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPlugins.Name = "btnPlugins";
            this.btnPlugins.Size = new System.Drawing.Size(267, 35);
            this.btnPlugins.TabIndex = 8;
            this.btnPlugins.Text = "插件列表(正在加载)";
            this.btnPlugins.UseVisualStyleBackColor = true;
            this.btnPlugins.Click += new System.EventHandler(this.btnPlugins_Click);
            // 
            // btnConnectToKnife
            // 
            this.btnConnectToKnife.Location = new System.Drawing.Point(3, 4);
            this.btnConnectToKnife.Name = "btnConnectToKnife";
            this.btnConnectToKnife.Size = new System.Drawing.Size(72, 35);
            this.btnConnectToKnife.TabIndex = 9;
            this.btnConnectToKnife.Text = "Knife";
            this.btnConnectToKnife.UseVisualStyleBackColor = true;
            this.btnConnectToKnife.Visible = false;
            this.btnConnectToKnife.Click += new System.EventHandler(this.btnConnectToKnife_Click);
            // 
            // btnConnectToOicq
            // 
            this.btnConnectToOicq.Location = new System.Drawing.Point(81, 4);
            this.btnConnectToOicq.Name = "btnConnectToOicq";
            this.btnConnectToOicq.Size = new System.Drawing.Size(112, 34);
            this.btnConnectToOicq.TabIndex = 10;
            this.btnConnectToOicq.Text = "Oicq";
            this.btnConnectToOicq.UseVisualStyleBackColor = true;
            this.btnConnectToOicq.Visible = false;
            this.btnConnectToOicq.Click += new System.EventHandler(this.btnConnectToOicq_Click);
            // 
            // btnKonata
            // 
            this.btnKonata.Location = new System.Drawing.Point(199, 4);
            this.btnKonata.Name = "btnKonata";
            this.btnKonata.Size = new System.Drawing.Size(112, 34);
            this.btnKonata.TabIndex = 11;
            this.btnKonata.Text = "Konata";
            this.btnKonata.UseVisualStyleBackColor = true;
            this.btnKonata.Visible = false;
            this.btnKonata.Click += new System.EventHandler(this.btnKonata_Click);
            // 
            // btnConnectToGoCqhttp
            // 
            this.btnConnectToGoCqhttp.Enabled = false;
            this.btnConnectToGoCqhttp.Location = new System.Drawing.Point(345, 197);
            this.btnConnectToGoCqhttp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConnectToGoCqhttp.Name = "btnConnectToGoCqhttp";
            this.btnConnectToGoCqhttp.Size = new System.Drawing.Size(267, 35);
            this.btnConnectToGoCqhttp.TabIndex = 12;
            this.btnConnectToGoCqhttp.Text = "连接到go-cqhttp";
            this.btnConnectToGoCqhttp.UseVisualStyleBackColor = true;
            this.btnConnectToGoCqhttp.Visible = false;
            this.btnConnectToGoCqhttp.Click += new System.EventHandler(this.btnConnectToGoCqhttp_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 337);
            this.Controls.Add(this.btnConnectToGoCqhttp);
            this.Controls.Add(this.btnKonata);
            this.Controls.Add(this.btnConnectToOicq);
            this.Controls.Add(this.btnConnectToKnife);
            this.Controls.Add(this.btnPlugins);
            this.Controls.Add(this.btnConnectToOneBot);
            this.Controls.Add(this.chkMinimizeToTray);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnBotSettings);
            this.Controls.Add(this.btnConnectToMiraiApiHttp);
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
        private System.Windows.Forms.MaskedTextBox txbQQ;
        private System.Windows.Forms.MaskedTextBox txbIP;
        private System.Windows.Forms.MaskedTextBox txbPort;
        private System.Windows.Forms.MaskedTextBox txbVerifyKey;
        private System.Windows.Forms.Button btnConnectToMiraiApiHttp;
        private System.Windows.Forms.Button btnBotSettings;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.Button btnConnectToOneBot;
        private System.Windows.Forms.Button btnPlugins;
        private Button btnConnectToKnife;
        private Button btnConnectToOicq;
        private Button btnKonata;
        private Button btnConnectToGoCqhttp;
    }
}