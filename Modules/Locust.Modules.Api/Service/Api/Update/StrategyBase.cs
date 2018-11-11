using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiUpdateStrategyBase : BabbageDataManipulationStrategy<ApiUpdateResponse, object, ApiUpdateStatus, ApiUpdateRequest, ApiUpdateContext>
    {
		public ApiUpdateStrategyBase ()
		{
			Init();
		}

    }
}