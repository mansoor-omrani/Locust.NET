using System;
using Locust.Caching;
using Locust.Modules.Api.Service;
using Locust.ServiceModel.Babbage;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubGetByPKStrategyBase : BabbageItemFetcherStrategy<ApiClientCustomerHubGetByPKResponse, ApiClientCustomerHub.Full, ApiClientCustomerHubGetByPKStatus, ApiClientCustomerHubGetByPKRequest, ApiClientCustomerHubGetByPKContext>
	{
	    protected ApiClientServiceBase clientService;

        public ApiClientCustomerHubGetByPKStrategyBase (ApiClientServiceBase clientService)
        {
            this.clientService = clientService;
			Init();
		}

    }
}