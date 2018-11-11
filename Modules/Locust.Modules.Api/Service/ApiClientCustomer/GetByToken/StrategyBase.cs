using System;
using Locust.Caching;
using Locust.Modules.Api.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerGetByTokenStrategyBase : BabbageItemFetcherStrategy<ApiClientCustomerGetByTokenResponse, ApiClientCustomer.Full, ApiClientCustomerGetByTokenStatus, ApiClientCustomerGetByTokenRequest, ApiClientCustomerGetByTokenContext>
    {
        protected ApiClientCustomerHubServiceBase hubService;
        public ApiClientCustomerGetByTokenStrategyBase (ApiClientCustomerHubServiceBase hubService)
		{
            this.hubService = hubService;
			Init();
        }

    }
}