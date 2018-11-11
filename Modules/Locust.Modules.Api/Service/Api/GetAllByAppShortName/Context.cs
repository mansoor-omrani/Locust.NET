using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public class ApiGetAllByAppShortNameContext : BabbageContext<ApiGetAllByAppShortNameResponse, IList<API.Full>, ApiGetAllByAppShortNameStatus, ApiGetAllByAppShortNameRequest>
    {
    }
}