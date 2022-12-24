namespace GreenOnions.BotManagerWindows.ItemFroms
{
    partial class FrmRssLogViewer
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
            this.splitterRssStatus = new System.Windows.Forms.Splitter();
            this.dgvTaskStatus = new System.Windows.Forms.DataGridView();
            this.dgvHeaderUrlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHeaderStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbLogs = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterRssStatus
            // 
            this.splitterRssStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterRssStatus.Location = new System.Drawing.Point(0, 175);
            this.splitterRssStatus.Name = "splitterRssStatus";
            this.splitterRssStatus.Size = new System.Drawing.Size(1258, 8);
            this.splitterRssStatus.TabIndex = 2;
            this.splitterRssStatus.TabStop = false;
            // 
            // dgvTaskStatus
            // 
            this.dgvTaskStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaskStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHeaderUrlColumn,
            this.dgvHeaderStatusColumn});
            this.dgvTaskStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTaskStatus.Location = new System.Drawing.Point(0, 0);
            this.dgvTaskStatus.Name = "dgvTaskStatus";
            this.dgvTaskStatus.ReadOnly = true;
            this.dgvTaskStatus.RowHeadersVisible = false;
            this.dgvTaskStatus.RowHeadersWidth = 62;
            this.dgvTaskStatus.RowTemplate.Height = 32;
            this.dgvTaskStatus.Size = new System.Drawing.Size(1258, 175);
            this.dgvTaskStatus.TabIndex = 49;
            // 
            // dgvHeaderUrlColumn
            // 
            this.dgvHeaderUrlColumn.DataPropertyName = "Url";
            this.dgvHeaderUrlColumn.HeaderText = "订阅地址";
            this.dgvHeaderUrlColumn.MinimumWidth = 8;
            this.dgvHeaderUrlColumn.Name = "dgvHeaderUrlColumn";
            this.dgvHeaderUrlColumn.ReadOnly = true;
            // 
            // dgvHeaderStatusColumn
            // 
            this.dgvHeaderStatusColumn.DataPropertyName = "Status";
            this.dgvHeaderStatusColumn.FillWeight = 20F;
            this.dgvHeaderStatusColumn.HeaderText = "线程状态";
            this.dgvHeaderStatusColumn.MinimumWidth = 8;
            this.dgvHeaderStatusColumn.Name = "dgvHeaderStatusColumn";
            this.dgvHeaderStatusColumn.ReadOnly = true;
            // 
            // txbLogs
            // 
            this.txbLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbLogs.Location = new System.Drawing.Point(0, 183);
            this.txbLogs.Name = "txbLogs";
            this.txbLogs.Size = new System.Drawing.Size(1258, 721);
            this.txbLogs.TabIndex = 50;
            this.txbLogs.Text = "";
            // 
            // FrmRssLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 904);
            this.Controls.Add(this.txbLogs);
            this.Controls.Add(this.splitterRssStatus);
            this.Controls.Add(this.dgvTaskStatus);
            this.Name = "FrmRssLogViewer";
            this.Text = "RSS监控器";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Splitter splitterRssStatus;
        private DataGridView dgvTaskStatus;
        private DataGridViewTextBoxColumn dgvHeaderUrlColumn;
        private DataGridViewTextBoxColumn dgvHeaderStatusColumn;
        private RichTextBox txbLogs;
    }
}