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
        public static GreenOnionsMessages ReplaceGreenOnionsTags(this GreenOnionsMessages originalMessage, IDictionary<string, string> propertiesValue, params KeyValuePair<string, string>[] customTags)
        {
            for (int i = 0; i < originalMessage.Count; i++)
            {
                if (originalMessage[i] is GreenOnionsTextMessage textMessage)
                {
                    string replacedStr = textMessage.Text;

                    foreach (KeyValuePair<string, string> prop in propertiesValue)
                    {
                        string tag = $"<{prop.Key}>";
                        if (replacedStr.Contains(tag))
                            replacedStr.Replace(tag, prop.Value);
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
        public static string ReplaceGreenOnionsTags(this string originalMessage, IDictionary<string, string> propertiesValue, params KeyValuePair<string, string>[] customTags)
        {
            foreach (KeyValuePair<string, string> prop in propertiesValue)
            {
                string tag = $"<{prop.Key}>";
                if (originalMessage.Contains(tag))
                    originalMessage = originalMessage.Replace(tag, prop.Value);
            }

            if (customTags != null)
            {
                foreach (var tag in customTags)
                    originalMessage = originalMessage.Replace($"<{tag.Key}>", tag.Value);
            }
            return originalMessage;
        }
    }
}
