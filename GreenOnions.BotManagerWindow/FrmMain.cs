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
            EventHelper.GetDocumentByBrowserEvent += webBrowserForm.GetDocument;

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
				txbPort.Text = BotInfo.Port.ToString();
				txbVerifyKey.Text = BotInfo.VerifyKey;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"读取配置发生异常，{ex.Message}，请删除应用目录下的config.json和cache.json文件后重启应用。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			#endregion -- 读取配置 --
		}

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
			if (WindowState == FormWindowState.Minimized)
			{
				if (chkMinimizeToTray.Checked)
				{
					Hide();
					ShowInTaskbar = false;
					notifyIcon.Visible = true;
				}
			}
		}

        public async Task ConnectToMiraiApiHttp(long qqId, string ip, ushort port, string verifyKey)
		{
            try
            {
				await BotMain.MiraiApiHttp.Program.Main(qqId, ip, port, verifyKey, (bConnect, nickNameOrErrorMessage) => Invoke(new Action(() => Connecting(bConnect, qqId, ip, port, verifyKey, nickNameOrErrorMessage, "mirai-api-http"))));
			}
            catch (Exception ex)
            {
				LogHelper.WriteErrorLog(ex);
                MessageBox.Show(ex.Message);
            }
		}

		public async Task ConnectToCqHttp(long qqId, string ip, ushort port, string verifyKey)
		{
			try
			{
				await BotMain.CqHttp.Program.Main(qqId, ip, port, verifyKey, (bConnect, nickNameOrErrorMessage) => Invoke(new Action(() => Connecting(bConnect, qqId, ip, port, verifyKey, nickNameOrErrorMessage, "cqhttp"))));
			}
			catch (Exception ex)
			{
				LogHelper.WriteErrorLog(ex);
				MessageBox.Show(ex.Message);
			}
		}

		private void btnDeconnect_Click(object sender, EventArgs e)
		{
			TextReader sr = new StringReader("exit");
			Console.SetIn(sr);

			btnConnectToMiraiApiHttp.Click -= btnDeconnect_Click;
			btnConnectToMiraiApiHttp.Click += btnConnectToMiraiApiHttp_Click;

			btnConnectToCqHttp.Click -= btnDeconnect_Click;
			btnConnectToCqHttp.Click += btnConnectToCqHttp_Click;
		}

		private void btnConnectToMiraiApiHttp_Click(object sender, EventArgs e)
		{
			if (CheckInfo())
			{
				Task.Run(() => ConnectToMiraiApiHttp(Convert.ToInt64(txbQQ.Text), txbIP.Text, Convert.ToUInt16(txbPort.Text), txbVerifyKey.Text));
			}
		}

		private void btnConnectToCqHttp_Click(object sender, EventArgs e)
		{
			if (CheckInfo())
			{
				Task.Run(() => ConnectToCqHttp(Convert.ToInt64(txbQQ.Text), txbIP.Text, Convert.ToUInt16(txbPort.Text), txbVerifyKey.Text));
			}
		}

		private void btnBotSettings_Click(object sender, EventArgs e) => OpenSetting();

        private void OpenSetting() => new FrmAppSetting().ShowDialog();

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
			Visible = true;
			ShowInTaskbar = true;
			WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;
		}

		private void Connecting(bool bConnect, long qqId, string ip, ushort port, string verifyKey, string nickNameOrErrorMessage, string protocol)
        {
			if (bConnect)
			{
				lblState.Text = $"连接状态: 已连接到{protocol}, 登录昵称:{nickNameOrErrorMessage}";
				lblState.ForeColor = Color.Black;

				btnConnectToMiraiApiHttp.Text = "断开连接";
				btnConnectToMiraiApiHttp.Click -= btnConnectToMiraiApiHttp_Click;
				btnConnectToMiraiApiHttp.Click += btnDeconnect_Click;

				btnConnectToCqHttp.Text = "断开连接";
				btnConnectToCqHttp.Click -= btnConnectToCqHttp_Click;
				btnConnectToCqHttp.Click += btnDeconnect_Click;

				notifyIcon.Text = $"葱葱机器人:{nickNameOrErrorMessage}";

				BotInfo.QQId = qqId;
				BotInfo.IP = ip;
				BotInfo.Port = port;
				BotInfo.VerifyKey = verifyKey;
				JsonHelper.SaveConfigFile();

				webBrowserForm.Show();
			}
			else if (nickNameOrErrorMessage == null)  //连接失败且没有异常
			{
				MessageBox.Show($"连接失败，请检查{protocol}是否已经正常启动并已配置IP端口相关参数, 以及机器人QQ是否成功登录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else  //发生异常或主动断开连接
			{
				btnConnectToMiraiApiHttp.Text = "连接到mirai-api-http";
				btnConnectToCqHttp.Text = "连接到cqhttp";
				lblState.Text = $"连接状态: 未连接到{protocol}";
				lblState.ForeColor = Color.Red;
				notifyIcon.Text = $"葱葱机器人";
				if (nickNameOrErrorMessage.Length > 0)  //发生异常
					MessageBox.Show("连接失败，" + nickNameOrErrorMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool CheckInfo()
        {
			if (string.IsNullOrEmpty(txbQQ.Text))
			{
				MessageBox.Show("请先输入机器人QQ号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (string.IsNullOrEmpty(txbIP.Text))
			{
				MessageBox.Show("请先输入机器人框架 IP。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (string.IsNullOrEmpty(txbPort.Text))
			{
				MessageBox.Show("请先输入机器人框架端口号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (string.IsNullOrEmpty(txbVerifyKey.Text))
			{
				MessageBox.Show("请先输入机器人框架连接凭证。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			BotInfo.QQId = Convert.ToInt64(txbQQ.Text);
			BotInfo.IP = txbIP.Text;
            BotInfo.Port = Convert.ToUInt16(txbPort.Text);
            BotInfo.VerifyKey = txbVerifyKey.Text;
			return true;
		}
	}
}
