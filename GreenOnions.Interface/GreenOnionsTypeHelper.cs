using System.Security.Cryptography;
using System.Text;

namespace GreenOnions.Interface
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

        public static string ToBase64(this MemoryStream ms)
        {
            try
            {
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                string base64Img = Convert.ToBase64String(arr);
                ms.Dispose();
                return base64Img;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static MemoryStream Base64ToMemoryStream(this string base64)
        {
            try
            {
                return new MemoryStream(Convert.FromBase64String(base64));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string ComputeMD5(string str)
        {
            byte[] bt = Encoding.UTF8.GetBytes(str);
            var md5 = MD5.Create();
            var md5bt = md5.ComputeHash(bt);
            StringBuilder builder = new StringBuilder();
            foreach (var item in md5bt)
                builder.Append(item.ToString("X2"));
            return builder.ToString();
        }
    }
}
