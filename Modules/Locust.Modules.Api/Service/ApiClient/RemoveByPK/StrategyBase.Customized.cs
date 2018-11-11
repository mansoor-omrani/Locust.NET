using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientRemoveByPKStrategyBase : BabbageDataManipulationStrategy<ApiClientRemoveByPKResponse, object, ApiClientRemoveByPKStatus, ApiClientRemoveByPKRequest, ApiClientRemoveByPKContext>
    {
		protected void Init()
		{
		}
    }
}