using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientCustomerGetPageContext : BabbageContext<ApiClientCustomerGetPageResponse, PageData<ApiClientCustomer.AdminGrid>, ApiClientCustomerGetPageStatus, ApiClientCustomerGetPageRequest>
    {
    }
}