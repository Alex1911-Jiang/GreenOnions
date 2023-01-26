using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GreenOnions.Interface;
using GreenOnions.Interface.Items;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace GreenOnions.Utility
{
    public static class BotInfo
    {
       private static Assembly _assembly_mscorlib = null;

        /// <summary>
        /// 配置文件
        /// </summary>
        public static BotConfig Config { get; private set; }

        /// <summary>
        /// 运行中的缓存
        /// </summary>
        public static BotCache Cache { get; } = new BotCache();

        /// <summary>
        /// RSS发送日期记录
        /// </summary>
        public static ConcurrentDictionary<string, DateTime> LastOneSendRssTime { get; set; } = new ConcurrentDictionary<string, DateTime>();

        /// <summary>
        /// 插件状态
        /// </summary>
        public static Dictionary<string, bool> PluginStatus { get; set; } = new Dictionary<string, bool>();

        /// <summary>
        /// 是否登录
        /// </summary>
        public static bool IsLogin { get; set; } = false;

        /// <summary>
        /// 葱葱API接口
        /// </summary>
        public static IGreenOnionsApi API { get; set; }


        static BotInfo()
        {
            if (File.Exists("config.json"))
            {
                string strConfig = File.ReadAllText("config.json");
                Config = JsonConvert.DeserializeObject<BotConfig>(strConfig);
                if (Config.QQId == 0)
                {
                    Config = UpdateOldConfig(strConfig);
                }
            }
            else
            {
                Console.WriteLine($"不存在配置文件{new FileInfo("config.json").FullName}");
            }
            if (Config is null)
            {
                Console.WriteLine("生成新的配置文件");
                Config = new BotConfig() { QQId = -1 };
                Config.CreateDefaultValue();
            }
            SaveConfigFile();

            Cache.SauceNAOKeysAndLongRemaining = new ConcurrentDictionary<string, int>();
            foreach (var key in Config.SauceNAOApiKey)
                Cache.SauceNAOKeysAndLongRemaining.TryAdd(key, 200);

            Cache.SauceNAOKeysAndShortRemaining = new ConcurrentDictionary<string, int>();
            foreach (var key in Config.SauceNAOApiKey)
                Cache.SauceNAOKeysAndShortRemaining.TryAdd(key, 6);

            Task.Run(async () =>
            {
                while (true)
                {
                    foreach (var key in Config.SauceNAOApiKey)
                    {
                        if (!Cache.SauceNAOKeysAndLongRemaining.ContainsKey(key))  //如果添加了新Key, 装进缓存
                            Cache.SauceNAOKeysAndLongRemaining.TryAdd(key, 200);
                        if (!Cache.SauceNAOKeysAndShortRemaining.ContainsKey(key))  //如果添加了新Key, 装进缓存
                            Cache.SauceNAOKeysAndShortRemaining.TryAdd(key, 6);
                    }
                    var removeLong = Cache.SauceNAOKeysAndLongRemaining.Keys.ToList().Except(Config.SauceNAOApiKey);
                    foreach (var item in removeLong)
                        Cache.SauceNAOKeysAndLongRemaining.TryRemove(item, out _);
                    var removeShort = Cache.SauceNAOKeysAndShortRemaining.Keys.ToList().Except(Config.SauceNAOApiKey);
                    foreach (var item in removeShort)
                        Cache.SauceNAOKeysAndShortRemaining.TryRemove(item, out _);
                    await Task.Delay(1000 * 60 * 10);
                }
            });

            Task.Run(async () =>
            {
                while (true)
                {
                    foreach (var item in Cache.SauceNAOKeysAndLongRemaining)  //每7.5分钟恢复1次
                    {
                        if (Cache.SauceNAOKeysAndLongRemaining[item.Key] < 200)
                            Cache.SauceNAOKeysAndLongRemaining[item.Key] += 1;
                    }
                    await Task.Delay(1000 * 450);

                    Cache.CheckWorkingTimeout(Cache.SearchingPicturesUsers);  //顺便检查正在搜图的人超时了没有
                    Cache.CheckWorkingTimeout(Cache.SearchingAnimeUsers);
                    Cache.CheckWorkingTimeout(Cache.Searching3DUsers);
                }
            });
            Task.Run(async () =>
            {
                while (true)
                {
                    foreach (var item in Cache.SauceNAOKeysAndShortRemaining)  //每5秒恢复1次
                    {
                        if (Cache.SauceNAOKeysAndShortRemaining[item.Key] < 6)
                            Cache.SauceNAOKeysAndShortRemaining[item.Key] += 1;
                    }
                    await Task.Delay(1000 * 5);
                }
            });

            if (File.Exists("rssCache.json"))
            {
                string strRssCache = File.ReadAllText("rssCache.json");
                LastOneSendRssTime = JsonConvert.DeserializeObject<ConcurrentDictionary<string, DateTime>>(strRssCache);
            }

            if (File.Exists("plugin.json"))
            {
                string strPlugins = File.ReadAllText("plugin.json");
                PluginStatus = JsonConvert.DeserializeObject<Dictionary<string, bool>>(strPlugins);
            }
        }

        public static void Init()  //空方法，目的是为了触发构造函数
        { 
        
        }

        private static BotConfig UpdateOldConfig(string strConfig)
        {
            JToken jt = JsonConvert.DeserializeObject<JToken>(strConfig);
            BotConfig botConfig = new BotConfig();
            UpdateOldConfigOneNode(botConfig, jt, "Bot");
            UpdateOldConfigOneNode(botConfig, jt, "PictureSearcher");
            UpdateOldConfigOneNode(botConfig, jt, "HPicture");
            UpdateOldConfigOneNode(botConfig, jt, "Translate");
            UpdateOldConfigOneNode(botConfig, jt, "Repeater");
            UpdateOldConfigOneNode(botConfig, jt, "GroupMemberEvent");
            UpdateOldConfigOneNode(botConfig, jt, "ForgeMessage");
            UpdateOldConfigOneNode(botConfig, jt, "Rss");
            UpdateOldConfigOneNode(botConfig, jt, "Other");
            return botConfig;
        }

        private static void UpdateOldConfigOneNode(BotConfig botConfig, JToken jt, string nodeName)
        {
            PropertyInfo[] coreProps = botConfig.GetType().GetProperties();
            for (int i = 0; i < coreProps.Length; i++)
            {
                object jValue = jt[nodeName][coreProps[i].Name];
                if (jValue is not null)
                {
                    object? actualValue = null;
                    try
                    {
                        actualValue = Convert.ChangeType(jValue, coreProps[i].PropertyType);
                        if (actualValue is not null)
                            coreProps[i].SetValue(botConfig, actualValue);
                    }
                    catch
                    {
                        string[] strValue = jValue.ToString().Split(";");
                        (object hash, Type elementType) = GetListObject(coreProps[i].PropertyType);
                        object[] actualArray = null;
                        if (elementType.IsEnum)
                        {
                            actualArray = Array.ConvertAll(strValue, s => Enum.Parse(elementType, s));
                        }
                        else if (elementType.IsClass && elementType.Name != "String")  //RssSubscriptionItem
                        {
                            HashSet<RssSubscriptionItem> rssItems = JsonConvert.DeserializeObject<HashSet<RssSubscriptionItem>>(strValue[0]);
                            coreProps[i].SetValue(botConfig, rssItems);
                            continue;
                        }
                        else
                        {
                            actualArray = Array.ConvertAll(strValue, s => Convert.ChangeType(s, elementType));
                        }
                        MethodInfo methodAdd = hash.GetType().GetMethod("Add");
                        for (int j = 0; j < actualArray.Length; j++)
                            methodAdd.Invoke(hash, new object[] { actualArray[j] });
                        coreProps[i].SetValue(botConfig, hash);
                    }
                }
            }
        }

        private static (object hash, Type elementType) GetListObject(Type listType)
        {
            if (_assembly_mscorlib is null)
                _assembly_mscorlib = Assembly.Load("mscorlib");
            Type elementType = GetEnumerableType(listType);
            string elementTypeName = elementType.FullName;
            Type lstType;
            if (elementType.IsEnum || (elementType.IsClass && elementType.Name != "String"))
                lstType = _assembly_mscorlib.GetType($"System.Collections.Generic.List`1[[{elementTypeName}, {elementType.Assembly}]]");
            else
                lstType = _assembly_mscorlib.GetType($"System.Collections.Generic.List`1[{elementTypeName}]");
            object lst = Activator.CreateInstance(lstType);
            MethodInfo tMethodToHashSet = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == "ToHashSet").First();
            MethodInfo methodToHashSet = tMethodToHashSet.MakeGenericMethod(elementType);
            object hash = methodToHashSet.Invoke(null, new[] { lst });
            return (hash, elementType);
        }

        private static Type GetEnumerableType(Type type) 
        { 
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments().First();
            var iface = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)).FirstOrDefault();
            return GetEnumerableType(iface); 
        }

        public static void SaveConfigFile()
        {
            lock (Config)
            {
                string config = JsonConvert.SerializeObject(Config, Formatting.Indented, new StringEnumConverter());
                File.WriteAllText("config.json", config);
            }
        }

        public static void SavePluginsStatus()
        {
            string pluginStatus = JsonConvert.SerializeObject(PluginStatus, Formatting.Indented, new StringEnumConverter());
            File.WriteAllText("plugin.json", pluginStatus);
        }
    }
}