using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GreenOnions.Utility.Helper
{
    public static class JsonHelper
    {
        public const string JsonNodeNameBot = "Bot";
        public const string JsonNodeNamePictureSearcher = "PictureSearcher";
        public const string JsonNodeNameHPicture = "HPicture";
        public const string JsonNodeNameTranslate = "Translate";
        public const string JsonNodeNameRepeater = "Repeater";
        public const string JsonNodeNameGroupMemberEvent = "GroupMemberEvent";
        public const string JsonNodeNameForgeMessage = "ForgeMessage";
        public const string JsonNodeNameRss = "Rss";
        public const string JsonNodeNameTicTacToe = "TicTacToe";
        public const string JsonNodeNameOther = "Other";

        private static JObject jsonConfig = null;
        private static JObject jsonCache = null;
        public static string JsonConfigFileName { get; set; }
        public static string JsonCacheFileName { get; set; }

        static JsonHelper()
        {
            JsonConfigFileName = Path.Combine(Environment.CurrentDirectory, "config.json");
            JsonCacheFileName = Path.Combine(Environment.CurrentDirectory, "cache.json");
        }

        /// <summary>
        /// 读取json文件
        /// </summary>
        /// <param name="jsonFileName">json文件路径</param>
        /// <param name="group">顶层键</param>
        /// <param name="key">次层键</param>
        /// <returns>读取到的值</returns>
        public static string GetSerializationValue(string jsonFileName, string group, string key)
        {
            JObject json = null;

            if (jsonFileName == JsonConfigFileName)
                if (jsonConfig == null)
                    if (File.Exists(jsonFileName))
                        using (StreamReader file = File.OpenText(jsonFileName))
                        using (JsonTextReader reader = new JsonTextReader(file))
                            jsonConfig = (JObject)JToken.ReadFrom(reader);

            if (jsonFileName == JsonCacheFileName)
                if (jsonCache == null)
                    if (File.Exists(jsonFileName))
                        using (StreamReader file = File.OpenText(jsonFileName))
                        using (JsonTextReader reader = new JsonTextReader(file))
                            jsonCache = (JObject)JToken.ReadFrom(reader);


            if (jsonFileName == JsonConfigFileName)
                json = jsonConfig;
            else if (jsonFileName == JsonCacheFileName)
                json = jsonCache;
            JToken oGroup = json?[group];
            var value = oGroup?[key];
            return value?.ToString();
        }

        /// <summary>
        /// 写入json文件
        /// </summary>
        /// <param name="jsonFilePath">json文件路径</param>
        /// <param name="group">顶层键</param>
        /// <param name="key">次层键</param>
        /// <param name="Value">值</param>
        public static void SetSerializationValue(string jsonFilePath, string group, string key, string value)
        {
            string json = null;
            if (jsonFilePath == JsonConfigFileName)
            {
                if (jsonConfig == null)
                    json = File.Exists(jsonFilePath) ? File.ReadAllText(jsonFilePath) : "";
                else
                    json = jsonConfig.ToString();
            }
            else if (jsonFilePath == JsonCacheFileName)
            {
                if (jsonCache == null)
                    json = File.Exists(jsonFilePath) ? File.ReadAllText(jsonFilePath) : "";
                else
                    json = jsonCache.ToString();
            }
            Dictionary<string, Dictionary<string, string>> dicJson = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json) ?? new Dictionary<string, Dictionary<string, string>>();
            if (dicJson.ContainsKey(group))
            {
                if (dicJson[group].ContainsKey(key))
                    dicJson[group][key] = value;
                else
                    dicJson[group].Add(key, value);
            }
            else
            {
                dicJson.Add(group, new Dictionary<string, string>());
                dicJson[group].Add(key, value);
            }
            if (jsonFilePath == JsonConfigFileName)
                jsonConfig = JObject.Parse(JsonConvert.SerializeObject(dicJson, Formatting.Indented));
            else if (jsonFilePath == JsonCacheFileName)
                jsonCache = JObject.Parse(JsonConvert.SerializeObject(dicJson, Formatting.Indented));
        }

        public static void SaveConfigFile() => File.WriteAllText("config.json", jsonConfig.ToString());
        public static void SaveCacheFile() => File.WriteAllText("cache.json", jsonCache.ToString());

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
    }
}
