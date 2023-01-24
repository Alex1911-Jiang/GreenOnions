using System;
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
        internal static GreenOnionsTextMessage CreateTextMessageByItem(object item)
        {
            if (item is LoliHPictureItem loliConItem)
                return CreateTextMessageByLoliconItem(loliConItem);
            else if (item is PictureItem webItem)
                return CreateTextMessageByWebItem(webItem);
            throw new Exception("图库设置有误或指定图库已失效，请联系机器人管理员");
        }

        internal static async Task<GreenOnionsImageMessage> CreateImageMessageByItemAsync(object item)
        {
            if (item is LoliHPictureItem loliItem)
                return await CreateImageMessageByLoliItemAsync(loliItem);
            else if (item is PictureItem yandeItem)
                return await CreateImageMessageByWebItemAsync(yandeItem);
            throw new Exception("图库设置有误或指定图库已失效，请联系机器人管理员");
        }

        /// <summary>
        /// 根据Lolicon对象创建消息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        internal static GreenOnionsTextMessage CreateTextMessageByLoliconItem(LoliHPictureItem item)
        {
            StringBuilder sb = new StringBuilder();
            if (BotInfo.Config.HPictureSendUrl)
                sb.AppendLine($"作品页：https://www.pixiv.net/artworks/{item.ID} (p{item.P})");
            if (BotInfo.Config.HPictureSendProxyUrl)
                sb.AppendLine($"图片代理地址：{item.URL}");
            if (BotInfo.Config.HPictureSendTitle)
                sb.AppendLine($"标题:{item.Title}\r\n作者:{item.Author}");
            if (BotInfo.Config.HPictureSendTags)
                sb.AppendLine($"标签:{item.Tags}");
            return new GreenOnionsTextMessage(sb);
        }

        internal static async Task<GreenOnionsImageMessage> CreateImageMessageByLoliItemAsync(LoliHPictureItem item)
        {
            return await ImageHelper.CreateImageMessageByUrlAsync(item.URL, BotInfo.Config.HPictureUseProxy);
        }

        internal static GreenOnionsTextMessage CreateTextMessageByWebItem(PictureItem item)
        {
            StringBuilder sb = new();
            if (BotInfo.Config.HPictureSendUrl)
                sb.AppendLine($"https://{item.Host}/{item.ShowPageUrl}");
            if (BotInfo.Config.HPictureSendTags && item.Tags is not null)
                sb.AppendLine($"标签:{string.Join(", ", item.Tags)}");
            return new GreenOnionsTextMessage(sb);
        }

        internal static async Task<GreenOnionsImageMessage> CreateImageMessageByWebItemAsync(PictureItem item)
        {
           return await ImageHelper.CreateImageMessageByUrlAsync(item.BigImgUrl, BotInfo.Config.HPictureUseProxy);
        }
    }
}
