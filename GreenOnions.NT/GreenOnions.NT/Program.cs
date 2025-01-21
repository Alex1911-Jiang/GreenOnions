using GreenOnions.NT.Base;
using GreenOnions.NT.Core;
using GreenOnions.NT.Core.Models;
using Lagrange.Core;
using Lagrange.Core.Common;
using Lagrange.Core.Common.Interface;
using Lagrange.Core.Common.Interface.Api;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

class Program
{
    static void Main(string[] args)
    {
        Load().ContinueWith(task => ReadCommand(task.Result));
    }

    private static async Task<BotContext> Load()
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
            bot.Invoker.OnFriendMessageReceived += MessageReceived.OnFriendMessage;
            bot.Invoker.OnGroupMessageReceived += MessageReceived.OnGroupMessage;
            bot.Invoker.OnTempMessageReceived += MessageReceived.OnTempMessage;

            PluginManager.LoadAllPlugins(bot);

            File.WriteAllText(botConfigPath, YamlConvert.SerializeObject(botConfig));
            File.WriteAllText(deviceInfoPath, YamlConvert.SerializeObject(deviceInfo));

            //if (string.IsNullOrEmpty(password))  //扫码登录
            //{
            (string Url, byte[] Png)? qrCode = await bot.FetchQrCode();
            if (qrCode is null)
            {
                Console.WriteLine("请求扫码登录接口失败，请重试或使用密码登录");
                goto IL_InputPassword;
            }

            Console.WriteLine(qrCode.Value.Url);
            GenerateQRCode(qrCode.Value.Url);

            Console.WriteLine("扫码成功后请按回车继续");
            Console.ReadLine();

            await bot.LoginByQrCode();
            //}
        }
        else  //自动登录
        {
            bot = BotFactory.Create(botConfig!, deviceInfo!, keystore!);

            bot.Invoker.OnFriendMessageReceived += MessageReceived.OnFriendMessage;
            bot.Invoker.OnGroupMessageReceived += MessageReceived.OnGroupMessage;
            bot.Invoker.OnTempMessageReceived += MessageReceived.OnTempMessage;

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
            return bot;
        }

        Config.SaveConfig();

        Console.WriteLine($"登录成功，机器人昵称：{bot.BotName}");
        keystore = bot.UpdateKeystore();
        File.WriteAllText(keystorePath, YamlConvert.SerializeObject(keystore));
        return bot;
    }

    private static async void ReadCommand(BotContext bot)
    {
        Console.WriteLine("您可以输入：help查询支持的命令");
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
            }
            else if (cmd == "list-plugins")
            {
                Dictionary<string, PluginReleaseInfo>? pluginReleases = await PluginManager.SearchPluginsOnGithub();
                if (pluginReleases is null)
                    continue;
                foreach (var pluginRelease in pluginReleases)
                    Console.WriteLine($"《{pluginRelease.Key}》插件版本号：{pluginRelease.Value.Version}，更新说明：{pluginRelease.Value.Description}");
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
        }
    }


    static void GenerateQRCode(string text)
    {
        var barcodeWriter = new BarcodeWriter<PixelData>()
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Width = 10,
                Height = 10,
                Margin = 1
            },
            Renderer = new PixelDataRenderer(),
        };

        var pixelData = barcodeWriter.Write(text);
        for (int y = 0; y < pixelData.Height; y++)
        {
            for (int x = 0; x < pixelData.Width; x++)
            {
                Console.Write(pixelData.Pixels[(y * pixelData.Width + x) * 4] == 0 ? "██" : "  ");
            }
            Console.WriteLine();
        }
    }
}