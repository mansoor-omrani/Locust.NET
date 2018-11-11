using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubAddResponse : BaseServiceResponse<int, ApiClientCustomerHubAddStatus>
    {
        public int Id { get; set; }
    }
}