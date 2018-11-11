using Locust.ServiceModel;
using Locust.Modules.Setting.Strategies;

namespace Locust.Modules.Setting.Service
{
    public class AppSettingConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<AppSettingAddStrategyBase, AppSettingAddStrategy>();
			Register<AppSettingQuickAddStrategyBase, AppSettingQuickAddStrategy>();
			Register<AppSettingUpdateStrategyBase, AppSettingUpdateStrategy>();
			Register<AppSettingQuickUpdateStrategyBase, AppSettingQuickUpdateStrategy>();
			Register<AppSettingDeleteStrategyBase, AppSettingDeleteStrategy>();
			Register<AppSettingGetByPKStrategyBase, AppSettingGetByPKStrategy>();
			Register<AppSettingGetByKeyStrategyBase, AppSettingGetByKeyStrategy>();
			Register<AppSettingGetAllStrategyBase, AppSettingGetAllStrategy>();
			
            Register<AppSettingStrategyStore, AppSettingStrategyStore>();

            Register<AppSettingServiceBase, AppSettingService>();
        }
    }
}
