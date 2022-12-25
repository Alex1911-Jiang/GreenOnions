using Konata.Core.Interfaces;
using Konata.Core;
using Konata.Core.Common;
using System.Text.Json;
using Konata.Core.Events.Model;
using Konata.Core.Interfaces.Api;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain.KonataCore
{
    public static class KonataCoreMain
    {
        public static event Func<string, string> CaptchaSms;
        public static event Action<string> CaptchaSlider;
        public static event Action<string> CaptchaFail;

        private static Bot? _bot = null;
        public static async Task Login(long qqId, string password, Func<string, string> captchaSms, Action<string> captchaSlider, Action<string> captchaFail)
        {
            CaptchaSms = captchaSms;
            CaptchaSlider = captchaSlider;
            CaptchaFail = captchaFail;

            _bot = BotFather.Create(GetConfig(), GetDevice(), GetKeyStore(qqId, password));

            // Print the log
            _bot.OnLog += (_, e) =>
            {
                switch (e.Level)
                {
                    case Konata.Core.Events.LogLevel.Verbose:
                    case Konata.Core.Events.LogLevel.Information:
                        LogHelper.WriteInfoLog(e.EventMessage);
                        break;
                    case Konata.Core.Events.LogLevel.Warning:
                        LogHelper.WriteWarningLog(e.EventMessage);
                        break;
                    case Konata.Core.Events.LogLevel.Exception:
                    case Konata.Core.Events.LogLevel.Fatal:
                        LogHelper.WriteErrorLog(e.EventMessage);
                        break;
                }
            };

            _bot.OnCaptcha += Bot_OnCaptcha;

            _bot.OnFriendMessage += _bot_OnFriendMessage;
            _bot.OnGroupMessage += _bot_OnGroupMessage;

            // Login the bot
            var result = await _bot.Login();
            {
                // Update the keystore
                if (result) UpdateKeystore(_bot.KeyStore);
            }
        }

        private static void _bot_OnFriendMessage(Bot sender, FriendMessageEvent args)
        {

        }

        private static void _bot_OnGroupMessage(Bot sender, GroupMessageEvent args)
        {

        }

        public static async void LogOut()
        {
            if (_bot != null)
            {
                await _bot.Logout();
                _bot.Dispose();
            }
        }

        /// <summary>
        /// Get bot config
        /// </summary>
        /// <returns></returns>
        private static BotConfig GetConfig()
        {
            return new BotConfig
            {
                EnableAudio = true,
                TryReconnect = true,
                HighwayChunkSize = 8192,
            };
        }

        /// <summary>
        /// Load or create device 
        /// </summary>
        /// <returns></returns>
        private static BotDevice? GetDevice()
        {
            // Read the device from config
            if (File.Exists("device.json"))
            {
                return JsonSerializer.Deserialize
                    <BotDevice>(File.ReadAllText("device.json"));
            }

            // Create new one
            var device = BotDevice.Default();
            {
                var deviceJson = JsonSerializer.Serialize(device,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("device.json", deviceJson);
            }

            return device;
        }

        /// <summary>
        /// Load or create keystore
        /// </summary>
        /// <returns></returns>
        private static BotKeyStore? GetKeyStore(long qqId, string password)
        {
            // Read the device from config
            if (File.Exists("keystore.json"))
            {
                return JsonSerializer.Deserialize
                    <BotKeyStore>(File.ReadAllText("keystore.json"));
            }

            // Create new one
            LogHelper.WriteInfoLog("构造机器人实例");
            return UpdateKeystore(new BotKeyStore(qqId.ToString(), password));
        }

        /// <summary>
        /// Update keystore
        /// </summary>
        /// <param name="keystore"></param>
        /// <returns></returns>
        private static BotKeyStore UpdateKeystore(BotKeyStore keystore)
        {
            var deviceJson = JsonSerializer.Serialize(keystore,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("keystore.json", deviceJson);
            return keystore;
        }

        /// <summary>
        /// 处理短信验证和滑动码验证，滑动码验证需要在手机app“滑动助手”配合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Bot_OnCaptcha(object? sender, CaptchaEvent e)
        {
            try
            {
                switch (e.Type)
                {
                    case CaptchaEvent.CaptchaType.Sms:
                        _bot.SubmitSmsCode(CaptchaSms($"手机验证码已经发送，请输入{e.Phone}接收到的验证码："));
                        break;

                    case CaptchaEvent.CaptchaType.Slider:
                        string ticket = DoCaptcha(e.SliderUrl);
                        if (string.IsNullOrEmpty(ticket)) 
                            CaptchaFail("认证失败，请检查并重试。");
                        else _bot.SubmitSliderTicket(ticket);
                        break;

                    default:
                    case CaptchaEvent.CaptchaType.Unknown:
                        CaptchaFail("未知的验证方式，请联系开发人员");
                        break;
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"处理验证码发生错误，{ex.Message}");
            }
        }

        /// <summary>
        /// 处理滑动验证，url是登录QQ时由QQ返回的滑动验证链接,返回滑动认证的ticket
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DoCaptcha(string url)
        {
            string code, ticket = "";
            try
            {
                url = url.Replace("ssl.captcha.qq.com", "txhelper.glitch.me");
                code = GetUrlInfo(url, "code"); //第一次返回的是4位数字验证码
                if (!string.IsNullOrEmpty(code))
                {
                    CaptchaSlider($"请在手机app‘滑动验证助手’输入验证码，并手动完成滑动验证：{code}\r\n完成滑动验证后点击确定登录。");
                    ticket = GetUrlInfo(url, "ticket"); //第二次返回的是登录QQ的验证字符串
                }
            }
            catch (Exception ex)
            {
                CaptchaFail($"处理验证过程发生错误，{ex.Message}");
            }
            return ticket;
        }

        /// <summary>  
        /// 获取滑动验证链接的code或ticket，需要配合手机“滑动验证助手app”
        /// </summary>  
        public static string GetUrlInfo(string url, string strtype)
        {
            string str = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
                string[] strBuff = client.GetStringAsync(url).Result.Split(":");
                if (strBuff.Length >= 4 && strtype == "code")
                    str = strBuff[2].Substring(0, 4); //获取滑动验证前的代码
                if (strBuff.Length >= 4 && strtype == "ticket")
                    str = strBuff[3].Replace("\"", "").Replace("}", ""); //获取滑动验证候的ticket
            }
            return str;
        }
    }
}
