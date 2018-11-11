using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiCheckAccessRequest : IBaseServiceRequest
    {
	    public int ApiId { get; set; }
        public int ApiClientId { get; set; }
        public int ApiClientCustomerId { get; set; }
    }
}