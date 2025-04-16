using GreenOnions.NT.Base;
using GreenOnions.NT.Core;
using GreenOnions.NT.Core.Models;
using Lagrange.Core;
using Lagrange.Core.Common;
using Lagrange.Core.Common.Interface;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Event.EventArg;
using Lagrange.Core.Message;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

class Program
{
    static async Task Main(string[] args)
    {
        Config.LoadConfig();

        string botConfigPath = Path.Combine(AppContext.BaseDirectory, "botConfig.yml");
        BotConfig? botConfig = null;
        if (File.Exists(botConfigPath))
        {
            string yamlBotConfig = File.ReadAllText(botConfigPath);
            botConfig = YamlConvert.DeserializeObject<BotConfig>(yamlBotConfig);
        }
        bool noBotConfig = botConfig is null;

        string deviceInfoPath = Path.Combine(AppContext.BaseDirectory, "device.yml");
        BotDeviceInfo? deviceInfo = null;
        if (File.Exists(deviceInfoPath))
        {
            string yamlDeviceInfo = File.ReadAllText(deviceInfoPath);
            deviceInfo = YamlConvert.DeserializeObject<BotDeviceInfo>(yamlDeviceInfo);
        }
        bool noDeviceInfo = deviceInfo is null;

        string keystorePath = Path.Combine(AppContext.BaseDirectory, "keystore.yml");
        BotKeystore? keystore = null;
        if (File.Exists(keystorePath))
        {
            string keystoreInfo = File.ReadAllText(keystorePath);
            keystore = YamlConvert.DeserializeObject<BotKeystore>(keystoreInfo);
        }
        bool noKeystore = keystore is null;

        Console.WriteLine("欢迎使用葱葱机器人NT");

        await PluginManager.UpgradePlugins();

        BotContext bot;
        if (noBotConfig || noDeviceInfo || noKeystore)
        {
        IL_InputUin:
            Console.WriteLine("请输入QQ号：");
            string? strUin = Console.ReadLine();
            uint uin = 0;
            if (!uint.TryParse(strUin, out uin))
            {
                Console.WriteLine("QQ号只能是数字，请重新输入");
                goto IL_InputUin;
            }

        IL_InputPassword:
            //Console.WriteLine("请输入密码，或直接回车使用扫码登录：");
            //string? password = Console.ReadLine();
            string password = "";

            botConfig = new BotConfig();
            bot = BotFactory.Create(botConfig, uin, password, out deviceInfo);
            bot.Invoker.OnBotLogEvent += OnLog;

            PluginManager.LoadAllPlugins(bot);

            File.WriteAllText(botConfigPath, YamlConvert.SerializeObject(botConfig));
            File.WriteAllText(deviceInfoPath, YamlConvert.SerializeObject(deviceInfo));

            //if (string.IsNullOrEmpty(password))  //扫码登录
            //{
            (string Url, byte[] Png)? qrCode = await bot.FetchQrCode();
            if (qrCode is null)
            {
                Console.WriteLine("请求扫码登录接口失败，请重试");
                goto IL_InputPassword;
            }

            Console.WriteLine("由于部分命令行存在输出字符变为全角的问题，请根据以下提示选择二维码方块渲染宽度");
        IL_ReselectRectWidth:
            Console.WriteLine("██  ← 如果你看到了一个正方形（或两个竖着的长方形）请输入1，如果看到了两个正方形，请输入2");
            string? rectWidth = Console.ReadLine();
            if (string.IsNullOrEmpty(rectWidth) || !int.TryParse(rectWidth, out int width) || width < 1 || width > 2)
            {
                Console.WriteLine("方块渲染宽度选择错误，请重新输入");
                goto IL_ReselectRectWidth;
            }

            Console.WriteLine(qrCode.Value.Url);
            GenerateQRCode(qrCode.Value.Url, width);

            Console.WriteLine("扫码成功后请按回车继续（如果二维码显示不正常，尝试选择另一种宽度）");
            Console.ReadLine();

            await bot.LoginByQrCode();
            //}
        }
        else  //自动登录
        {
            bot = BotFactory.Create(botConfig!, deviceInfo!, keystore!);
            bot.Invoker.OnBotLogEvent += OnLog;

            PluginManager.LoadAllPlugins(bot);

            Console.WriteLine("尝试使用Keystore自动登录，如果长时间未出现登录成功，请删除keystore.yml后重新登录");
        }
        SngletonInstance.Bot = bot;

        bool loginSuccess = await bot.LoginByPassword();
        if (!loginSuccess)
        {
            Console.WriteLine("登录失败，请重试或尝试使用其他方式登录");
            if (File.Exists(keystorePath))
                File.Delete(keystorePath);
            Environment.Exit(0);
            return;
        }

        Config.SaveConfig();

        Console.WriteLine($"登录成功，机器人昵称：{bot.BotName}");
        keystore = bot.UpdateKeystore();
        File.WriteAllText(keystorePath, YamlConvert.SerializeObject(keystore));

        Dictionary<string, PluginReleaseInfo> pluginReleases = await PluginManager.SearchPluginsOnGithub();

        foreach (var pluginRelease in pluginReleases)
        {
            if (SngletonInstance.Plugins.TryGetValue(pluginRelease.Value.PackageName, out IPlugin? lastPlugin) && pluginRelease.Value.Version > lastPlugin.GetVersion())
                Console.WriteLine($"《{pluginRelease.Key}》（{pluginRelease.Value.PackageName}）插件有新版本：{pluginRelease.Value.Version} 可更新");
        }

        ReadCommand(bot);
    }

