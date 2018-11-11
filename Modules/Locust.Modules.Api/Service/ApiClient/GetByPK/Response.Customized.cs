using Locust.ServiceModel;
using ApiClient = Locust.Modules.Api.Model.ApiClient;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByPKResponse : BaseServiceResponse<ApiClient.Full, ApiClientGetByPKStatus>
    {
    }
}