using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientRemoveByKeyStrategyBase : BabbageDataManipulationStrategy<ApiClientRemoveByKeyResponse, object, ApiClientRemoveByKeyStatus, ApiClientRemoveByKeyRequest, ApiClientRemoveByKeyContext>
    {
		protected void Init()
		{
		}
    }
}