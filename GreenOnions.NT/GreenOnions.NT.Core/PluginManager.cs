using System.Reflection;
using System.Runtime.Loader;
using GreenOnions.NT.Base;
using Lagrange.Core;

namespace GreenOnions.NT.Core
{
    public static class PluginManager
    {
        private static string _pluginsPath = Path.Combine(Environment.CurrentDirectory, "Plugins");
        private static List<IPlugin> _plugins = new List<IPlugin>();

        public static int Load(BotContext bot)
        {
            if (!Directory.Exists(_pluginsPath))
                Directory.CreateDirectory(_pluginsPath);

            string[] pluginItemPaths = Directory.GetDirectories(_pluginsPath);

            foreach (string pluginItemPath in pluginItemPaths)
            {
                if (pluginItemPath.Substring(pluginItemPath.LastIndexOf('\\') + 1) == "GreenOnions.PluginConfigEditor")
                {
                    continue;
                }

                File.Copy("GreenOnions.NT.Base.dll", Path.Combine(pluginItemPath, "GreenOnions.NT.Base.dll"), true);
                if (File.Exists("GreenOnions.NT.Base.xml"))
                    File.Copy("GreenOnions.NT.Base.xml", Path.Combine(pluginItemPath, "GreenOnions.NT.Base.xml"), true);
                if (File.Exists("GreenOnions.NT.Base.json"))
                    File.Copy("GreenOnions.NT.Base.json", Path.Combine(pluginItemPath, "GreenOnions.NT.Base.json"), true);
#if DEBUG
                File.Copy("GreenOnions.NT.Base.pdb", Path.Combine(pluginItemPath, "GreenOnions.NT.Base.pdb"), true);
#endif

                Dictionary<string, string> dependPath = new Dictionary<string, string>();
                string[] dlls = Directory.GetFiles(pluginItemPath, "*.dll", SearchOption.TopDirectoryOnly);
                foreach (string dll in dlls)
                {
                    string dllPath = Path.GetDirectoryName(dll)!;
                    string pluginFileName = Path.GetFileNameWithoutExtension(dll);
                    if (pluginFileName == "GreenOnions.NT.Base")
                        continue;
                    try
                    {
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

                            plugin.OnLoad(pluginItemPath, bot, Config.Instance);

                            _plugins.Add(plugin);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogException(ex, $"插件{pluginFileName}加载失败");
                    }
                }
            }
            return _plugins.Count;
        }
    }
}
