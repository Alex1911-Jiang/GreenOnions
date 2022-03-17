namespace GreenOnions.BotManagerWindow
{
    partial class WebBrowserForm
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
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.pnlText.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(800, 350);
            this.pnlBrowser.TabIndex = 0;
            // 
            // pnlText
            // 
            this.pnlText.Controls.Add(this.txbMessage);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlText.Location = new System.Drawing.Point(0, 350);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(800, 100);
            this.pnlText.TabIndex = 1;
            // 
            // txbMessage
            // 
            this.txbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMessage.Location = new System.Drawing.Point(0, 0);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(800, 100);
            this.txbMessage.TabIndex = 0;
            // 
            // WebBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBrowser);
            this.Controls.Add(this.pnlText);
            this.Name = "WebBrowserForm";
            this.Text = "WebBrowserForm";
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.TextBox txbMessage;
    }
}