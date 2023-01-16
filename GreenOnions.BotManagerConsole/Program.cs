namespace GreenOnions.BotManagerConsole
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using GreenOnions.BotMain;
    using GreenOnions.BotMain.CqHttp;
    using GreenOnions.BotMain.MiraiApiHttp;
    using GreenOnions.Utility;
    using GreenOnions.Utility.Helper;

    public static class Program
    {
        private static MiraiClient? _miraiClient;
        static async Task Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (_, e) => LogHelper.WriteErrorLog(e.ExceptionObject);

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
            BotInfo.LoadConfig();

            Console.WriteLine("有任何疑问，意见或建议欢迎到 https://github.com/Alex1911-Jiang/GreenOnions 提Issue");

            Console.WriteLine($"成功加载{PluginManager.Load()}个插件");

            if (BotInfo.Config.AutoConnectEnabled)
            {
                Console.WriteLine($"启用了自动连接, {BotInfo.Config.AutoConnectDelay}秒后自动连接到{(BotInfo.Config.AutoConnectProtocol == 0 ? "Mirai-Api-Http" : "CqHttp")}平台");
                Console.WriteLine($"如果要取消自动连接, 请将 config.json 中 Bot.AutoConnectEnabled 修改为 False");
                Task.Delay(BotInfo.Config.AutoConnectDelay * 1000).Wait();

                if (BotInfo.Config.AutoConnectProtocol == 0)
                {
                    _miraiClient = new MiraiApiHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.Config.AutoConnectProtocol, "mirai-api-http"));

                    try
                    {
                        await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("连接到mirai-api-http发生异常", ex);
                        Console.WriteLine("连接mirai-api-http失败，" + ex.Message);
                    }
                }
                else
                {
                    _miraiClient = new CqHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, BotInfo.Config.AutoConnectProtocol, "cqhttp"));
                    try
                    {
                        await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
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
                    try
                    {
                        BotInfo.Config.QQId = qqId;
                        BotInfo.Config.IP = ip;
                        BotInfo.Config.Port = port;
                        BotInfo.Config.VerifyKey = verifyKey;
                        WorkingTimeRecorder.DoWork = true;
                        Console.CancelKeyPress -= Console_CancelKeyPress;
                        Console.CancelKeyPress += Console_CancelKeyPress;
                        _miraiClient = new MiraiApiHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, 0, "mirai-api-http"));
                        await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
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
                    string? accessToken = Console.ReadLine();
                    try
                    {
                        BotInfo.Config.QQId = qqId;
                        BotInfo.Config.IP = ip;
                        BotInfo.Config.Port = port;
                        BotInfo.Config.VerifyKey = accessToken;
                        WorkingTimeRecorder.DoWork = true;
                        Console.CancelKeyPress -= Console_CancelKeyPress;
                        Console.CancelKeyPress += Console_CancelKeyPress;
                        _miraiClient = new CqHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, 1, "cqhttp"));
                        await _miraiClient.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage("连接cqhttp发生异常", ex);
                        Console.WriteLine("连接cqhttp失败，" + ex.Message);
                    }
                }
                BotInfo.SaveConfigFile();
            }

            while (true)
            {
                string? cmd = Console.ReadLine();
                if (string.Equals(cmd, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    _miraiClient?.Disconnect();
                    return;
                }
                await Task.Delay(100);
            }
        }
        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            Disconnected();
            e.Cancel = true;
        }

        private static void Connecting(bool bConnect, string nickNameOrErrorMessage, int platform, string protocol)
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
            WorkingTimeRecorder.DoWork = false;
            _miraiClient?.Disconnect();
        }

        private static async void ConnectToPlatform(int platform)
        {
            MiraiClient client = platform switch
            {
                0 => new MiraiApiHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, 0, "mirai-api-http")),
                1 => new CqHttpClient((bConnect, nickNameOrErrorMessage) => Connecting(bConnect, nickNameOrErrorMessage, 1, "cqhttp")),
                _ => throw new NotImplementedException(),
            };
            await client.Connect(BotInfo.Config.QQId, BotInfo.Config.IP, BotInfo.Config.Port, BotInfo.Config.VerifyKey);
        }
    }
}