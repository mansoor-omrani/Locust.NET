using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubQuickUpdateStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerHubQuickUpdateResponse, object, ApiClientCustomerHubQuickUpdateStatus, ApiClientCustomerHubQuickUpdateRequest, ApiClientCustomerHubQuickUpdateContext>
    {

        public ApiClientCustomerHubQuickUpdateStrategyBase ()
		{
            Init();
		}

    }
}