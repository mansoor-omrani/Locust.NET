using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerSetActivatedRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public bool Activated { get; set; }
        public GuidCommandParameter AccessToken { get; set; }

        public ApiClientCustomerSetActivatedRequest()
        {
            AccessToken = new GuidCommandParameter("");
        }
    }
}