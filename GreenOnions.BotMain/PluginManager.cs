using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace GreenOnions.BotMain
{
    public static class PluginManager
    {
        public static List<IPlugin> Plugins = new List<IPlugin>();
        private static string _pluginsPath = Path.Combine(Environment.CurrentDirectory, "Plugins");

        public static int Load()
        {
            if (!Directory.Exists(_pluginsPath))
                Directory.CreateDirectory(_pluginsPath);

            string[] pluginItemPath = Directory.GetDirectories(_pluginsPath);

            Dictionary<string, IPlugin> loadedPlugins = new Dictionary<string, IPlugin>();

            foreach (string pluginItem in pluginItemPath)
            {
                string pluginItemUser = pluginItem;
                string[] dlls = Directory.GetFiles(pluginItemUser, "*.dll", SearchOption.TopDirectoryOnly);
                foreach (string dll in dlls)
                {
                    string dllPath = Path.GetDirectoryName(dll);
                    string pluginFileName = Path.GetFileNameWithoutExtension(dll);
                    string pluginDescriptionFileName = Path.Combine(dllPath, $"{pluginFileName}.deps.json");
                    if (pluginFileName != "GreenOnions.Interface" && File.Exists(pluginDescriptionFileName))
                    {
                        string errMsg = null;
                        string pluginName = null;
                        try
                        {
                            AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
                            Assembly pluginAssembly = Assembly.LoadFrom(dll);
                            Type[] types = pluginAssembly.GetTypes();
                            foreach (Type type in types)
                            {
                                if (type.GetInterface("IPlugin") != null)
                                {
                                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                                    if (plugin != null)
                                    {
                                        loadedPlugins.Add(Path.GetFileNameWithoutExtension(dllPath), plugin);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteWarningLog($"插件{pluginName}({pluginFileName})加载失败, {errMsg}");
                        }
                    }
                }
            }

            List<string> pluginNewOrder = new List<string>();
            for (int i = 0; i < BotInfo.PluginOrder.Count; i++)
            {
                string pluginPath = BotInfo.PluginOrder[i];
                if (loadedPlugins.ContainsKey(pluginPath))
                {
                    IPlugin plugin = loadedPlugins[pluginPath];
                    Plugins.Add(plugin);
                    try
                    {
                        loadedPlugins.Remove(pluginPath);
                        plugin.OnLoad(Path.Combine(_pluginsPath, pluginPath));
                        LogHelper.WriteInfoLog($"插件{plugin.Name}加载成功");
                        pluginNewOrder.Add(Path.GetFileNameWithoutExtension(pluginPath));
                    }
                    catch (Exception ex)
                    {
                        if (Plugins.Contains(plugin))
                            Plugins.Remove(plugin);
                        LogHelper.WriteErrorLog($"插件{plugin.Name}加载失败，" + ex.Message);
                    }
                }
            }
            foreach (KeyValuePair<string, IPlugin> theOtherPlugins in loadedPlugins)
            {
                Plugins.Add(theOtherPlugins.Value);
                theOtherPlugins.Value.OnLoad(Path.Combine(_pluginsPath, theOtherPlugins.Key));
                LogHelper.WriteInfoLog($"插件{theOtherPlugins.Value.Name}加载成功");
                pluginNewOrder.Add(Path.GetFileNameWithoutExtension(theOtherPlugins.Key));
            }
            BotInfo.PluginOrder = pluginNewOrder;
            ConfigHelper.SaveConfigFile();
            return Plugins.Count;
        }

        public static void Connected(long selfId,
            Func<long, GreenOnionsMessages, Task<int>> SendFriendMessage,
            Func<long, GreenOnionsMessages, Task<int>> SendGroupMessage,
            Func<long, long, GreenOnionsMessages, Task<int>> SendTempMessage,
            Func<Task<List<GreenOnionsFriendInfo>>> GetFriendList,
            Func<Task<List<GreenOnionsGroupInfo>>> GetGroupList,
            Func<long, Task<List<long>>> GetMemberList,
            Func<long, long, Task<GreenOnionsMemberInfo>> GetMemberInfo)
        {
            foreach (IPlugin plugin in Plugins)
            {
                try
                {
                    plugin.OnConnected(selfId, SendFriendMessage, SendGroupMessage, SendTempMessage, GetFriendList, GetGroupList, GetMemberList, GetMemberInfo);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{plugin.Name}连接方法调用发生异常，" + ex.Message);
                }
            }    
        }

        public static void Disconnected()
        {
            foreach (IPlugin plugin in Plugins)
            {
                try
                {
                    plugin.OnDisconnected();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{plugin.Name}断开连接方法调用发生异常，" + ex.Message);
                }
            }
        }

        public static bool Message(GreenOnionsMessages msgs, long? senderGroup, Action<GreenOnionsMessages> Response)
        {
            foreach (IPlugin plugin in Plugins)
            {
                try
                {
                    if (plugin.OnMessage(msgs, senderGroup, Response))
                        return true;  //命中插件
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"插件{plugin.Name}处理消息方法调用发生异常，" + ex.Message);
                }
            }
            return false;
        }
    }
}
