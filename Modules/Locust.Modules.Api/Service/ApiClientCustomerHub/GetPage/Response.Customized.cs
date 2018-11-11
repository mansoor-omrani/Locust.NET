using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubGetPageResponse : BaseServicePageResponse<ApiClientCustomerHub.AdminGrid, ApiClientCustomerHubGetPageStatus>
    {
    }
}