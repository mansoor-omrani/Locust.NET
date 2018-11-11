using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientCustomerActivateContext : BabbageContext<ApiClientCustomerActivateResponse, ApiClientCustomerActivateResponseData, ApiClientCustomerActivateStatus, ApiClientCustomerActivateRequest>
    {
        public int OverrideAppId { get; set; }
    }
}