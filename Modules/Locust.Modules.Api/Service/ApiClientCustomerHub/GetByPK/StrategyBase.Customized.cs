using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Service;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubGetByPKStrategyBase : BabbageItemFetcherStrategy<ApiClientCustomerHubGetByPKResponse, ApiClientCustomerHub.Full, ApiClientCustomerHubGetByPKStatus, ApiClientCustomerHubGetByPKRequest, ApiClientCustomerHubGetByPKContext>
    {
        public ApiClientCustomerHubServiceBase Service
        {
            get { return Store.Service as ApiClientCustomerHubServiceBase; }
        }
        protected void Init()
		{
        }

    }
}