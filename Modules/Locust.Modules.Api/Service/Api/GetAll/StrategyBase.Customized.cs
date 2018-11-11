using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetAllStrategyBase : BabbageListFetcherStrategy<ApiGetAllResponse, ApiGetAllStatus, ApiGetAllRequest, ApiGetAllContext, API.AdminGrid>
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