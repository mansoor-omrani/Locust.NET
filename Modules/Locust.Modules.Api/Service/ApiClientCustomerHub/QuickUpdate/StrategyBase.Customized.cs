using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubQuickUpdateStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerHubQuickUpdateResponse, object, ApiClientCustomerHubQuickUpdateStatus, ApiClientCustomerHubQuickUpdateRequest, ApiClientCustomerHubQuickUpdateContext>
    {
        public ApiClientCustomerHubServiceBase Service
        {
            get { return Store.Service as ApiClientCustomerHubServiceBase; }
        }
        protected void Init()
		{
        }
    }
}