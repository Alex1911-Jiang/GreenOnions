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
			Console.WriteLine("葱葱机器人");

			if (!File.Exists(Cache.JsonConfigFileName))
			{
				Console.WriteLine("初次使用本机器人，请先设置config.json相关参数。");
			}

			Console.WriteLine("请输入机器人QQ号:");
			long qqId = Convert.ToInt64(Console.ReadLine());
			Console.WriteLine("请输入mirai-api-http host IP:");
			string ip = Console.ReadLine();
			Console.WriteLine("请输入mirai-api-http端口:");
			int port = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("请输入mirai-api-http autoKey:");
			string autoKey = Console.ReadLine();

			ConfigHelper.ReadConfig();

			MiraiHttpSessionOptions options = new MiraiHttpSessionOptions(ip, port, autoKey);
			await using MiraiHttpSession session = new MiraiHttpSession();
			session.AddPlugin(new GroupMessage());
			bool stop = false;
			await session.ConnectAsync(options, qqId).ContinueWith(callback =>
			{
				if (callback.IsFaulted)
				{
					stop = true;
					Console.WriteLine("连接失败，请检查Mirai是否已经正常启动并已配置mirai-api-http相关参数。");
				}
			});

			if (stop) return;

			Cache.SetTaskAtFixedTime();

			string nickname = (await session.GetFriendListAsync()).Where(m => m.Id == qqId).FirstOrDefault().Name;

			Console.WriteLine($"已连接到mirai-api-http, 登录昵称:{nickname}, 输入exit或按下Ctrl+C断开连接。");

			while (true)
			{
				if (await Console.In.ReadLineAsync() == "exit")
				{
					return;
				}
			}
		}
    }
}
