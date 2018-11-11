using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientUpdateResponse : BaseServiceResponse<object, ApiClientUpdateStatus>
    {
        public string OldClientKey { get; set; }
    }
}