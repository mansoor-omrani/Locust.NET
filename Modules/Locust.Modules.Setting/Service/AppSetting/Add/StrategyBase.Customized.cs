using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingAddStrategyBase : BabbageDataManipulationStrategy<AppSettingAddResponse, object, AppSettingAddStatus, AppSettingAddRequest, AppSettingAddContext>
    {
		protected void Init()
		{
		}
    }
}