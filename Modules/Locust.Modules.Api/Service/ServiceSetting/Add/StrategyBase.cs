using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingAddStrategyBase : BabbageDataManipulationStrategy<ServiceSettingAddResponse, object, ServiceSettingAddStatus, ServiceSettingAddRequest, ServiceSettingAddContext>
    {
        protected ServiceSettingServiceBase Service
        {
            get { return Store.Service as ServiceSettingServiceBase; }
        }
        public ServiceSettingAddStrategyBase ()
		{
			Init();
		}

    }
}