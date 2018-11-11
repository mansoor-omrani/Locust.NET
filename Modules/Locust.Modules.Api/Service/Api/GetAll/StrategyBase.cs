using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetAllStrategyBase : BabbageListFetcherStrategy<ApiGetAllResponse, ApiGetAllStatus, ApiGetAllRequest, ApiGetAllContext, API.AdminGrid>
    {
		public ApiGetAllStrategyBase ()
		{
			Init();
		}

    }
}