using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public class ApiGetAllContext : BabbageContext<ApiGetAllResponse, IList<API.AdminGrid>, ApiGetAllStatus, ApiGetAllRequest>
    {
    }
}