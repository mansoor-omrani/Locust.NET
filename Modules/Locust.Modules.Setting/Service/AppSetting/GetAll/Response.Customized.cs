using System.Collections.Generic;
using Locust.ServiceModel;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetAllResponse : BaseServiceListResponse<AppSetting, AppSettingGetAllStatus>
    {
    }
}