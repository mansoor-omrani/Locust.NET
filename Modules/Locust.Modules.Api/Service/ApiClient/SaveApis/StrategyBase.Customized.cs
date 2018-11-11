using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientSaveApisStrategyBase : BabbageDataManipulationStrategy<ApiClientSaveApisResponse, object, ApiClientSaveApisStatus, ApiClientSaveApisRequest, ApiClientSaveApisContext>
    {
		protected void Init()
		{
		}
    }
}