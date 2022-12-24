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
            this.chkRssSendLiveCover = new System.Windows.Forms.CheckBox();
            this.pnlRssSubscriptionList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRssSubscription = new System.Windows.Forms.Button();
            this.txbReadRssInterval = new System.Windows.Forms.TextBox();
            this.lblReadRssInterval = new System.Windows.Forms.Label();
            this.pnlRssSettings = new System.Windows.Forms.Panel();
            this.btnRssLogViewer = new System.Windows.Forms.Button();
            this.chkRssParallel = new System.Windows.Forms.CheckBox();
            this.pnlRssSubscriptionList.SuspendLayout();
            this.pnlRssSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRssSendLiveCover
            // 
            this.chkRssSendLiveCover.AutoSize = true;
            this.chkRssSendLiveCover.Location = new System.Drawing.Point(233, 6);
            this.chkRssSendLiveCover.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRssSendLiveCover.Name = "chkRssSendLiveCover";
            this.chkRssSendLiveCover.Size = new System.Drawing.Size(191, 28);
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
            this.pnlRssSubscriptionList.Location = new System.Drawing.Point(0, 41);
            this.pnlRssSubscriptionList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRssSubscriptionList.Name = "pnlRssSubscriptionList";
            this.pnlRssSubscriptionList.Size = new System.Drawing.Size(990, 865);
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
            this.btnAddRssSubscription.Size = new System.Drawing.Size(977, 212);
            this.btnAddRssSubscription.TabIndex = 0;
            this.btnAddRssSubscription.UseVisualStyleBackColor = true;
            this.btnAddRssSubscription.Click += new System.EventHandler(this.btnAddRssSubscription_Click);
            // 
            // txbReadRssInterval
            // 
            this.txbReadRssInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbReadRssInterval.Location = new System.Drawing.Point(650, 4);
            this.txbReadRssInterval.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbReadRssInterval.Name = "txbReadRssInterval";
            this.txbReadRssInterval.Size = new System.Drawing.Size(217, 30);
            this.txbReadRssInterval.TabIndex = 6;
            // 
            // lblReadRssInterval
            // 
            this.lblReadRssInterval.AutoSize = true;
            this.lblReadRssInterval.Location = new System.Drawing.Point(434, 7);
            this.lblReadRssInterval.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReadRssInterval.Name = "lblReadRssInterval";
            this.lblReadRssInterval.Size = new System.Drawing.Size(206, 24);
            this.lblReadRssInterval.TabIndex = 5;
            this.lblReadRssInterval.Text = "获取内容时间间隔(分钟):";
            // 
            // pnlRssSettings
            // 
            this.pnlRssSettings.Controls.Add(this.chkRssParallel);
            this.pnlRssSettings.Controls.Add(this.btnRssLogViewer);
            this.pnlRssSettings.Controls.Add(this.lblReadRssInterval);
            this.pnlRssSettings.Controls.Add(this.chkRssSendLiveCover);
            this.pnlRssSettings.Controls.Add(this.txbReadRssInterval);
            this.pnlRssSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRssSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlRssSettings.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlRssSettings.Name = "pnlRssSettings";
            this.pnlRssSettings.Size = new System.Drawing.Size(990, 41);
            this.pnlRssSettings.TabIndex = 9;
            // 
            // btnRssLogViewer
            // 
            this.btnRssLogViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRssLogViewer.Location = new System.Drawing.Point(875, 2);
            this.btnRssLogViewer.Name = "btnRssLogViewer";
            this.btnRssLogViewer.Size = new System.Drawing.Size(112, 34);
            this.btnRssLogViewer.TabIndex = 9;
            this.btnRssLogViewer.Text = "监控";
            this.btnRssLogViewer.UseVisualStyleBackColor = true;
            this.btnRssLogViewer.Click += new System.EventHandler(this.btnRssLogViewer_Click);
            // 
            // chkRssParallel
            // 
            this.chkRssParallel.AutoSize = true;
            this.chkRssParallel.Location = new System.Drawing.Point(6, 6);
            this.chkRssParallel.Name = "chkRssParallel";
            this.chkRssParallel.Size = new System.Drawing.Size(216, 28);
            this.chkRssParallel.TabIndex = 10;
            this.chkRssParallel.Text = "每条订阅占用一个线程";
            this.chkRssParallel.UseVisualStyleBackColor = true;
            // 
            // CtrlRss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlRssSubscriptionList);
            this.Controls.Add(this.pnlRssSettings);
            this.Name = "CtrlRss";
            this.Size = new System.Drawing.Size(990, 906);
            this.pnlRssSubscriptionList.ResumeLayout(false);
            this.pnlRssSettings.ResumeLayout(false);
            this.pnlRssSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CheckBox chkRssSendLiveCover;
        private FlowLayoutPanel pnlRssSubscriptionList;
        private Button btnAddRssSubscription;
        private TextBox txbReadRssInterval;
        private Label lblReadRssInterval;
        private Panel pnlRssSettings;
        private Button btnRssLogViewer;
        private CheckBox chkRssParallel;
    }
}
