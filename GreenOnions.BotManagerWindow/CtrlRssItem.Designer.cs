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
            this.txbRssTranslate = new System.Windows.Forms.CheckBox();
            this.txbRssForwardGroups = new System.Windows.Forms.TextBox();
            this.txbRssForwardQQs = new System.Windows.Forms.TextBox();
            this.btnRssRemoveItem = new System.Windows.Forms.Button();
            this.txbRssRemark = new System.Windows.Forms.TextBox();
            this.lblRssRemark = new System.Windows.Forms.Label();
            this.chkRssSendByForward = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblRssSubscriptionUrl
            // 
            this.lblRssSubscriptionUrl.AutoSize = true;
            this.lblRssSubscriptionUrl.Location = new System.Drawing.Point(17, 8);
            this.lblRssSubscriptionUrl.Name = "lblRssSubscriptionUrl";
            this.lblRssSubscriptionUrl.Size = new System.Drawing.Size(59, 17);
            this.lblRssSubscriptionUrl.TabIndex = 0;
            this.lblRssSubscriptionUrl.Text = "订阅地址:";
            // 
            // txbRssSubscriptionUrl
            // 
            this.txbRssSubscriptionUrl.Location = new System.Drawing.Point(82, 5);
            this.txbRssSubscriptionUrl.Name = "txbRssSubscriptionUrl";
            this.txbRssSubscriptionUrl.Size = new System.Drawing.Size(427, 23);
            this.txbRssSubscriptionUrl.TabIndex = 1;
            // 
            // lblRssForwardGroup
            // 
            this.lblRssForwardGroup.AutoSize = true;
            this.lblRssForwardGroup.Location = new System.Drawing.Point(17, 95);
            this.lblRssForwardGroup.Name = "lblRssForwardGroup";
            this.lblRssForwardGroup.Size = new System.Drawing.Size(59, 17);
            this.lblRssForwardGroup.TabIndex = 2;
            this.lblRssForwardGroup.Text = "转发群组:";
            // 
            // lblRssForwardQQ
            // 
            this.lblRssForwardQQ.AutoSize = true;
            this.lblRssForwardQQ.Location = new System.Drawing.Point(268, 95);
            this.lblRssForwardQQ.Name = "lblRssForwardQQ";
            this.lblRssForwardQQ.Size = new System.Drawing.Size(55, 17);
            this.lblRssForwardQQ.TabIndex = 2;
            this.lblRssForwardQQ.Text = "转发QQ:";
            // 
            // txbRssTranslate
            // 
            this.txbRssTranslate.AutoSize = true;
            this.txbRssTranslate.Location = new System.Drawing.Point(515, 108);
            this.txbRssTranslate.Name = "txbRssTranslate";
            this.txbRssTranslate.Size = new System.Drawing.Size(51, 21);
            this.txbRssTranslate.TabIndex = 3;
            this.txbRssTranslate.Text = "翻译";
            this.txbRssTranslate.UseVisualStyleBackColor = true;
            // 
            // txbRssForwardGroups
            // 
            this.txbRssForwardGroups.Location = new System.Drawing.Point(82, 63);
            this.txbRssForwardGroups.Multiline = true;
            this.txbRssForwardGroups.Name = "txbRssForwardGroups";
            this.txbRssForwardGroups.Size = new System.Drawing.Size(180, 80);
            this.txbRssForwardGroups.TabIndex = 4;
            this.txbRssForwardGroups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber_KeyPress);
            this.txbRssForwardGroups.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkNumber_KeyUp);
            // 
            // txbRssForwardQQs
            // 
            this.txbRssForwardQQs.Location = new System.Drawing.Point(329, 63);
            this.txbRssForwardQQs.Multiline = true;
            this.txbRssForwardQQs.Name = "txbRssForwardQQs";
            this.txbRssForwardQQs.Size = new System.Drawing.Size(180, 80);
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
            this.txbRssRemark.Location = new System.Drawing.Point(82, 34);
            this.txbRssRemark.Name = "txbRssRemark";
            this.txbRssRemark.Size = new System.Drawing.Size(427, 23);
            this.txbRssRemark.TabIndex = 7;
            // 
            // lblRssRemark
            // 
            this.lblRssRemark.AutoSize = true;
            this.lblRssRemark.Location = new System.Drawing.Point(17, 37);
            this.lblRssRemark.Name = "lblRssRemark";
            this.lblRssRemark.Size = new System.Drawing.Size(59, 17);
            this.lblRssRemark.TabIndex = 6;
            this.lblRssRemark.Text = "备      注:";
            // 
            // chkRssSendByForward
            // 
            this.chkRssSendByForward.AutoSize = true;
            this.chkRssSendByForward.Location = new System.Drawing.Point(515, 76);
            this.chkRssSendByForward.Name = "chkRssSendByForward";
            this.chkRssSendByForward.Size = new System.Drawing.Size(51, 21);
            this.chkRssSendByForward.TabIndex = 8;
            this.chkRssSendByForward.Text = "转发";
            this.chkRssSendByForward.UseVisualStyleBackColor = true;
            // 
            // CtrlRssItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chkRssSendByForward);
            this.Controls.Add(this.txbRssRemark);
            this.Controls.Add(this.lblRssRemark);
            this.Controls.Add(this.btnRssRemoveItem);
            this.Controls.Add(this.txbRssForwardQQs);
            this.Controls.Add(this.txbRssForwardGroups);
            this.Controls.Add(this.txbRssTranslate);
            this.Controls.Add(this.lblRssForwardQQ);
            this.Controls.Add(this.lblRssForwardGroup);
            this.Controls.Add(this.txbRssSubscriptionUrl);
            this.Controls.Add(this.lblRssSubscriptionUrl);
            this.Name = "CtrlRssItem";
            this.Size = new System.Drawing.Size(575, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRssSubscriptionUrl;
        private System.Windows.Forms.TextBox txbRssSubscriptionUrl;
        private System.Windows.Forms.Label lblRssForwardGroup;
        private System.Windows.Forms.Label lblRssForwardQQ;
        private System.Windows.Forms.CheckBox txbRssTranslate;
        private System.Windows.Forms.TextBox txbRssForwardGroups;
        private System.Windows.Forms.TextBox txbRssForwardQQs;
        private System.Windows.Forms.Button btnRssRemoveItem;
        private System.Windows.Forms.TextBox txbRssRemark;
        private System.Windows.Forms.Label lblRssRemark;
        private System.Windows.Forms.CheckBox chkRssSendByForward;
    }
}
