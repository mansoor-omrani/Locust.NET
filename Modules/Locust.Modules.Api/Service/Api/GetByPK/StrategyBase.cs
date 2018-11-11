using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetByPKStrategyBase : BabbageItemFetcherStrategy<ApiGetByPKResponse, API.Full, ApiGetByPKStatus, ApiGetByPKRequest, ApiGetByPKContext>
    {
		public ApiGetByPKStrategyBase()
		{
			Init();
		}

    }
}