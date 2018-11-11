using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetByKeyResponse : BaseServiceResponse<AppSetting, AppSettingGetByKeyStatus>
    {
    }
}