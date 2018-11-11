using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using ResponseType = Locust.Modules.Api.Model.ApiClient.GetPage;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetPageStrategyBase : BabbagePageFetcherStrategy<ApiClientGetPageResponse, ApiClientGetPageStatus, ApiClientGetPageRequest, ApiClientGetPageContext, ResponseType>
    {
		protected void Init()
		{
		}

    }
}