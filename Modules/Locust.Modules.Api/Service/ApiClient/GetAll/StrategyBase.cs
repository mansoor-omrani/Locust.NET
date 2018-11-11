using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using ApiClient = Locust.Modules.Api.Model.ApiClient.AdminGrid;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetAllStrategyBase : BabbageListFetcherStrategy<ApiClientGetAllResponse, ApiClientGetAllStatus, ApiClientGetAllRequest, ApiClientGetAllContext, ApiClient>
    {
        protected ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }


        public ApiClientGetAllStrategyBase ()
		{
			Init();
		}

    }
}