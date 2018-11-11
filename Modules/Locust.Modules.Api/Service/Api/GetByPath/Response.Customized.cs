using Locust.ServiceModel;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetByPathResponse : BaseServiceResponse<API.Full, ApiGetByPathStatus>
    {
    }
}