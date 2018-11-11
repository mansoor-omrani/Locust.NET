using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Service;
using ApiClient = Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetByKeyStrategyBase : BabbageItemFetcherStrategy<ApiClientGetByKeyResponse, ApiClient.Full, ApiClientGetByKeyStatus, ApiClientGetByKeyRequest, ApiClientGetByKeyContext>
    {
		protected void Init()
		{
        }
    }
}