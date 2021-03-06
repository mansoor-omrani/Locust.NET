using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubDeleteStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerHubDeleteResponse, object, ApiClientCustomerHubDeleteStatus, ApiClientCustomerHubDeleteRequest, ApiClientCustomerHubDeleteContext>
    {
		public ApiClientCustomerHubDeleteStrategyBase ()
		{
			Init();
		}

    }
}