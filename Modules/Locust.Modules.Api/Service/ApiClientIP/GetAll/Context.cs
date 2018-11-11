using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using ApiClientIP = Locust.Modules.Api.Model.ApiClientIP;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientIPGetAllContext : BabbageContext<ApiClientIPGetAllResponse, IList<ApiClientIP.AdminGrid>, ApiClientIPGetAllStatus, ApiClientIPGetAllRequest>
    {
    }
}