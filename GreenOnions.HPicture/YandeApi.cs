using System.Threading.Tasks;
using Yande.re.Api;
using System.Linq;

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
    }

}
