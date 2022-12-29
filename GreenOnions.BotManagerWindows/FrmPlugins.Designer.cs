namespace GreenOnions.BotManagerWindows
{
    partial class FrmPlugins
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPlugins = new System.Windows.Forms.Label();
            this.dgvPlugins = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lnkPluginsRepo = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlugins)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlugins
            // 
            this.lblPlugins.AutoSize = true;
            this.lblPlugins.Location = new System.Drawing.Point(12, 9);
            this.lblPlugins.Name = "lblPlugins";
            this.lblPlugins.Size = new System.Drawing.Size(92, 17);
            this.lblPlugins.TabIndex = 5;
            this.lblPlugins.Text = "已加载的插件：";
            // 
            // dgvPlugins
            // 
            this.dgvPlugins.AllowUserToAddRows = false;
            this.dgvPlugins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlugins.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPlugins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlugins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colName,
            this.colDescription,
            this.colSetting,
            this.colEnabled});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlugins.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPlugins.Location = new System.Drawing.Point(12, 29);
            this.dgvPlugins.Name = "dgvPlugins";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlugins.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPlugins.RowHeadersVisible = false;
            this.dgvPlugins.RowTemplate.Height = 25;
            this.dgvPlugins.Size = new System.Drawing.Size(600, 400);
            this.dgvPlugins.TabIndex = 6;
            this.dgvPlugins.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlugins_CellContentClick);
            // 
            // colIndex
            // 
            this.colIndex.DataPropertyName = "Index";
            this.colIndex.HeaderText = "序号";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colSetting
            // 
            this.colSetting.DataPropertyName = "Setting";
            this.colSetting.HeaderText = "设置";
            this.colSetting.Name = "colSetting";
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "启用";
            this.colEnabled.Name = "colEnabled";
            // 
            // lnkPluginsRepo
            // 
            this.lnkPluginsRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPluginsRepo.AutoSize = true;
            this.lnkPluginsRepo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkPluginsRepo.Location = new System.Drawing.Point(556, 9);
            this.lnkPluginsRepo.Name = "lnkPluginsRepo";
            this.lnkPluginsRepo.Size = new System.Drawing.Size(56, 17);
            this.lnkPluginsRepo.TabIndex = 7;
            this.lnkPluginsRepo.TabStop = true;
            this.lnkPluginsRepo.Text = "插件仓库";
            this.lnkPluginsRepo.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkPluginsRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PluginsRepo_LinkClicked);
            // 
            // FrmPlugins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.lnkPluginsRepo);
            this.Controls.Add(this.dgvPlugins);
            this.Controls.Add(this.lblPlugins);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlugins";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "葱葱插件";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlugins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPlugins;
        private System.Windows.Forms.DataGridView dgvPlugins;
        private DataGridViewTextBoxColumn colIndex;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewButtonColumn colSetting;
        private DataGridViewCheckBoxColumn colEnabled;
        private LinkLabel lnkPluginsRepo;
    }
}