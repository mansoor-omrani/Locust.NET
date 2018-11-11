using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientUpdateStrategyBase : BabbageDataManipulationStrategy<ApiClientUpdateResponse, object, ApiClientUpdateStatus, ApiClientUpdateRequest, ApiClientUpdateContext>
    {
        protected ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
        public ApiClientUpdateStrategyBase ()
		{
			Init();
		}

    }
}