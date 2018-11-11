using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Model.ApiClient;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetApisStrategyBase : BabbageListFetcherStrategy<ApiClientGetApisResponse, ApiClientGetApisStatus, ApiClientGetApisRequest, ApiClientGetApisContext, ClientApi>
    {
        protected ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }

        public ApiClientGetApisStrategyBase ()
		{
			
			Init();
		}

    }
}