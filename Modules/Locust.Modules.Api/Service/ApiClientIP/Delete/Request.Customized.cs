using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPDeleteRequest : IBaseServiceRequest
    {
        public int ApiClientId { get; set; }
        public string IP { get; set; }
    }
}