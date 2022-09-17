namespace GreenOnions.BotManagerWindows
{
    partial class FrmRssFilter
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
            this.rdoDontFilter = new System.Windows.Forms.RadioButton();
            this.rdoContainAny = new System.Windows.Forms.RadioButton();
            this.rdoDontContain = new System.Windows.Forms.RadioButton();
            this.txbFilterKeyWords = new System.Windows.Forms.TextBox();
            this.rdoContainAll = new System.Windows.Forms.RadioButton();
            this.lblFilterKeyWords = new System.Windows.Forms.Label();
            this.lblFilterKeyWordsInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdoDontFilter
            // 
            this.rdoDontFilter.AutoSize = true;
            this.rdoDontFilter.Checked = true;
            this.rdoDontFilter.Location = new System.Drawing.Point(12, 12);
            this.rdoDontFilter.Name = "rdoDontFilter";
            this.rdoDontFilter.Size = new System.Drawing.Size(62, 21);
            this.rdoDontFilter.TabIndex = 0;
            this.rdoDontFilter.TabStop = true;
            this.rdoDontFilter.Tag = "0";
            this.rdoDontFilter.Text = "不过滤";
            this.rdoDontFilter.UseVisualStyleBackColor = true;
            // 
            // rdoContainAny
            // 
            this.rdoContainAny.AutoSize = true;
            this.rdoContainAny.Location = new System.Drawing.Point(12, 39);
            this.rdoContainAny.Name = "rdoContainAny";
            this.rdoContainAny.Size = new System.Drawing.Size(170, 21);
            this.rdoContainAny.TabIndex = 0;
            this.rdoContainAny.Tag = "1";
            this.rdoContainAny.Text = "包含以下任一关键词时发送";
            this.rdoContainAny.UseVisualStyleBackColor = true;
            // 
            // rdoDontContain
            // 
            this.rdoDontContain.AutoSize = true;
            this.rdoDontContain.Location = new System.Drawing.Point(12, 93);
            this.rdoDontContain.Name = "rdoDontContain";
            this.rdoDontContain.Size = new System.Drawing.Size(218, 21);
            this.rdoDontContain.TabIndex = 0;
            this.rdoDontContain.Tag = "3";
            this.rdoDontContain.Text = "必须不包含以下任一关键词时才发送";
            this.rdoDontContain.UseVisualStyleBackColor = true;
            // 
            // txbFilterKeyWords
            // 
            this.txbFilterKeyWords.Location = new System.Drawing.Point(89, 120);
            this.txbFilterKeyWords.Multiline = true;
            this.txbFilterKeyWords.Name = "txbFilterKeyWords";
            this.txbFilterKeyWords.Size = new System.Drawing.Size(141, 102);
            this.txbFilterKeyWords.TabIndex = 1;
            // 
            // rdoContainAll
            // 
            this.rdoContainAll.AutoSize = true;
            this.rdoContainAll.Location = new System.Drawing.Point(12, 66);
            this.rdoContainAll.Name = "rdoContainAll";
            this.rdoContainAll.Size = new System.Drawing.Size(170, 21);
            this.rdoContainAll.TabIndex = 2;
            this.rdoContainAll.Tag = "2";
            this.rdoContainAll.Text = "包含以下所有关键词时发送";
            this.rdoContainAll.UseVisualStyleBackColor = true;
            // 
            // lblFilterKeyWords
            // 
            this.lblFilterKeyWords.AutoSize = true;
            this.lblFilterKeyWords.Location = new System.Drawing.Point(12, 154);
            this.lblFilterKeyWords.Name = "lblFilterKeyWords";
            this.lblFilterKeyWords.Size = new System.Drawing.Size(71, 17);
            this.lblFilterKeyWords.TabIndex = 3;
            this.lblFilterKeyWords.Text = "过滤关键词:";
            // 
            // lblFilterKeyWordsInfo
            // 
            this.lblFilterKeyWordsInfo.AutoSize = true;
            this.lblFilterKeyWordsInfo.Location = new System.Drawing.Point(15, 171);
            this.lblFilterKeyWordsInfo.Name = "lblFilterKeyWordsInfo";
            this.lblFilterKeyWordsInfo.Size = new System.Drawing.Size(64, 17);
            this.lblFilterKeyWordsInfo.TabIndex = 4;
            this.lblFilterKeyWordsInfo.Text = "(一行一个)";
            // 
            // FrmRssFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 234);
            this.Controls.Add(this.lblFilterKeyWordsInfo);
            this.Controls.Add(this.lblFilterKeyWords);
            this.Controls.Add(this.rdoContainAll);
            this.Controls.Add(this.txbFilterKeyWords);
            this.Controls.Add(this.rdoDontContain);
            this.Controls.Add(this.rdoContainAny);
            this.Controls.Add(this.rdoDontFilter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRssFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RSS关键词过滤";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoDontFilter;
        private System.Windows.Forms.RadioButton rdoContainAny;
        private System.Windows.Forms.RadioButton rdoDontContain;
        private System.Windows.Forms.TextBox txbFilterKeyWords;
        private System.Windows.Forms.RadioButton rdoContainAll;
        private System.Windows.Forms.Label lblFilterKeyWords;
        private System.Windows.Forms.Label lblFilterKeyWordsInfo;
    }
}