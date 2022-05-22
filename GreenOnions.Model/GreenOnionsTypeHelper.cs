using System.Text;

namespace GreenOnions.Model
{
    public static class GreenOnionsTypeHelper
    {
        public static GreenOnionsTextMessage ToTextMessage(this string str)
        {
            return new GreenOnionsTextMessage(str);
        }
        public static GreenOnionsTextMessage ToTextMessage(this StringBuilder stringBuilder)
        {
            return new GreenOnionsTextMessage(stringBuilder.ToString());
        }
        public static GreenOnionsTextMessage[] ToTextMessageArray(this IEnumerable<string> strs)
        {
            return strs.Select(s => new GreenOnionsTextMessage(s)).ToArray();
        }
    }
}
