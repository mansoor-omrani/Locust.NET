using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using ResponseType = Locust.Modules.Api.Model.ApiClient.Full;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetByHashStrategyBase : BabbageItemFetcherStrategy<ApiClientGetByHashResponse, ResponseType, ApiClientGetByHashStatus, ApiClientGetByHashRequest, ApiClientGetByHashContext>
    {
		protected void Init()
		{
		}
    }
}