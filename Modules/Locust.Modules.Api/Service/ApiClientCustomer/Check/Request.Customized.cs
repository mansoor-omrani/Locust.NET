using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerCheckRequest : IBaseServiceRequest
    {
        public string AccessToken { get; set; }
    }
}