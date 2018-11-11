using System.Data;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientCustomerGetByTokenContext : BabbageContext<ApiClientCustomerGetByTokenResponse, ApiClientCustomer.Full, ApiClientCustomerGetByTokenStatus, ApiClientCustomerGetByTokenRequest>
    {
        public ApiClientCustomerGetByTokenContext()
        {
            AddOutput("IsChanged", SqlDbType.Bit);
        }
    }
}