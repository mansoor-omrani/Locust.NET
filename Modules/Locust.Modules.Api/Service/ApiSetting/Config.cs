using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;


namespace Locust.Modules.Api.Service
{
    public class ApiSettingConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApiSettingAddStrategyBase, ApiSettingAddStrategy>();
			Register<ApiSettingUpdateStrategyBase, ApiSettingUpdateStrategy>();
			Register<ApiSettingDeleteStrategyBase, ApiSettingDeleteStrategy>();
			Register<ApiSettingGetAllByApiStrategyBase, ApiSettingGetAllByApiStrategy>();
			
            Register<ApiSettingStrategyStore, ApiSettingStrategyStore>();

            Register<ApiSettingServiceBase, ApiSettingService>();
        }
    }
}
