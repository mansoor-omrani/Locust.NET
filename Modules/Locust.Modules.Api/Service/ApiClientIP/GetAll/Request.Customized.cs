using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPGetAllRequest : IBaseServiceRequest
    {
        public int ApiClientId { get; set; }
    }
}