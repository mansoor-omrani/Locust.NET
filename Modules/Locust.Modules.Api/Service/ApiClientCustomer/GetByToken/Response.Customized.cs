using Locust.ServiceModel;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByTokenResponse : BaseServiceResponse<ApiClientCustomer.Full, ApiClientCustomerGetByTokenStatus>
    {
    }
}