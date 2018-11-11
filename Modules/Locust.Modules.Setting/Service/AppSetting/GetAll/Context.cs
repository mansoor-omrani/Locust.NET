using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingGetAllContext : BabbageContext<AppSettingGetAllResponse, IList<AppSetting>, AppSettingGetAllStatus, AppSettingGetAllRequest>
    {
    }
}