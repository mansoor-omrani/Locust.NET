using Locust.ServiceModel;
using Locust.Modules.Api.Service.ApiEngine;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetAllByAppShortNameRequest : ApiBaseRequest
    {
        public string AppShortName { get; set; }
    }
}