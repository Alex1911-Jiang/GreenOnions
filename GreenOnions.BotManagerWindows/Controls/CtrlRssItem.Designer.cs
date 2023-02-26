namespace GreenOnions.BotManagerWindows.Controls
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
            this.btnFilters = new System.Windows.Forms.Button();
            this.chkTranslateFromTo = new System.Windows.Forms.CheckBox();
            this.btnHeaders = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.pnlTranslateFromTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRssSubscriptionUrl
            // 
            this.lblRssSubscriptionUrl.AutoSize = true;
            this.lblRssSubscriptionUrl.Location = new System.Drawing.Point(27, 13);
            this.lblRssSubscriptionUrl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRssSubscriptionUrl.Name = "lblRssSubscriptionUrl";
            this.lblRssSubscriptionUrl.Size = new System.Drawing.Size(86, 24);
            this.lblRssSubscriptionUrl.TabIndex = 0;
            this.lblRssSubscriptionUrl.Text = "订阅地址:";
            // 
            // txbRssSubscriptionUrl
            // 
            this.txbRssSubscriptionUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRssSubscriptionUrl.Location = new System.Drawing.Point(129, 10);
            this.txbRssSubscriptionUrl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRssSubscriptionUrl.Name = "txbRssSubscriptionUrl";
            this.txbRssSubscriptionUrl.Size = new System.Drawing.Size(549, 30);
            this.txbRssSubscriptionUrl.TabIndex = 1;
            // 
            // lblRssForwardGroup
            // 
            this.lblRssForwardGroup.AutoSize = true;
            this.lblRssForwardGroup.Location = new System.Drawing.Point(27, 117);
            this.lblRssForwardGroup.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRssForwardGroup.Name = "lblRssForwardGroup";
            this.lblRssForwardGroup.Size = new System.Drawing.Size(86, 24);
            this.lblRssForwardGroup.TabIndex = 2;
            this.lblRssForwardGroup.Text = "转发群组:";
            // 
            // lblRssForwardQQ
            // 
            this.lblRssForwardQQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRssForwardQQ.AutoSize = true;
            this.lblRssForwardQQ.Location = new System.Drawing.Point(421, 117);
            this.lblRssForwardQQ.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRssForwardQQ.Name = "lblRssForwardQQ";
            this.lblRssForwardQQ.Size = new System.Drawing.Size(80, 24);
            this.lblRssForwardQQ.TabIndex = 2;
            this.lblRssForwardQQ.Text = "转发QQ:";
            // 
            // chkRssTranslate
            // 
            this.chkRssTranslate.AutoSize = true;
            this.chkRssTranslate.Location = new System.Drawing.Point(27, 176);
            this.chkRssTranslate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssTranslate.Name = "chkRssTranslate";
            this.chkRssTranslate.Size = new System.Drawing.Size(72, 28);
            this.chkRssTranslate.TabIndex = 3;
            this.chkRssTranslate.Text = "翻译";
            this.chkRssTranslate.UseVisualStyleBackColor = true;
            this.chkRssTranslate.CheckedChanged += new System.EventHandler(this.chkRssTranslate_CheckedChanged);
            // 
            // txbRssForwardGroups
            // 
            this.txbRssForwardGroups.Location = new System.Drawing.Point(129, 86);
            this.txbRssForwardGroups.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRssForwardGroups.Multiline = true;
            this.txbRssForwardGroups.Name = "txbRssForwardGroups";
            this.txbRssForwardGroups.Size = new System.Drawing.Size(281, 83);
            this.txbRssForwardGroups.TabIndex = 4;
            this.txbRssForwardGroups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRssForwardGroups.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbRssForwardQQs
            // 
            this.txbRssForwardQQs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRssForwardQQs.Location = new System.Drawing.Point(517, 86);
            this.txbRssForwardQQs.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRssForwardQQs.Multiline = true;
            this.txbRssForwardQQs.Name = "txbRssForwardQQs";
            this.txbRssForwardQQs.Size = new System.Drawing.Size(281, 83);
            this.txbRssForwardQQs.TabIndex = 4;
            this.txbRssForwardQQs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRssForwardQQs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // btnRssRemoveItem
            // 
            this.btnRssRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRssRemoveItem.Image = global::GreenOnions.BotManagerWindows.Resource.remove;
            this.btnRssRemoveItem.Location = new System.Drawing.Point(836, 4);
            this.btnRssRemoveItem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRssRemoveItem.Name = "btnRssRemoveItem";
            this.btnRssRemoveItem.Size = new System.Drawing.Size(63, 56);
            this.btnRssRemoveItem.TabIndex = 5;
            this.btnRssRemoveItem.UseVisualStyleBackColor = true;
            // 
            // txbRssRemark
            // 
            this.txbRssRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRssRemark.Location = new System.Drawing.Point(129, 49);
            this.txbRssRemark.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbRssRemark.Name = "txbRssRemark";
            this.txbRssRemark.Size = new System.Drawing.Size(669, 30);
            this.txbRssRemark.TabIndex = 7;
            // 
            // lblRssRemark
            // 
            this.lblRssRemark.AutoSize = true;
            this.lblRssRemark.Location = new System.Drawing.Point(33, 52);
            this.lblRssRemark.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRssRemark.Name = "lblRssRemark";
            this.lblRssRemark.Size = new System.Drawing.Size(80, 24);
            this.lblRssRemark.TabIndex = 6;
            this.lblRssRemark.Text = "备      注:";
            // 
            // chkRssSendByForward
            // 
            this.chkRssSendByForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRssSendByForward.AutoSize = true;
            this.chkRssSendByForward.Location = new System.Drawing.Point(818, 76);
            this.chkRssSendByForward.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssSendByForward.Name = "chkRssSendByForward";
            this.chkRssSendByForward.Size = new System.Drawing.Size(77, 52);
            this.chkRssSendByForward.TabIndex = 8;
            this.chkRssSendByForward.Text = " 合并\r\n 转发";
            this.chkRssSendByForward.UseVisualStyleBackColor = true;
            // 
            // pnlTranslateFromTo
            // 
            this.pnlTranslateFromTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranslateFromTo.Controls.Add(this.lblTranslateTo);
            this.pnlTranslateFromTo.Controls.Add(this.lblTranslateFrom);
            this.pnlTranslateFromTo.Controls.Add(this.cboTranslateTo);
            this.pnlTranslateFromTo.Controls.Add(this.cboTranslateFrom);
            this.pnlTranslateFromTo.Enabled = false;
            this.pnlTranslateFromTo.Location = new System.Drawing.Point(263, 171);
            this.pnlTranslateFromTo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlTranslateFromTo.Name = "pnlTranslateFromTo";
            this.pnlTranslateFromTo.Size = new System.Drawing.Size(406, 42);
            this.pnlTranslateFromTo.TabIndex = 9;
            // 
            // lblTranslateTo
            // 
            this.lblTranslateTo.AutoSize = true;
            this.lblTranslateTo.Location = new System.Drawing.Point(214, 7);
            this.lblTranslateTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateTo.Name = "lblTranslateTo";
            this.lblTranslateTo.Size = new System.Drawing.Size(32, 24);
            this.lblTranslateTo.TabIndex = 2;
            this.lblTranslateTo.Text = "到:";
            // 
            // lblTranslateFrom
            // 
            this.lblTranslateFrom.AutoSize = true;
            this.lblTranslateFrom.Location = new System.Drawing.Point(19, 7);
            this.lblTranslateFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateFrom.Name = "lblTranslateFrom";
            this.lblTranslateFrom.Size = new System.Drawing.Size(32, 24);
            this.lblTranslateFrom.TabIndex = 1;
            this.lblTranslateFrom.Text = "从:";
            // 
            // cboTranslateTo
            // 
            this.cboTranslateTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateTo.FormattingEnabled = true;
            this.cboTranslateTo.Location = new System.Drawing.Point(256, 3);
            this.cboTranslateTo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboTranslateTo.Name = "cboTranslateTo";
            this.cboTranslateTo.Size = new System.Drawing.Size(140, 32);
            this.cboTranslateTo.TabIndex = 0;
            // 
            // cboTranslateFrom
            // 
            this.cboTranslateFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateFrom.FormattingEnabled = true;
            this.cboTranslateFrom.Location = new System.Drawing.Point(64, 3);
            this.cboTranslateFrom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboTranslateFrom.Name = "cboTranslateFrom";
            this.cboTranslateFrom.Size = new System.Drawing.Size(140, 32);
            this.cboTranslateFrom.TabIndex = 0;
            // 
            // btnFilters
            // 
            this.btnFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilters.Location = new System.Drawing.Point(809, 166);
            this.btnFilters.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(90, 38);
            this.btnFilters.TabIndex = 3;
            this.btnFilters.Text = "过滤...";
            this.btnFilters.UseVisualStyleBackColor = true;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // chkTranslateFromTo
            // 
            this.chkTranslateFromTo.AutoSize = true;
            this.chkTranslateFromTo.Enabled = false;
            this.chkTranslateFromTo.Location = new System.Drawing.Point(109, 176);
            this.chkTranslateFromTo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkTranslateFromTo.Name = "chkTranslateFromTo";
            this.chkTranslateFromTo.Size = new System.Drawing.Size(144, 28);
            this.chkTranslateFromTo.TabIndex = 10;
            this.chkTranslateFromTo.Text = "指定翻译语言";
            this.chkTranslateFromTo.UseVisualStyleBackColor = true;
            this.chkTranslateFromTo.CheckedChanged += new System.EventHandler(this.chkTranslateFromTo_CheckedChanged);
            // 
            // btnHeaders
            // 
            this.btnHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaders.Location = new System.Drawing.Point(809, 131);
            this.btnHeaders.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnHeaders.Name = "btnHeaders";
            this.btnHeaders.Size = new System.Drawing.Size(90, 38);
            this.btnHeaders.TabIndex = 12;
            this.btnHeaders.Text = "Header";
            this.btnHeaders.UseVisualStyleBackColor = true;
            this.btnHeaders.Click += new System.EventHandler(this.btnHeaders_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(686, 8);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(112, 34);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "测试抓取";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormat.Location = new System.Drawing.Point(677, 174);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(124, 34);
            this.btnFormat.TabIndex = 14;
            this.btnFormat.Text = "自定义排版";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // CtrlRssItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnHeaders);
            this.Controls.Add(this.btnFilters);
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
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CtrlRssItem";
            this.Size = new System.Drawing.Size(904, 212);
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
        private System.Windows.Forms.Button btnFilters;
        private Button btnHeaders;
        private Button btnTest;
        private Button btnFormat;
    }
}
