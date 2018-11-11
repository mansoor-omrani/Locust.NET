using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
    public class CustomerRefreshResponseData
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string EncryptionCode { get; set; }
    }
    public partial class ApiClientCustomerRefreshResponse : BaseServiceResponse<CustomerRefreshResponseData, ApiClientCustomerRefreshStatus>
    {
        public string NewAccessToken { get; set; }
        public string NewRefreshToken { get; set; }
        public string NewEncryptionCode { get; set; }
    }
}