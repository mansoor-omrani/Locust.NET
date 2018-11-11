using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientIPUpdateContext : BabbageContext<ApiClientIPUpdateResponse, object, ApiClientIPUpdateStatus, ApiClientIPUpdateRequest>
    {
    }
}