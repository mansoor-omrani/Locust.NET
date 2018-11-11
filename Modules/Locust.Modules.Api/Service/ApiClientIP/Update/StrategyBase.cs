using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPUpdateStrategyBase : BabbageDataManipulationStrategy<ApiClientIPUpdateResponse, object, ApiClientIPUpdateStatus, ApiClientIPUpdateRequest, ApiClientIPUpdateContext>
    {
		public ApiClientIPUpdateStrategyBase ()
		{
			Init();
		}

    }
}