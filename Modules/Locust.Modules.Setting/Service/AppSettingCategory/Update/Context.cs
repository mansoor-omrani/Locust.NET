using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingCategoryUpdateContext : BabbageContext<AppSettingCategoryUpdateResponse, object, AppSettingCategoryUpdateStatus, AppSettingCategoryUpdateRequest>
    {
    }
}