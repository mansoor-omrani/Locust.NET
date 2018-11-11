using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public class ApiSettingUpdateContext : BabbageContext<ApiSettingUpdateResponse, object, ApiSettingUpdateStatus, ApiSettingUpdateRequest>
    {
    }
}