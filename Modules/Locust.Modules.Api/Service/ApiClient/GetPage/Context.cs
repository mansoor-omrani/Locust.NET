using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using ResponseType = Locust.Modules.Api.Model.ApiClient.GetPage;

namespace Locust.Modules.Api.Strategies
{
	public class ApiClientGetPageContext : BabbageContext<ApiClientGetPageResponse, PageData<ResponseType>, ApiClientGetPageStatus, ApiClientGetPageRequest>
    {
    }
}