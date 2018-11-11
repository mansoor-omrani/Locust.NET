using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ResponseType = Locust.Modules.Api.Model.ApiClient.Full;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByHashResponse : BaseServiceResponse<ResponseType, ApiClientGetByHashStatus>
    {
    }
}