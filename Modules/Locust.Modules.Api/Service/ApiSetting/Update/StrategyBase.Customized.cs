using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiSettingUpdateStrategyBase : BabbageDataManipulationStrategy<ApiSettingUpdateResponse, object, ApiSettingUpdateStatus, ApiSettingUpdateRequest, ApiSettingUpdateContext>
    {
		protected void Init()
		{
		}
    }
}