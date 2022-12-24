namespace GreenOnions.BotManagerWindows.ItemFroms
{
    partial class FrmRssHeders
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
            this.dgvHeader = new System.Windows.Forms.DataGridView();
            this.dgvHeaderKeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHeaderValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHeader
            // 
            this.dgvHeader.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHeaderKeyColumn,
            this.dgvHeaderValueColumn});
            this.dgvHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeader.Location = new System.Drawing.Point(0, 0);
            this.dgvHeader.Name = "dgvHeader";
            this.dgvHeader.RowHeadersVisible = false;
            this.dgvHeader.RowHeadersWidth = 62;
            this.dgvHeader.RowTemplate.Height = 32;
            this.dgvHeader.Size = new System.Drawing.Size(800, 450);
            this.dgvHeader.TabIndex = 49;
            // 
            // dgvHeaderKeyColumn
            // 
            this.dgvHeaderKeyColumn.FillWeight = 20F;
            this.dgvHeaderKeyColumn.HeaderText = "Key";
            this.dgvHeaderKeyColumn.MinimumWidth = 8;
            this.dgvHeaderKeyColumn.Name = "dgvHeaderKeyColumn";
            // 
            // dgvHeaderValueColumn
            // 
            this.dgvHeaderValueColumn.HeaderText = "Value";
            this.dgvHeaderValueColumn.MinimumWidth = 8;
            this.dgvHeaderValueColumn.Name = "dgvHeaderValueColumn";
            // 
            // FrmRssHeders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRssHeders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑Heders";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvHeader;
        private DataGridViewTextBoxColumn dgvHeaderKeyColumn;
        private DataGridViewTextBoxColumn dgvHeaderValueColumn;
    }
}