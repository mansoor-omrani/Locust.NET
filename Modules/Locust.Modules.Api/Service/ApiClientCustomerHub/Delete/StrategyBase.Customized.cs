using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerHubDeleteStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerHubDeleteResponse, object, ApiClientCustomerHubDeleteStatus, ApiClientCustomerHubDeleteRequest, ApiClientCustomerHubDeleteContext>
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