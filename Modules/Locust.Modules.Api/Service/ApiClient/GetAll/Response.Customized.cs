using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiClient = Locust.Modules.Api.Model.ApiClient.AdminGrid;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetAllResponse : BaseServiceListResponse<ApiClient, ApiClientGetAllStatus>
    {
    }
}