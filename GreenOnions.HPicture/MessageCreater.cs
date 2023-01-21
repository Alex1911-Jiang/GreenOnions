using System.IO;
using System.Text;
using System.Threading.Tasks;
using GreenOnions.HPicture.Items;
using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Yande.re.Api;

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
            GreenOnionsImageMessage imgMsg = await ImageHelper.CreateImageMessageByUrlAsync(item.URL);
            outMessage.Add(imgMsg);
            return outMessage;
        }

        internal static async Task<GreenOnionsMessages> CreateMessageByYandeItemAsync(YandeItem item)
        {
            GreenOnionsMessages outMessage = new();
            StringBuilder sb = new();
            if (BotInfo.Config.HPictureSendUrl)
                sb.AppendLine($"http://yande.re{item.ShowPageUrl}");
            if (BotInfo.Config.HPictureSendTags)
                sb.AppendLine($"标签:{string.Join(", ", item.Tags)}");
            outMessage.Add(sb);

            GreenOnionsImageMessage imgMsg = await ImageHelper.CreateImageMessageByUrlAsync(item.BigImgUrl);
            outMessage.Add(imgMsg);

            return outMessage;
        }
    }
}
