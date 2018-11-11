using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerDeleteResponse : BaseServiceResponse<object, ApiClientCustomerDeleteStatus>
    {
        public string AccessToken { get; set; }
    }
}