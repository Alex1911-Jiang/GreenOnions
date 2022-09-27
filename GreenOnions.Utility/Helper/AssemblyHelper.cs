using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GreenOnions.Utility.Helper
{
    public static class AssemblyHelper
    {
        public static T CallStaticMethod<T>(string dllName, string className, string methodName, params object[] param)
        {
            Type type = CreateType(dllName, className);
            MethodInfo method = type.GetMethod(methodName);
            return (T)method.Invoke(null, param);
        }

        public static Type CreateType(string dllName, string className)
        {
            string dllFileName = Path.Combine(Environment.CurrentDirectory, dllName + ".dll");
            Assembly assembly;
            if (Cache.Assemblies.ContainsKey(dllFileName))
            {
                assembly = Cache.Assemblies[dllFileName];
            }
            else
            {
                byte[] bytes = File.ReadAllBytes(dllFileName);
                assembly = Assembly.Load(bytes);
                Cache.Assemblies.Add(dllFileName, assembly);
            }
            Type type = assembly.GetType(className);
            return type;
        }

        public static Dictionary<string, string> GetAllPropertiesValue()
        {
            PropertyInfo[] PropertyInfos = typeof(BotInfo).GetProperties();
            if (PropertyInfos == null)
            {
                LogHelper.WriteWarningLog("获取配置信息失败");
                return null;
            }
            Dictionary<string, string> props = new Dictionary<string, string>();
            foreach (PropertyInfo item in PropertyInfos)
            {
                string val = item.GetValue(null)?.ToString();
                if (!props.ContainsKey(item.Name))
                {
                    props.Add(item.Name, val);
                    try
                    {
                        foreach (var attributes in item.CustomAttributes)
                        {
                            if (attributes.AttributeType.Name == "PropertyChineseNameAttribute")
                            {
                                var attribute = attributes.ConstructorArguments.Select(v => v.Value).FirstOrDefault();
                                if (attribute != null && !props.ContainsKey(attribute.ToString()))
                                    props.Add(attribute.ToString(), val);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteErrorLogWithUserMessage($"属性特性转换为属性值时发生异常, 属性为:{item.Name}", ex);
                    }
                }
            }
            return props;
        }

        public static string ReplacePropertyChineseNameToValue(string str)
        {
            PropertyInfo[] PropertyInfos = typeof(BotInfo).GetProperties();
            if (PropertyInfos == null)
            {
                LogHelper.WriteWarningLog("获取配置信息失败");
                return str;
            }
            foreach (PropertyInfo item in PropertyInfos)
            {
                try
                {
                    foreach (var attributes in item.CustomAttributes)
                    {
                        if (attributes.AttributeType.Name == "PropertyChineseNameAttribute")
                        {
                            var attribute = attributes.ConstructorArguments.Select(v => v.Value).FirstOrDefault();
                            if (attribute != null)
                                str = str.Replace($"<{attribute}>", item.GetValue(null)?.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogWithUserMessage($"属性特性转换为属性值时发生异常, 属性为:{item.Name}", ex);
                }
            }
            return str;
        }
    }
}
