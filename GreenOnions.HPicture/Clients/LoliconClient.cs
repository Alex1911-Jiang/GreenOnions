using System.Threading.Tasks;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GreenOnions.HPicture.Clients
{
    internal class LoliconClient : BaseLoliClient
    {
        protected override string ApiName => "Lolicon";
        protected override string ApiUrl => "https://api.lolicon.app/setu/v2";

        protected override async Task<JToken> RequestLoli(string strUrl)
        {
            string resultValue;
            if (EventHelper.GetDocumentByBrowserEvent is not null && BotInfo.Config.HttpRequestByWebBrowser && BotInfo.Config.HPictureLoliconRequestByWebBrowser)
            {
                string doc = EventHelper.GetDocumentByBrowserEvent!(strUrl).document;
                resultValue = doc[doc.IndexOf("{")..(doc.LastIndexOf("}") + 1)];
            }
            else
                resultValue = await HttpHelper.GetStringAsync(strUrl, BotInfo.Config.HPictureUseProxy);

            return JsonConvert.DeserializeObject<JObject>(resultValue);
        }
    }
}
