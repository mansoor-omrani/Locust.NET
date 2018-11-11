using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetByCodeResponse : BaseServiceResponse<AppSettingCategory, AppSettingCategoryGetByCodeStatus>
    {
    }
}