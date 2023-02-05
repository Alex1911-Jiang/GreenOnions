using System.Threading.Tasks;
using GreenOnions.Interface.DispatchCenter;
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
            if (BotInfo.Config.HPictureLoliconRequestByPlugin && HttpClientSubstitutes.GetStringAsync is not null)
            {
                return JsonConvert.DeserializeObject<JToken>(await HttpClientSubstitutes.GetStringAsync(strUrl, null));
            }
            else  if (EventHelper.GetDocumentByBrowserEvent is not null && BotInfo.Config.HttpRequestByWebBrowser && BotInfo.Config.HPictureLoliconRequestByWebBrowser)
            {
                string doc = EventHelper.GetDocumentByBrowserEvent!(strUrl).document;
                return JsonConvert.DeserializeObject<JObject>(doc[doc.IndexOf("{")..(doc.LastIndexOf("}") + 1)]);
            }
            else
                return await base.RequestLoli(strUrl);
        }
    }
}
