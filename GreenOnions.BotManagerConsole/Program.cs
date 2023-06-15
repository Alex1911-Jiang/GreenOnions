namespace GreenOnions.BotManagerConsole
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using GreenOnions.BotMain;
    using GreenOnions.BotMain.OneBot;
    using GreenOnions.BotMain.MiraiApiHttp;
    using GreenOnions.Utility;
    using GreenOnions.Utility.Helper;
    using GreenOnions.Interface.Configs.Enums;
    using GreenOnions.BotMain.Go_CqHttp;

    public static class Program
    {
        private static MiraiClient? _miraiClient;
        static async Task Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (_, e) => LogHelper.WriteErrorLog("全局捕获异常", e.ExceptionObject);

            Console.WriteLine("葱葱机器人");

            if (!File.Exists("config.json"))
            {
                BotInfo.Init();

                Console.WriteLine("初次使用本机器人，请先输入机器人管理员的QQ：（方便后续通过消息修改配置，如果不想设置可以直接回车跳过）");
            IL_SetAdminQQ:;
                string? strAdminQQ = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(strAdminQQ))
                {
                    if (!long.TryParse(strAdminQQ, out long adminQQ))
                    {
                        Console.WriteLine("输入错误，请重试或留空跳过");
                        goto IL_SetAdminQQ;
                    }
                }
                Console.WriteLine("请先修改config.json相关参数后继续以下步骤，或直接回车以默认参数启动。");
                Console.ReadLine();
            }

            Console.WriteLine("有任何疑问，意见或建议欢迎到 https://github.com/Alex1911-Jiang/GreenOnions 提Issue");

            Console.WriteLine($"成功加载{PluginManager.Load()}个插件");

            if (BotInfo.Config.AutoConnectEnabled)
            {
                Console.WriteLine($"启用了自动连接, {BotInfo.Config.AutoConnectDelay}秒后自动连接到{BotInfo.Config.AutoConnectProtocol}平台");
                Console.WriteLine($"如果要取消自动连接, 请将 config.json 中 Bot.AutoConnectEnabled 修改为 False");
                Task.Delay(BotInfo.Config.AutoConnectDelay * 1000).Wait();

                switch (BotInfo.Config.AutoConnectProtocol)
                {
                    case BotPlatform.Mirai_Api_Http:
                        _miraiClient = new MiraiApiHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.Config.AutoConnectProtocol));
                        try
                        {
                            await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteErrorLog("连接到mirai-api-http发生异常", ex);
                            Console.WriteLine("连接mirai-api-http失败，" + ex.Message);
                        }
                        break;
                    case BotPlatform.OneBot:
                        _miraiClient = new OneBotClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.Config.AutoConnectProtocol));
                        try
                        {
                            await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteErrorLog("连接到OneBot发生异常", ex);
                            Console.WriteLine("连接OneBot失败，" + ex.Message);
                        }
                        break;
                    case BotPlatform.GoCqhttp:
                        _miraiClient = new Go_CqHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.Config.AutoConnectProtocol));
                        try
                        {
                            await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteErrorLog("连接到go-cqhttp发生异常", ex);
                            Console.WriteLine("连接go-cqhttp失败，" + ex.Message);
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("请选择连接平台: 0 = mirai-api-http,  1 = OneBot, 2 = go-cqhttp");
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

                Console.WriteLine("请输入连接 IP:");
            IL_RetryIP:;
                string? ip = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ip))
                {
                    Console.WriteLine("输入的IP不合法，请重新输入。");
                    goto IL_RetryIP;
                }

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
                    string? verifyKey = Console.ReadLine();
                    verifyKey ??= string.Empty;
                    try
                    {
                        BotInfo.Config.QQId = qqId;
                        BotInfo.Config.IP = ip;
                        BotInfo.Config.Port = port;
                        BotInfo.Config.VerifyKey = verifyKey;
                        Console.CancelKeyPress -= Console_CancelKeyPress;
                        Console.CancelKeyPress += Console_CancelKeyPress;
                        _miraiClient = new MiraiApiHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotPlatform.Mirai_Api_Http));
                        await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLog("连接mirai-api-http发生异常", ex);
                        Console.WriteLine("连接mirai-api-http发生异常" + ex.Message);
                        Environment.Exit(0);
                    }
                }
                else if (protocol == 1)
                {
                    Console.WriteLine("请输入OneBot access-token:");
                    string? accessToken = Console.ReadLine();
                    try
                    {
                        BotInfo.Config.QQId = qqId;
                        BotInfo.Config.IP = ip;
                        BotInfo.Config.Port = port;
                        BotInfo.Config.VerifyKey = accessToken;
                        Console.CancelKeyPress -= Console_CancelKeyPress;
                        Console.CancelKeyPress += Console_CancelKeyPress;
                        _miraiClient = new OneBotClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotPlatform.OneBot));
                        await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLog("连接OneBot发生异常", ex);
                        Console.WriteLine("连接OneBot失败，" + ex.Message);
                        Environment.Exit(0);
                    }
                }
                else if (protocol == 2)
                {
                    Console.WriteLine("请输入go-cqhttp access-token:");
                    string? accessToken = Console.ReadLine();
                    try
                    {
                        BotInfo.Config.QQId = qqId;
                        BotInfo.Config.IP = ip;
                        BotInfo.Config.Port = port;
                        BotInfo.Config.VerifyKey = accessToken;
                        Console.CancelKeyPress -= Console_CancelKeyPress;
                        Console.CancelKeyPress += Console_CancelKeyPress;
                        _miraiClient = new Go_CqHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotPlatform.GoCqhttp));
                        await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLog("连接go-cqhttp发生异常", ex);
                        Console.WriteLine("连接go-cqhttp失败，" + ex.Message);
                        Environment.Exit(0);
                    }
                }
                BotInfo.SaveConfigFile();
            }

            while (true)
            {
                string? cmd = Console.ReadLine();
                if (string.Equals(cmd, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Exit();
                    return;
                }
                ExecuteCommand(cmd);
                await Task.Delay(100);
            }
        }

        private static void ExecuteCommand(string cmd)
        {
            if (string.IsNullOrEmpty(cmd))
                return;
            if (string.Equals(cmd,"ReloadConfig", StringComparison.OrdinalIgnoreCase))
            {
                PluginManager.ReloadAllPluginsConfig();
                Console.WriteLine("重新加载配置文件成功");
                return;
            }
            Console.WriteLine(Command.CommandEditor.HandleCommand(cmd, MessageHandler.UpdateRegexs));
        }

        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            Exit();
        }

        private static void Exit()
        {
            Disconnected();
            Environment.Exit(0);
        }

        private static void Connecting(bool bConnect, string nickNameOrErrorMessage, BotPlatform platform)
        {
            if (bConnect)
            {
                Console.WriteLine($"已连接到{platform}, 登录昵称:{nickNameOrErrorMessage}, 如果要断开连接, 请输入exit");
                WorkingTimeRecorder.StartRecord(platform, ConnectToPlatform, Disconnected);
            }
            else if (nickNameOrErrorMessage is null)  //连接失败且没有异常
                Console.WriteLine($"连接失败，请检查{platform}是否已经正常启动并已配置IP端口相关参数, 以及机器人QQ是否成功登录。");
            else  //发生异常
                if (nickNameOrErrorMessage.Length > 0)
                Console.WriteLine("连接失败，" + nickNameOrErrorMessage);
        }

        private static void Disconnected()
        {
            Console.WriteLine($"主动调用断开连接");
            _miraiClient?.Disconnect();
            Console.WriteLine($"已断开连接");
        }

        private static async void ConnectToPlatform(BotPlatform platform)
        {
            MiraiClient client = platform switch
            {
                BotPlatform.Mirai_Api_Http => new MiraiApiHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, platform)),
                BotPlatform.OneBot => new OneBotClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, platform)),
                _ => throw new NotImplementedException(),
            };
            await client.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
        }
    }
}