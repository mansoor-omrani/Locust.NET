using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUnlockRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public GuidCommandParameter AccessToken { get; set; }

        public ApiClientCustomerUnlockRequest()
        {
            AccessToken = new GuidCommandParameter("");
        }
    }
}