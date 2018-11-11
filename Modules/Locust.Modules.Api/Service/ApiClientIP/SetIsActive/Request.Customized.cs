using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPSetIsActiveRequest : IBaseServiceRequest
    {
        public int ApiClientId { get; set; }
        public string IP { get; set; }
        public bool IsActive { get; set; }
    }
}