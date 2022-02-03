using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GreenOnions.BotManagerConsole
{
    public static class Program
	{
		public static async Task Main()
		{
			AppDomain.CurrentDomain.UnhandledException += (_, e) => ErrorHelper.WriteErrorLog(e.ExceptionObject);

			Console.WriteLine("葱葱机器人");

			if (!File.Exists(JsonHelper.JsonConfigFileName))
			{
				JsonHelper.CreateConfig();
				Console.WriteLine("初次使用本机器人，请先设置config.json相关参数。");
			}
			if (!File.Exists(JsonHelper.JsonCacheFileName))
				JsonHelper.CreateCache();

			ILRetry:;
			Console.WriteLine("请输入机器人QQ号:");
			long qqId = 0;
			if (!long.TryParse(Console.ReadLine(), out qqId))
			{
				Console.WriteLine("输入的QQ号不正确，请重新输入。");
				goto ILRetry;
			}
			Console.WriteLine("请输入mirai-api-http host IP:");
			string ip = Console.ReadLine();
		ILReadPort:;
			Console.WriteLine("请输入mirai-api-http端口:");
			int port = 0;
			if (!int.TryParse(Console.ReadLine(), out port) || port < 0 || port > 65535)
			{
				Console.WriteLine("输入的端口号不正确，请重新输入:");
				goto ILReadPort;
			}
			Console.WriteLine("请输入mirai-api-http verifyKey:");
			string verifyKey = Console.ReadLine();

			await BotMain.Program.Main(qqId, ip, port, verifyKey, (bConnect, nickNameOrErrorMessage) =>
			{
				if (bConnect)
				{
					Console.WriteLine($"连接状态: 已连接到mirai-api-http, 登录昵称:{nickNameOrErrorMessage}");
				}
				else if (nickNameOrErrorMessage == null)  //连接失败且没有异常
				{
					Console.WriteLine("连接失败，请检查Mirai是否已经正常启动并已配置mirai-api-http相关参数。");
				}
				else  //发生异常
				{
					if (nickNameOrErrorMessage.Length > 0)
					{
						Console.WriteLine("连接失败，" + nickNameOrErrorMessage);
					}
				}
			});
		}
	}
}
