using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingCategoryGetByPKContext : BabbageContext<AppSettingCategoryGetByPKResponse, AppSettingCategory, AppSettingCategoryGetByPKStatus, AppSettingCategoryGetByPKRequest>
    {
    }
}