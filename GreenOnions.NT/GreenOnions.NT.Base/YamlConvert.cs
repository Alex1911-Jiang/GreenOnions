using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GreenOnions.NT.Base
{
    public static class YamlConvert
    {
        public static string SerializeObject<T>(T value)
        {
            var serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            return serializer.Serialize(value);
        }

        public static T? DeserializeObject<T>(string yaml) where T : class
        {
            try
            {
                var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).IgnoreUnmatchedProperties().Build();
                return deserializer.Deserialize<T>(yaml);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, "反序列化配置文件失败");
                return null;
            }
        }
    }
}
