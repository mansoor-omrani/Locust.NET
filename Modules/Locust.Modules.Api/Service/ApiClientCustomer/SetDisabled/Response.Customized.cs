using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerSetDisabledResponse : BaseServiceResponse<object, ApiClientCustomerSetDisabledStatus>
    {
        public string AccessToken { get; set; }
    }
}