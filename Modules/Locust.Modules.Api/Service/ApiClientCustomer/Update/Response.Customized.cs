using Locust.Data;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUpdateResponse : BaseServiceResponse<object, ApiClientCustomerUpdateStatus>
    {
        public string OiriginalAccessToken { get; set; }
    }
}