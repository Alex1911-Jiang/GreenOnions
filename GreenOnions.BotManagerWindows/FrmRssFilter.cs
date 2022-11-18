namespace GreenOnions.BotManagerWindows
{
    public partial class FrmRssFilter : Form
    {
        public int FilterMode => Convert.ToInt32(Controls.OfType<RadioButton>().Where(r => r.Checked).First().Tag);

        public string[] FilterKeyWords => txbFilterKeyWords.Text.Replace("\r","").Split('\n');

        public FrmRssFilter(int filterMode, string[] filterKeyWords)
        {
            InitializeComponent();
            Controls.OfType<RadioButton>().Where(r => Convert.ToInt32(r.Tag) == filterMode).First().Checked = true;
            if (filterKeyWords is not null)
                txbFilterKeyWords.Text = string.Join("\r\n", filterKeyWords);
        }
    }
}
