using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientDeleteByPKStrategyBase : BabbageDataManipulationStrategy<ApiClientDeleteByPKResponse, object, ApiClientDeleteByPKStatus, ApiClientDeleteByPKRequest, ApiClientDeleteByPKContext>
    {
		protected void Init()
		{
		}
    }
}