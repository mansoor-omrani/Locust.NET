using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPUpdateStrategyBase : BabbageDataManipulationStrategy<ApiClientIPUpdateResponse, object, ApiClientIPUpdateStatus, ApiClientIPUpdateRequest, ApiClientIPUpdateContext>
    {
        public ApiClientIPServiceBase Service
        {
            get { return Store.Service as ApiClientIPServiceBase; }
        }
        protected void Init()
		{
        }
    }
}