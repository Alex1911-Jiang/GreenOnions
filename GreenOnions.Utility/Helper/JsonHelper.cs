using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GreenOnions.Utility.Helper
{
    public static class JsonHelper
    {/// <summary>
     /// 读取json文件
     /// </summary>
     /// <param name="jsonFilePath">json文件路径</param>
     /// <param name="group">顶层键</param>
     /// <param name="key">次层键</param>
     /// <returns>读取到的值</returns>
        public static string GetSerializationValue(string jsonFilePath, string group, string key)
        {
            if (File.Exists(jsonFilePath))
            {
                using (StreamReader file = System.IO.File.OpenText(jsonFilePath))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject o = (JObject)JToken.ReadFrom(reader);
                        var oGroup = o?[group];
                        var value = oGroup?[key];
                        return value?.ToString();
                    }
                }
            }
            return null;
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
            string json = File.Exists(jsonFilePath) ? File.ReadAllText(jsonFilePath) : "";
            Dictionary<string, Dictionary<string, string>> dicJson =  JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json) ?? new Dictionary<string, Dictionary<string, string>>();
            if (dicJson.ContainsKey(group))
            {
                if (dicJson[group].ContainsKey(key))
                {
                    dicJson[group][key] = value;
                }
                else
                {
                    dicJson[group].Add(key, value);
                }
            }
            else
            {
                dicJson.Add(group, new Dictionary<string, string>());
                dicJson[group].Add(key, value);
            }
            string output = JsonConvert.SerializeObject(dicJson, Formatting.Indented);
            File.WriteAllText("config.json", output);
        }
    }
}
