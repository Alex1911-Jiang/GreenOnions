using System.ComponentModel;

namespace GreenOnions.BotManagerWindows.ItemFroms
{
    public partial class FrmRssFromat : Form
    {
        public string[] Format { get; private set; }
        public FrmRssFromat(string[] format)
        {
            InitializeComponent();
            txbFormat.Text = string.Join("\r\n", format);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Format = txbFormat.Text.Replace('\r', '\n').Replace("\n\n", "\n").Split('\n');
        }
    }
}
