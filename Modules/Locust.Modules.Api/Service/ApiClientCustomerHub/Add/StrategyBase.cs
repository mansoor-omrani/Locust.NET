using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubAddStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerHubAddResponse, int, ApiClientCustomerHubAddStatus, ApiClientCustomerHubAddRequest, ApiClientCustomerHubAddContext>
    {
		public ApiClientCustomerHubAddStrategyBase ()
		{
			Init();
		}

    }
}