using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerSetActivatedResponse : BaseServiceResponse<object, ApiClientCustomerSetActivatedStatus>
    {
        public string AccessToken { get; set; }
    }
}