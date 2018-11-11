using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public class ApiGetByPathContext : BabbageContext<ApiGetByPathResponse, API.Full, ApiGetByPathStatus, ApiGetByPathRequest>
    {
    }
}