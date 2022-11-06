namespace GreenOnions.BotManagerWindows.Controls
{
    partial class CtrlRss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlRss));
            this.chkRssParallel = new System.Windows.Forms.CheckBox();
            this.chkRssSendLiveCover = new System.Windows.Forms.CheckBox();
            this.pnlRssSubscriptionList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRssSubscription = new System.Windows.Forms.Button();
            this.txbReadRssInterval = new System.Windows.Forms.TextBox();
            this.lblReadRssInterval = new System.Windows.Forms.Label();
            this.pnlRssSubscriptionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRssParallel
            // 
            this.chkRssParallel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRssParallel.AutoSize = true;
            this.chkRssParallel.Location = new System.Drawing.Point(534, 26);
            this.chkRssParallel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssParallel.Name = "chkRssParallel";
            this.chkRssParallel.Size = new System.Drawing.Size(234, 28);
            this.chkRssParallel.TabIndex = 8;
            this.chkRssParallel.Text = "每条订阅各占用一个线程";
            this.chkRssParallel.UseVisualStyleBackColor = true;
            // 
            // chkRssSendLiveCover
            // 
            this.chkRssSendLiveCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRssSendLiveCover.AutoSize = true;
            this.chkRssSendLiveCover.Location = new System.Drawing.Point(778, 26);
            this.chkRssSendLiveCover.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssSendLiveCover.Name = "chkRssSendLiveCover";
            this.chkRssSendLiveCover.Size = new System.Drawing.Size(191, 28);
            this.chkRssSendLiveCover.TabIndex = 4;
            this.chkRssSendLiveCover.Text = "获取B站直播间封面";
            this.chkRssSendLiveCover.UseVisualStyleBackColor = true;
            // 
            // pnlRssSubscriptionList
            // 
            this.pnlRssSubscriptionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRssSubscriptionList.AutoScroll = true;
            this.pnlRssSubscriptionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRssSubscriptionList.Controls.Add(this.btnAddRssSubscription);
            this.pnlRssSubscriptionList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlRssSubscriptionList.Location = new System.Drawing.Point(33, 64);
            this.pnlRssSubscriptionList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRssSubscriptionList.Name = "pnlRssSubscriptionList";
            this.pnlRssSubscriptionList.Size = new System.Drawing.Size(947, 820);
            this.pnlRssSubscriptionList.TabIndex = 7;
            this.pnlRssSubscriptionList.WrapContents = false;
            this.pnlRssSubscriptionList.SizeChanged += new System.EventHandler(this.pnlRssSubscriptionList_SizeChanged);
            this.pnlRssSubscriptionList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlRssSubscriptionList_ControlChanged);
            this.pnlRssSubscriptionList.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlRssSubscriptionList_ControlChanged);
            // 
            // btnAddRssSubscription
            // 
            this.btnAddRssSubscription.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRssSubscription.Image")));
            this.btnAddRssSubscription.Location = new System.Drawing.Point(5, 4);
            this.btnAddRssSubscription.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAddRssSubscription.Name = "btnAddRssSubscription";
            this.btnAddRssSubscription.Size = new System.Drawing.Size(930, 212);
            this.btnAddRssSubscription.TabIndex = 0;
            this.btnAddRssSubscription.UseVisualStyleBackColor = true;
            this.btnAddRssSubscription.Click += new System.EventHandler(this.btnAddRssSubscription_Click);
            // 
            // txbReadRssInterval
            // 
            this.txbReadRssInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbReadRssInterval.Location = new System.Drawing.Point(263, 23);
            this.txbReadRssInterval.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbReadRssInterval.Name = "txbReadRssInterval";
            this.txbReadRssInterval.Size = new System.Drawing.Size(261, 30);
            this.txbReadRssInterval.TabIndex = 6;
            // 
            // lblReadRssInterval
            // 
            this.lblReadRssInterval.AutoSize = true;
            this.lblReadRssInterval.Location = new System.Drawing.Point(35, 27);
            this.lblReadRssInterval.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReadRssInterval.Name = "lblReadRssInterval";
            this.lblReadRssInterval.Size = new System.Drawing.Size(206, 24);
            this.lblReadRssInterval.TabIndex = 5;
            this.lblReadRssInterval.Text = "获取内容时间间隔(分钟):";
            // 
            // CtrlRss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkRssSendLiveCover);
            this.Controls.Add(this.chkRssParallel);
            this.Controls.Add(this.pnlRssSubscriptionList);
            this.Controls.Add(this.txbReadRssInterval);
            this.Controls.Add(this.lblReadRssInterval);
            this.Name = "CtrlRss";
            this.Size = new System.Drawing.Size(1012, 906);
            this.pnlRssSubscriptionList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox chkRssParallel;
        private CheckBox chkRssSendLiveCover;
        private FlowLayoutPanel pnlRssSubscriptionList;
        private Button btnAddRssSubscription;
        private TextBox txbReadRssInterval;
        private Label lblReadRssInterval;
    }
}
