using GreenOnions.BotMain;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenOnions.BotMainManagerWindow
{
    public partial class FrmMain : Form
	{
		public FrmMain()
        {
            InitializeComponent();
			#region -- 读取配置 --
			try
			{
				if (!File.Exists(Cache.JsonConfigFileName))
				{
					MessageBox.Show("初次使用本机器人，请先配置相关参数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					OpenSetting();
				}

				txbQQ.Text = BotInfo.QQId.ToString();
				txbIP.Text = BotInfo.IP;
				txbPort.Text = BotInfo.Port;
				txbAutoKey.Text = BotInfo.AutoKey;
			}
			catch (Exception ex)
			{
				throw new Exception("读取配置发生异常，请删除应用目录下的config.json文件后重启应用。" + ex.Message);
			}
			#endregion -- 读取配置 --
		}

        public async Task Main(long qqId, string ip, int port, string autoKey)
		{
			MiraiHttpSessionOptions options = new MiraiHttpSessionOptions(ip, port, autoKey);
			await using MiraiHttpSession session = new MiraiHttpSession();
			session.AddPlugin(new TempMessage());
			session.AddPlugin(new FriendMessage());
			session.AddPlugin(new GroupMessage());
			bool stop = false;
			await session.ConnectAsync(options, qqId).ContinueWith(callback =>
			{
                if (callback.IsFaulted)
                {
					stop = true;
					MessageBox.Show("连接失败，请检查Mirai是否已经正常启动并已配置mirai-api-http相关参数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
			});

			if (stop) return;

			Cache.SetTaskAtFixedTime();

			string nickname = (await session.GetFriendListAsync()).Where(m => m.Id == qqId).FirstOrDefault().Name;

			Invoke(new Action(() =>
			{
				lblState.Text = $"连接状态: 已连接到mirai-api-http, 登录昵称:{nickname}";
				lblState.ForeColor = Color.Black;
				btnConnect.Text = "断开连接";
				btnConnect.Click -= btnConnect_Click;
				btnConnect.Click += btnDeconnect_Click;
			}));

			while (true)
			{
				if (await Console.In.ReadLineAsync() == "exit")
				{
					Invoke(new Action(() =>
					{
						btnConnect.Text = "连接到mirai-api-http";
						lblState.Text = "连接状态: 未连接到mirai-api-http";
						lblState.ForeColor = Color.Red;
					}));
					return;
				}
			}
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
				if (string.IsNullOrEmpty(txbAutoKey.Text))
				{
					MessageBox.Show("请先输入mirai-api-http authKey。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				BotInfo.QQId = Convert.ToInt64(txbQQ.Text);
				BotInfo.IP = txbIP.Text;
				BotInfo.Port = txbPort.Text;
				BotInfo.AutoKey = txbAutoKey.Text;

				Task.Run(() => Main(Convert.ToInt64(txbQQ.Text), txbIP.Text, Convert.ToInt32(txbPort.Text), txbAutoKey.Text));
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
    }
}
