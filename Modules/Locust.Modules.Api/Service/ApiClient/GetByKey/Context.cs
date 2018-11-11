using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ApiClient = Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientGetByKeyContext : BabbageContext<ApiClientGetByKeyResponse, ApiClient.Full, ApiClientGetByKeyStatus, ApiClientGetByKeyRequest>
    {
    }
}