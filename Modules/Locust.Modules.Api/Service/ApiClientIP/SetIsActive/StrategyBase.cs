using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPSetIsActiveStrategyBase : BabbageDataManipulationStrategy<ApiClientIPSetIsActiveResponse, object, ApiClientIPSetIsActiveStatus, ApiClientIPSetIsActiveRequest, ApiClientIPSetIsActiveContext>
    {
		public ApiClientIPSetIsActiveStrategyBase ()
		{
			Init();
		}

    }
}