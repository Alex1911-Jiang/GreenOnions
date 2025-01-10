using System.IO.Compression;
using GreenOnions.NT.Base;
using GreenOnions.NT.Core;
using Lagrange.Core;
using Lagrange.Core.Common;
using Lagrange.Core.Common.Interface;
using Lagrange.Core.Common.Interface.Api;
using Newtonsoft.Json;
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

            File.WriteAllText(botConfigPath, YamlConvert.SerializeObject(botConfig));
            File.WriteAllText(deviceInfoPath, YamlConvert.SerializeObject(deviceInfo));

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
            if (File.Exists(keystorePath))
                File.Delete(keystorePath);
            Environment.Exit(0);
            return;
        }

        Config.SaveConfig();

        Console.WriteLine($"登录成功，机器人昵称：{bot.BotName}");
        keystore = bot.UpdateKeystore();
        File.WriteAllText(keystorePath, YamlConvert.SerializeObject(keystore));

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
exit : 退出葱葱");
            }
            else if (cmd == "exit")
            {
                Environment.Exit(0);
                return;
            }
            else if (cmd == "list-plugins")
            {
                Dictionary<string, GreenOnionsPluginRelease>? pluginReleases = await SearchPluginsFromGithub();
                if (pluginReleases is null)
                    continue;
                foreach (var pluginRelease in pluginReleases)
                    Console.WriteLine($"《{pluginRelease.Key}》版本号：{pluginRelease.Value.Version}，更新说明：{pluginRelease.Value.Description}");
            }
            else if (cmd.StartsWith("install-plugin"))
            {
                string pluginName = cmd.Substring("install-plugin".Length).Trim();
                Dictionary<string, GreenOnionsPluginRelease>? pluginReleases = await SearchPluginsFromGithub();
                if (pluginReleases is null)
                    continue;
                if (!pluginReleases.TryGetValue(pluginName, out GreenOnionsPluginRelease? plugin))
                {
                    Console.WriteLine($"找不到名为《{pluginName}》的插件");
                    continue;
                }
                using HttpClient client = new HttpClient();
                var resp = await client.GetAsync(plugin.Url);
                if (!resp.IsSuccessStatusCode)
                {
                    Console.WriteLine($"下载《{pluginName}》插件失败，{(int)resp.StatusCode} {resp.StatusCode}");
                    continue;
                }
                Stream pluginZip = await resp.Content.ReadAsStreamAsync();

                string pluginPath = Path.Combine(AppContext.BaseDirectory, "Plugins", plugin.PackageName.Substring(0, plugin.PackageName.LastIndexOf('.')));
                Directory.CreateDirectory(pluginPath);
                ZipFile.ExtractToDirectory(pluginZip, pluginPath);
                LogHelper.LogMessage($"下载{pluginName}插件完成");
                PluginManager.Load(bot);
            }
        }
    }

    private static async Task<Dictionary<string, GreenOnionsPluginRelease>?> SearchPluginsFromGithub()
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.TryParseAdd("DotNetHttpClient/8.0");
        var resp = await client.GetAsync("https://api.github.com/repos/Alex1911-Jiang/GreenOnions.Plugins/releases");
        if (!resp.IsSuccessStatusCode)
        {
            LogHelper.LogError($"在Github查找葱葱官方插件失败 {(int)resp.StatusCode} {resp.StatusCode}");
            return null;
        }
        string releaseJson = await resp.Content.ReadAsStringAsync();
        GithubRelease[]? releases = JsonConvert.DeserializeObject<GithubRelease[]>(releaseJson);
        if (releases is null)
        {
            LogHelper.LogError($"在Github查找葱葱官方插件失败，解析内容错误");
            return null;
        }

        GithubRelease release = releases.First();

        Dictionary<string, GreenOnionsPluginRelease> pluginReleases = new Dictionary<string, GreenOnionsPluginRelease>();
        foreach (var item in release.assets)
        {
            GreenOnionsPluginRelease pluginRelease = new GreenOnionsPluginRelease
            {
                PackageName = item.name,
                Description = release.body,
                Version = release.name,
                Url = item.browser_download_url,
            };
            if (pluginReleases.TryGetValue(release.tag_name, out GreenOnionsPluginRelease? sameRelease) && sameRelease.Version > pluginRelease.Version)
                continue;
            pluginReleases[release.tag_name] = pluginRelease;
        }

        return pluginReleases;
    }

    public class GreenOnionsPluginRelease
    {
        public string PackageName { get; set; }
        public string Description { get; set; }
        public long Version { get; set; }
        public string Url { get; set; }
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


    public class GithubRelease
    {
        public string url { get; set; }
        public string assets_url { get; set; }
        public string upload_url { get; set; }
        public string html_url { get; set; }
        public int id { get; set; }
        public GithubAuthor author { get; set; }
        public string node_id { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
        public long name { get; set; }
        public bool draft { get; set; }
        public bool prerelease { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public GithubAsset[] assets { get; set; }
        public string tarball_url { get; set; }
        public string zipball_url { get; set; }
        public string body { get; set; }
    }

    public class GithubAuthor
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public string user_view_type { get; set; }
        public bool site_admin { get; set; }
    }

    public class GithubAsset
    {
        public string url { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public object label { get; set; }
        public GithubUploader uploader { get; set; }
        public string content_type { get; set; }
        public string state { get; set; }
        public int size { get; set; }
        public int download_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string browser_download_url { get; set; }
    }

    public class GithubUploader
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public string user_view_type { get; set; }
        public bool site_admin { get; set; }
    }

}