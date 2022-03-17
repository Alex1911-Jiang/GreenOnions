using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenOnions.BotManagerWindow
{
    public partial class FrmMain : Form
	{
		private WebBrowserForm webBrowserForm;
		public FrmMain()
		{
			InitializeComponent();

            webBrowserForm = new WebBrowserForm();
            EventHelper.GetDocumentByBrowserEvent += webBrowserForm.GetDocumentAsync;

			#region -- 读取配置 --
			try
			{
				if (!File.Exists(JsonHelper.JsonConfigFileName))
				{
					MessageBox.Show("初次使用本机器人，请先配置相关参数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					OpenSetting();
				}
				if (!File.Exists(JsonHelper.JsonCacheFileName))
					JsonHelper.CreateCache();

				txbQQ.Text = BotInfo.QQId.ToString();
				txbIP.Text = BotInfo.IP;
				txbPort.Text = BotInfo.Port;
				txbVerifyKey.Text = BotInfo.VerifyKey;
			}
			catch (Exception ex)
			{
				throw new Exception("读取配置发生异常，请删除应用目录下的config.json文件后重启应用。" + ex.Message);
			}
			#endregion -- 读取配置 --
		}

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
			if (WindowState == FormWindowState.Minimized)
			{
				Hide();
				ShowInTaskbar = false;
				notifyIcon.Visible = true;
			}
		}

        public async Task Main(long qqId, string ip, int port, string verifyKey)
		{
			await BotMain.Program.Main(qqId, ip, port, verifyKey, (bConnect, nickNameOrErrorMessage) =>
			{
				Invoke(new Action(() =>
				{
					if (bConnect)
					{
						lblState.Text = $"连接状态: 已连接到mirai-api-http, 登录昵称:{nickNameOrErrorMessage}";
						lblState.ForeColor = Color.Black;
						btnConnect.Text = "断开连接";
						btnConnect.Click -= btnConnect_Click;
						btnConnect.Click += btnDeconnect_Click;
						notifyIcon.Text = $"葱葱机器人:{nickNameOrErrorMessage}";

						BotInfo.QQId = qqId;
						BotInfo.IP = ip;
						BotInfo.Port = port.ToString();
						BotInfo.VerifyKey = verifyKey;
						JsonHelper.SaveConfigFile();

                        webBrowserForm.CreateHandle();
                    }
					else if (nickNameOrErrorMessage == null)  //连接失败且没有异常
					{
						MessageBox.Show("连接失败，请检查Mirai是否已经正常启动并已配置mirai-api-http相关参数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else  //发生异常或主动断开连接
					{
						btnConnect.Text = "连接到mirai-api-http";
						lblState.Text = "连接状态: 未连接到mirai-api-http";
						lblState.ForeColor = Color.Red;
						notifyIcon.Text = $"葱葱机器人";
						if (nickNameOrErrorMessage.Length > 0)  //发生异常
                            MessageBox.Show("连接失败，" + nickNameOrErrorMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}));
            });
		}

		private void btnDeconnect_Click(object sender, EventArgs e)
		{
			TextReader sr = new StringReader("exit");
			Console.SetIn(sr);

			btnConnect.Click -= btnDeconnect_Click;
			btnConnect.Click += btnConnect_Click;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txbQQ.Text))
				{
					MessageBox.Show("请先输入机器人QQ号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (string.IsNullOrEmpty(txbIP.Text))
				{
					MessageBox.Show("请先输入mirai-api-http host IP。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (string.IsNullOrEmpty(txbPort.Text))
				{
					MessageBox.Show("请先输入mirai-api-http端口号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (string.IsNullOrEmpty(txbVerifyKey.Text))
				{
					MessageBox.Show("请先输入mirai-api-http verifyKey。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				BotInfo.QQId = Convert.ToInt64(txbQQ.Text);
				BotInfo.IP = txbIP.Text;
				BotInfo.Port = txbPort.Text;
				BotInfo.VerifyKey = txbVerifyKey.Text;

				Task.Run(() => Main(Convert.ToInt64(txbQQ.Text), txbIP.Text, Convert.ToInt32(txbPort.Text), txbVerifyKey.Text));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnBotSettings_Click(object sender, EventArgs e) => OpenSetting();

		private void OpenSetting()
		{
			FrmAppSetting frmAppSetting = new FrmAppSetting();
			frmAppSetting.ShowDialog();
		}

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
			Visible = true;
			ShowInTaskbar = true;
			WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;
		}
    }
}
