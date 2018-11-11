using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using ApiClient = Locust.Modules.Api.Model.ApiClient.AdminGrid;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetAllStrategyBase : BabbageListFetcherStrategy<ApiClientGetAllResponse, ApiClientGetAllStatus, ApiClientGetAllRequest, ApiClientGetAllContext, ApiClient>
    {
		protected void Init()
		{
		}

    }
}