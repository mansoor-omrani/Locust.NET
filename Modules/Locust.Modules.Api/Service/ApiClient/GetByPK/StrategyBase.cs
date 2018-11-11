using System;
using Locust.Caching;
using Locust.Modules.Api.Service;
using Locust.ServiceModel.Babbage;
using ApiClient = Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetByPKStrategyBase : BabbageItemFetcherStrategy<ApiClientGetByPKResponse, ApiClient.Full, ApiClientGetByPKStatus, ApiClientGetByPKRequest, ApiClientGetByPKContext>
    {
        protected ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
        public ApiClientGetByPKStrategyBase()
		{
			Init();
		}

    }
}