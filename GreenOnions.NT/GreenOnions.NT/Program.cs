using GreenOnions.NT.Base;
using GreenOnions.NT.Core;
using Lagrange.Core;
using Lagrange.Core.Common;
using Lagrange.Core.Common.Interface;
using Lagrange.Core.Common.Interface.Api;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

class Program
{
    static async Task Main(string[] args)
    {
        Config.LoadConfig();

        string botConfigDirect = Path.Combine(AppContext.BaseDirectory, "botConfig.yml");
        BotConfig? botConfig = null;
        if (File.Exists(botConfigDirect))
        {
            string yamlBotConfig = File.ReadAllText(botConfigDirect);
            botConfig = YamlConvert.DeserializeObject<BotConfig>(yamlBotConfig);
        }
        bool noBotConfig = botConfig is null;

        string deviceInfoDirect = Path.Combine(AppContext.BaseDirectory, "device.yml");
        BotDeviceInfo? deviceInfo = null;
        if (File.Exists(deviceInfoDirect))
        {
            string yamlDeviceInfo = File.ReadAllText(deviceInfoDirect);
            deviceInfo = YamlConvert.DeserializeObject<BotDeviceInfo>(yamlDeviceInfo);
        }
        bool noDeviceInfo = deviceInfo is null;

        string keystoreDirect = Path.Combine(AppContext.BaseDirectory, "keystore.yml");
        BotKeystore? keystore = null;
        if (File.Exists(keystoreDirect))
        {
            string keystoreInfo = File.ReadAllText(keystoreDirect);
            keystore = YamlConvert.DeserializeObject<BotKeystore>(keystoreInfo);
        }
        bool noKeystore = keystore is null;

        Console.WriteLine("欢迎使用葱葱机器人NT");

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
            Console.WriteLine("请输入密码，或直接回车使用扫码登录：");
            string? password = Console.ReadLine();

            botConfig = new BotConfig();
            bot = BotFactory.Create(botConfig, uin, password!, out deviceInfo);

            bot.Invoker.OnFriendMessageReceived += MessageReceived.OnFriendMessage;
            bot.Invoker.OnGroupMessageReceived += MessageReceived.OnGroupMessage;
            bot.Invoker.OnTempMessageReceived += MessageReceived.OnTempMessage;

            PluginManager.Load(bot);

            File.WriteAllText(botConfigDirect, YamlConvert.SerializeObject(botConfig));
            File.WriteAllText(deviceInfoDirect, YamlConvert.SerializeObject(deviceInfo));

            if (string.IsNullOrEmpty(password))  //扫码登录
            {
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
            }
        }
        else  //自动登录
        {
            bot = BotFactory.Create(botConfig!, deviceInfo!, keystore!);

            bot.Invoker.OnFriendMessageReceived += MessageReceived.OnFriendMessage;
            bot.Invoker.OnGroupMessageReceived += MessageReceived.OnGroupMessage;
            bot.Invoker.OnTempMessageReceived += MessageReceived.OnTempMessage;

            PluginManager.Load(bot);
        }

        bool loginSuccess = await bot.LoginByPassword();
        if (!loginSuccess)
        {
            Console.WriteLine("登录失败，请重试或尝试使用其他方式登录");
            if (File.Exists(keystoreDirect))
                File.Delete(keystoreDirect);
            Environment.Exit(0);
            return;
        }

        Config.SaveConfig();

        Console.WriteLine($"登录成功，机器人昵称：{bot.BotName}");
        keystore = bot.UpdateKeystore();
        File.WriteAllText(keystoreDirect, YamlConvert.SerializeObject(keystore));
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