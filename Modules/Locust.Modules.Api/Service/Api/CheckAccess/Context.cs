using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public class ApiCheckAccessContext : BabbageContext<ApiCheckAccessResponse, object, ApiCheckAccessStatus, ApiCheckAccessRequest>
    {
    }
}