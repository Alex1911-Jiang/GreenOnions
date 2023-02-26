namespace GreenOnions.BotManagerWindows.ItemFroms
{
    partial class FrmRssFromat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRssFromat));
            this.lblFormat = new System.Windows.Forms.Label();
            this.txbFormat = new System.Windows.Forms.TextBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.spltLeftRight = new System.Windows.Forms.Splitter();
            this.lblHelp = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormat.Location = new System.Drawing.Point(0, 0);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(118, 24);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "排版表达式：";
            // 
            // txbFormat
            // 
            this.txbFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbFormat.Location = new System.Drawing.Point(0, 24);
            this.txbFormat.Multiline = true;
            this.txbFormat.Name = "txbFormat";
            this.txbFormat.Size = new System.Drawing.Size(574, 720);
            this.txbFormat.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.txbFormat);
            this.pnlLeft.Controls.Add(this.lblFormat);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(574, 744);
            this.pnlLeft.TabIndex = 2;
            // 
            // spltLeftRight
            // 
            this.spltLeftRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.spltLeftRight.Location = new System.Drawing.Point(574, 0);
            this.spltLeftRight.Name = "spltLeftRight";
            this.spltLeftRight.Size = new System.Drawing.Size(4, 744);
            this.spltLeftRight.TabIndex = 4;
            this.spltLeftRight.TabStop = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHelp.Location = new System.Drawing.Point(578, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(766, 648);
            this.lblHelp.TabIndex = 0;
            this.lblHelp.Text = resources.GetString("lblHelp.Text");
            // 
            // FrmRssFromat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 744);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.spltLeftRight);
            this.Controls.Add(this.lblHelp);
            this.Name = "FrmRssFromat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSS自定义排版设置";
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblFormat;
        private TextBox txbFormat;
        private Panel pnlLeft;
        private Splitter spltLeftRight;
        private Label lblHelp;
    }
}