using Locust.ServiceModel;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByPKResponse : BaseServiceResponse<ApiClientCustomer.Full, ApiClientCustomerGetByPKStatus>
    {
    }
}