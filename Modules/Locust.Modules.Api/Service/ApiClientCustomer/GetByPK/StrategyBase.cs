using System;
using Locust.Caching;
using Locust.Modules.Api.Service;
using Locust.ServiceModel;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerGetByPKStrategyBase : BabbageItemFetcherStrategy<ApiClientCustomerGetByPKResponse, ApiClientCustomer.Full, ApiClientCustomerGetByPKStatus, ApiClientCustomerGetByPKRequest, ApiClientCustomerGetByPKContext>
	{
	    protected ApiClientCustomerHubServiceBase hubService;
        public ApiClientCustomerGetByPKStrategyBase (ApiClientCustomerHubServiceBase hubService)
        {
            this.hubService = hubService;
			Init();
		}

    }
}