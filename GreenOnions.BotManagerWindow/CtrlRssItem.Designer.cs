namespace GreenOnions.BotManagerWindow
{
    partial class CtrlRssItem
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
            if (disposing && (components != null))
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
            this.lblRssSubscriptionUrl = new System.Windows.Forms.Label();
            this.txbRssSubscriptionUrl = new System.Windows.Forms.TextBox();
            this.lblRssForwardGroup = new System.Windows.Forms.Label();
            this.lblRssForwardQQ = new System.Windows.Forms.Label();
            this.chkRssTranslate = new System.Windows.Forms.CheckBox();
            this.txbRssForwardGroups = new System.Windows.Forms.TextBox();
            this.txbRssForwardQQs = new System.Windows.Forms.TextBox();
            this.btnRssRemoveItem = new System.Windows.Forms.Button();
            this.txbRssRemark = new System.Windows.Forms.TextBox();
            this.lblRssRemark = new System.Windows.Forms.Label();
            this.chkRssSendByForward = new System.Windows.Forms.CheckBox();
            this.pnlTranslateFromTo = new System.Windows.Forms.Panel();
            this.lblTranslateTo = new System.Windows.Forms.Label();
            this.lblTranslateFrom = new System.Windows.Forms.Label();
            this.cboTranslateTo = new System.Windows.Forms.ComboBox();
            this.cboTranslateFrom = new System.Windows.Forms.ComboBox();
            this.chkTranslateFromTo = new System.Windows.Forms.CheckBox();
            this.chkRssAtAll = new System.Windows.Forms.CheckBox();
            this.pnlTranslateFromTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRssSubscriptionUrl
            // 
            this.lblRssSubscriptionUrl.AutoSize = true;
            this.lblRssSubscriptionUrl.Location = new System.Drawing.Point(17, 6);
            this.lblRssSubscriptionUrl.Name = "lblRssSubscriptionUrl";
            this.lblRssSubscriptionUrl.Size = new System.Drawing.Size(59, 17);
            this.lblRssSubscriptionUrl.TabIndex = 0;
            this.lblRssSubscriptionUrl.Text = "订阅地址:";
            // 
            // txbRssSubscriptionUrl
            // 
            this.txbRssSubscriptionUrl.Location = new System.Drawing.Point(82, 3);
            this.txbRssSubscriptionUrl.Name = "txbRssSubscriptionUrl";
            this.txbRssSubscriptionUrl.Size = new System.Drawing.Size(427, 23);
            this.txbRssSubscriptionUrl.TabIndex = 1;
            // 
            // lblRssForwardGroup
            // 
            this.lblRssForwardGroup.AutoSize = true;
            this.lblRssForwardGroup.Location = new System.Drawing.Point(17, 83);
            this.lblRssForwardGroup.Name = "lblRssForwardGroup";
            this.lblRssForwardGroup.Size = new System.Drawing.Size(59, 17);
            this.lblRssForwardGroup.TabIndex = 2;
            this.lblRssForwardGroup.Text = "转发群组:";
            // 
            // lblRssForwardQQ
            // 
            this.lblRssForwardQQ.AutoSize = true;
            this.lblRssForwardQQ.Location = new System.Drawing.Point(268, 83);
            this.lblRssForwardQQ.Name = "lblRssForwardQQ";
            this.lblRssForwardQQ.Size = new System.Drawing.Size(55, 17);
            this.lblRssForwardQQ.TabIndex = 2;
            this.lblRssForwardQQ.Text = "转发QQ:";
            // 
            // chkRssTranslate
            // 
            this.chkRssTranslate.AutoSize = true;
            this.chkRssTranslate.Location = new System.Drawing.Point(17, 125);
            this.chkRssTranslate.Name = "chkRssTranslate";
            this.chkRssTranslate.Size = new System.Drawing.Size(51, 21);
            this.chkRssTranslate.TabIndex = 3;
            this.chkRssTranslate.Text = "翻译";
            this.chkRssTranslate.UseVisualStyleBackColor = true;
            this.chkRssTranslate.CheckedChanged += new System.EventHandler(this.chkRssTranslate_CheckedChanged);
            // 
            // txbRssForwardGroups
            // 
            this.txbRssForwardGroups.Location = new System.Drawing.Point(82, 61);
            this.txbRssForwardGroups.Multiline = true;
            this.txbRssForwardGroups.Name = "txbRssForwardGroups";
            this.txbRssForwardGroups.Size = new System.Drawing.Size(180, 60);
            this.txbRssForwardGroups.TabIndex = 4;
            this.txbRssForwardGroups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRssForwardGroups.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbRssForwardQQs
            // 
            this.txbRssForwardQQs.Location = new System.Drawing.Point(329, 61);
            this.txbRssForwardQQs.Multiline = true;
            this.txbRssForwardQQs.Name = "txbRssForwardQQs";
            this.txbRssForwardQQs.Size = new System.Drawing.Size(180, 60);
            this.txbRssForwardQQs.TabIndex = 4;
            this.txbRssForwardQQs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRssForwardQQs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // btnRssRemoveItem
            // 
            this.btnRssRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRssRemoveItem.Image = global::GreenOnions.BotManagerWindow.Properties.Resources.remove;
            this.btnRssRemoveItem.Location = new System.Drawing.Point(532, 3);
            this.btnRssRemoveItem.Name = "btnRssRemoveItem";
            this.btnRssRemoveItem.Size = new System.Drawing.Size(40, 40);
            this.btnRssRemoveItem.TabIndex = 5;
            this.btnRssRemoveItem.UseVisualStyleBackColor = true;
            this.btnRssRemoveItem.Click += new System.EventHandler(this.btnRssRemoveItem_Click);
            // 
            // txbRssRemark
            // 
            this.txbRssRemark.Location = new System.Drawing.Point(82, 32);
            this.txbRssRemark.Name = "txbRssRemark";
            this.txbRssRemark.Size = new System.Drawing.Size(427, 23);
            this.txbRssRemark.TabIndex = 7;
            // 
            // lblRssRemark
            // 
            this.lblRssRemark.AutoSize = true;
            this.lblRssRemark.Location = new System.Drawing.Point(17, 35);
            this.lblRssRemark.Name = "lblRssRemark";
            this.lblRssRemark.Size = new System.Drawing.Size(59, 17);
            this.lblRssRemark.TabIndex = 6;
            this.lblRssRemark.Text = "备      注:";
            // 
            // chkRssSendByForward
            // 
            this.chkRssSendByForward.AutoSize = true;
            this.chkRssSendByForward.Location = new System.Drawing.Point(515, 54);
            this.chkRssSendByForward.Name = "chkRssSendByForward";
            this.chkRssSendByForward.Size = new System.Drawing.Size(55, 38);
            this.chkRssSendByForward.TabIndex = 8;
            this.chkRssSendByForward.Text = " 合并\r\n 转发";
            this.chkRssSendByForward.UseVisualStyleBackColor = true;
            // 
            // pnlTranslateFromTo
            // 
            this.pnlTranslateFromTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranslateFromTo.Controls.Add(this.lblTranslateTo);
            this.pnlTranslateFromTo.Controls.Add(this.lblTranslateFrom);
            this.pnlTranslateFromTo.Controls.Add(this.cboTranslateTo);
            this.pnlTranslateFromTo.Controls.Add(this.cboTranslateFrom);
            this.pnlTranslateFromTo.Enabled = false;
            this.pnlTranslateFromTo.Location = new System.Drawing.Point(187, 121);
            this.pnlTranslateFromTo.Name = "pnlTranslateFromTo";
            this.pnlTranslateFromTo.Size = new System.Drawing.Size(389, 30);
            this.pnlTranslateFromTo.TabIndex = 9;
            // 
            // lblTranslateTo
            // 
            this.lblTranslateTo.AutoSize = true;
            this.lblTranslateTo.Location = new System.Drawing.Point(172, 5);
            this.lblTranslateTo.Name = "lblTranslateTo";
            this.lblTranslateTo.Size = new System.Drawing.Size(23, 17);
            this.lblTranslateTo.TabIndex = 2;
            this.lblTranslateTo.Text = "到:";
            // 
            // lblTranslateFrom
            // 
            this.lblTranslateFrom.AutoSize = true;
            this.lblTranslateFrom.Location = new System.Drawing.Point(12, 5);
            this.lblTranslateFrom.Name = "lblTranslateFrom";
            this.lblTranslateFrom.Size = new System.Drawing.Size(23, 17);
            this.lblTranslateFrom.TabIndex = 1;
            this.lblTranslateFrom.Text = "从:";
            // 
            // cboTranslateTo
            // 
            this.cboTranslateTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateTo.FormattingEnabled = true;
            this.cboTranslateTo.Location = new System.Drawing.Point(201, 2);
            this.cboTranslateTo.Name = "cboTranslateTo";
            this.cboTranslateTo.Size = new System.Drawing.Size(121, 25);
            this.cboTranslateTo.TabIndex = 0;
            // 
            // cboTranslateFrom
            // 
            this.cboTranslateFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateFrom.FormattingEnabled = true;
            this.cboTranslateFrom.Location = new System.Drawing.Point(41, 2);
            this.cboTranslateFrom.Name = "cboTranslateFrom";
            this.cboTranslateFrom.Size = new System.Drawing.Size(121, 25);
            this.cboTranslateFrom.TabIndex = 0;
            // 
            // chkTranslateFromTo
            // 
            this.chkTranslateFromTo.AutoSize = true;
            this.chkTranslateFromTo.Enabled = false;
            this.chkTranslateFromTo.Location = new System.Drawing.Point(82, 125);
            this.chkTranslateFromTo.Name = "chkTranslateFromTo";
            this.chkTranslateFromTo.Size = new System.Drawing.Size(99, 21);
            this.chkTranslateFromTo.TabIndex = 10;
            this.chkTranslateFromTo.Text = "指定翻译语言";
            this.chkTranslateFromTo.UseVisualStyleBackColor = true;
            this.chkTranslateFromTo.CheckedChanged += new System.EventHandler(this.chkTranslateFromTo_CheckedChanged);
            // 
            // chkRssAtAll
            // 
            this.chkRssAtAll.AutoSize = true;
            this.chkRssAtAll.Location = new System.Drawing.Point(515, 98);
            this.chkRssAtAll.Name = "chkRssAtAll";
            this.chkRssAtAll.Size = new System.Drawing.Size(63, 21);
            this.chkRssAtAll.TabIndex = 11;
            this.chkRssAtAll.Text = "@全员";
            this.chkRssAtAll.UseVisualStyleBackColor = true;
            // 
            // CtrlRssItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chkRssAtAll);
            this.Controls.Add(this.chkTranslateFromTo);
            this.Controls.Add(this.pnlTranslateFromTo);
            this.Controls.Add(this.chkRssSendByForward);
            this.Controls.Add(this.txbRssRemark);
            this.Controls.Add(this.lblRssRemark);
            this.Controls.Add(this.btnRssRemoveItem);
            this.Controls.Add(this.txbRssForwardQQs);
            this.Controls.Add(this.txbRssForwardGroups);
            this.Controls.Add(this.chkRssTranslate);
            this.Controls.Add(this.lblRssForwardQQ);
            this.Controls.Add(this.lblRssForwardGroup);
            this.Controls.Add(this.txbRssSubscriptionUrl);
            this.Controls.Add(this.lblRssSubscriptionUrl);
            this.Name = "CtrlRssItem";
            this.Size = new System.Drawing.Size(575, 150);
            this.pnlTranslateFromTo.ResumeLayout(false);
            this.pnlTranslateFromTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRssSubscriptionUrl;
        private System.Windows.Forms.TextBox txbRssSubscriptionUrl;
        private System.Windows.Forms.Label lblRssForwardGroup;
        private System.Windows.Forms.Label lblRssForwardQQ;
        private System.Windows.Forms.CheckBox chkRssTranslate;
        private System.Windows.Forms.TextBox txbRssForwardGroups;
        private System.Windows.Forms.TextBox txbRssForwardQQs;
        private System.Windows.Forms.Button btnRssRemoveItem;
        private System.Windows.Forms.TextBox txbRssRemark;
        private System.Windows.Forms.Label lblRssRemark;
        private System.Windows.Forms.CheckBox chkRssSendByForward;
        private System.Windows.Forms.Panel pnlTranslateFromTo;
        private System.Windows.Forms.Label lblTranslateTo;
        private System.Windows.Forms.Label lblTranslateFrom;
        private System.Windows.Forms.ComboBox cboTranslateTo;
        private System.Windows.Forms.ComboBox cboTranslateFrom;
        private System.Windows.Forms.CheckBox chkTranslateFromTo;
        private System.Windows.Forms.CheckBox chkRssAtAll;
    }
}
