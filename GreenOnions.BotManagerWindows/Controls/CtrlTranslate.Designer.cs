namespace GreenOnions.BotManagerWindows.Controls
{
    partial class CtrlTranslate
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
            this.txbTranslateFromToCMD = new System.Windows.Forms.TextBox();
            this.lblTranslateFromTo = new System.Windows.Forms.Label();
            this.cboTranslateEngine = new System.Windows.Forms.ComboBox();
            this.lblTranslateEngine = new System.Windows.Forms.Label();
            this.txbAddAutoTranslateGroupMemoryQQ = new System.Windows.Forms.TextBox();
            this.btnRemoveAutoTranslateGroupMemoryQQ = new System.Windows.Forms.Button();
            this.btnAddAutoTranslateGroupMemoryQQ = new System.Windows.Forms.Button();
            this.lstAutoTranslateGroupMemoriesQQ = new System.Windows.Forms.ListView();
            this.lblAddAutoTranslateGroupMemoryQQ = new System.Windows.Forms.Label();
            this.lblAutoTranslateGroupMemoriesQQ = new System.Windows.Forms.Label();
            this.txbTranslateTo = new System.Windows.Forms.TextBox();
            this.txbTranslateToChinese = new System.Windows.Forms.TextBox();
            this.lblTranslateTo = new System.Windows.Forms.Label();
            this.lblTranslateToChinese = new System.Windows.Forms.Label();
            this.lblTranslateEngineHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbTranslateFromToCMD
            // 
            this.txbTranslateFromToCMD.Location = new System.Drawing.Point(197, 134);
            this.txbTranslateFromToCMD.Name = "txbTranslateFromToCMD";
            this.txbTranslateFromToCMD.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateFromToCMD.TabIndex = 30;
            // 
            // lblTranslateFromTo
            // 
            this.lblTranslateFromTo.AutoSize = true;
            this.lblTranslateFromTo.Location = new System.Drawing.Point(12, 137);
            this.lblTranslateFromTo.Name = "lblTranslateFromTo";
            this.lblTranslateFromTo.Size = new System.Drawing.Size(179, 17);
            this.lblTranslateFromTo.TabIndex = 29;
            this.lblTranslateFromTo.Text = "从指定语言翻译为指定语言命令:";
            // 
            // cboTranslateEngine
            // 
            this.cboTranslateEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateEngine.FormattingEnabled = true;
            this.cboTranslateEngine.Items.AddRange(new object[] {
            "YouDao"});
            this.cboTranslateEngine.Location = new System.Drawing.Point(137, 13);
            this.cboTranslateEngine.Name = "cboTranslateEngine";
            this.cboTranslateEngine.Size = new System.Drawing.Size(485, 25);
            this.cboTranslateEngine.TabIndex = 27;
            this.cboTranslateEngine.SelectedIndexChanged += new System.EventHandler(this.cboTranslateEngine_SelectedIndexChanged);
            // 
            // lblTranslateEngine
            // 
            this.lblTranslateEngine.AutoSize = true;
            this.lblTranslateEngine.Location = new System.Drawing.Point(12, 16);
            this.lblTranslateEngine.Name = "lblTranslateEngine";
            this.lblTranslateEngine.Size = new System.Drawing.Size(59, 17);
            this.lblTranslateEngine.TabIndex = 26;
            this.lblTranslateEngine.Text = "翻译引擎:";
            // 
            // txbAddAutoTranslateGroupMemoryQQ
            // 
            this.txbAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(455, 210);
            this.txbAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbAddAutoTranslateGroupMemoryQQ.Name = "txbAddAutoTranslateGroupMemoryQQ";
            this.txbAddAutoTranslateGroupMemoryQQ.ShortcutsEnabled = false;
            this.txbAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(167, 23);
            this.txbAddAutoTranslateGroupMemoryQQ.TabIndex = 20;
            // 
            // btnRemoveAutoTranslateGroupMemoryQQ
            // 
            this.btnRemoveAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(347, 241);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Name = "btnRemoveAutoTranslateGroupMemoryQQ";
            this.btnRemoveAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveAutoTranslateGroupMemoryQQ.TabIndex = 24;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Text = ">>移除>>";
            this.btnRemoveAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnRemoveAutoTranslateGroupMemoryQQ_Click);
            // 
            // btnAddAutoTranslateGroupMemoryQQ
            // 
            this.btnAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(347, 210);
            this.btnAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddAutoTranslateGroupMemoryQQ.Name = "btnAddAutoTranslateGroupMemoryQQ";
            this.btnAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(88, 23);
            this.btnAddAutoTranslateGroupMemoryQQ.TabIndex = 25;
            this.btnAddAutoTranslateGroupMemoryQQ.Text = "<<添加<<";
            this.btnAddAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnAddAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnAddAutoTranslateGroupMemoryQQ_Click);
            // 
            // lstAutoTranslateGroupMemoriesQQ
            // 
            this.lstAutoTranslateGroupMemoriesQQ.FullRowSelect = true;
            this.lstAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(156, 189);
            this.lstAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstAutoTranslateGroupMemoriesQQ.Name = "lstAutoTranslateGroupMemoriesQQ";
            this.lstAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(167, 85);
            this.lstAutoTranslateGroupMemoriesQQ.TabIndex = 23;
            this.lstAutoTranslateGroupMemoriesQQ.UseCompatibleStateImageBehavior = false;
            this.lstAutoTranslateGroupMemoriesQQ.View = System.Windows.Forms.View.List;
            // 
            // lblAddAutoTranslateGroupMemoryQQ
            // 
            this.lblAddAutoTranslateGroupMemoryQQ.AutoSize = true;
            this.lblAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(453, 189);
            this.lblAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddAutoTranslateGroupMemoryQQ.Name = "lblAddAutoTranslateGroupMemoryQQ";
            this.lblAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(160, 17);
            this.lblAddAutoTranslateGroupMemoryQQ.TabIndex = 21;
            this.lblAddAutoTranslateGroupMemoryQQ.Text = "添加自动翻译群友消息QQ：";
            // 
            // lblAutoTranslateGroupMemoriesQQ
            // 
            this.lblAutoTranslateGroupMemoriesQQ.AutoSize = true;
            this.lblAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(12, 189);
            this.lblAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoTranslateGroupMemoriesQQ.Name = "lblAutoTranslateGroupMemoriesQQ";
            this.lblAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(136, 17);
            this.lblAutoTranslateGroupMemoriesQQ.TabIndex = 22;
            this.lblAutoTranslateGroupMemoriesQQ.Text = "自动翻译群友消息QQ：";
            // 
            // txbTranslateTo
            // 
            this.txbTranslateTo.Enabled = false;
            this.txbTranslateTo.Location = new System.Drawing.Point(197, 105);
            this.txbTranslateTo.Name = "txbTranslateTo";
            this.txbTranslateTo.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateTo.TabIndex = 19;
            // 
            // txbTranslateToChinese
            // 
            this.txbTranslateToChinese.Location = new System.Drawing.Point(197, 76);
            this.txbTranslateToChinese.Name = "txbTranslateToChinese";
            this.txbTranslateToChinese.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateToChinese.TabIndex = 18;
            // 
            // lblTranslateTo
            // 
            this.lblTranslateTo.AutoSize = true;
            this.lblTranslateTo.Enabled = false;
            this.lblTranslateTo.Location = new System.Drawing.Point(12, 108);
            this.lblTranslateTo.Name = "lblTranslateTo";
            this.lblTranslateTo.Size = new System.Drawing.Size(119, 17);
            this.lblTranslateTo.TabIndex = 17;
            this.lblTranslateTo.Text = "翻译为指定语言命令:";
            // 
            // lblTranslateToChinese
            // 
            this.lblTranslateToChinese.AutoSize = true;
            this.lblTranslateToChinese.Location = new System.Drawing.Point(12, 79);
            this.lblTranslateToChinese.Name = "lblTranslateToChinese";
            this.lblTranslateToChinese.Size = new System.Drawing.Size(95, 17);
            this.lblTranslateToChinese.TabIndex = 16;
            this.lblTranslateToChinese.Text = "翻译为中文命令:";
            // 
            // lblTranslateEngineHelp
            // 
            this.lblTranslateEngineHelp.AutoSize = true;
            this.lblTranslateEngineHelp.Location = new System.Drawing.Point(137, 41);
            this.lblTranslateEngineHelp.Name = "lblTranslateEngineHelp";
            this.lblTranslateEngineHelp.Size = new System.Drawing.Size(119, 17);
            this.lblTranslateEngineHelp.TabIndex = 28;
            this.lblTranslateEngineHelp.Text = "谷歌翻译 API 已停用";
            // 
            // CtrlTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txbTranslateFromToCMD);
            this.Controls.Add(this.lblTranslateFromTo);
            this.Controls.Add(this.lblTranslateEngineHelp);
            this.Controls.Add(this.cboTranslateEngine);
            this.Controls.Add(this.lblTranslateEngine);
            this.Controls.Add(this.txbAddAutoTranslateGroupMemoryQQ);
            this.Controls.Add(this.btnRemoveAutoTranslateGroupMemoryQQ);
            this.Controls.Add(this.btnAddAutoTranslateGroupMemoryQQ);
            this.Controls.Add(this.lstAutoTranslateGroupMemoriesQQ);
            this.Controls.Add(this.lblAddAutoTranslateGroupMemoryQQ);
            this.Controls.Add(this.lblAutoTranslateGroupMemoriesQQ);
            this.Controls.Add(this.txbTranslateTo);
            this.Controls.Add(this.txbTranslateToChinese);
            this.Controls.Add(this.lblTranslateTo);
            this.Controls.Add(this.lblTranslateToChinese);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CtrlTranslate";
            this.Size = new System.Drawing.Size(630, 642);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbTranslateFromToCMD;
        private Label lblTranslateFromTo;
        private ComboBox cboTranslateEngine;
        private Label lblTranslateEngine;
        private TextBox txbAddAutoTranslateGroupMemoryQQ;
        private Button btnRemoveAutoTranslateGroupMemoryQQ;
        private Button btnAddAutoTranslateGroupMemoryQQ;
        private ListView lstAutoTranslateGroupMemoriesQQ;
        private Label lblAddAutoTranslateGroupMemoryQQ;
        private Label lblAutoTranslateGroupMemoriesQQ;
        private TextBox txbTranslateTo;
        private TextBox txbTranslateToChinese;
        private Label lblTranslateTo;
        private Label lblTranslateToChinese;
        private Label lblTranslateEngineHelp;
    }
}
