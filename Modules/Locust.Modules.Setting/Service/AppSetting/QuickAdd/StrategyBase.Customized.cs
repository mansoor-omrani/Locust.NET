using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingQuickAddStrategyBase : BabbageDataManipulationStrategy<AppSettingQuickAddResponse, object, AppSettingQuickAddStatus, AppSettingQuickAddRequest, AppSettingQuickAddContext>
    {
		protected void Init()
		{
		}
    }
}