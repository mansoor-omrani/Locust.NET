using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPAddStrategyBase : BabbageDataManipulationStrategy<ApiClientIPAddResponse, object, ApiClientIPAddStatus, ApiClientIPAddRequest, ApiClientIPAddContext>
    {
		public ApiClientIPAddStrategyBase ()
		{
			Init();
		}

    }
}