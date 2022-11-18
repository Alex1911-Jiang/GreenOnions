using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GreenOnions.Utility.Helper
{
    public static class AssemblyHelper
    {
        //public static Dictionary<string, object> GetAllPropertiesValue()
        //{
        //    PropertyInfo[] PropertyInfos = typeof(BotConfig).GetProperties();
        //    if (PropertyInfos is null)
        //    {
        //        LogHelper.WriteWarningLog("获取配置信息失败");
        //        return null;
        //    }
        //    Dictionary<string, object> props = new Dictionary<string, object>();
        //    foreach (PropertyInfo item in PropertyInfos)
        //    {
        //        object val = item.GetValue(BotInfo.Config);
        //        if (!props.ContainsKey(item.Name))
        //        {
        //            props.Add(item.Name, val);
        //            try
        //            {
        //                foreach (var attributes in item.CustomAttributes)
        //                {
        //                    if (attributes.AttributeType.Name == "PropertyChineseNameAttribute")
        //                    {
        //                        var attribute = attributes.ConstructorArguments.Select(v => v.Value).FirstOrDefault();
        //                        if (attribute is not null && !props.ContainsKey(attribute.ToString()))
        //                            props.Add(attribute.ToString(), val);
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                LogHelper.WriteErrorLogWithUserMessage($"属性特性转换为属性值时发生异常, 属性为:{item.Name}", ex);
        //            }
        //        }
        //    }
        //    return props;
        //}

        //public static string ReplacePropertyChineseNameToValue(string str)
        //{
        //    PropertyInfo[] PropertyInfos = typeof(BotConfig).GetProperties();
        //    if (PropertyInfos is null)
        //    {
        //        LogHelper.WriteWarningLog("获取配置信息失败");
        //        return str;
        //    }
        //    foreach (PropertyInfo item in PropertyInfos)
        //    {
        //        try
        //        {
        //            foreach (var attributes in item.CustomAttributes)
        //            {
        //                if (attributes.AttributeType.Name == "PropertyChineseNameAttribute")
        //                {
        //                    var attribute = attributes.ConstructorArguments.Select(v => v.Value).FirstOrDefault();
        //                    if (attribute is not null)
        //                        str = str.Replace($"<{attribute}>", item.GetValue(BotInfo.Config)?.ToString());
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.WriteErrorLogWithUserMessage($"属性特性转换为属性值时发生异常, 属性为:{item.Name}", ex);
        //        }
        //    }
        //    return str;
        //}
    }
}
