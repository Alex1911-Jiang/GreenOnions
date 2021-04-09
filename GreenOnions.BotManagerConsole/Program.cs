using GreenOnions.BotMain;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai_CSharp;
using Mirai_CSharp.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.BotManagerConsole
{
	public static class Program
	{
		public static async Task Main()
		{
			AppDomain.CurrentDomain.UnhandledException += (_,e) => ErrorHelper.WriteErrorLog(e.ExceptionObject);

			Console.WriteLine("葱葱机器人");

			if (!File.Exists(Cache.JsonConfigFileName))
			{
				AssemblyHelper.CreateConfig();
				Console.WriteLine("初次使用本机器人，请先设置config.json相关参数。");
			}

			await using MiraiHttpSession session = new MiraiHttpSession();
			session.AddPlugin(new TempMessage());
			session.AddPlugin(new FriendMessage());
			session.AddPlugin(new GroupMessage());

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
			Console.WriteLine("请输入mirai-api-http autoKey:");
			string autoKey = Console.ReadLine();

			MiraiHttpSessionOptions options = new MiraiHttpSessionOptions(ip, port, autoKey);
			bool retry = false;
			await session.ConnectAsync(options, qqId).ContinueWith(callback =>
			{
				if (callback.IsFaulted)
				{
					retry = true;
					Console.WriteLine("连接失败，请检查Mirai是否已经正常启动并已配置mirai-api-http相关参数，按任意键重试。");
				}
			});

			if (retry)
			{
				Console.ReadKey();
				goto ILRetry;
			}

			Cache.SetTaskAtFixedTime();

			string nickname = (await session.GetFriendListAsync()).Where(m => m.Id == qqId).FirstOrDefault().Name;

			Console.WriteLine($"已连接到mirai-api-http, 登录昵称:{nickname}, 输入exit或按下Ctrl+C断开连接。");

			while (true)
			{
				if (await Console.In.ReadLineAsync() == "exit")
				{
					return;
				}
				Task.Delay(100).Wait();
			}
		}
    }
}
