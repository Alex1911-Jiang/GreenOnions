using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using GreenOnions.Interface;
using GreenOnions.Interface.Configs;
using GreenOnions.Interface.Items;
using GreenOnions.Utility;

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

        public static string? HandleCommand(string message, Func<string> UpdateRegex)
        {
            bool bGet = false;
            bool bSet = false;
            bool bList = false;
            bool bDescription = false;
            bool bRss = false;
            bool bAddRss = false;
            bool bRemoveRss = false;
            if ((bGet = message.StartsWith("--get ", StringComparison.OrdinalIgnoreCase)) || 
                (bSet = message.StartsWith("--set ", StringComparison.OrdinalIgnoreCase)) || 
                (bList = message.StartsWith("--list", StringComparison.OrdinalIgnoreCase)) ||
                (bDescription = message.StartsWith("--description ", StringComparison.OrdinalIgnoreCase)) ||
                (bRss = message.StartsWith("--rss", StringComparison.OrdinalIgnoreCase)) ||
                (bAddRss = message.StartsWith("--addrss ", StringComparison.OrdinalIgnoreCase)) ||
                (bRemoveRss = message.StartsWith("--removerss ", StringComparison.OrdinalIgnoreCase)))
            {
                if (bGet)  //获取属性值
                {
                    string commandBody = message.Substring("--get".Length).Trim();
                    if (!string.IsNullOrWhiteSpace(commandBody))
                    {
                        PropertyInfo? prop = FindProperty(commandBody);
                        if (prop is not null)
                        {
                            object originalVal = prop.GetValue(BotInfo.Config)!;
                            string strValue;
                            string strAddDescription = string.Empty;
                            if (!(originalVal is string) && originalVal is IEnumerable enu)
                            {
                                List<string> elements = new List<string>();
                                foreach (var item in enu)
                                    elements.Add(item.ToString()!);
                                strValue = string.Join(";\r\n", elements);
                            }
                            else if (prop.PropertyType.IsEnum)
                            {
                                strValue = originalVal.ToString()!;
                                strAddDescription = $"\r\n该属性是一个枚举，如果需要列出允许的值，请使用\"--description <属性名>\"命令(不含尖括号)";
                            }
                            else
                                strValue = originalVal.ToString()!;
                            return $"属性<{prop.Name}>的值为:{strValue} {strAddDescription}。";
                        }
                    }
                }
                else if (bSet)  //设置属性值
                {
                    string commandBody = message.Substring("--set".Length).Trim();
                    if (!string.IsNullOrWhiteSpace(commandBody))
                    {
                        int firstEqualIndex = commandBody.IndexOf('=');
                        if (firstEqualIndex > -1)
                        {
                            string propName = commandBody[..firstEqualIndex].TrimStart();
                            string propValue = commandBody[(firstEqualIndex + 1)..].TrimEnd();

                            PropertyInfo? prop = FindProperty(propName);
                            if (prop is not null)
                            {
                                object originalVal = prop.GetValue(BotInfo.Config)!;
                                Type originalType = originalVal.GetType();
                                try
                                {
                                    if (!(originalVal is string) && originalVal is IEnumerable)
                                    {
                                        Type elementType = GetEnumerableType(originalType)!;

                                        string[] elements = propValue.Split(';');
                                        if (elementType == typeof(long))
                                            prop.SetValue(BotInfo.Config, elements.Select(s => Convert.ToInt64(s)).ToList());
                                        else
                                            prop.SetValue(BotInfo.Config, elements);
                                        propValue = $"\r\n{string.Join(";\r\n", elements)}";
                                    }
                                    else if (prop.PropertyType.IsEnum)
                                    {
                                        if (propValue.EndsWith(';'))
                                            propValue = propValue.Remove(propValue.Length - 1);
                                        if (Enum.TryParse(originalType, propValue, out object? enu))
                                        {
                                            if (enu != null)
                                            {
                                                prop.SetValue(BotInfo.Config, enu);
                                                propValue = enu.ToString()!;
                                            }
                                            else
                                            {
                                                return ShowEnumValues();
                                            }
                                        }
                                        else
                                        {
                                            return ShowEnumValues();
                                        }
                                    }
                                    else
                                    {
                                        prop.SetValue(BotInfo.Config, Convert.ChangeType(propValue, originalType));
                                    }
                                    string strUpdateRegexMessage = UpdateRegex();
                                    BotInfo.SaveConfigFile();
                                    return $"属性<{prop.Name}>值已成功设置为:{propValue}。{strUpdateRegexMessage}";
                                }
                                catch (Exception ex)
                                {
                                    if (originalVal is IEnumerable)
                                    {
                                        Type? elementType = GetEnumerableType(originalType);
                                        if (elementType is not null)
                                        {
                                            string typeChineseName = elementType.Name;
                                            if (_typeDescription.ContainsKey(elementType.Name))
                                                typeChineseName = _typeDescription[elementType.Name];
                                            return $"属性<{prop.Name}>值设置失败，该属性是一个集合，元素类型为:{typeChineseName}，添加多个元素请使用英文分号隔开。";

                                        }
                                    }
                                    else if (prop.PropertyType.IsEnum)
                                    {
                                        return ShowEnumValues();
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
                            string ShowEnumValues()
                            {

                                List<string> lstEnumName = new List<string>();
                                foreach (var item in Enum.GetValues(prop.PropertyType))
                                    lstEnumName.Add(item.ToString()!);
                                return $"属性<{prop.Name}>值设置失败，该属性是一个枚举，允许的值有:\r\n{string.Join(";\r\n", lstEnumName)}。";
                            }
                        }
                    }
                }
                else if (bList)  //列出属性
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
                            strProps.Add($"属性:<{item.Key.Name}>, 别名:<{item.Value.ChineseName}>{description}");
                        }
                        return $"{string.Join("\r\n", strProps)}\r\n如果需要获取属性的值请使用命令 \"--get 属性名\"(不含尖括号)";
                    }
                }
                else if (bDescription)
                {
                    string commandBody = message.Substring("--description".Length).Trim();
                    if (!string.IsNullOrWhiteSpace(commandBody))
                    {
                        PropertyInfo? prop = FindProperty(commandBody);
                        if (prop is not null)
                        {
                            string strEnumValuesInfo = string.Empty;
                            if (prop.PropertyType.IsEnum)
                            {
                                List<string> lstEnumName = new List<string>();
                                foreach (var item in Enum.GetValues(prop.PropertyType))
                                    lstEnumName.Add(item.ToString()!);
                                strEnumValuesInfo = $"\r\n该属性是一个枚举，允许的值有：\r\n{string.Join(";\r\n", lstEnumName)}";
                            }

                            PropertyChineseNameAttribute? attr = GetDescription(prop);
                            if (attr is not null)
                            {
                                return $"属性:<{prop.Name}>，\r\n别名:<{attr.ChineseName}>，\r\n隶属于分组:<{attr.NodeName}>，\r\n描述信息为:\"{attr.Description}\"\r\n{strEnumValuesInfo}";
                            }
                            return $"属性:<{prop.Name}> 不存在描述信息。\r\n{strEnumValuesInfo}";
                        }
                    }
                }
                else if (bRss)
                {
                    List<string> lstRss = new List<string>();
                    RssSubscriptionItem[] rssSubscription = BotInfo.Config.RssSubscription.ToArray();
                    for (int i = 0; i < rssSubscription.Length; i++)
                    {
                        lstRss.Add($"{{\r\n" +
                            $"    Url(订阅地址)=\"{rssSubscription[i].Url}\",\r\n" +
                            $"    Remark(别名)=\"{rssSubscription[i].Remark}\",\r\n" +
                            $"    ForwardGroups(转发到群)=\"{string.Join(';', rssSubscription[i].ForwardGroups is null ? new long[0] : rssSubscription[i].ForwardGroups!)}\",\r\n" +
                            $"    ForwardQQs(转发到好友)=\"{string.Join(';', rssSubscription[i].ForwardQQs is null ? new long[0] : rssSubscription[i].ForwardQQs!)}\",\r\n" +
                            $"    Translate(是否翻译)=\"{rssSubscription[i].Translate}\",\r\n" +
                            $"    TranslateFromTo(是否指定翻译语言)=\"{rssSubscription[i].TranslateFromTo}\",\r\n" +
                            $"    TranslateFrom(从什么语言翻译)=\"{rssSubscription[i].TranslateFromTo}\",\r\n" +
                            $"    TranslateTo(翻译为什么语言)=\"{rssSubscription[i].TranslateTo}\",\r\n" +
                            $"    AtAll(是否@所有人)=\"{rssSubscription[i].AtAll}\",\r\n" +
                            $"    SendByForward(是否以合并转发方式发送)=\"{rssSubscription[i].SendByForward}\",\r\n" +
                            $"    FilterMode(过滤模式 0=不过滤, 1=包含任一, 2=包含所有, 3=不包含)=\"{rssSubscription[i].FilterMode}\",\r\n" +
                            $"    FilterKeyWords(过滤关键词)=\"{string.Join(';', rssSubscription[i].FilterKeyWords is null ? new string[0] : rssSubscription[i].FilterKeyWords!)}\"," +
                            $"\r\n}}");
                    }
                    return $"当前存在以下RSS订阅项:\r\n{string.Join(",\r\n", lstRss)}";
                }
                else if (bAddRss)
                {
                    string commandBody = message.Substring("--addrss".Length).Trim();

                    Regex regexUrl = new Regex("Url=\"(?<Url>.*?)\"", RegexOptions.IgnoreCase);
                    Regex regexRemark = new Regex("Remark=\"(?<Remark>.*?)\"", RegexOptions.IgnoreCase);
                    Regex regexForwardGroups = new Regex("ForwardGroups=\"(?<ForwardGroups>.*?)\"", RegexOptions.IgnoreCase);
                    Regex regexForwardQQs = new Regex("ForwardQQs=\"(?<ForwardQQs>.*?)\"", RegexOptions.IgnoreCase);
                    Regex regexTranslate = new Regex("Translate=\"(?<Translate>true|false)\"", RegexOptions.IgnoreCase);
                    Regex regexTranslateFromTo = new Regex("TranslateFromTo=\"(?<TranslateFromTo>true|false)\"", RegexOptions.IgnoreCase);
                    Regex regexTranslateFrom = new Regex("TranslateFrom=\"(?<TranslateFrom>.*?)\"", RegexOptions.IgnoreCase);
                    Regex regexTranslateTo = new Regex("TranslateTo=\"(?<TranslateTo>.*?)\"", RegexOptions.IgnoreCase);
                    Regex regexAtAll = new Regex("AtAll=\"(?<AtAll>true|false)\"", RegexOptions.IgnoreCase);
                    Regex regexSendByForward = new Regex("SendByForward=\"(?<SendByForward>true|false)\"", RegexOptions.IgnoreCase);
                    Regex regexFilterMode = new Regex("FilterMode=\"(?<FilterMode>[0-9]{1})\"", RegexOptions.IgnoreCase);
                    Regex regexFilterKeyWords = new Regex("FilterKeyWords=\"(?<FilterKeyWords>.*?)\"", RegexOptions.IgnoreCase);

                    Match matchUrl = regexUrl.Match(commandBody);
                    if (matchUrl.Groups["Url"].Success)  //必须有Url
                    {
                        if (BotInfo.Config.RssSubscription.Where(r => r.Url == matchUrl.Groups["Url"].Value).Count() > 0)
                        {
                            return $"添加订阅失败, 已存在地址为:\r\n{matchUrl.Groups["Url"].Value}\r\n的订阅项";
                        }

                        RssSubscriptionItem rssItem = new RssSubscriptionItem() { Url = matchUrl.Groups["Url"].Value };

                        Match matchRemark = regexRemark.Match(commandBody);
                        if (matchRemark.Groups["Remark"].Success)
                            rssItem.Remark = matchRemark.Groups["Remark"].Value;

                        Match matchForwardGroups = regexForwardGroups.Match(commandBody);
                        if (matchForwardGroups.Groups["ForwardGroups"].Success)
                            rssItem.ForwardGroups = matchForwardGroups.Groups["ForwardGroups"].Value.Split().Select(s => Convert.ToInt64(s)).ToArray();

                        Match matchForwardQQs = regexForwardQQs.Match(commandBody);
                        if (matchForwardQQs.Groups["ForwardQQs"].Success)
                            rssItem.ForwardQQs = matchForwardQQs.Groups["ForwardQQs"].Value.Split().Select(s => Convert.ToInt64(s)).ToArray();

                        Match matchTranslate = regexTranslate.Match(commandBody);
                        if (matchTranslate.Groups["Translate"].Success)
                            rssItem.Translate = Convert.ToBoolean(matchTranslate.Groups["Translate"].Value);

                        Match matchTranslateFromTo = regexTranslateFromTo.Match(commandBody);
                        if (matchTranslateFromTo.Groups["TranslateFromTo"].Success)
                            rssItem.TranslateFromTo = Convert.ToBoolean(matchTranslateFromTo.Groups["TranslateFromTo"].Value);

                        Match matchTranslateFrom = regexTranslateFrom.Match(commandBody);
                        if (matchTranslateFrom.Groups["TranslateFrom"].Success)
                            rssItem.TranslateFrom = matchTranslateFrom.Groups["TranslateFrom"].Value;

                        Match matchTranslateTo = regexTranslateTo.Match(commandBody);
                        if (matchTranslateTo.Groups["TranslateTo"].Success)
                            rssItem.TranslateTo = matchTranslateTo.Groups["TranslateTo"].Value;

                        Match matchAtAll = regexAtAll.Match(commandBody);
                        if (matchAtAll.Groups["AtAll"].Success)
                            rssItem.AtAll = Convert.ToBoolean(matchAtAll.Groups["AtAll"].Value);

                        Match matchSendByForward = regexSendByForward.Match(commandBody);
                        if (matchSendByForward.Groups["SendByForward"].Success)
                            rssItem.SendByForward = Convert.ToBoolean(matchSendByForward.Groups["SendByForward"].Value);

                        Match matchFilterMode = regexFilterMode.Match(commandBody);
                        if (matchFilterMode.Groups["FilterMode"].Success)
                            rssItem.FilterMode = Convert.ToInt32(matchFilterMode.Groups["FilterMode"].Value);

                        Match matchFilterKeyWords = regexFilterKeyWords.Match(commandBody);
                        if (matchFilterKeyWords.Groups["FilterKeyWords"].Success)
                            rssItem.FilterKeyWords = matchFilterKeyWords.Groups["FilterKeyWords"].Value.Split(";");

                        var rssList = BotInfo.Config.RssSubscription;
                        rssList.Add(rssItem);
                        BotInfo.Config.RssSubscription = rssList;
                        BotInfo.SaveConfigFile();

                        return $"已成功订阅:<{rssItem.Remark}>";
                    }
                    else
                    {
                        return $"订阅添加失败, 没有订阅Url";
                    }
                }
                else if (bRemoveRss)
                {
                    string commandBody = message.Substring("--removerss".Length).Trim();
                    var rssList = BotInfo.Config.RssSubscription;
                    RssSubscriptionItem rssItem = rssList.FirstOrDefault(rss => rss.Remark == commandBody);
                    if (rssItem is null)
                        rssItem = rssList.FirstOrDefault(rss => rss.Url == commandBody);
                    if (rssItem is not null)
                    {
                        rssList.Remove(rssItem);
                        BotInfo.Config.RssSubscription = rssList;
                        BotInfo.SaveConfigFile();
                        return $"订阅项:<{rssItem.Remark}>已成功移除";
                    }
                    else
                    {
                        return $"订阅项:<{commandBody}>移除失败, 没有找到此订阅项";
                    }
                }
            }
            return null;
        }

        private static Type? GetEnumerableType(Type type)
        {
            if (type is null)
                return null;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments()[0];

            var iface = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)).FirstOrDefault();

            if (iface is null)
                return null;

            return GetEnumerableType(iface);
        }

        private static PropertyInfo? FindProperty(string propName)
        {
            Dictionary<string, PropertyInfo> interfaceProps = typeof(IBotConfig).GetProperties().ToDictionary(k => k.Name, v => v);
            PropertyInfo[] classProps = typeof(BotConfig).GetProperties();
            for (int i = 0; i < classProps.Length; i++)
            {
                if (classProps[i].Name == propName)
                {
                    return classProps[i];
                }
                PropertyChineseNameAttribute? chnNameAttr = interfaceProps[classProps[i].Name].GetCustomAttribute<PropertyChineseNameAttribute>();
                if (chnNameAttr is not null)
                {
                    if (chnNameAttr.ChineseName == propName)
                    {
                        return classProps[i];
                    }
                }
            }
            return null;
        }

        private static PropertyChineseNameAttribute? GetDescription(PropertyInfo prop)
        {
            PropertyChineseNameAttribute? chnNameAttr = prop.GetCustomAttribute<PropertyChineseNameAttribute>();
            if (chnNameAttr is not null)
                return chnNameAttr;
            return null;
        }

        private static Dictionary<PropertyInfo, PropertyChineseNameAttribute> FindPropertysByNodeName(string nodeName)
        {
            Dictionary<PropertyInfo, PropertyChineseNameAttribute> propertyInfos = new Dictionary<PropertyInfo, PropertyChineseNameAttribute>();
            PropertyInfo[] props = typeof(IBotConfig).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                PropertyChineseNameAttribute? chnNameAttr = props[i].GetCustomAttribute<PropertyChineseNameAttribute>();
                if (chnNameAttr is not null)
                {
                    if (string.IsNullOrWhiteSpace(nodeName) || chnNameAttr.NodeName == nodeName)
                        propertyInfos.Add(props[i], chnNameAttr);
                }
            }
            return propertyInfos;
        }
    }
}