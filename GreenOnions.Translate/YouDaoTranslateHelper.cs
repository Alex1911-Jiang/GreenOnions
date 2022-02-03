using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace GreenOnions.Translate
{
    public static class YouDaoTranslateHelper
    {
        public static async Task<string> TranslateToChinese(string text)
        {
            string url = "http://fanyi.youdao.com/translate?&doctype=json&type=AUTO&i=" + text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html, application/xhtml+xml, */*";
            HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
            Stream rs = response.GetResponseStream();
            StreamReader sr = new StreamReader(rs, Encoding.UTF8);
            string translatedText = await sr.ReadToEndAsync();
            sr.Close();
            rs.Close();
            JToken json = JsonConvert.DeserializeObject<JToken>(translatedText);
            JArray jResult = json["translateResult"] as JArray;
            List<string> resultList = new List<string>();
            foreach (JArray innerArray in jResult)
                resultList.AddRange(innerArray.Select(j => j["tgt"].ToString()));
            return string.Join("\r\n", resultList).ToString();
        }
    }
}
