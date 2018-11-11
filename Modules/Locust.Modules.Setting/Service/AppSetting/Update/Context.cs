using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingUpdateContext : BabbageContext<AppSettingUpdateResponse, object, AppSettingUpdateStatus, AppSettingUpdateRequest>
    {
    }
}