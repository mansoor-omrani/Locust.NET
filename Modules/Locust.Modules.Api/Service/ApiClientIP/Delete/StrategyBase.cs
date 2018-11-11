using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPDeleteStrategyBase : BabbageDataManipulationStrategy<ApiClientIPDeleteResponse, object, ApiClientIPDeleteStatus, ApiClientIPDeleteRequest, ApiClientIPDeleteContext>
    {
		public ApiClientIPDeleteStrategyBase ()
		{
			Init();
		}

    }
}