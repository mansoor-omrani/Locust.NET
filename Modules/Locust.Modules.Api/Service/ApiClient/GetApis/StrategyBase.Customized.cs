using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetApisStrategyBase : BabbageListFetcherStrategy<ApiClientGetApisResponse, ApiClientGetApisStatus, ApiClientGetApisRequest, ApiClientGetApisContext, ClientApi>
    {
		protected void Init()
		{
		}

    }
}