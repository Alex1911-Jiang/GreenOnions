namespace GreenOnions.BotManagerWindows.Controls
{
    partial class CtrlForgeMessage
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
            this.SuspendLayout();
            // 
            // lblForgeMessageCmd
            // 
            this.lblForgeMessageCmd.AutoSize = true;
            this.lblForgeMessageCmd.Location = new System.Drawing.Point(18, 247);
            this.lblForgeMessageCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForgeMessageCmd.Name = "lblForgeMessageCmd";
            this.lblForgeMessageCmd.Size = new System.Drawing.Size(59, 17);
            this.lblForgeMessageCmd.TabIndex = 30;
            this.lblForgeMessageCmd.Text = "完整命令:";
            // 
            // txbForgeMessageCmd
            // 
            this.txbForgeMessageCmd.BackColor = System.Drawing.SystemColors.Control;
            this.txbForgeMessageCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbForgeMessageCmd.Location = new System.Drawing.Point(85, 245);
            this.txbForgeMessageCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txbForgeMessageCmd.Name = "txbForgeMessageCmd";
            this.txbForgeMessageCmd.ReadOnly = true;
            this.txbForgeMessageCmd.Size = new System.Drawing.Size(525, 23);
            this.txbForgeMessageCmd.TabIndex = 31;
            this.txbForgeMessageCmd.TextChanged += new System.EventHandler(this.txbForgeMessageCmd_TextChanged);
            // 
            // chkForgeMessageAdminDontAppend
            // 
            this.chkForgeMessageAdminDontAppend.AutoSize = true;
            this.chkForgeMessageAdminDontAppend.Location = new System.Drawing.Point(352, 67);
            this.chkForgeMessageAdminDontAppend.Margin = new System.Windows.Forms.Padding(4);
            this.chkForgeMessageAdminDontAppend.Name = "chkForgeMessageAdminDontAppend";
            this.chkForgeMessageAdminDontAppend.Size = new System.Drawing.Size(195, 21);
            this.chkForgeMessageAdminDontAppend.TabIndex = 25;
            this.chkForgeMessageAdminDontAppend.Text = "机器人管理员使用时不追加消息";
            this.chkForgeMessageAdminDontAppend.UseVisualStyleBackColor = true;
            // 
            // chkForgeMessageAdminOnly
            // 
            this.chkForgeMessageAdminOnly.AutoSize = true;
            this.chkForgeMessageAdminOnly.Location = new System.Drawing.Point(197, 67);
            this.chkForgeMessageAdminOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkForgeMessageAdminOnly.Name = "chkForgeMessageAdminOnly";
            this.chkForgeMessageAdminOnly.Size = new System.Drawing.Size(147, 21);
            this.chkForgeMessageAdminOnly.TabIndex = 23;
            this.chkForgeMessageAdminOnly.Text = "仅限机器人管理员可用";
            this.chkForgeMessageAdminOnly.UseVisualStyleBackColor = true;
            // 
            // chkRefuseForgeBot
            // 
            this.chkRefuseForgeBot.AutoSize = true;
            this.chkRefuseForgeBot.Location = new System.Drawing.Point(18, 187);
            this.chkRefuseForgeBot.Margin = new System.Windows.Forms.Padding(4);
            this.chkRefuseForgeBot.Name = "chkRefuseForgeBot";
            this.chkRefuseForgeBot.Size = new System.Drawing.Size(147, 21);
            this.chkRefuseForgeBot.TabIndex = 21;
            this.chkRefuseForgeBot.Text = "拒绝伪造机器人的消息";
            this.chkRefuseForgeBot.UseVisualStyleBackColor = true;
            this.chkRefuseForgeBot.CheckedChanged += new System.EventHandler(this.chkRefuseForgeBot_CheckedChanged);
            // 
            // chkRefuseForgeAdmin
            // 
            this.chkRefuseForgeAdmin.AutoSize = true;
            this.chkRefuseForgeAdmin.Location = new System.Drawing.Point(18, 126);
            this.chkRefuseForgeAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.chkRefuseForgeAdmin.Name = "chkRefuseForgeAdmin";
            this.chkRefuseForgeAdmin.Size = new System.Drawing.Size(183, 21);
            this.chkRefuseForgeAdmin.TabIndex = 29;
            this.chkRefuseForgeAdmin.Text = "拒绝伪造机器人管理员的消息";
            this.chkRefuseForgeAdmin.UseVisualStyleBackColor = true;
            this.chkRefuseForgeAdmin.CheckedChanged += new System.EventHandler(this.chkRefuseForgeAdmin_CheckedChanged);
            // 
            // lblRefuseForgeBotReply
            // 
            this.lblRefuseForgeBotReply.AutoSize = true;
            this.lblRefuseForgeBotReply.Location = new System.Drawing.Point(18, 218);
            this.lblRefuseForgeBotReply.Name = "lblRefuseForgeBotReply";
            this.lblRefuseForgeBotReply.Size = new System.Drawing.Size(179, 17);
            this.lblRefuseForgeBotReply.TabIndex = 19;
            this.lblRefuseForgeBotReply.Text = "试图伪造机器人消息时的回复语:";
            // 
            // chkForgeMessageAppendBotMessageEnabled
            // 
            this.chkForgeMessageAppendBotMessageEnabled.AutoSize = true;
            this.chkForgeMessageAppendBotMessageEnabled.Location = new System.Drawing.Point(18, 67);
            this.chkForgeMessageAppendBotMessageEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.chkForgeMessageAppendBotMessageEnabled.Name = "chkForgeMessageAppendBotMessageEnabled";
            this.chkForgeMessageAppendBotMessageEnabled.Size = new System.Drawing.Size(171, 21);
            this.chkForgeMessageAppendBotMessageEnabled.TabIndex = 22;
            this.chkForgeMessageAppendBotMessageEnabled.Text = "在消息末尾追加机器人消息";
            this.chkForgeMessageAppendBotMessageEnabled.UseVisualStyleBackColor = true;
            this.chkForgeMessageAppendBotMessageEnabled.CheckedChanged += new System.EventHandler(this.chkForgeMessageAppendBotMessageEnabled_CheckedChanged);
            // 
            // lblRefuseForgeAdminReply
            // 
            this.lblRefuseForgeAdminReply.AutoSize = true;
            this.lblRefuseForgeAdminReply.Location = new System.Drawing.Point(18, 157);
            this.lblRefuseForgeAdminReply.Name = "lblRefuseForgeAdminReply";
            this.lblRefuseForgeAdminReply.Size = new System.Drawing.Size(215, 17);
            this.lblRefuseForgeAdminReply.TabIndex = 20;
            this.lblRefuseForgeAdminReply.Text = "试图伪造机器人管理员消息时的回复语:";
            // 
            // txbRefuseForgeBotReply
            // 
            this.txbRefuseForgeBotReply.Enabled = false;
            this.txbRefuseForgeBotReply.Location = new System.Drawing.Point(239, 215);
            this.txbRefuseForgeBotReply.Name = "txbRefuseForgeBotReply";
            this.txbRefuseForgeBotReply.Size = new System.Drawing.Size(371, 23);
            this.txbRefuseForgeBotReply.TabIndex = 24;
            // 
            // lblForgeMessageAppendSelfMessage
            // 
            this.lblForgeMessageAppendSelfMessage.AutoSize = true;
            this.lblForgeMessageAppendSelfMessage.Location = new System.Drawing.Point(18, 99);
            this.lblForgeMessageAppendSelfMessage.Name = "lblForgeMessageAppendSelfMessage";
            this.lblForgeMessageAppendSelfMessage.Size = new System.Drawing.Size(83, 17);
            this.lblForgeMessageAppendSelfMessage.TabIndex = 18;
            this.lblForgeMessageAppendSelfMessage.Text = "追加消息内容:";
            // 
            // txbRefuseForgeAdminReply
            // 
            this.txbRefuseForgeAdminReply.Enabled = false;
            this.txbRefuseForgeAdminReply.Location = new System.Drawing.Point(239, 154);
            this.txbRefuseForgeAdminReply.Name = "txbRefuseForgeAdminReply";
            this.txbRefuseForgeAdminReply.Size = new System.Drawing.Size(371, 23);
            this.txbRefuseForgeAdminReply.TabIndex = 26;
            // 
            // txbForgeMessageAppendMessage
            // 
            this.txbForgeMessageAppendMessage.Enabled = false;
            this.txbForgeMessageAppendMessage.Location = new System.Drawing.Point(143, 96);
            this.txbForgeMessageAppendMessage.Name = "txbForgeMessageAppendMessage";
            this.txbForgeMessageAppendMessage.Size = new System.Drawing.Size(467, 23);
            this.txbForgeMessageAppendMessage.TabIndex = 27;
            // 
            // lblForgeMessageCmdNewLine
            // 
            this.lblForgeMessageCmdNewLine.AutoSize = true;
            this.lblForgeMessageCmdNewLine.Location = new System.Drawing.Point(18, 41);
            this.lblForgeMessageCmdNewLine.Name = "lblForgeMessageCmdNewLine";
            this.lblForgeMessageCmdNewLine.Size = new System.Drawing.Size(95, 17);
            this.lblForgeMessageCmdNewLine.TabIndex = 17;
            this.lblForgeMessageCmdNewLine.Text = "伪造消息分行符:";
            // 
            // txbForgeMessageCmdNewLine
            // 
            this.txbForgeMessageCmdNewLine.Location = new System.Drawing.Point(143, 38);
            this.txbForgeMessageCmdNewLine.Name = "txbForgeMessageCmdNewLine";
            this.txbForgeMessageCmdNewLine.Size = new System.Drawing.Size(467, 23);
            this.txbForgeMessageCmdNewLine.TabIndex = 28;
            // 
            // lblForgeMessageCmdBegin
            // 
            this.lblForgeMessageCmdBegin.AutoSize = true;
            this.lblForgeMessageCmdBegin.Location = new System.Drawing.Point(18, 12);
            this.lblForgeMessageCmdBegin.Name = "lblForgeMessageCmdBegin";
            this.lblForgeMessageCmdBegin.Size = new System.Drawing.Size(107, 17);
            this.lblForgeMessageCmdBegin.TabIndex = 15;
            this.lblForgeMessageCmdBegin.Text = "伪造消息命令前缀:";
            // 
            // txbForgeMessageCmdBegin
            // 
            this.txbForgeMessageCmdBegin.Location = new System.Drawing.Point(143, 9);
            this.txbForgeMessageCmdBegin.Name = "txbForgeMessageCmdBegin";
            this.txbForgeMessageCmdBegin.Size = new System.Drawing.Size(467, 23);
            this.txbForgeMessageCmdBegin.TabIndex = 16;
            // 
            // CtrlForgeMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblForgeMessageCmd);
            this.Controls.Add(this.txbForgeMessageCmd);
            this.Controls.Add(this.chkForgeMessageAdminDontAppend);
            this.Controls.Add(this.chkForgeMessageAdminOnly);
            this.Controls.Add(this.chkRefuseForgeBot);
            this.Controls.Add(this.chkRefuseForgeAdmin);
            this.Controls.Add(this.lblRefuseForgeBotReply);
            this.Controls.Add(this.chkForgeMessageAppendBotMessageEnabled);
            this.Controls.Add(this.lblRefuseForgeAdminReply);
            this.Controls.Add(this.txbRefuseForgeBotReply);
            this.Controls.Add(this.lblForgeMessageAppendSelfMessage);
            this.Controls.Add(this.txbRefuseForgeAdminReply);
            this.Controls.Add(this.txbForgeMessageAppendMessage);
            this.Controls.Add(this.lblForgeMessageCmdNewLine);
            this.Controls.Add(this.txbForgeMessageCmdNewLine);
            this.Controls.Add(this.lblForgeMessageCmdBegin);
            this.Controls.Add(this.txbForgeMessageCmdBegin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CtrlForgeMessage";
            this.Size = new System.Drawing.Size(630, 642);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblForgeMessageCmd;
        private TextBox txbForgeMessageCmd;
        private CheckBox chkForgeMessageAdminDontAppend;
        private CheckBox chkForgeMessageAdminOnly;
        private CheckBox chkRefuseForgeBot;
        private CheckBox chkRefuseForgeAdmin;
        private Label lblRefuseForgeBotReply;
        private CheckBox chkForgeMessageAppendBotMessageEnabled;
        private Label lblRefuseForgeAdminReply;
        private TextBox txbRefuseForgeBotReply;
        private Label lblForgeMessageAppendSelfMessage;
        private TextBox txbRefuseForgeAdminReply;
        private TextBox txbForgeMessageAppendMessage;
        private Label lblForgeMessageCmdNewLine;
        private TextBox txbForgeMessageCmdNewLine;
        private Label lblForgeMessageCmdBegin;
        private TextBox txbForgeMessageCmdBegin;
    }
}
