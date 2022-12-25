﻿using System;
using System.IO;
using System.Threading.Tasks;
using GreenOnions.BotMain;
using GreenOnions.BotMain.CqHttp;
using GreenOnions.BotMain.KonataCore;
using GreenOnions.BotMain.MiraiApiHttp;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotManagerConsole
{
	public static class Program
	{
        public static void Main()
        {
            MainAsync();
        }

		public static async void MainAsync()
		{
            AppDomain.CurrentDomain.UnhandledException += (_, e) => LogHelper.WriteErrorLog(e.ExceptionObject);

            Console.WriteLine("葱葱机器人");

            if (!File.Exists("config.json"))
            {
                BotInfo.CreateConfig();
                Console.WriteLine("初次使用本机器人，请先设置config.json相关参数后继续以下步骤。");
            }

            Console.WriteLine("有任何疑问，意见或建议欢迎到 https://github.com/Alex1911-Jiang/GreenOnions 提Issue");

            Console.WriteLine($"成功加载{PluginManager.Load()}个插件");

            //if (BotInfo.Config.AutoConnectEnabled)
            //{
            //	Console.WriteLine($"启用了自动连接, {BotInfo.Config.AutoConnectDelay}秒后自动连接到{(BotInfo.Config.AutoConnectProtocol == 0 ? "Mirai-Api-Http" : "CqHttp")}平台");
            //	Console.WriteLine($"如果要取消自动连接, 请将 config.json 中 Bot.AutoConnectEnabled 修改为 False");
            //	Task.Delay(BotInfo.Config.AutoConnectDelay * 1000).Wait();
            //	if (BotInfo.Config.AutoConnectProtocol == BotProtocol.mirai_api_http)
            //	{
            //		try
            //		{
            //			_ = MiraiApiHttpMain.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.Config.AutoConnectProtocol, "mirai-api-http"));
            //		}
            //		catch (Exception ex)
            //		{
            //			LogHelper.WriteErrorLogWithUserMessage("连接到mirai-api-http发生异常", ex);
            //			Console.WriteLine("连接mirai-api-http失败，" + ex.Message);
            //		}
            //	}
            //	else if(BotInfo.Config.AutoConnectProtocol == BotProtocol.OneBot)
            //	{
            //		try
            //		{
            //			_ = OneBotMain.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.Config.AutoConnectProtocol, "cqhttp"));
            //		}
            //		catch (Exception ex)
            //		{
            //			LogHelper.WriteErrorLogWithUserMessage("连接到cqhttp发生异常", ex);
            //			Console.WriteLine("连接cqhttp失败，" + ex.Message);
            //		}
            //	}
            //}
            //else
            //{
            Console.WriteLine("请选择连接平台: 0 = mirai-api-http,  1 = cqhttp, 2 = 内置Konata");
        ILRetryProtocol:;
            if (!int.TryParse(Console.ReadLine(), out int protocol) || protocol < 0 || protocol > 2)
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

            Task clientTask = null;

            if (protocol == 2)
            {
                Console.WriteLine("请输入密码:");
                string password = Console.ReadLine();
                await LoginByKonataCore();
            }
            else
            {
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
                        BotInfo.Config.QQId = qqId;
                        BotInfo.Config.IP = ip;
                        BotInfo.Config.Port = port;
                        BotInfo.Config.VerifyKey = verifyKey;
                        WorkingTimeRecorder.DoWork = true;
                        Console.CancelKeyPress -= Console_CancelKeyPress;
                        Console.CancelKeyPress += Console_CancelKeyPress;
                        clientTask = ConnectToMiraiApiHttp();
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
                        BotInfo.Config.QQId = qqId;
                        BotInfo.Config.IP = ip;
                        BotInfo.Config.Port = port;
                        BotInfo.Config.VerifyKey = accessToken;
                        WorkingTimeRecorder.DoWork = true;
                        Console.CancelKeyPress -= Console_CancelKeyPress;
                        Console.CancelKeyPress += Console_CancelKeyPress;
                        clientTask = ConnectToOneBot();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("连接cqhttp发生异常", ex);
                        Console.WriteLine("连接cqhttp失败，" + ex.Message);
                    }
                }
            }

            BotInfo.SaveConfigFile();
            clientTask?.ContinueWith(_ => Environment.Exit(0));
            //}
            while (true)
            {
                string cmd = Console.ReadLine();
                if (string.Equals(cmd, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
        }

		private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			WorkingTimeRecorder.DoWork = false;
			TextReader sr = new StringReader("exit");
			Console.SetIn(sr);
			e.Cancel = true;
		}

        private static async Task LoginByKonataCore()
        {
            await KonataCoreMain.Login(BotInfo.Config.QQId, BotInfo.Config.Password,
                    msg => 
					{
						Console.WriteLine(msg);
						return Console.ReadLine();
					},
                    msg => 
					{
						Console.WriteLine(msg);
						Console.ReadLine();
                    },
                    msg => Console.WriteLine(msg));
        }

        private static async Task ConnectToMiraiApiHttp()
		{
			await MiraiApiHttpMain.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotProtocol.mirai_api_http, "mirai-api-http"));
		}

		private static async Task ConnectToOneBot()
		{
			await OneBotMain.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey, (bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotProtocol.OneBot, "cqhttp"));
		}

		private static void Connecting(bool bConnect, string nickNameOrErrorMessage, BotProtocol platform, string protocol)
		{
			if (bConnect)
			{
				Console.WriteLine($"连接状态: 已连接到{protocol}, 登录昵称:{nickNameOrErrorMessage}");
				WorkingTimeRecorder.StartRecord(platform, ConnectToPlatform, Disconnected);
			}
			else if (nickNameOrErrorMessage is null)  //连接失败且没有异常
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

		private static void ConnectToPlatform(BotProtocol platform)
		{
			switch (platform)
			{
				case BotProtocol.mirai_api_http:
					_ = ConnectToMiraiApiHttp();
					break;
				case BotProtocol.OneBot:
					_ = ConnectToOneBot();
					break;
			}
		}
	}
}
