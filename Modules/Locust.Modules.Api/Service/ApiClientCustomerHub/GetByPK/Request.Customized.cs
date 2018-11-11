using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubGetByPKRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}