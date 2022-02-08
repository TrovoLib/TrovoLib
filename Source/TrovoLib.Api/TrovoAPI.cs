using System.Threading.Tasks;
using TrovoLib.Api.Interfaces;
using TrovoLib.Core;

namespace TrovoLib.Api
{
    public class TrovoAPI : ITrovoAPI
    {
        public string ClientID { get; set; }

        public async Task GetGameCategories()
        {
            using var api = new ApiClient();

            //api.ApiRequest(TrovoConstants.ApiHost, "categorys/top", ClientID);

        }
    }
}
