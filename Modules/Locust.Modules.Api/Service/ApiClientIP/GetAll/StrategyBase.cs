using System;
using Locust.Caching;
using Locust.Modules.Api.Service;
using Locust.ServiceModel.Babbage;
using ApiClientIP = Locust.Modules.Api.Model.ApiClientIP;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPGetAllStrategyBase : BabbageListFetcherStrategy<ApiClientIPGetAllResponse, ApiClientIPGetAllStatus, ApiClientIPGetAllRequest, ApiClientIPGetAllContext, ApiClientIP.AdminGrid>
	{
	    protected ApiClientServiceBase clientService;

        public ApiClientIPGetAllStrategyBase (ApiClientServiceBase clientService)
        {
            this.clientService = clientService;
			Init();
		}

    }
}