using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByPKRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}