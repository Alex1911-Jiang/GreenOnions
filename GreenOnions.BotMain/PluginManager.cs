using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Loader;
using GreenOnions.Interface;
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
            Dictionary<string, string> dependPath = new Dictionary<string, string>();

            Dictionary<string, bool> pluginStatus = new Dictionary<string, bool>();
            foreach (string pluginItem in pluginItemPath)
            {
                File.Copy("GreenOnions.Interface.dll", Path.Combine(pluginItem, "GreenOnions.Interface.dll") , true);
#if DEBUG
                File.Copy("GreenOnions.Interface.pdb", Path.Combine(pluginItem, "GreenOnions.Interface.pdb"), true);
#endif

                string[] dlls = Directory.GetFiles(pluginItem, "*.dll", SearchOption.TopDirectoryOnly);
                foreach (string dll in dlls)
                {
                    string dllPath = Path.GetDirectoryName(dll)!;
                    string pluginFileName = Path.GetFileNameWithoutExtension(dll);
                    string pluginDescriptionFileName = Path.Combine(dllPath, $"{pluginFileName}.deps.json");
                    if (pluginFileName != "GreenOnions.Interface" && File.Exists(pluginDescriptionFileName))
                    {
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
                                if (type.GetInterface("IPlugin") is not null)
                                {
                                    IPlugin? plugin = (IPlugin?)Activator.CreateInstance(type);
                                    if (plugin is not null)
                                    {
                                        loadedPlugins.Add(dllPath.Substring(dllPath.LastIndexOf(@"\") + 1), plugin);
                                        if (!BotInfo.PluginStatus.ContainsKey(plugin.Name))
                                            pluginStatus.Add(plugin.Name, true);
                                        else
                                            pluginStatus.Add(plugin.Name, BotInfo.PluginStatus[plugin.Name]);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteWarningLog($"插件{pluginFileName}加载失败, {ex.Message}");
                        }
                    }
                }
            }

            BotInfo.PluginStatus = pluginStatus;

            foreach (KeyValuePair<string, IPlugin> theOtherPlugins in loadedPlugins)
            {
                Plugins.Add(theOtherPlugins.Value);
                theOtherPlugins.Value.OnLoad(Path.Combine(_pluginsPath, theOtherPlugins.Key), BotInfo.Config);
                LogHelper.WriteInfoLog($"插件{theOtherPlugins.Value.Name}加载成功");
            }
            return Plugins.Count;
        }

        public static GreenOnionsMessages? GetHelpMessage(string pluginName)
        {
            IPlugin? plugin = Plugins.Where(p => p.Name == pluginName).FirstOrDefault();
            if (plugin is not null && BotInfo.PluginStatus[plugin.Name])
                return plugin.HelpMessage;
            return string.Empty;
        }

        public static void Connected(long selfId, IGreenOnionsApi api)
        {
            _api = api;

            for (int i = 0; i < Plugins.Count; i++)
            {
                try
                {
                    if (BotInfo.PluginStatus[Plugins[i].Name])
                        Plugins[i].OnConnected(selfId, _api);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{Plugins[i].Name}连接方法调用发生异常，" + ex.Message);
                }
            }
        }

        public static void Disconnected()
        {
            _api = null;
            for (int i = 0; i < Plugins.Count; i++)
            {
                try
                {
                    if (BotInfo.PluginStatus[Plugins[i].Name])
                        Plugins[i].OnDisconnected();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{Plugins[i].Name}断开连接方法调用发生异常，" + ex.Message);
                }
            }
        }

        public static bool Message(GreenOnionsMessages msgs, long? senderGroup, Action<GreenOnionsMessages> Response)
        {
            for (int i = 0; i < Plugins.Count; i++)
            {
                try
                {
                    if (BotInfo.PluginStatus[Plugins[i].Name])
                        if (Plugins[i].OnMessage(msgs, senderGroup, Response))
                            return true;  //命中插件
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{Plugins[i].Name}处理消息方法调用发生异常，" + ex.Message);
                }
            }
            return false;
        }
    }
}
