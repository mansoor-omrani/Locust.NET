using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientCustomerGetByPKContext : BabbageContext<ApiClientCustomerGetByPKResponse, ApiClientCustomer.Full, ApiClientCustomerGetByPKStatus, ApiClientCustomerGetByPKRequest>
    {
    }
}