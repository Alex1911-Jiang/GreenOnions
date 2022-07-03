using GreenOnions.Interface;
using System.IO;
using System.Reflection;

namespace GreenOnions.Utility.Helper
{
    public static class ConfigHelper
    {
        public static void CreateConfig()
        {
            PropertyInfo[] PropertyInfos = typeof(BotInfo).GetProperties();
            for (int i = 0; i < PropertyInfos.Length; i++)
            {
                if (PropertyInfos[i].CanWrite)
                    PropertyInfos[i].SetValue(null, PropertyInfos[i].GetValue(null));
            }
            SaveConfigFile();
        }

        public static void CreateCache()
        {
            PropertyInfo[] PropertyInfos = typeof(Cache).GetProperties();
            for (int i = 0; i < PropertyInfos.Length; i++)
            {
                if (PropertyInfos[i].CanWrite)
                    PropertyInfos[i].SetValue(null, PropertyInfos[i].GetValue(null));
            }
            SaveCacheFile();
        }

        public static void SaveConfigFile() => File.WriteAllText("config.json", JsonHelper.JsonConfig.ToString());
        public static void SaveCacheFile() => File.WriteAllText("cache.json", JsonHelper.JsonCache.ToString());
    }
}
