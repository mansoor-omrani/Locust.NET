using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingQuickUpdateStrategyBase : BabbageDataManipulationStrategy<AppSettingQuickUpdateResponse, object, AppSettingQuickUpdateStatus, AppSettingQuickUpdateRequest, AppSettingQuickUpdateContext>
    {
		protected void Init()
		{
		}
    }
}