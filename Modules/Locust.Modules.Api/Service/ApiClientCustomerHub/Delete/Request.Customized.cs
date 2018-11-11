using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubDeleteRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}