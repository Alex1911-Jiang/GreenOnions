using Konata.Core;
using Konata.Core.Events.Model;
using Konata.Core.Interfaces.Api;
using Konata.Core.Interfaces;
using Konata.Core.Common;
using System.Text.Json;
using Konata.Core.Message.Model;

namespace GreenOnions.Konata
{
    public class Client
    {
        private Bot? _bot = null;

        public Client()
        {
            
        }

        public async void Login()
        {
            _bot = BotFather.Create(GetConfig(), GetDevice(), GetKeyStore(0, "A"));  //TODO:QQ号，密码
            {
                // Print the log
                _bot.OnLog += (_, e) =>
                    Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] " +
                                      $"[{e.Level}] [{e.Tag}] {e.EventMessage}");

                // Handle the captcha
                _bot.OnCaptcha += (s, e) =>
                {
                    switch (e.Type)
                    {
                        case CaptchaEvent.CaptchaType.Sms:
                            Console.WriteLine(e.Phone);
                            s.SubmitSmsCode(Console.ReadLine());
                            break;

                        case CaptchaEvent.CaptchaType.Slider:
                            Console.WriteLine(e.SliderUrl);
                            s.SubmitSliderTicket(Console.ReadLine());
                            break;

                        default:
                        case CaptchaEvent.CaptchaType.Unknown:
                            break;
                    }
                };

                // Handle group messages
                //_bot.OnGroupMessage += GroupMessageHandler;

                _bot.OnFriendMessage += _bot_OnFriendMessage;

                // Update the keystore
                _bot.OnBotOnline += (bot, _) =>
                {
                    Console.WriteLine("Bot keystore updated.");
                };

                // Login the bot
                if (!await _bot.Login())
                {
                    Console.WriteLine("Oops... Login failed.");
                    return;
                }

                // cli
                while (true)
                {
                    try
                    {
                        switch (Console.ReadLine())
                        {
                            case "/stop":
                                await _bot.Logout();
                                _bot.Dispose();
                                return;

                            case "/login":
                                await _bot.Login();
                                break;

                            //case "/reload":
                            //    await _sandbox.ScanScriptsAndLoad();
                            //    break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}\n{e.StackTrace}");
                    }
                }
            }
        }

        private void _bot_OnFriendMessage(Bot sender, FriendMessageEvent args)
        {
            if (args.FriendUin == sender.Uin)
                return;

            var textChain = args.Chain.GetChain<TextChain>();
            if (textChain is null) 
                return;

            sender.SendFriendMessage(args.FriendUin, $"接收到消息：{textChain.Content}");
        }

        private BotKeyStore? GetKeyStore(long qqId, string password)
        {
            // Create new one
            Console.WriteLine("Bot created.");
            return new BotKeyStore(qqId.ToString(), password);
        }


        private BotConfig? GetConfig()
        {
            // Read the device from config
            if (File.Exists("konataConfig.json"))
            {
                return JsonSerializer.Deserialize
                    <BotConfig>(File.ReadAllText("konataConfig.json"));
            }

            // Create new one
            var config = new BotConfig
            {
                EnableAudio = true,
                TryReconnect = true,
                HighwayChunkSize = 8192,
                DefaultTimeout = 6000,
                Protocol = OicqProtocol.AndroidPhone
            };

            // Write to file
            var configJson = JsonSerializer.Serialize(config,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("konataConfig.json", configJson);

            return config;
        }

        private BotDevice? GetDevice()
        {
            if (File.Exists("device.json"))
            {
                return JsonSerializer.Deserialize
                    <BotDevice>(File.ReadAllText("device.json"));
            }

            var device = BotDevice.Default();
            {
                var deviceJson = JsonSerializer.Serialize(device,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("device.json", deviceJson);
            }

            return device;
        }
    }
}