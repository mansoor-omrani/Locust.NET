using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
    public class ApiClientCustomerEnrolResponseData
    {
        public int ApiClientCustomerId { get; set; }
        public string ActivationCode { get; set; }
    }

    public partial class ApiClientCustomerEnrolResponse : BaseServiceResponse<ApiClientCustomerEnrolResponseData, ApiClientCustomerEnrolStatus>
    {
        public int ApiClientCustomerId { get; set; }
        public string ActivationCode { get; set; }
    }
}