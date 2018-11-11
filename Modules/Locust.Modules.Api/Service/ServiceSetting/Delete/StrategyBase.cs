using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingDeleteStrategyBase : BabbageDataManipulationStrategy<ServiceSettingDeleteResponse, object, ServiceSettingDeleteStatus, ServiceSettingDeleteRequest, ServiceSettingDeleteContext>
    {
        protected ServiceSettingServiceBase Service
        {
            get { return Store.Service as ServiceSettingServiceBase; }
        }
        public ServiceSettingDeleteStrategyBase ()
		{
			Init();
		}

    }
}