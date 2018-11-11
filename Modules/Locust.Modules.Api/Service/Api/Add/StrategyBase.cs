using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiAddStrategyBase : BabbageDataManipulationStrategy<ApiAddResponse, int, ApiAddStatus, ApiAddRequest, ApiAddContext>
    {
		public ApiAddStrategyBase()
		{
			Init();
		}

    }
}