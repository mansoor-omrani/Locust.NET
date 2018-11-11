using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubUpdateStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerHubUpdateResponse, object, ApiClientCustomerHubUpdateStatus, ApiClientCustomerHubUpdateRequest, ApiClientCustomerHubUpdateContext>
    {
		public ApiClientCustomerHubUpdateStrategyBase ()
		{
			Init();
		}

    }
}