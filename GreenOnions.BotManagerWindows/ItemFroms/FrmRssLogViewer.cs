using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using GreenOnions.RSS;

namespace GreenOnions.BotManagerWindows.ItemFroms
{
    public partial class FrmRssLogViewer : Form
    {
        private bool _run = false;
        private List<string> _logs = new List<string>();
        private Task? _task1 = null;
        private Task? _task2 = null;
        public FrmRssLogViewer()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            _run = true;
            base.OnShown(e);
            _task1 = Task.Run(async () =>
            {
                while (_run)
                {
                    Dictionary<string, string> taskStatus = RssHelper.GetTaskStatus();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Url");
                    dt.Columns.Add("Status");
                    foreach (var item in taskStatus)
                        dt.Rows.Add(item.Key, item.Value);
                    try
                    {
                        Invoke(new Action(() => dgvTaskStatus.DataSource = dt));
                    }
                    catch
                    {
                        return;
                    }
                    await Task.Delay(1000);
                }
            });

            _task2 = Task.Run(async () =>
            {
                while (_run)
                {
                    if (RssHelper.Logs is not null)
                    {
                        while (RssHelper.Logs.TryDequeue(out string? logMessage))
                        {
                            if (!string.IsNullOrEmpty(logMessage))
                            {
                                _logs.Add(logMessage);
                                if (!_run)
                                    return;
                                try
                                {
                                    Invoke(new Action(() =>
                                    {
                                        string logLine = $"{logMessage}\n";
                                        txbLogs.AppendText(logLine);
                                        txbLogs.Select(txbLogs.Text.Length - logLine.Length, logLine.Length);
                                        if (logMessage.StartsWith("警告"))
                                            txbLogs.SelectionColor = Color.Yellow;
                                        else if (logMessage.StartsWith("错误"))
                                            txbLogs.SelectionColor = Color.Red;
                                        else
                                            txbLogs.SelectionColor = Color.Black;
                                        txbLogs.Select(txbLogs.TextLength, 0);
                                        txbLogs.ScrollToCaret();
                                    }));
                                }
                                catch
                                {
                                    return;
                                }
                            }
                        }
                    }
                    await Task.Yield();
                }
            });
        }

        protected override async void OnClosing(CancelEventArgs e)
        {
            _run = false;
            await _task1!;
            await _task2!;
            RssHelper.Logs = new ConcurrentQueue<string>(_logs);
            base.OnClosing(e);
        }
    }
}
