using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubGetPageStrategyBase : BabbagePageFetcherStrategy<ApiClientCustomerHubGetPageResponse, ApiClientCustomerHubGetPageStatus, ApiClientCustomerHubGetPageRequest, ApiClientCustomerHubGetPageContext, ApiClientCustomerHub.AdminGrid>
    {
		public ApiClientCustomerHubGetPageStrategyBase ()
		{
			Init();
		}

    }
}