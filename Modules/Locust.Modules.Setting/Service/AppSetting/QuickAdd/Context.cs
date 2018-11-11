using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingQuickAddContext : BabbageContext<AppSettingQuickAddResponse, object, AppSettingQuickAddStatus, AppSettingQuickAddRequest>
    {
    }
}