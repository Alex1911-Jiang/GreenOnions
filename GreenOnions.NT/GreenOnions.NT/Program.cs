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
    public static byte[] GenerateRandomMACAddress()
    {
        byte[] macAddress = new byte[6];
        new Random().NextBytes(macAddress);
        return macAddress;
    }

    static async Task Main(string[] args)
    {
        Config.LoadConfig();
        BotConfig botConfig = Config.Instance.BotConfig ?? new BotConfig();

        string deviceInfoDirect = Path.Combine(AppContext.BaseDirectory, "device.yml");
        BotDeviceInfo? device = null;
        if (File.Exists(deviceInfoDirect))
        {
            string deviceInfo = File.ReadAllText(deviceInfoDirect);
            device = YamlConvert.DeserializeObject<BotDeviceInfo>(deviceInfo);
        }
        bool noDevice = device is null || string.IsNullOrWhiteSpace(device.DeviceName);

        string keystoreDirect = Path.Combine(AppContext.BaseDirectory, "keystore.yml");
        BotKeystore? keystore = null;
        if (File.Exists(keystoreDirect))
        {
            string keystoreInfo = File.ReadAllText(keystoreDirect);
            keystore = YamlConvert.DeserializeObject<BotKeystore>(keystoreInfo);
        }
        bool noKeystore = keystore is null || string.IsNullOrWhiteSpace(keystore.Uid);

        BotContext bot;
        if (noDevice || noKeystore)
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

            bot = BotFactory.Create(botConfig, uin, password!, out device);

            string deviceYml = YamlConvert.SerializeObject(device);
            File.WriteAllText(deviceInfoDirect, deviceYml);
            if (string.IsNullOrEmpty(password))
            {
                (string Url, byte[] Png)? qrCode = await bot.FetchQrCode();
                if (qrCode is null)
                {
                    Console.WriteLine("请求扫码登录接口失败，请重试或使用密码登录");
                    goto IL_InputPassword;
                }

                Console.WriteLine(qrCode.Value.Url);
                GenerateQRCode(qrCode.Value.Url);
                //TODO：在此处将Url输出为二维码，或将Png转成控制台能显示字符组成的图片输出

                Console.WriteLine("扫码成功后请按回车继续");
                Console.ReadLine();

                await bot.LoginByQrCode();
            }
            else
            {
                bool loginSuccess = await bot.LoginByPassword();
                if (!loginSuccess)
                {
                    Console.WriteLine("登录失败，请重试或使用扫码登录");
                    goto IL_InputPassword;
                }
            }
        }
        else
        {
            bot = BotFactory.Create(botConfig, device!, keystore!);
            bool loginSuccess = await bot.LoginByPassword();
            if (!loginSuccess)
            {
                Console.WriteLine("登录失败");
                Environment.Exit(0);
                return;
            }
        }

        Config.Instance.BotConfig = botConfig;
        Config.SaveConfig();

        Console.WriteLine("登录成功");
        keystore = bot.UpdateKeystore();
        File.WriteAllText(keystoreDirect, YamlConvert.SerializeObject(keystore));

        bot.Invoker.OnFriendMessageReceived += MessageReceived.OnFriendMessage;
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