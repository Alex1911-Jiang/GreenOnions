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
            this.txbTranslateFromToCMD = new System.Windows.Forms.TextBox();
            this.lblTranslateFromTo = new System.Windows.Forms.Label();
            this.lblTranslateEngineHelp = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // txbTranslateFromToCMD
            // 
            this.txbTranslateFromToCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTranslateFromToCMD.Location = new System.Drawing.Point(316, 189);
            this.txbTranslateFromToCMD.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTranslateFromToCMD.Name = "txbTranslateFromToCMD";
            this.txbTranslateFromToCMD.Size = new System.Drawing.Size(665, 30);
            this.txbTranslateFromToCMD.TabIndex = 30;
            // 
            // lblTranslateFromTo
            // 
            this.lblTranslateFromTo.AutoSize = true;
            this.lblTranslateFromTo.Location = new System.Drawing.Point(25, 193);
            this.lblTranslateFromTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateFromTo.Name = "lblTranslateFromTo";
            this.lblTranslateFromTo.Size = new System.Drawing.Size(266, 24);
            this.lblTranslateFromTo.TabIndex = 29;
            this.lblTranslateFromTo.Text = "从指定语言翻译为指定语言命令:";
            // 
            // lblTranslateEngineHelp
            // 
            this.lblTranslateEngineHelp.AutoSize = true;
            this.lblTranslateEngineHelp.Location = new System.Drawing.Point(221, 58);
            this.lblTranslateEngineHelp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateEngineHelp.Name = "lblTranslateEngineHelp";
            this.lblTranslateEngineHelp.Size = new System.Drawing.Size(587, 24);
            this.lblTranslateEngineHelp.TabIndex = 28;
            this.lblTranslateEngineHelp.Text = "提示: 谷歌翻译 Api 需翻墙，有道翻译识别语言经常出错，建议手动指定)";
            // 
            // cboTranslateEngine
            // 
            this.cboTranslateEngine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTranslateEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranslateEngine.FormattingEnabled = true;
            this.cboTranslateEngine.Items.AddRange(new object[] {
            "Google",
            "YouDao"});
            this.cboTranslateEngine.Location = new System.Drawing.Point(221, 18);
            this.cboTranslateEngine.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboTranslateEngine.Name = "cboTranslateEngine";
            this.cboTranslateEngine.Size = new System.Drawing.Size(760, 32);
            this.cboTranslateEngine.TabIndex = 27;
            this.cboTranslateEngine.SelectedIndexChanged += new System.EventHandler(this.cboTranslateEngine_SelectedIndexChanged);
            // 
            // lblTranslateEngine
            // 
            this.lblTranslateEngine.AutoSize = true;
            this.lblTranslateEngine.Location = new System.Drawing.Point(25, 22);
            this.lblTranslateEngine.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateEngine.Name = "lblTranslateEngine";
            this.lblTranslateEngine.Size = new System.Drawing.Size(86, 24);
            this.lblTranslateEngine.TabIndex = 26;
            this.lblTranslateEngine.Text = "翻译引擎:";
            // 
            // txbAddAutoTranslateGroupMemoryQQ
            // 
            this.txbAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(721, 296);
            this.txbAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6);
            this.txbAddAutoTranslateGroupMemoryQQ.Name = "txbAddAutoTranslateGroupMemoryQQ";
            this.txbAddAutoTranslateGroupMemoryQQ.ShortcutsEnabled = false;
            this.txbAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(260, 30);
            this.txbAddAutoTranslateGroupMemoryQQ.TabIndex = 20;
            // 
            // btnRemoveAutoTranslateGroupMemoryQQ
            // 
            this.btnRemoveAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(551, 340);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Name = "btnRemoveAutoTranslateGroupMemoryQQ";
            this.btnRemoveAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(138, 32);
            this.btnRemoveAutoTranslateGroupMemoryQQ.TabIndex = 24;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Text = ">>移除>>";
            this.btnRemoveAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnRemoveAutoTranslateGroupMemoryQQ_Click);
            // 
            // btnAddAutoTranslateGroupMemoryQQ
            // 
            this.btnAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(551, 296);
            this.btnAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddAutoTranslateGroupMemoryQQ.Name = "btnAddAutoTranslateGroupMemoryQQ";
            this.btnAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(138, 32);
            this.btnAddAutoTranslateGroupMemoryQQ.TabIndex = 25;
            this.btnAddAutoTranslateGroupMemoryQQ.Text = "<<添加<<";
            this.btnAddAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnAddAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnAddAutoTranslateGroupMemoryQQ_Click);
            // 
            // lstAutoTranslateGroupMemoriesQQ
            // 
            this.lstAutoTranslateGroupMemoriesQQ.FullRowSelect = true;
            this.lstAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(251, 267);
            this.lstAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(6);
            this.lstAutoTranslateGroupMemoriesQQ.Name = "lstAutoTranslateGroupMemoriesQQ";
            this.lstAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(260, 118);
            this.lstAutoTranslateGroupMemoriesQQ.TabIndex = 23;
            this.lstAutoTranslateGroupMemoriesQQ.UseCompatibleStateImageBehavior = false;
            this.lstAutoTranslateGroupMemoriesQQ.View = System.Windows.Forms.View.List;
            // 
            // lblAddAutoTranslateGroupMemoryQQ
            // 
            this.lblAddAutoTranslateGroupMemoryQQ.AutoSize = true;
            this.lblAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(718, 267);
            this.lblAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddAutoTranslateGroupMemoryQQ.Name = "lblAddAutoTranslateGroupMemoryQQ";
            this.lblAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(238, 24);
            this.lblAddAutoTranslateGroupMemoryQQ.TabIndex = 21;
            this.lblAddAutoTranslateGroupMemoryQQ.Text = "添加自动翻译群友消息QQ：";
            // 
            // lblAutoTranslateGroupMemoriesQQ
            // 
            this.lblAutoTranslateGroupMemoriesQQ.AutoSize = true;
            this.lblAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(25, 267);
            this.lblAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAutoTranslateGroupMemoriesQQ.Name = "lblAutoTranslateGroupMemoriesQQ";
            this.lblAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(202, 24);
            this.lblAutoTranslateGroupMemoriesQQ.TabIndex = 22;
            this.lblAutoTranslateGroupMemoriesQQ.Text = "自动翻译群友消息QQ：";
            // 
            // txbTranslateTo
            // 
            this.txbTranslateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTranslateTo.Location = new System.Drawing.Point(316, 148);
            this.txbTranslateTo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTranslateTo.Name = "txbTranslateTo";
            this.txbTranslateTo.Size = new System.Drawing.Size(665, 30);
            this.txbTranslateTo.TabIndex = 19;
            // 
            // txbTranslateToChinese
            // 
            this.txbTranslateToChinese.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTranslateToChinese.Location = new System.Drawing.Point(316, 107);
            this.txbTranslateToChinese.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txbTranslateToChinese.Name = "txbTranslateToChinese";
            this.txbTranslateToChinese.Size = new System.Drawing.Size(665, 30);
            this.txbTranslateToChinese.TabIndex = 18;
            // 
            // lblTranslateTo
            // 
            this.lblTranslateTo.AutoSize = true;
            this.lblTranslateTo.Location = new System.Drawing.Point(25, 152);
            this.lblTranslateTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateTo.Name = "lblTranslateTo";
            this.lblTranslateTo.Size = new System.Drawing.Size(176, 24);
            this.lblTranslateTo.TabIndex = 17;
            this.lblTranslateTo.Text = "翻译为指定语言命令:";
            // 
            // lblTranslateToChinese
            // 
            this.lblTranslateToChinese.AutoSize = true;
            this.lblTranslateToChinese.Location = new System.Drawing.Point(25, 111);
            this.lblTranslateToChinese.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTranslateToChinese.Name = "lblTranslateToChinese";
            this.lblTranslateToChinese.Size = new System.Drawing.Size(140, 24);
            this.lblTranslateToChinese.TabIndex = 16;
            this.lblTranslateToChinese.Text = "翻译为中文命令:";
            // 
            // CtrlTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
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
            this.Name = "CtrlTranslate";
            this.Size = new System.Drawing.Size(1012, 906);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbTranslateFromToCMD;
        private Label lblTranslateFromTo;
        private Label lblTranslateEngineHelp;
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
    }
}
