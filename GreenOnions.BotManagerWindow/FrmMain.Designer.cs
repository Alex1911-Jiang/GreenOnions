
namespace GreenOnions.BotMainManagerWindow
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
            this.lblQQ = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblAutoKey = new System.Windows.Forms.Label();
            this.txbQQ = new System.Windows.Forms.MaskedTextBox();
            this.txbIP = new System.Windows.Forms.MaskedTextBox();
            this.txbPort = new System.Windows.Forms.MaskedTextBox();
            this.txbAutoKey = new System.Windows.Forms.MaskedTextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnBotSettings = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
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
            // lblAutoKey
            // 
            this.lblAutoKey.AutoSize = true;
            this.lblAutoKey.Location = new System.Drawing.Point(44, 117);
            this.lblAutoKey.Name = "lblAutoKey";
            this.lblAutoKey.Size = new System.Drawing.Size(59, 17);
            this.lblAutoKey.TabIndex = 0;
            this.lblAutoKey.Text = "AutoKey:";
            // 
            // txbQQ
            // 
            this.txbQQ.Location = new System.Drawing.Point(109, 27);
            this.txbQQ.Name = "txbQQ";
            this.txbQQ.Size = new System.Drawing.Size(281, 23);
            this.txbQQ.TabIndex = 1;
            this.txbQQ.Text = "3246934384";
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(109, 56);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(281, 23);
            this.txbIP.TabIndex = 1;
            this.txbIP.Text = "127.0.0.1";
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(109, 85);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(281, 23);
            this.txbPort.TabIndex = 1;
            this.txbPort.Text = "33111";
            // 
            // txbAutoKey
            // 
            this.txbAutoKey.Location = new System.Drawing.Point(109, 114);
            this.txbAutoKey.Name = "txbAutoKey";
            this.txbAutoKey.Size = new System.Drawing.Size(281, 23);
            this.txbAutoKey.TabIndex = 1;
            this.txbAutoKey.Text = "Alex1911";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(44, 170);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(170, 25);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接到mirai-api-http";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnBotSettings
            // 
            this.btnBotSettings.Location = new System.Drawing.Point(220, 170);
            this.btnBotSettings.Name = "btnBotSettings";
            this.btnBotSettings.Size = new System.Drawing.Size(170, 25);
            this.btnBotSettings.TabIndex = 2;
            this.btnBotSettings.Text = "机器人设置";
            this.btnBotSettings.UseVisualStyleBackColor = true;
            this.btnBotSettings.Click += new System.EventHandler(this.btnBotSettings_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Red;
            this.lblState.Location = new System.Drawing.Point(44, 140);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(191, 17);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "连接状态: 未连接到mirai-api-http";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 212);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnBotSettings);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txbAutoKey);
            this.Controls.Add(this.txbPort);
            this.Controls.Add(this.txbIP);
            this.Controls.Add(this.txbQQ);
            this.Controls.Add(this.lblAutoKey);
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
        private System.Windows.Forms.Label lblAutoKey;
        private System.Windows.Forms.MaskedTextBox txbQQ;
        private System.Windows.Forms.MaskedTextBox txbIP;
        private System.Windows.Forms.MaskedTextBox txbPort;
        private System.Windows.Forms.MaskedTextBox txbAutoKey;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnBotSettings;
        private System.Windows.Forms.Label lblState;
    }
}