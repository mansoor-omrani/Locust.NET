using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingCategoryAddStrategyBase : BabbageDataManipulationStrategy<AppSettingCategoryAddResponse, object, AppSettingCategoryAddStatus, AppSettingCategoryAddRequest, AppSettingCategoryAddContext>
    {
		protected void Init()
		{
		}
    }
}