using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetAllResponse : BaseServiceListResponse<API.AdminGrid, ApiGetAllStatus>
    {
    }
}