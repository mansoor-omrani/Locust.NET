using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using Locust.ServiceModel.Babbage;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public class AppSettingCategoryGetAllContext : BabbageContext<AppSettingCategoryGetAllResponse, IList<AppSettingCategory>, AppSettingCategoryGetAllStatus, AppSettingCategoryGetAllRequest>
    {
    }
}