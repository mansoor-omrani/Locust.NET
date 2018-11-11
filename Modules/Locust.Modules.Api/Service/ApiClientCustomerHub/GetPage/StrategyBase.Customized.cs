using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubGetPageStrategyBase : BabbagePageFetcherStrategy<ApiClientCustomerHubGetPageResponse, ApiClientCustomerHubGetPageStatus, ApiClientCustomerHubGetPageRequest, ApiClientCustomerHubGetPageContext, ApiClientCustomerHub.AdminGrid>
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