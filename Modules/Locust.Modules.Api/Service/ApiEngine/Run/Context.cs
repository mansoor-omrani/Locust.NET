using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public class ApiEngineRunContext : BabbageContextWeb<ApiEngineRunResponse, object, ApiEngineRunStatus, ApiEngineRunRequest>
    {
    }
}