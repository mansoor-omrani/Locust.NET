using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubQuickUpdateRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public int MaxCustomer { get; set; }
        public bool IsActive { get; set; }
    }
}