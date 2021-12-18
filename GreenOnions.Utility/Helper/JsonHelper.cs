using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace GreenOnions.Utility.Helper
{
    public static class JsonHelper
    {
        private static JObject jsonCache = null;

        /// <summary>
        /// 读取json文件
        /// </summary>
        /// <param name="jsonFileName">json文件路径</param>
        /// <param name="group">顶层键</param>
        /// <param name="key">次层键</param>
        /// <returns>读取到的值</returns>
        public static string GetSerializationValue(string jsonFileName, string group, string key)
        {
            if (jsonCache == null)
                if (File.Exists(jsonFileName))
                    using (StreamReader file = File.OpenText(jsonFileName))
                        using (JsonTextReader reader = new JsonTextReader(file))
                            jsonCache = (JObject)JToken.ReadFrom(reader);
            var oGroup = jsonCache?[group];
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
            string json;
            if (jsonCache == null)
                json = File.Exists(jsonFilePath) ? File.ReadAllText(jsonFilePath) : "";
            else
                json = jsonCache.ToString();

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
            jsonCache = JObject.Parse(JsonConvert.SerializeObject(dicJson, Formatting.Indented));
        }

        public static void SaveConfigFile() => File.WriteAllText("config.json", jsonCache.ToString());
    }
}
