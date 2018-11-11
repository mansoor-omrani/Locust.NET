using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingCategoryDeleteStrategyBase : BabbageDataManipulationStrategy<AppSettingCategoryDeleteResponse, object, AppSettingCategoryDeleteStatus, AppSettingCategoryDeleteRequest, AppSettingCategoryDeleteContext>
    {
		protected void Init()
		{
		}
    }
}