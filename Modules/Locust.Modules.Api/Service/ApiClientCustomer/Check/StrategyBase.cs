using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerCheckStrategyBase : BabbageItemFetcherStrategy<ApiClientCustomerCheckResponse, CustomerCheckResponseData, ApiClientCustomerCheckStatus, ApiClientCustomerCheckRequest, ApiClientCustomerCheckContext>
    {
        public ApiClientCustomerCheckStrategyBase ()
		{
			Init();
		}

    }
}