using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiSettingDeleteStrategyBase : BabbageDataManipulationStrategy<ApiSettingDeleteResponse, object, ApiSettingDeleteStatus, ApiSettingDeleteRequest, ApiSettingDeleteContext>
    {
		protected void Init()
		{
		}
    }
}