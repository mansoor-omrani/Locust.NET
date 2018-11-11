using Locust.ServiceModel;
using ApiClient = Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByKeyResponse : BaseServiceResponse<ApiClient.Full, ApiClientGetByKeyStatus>
    {
    }
}