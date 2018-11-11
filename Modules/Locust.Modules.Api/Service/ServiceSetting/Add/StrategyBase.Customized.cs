using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingAddStrategyBase : BabbageDataManipulationStrategy<ServiceSettingAddResponse, object, ServiceSettingAddStatus, ServiceSettingAddRequest, ServiceSettingAddContext>
    {
		protected void Init()
		{
		}
    }
}