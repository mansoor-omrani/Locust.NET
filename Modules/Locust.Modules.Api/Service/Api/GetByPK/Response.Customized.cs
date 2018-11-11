using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetByPKResponse : BaseServiceResponse<API.Full, ApiGetByPKStatus>
    {
    }
}