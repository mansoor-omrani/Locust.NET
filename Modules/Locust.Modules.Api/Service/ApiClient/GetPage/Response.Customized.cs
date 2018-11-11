using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ResponseType = Locust.Modules.Api.Model.ApiClient.GetPage;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetPageResponse : BaseServicePageResponse<ResponseType, ApiClientGetPageStatus>
    {
    }
}