using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetPageResponse : BaseServicePageResponse<ApiClientCustomer.AdminGrid, ApiClientCustomerGetPageStatus>
    {
    }
}