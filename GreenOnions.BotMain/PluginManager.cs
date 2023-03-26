using System.Reflection;
using System.Runtime.Loader;
using COSXML.Network;
using GreenOnions.Interface;
using GreenOnions.Interface.DispatchCenter;
using GreenOnions.Interface.Subinterface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain
{
    public static class PluginManager
    {
        private static string _pluginsPath = Path.Combine(Environment.CurrentDirectory, "Plugins");
        public static List<IPlugin> Plugins { get; private set; } = new List<IPlugin>();
        public static IGreenOnionsApi? _api { get; private set; } = null;

        public static int Load()
        {
            if (!Directory.Exists(_pluginsPath))
                Directory.CreateDirectory(_pluginsPath);

            string[] pluginItemPath = Directory.GetDirectories(_pluginsPath);

            Dictionary<string, IPlugin> loadedPlugins = new Dictionary<string, IPlugin>();

            foreach (string pluginItem in pluginItemPath)
            {
                File.Copy("GreenOnions.Interface.dll", Path.Combine(pluginItem, "GreenOnions.Interface.dll"), true);
                if (File.Exists("GreenOnions.Interface.xml"))
                    File.Copy("GreenOnions.Interface.xml", Path.Combine(pluginItem, "GreenOnions.Interface.xml"), true);
                if (File.Exists("GreenOnions.Interface.json"))
                    File.Copy("GreenOnions.Interface.json", Path.Combine(pluginItem, "GreenOnions.Interface.json"), true);
#if DEBUG
                File.Copy("GreenOnions.Interface.pdb", Path.Combine(pluginItem, "GreenOnions.Interface.pdb"), true);
#endif

                Dictionary<string, string> dependPath = new Dictionary<string, string>();
                string[] dlls = Directory.GetFiles(pluginItem, "*.dll", SearchOption.TopDirectoryOnly);
                foreach (string dll in dlls)
                {
                    string dllPath = Path.GetDirectoryName(dll)!;
                    string pluginFileName = Path.GetFileNameWithoutExtension(dll);
                    if (pluginFileName == "GreenOnions.Interface")
                        continue;
                    try
                    {
                        AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(pluginFileName);
                        Assembly pluginAssembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
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
                            if (type.GetInterface("IPlugin") is null)
                                continue;

                            IPlugin? plugin = (IPlugin?)Activator.CreateInstance(type);
                            if (plugin is null)
                                continue;

                            loadedPlugins.Add(dllPath.Substring(dllPath.LastIndexOf(@"\") + 1), plugin);
                            if (!BotInfo.PluginStatus.ContainsKey(plugin.Name))
                                BotInfo.PluginStatus.Add(plugin.Name, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLog($"插件{pluginFileName}加载失败", ex);
                    }
                }
            }

            foreach (KeyValuePair<string, IPlugin> loadedPlugin in loadedPlugins)
            {
                Plugins.Add(loadedPlugin.Value);
                try
                {
                    loadedPlugin.Value.OnLoad(Path.Combine(_pluginsPath, loadedPlugin.Key), BotInfo.Config);
                    SetToolPluginMethod(loadedPlugin.Value);
                    LogHelper.WriteInfoLog($"插件{loadedPlugin.Value.Name}加载成功");
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{loadedPlugin.Value.Name}加载失败", ex);
                }
            }
            return Plugins.Count;
        }

        private static void SetToolPluginMethod(IPlugin loadedPlugin)
        {
            if (loadedPlugin is IHttpClientSubstitutes httpTool)
            {
                HttpClientSubstitutes.GetString = httpTool.GetString;
                HttpClientSubstitutes.GetStringAsync = httpTool.GetStringAsync;
                HttpClientSubstitutes.GetByteArray = httpTool.GetByteArray;
                HttpClientSubstitutes.GetByteArrayAsync = httpTool.GetByteArrayAsync;
                HttpClientSubstitutes.GetStream = httpTool.GetStream;
                HttpClientSubstitutes.GetStreamAsync = httpTool.GetStreamAsync;

                HttpClientSubstitutes.PostString = httpTool.PostString;
                HttpClientSubstitutes.PostStringAsync = httpTool.PostStringAsync;
                HttpClientSubstitutes.PostByteArray = httpTool.PostByteArray;
                HttpClientSubstitutes.PostByteArrayAsync = httpTool.PostByteArrayAsync;
                HttpClientSubstitutes.PostStream = httpTool.PostStream;
                HttpClientSubstitutes.PostStreamAsync = httpTool.PostStreamAsync;
            }
        }

        public static void Connected(long selfId, IGreenOnionsApi api)
        {
            _api = api;

            for (int i = 0; i < Plugins.Count; i++)
            {
                if (!BotInfo.PluginStatus[Plugins[i].Name])
                    continue;
                try
                {
                    Plugins[i].OnConnected(selfId, _api);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{Plugins[i].Name}连接方法调用发生异常", ex);
                }
            }
        }

        public static void Disconnected()
        {
            _api = null;
            for (int i = 0; i < Plugins.Count; i++)
            {
                if (!BotInfo.PluginStatus[Plugins[i].Name])
                    continue;
                try
                {
                    Plugins[i].OnDisconnected();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{Plugins[i].Name}断开连接方法调用发生异常", ex);
                }
            }
        }

        public static void ReloadAllPluginsConfig()
        {
            for (int i = 0; i < Plugins.Count; i++)
            {
                if (Plugins[i] is not IMessagePlugin msgPlugin) 
                    continue;
                try
                {
                    msgPlugin.ReloadConfig();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{Plugins[i].Name}重新读取配置文件发生异常", ex);
                }
            }
        }

        public static bool Message(GreenOnionsMessages msgs, long? senderGroup, Action<GreenOnionsMessages> Response)
        {
            for (int i = 0; i < Plugins.Count; i++)
            {
                if (!BotInfo.PluginStatus[Plugins[i].Name])  //插件没启用
                    continue;
                if (Plugins[i] is not IMessagePlugin msgPlugin)  //插件不是消息处理插件
                    continue;
                try
                {
                    if (msgPlugin.OnMessage(msgs, senderGroup, Response))
                        return true;  //消息已被处理
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{Plugins[i].Name}处理消息方法调用发生异常", ex);
                }
            }
            return false;
        }
    }
}
