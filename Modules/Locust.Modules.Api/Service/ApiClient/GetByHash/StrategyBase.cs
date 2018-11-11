using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using ResponseType = Locust.Modules.Api.Model.ApiClient.Full;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetByHashStrategyBase : BabbageItemFetcherStrategy<ApiClientGetByHashResponse, ResponseType, ApiClientGetByHashStatus, ApiClientGetByHashRequest, ApiClientGetByHashContext>
    {
        protected ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
        public ApiClientGetByHashStrategyBase ()
		{
			Init();
		}

    }
}