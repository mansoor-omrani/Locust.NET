using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Api.Model.ApiClient.Full;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientGetByHashContext : BabbageContext<ApiClientGetByHashResponse, ResponseType, ApiClientGetByHashStatus, ApiClientGetByHashRequest>
    {
    }
}