using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByHashRequest : IBaseServiceRequest
    {
        public string ClientKeyHash { get; set; }
    }
}