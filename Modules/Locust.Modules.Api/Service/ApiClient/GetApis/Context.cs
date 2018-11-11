using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Model.ApiClient;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientGetApisContext : BabbageContext<ApiClientGetApisResponse, IList<ClientApi>, ApiClientGetApisStatus, ApiClientGetApisRequest>
    {
    }
}