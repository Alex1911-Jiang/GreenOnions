using GreenOnions.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GreenOnions.BotMain
{
    public static class AssemblyHelper
    {
        public static T CallStaticMethod<T>(string dllName, string className, string methodName, params object[] param)
        {
            Type type = CreateType(dllName, className);
            MethodInfo method = type.GetMethod(methodName);
            return (T)method.Invoke(null, param);
        }

        private static Type CreateType(string dllName, string className)
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
    }
}
