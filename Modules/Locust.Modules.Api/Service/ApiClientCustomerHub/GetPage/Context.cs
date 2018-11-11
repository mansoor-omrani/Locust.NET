using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using ApiClientCustomerHub = Locust.Modules.Api.Model.ApiClientCustomerHub;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientCustomerHubGetPageContext : BabbageContext<ApiClientCustomerHubGetPageResponse, PageData<ApiClientCustomerHub.AdminGrid>, ApiClientCustomerHubGetPageStatus, ApiClientCustomerHubGetPageRequest>
    {
    }
}