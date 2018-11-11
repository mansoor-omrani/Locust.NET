using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingDeleteStrategyBase : BabbageDataManipulationStrategy<ServiceSettingDeleteResponse, object, ServiceSettingDeleteStatus, ServiceSettingDeleteRequest, ServiceSettingDeleteContext>
    {
		protected void Init()
		{
		}
    }
}