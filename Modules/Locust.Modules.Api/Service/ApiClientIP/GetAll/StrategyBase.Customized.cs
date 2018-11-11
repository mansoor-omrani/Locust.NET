using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Service;
using ApiClientIP = Locust.Modules.Api.Model.ApiClientIP;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPGetAllStrategyBase : BabbageListFetcherStrategy<ApiClientIPGetAllResponse, ApiClientIPGetAllStatus, ApiClientIPGetAllRequest, ApiClientIPGetAllContext, ApiClientIP.AdminGrid>
    {
        public ApiClientIPServiceBase Service
        {
            get { return Store.Service as ApiClientIPServiceBase; }
        }
        protected void Init()
		{
        }

    }
}