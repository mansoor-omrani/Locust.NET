using Locust.Caching;
using Locust.Modules.Api.Service;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetByPathStrategyBase : BabbageItemFetcherStrategy<ApiGetByPathResponse, API.Full, ApiGetByPathStatus, ApiGetByPathRequest, ApiGetByPathContext>
    {
        public ApiServiceBase Service
        {
            get { return Store.Service as ApiServiceBase; }
        }
        protected void Init()
		{
		}
    }
}