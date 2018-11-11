using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using ApiClient = Locust.Modules.Api.Model.ApiClient.AdminGrid;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientGetAllContext : BabbageContext<ApiClientGetAllResponse, IList<ApiClient>, ApiClientGetAllStatus, ApiClientGetAllRequest>
    {
    }
}