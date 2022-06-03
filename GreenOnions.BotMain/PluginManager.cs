using GreenOnions.Interface;
using System.Reflection;

namespace GreenOnions.BotMain
{
    public static class PluginManager
    {
        public static Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();

        public static IEnumerable<(bool, string)> Load()
        {
            string pluginsPath = Path.Combine(Environment.CurrentDirectory, "Plugins");
            if (!Directory.Exists(pluginsPath))
                Directory.CreateDirectory(pluginsPath);

            string[] pluginItemPath = Directory.GetDirectories(pluginsPath);
            foreach (string pluginItem in pluginItemPath)
            {
                string[] dlls = Directory.GetFiles(pluginItem, "*.dll", SearchOption.TopDirectoryOnly);
                foreach (string dll in dlls)
                {
                    if (!string.IsNullOrEmpty(dll))
                    {
                        string dllPath = Path.GetDirectoryName(dll);
                        string pluginName = Path.GetFileNameWithoutExtension(dll);
                        if (pluginName != "GreenOnions.Interface" && File.Exists(Path.Combine(dllPath, $"{pluginName}.deps.json")))
                        {
                            if (Plugins.ContainsKey(pluginName))
                            {
                                yield return (true, $"存在同名插件{pluginName}, 加载失败");
                            }
                            string errMsg = null;
                            try
                            {
                                Assembly pluginAssembly = Assembly.LoadFrom(dll);
                                Type[] types = pluginAssembly.GetTypes();
                                foreach (Type type in types)
                                {
                                    if (type.GetInterface("IPlugin") != null)
                                    {
                                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                                        if (plugin != null)
                                        {
                                            Plugins.Add(pluginName, plugin);
                                            plugin.OnLoad();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                errMsg = ex.Message;
                            }
                            if (string.IsNullOrEmpty(errMsg))
                                yield return (true, $"插件{pluginName}加载成功");
                            else
                                yield return (true, $"插件{pluginName}加载失败, {errMsg}");
                        }
                    }
                }
            }
        }

        public static void Connected(long selfId, Func<long, IGreenOnionsMessages, Task<int>> SendFriendMessage, Func<long, IGreenOnionsMessages, Task<int>> SendGroupMessage, Func<long, long, IGreenOnionsMessages, Task<int>> SendTempMessage)
        {
            foreach (KeyValuePair<string, IPlugin> plugin in Plugins)
                plugin.Value.OnConnected(selfId, SendFriendMessage, SendGroupMessage, SendTempMessage);
        }

        public static void Disconnected()
        {
            foreach (KeyValuePair<string, IPlugin> plugin in Plugins)
                plugin.Value.OnDisconnected();
        }

        public static bool Message(IGreenOnionsMessages msgs, long? senderGroup, Action<IGreenOnionsMessages> Response)
        {
            foreach (KeyValuePair<string, IPlugin> plugin in Plugins)
            {
                if (plugin.Value.OnMessage(msgs, senderGroup, Response))
                    return true;  //命中插件
            }
            return false;
        }
    }
}
