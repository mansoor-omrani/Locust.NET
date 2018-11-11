using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientAddStrategyBase : BabbageDataManipulationStrategy<ApiClientAddResponse, int, ApiClientAddStatus, ApiClientAddRequest, ApiClientAddContext>
    {
		protected void Init()
		{
        }
    }
}