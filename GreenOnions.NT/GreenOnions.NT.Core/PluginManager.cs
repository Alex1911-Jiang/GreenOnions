using System.IO.Compression;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using GreenOnions.NT.Base;
using GreenOnions.NT.Core.Models;
using GreenOnions.NT.Core.Models.Github;
using Lagrange.Core;
using Newtonsoft.Json;

namespace GreenOnions.NT.Core
{
    public static class PluginManager
    {
        private static string _pluginsPath = Path.Combine(Environment.CurrentDirectory, "Plugins");
        private static Dictionary<string, PluginReleaseInfo>? _pluginInfos = null;

        public static IPlugin? GetPluginByName(string name)
        {
            SngletonInstance.Plugins.TryGetValue(name, out IPlugin? plugin);
            return plugin;
        }

        public static void OnConfigUpdate()
        {
            foreach (var item in SngletonInstance.Plugins.Values)
                item.OnConfigUpdated(SngletonInstance.Config!);
        }

        public static int LoadAllPlugins(BotContext bot)
        {
            if (!Directory.Exists(_pluginsPath))
                Directory.CreateDirectory(_pluginsPath);

            string[] pluginItemPaths = Directory.GetDirectories(_pluginsPath);

            foreach (string pluginItemPath in pluginItemPaths)
            {
                //if (pluginItemPath.Substring(pluginItemPath.LastIndexOf('\\') + 1) == "GreenOnions.PluginConfigEditor")
                //    continue;

                LoadOncePlugin(pluginItemPath, bot);
            }
            return SngletonInstance.Plugins.Count;
        }

        public static async Task UpgradePlugins()
        {
            if (!Directory.Exists(_pluginsPath))
                Directory.CreateDirectory(_pluginsPath);

            string[] pluginItemPaths = Directory.GetDirectories(_pluginsPath);

            foreach (string pluginItemPath in pluginItemPaths)
            {
                string? upgradeFile = Directory.GetFiles(pluginItemPath, ".upgrade", SearchOption.TopDirectoryOnly).FirstOrDefault();
                if (upgradeFile is null)
                    continue;
                string base64 = File.ReadAllText(upgradeFile);
                string pluginName = Encoding.UTF8.GetString(Convert.FromBase64String(base64));

                await InstallPlugin(pluginName);
                File.Delete(upgradeFile);
            }
        }

        public static bool LoadOncePlugin(string pluginPath, BotContext bot)
        {
            Dictionary<string, string> dependPath = new Dictionary<string, string>();
            string[] dlls = Directory.GetFiles(pluginPath, "*.dll", SearchOption.TopDirectoryOnly);
            foreach (string dll in dlls)
            {
                string dllPath = Path.GetDirectoryName(dll)!;
                string pluginFileName = Path.GetFileNameWithoutExtension(dll);
                if (pluginFileName == "GreenOnions.NT.Base")
                    continue;

                if (SngletonInstance.Plugins.ContainsKey(pluginFileName))
                {
                    LogHelper.LogWarning($"已加载（{pluginFileName}）插件无需重复加载");
                    return false;
                }

                AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(pluginFileName);
                Assembly pluginAssembly;
                try
                {
                    pluginAssembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
                }
                catch (Exception)
                {
                    continue;
                }

                try
                {
                    dependPath.Add(pluginFileName, dllPath);
                    assemblyLoadContext.Resolving += (context, assemblyName) =>
                    {
                        string filename = $@"{Path.Combine(dependPath[context.Name!], $"{assemblyName.Name}.dll")}";
                        if (File.Exists(filename))
                            return context.LoadFromAssemblyPath(filename);
                        return null;
                    };

                    Type[] types = pluginAssembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.GetInterface(nameof(IPlugin)) is null)
                            continue;

                        IPlugin? plugin = (IPlugin?)Activator.CreateInstance(type);
                        if (plugin is null)
                            continue;
                        string pluginNamespace = plugin.GetNamespace();
                        if (SngletonInstance.Plugins.ContainsKey(plugin.Name))
                        {
                            LogHelper.LogWarning($"已加载《{plugin.Name}》（{pluginNamespace}）插件无法重复加载");
                            return false;
                        }

                        plugin.OnLoaded(pluginPath, bot, SngletonInstance.Config!);
                        LogHelper.LogMessage($"《{plugin.Name}》（{pluginNamespace}）插件加载成功，版本：{plugin.GetVersion()}");

                        SngletonInstance.Plugins.Add(plugin.GetNamespace(), plugin);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogException(ex, $"《{pluginFileName}》插件加载失败，错误信息：{ex.Message}");
                    return false;
                }
            }
            return true;
        }

