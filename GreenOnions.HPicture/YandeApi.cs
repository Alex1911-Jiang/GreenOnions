using System;
using System.Threading.Tasks;
using GreenOnions.Utility;
using Yande.re.Api;

namespace GreenOnions.HPicture
{
    public static class YandeApi
    {
        private static YandeClient _api = null;
        private static string _lastTag = string.Empty;
        public static async Task<YandeItem> GetRandomHPictrue(string tag, bool r18)
        {
            if (tag != _lastTag)
            {
                _lastTag = tag;
                _api = await YandeClient.CreateNew(false, true, tag);
            }
            return await _api.GetRandom(r18 ? Rating.Explicit : Rating.Safe);
        }

        public static async Task<YandeItem> GetOnceYandeItem()
        {
            YandeItem item = await GetRandomHPictrue(string.Empty, false);
            if (item is null)
                throw new Exception(BotInfo.Config.HPictureNoResultReply);  //没有结果
            return item;
        }
    }
}
