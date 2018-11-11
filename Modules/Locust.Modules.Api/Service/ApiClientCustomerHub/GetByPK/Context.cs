using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientCustomerHubGetByPKContext : BabbageContext<ApiClientCustomerHubGetByPKResponse, ApiClientCustomerHub.Full, ApiClientCustomerHubGetByPKStatus, ApiClientCustomerHubGetByPKRequest>
    {
    }
}