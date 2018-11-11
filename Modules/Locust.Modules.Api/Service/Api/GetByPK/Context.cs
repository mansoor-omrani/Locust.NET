using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public class ApiGetByPKContext : BabbageContext<ApiGetByPKResponse, API.Full, ApiGetByPKStatus, ApiGetByPKRequest>
    {
    }
}