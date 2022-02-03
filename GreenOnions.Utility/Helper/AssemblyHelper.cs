using System;
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

        public static string ReplacePropertyChineseNameToValue(string str)
        {
            PropertyInfo[] PropertyInfos = CreateType("GreenOnions.Utility", "GreenOnions.Utility.BotInfo").GetProperties();
            foreach (PropertyInfo item in PropertyInfos)
            {
                foreach (var attributes in item.CustomAttributes)
                {
                    if (attributes.AttributeType.Name == "PropertyChineseNameAttribute")
                    {
                        var attribute = attributes.ConstructorArguments.Select(v => v.Value).FirstOrDefault();
                        if (attribute != null)
                        {
                            string strAttribute = attribute.ToString();
                            str = str.Replace($"<{strAttribute}>", item.GetValue(null).ToString());
                        }
                    }
                }
            }
            return str;
        }
    }
}
