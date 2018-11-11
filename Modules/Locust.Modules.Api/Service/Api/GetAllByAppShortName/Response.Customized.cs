using System.Collections.Generic;
using Locust.ServiceModel;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetAllByAppShortNameResponse : BaseServiceListResponse<API.Full, ApiGetAllByAppShortNameStatus>
    {
    }
}