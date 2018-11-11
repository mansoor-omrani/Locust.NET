using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingGetByKeyContext : BabbageContext<AppSettingGetByKeyResponse, AppSetting, AppSettingGetByKeyStatus, AppSettingGetByKeyRequest>
    {
    }
}