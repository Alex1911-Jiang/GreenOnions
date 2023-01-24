using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenOnions.Utility;
using Yande.re.Api;

namespace GreenOnions.HPicture.Clients
{
    public static class LolibooruApi
    {
        private static BaseClient? _api = null;
        private static string _lastTag = string.Empty;
        public static async Task<PictureItem?> GetRandomHPictrue(string tag, bool r18)
        {
            await CreateNewApiIfTagChange(tag);
            return await _api!.GetRandom(r18 ? Rating.Explicit : Rating.Safe);
        }

        public static async Task<PictureItem> GetOnceItem()
        {
            PictureItem? item = await GetRandomHPictrue(string.Empty, false);
            if (item is null)
                throw new Exception(BotInfo.Config.HPictureNoResultReply);  //没有结果
            return item;
        }

        public static async IAsyncEnumerable<PictureItem> GetItems(string tag, bool r18)
        {
            await CreateNewApiIfTagChange(tag);
            foreach (var item in _api!.PictureList)
            {
                if (item.Rating == (r18 ? Rating.Explicit : Rating.Safe))
                    yield return item;
            }
        }

        private static async Task CreateNewApiIfTagChange(string tag)
        {
            if (_api is null || tag != _lastTag)
            {
                _lastTag = tag;
                _api = await Lolibooru.CreateNew(true, true, tag, BotInfo.Config.HPictureUseProxy ? BotInfo.Config.ProxyUrl : null);
            }
        }
    }
}
