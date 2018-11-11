using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingCategoryGetByCodeContext : BabbageContext<AppSettingCategoryGetByCodeResponse, AppSettingCategory, AppSettingCategoryGetByCodeStatus, AppSettingCategoryGetByCodeRequest>
    {
    }
}