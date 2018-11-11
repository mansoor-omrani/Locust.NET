using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerAddStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerAddResponse, int, ApiClientCustomerAddStatus, ApiClientCustomerAddRequest, ApiClientCustomerAddContext>
    {

        public ApiClientCustomerAddStrategyBase ()
		{
			Init();
		}

    }
}