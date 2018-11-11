using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerRegisterStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerRegisterResponse, object, ApiClientCustomerRegisterStatus, ApiClientCustomerRegisterRequest, ApiClientCustomerRegisterContext>
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