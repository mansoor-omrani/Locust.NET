using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubUpdateRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public int ApiClientCustomerHubTypeId { get; set; }
        public int MaxCustomer { get; set; }
        public bool IsActive { get; set; }
        public string HubUniqueCode { get; set; }
    }
}