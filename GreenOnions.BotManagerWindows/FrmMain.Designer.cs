
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            lblQQ = new Label();
            lblIP = new Label();
            lblPort = new Label();
            lblVerifyKey = new Label();
            txbQQ = new MaskedTextBox();
            txbIP = new MaskedTextBox();
            txbPort = new MaskedTextBox();
            txbVerifyKey = new MaskedTextBox();
            btnConnectToMiraiApiHttp = new Button();
            btnBotSettings = new Button();
            lblState = new Label();
            notifyIcon = new NotifyIcon(components);
            chkMinimizeToTray = new CheckBox();
            btnConnectToOneBot = new Button();
            btnPlugins = new Button();
            btnConnectToOicq = new Button();
            btnKonata = new Button();
            btnConnectToGoCqhttp = new Button();
            SuspendLayout();
            // 
            // lblQQ
            // 
            lblQQ.AutoSize = true;
            lblQQ.Location = new Point(44, 30);
            lblQQ.Name = "lblQQ";
            lblQQ.Size = new Size(43, 17);
            lblQQ.TabIndex = 0;
            lblQQ.Text = "QQ号:";
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Location = new Point(44, 59);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(47, 17);
            lblIP.TabIndex = 0;
            lblIP.Text = "地址号:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(44, 88);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(47, 17);
            lblPort.TabIndex = 0;
            lblPort.Text = "端口号:";
            // 
            // lblVerifyKey
            // 
            lblVerifyKey.AutoSize = true;
            lblVerifyKey.Location = new Point(44, 117);
            lblVerifyKey.Name = "lblVerifyKey";
            lblVerifyKey.Size = new Size(158, 17);
            lblVerifyKey.TabIndex = 0;
            lblVerifyKey.Text = "VerifyKey / Access-Token:";
            // 
            // txbQQ
            // 
            txbQQ.Location = new Point(115, 27);
            txbQQ.Name = "txbQQ";
            txbQQ.Size = new Size(275, 23);
            txbQQ.TabIndex = 1;
            // 
            // txbIP
            // 
            txbIP.Location = new Point(115, 56);
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(275, 23);
            txbIP.TabIndex = 2;
            txbIP.Text = "127.0.0.1";
            // 
            // txbPort
            // 
            txbPort.Location = new Point(115, 85);
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(275, 23);
            txbPort.TabIndex = 3;
            txbPort.Text = "33111";
            // 
            // txbVerifyKey
            // 
            txbVerifyKey.Location = new Point(204, 114);
            txbVerifyKey.Name = "txbVerifyKey";
            txbVerifyKey.Size = new Size(186, 23);
            txbVerifyKey.TabIndex = 4;
            // 
            // btnConnectToMiraiApiHttp
            // 
            btnConnectToMiraiApiHttp.Enabled = false;
            btnConnectToMiraiApiHttp.Location = new Point(44, 170);
            btnConnectToMiraiApiHttp.Name = "btnConnectToMiraiApiHttp";
            btnConnectToMiraiApiHttp.Size = new Size(170, 25);
            btnConnectToMiraiApiHttp.TabIndex = 5;
            btnConnectToMiraiApiHttp.Text = "连接到mirai-api-http";
            btnConnectToMiraiApiHttp.UseVisualStyleBackColor = true;
            btnConnectToMiraiApiHttp.Click += btnConnectToMiraiApiHttp_Click;
            // 
            // btnBotSettings
            // 
            btnBotSettings.Location = new Point(219, 201);
            btnBotSettings.Name = "btnBotSettings";
            btnBotSettings.Size = new Size(170, 25);
            btnBotSettings.TabIndex = 7;
            btnBotSettings.Text = "机器人设置";
            btnBotSettings.UseVisualStyleBackColor = true;
            btnBotSettings.Click += btnBotSettings_Click;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.ForeColor = Color.Red;
            lblState.Location = new Point(43, 143);
            lblState.Name = "lblState";
            lblState.Size = new Size(171, 17);
            lblState.TabIndex = 3;
            lblState.Text = "连接状态: 未连接到机器人平台";
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "葱葱机器人";
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // chkMinimizeToTray
            // 
            chkMinimizeToTray.AutoSize = true;
            chkMinimizeToTray.Checked = true;
            chkMinimizeToTray.CheckState = CheckState.Checked;
            chkMinimizeToTray.Location = new Point(334, 0);
            chkMinimizeToTray.Name = "chkMinimizeToTray";
            chkMinimizeToTray.Size = new Size(99, 21);
            chkMinimizeToTray.TabIndex = 0;
            chkMinimizeToTray.Text = "最小化到托盘";
            chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // btnConnectToOneBot
            // 
            btnConnectToOneBot.Enabled = false;
            btnConnectToOneBot.Location = new Point(44, 201);
            btnConnectToOneBot.Name = "btnConnectToOneBot";
            btnConnectToOneBot.Size = new Size(170, 25);
            btnConnectToOneBot.TabIndex = 6;
            btnConnectToOneBot.Text = "连接到OneBot";
            btnConnectToOneBot.UseVisualStyleBackColor = true;
            btnConnectToOneBot.Click += btnConnectToOneBot_Click;
            // 
            // btnPlugins
            // 
            btnPlugins.Location = new Point(44, 231);
            btnPlugins.Name = "btnPlugins";
            btnPlugins.Size = new Size(345, 25);
            btnPlugins.TabIndex = 8;
            btnPlugins.Text = "插件列表(正在加载)";
            btnPlugins.UseVisualStyleBackColor = true;
            btnPlugins.Click += btnPlugins_Click;
            // 
            // btnConnectToOicq
            // 
            btnConnectToOicq.Location = new Point(11, 3);
            btnConnectToOicq.Margin = new Padding(2);
            btnConnectToOicq.Name = "btnConnectToOicq";
            btnConnectToOicq.Size = new Size(71, 24);
            btnConnectToOicq.TabIndex = 10;
            btnConnectToOicq.Text = "Oicq";
            btnConnectToOicq.UseVisualStyleBackColor = true;
            btnConnectToOicq.Visible = false;
            btnConnectToOicq.Click += btnConnectToOicq_Click;
            // 
            // btnKonata
            // 
            btnKonata.Location = new Point(86, 3);
            btnKonata.Margin = new Padding(2);
            btnKonata.Name = "btnKonata";
            btnKonata.Size = new Size(71, 24);
            btnKonata.TabIndex = 11;
            btnKonata.Text = "Konata";
            btnKonata.UseVisualStyleBackColor = true;
            btnKonata.Visible = false;
            btnKonata.Click += btnKonata_Click;
            // 
            // btnConnectToGoCqhttp
            // 
            btnConnectToGoCqhttp.Enabled = false;
            btnConnectToGoCqhttp.Location = new Point(219, 170);
            btnConnectToGoCqhttp.Name = "btnConnectToGoCqhttp";
            btnConnectToGoCqhttp.Size = new Size(170, 25);
            btnConnectToGoCqhttp.TabIndex = 12;
            btnConnectToGoCqhttp.Text = "连接到go-cqhttp";
            btnConnectToGoCqhttp.UseVisualStyleBackColor = true;
            btnConnectToGoCqhttp.Click += btnConnectToGoCqhttp_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 268);
            Controls.Add(btnConnectToGoCqhttp);
            Controls.Add(btnKonata);
            Controls.Add(btnConnectToOicq);
            Controls.Add(btnPlugins);
            Controls.Add(btnConnectToOneBot);
            Controls.Add(chkMinimizeToTray);
            Controls.Add(lblState);
            Controls.Add(btnBotSettings);
            Controls.Add(btnConnectToMiraiApiHttp);
            Controls.Add(txbVerifyKey);
            Controls.Add(txbPort);
            Controls.Add(txbIP);
            Controls.Add(txbQQ);
            Controls.Add(lblVerifyKey);
            Controls.Add(lblPort);
            Controls.Add(lblIP);
            Controls.Add(lblQQ);
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "葱葱机器人主窗口";
            ResumeLayout(false);
            PerformLayout();
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
        private Button btnConnectToOicq;
        private Button btnKonata;
        private Button btnConnectToGoCqhttp;
    }
}