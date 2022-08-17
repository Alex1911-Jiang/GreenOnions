using GreenOnions.Utility;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace GreenOnions.Command
{
    public static class CommandEditor
    {
        private static readonly Dictionary<string, string> _typeDescription = new Dictionary<string, string>()
        {
            {"String","文字" },
            {"Int16","数字" },
            {"Int32","数字" },
            {"Int64","数字" },
            {"Float","数字" },
            {"Double","数字" },
            {"Decimal","数字" },
            {"Boolean","布尔" },
            {"IEnumerable","集合" },
            {"IEnumerable`1","集合" },
            {"Array","集合" },
            {"List","集合" },
            {"List`1","集合" },
        };

        public static async Task<string?> HandleCommand(string message, Func<string> UpdateRegex)
        {
            bool bGet = false;
            bool bSet = false;
            bool bList = false;
            bool bDescription = false;
            bool bAddRss = false;
            bool bRemoveRss = false;
            if ((bGet = message.StartsWith("--get ", StringComparison.OrdinalIgnoreCase)) || 
                (bSet = message.StartsWith("--set ", StringComparison.OrdinalIgnoreCase)) || 
                (bList = message.StartsWith("--list", StringComparison.OrdinalIgnoreCase)) ||
                (bDescription = message.StartsWith("--description ", StringComparison.OrdinalIgnoreCase)) ||
                (bAddRss = message.StartsWith("--addrss ", StringComparison.OrdinalIgnoreCase)) ||
                (bRemoveRss = message.StartsWith("--removerss ", StringComparison.OrdinalIgnoreCase)))
            {
                if (bGet)
                {
                    string commandBody = message.Substring("--get ".Length).Trim();
                    PropertyInfo? prop = FindProperty(commandBody);

                    if (prop != null)
                    {
                        object originalVal = prop.GetValue(null);
                        string strValue;
                        string strAddDescription = string.Empty;
                        if (!(originalVal is string) && originalVal is IEnumerable enu)
                        {
                            List<string> elements = new List<string>();
                            foreach (var item in enu)
                                elements.Add(item.ToString());
                            strValue = string.Join(";\r\n", elements);
                        }
                        else if (prop.PropertyType.IsEnum)
                        {
                            List<string> lstEnumName = new List<string>();
                            foreach (var item in Enum.GetValues(prop.PropertyType))
                                lstEnumName.Add(item.ToString());
                            strValue = originalVal.ToString();
                            strAddDescription = $"\r\n该属性是一个枚举，允许的值有：\r\n{string.Join(";\r\n", lstEnumName)}";
                        }
                        else
                            strValue = originalVal.ToString();
                        return $"属性<{prop.Name}>的值为:{strValue} {strAddDescription}。";
                    }

                }
                else if(bSet)
                {
                    string commandBody = message.Substring("--set ".Length).Trim();
                    int firstEqualIndex = commandBody.IndexOf('=');
                    if (firstEqualIndex > -1)
                    {
                        string propName = commandBody[..firstEqualIndex].TrimStart();
                        string propValue = commandBody[(firstEqualIndex + 1)..].TrimEnd();

                        PropertyInfo? prop = FindProperty(propName);
                        if (prop != null)
                        {
                            object originalVal = prop.GetValue(null);
                            Type originalType = originalVal.GetType();
                            try
                            {
                                if (!(originalVal is string) && originalVal is IEnumerable)
                                {
                                    Type elementType = GetEnumerableType(originalType);

                                    string[] elements = propValue.Split(';');
                                    if (elementType == typeof(long))
                                        prop.SetValue(null, elements.Select(s => Convert.ToInt64(s)).ToList());
                                    else
                                        prop.SetValue(null, elements);
                                    propValue = $"\r\n{string.Join(";\r\n", elements)}";
                                }
                                else if (prop.PropertyType.IsEnum)
                                {
                                    object enu = Enum.Parse(originalType, propValue);
                                    prop.SetValue(null, enu);
                                    propValue = enu.ToString();
                                }
                                else
                                {
                                    prop.SetValue(null, Convert.ChangeType(propValue, originalType));
                                }
                                string strUpdateRegexMessage = UpdateRegex();
                                return $"属性<{prop.Name}>值已成功设置为:{propValue}。{strUpdateRegexMessage}";
                            }
                            catch (Exception ex)
                            {
                                if (originalVal is IEnumerable)
                                {
                                    Type? elementType = GetEnumerableType(originalType);
                                    if (elementType != null)
                                        return $"属性<{prop.Name}>值设置失败，该属性是一个集合，元素类型为:{_typeDescription[elementType.Name]}，添加多个元素请使用英文分号隔开。";
                                }
                                else if (prop.PropertyType.IsEnum)
                                {
                                    List<string> lstEnumName = new List<string>();
                                    foreach (var item in Enum.GetValues(prop.PropertyType))
                                        lstEnumName.Add(item.ToString());
                                    return $"属性<{prop.Name}>值设置失败，该属性是一个枚举，允许的值有:\r\n{string.Join(";\r\n", lstEnumName)}。";
                                }
                                else if (originalVal is bool)
                                {
                                    return $"属性<{prop.Name}>值设置失败，该属性是一个布尔，允许的值有:true(代表是)\r\nfalse(代表否)。";
                                }
                                else
                                {
                                    return $"属性<{prop.Name}>值设置失败，该属性是一个{_typeDescription[originalType.Name]}。";
                                }
                            }
                        }
                    }
                }
                else if (bList)
                {
                    string commandBody = message.Substring("--list".Length).Trim();
                    if (string.IsNullOrWhiteSpace(commandBody))
                    {
                        HashSet<string> nodes = new HashSet<string>();
                        foreach (KeyValuePair<PropertyInfo, PropertyChineseNameAttribute> item in FindPropertysByNodeName(null))
                            nodes.Add(item.Value.NodeName);
                        return $"属性存在\r\n<{string.Join(">\r\n<", nodes)}>\r\n个分组，如果需要列出各组中的属性，请输入命令\"--list 组名\"(不含尖括号)";
                    }
                    else
                    {
                        Dictionary<PropertyInfo, PropertyChineseNameAttribute> props = FindPropertysByNodeName(commandBody);
                        List<string> strProps = new List<string>();
                        foreach (KeyValuePair<PropertyInfo, PropertyChineseNameAttribute> item in props)
                        {
                            string description = string.Empty;
                            if (!string.IsNullOrEmpty(item.Value.Description))
                                description = $" ({item.Value.Description})";
                            strProps.Add($"属性:<{item.Key.Name}>, 别名:<{item.Value.ChineseName}{description}>");
                        }
                        return $"{string.Join("\r\n", strProps)}\r\n如果需要获取属性的值请使用命令 \"--get 属性名\"(不含尖括号)" ;
                    }
                }
            }
            return null;
        }

        private static Type? GetEnumerableType(Type type)
        {
            if (type == null)
                return null;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments()[0];

            var iface = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)).FirstOrDefault();

            if (iface == null)
                return null;

            return GetEnumerableType(iface);
        }

        private static PropertyInfo? FindProperty(string propName)
        {
            PropertyInfo[] props = typeof(BotInfo).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].Name == propName)
                {
                    return props[i];
                }
                PropertyChineseNameAttribute? chnNameAttr = props[i].GetCustomAttribute<PropertyChineseNameAttribute>();
                if (chnNameAttr != null)
                {
                    if (chnNameAttr.ChineseName == propName)
                    {
                        return props[i];
                    }
                }
            }
            return null;
        }

        private static Dictionary<PropertyInfo, PropertyChineseNameAttribute> FindPropertysByNodeName(string nodeName)
        {
            Dictionary<PropertyInfo, PropertyChineseNameAttribute> propertyInfos = new Dictionary<PropertyInfo, PropertyChineseNameAttribute>();
            PropertyInfo[] props = typeof(BotInfo).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                PropertyChineseNameAttribute? chnNameAttr = props[i].GetCustomAttribute<PropertyChineseNameAttribute>();
                if (chnNameAttr != null)
                {
                    if (string.IsNullOrWhiteSpace(nodeName) || chnNameAttr.NodeName == nodeName)
                        propertyInfos.Add(props[i], chnNameAttr);
                }
            }
            return propertyInfos;
        }
    }
}