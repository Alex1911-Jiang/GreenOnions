using System.Security.Cryptography;
using System.Text;

namespace GreenOnions.Interface
{
    public static class GreenOnionsTypeHelper
    {
        /// <summary>
        /// 把字符串转换为文字消息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static GreenOnionsTextMessage ToTextMessage(this string str)
        {
            return new GreenOnionsTextMessage(str);
        }

        /// <summary>
        /// 把StringBuilder转换为文字消息
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        public static GreenOnionsTextMessage ToTextMessage(this StringBuilder stringBuilder)
        {
            return new GreenOnionsTextMessage(stringBuilder.ToString());
        }

        /// <summary>
        /// 把一组字符串转换为一组文字消息
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static GreenOnionsTextMessage[] ToTextMessageArray(this IEnumerable<string> strs)
        {
            return strs.Select(s => new GreenOnionsTextMessage(s)).ToArray();
        }

        /// <summary>
        /// 把内存流转换为Base64字符串(图片)
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 把Base64字符串转换为内存流(图片)
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 计算文字的MD5, 作为图片缓存的名称
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
