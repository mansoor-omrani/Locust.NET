using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingQuickUpdateContext : BabbageContext<AppSettingQuickUpdateResponse, object, AppSettingQuickUpdateStatus, AppSettingQuickUpdateRequest>
    {
    }
}