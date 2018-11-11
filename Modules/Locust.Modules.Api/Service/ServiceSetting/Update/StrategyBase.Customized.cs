using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingUpdateStrategyBase : BabbageDataManipulationStrategy<ServiceSettingUpdateResponse, object, ServiceSettingUpdateStatus, ServiceSettingUpdateRequest, ServiceSettingUpdateContext>
    {
		protected void Init()
		{
		}
    }
}