    private static async void ReadCommand(BotContext bot)
    {
        Console.WriteLine("您可以输入：help 查询支持的命令");
        while (true)
        {
            string? cmd = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cmd))
            {
                continue;
            }
            else if (cmd == "help")
            {
                Console.WriteLine(@"支持以下命令：
list-plugins : 在Github查找葱葱官方提供的插件列表
install-plugin <插件名称> : 在Github下载该插件并安装(或更新到最新版本)
reload-config : 重新加载配置文件
send-friend-message <好友QQ号> <消息内容> : 向好友发送消息
send-group-message <群号> <消息内容>: 向群发送消息
upload-friend-file <好友QQ号> <文件完整路径> : 向好友发送文件
upload-group-file <群号> <文件完整路径> : 向群发送文件
exit : 退出葱葱");
            }
            else if (cmd == "exit")
            {
                Environment.Exit(0);
                return;
            }
            else if (cmd == "reload-config")
            {
                Config.LoadConfig();
                Console.WriteLine("已重新加载配置文件");
            }
            else if (cmd == "list-plugins")
            {
                Dictionary<string, PluginReleaseInfo>? pluginReleases = await PluginManager.SearchPluginsOnGithub();
                if (pluginReleases is null)
                    continue;
                foreach (var pluginRelease in pluginReleases)
                    Console.WriteLine($"《{pluginRelease.Key}》（{pluginRelease.Value.PackageName}）插件版本号：{pluginRelease.Value.Version}，更新说明：{pluginRelease.Value.Description}");
            }
            else if (cmd.StartsWith("install-plugin"))
            {
                string pluginName = cmd.Substring("install-plugin".Length).Trim();
                var result = await PluginManager.InstallPlugin(pluginName);
                if (!result.Success)
                {
                    Console.WriteLine(result.Message);
                    continue;
                }
                PluginManager.LoadOncePlugin(result.Data!, bot);
            }
            else if (cmd.StartsWith("send-friend-message"))
            {
                string[] args = cmd.Substring("send-friend-message".Length).Trim().Split(' ');
                if (args.Length < 2)
                {
                    Console.WriteLine("参数错误，请输入好友QQ号和消息内容");
                    continue;
                }
                if (!uint.TryParse(args[0], out uint friendUin))
                {
                    Console.WriteLine("参数错误，QQ号不合法");
                    continue;
                }
                string message = string.Join(' ', args.Skip(1));
                Console.WriteLine($"向好友{friendUin}发送消息：{message}");
                MessageBuilder builder = MessageBuilder.Friend(friendUin);
                builder.Text(message);
                await bot.SendMessage(builder.Build());
            }
            else if (cmd.StartsWith("send-group-message"))
            {
                string[] args = cmd.Substring("send-group-message".Length).Trim().Split(' ');
                if (args.Length < 2)
                {
                    Console.WriteLine("参数错误，请输入群号和消息内容");
                    continue;
                }
                if (!uint.TryParse(args[0], out uint groupUin))
                {
                    Console.WriteLine("参数错误，群号不合法");
                    continue;
                }
                string message = string.Join(' ', args.Skip(1));
                Console.WriteLine($"向群{groupUin}发送消息：{message}");
                MessageBuilder builder = MessageBuilder.Group(groupUin);
                builder.Text(message);
                await bot.SendMessage(builder.Build());
            }
            else if (cmd.StartsWith("upload-friend-file"))
            {
                string[] args = cmd.Substring("upload-friend-file".Length).Trim().Split(' ');
                if (args.Length < 2)
                {
                    Console.WriteLine("参数错误，请输入好友QQ号和文件路径");
                    continue;
                }
                if (!uint.TryParse(args[0], out uint friendUin))
                {
                    Console.WriteLine("参数错误，QQ号不合法");
                    continue;
                }
                string fileName = string.Join(' ', args.Skip(1));
                Console.WriteLine($"向好友{friendUin}发送文件：{fileName}");
                await bot.UploadFriendFile(friendUin, new Lagrange.Core.Message.Entity.FileEntity(fileName));
            }
            else if (cmd.StartsWith("upload-group-file"))
            {
                string[] args = cmd.Substring("upload-group-file".Length).Trim().Split(' ');
                if (args.Length < 2)
                {
                    Console.WriteLine("参数错误，请输入好友群号和文件路径");
                    continue;
                }
                if (!uint.TryParse(args[0], out uint groupUin))
                {
                    Console.WriteLine("参数错误，群号不合法");
                    continue;
                }
                string fileName = string.Join(' ', args.Skip(1));
                Console.WriteLine($"向群{groupUin}发送文件：{fileName}");
                await bot.GroupFSUpload(groupUin, new Lagrange.Core.Message.Entity.FileEntity(fileName));
            }
        }
    }

    private static void OnLog(BotContext context, BotLogEvent e)
    {
        switch (e.Level)
        {
            case LogLevel.Debug:
                //LogHelper.LogDebug(e.EventMessage);
                break;
            case LogLevel.Verbose:
                LogHelper.LogDebug(e.EventMessage);
                break;
            case LogLevel.Information:
                LogHelper.LogMessage(e.EventMessage);
                break;
            case LogLevel.Warning:
                LogHelper.LogWarning(e.EventMessage);
                break;
            case LogLevel.Exception:
                LogHelper.LogError(e.EventMessage);
                break;
            case LogLevel.Fatal:
                LogHelper.LogError(e.EventMessage);
                break;
        }
    }

    private static void GenerateQRCode(string text, int rectWidth)
    {
        var barcodeWriter = new BarcodeWriter<PixelData>()
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Width = 8,
                Height = 8,
                Margin = 1
            },
            Renderer = new PixelDataRenderer(),
        };

        string rect = rectWidth == 1 ? "██" : "█";  //█■??
        var pixelData = barcodeWriter.Write(text);
        for (int y = 0; y < pixelData.Height; y++)
        {
            for (int x = 0; x < pixelData.Width; x++)
            {
                Console.Write(pixelData.Pixels[(y * pixelData.Width + x) * 4] == 0 ? rect : "  ");
            }
            Console.WriteLine();
        }
    }
}