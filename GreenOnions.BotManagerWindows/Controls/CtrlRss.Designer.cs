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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlRss));
            this.chkRssParallel = new System.Windows.Forms.CheckBox();
            this.chkRssSendLiveCover = new System.Windows.Forms.CheckBox();
            this.pnlRssSubscriptionList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRssSubscription = new System.Windows.Forms.Button();
            this.txbReadRssInterval = new System.Windows.Forms.TextBox();
            this.lblReadRssInterval = new System.Windows.Forms.Label();
            this.pnlRssSettings = new System.Windows.Forms.Panel();
            this.pnlRssSubscriptionList.SuspendLayout();
            this.pnlRssSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRssParallel
            // 
            this.chkRssParallel.AutoSize = true;
            this.chkRssParallel.Location = new System.Drawing.Point(3, 5);
            this.chkRssParallel.Name = "chkRssParallel";
            this.chkRssParallel.Size = new System.Drawing.Size(159, 21);
            this.chkRssParallel.TabIndex = 8;
            this.chkRssParallel.Text = "每条订阅各占用一个线程";
            this.chkRssParallel.UseVisualStyleBackColor = true;
            // 
            // chkRssSendLiveCover
            // 
            this.chkRssSendLiveCover.AutoSize = true;
            this.chkRssSendLiveCover.Location = new System.Drawing.Point(168, 5);
            this.chkRssSendLiveCover.Name = "chkRssSendLiveCover";
            this.chkRssSendLiveCover.Size = new System.Drawing.Size(131, 21);
            this.chkRssSendLiveCover.TabIndex = 4;
            this.chkRssSendLiveCover.Text = "获取B站直播间封面";
            this.chkRssSendLiveCover.UseVisualStyleBackColor = true;
            // 
            // pnlRssSubscriptionList
            // 
            this.pnlRssSubscriptionList.AutoScroll = true;
            this.pnlRssSubscriptionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRssSubscriptionList.Controls.Add(this.btnAddRssSubscription);
            this.pnlRssSubscriptionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRssSubscriptionList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlRssSubscriptionList.Location = new System.Drawing.Point(0, 29);
            this.pnlRssSubscriptionList.Name = "pnlRssSubscriptionList";
            this.pnlRssSubscriptionList.Size = new System.Drawing.Size(630, 613);
            this.pnlRssSubscriptionList.TabIndex = 7;
            this.pnlRssSubscriptionList.WrapContents = false;
            this.pnlRssSubscriptionList.SizeChanged += new System.EventHandler(this.pnlRssSubscriptionList_SizeChanged);
            this.pnlRssSubscriptionList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlRssSubscriptionList_ControlChanged);
            this.pnlRssSubscriptionList.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlRssSubscriptionList_ControlChanged);
            // 
            // btnAddRssSubscription
            // 
            this.btnAddRssSubscription.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRssSubscription.Image")));
            this.btnAddRssSubscription.Location = new System.Drawing.Point(3, 3);
            this.btnAddRssSubscription.Name = "btnAddRssSubscription";
            this.btnAddRssSubscription.Size = new System.Drawing.Size(622, 150);
            this.btnAddRssSubscription.TabIndex = 0;
            this.btnAddRssSubscription.UseVisualStyleBackColor = true;
            this.btnAddRssSubscription.Click += new System.EventHandler(this.btnAddRssSubscription_Click);
            // 
            // txbReadRssInterval
            // 
            this.txbReadRssInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbReadRssInterval.Location = new System.Drawing.Point(450, 3);
            this.txbReadRssInterval.Name = "txbReadRssInterval";
            this.txbReadRssInterval.Size = new System.Drawing.Size(177, 23);
            this.txbReadRssInterval.TabIndex = 6;
            // 
            // lblReadRssInterval
            // 
            this.lblReadRssInterval.AutoSize = true;
            this.lblReadRssInterval.Location = new System.Drawing.Point(305, 6);
            this.lblReadRssInterval.Name = "lblReadRssInterval";
            this.lblReadRssInterval.Size = new System.Drawing.Size(139, 17);
            this.lblReadRssInterval.TabIndex = 5;
            this.lblReadRssInterval.Text = "获取内容时间间隔(分钟):";
            // 
            // pnlRssSettings
            // 
            this.pnlRssSettings.Controls.Add(this.lblReadRssInterval);
            this.pnlRssSettings.Controls.Add(this.chkRssSendLiveCover);
            this.pnlRssSettings.Controls.Add(this.txbReadRssInterval);
            this.pnlRssSettings.Controls.Add(this.chkRssParallel);
            this.pnlRssSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRssSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlRssSettings.Name = "pnlRssSettings";
            this.pnlRssSettings.Size = new System.Drawing.Size(630, 29);
            this.pnlRssSettings.TabIndex = 9;
            // 
            // CtrlRss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlRssSubscriptionList);
            this.Controls.Add(this.pnlRssSettings);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CtrlRss";
            this.Size = new System.Drawing.Size(630, 642);
            this.pnlRssSubscriptionList.ResumeLayout(false);
            this.pnlRssSettings.ResumeLayout(false);
            this.pnlRssSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox chkRssParallel;
        private CheckBox chkRssSendLiveCover;
        private FlowLayoutPanel pnlRssSubscriptionList;
        private Button btnAddRssSubscription;
        private TextBox txbReadRssInterval;
        private Label lblReadRssInterval;
        private Panel pnlRssSettings;
    }
}
