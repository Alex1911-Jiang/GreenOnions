using System.Collections;

namespace GreenOnions.Interface
{
    /// <summary>
    /// 属性帮助类
    /// </summary>
    public static class PropertiesHelper
    {
        /// <summary>
        /// 替换消息中的标签为属性值
        /// </summary>
        /// <param name="originalMessage">原始消息</param>
        /// <param name="propertiesValue">属性集</param>
        /// <param name="customTags">自定义标签</param>
        /// <returns>替换标签后的消息</returns>
        public static GreenOnionsMessages ReplaceGreenOnionsTags(this GreenOnionsMessages originalMessage, IDictionary<string, object> propertiesValue, params KeyValuePair<string, string>[] customTags)
        {
            for (int i = 0; i < originalMessage.Count; i++)
            {
                if (originalMessage[i] is GreenOnionsTextMessage textMessage)
                {
                    string replacedStr = textMessage.Text;

                    foreach (KeyValuePair<string, object> prop in propertiesValue)
                    {
                        string tag = $"<{prop.Key}>";
                        if (replacedStr.Contains(tag))
                            replacedStr.Replace(tag, prop.Value.AnyToString());
                    }

                    if (customTags != null)
                    {
                        foreach (var tag in customTags)
                            replacedStr = replacedStr.Replace($"<{tag.Key}>", tag.Value);
                    }
                    originalMessage[i] = replacedStr;
                }
            }
            return originalMessage;
        }

        /// <summary>
        /// 替换消息中的标签为属性值
        /// </summary>
        /// <param name="originalMessage">原始消息</param>
        /// <param name="propertiesValue">属性集</param>
        /// <param name="customTags">自定义标签</param>
        /// <returns>替换标签后的消息</returns>
        public static string ReplaceGreenOnionsTags(this string originalMessage, IDictionary<string, object> propertiesValue, params KeyValuePair<string, string>[] customTags)
        {
            foreach (KeyValuePair<string, object> prop in propertiesValue)
            {
                string tag = $"<{prop.Key}>";
                if (originalMessage.Contains(tag))
                    originalMessage = originalMessage.Replace(tag, prop.Value.AnyToString());
            }

            if (customTags != null)
            {
                foreach (var tag in customTags)
                    originalMessage = originalMessage.Replace($"<{tag.Key}>", tag.Value);
            }
            return originalMessage;
        }

        /// <summary>
        /// 任意类型转字符串
        /// </summary>
        /// <param name="objValue">object</param>
        /// <returns>string</returns>
        public static string AnyToString(this object objValue)
        {
            string strValue;
            if (!(objValue is string) && objValue is IEnumerable enu)
            {
                List<string> elements = new List<string>();
                foreach (var item in enu)
                    elements.Add(item.ToString()!);
                strValue = string.Join(";\r\n", elements);
            }
            else if (objValue.GetType().IsEnum)
                strValue = objValue.ToString()!;
            else
                strValue = objValue.ToString()!;
            return strValue;
        }
    }
}
