using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service
{
    public class ServiceSettingConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ServiceSettingAddStrategyBase, ServiceSettingAddStrategy>();
			Register<ServiceSettingUpdateStrategyBase, ServiceSettingUpdateStrategy>();
			Register<ServiceSettingDeleteStrategyBase, ServiceSettingDeleteStrategy>();
			Register<ServiceSettingGetAllByServiceStrategyBase, ServiceSettingGetAllByServiceStrategy>();
			
            Register<ServiceSettingStrategyStore, ServiceSettingStrategyStore>();

            Register<ServiceSettingServiceBase, ServiceSettingService>();
        }
    }
}
