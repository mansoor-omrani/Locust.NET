using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerSetActivatedStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerSetActivatedResponse, object, ApiClientCustomerSetActivatedStatus, ApiClientCustomerSetActivatedRequest, ApiClientCustomerSetActivatedContext>
    {
        public ApiClientCustomerServiceBase Service
        {
            get { return Store.Service as ApiClientCustomerServiceBase; }
        }
        protected void Init()
		{
        }
    }
}