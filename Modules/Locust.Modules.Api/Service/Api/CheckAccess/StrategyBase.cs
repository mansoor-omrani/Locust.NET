using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiCheckAccessStrategyBase : BabbageDataManipulationStrategy<ApiCheckAccessResponse, object, ApiCheckAccessStatus, ApiCheckAccessRequest, ApiCheckAccessContext>
    {
		public ApiCheckAccessStrategyBase()
		{
			Init();
		}

    }
}