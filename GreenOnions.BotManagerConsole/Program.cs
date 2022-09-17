using System;
using System.IO;
using System.Threading.Tasks;
using GreenOnions.BotMain;
using GreenOnions.BotMain.CqHttp;
using GreenOnions.BotMain.MiraiApiHttp;
using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotManagerConsole
{
    public static class Program
	{
		public static async Task Main()
		{
			AppDomain.CurrentDomain.UnhandledException += (_, e) => LogHelper.WriteErrorLog(e.ExceptionObject);

			Console.WriteLine("葱葱机器人");

			if (!File.Exists(JsonHelper.JsonConfigFileName))
			{
				ConfigHelper.CreateConfig();
				Console.WriteLine("初次使用本机器人，请先设置config.json相关参数后继续以下步骤。");
			}
			if (!File.Exists(JsonHelper.JsonCacheFileName))
				ConfigHelper.CreateCache();

			Console.WriteLine("有任何疑问，意见或建议欢迎到 https://github.com/Alex1911-Jiang/GreenOnions 提Issue");

            Console.WriteLine($"成功加载{PluginManager.Load()}个插件");

			if (BotInfo.AutoConnectEnabled)
			{
                Console.WriteLine($"启用了自动连接, {BotInfo.AutoConnectDelay}秒后自动连接到{(BotInfo.AutoConnectProtocol == 0 ? "Mirai-Api-Http" : "CqHttp")}平台");
				Console.WriteLine($"如果要取消自动连接, 请将 config.json 中 Bot.AutoConnectEnabled 修改为 False");
				Task.Delay(BotInfo.AutoConnectDelay * 1000).Wait();
				if (BotInfo.AutoConnectProtocol == 0)
				{
					try
					{
                        await MiraiApiHttpMain.Connect(BotInfo.QQId, BotInfo.IP, BotInfo.Port, BotInfo.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.AutoConnectProtocol, "mirai-api-http"));
                    }
					catch (Exception ex)
					{
						LogHelper.WriteErrorLogWithUserMessage("连接到mirai-api-http发生异常", ex);
						Console.WriteLine("连接mirai-api-http失败，" + ex.Message);
					}
				}
				else
				{
					try
					{
                        await CqHttpMain.Connect(BotInfo.QQId, BotInfo.IP, BotInfo.Port, BotInfo.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.AutoConnectProtocol, "cqhttp"));
                    }
					catch (Exception ex)
					{
						LogHelper.WriteErrorLogWithUserMessage("连接到cqhttp发生异常", ex);
						Console.WriteLine("连接cqhttp失败，" + ex.Message);
					}
				}
			}
			else
            {
				Console.WriteLine("请选择连接平台: 0 = mirai-api-http,  1 = cqhttp");
			ILRetryProtocol:;
				if (!int.TryParse(Console.ReadLine(), out int protocol) || protocol < 0 || protocol > 1)
				{
					Console.WriteLine("选择的平台不正确, 请重新选择。");
					goto ILRetryProtocol;
				}

				Console.WriteLine("请输入机器人QQ号:");
			ILRetryQQ:;
				if (!long.TryParse(Console.ReadLine(), out long qqId))
				{
					Console.WriteLine("输入的QQ号不正确，请重新输入。");
					goto ILRetryQQ;
				}

				Console.WriteLine("请输入连接 IP:");
				string ip = Console.ReadLine();

				Console.WriteLine("请输入连接端口:");
			ILReadPort:;
				if (!ushort.TryParse(Console.ReadLine(), out ushort port) || port < 0 || port > 65535)
				{
					Console.WriteLine("输入的端口号不正确，请重新输入:");
					goto ILReadPort;
				}

				if (protocol == 0)
				{
					Console.WriteLine("请输入mirai-api-http verifyKey:");
					string verifyKey = Console.ReadLine();
                    try
                    {
						BotInfo.QQId = qqId;
						BotInfo.IP = ip;
						BotInfo.Port = port;
						BotInfo.VerifyKey = verifyKey;
						WorkingTimeRecorder.DoWork = true;
						Console.CancelKeyPress -= Console_CancelKeyPress;
						Console.CancelKeyPress += Console_CancelKeyPress;
						ConnectToMiraiApiHttp();
					}
					catch (Exception ex)
                    {
						LogHelper.WriteErrorLogWithUserMessage("连接mirai-api-http发生异常", ex);
						Console.WriteLine("连接mirai-api-http发生异常" + ex.Message);
                    }
				}
				else
				{
					Console.WriteLine("请输入cqhttp access-token:");
					string accessToken = Console.ReadLine();
					try
					{
						BotInfo.QQId = qqId;
						BotInfo.IP = ip;
						BotInfo.Port = port;
						BotInfo.VerifyKey = accessToken;
						WorkingTimeRecorder.DoWork = true;
						Console.CancelKeyPress -= Console_CancelKeyPress;
						Console.CancelKeyPress += Console_CancelKeyPress;
						ConnectToCqHttp();
					}
					catch (Exception ex)
					{
						LogHelper.WriteErrorLogWithUserMessage("连接cqhttp发生异常", ex);
						Console.WriteLine("连接cqhttp失败，" + ex.Message);
					}
				}
			}
			Console.ReadLine();
		}

		private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			WorkingTimeRecorder.DoWork = false;
			TextReader sr = new StringReader("exit");
			Console.SetIn(sr);
			e.Cancel = true;
		}

        private async static void ConnectToMiraiApiHttp()
        {
            await MiraiApiHttpMain.Connect(BotInfo.QQId, BotInfo.IP, BotInfo.Port, BotInfo.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, 0, "mirai-api-http"));
        }

        private async static void ConnectToCqHttp()
        {
            await CqHttpMain.Connect(BotInfo.QQId, BotInfo.IP, BotInfo.Port, BotInfo.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, 1, "cqhttp"));
        }

		private static void Connecting(bool bConnect, string nickNameOrErrorMessage, int platform, string protocol)
        {
			if (bConnect)
			{
				Console.WriteLine($"连接状态: 已连接到{protocol}, 登录昵称:{nickNameOrErrorMessage}");
				WorkingTimeRecorder.StartRecord(platform, ConnectToPlatform, Disconnected);
			}
			else if (nickNameOrErrorMessage == null)  //连接失败且没有异常
				Console.WriteLine($"连接失败，请检查{protocol}是否已经正常启动并已配置IP端口相关参数, 以及机器人QQ是否成功登录。");
			else  //发生异常
				if (nickNameOrErrorMessage.Length > 0)
				Console.WriteLine("连接失败，" + nickNameOrErrorMessage);
		}

		private static void Disconnected()
        {
			TextReader sr = new StringReader("exit");
			Console.SetIn(sr);
		}

		private static void ConnectToPlatform(int platform)
		{
			switch (platform)
			{
				case 0:
					ConnectToMiraiApiHttp();
					break;
				case 1:
					ConnectToCqHttp();
					break;
			}
		}
	}
}