        public static async Task<RestResult<string>> InstallPlugin(string pluginName)
        {
            Dictionary<string, PluginReleaseInfo> pluginReleases = _pluginInfos ?? await SearchPluginsOnGithub();
            if (!pluginReleases.TryGetValue(pluginName, out PluginReleaseInfo? plugin))
                return new RestResult<string>(false, null, $"找不到名为《{pluginName}》的插件");
            IPlugin? installedPlugin = PluginManager.GetPluginByName(pluginName);
            string? pluginPath = installedPlugin?.GetPath();
            if (installedPlugin is not null && pluginPath is not null)
            {
                long installedVersion = installedPlugin.GetVersion();
                if (installedVersion >= plugin.Version)
                    return new RestResult<string>(false, null, $"当前安装的《{pluginName}》插件已是最新版本：{installedVersion}");
                string pluginDirect = Path.Combine(Path.GetDirectoryName(pluginPath)!, $".upgrade");
                File.WriteAllText(pluginDirect, Convert.ToBase64String(Encoding.UTF8.GetBytes(pluginName)));
                return new RestResult<string>(false, null, $"已创建升级计划，《{pluginName}》插件将在您下次启动葱葱NT时自动升级");
            }

            bool useProxy = false;
            if (SngletonInstance.Config is Config config)
                useProxy = config.UseProxy;
            using HttpClientHandler handler = new HttpClientHandler { UseProxy = useProxy };
            using HttpClient client = new HttpClient(handler);
            var resp = await client.GetAsync(plugin.Url);
            if (!resp.IsSuccessStatusCode)
                return new RestResult<string>(false, null, $"下载《{pluginName}》插件失败，{(int)resp.StatusCode} {resp.StatusCode}");
            long totalBytes = resp.Content.Headers.ContentLength!.Value;
            Stream pluginZip = await resp.Content.ReadAsStreamAsync();

            double totalRead = 0;
            byte[] buffer = new byte[8192];
            int read = 0;
            do
            {
                read = await pluginZip.ReadAsync(buffer, 0, buffer.Length);
                totalRead += read;
                int progress = (int)Math.Round(totalRead / totalBytes * 50);
                Console.Write($"\r正在下载《{pluginName}》插件，进度：[{string.Empty.PadLeft(progress, '=').PadRight(50)}]");
                await Task.Delay(1);
            } while (read > 0);
            Console.WriteLine();

            string installPath = Path.Combine(AppContext.BaseDirectory, "Plugins", plugin.PackageName);
            Directory.CreateDirectory(installPath);
            ZipFile.ExtractToDirectory(pluginZip, installPath, true);
            LogHelper.LogMessage($"安装《{pluginName}》插件完成");
            return new RestResult<string>(false, installPath);
        }

        public static async Task<Dictionary<string, PluginReleaseInfo>> SearchPluginsOnGithub()
        {
            bool useProxy = false;
            if (SngletonInstance.Config is Config config)
                useProxy = config.UseProxy;
            using HttpClientHandler handler = new HttpClientHandler { UseProxy = useProxy };
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("DotNetRuntime/8.0");
            var resp = await client.GetAsync("https://api.github.com/repos/Alex1911-Jiang/GreenOnions.Plugins/releases");
            if (!resp.IsSuccessStatusCode)
            {
                LogHelper.LogError($"在Github查找葱葱官方插件失败 {(int)resp.StatusCode} {resp.StatusCode}");
                throw new Exception($"在Github查找葱葱官方插件失败 {(int)resp.StatusCode} {resp.StatusCode}");
            }
            string releaseJson = await resp.Content.ReadAsStringAsync();
            GithubRelease[]? releases = JsonConvert.DeserializeObject<GithubRelease[]>(releaseJson);
            if (releases is null)
            {
                LogHelper.LogError($"在Github查找葱葱官方插件失败，解析内容错误");
                throw new Exception($"在Github查找葱葱官方插件失败，解析内容错误");
            }

            GithubRelease release = releases.First();

            Dictionary<string, PluginReleaseInfo> pluginReleases = new Dictionary<string, PluginReleaseInfo>();
            foreach (var item in release.assets)
            {
                PluginReleaseInfo pluginRelease = new PluginReleaseInfo
                {
                    PackageName = item.name.Substring(0, item.name.LastIndexOf('.')),
                    Description = release.body,
                    Version = release.name,
                    Url = item.browser_download_url,
                };
                if (pluginReleases.TryGetValue(release.tag_name, out PluginReleaseInfo? sameRelease) && sameRelease.Version > pluginRelease.Version)
                    continue;
                pluginReleases[release.tag_name] = pluginRelease;
            }
            _pluginInfos = pluginReleases;
            return pluginReleases;
        }
    }
}
