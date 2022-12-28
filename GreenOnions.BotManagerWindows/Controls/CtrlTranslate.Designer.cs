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
            this.txbTranslateAPPID = new System.Windows.Forms.TextBox();
            this.lblTranslateAPPID = new System.Windows.Forms.Label();
            this.txbTranslateAPPKey = new System.Windows.Forms.TextBox();
            this.lblTranslateAPPKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbTranslateFromToCMD
            // 
            this.txbTranslateFromToCMD.Location = new System.Drawing.Point(197, 188);
            this.txbTranslateFromToCMD.Name = "txbTranslateFromToCMD";
            this.txbTranslateFromToCMD.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateFromToCMD.TabIndex = 30;
            // 
            // lblTranslateFromTo
            // 
            this.lblTranslateFromTo.AutoSize = true;
            this.lblTranslateFromTo.Location = new System.Drawing.Point(12, 191);
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
            "谷歌网页翻译(已失效)",
            "有道网页翻译(爬虫)",
            "有道智云API",
            "百度翻译API"});
            this.cboTranslateEngine.Location = new System.Drawing.Point(197, 13);
            this.cboTranslateEngine.Name = "cboTranslateEngine";
            this.cboTranslateEngine.Size = new System.Drawing.Size(425, 25);
            this.cboTranslateEngine.TabIndex = 27;
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
            this.txbAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(455, 264);
            this.txbAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddAutoTranslateGroupMemoryQQ.Name = "txbAddAutoTranslateGroupMemoryQQ";
            this.txbAddAutoTranslateGroupMemoryQQ.ShortcutsEnabled = false;
            this.txbAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(167, 23);
            this.txbAddAutoTranslateGroupMemoryQQ.TabIndex = 20;
            // 
            // btnRemoveAutoTranslateGroupMemoryQQ
            // 
            this.btnRemoveAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(347, 295);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAutoTranslateGroupMemoryQQ.Name = "btnRemoveAutoTranslateGroupMemoryQQ";
            this.btnRemoveAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveAutoTranslateGroupMemoryQQ.TabIndex = 24;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Text = ">>移除>>";
            this.btnRemoveAutoTranslateGroupMemoryQQ.UseVisualStyleBackColor = true;
            this.btnRemoveAutoTranslateGroupMemoryQQ.Click += new System.EventHandler(this.btnRemoveAutoTranslateGroupMemoryQQ_Click);
            // 
            // btnAddAutoTranslateGroupMemoryQQ
            // 
            this.btnAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(347, 264);
            this.btnAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4);
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
            this.lstAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(156, 243);
            this.lstAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(4);
            this.lstAutoTranslateGroupMemoriesQQ.Name = "lstAutoTranslateGroupMemoriesQQ";
            this.lstAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(167, 85);
            this.lstAutoTranslateGroupMemoriesQQ.TabIndex = 23;
            this.lstAutoTranslateGroupMemoriesQQ.UseCompatibleStateImageBehavior = false;
            this.lstAutoTranslateGroupMemoriesQQ.View = System.Windows.Forms.View.List;
            // 
            // lblAddAutoTranslateGroupMemoryQQ
            // 
            this.lblAddAutoTranslateGroupMemoryQQ.AutoSize = true;
            this.lblAddAutoTranslateGroupMemoryQQ.Location = new System.Drawing.Point(453, 243);
            this.lblAddAutoTranslateGroupMemoryQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddAutoTranslateGroupMemoryQQ.Name = "lblAddAutoTranslateGroupMemoryQQ";
            this.lblAddAutoTranslateGroupMemoryQQ.Size = new System.Drawing.Size(160, 17);
            this.lblAddAutoTranslateGroupMemoryQQ.TabIndex = 21;
            this.lblAddAutoTranslateGroupMemoryQQ.Text = "添加自动翻译群友消息QQ：";
            // 
            // lblAutoTranslateGroupMemoriesQQ
            // 
            this.lblAutoTranslateGroupMemoriesQQ.AutoSize = true;
            this.lblAutoTranslateGroupMemoriesQQ.Location = new System.Drawing.Point(12, 243);
            this.lblAutoTranslateGroupMemoriesQQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoTranslateGroupMemoriesQQ.Name = "lblAutoTranslateGroupMemoriesQQ";
            this.lblAutoTranslateGroupMemoriesQQ.Size = new System.Drawing.Size(136, 17);
            this.lblAutoTranslateGroupMemoriesQQ.TabIndex = 22;
            this.lblAutoTranslateGroupMemoriesQQ.Text = "自动翻译群友消息QQ：";
            // 
            // txbTranslateTo
            // 
            this.txbTranslateTo.Location = new System.Drawing.Point(197, 159);
            this.txbTranslateTo.Name = "txbTranslateTo";
            this.txbTranslateTo.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateTo.TabIndex = 19;
            // 
            // txbTranslateToChinese
            // 
            this.txbTranslateToChinese.Location = new System.Drawing.Point(197, 130);
            this.txbTranslateToChinese.Name = "txbTranslateToChinese";
            this.txbTranslateToChinese.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateToChinese.TabIndex = 18;
            // 
            // lblTranslateTo
            // 
            this.lblTranslateTo.AutoSize = true;
            this.lblTranslateTo.Location = new System.Drawing.Point(12, 162);
            this.lblTranslateTo.Name = "lblTranslateTo";
            this.lblTranslateTo.Size = new System.Drawing.Size(119, 17);
            this.lblTranslateTo.TabIndex = 17;
            this.lblTranslateTo.Text = "翻译为指定语言命令:";
            // 
            // lblTranslateToChinese
            // 
            this.lblTranslateToChinese.AutoSize = true;
            this.lblTranslateToChinese.Location = new System.Drawing.Point(12, 133);
            this.lblTranslateToChinese.Name = "lblTranslateToChinese";
            this.lblTranslateToChinese.Size = new System.Drawing.Size(95, 17);
            this.lblTranslateToChinese.TabIndex = 16;
            this.lblTranslateToChinese.Text = "翻译为中文命令:";
            // 
            // lblTranslateEngineHelp
            // 
            this.lblTranslateEngineHelp.AutoSize = true;
            this.lblTranslateEngineHelp.Location = new System.Drawing.Point(197, 41);
            this.lblTranslateEngineHelp.Name = "lblTranslateEngineHelp";
            this.lblTranslateEngineHelp.Size = new System.Drawing.Size(212, 17);
            this.lblTranslateEngineHelp.TabIndex = 28;
            this.lblTranslateEngineHelp.Text = "有道网页翻译（爬虫）只支持中英互译";
            // 
            // txbTranslateAPPID
            // 
            this.txbTranslateAPPID.Location = new System.Drawing.Point(197, 61);
            this.txbTranslateAPPID.Name = "txbTranslateAPPID";
            this.txbTranslateAPPID.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateAPPID.TabIndex = 32;
            // 
            // lblTranslateAPPID
            // 
            this.lblTranslateAPPID.AutoSize = true;
            this.lblTranslateAPPID.Location = new System.Drawing.Point(12, 64);
            this.lblTranslateAPPID.Name = "lblTranslateAPPID";
            this.lblTranslateAPPID.Size = new System.Drawing.Size(46, 17);
            this.lblTranslateAPPID.TabIndex = 31;
            this.lblTranslateAPPID.Text = "APPID:";
            // 
            // txbTranslateAPPKey
            // 
            this.txbTranslateAPPKey.Location = new System.Drawing.Point(197, 90);
            this.txbTranslateAPPKey.Name = "txbTranslateAPPKey";
            this.txbTranslateAPPKey.Size = new System.Drawing.Size(425, 23);
            this.txbTranslateAPPKey.TabIndex = 34;
            // 
            // lblTranslateAPPKey
            // 
            this.lblTranslateAPPKey.AutoSize = true;
            this.lblTranslateAPPKey.Location = new System.Drawing.Point(12, 93);
            this.lblTranslateAPPKey.Name = "lblTranslateAPPKey";
            this.lblTranslateAPPKey.Size = new System.Drawing.Size(54, 17);
            this.lblTranslateAPPKey.TabIndex = 33;
            this.lblTranslateAPPKey.Text = "APPKey:";
            // 
            // CtrlTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txbTranslateAPPKey);
            this.Controls.Add(this.lblTranslateAPPKey);
            this.Controls.Add(this.txbTranslateAPPID);
            this.Controls.Add(this.lblTranslateAPPID);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private TextBox txbTranslateAPPID;
        private Label lblTranslateAPPID;
        private TextBox txbTranslateAPPKey;
        private Label lblTranslateAPPKey;
    }
}
