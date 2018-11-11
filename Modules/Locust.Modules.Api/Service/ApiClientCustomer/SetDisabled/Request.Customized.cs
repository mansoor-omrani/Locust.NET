using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerSetDisabledRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public bool Disabled { get; set; }
        public GuidCommandParameter AccessToken { get; set; }
        public ApiClientCustomerSetDisabledRequest()
        {
            AccessToken = new GuidCommandParameter("");
        }
    }
}