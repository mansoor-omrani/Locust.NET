using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubAddRequest : IBaseServiceRequest
    {
        public CommandParameter Id { get; set; }
        public int ApiClientCustomerHubTypeId { get; set; }
        public int ApiClientId { get; set; }
        public int MaxCustomer { get; set; }
        public bool IsActive { get; set; }
        public string HubUniqueCode { get; set; }

        public ApiClientCustomerHubAddRequest()
        {
            Id = CommandParameter.Output(SqlDbType.Int);
        }
    }
}