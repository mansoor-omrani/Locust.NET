using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUpdateRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public GuidCommandParameter AccessToken { get; set; }
        public GuidCommandParameter RefreshToken { get; set; }
        public int LifeLength { get; set; }
        public bool Activated { get; set; }
        public bool Disabled { get; set; }
        public string EncryptionCode { get; set; }
        public string CustomerType { get; set; }
        public GuidCommandParameter OiriginalAccessToken { get; set; }
        public ApiClientCustomerUpdateRequest()
        {
            AccessToken = new GuidCommandParameter("");
            OiriginalAccessToken = new GuidCommandParameter("");
            RefreshToken = new GuidCommandParameter("");
        }
    }
}