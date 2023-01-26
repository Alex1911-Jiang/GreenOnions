using System.ComponentModel;

namespace GreenOnions.BotManagerWindows.ItemFroms
{
    public partial class FrmRssHeders : Form
    {
        public Dictionary<string,string>? Headers { get; set; }

        public FrmRssHeders(Dictionary<string, string>? rssHeders)
        {
            Headers = rssHeders;
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (Headers is not null)
            {
                foreach (var header in Headers)
                    dgvHeader.Rows.Add(header.Key, header.Value);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            dgvHeader.EndEdit();
            if (Headers is null)
                Headers = new Dictionary<string, string>();
            for (int i = 0; i < dgvHeader.Rows.Count; i++)
            {
                string? headerKey = dgvHeader.Rows[i].Cells[0].Value?.ToString();
                if (headerKey is not null)
                {
                    string? headerValue = dgvHeader.Rows[i].Cells[1].Value?.ToString();
                    Headers[headerKey] =  headerValue ?? string.Empty;
                }
            }
            base.OnClosing(e);
        }
    }
}
