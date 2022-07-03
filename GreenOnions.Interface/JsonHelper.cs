using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GreenOnions.Interface
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
        public const string JsonNodeNamePlugin = "Plugin";

        public static JObject JsonConfig { get; set; }
        public static JObject JsonCache { get; set; }
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
            {
                if (JsonConfig == null)
                    if (File.Exists(jsonFileName))
                        JsonConfig = ReadJsonFile(jsonFileName);
                json = JsonConfig;
            }
            else if (jsonFileName == JsonCacheFileName)
            {
                if (JsonCache == null)
                    if (File.Exists(jsonFileName))
                        JsonCache = ReadJsonFile(jsonFileName);
                json = JsonCache;
            }
            else
            {
                if (File.Exists(jsonFileName))
                    json = ReadJsonFile(jsonFileName);
            }

            JToken oGroup = json?[group];
            var value = oGroup?[key];
            return value?.ToString();
        }

        private static JObject ReadJsonFile(string jsonFileName)
        {
            using (StreamReader file = File.OpenText(jsonFileName))
            using (JsonTextReader reader = new JsonTextReader(file))
                return (JObject)JToken.ReadFrom(reader);
        }

        /// <summary>
        /// 写入json文件
        /// </summary>
        /// <param name="jsonFilePath">json文件路径</param>
        /// <param name="group">顶层键</param>
        /// <param name="key">次层键</param>
        /// <param name="value">值</param>
        public static void SetSerializationValue(string jsonFilePath, string group, string key, string value)
        {
            string json = null;
            if (jsonFilePath == JsonConfigFileName)
            {
                if (JsonConfig == null)
                    json = File.Exists(jsonFilePath) ? File.ReadAllText(jsonFilePath) : "";
                else
                    json = JsonConfig.ToString();
            }
            else if (jsonFilePath == JsonCacheFileName)
            {
                if (JsonCache == null)
                    json = File.Exists(jsonFilePath) ? File.ReadAllText(jsonFilePath) : "";
                else
                    json = JsonCache.ToString();
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
                JsonConfig = JObject.Parse(JsonConvert.SerializeObject(dicJson, Formatting.Indented));
            else if (jsonFilePath == JsonCacheFileName)
                JsonCache = JObject.Parse(JsonConvert.SerializeObject(dicJson, Formatting.Indented));
        }
    }
}
