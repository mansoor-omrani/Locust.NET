using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingUpdateStrategyBase : BabbageDataManipulationStrategy<ServiceSettingUpdateResponse, object, ServiceSettingUpdateStatus, ServiceSettingUpdateRequest, ServiceSettingUpdateContext>
    {
        protected ServiceSettingServiceBase Service
        {
            get { return Store.Service as ServiceSettingServiceBase; }
        }
        public ServiceSettingUpdateStrategyBase ()
		{
			Init();
		}

    }
}