using Locust.ServiceModel;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubGetByPKResponse : BaseServiceResponse<ApiClientCustomerHub.Full, ApiClientCustomerHubGetByPKStatus>
    {
    }
}