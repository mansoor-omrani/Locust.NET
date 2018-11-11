using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
    public class ApiClientCustomerActivateResponseData
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string EncryptionCode { get; set; }
        public int LifeLength { get; set; }
    }
    public partial class ApiClientCustomerActivateResponse : BaseServiceResponse<ApiClientCustomerActivateResponseData, ApiClientCustomerActivateStatus>
    {
        public int ApiClientCustomerId { get; set; }
        public string OldAccessToken { get; set; }
        public string OldEncryptionCode { get; set; }
    }
}