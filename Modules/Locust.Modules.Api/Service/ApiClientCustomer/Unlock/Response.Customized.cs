using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUnlockResponse : BaseServiceResponse<object, ApiClientCustomerUnlockStatus>
    {
        public string AccessToken { get; set; }
    }
}