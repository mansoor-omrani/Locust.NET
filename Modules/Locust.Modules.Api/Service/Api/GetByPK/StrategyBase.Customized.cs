using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetByPKStrategyBase : BabbageItemFetcherStrategy<ApiGetByPKResponse, API.Full, ApiGetByPKStatus, ApiGetByPKRequest, ApiGetByPKContext>
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