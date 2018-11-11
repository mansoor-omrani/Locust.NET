using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientDeleteByKeyStrategyBase : BabbageDataManipulationStrategy<ApiClientDeleteByKeyResponse, object, ApiClientDeleteByKeyStatus, ApiClientDeleteByKeyRequest, ApiClientDeleteByKeyContext>
    {
		protected void Init()
		{
		}
    }
}