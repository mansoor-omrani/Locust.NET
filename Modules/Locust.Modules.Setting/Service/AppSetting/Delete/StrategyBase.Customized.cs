using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingDeleteStrategyBase : BabbageDataManipulationStrategy<AppSettingDeleteResponse, object, AppSettingDeleteStatus, AppSettingDeleteRequest, AppSettingDeleteContext>
    {
		protected void Init()
		{
		}
    }
}