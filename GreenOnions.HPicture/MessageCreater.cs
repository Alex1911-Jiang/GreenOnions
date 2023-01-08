using System.IO;
using System.Text;
using System.Threading.Tasks;
using GreenOnions.HPicture.Items;
using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.HPicture
{
    internal static class MessageCreater
    {
        /// <summary>
        /// 根据Lolicon对象创建消息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        internal static async Task<GreenOnionsMessages> CreateMessageByLoliconItemAsync(LoliconHPictureItem item)
        {
            GreenOnionsMessages outMessage = new GreenOnionsMessages();
            StringBuilder sb = new StringBuilder();
            if (BotInfo.Config.HPictureSendUrl)
                sb.AppendLine($"作品页：https://www.pixiv.net/artworks/{item.ID} (p{item.P})");
            if (BotInfo.Config.HPictureSendProxyUrl)
                sb.AppendLine($"图片代理地址：{item.URL}");
            if (BotInfo.Config.HPictureSendTitle)
                sb.AppendLine($"标题:{item.Title}\r\n作者:{item.Author}");
            if (BotInfo.Config.HPictureSendTags)
                sb.AppendLine($"标签:{item.Tags}");
            outMessage.Add(sb);

            string extension = Path.GetExtension(item.URL);
            string size = BotInfo.Config.HPictureSize1200 ? "_1200" : "";
            string imgCacheName = Path.Combine(ImageHelper.ImagePath, $"{item.ID}_{item.P}{size}{extension}");
            GreenOnionsImageMessage imgMsg = await CreateImageMessageByUrlAsync(item.URL, imgCacheName);

            outMessage.Add(imgMsg);
            return outMessage;
        }

        /// <summary>
        /// 根据图片URL创建一个图片消息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        private static async Task<GreenOnionsImageMessage> CreateImageMessageByUrlAsync(string url, string cacheName)
        {
            GreenOnionsImageMessage imageMsg = null;
            if (File.Exists(cacheName) && new FileInfo(cacheName).Length > 0) //存在本地缓存时优先使用缓存
            {
                imageMsg = new GreenOnionsImageMessage(cacheName);
            }
            else
            {
                if (BotInfo.Config.SendImageByFile)  //下载完成后发送文件
                {
                    await HttpHelper.DownloadImageFileAsync(url, cacheName);
                    if (File.Exists(cacheName))
                        imageMsg = new GreenOnionsImageMessage(cacheName);
                }
                else  //直接发送地址
                {
                    imageMsg = new GreenOnionsImageMessage(url);
                    if (BotInfo.Config.DownloadImage4Caching)
                        _ = HttpHelper.DownloadImageFileAsync(url, cacheName);  //下载图片用于缓存
                }
            }
            return imageMsg;
        }
    }
}
