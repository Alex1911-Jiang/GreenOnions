
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
            this.btnConnectToCqHttp = new System.Windows.Forms.Button();
            this.btnPlugins = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQQ
            // 
            this.lblQQ.AutoSize = true;
            this.lblQQ.Location = new System.Drawing.Point(44, 30);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(43, 17);
            this.lblQQ.TabIndex = 0;
            this.lblQQ.Text = "QQ号:";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(44, 59);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(47, 17);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "地址号:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(44, 88);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(47, 17);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "端口号:";
            // 
            // lblVerifyKey
            // 
            this.lblVerifyKey.AutoSize = true;
            this.lblVerifyKey.Location = new System.Drawing.Point(44, 117);
            this.lblVerifyKey.Name = "lblVerifyKey";
            this.lblVerifyKey.Size = new System.Drawing.Size(158, 17);
            this.lblVerifyKey.TabIndex = 0;
            this.lblVerifyKey.Text = "VerifyKey / Access-Token:";
            // 
            // txbQQ
            // 
            this.txbQQ.Location = new System.Drawing.Point(115, 27);
            this.txbQQ.Name = "txbQQ";
            this.txbQQ.Size = new System.Drawing.Size(275, 23);
            this.txbQQ.TabIndex = 1;
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(115, 56);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(275, 23);
            this.txbIP.TabIndex = 2;
            this.txbIP.Text = "127.0.0.1";
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(115, 85);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(275, 23);
            this.txbPort.TabIndex = 3;
            this.txbPort.Text = "33111";
            // 
            // txbVerifyKey
            // 
            this.txbVerifyKey.Location = new System.Drawing.Point(204, 114);
            this.txbVerifyKey.Name = "txbVerifyKey";
            this.txbVerifyKey.Size = new System.Drawing.Size(186, 23);
            this.txbVerifyKey.TabIndex = 4;
            // 
            // btnConnectToMiraiApiHttp
            // 
            this.btnConnectToMiraiApiHttp.Location = new System.Drawing.Point(44, 170);
            this.btnConnectToMiraiApiHttp.Name = "btnConnectToMiraiApiHttp";
            this.btnConnectToMiraiApiHttp.Size = new System.Drawing.Size(170, 25);
            this.btnConnectToMiraiApiHttp.TabIndex = 5;
            this.btnConnectToMiraiApiHttp.Text = "连接到mirai-api-http";
            this.btnConnectToMiraiApiHttp.UseVisualStyleBackColor = true;
            this.btnConnectToMiraiApiHttp.Click += new System.EventHandler(this.btnConnectToMiraiApiHttp_Click);
            // 
            // btnBotSettings
            // 
            this.btnBotSettings.Location = new System.Drawing.Point(44, 201);
            this.btnBotSettings.Name = "btnBotSettings";
            this.btnBotSettings.Size = new System.Drawing.Size(170, 25);
            this.btnBotSettings.TabIndex = 7;
            this.btnBotSettings.Text = "机器人设置";
            this.btnBotSettings.UseVisualStyleBackColor = true;
            this.btnBotSettings.Click += new System.EventHandler(this.btnBotSettings_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Red;
            this.lblState.Location = new System.Drawing.Point(43, 143);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(171, 17);
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
            this.chkMinimizeToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Checked = true;
            this.chkMinimizeToTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinimizeToTray.Location = new System.Drawing.Point(334, 0);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.Size = new System.Drawing.Size(99, 21);
            this.chkMinimizeToTray.TabIndex = 0;
            this.chkMinimizeToTray.Text = "最小化到托盘";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // btnConnectToCqHttp
            // 
            this.btnConnectToCqHttp.Location = new System.Drawing.Point(220, 170);
            this.btnConnectToCqHttp.Name = "btnConnectToCqHttp";
            this.btnConnectToCqHttp.Size = new System.Drawing.Size(170, 25);
            this.btnConnectToCqHttp.TabIndex = 6;
            this.btnConnectToCqHttp.Text = "连接到cqhttp";
            this.btnConnectToCqHttp.UseVisualStyleBackColor = true;
            this.btnConnectToCqHttp.Click += new System.EventHandler(this.btnConnectToCqHttp_Click);
            // 
            // btnPlugins
            // 
            this.btnPlugins.Location = new System.Drawing.Point(220, 201);
            this.btnPlugins.Name = "btnPlugins";
            this.btnPlugins.Size = new System.Drawing.Size(170, 25);
            this.btnPlugins.TabIndex = 8;
            this.btnPlugins.Text = "插件列表(0)";
            this.btnPlugins.UseVisualStyleBackColor = true;
            this.btnPlugins.Click += new System.EventHandler(this.btnPlugins_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 249);
            this.Controls.Add(this.btnPlugins);
            this.Controls.Add(this.btnConnectToCqHttp);
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
        private System.Windows.Forms.Button btnConnectToCqHttp;
        private System.Windows.Forms.Button btnPlugins;
        private System.Windows.Forms.Label lblPluginMessage;
    }
}