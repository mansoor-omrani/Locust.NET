using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerAddResponse : BaseServiceResponse<int, ApiClientCustomerAddStatus>
    {
        public int Id { get; set; }
    }
}