using Locust.ServiceModel;
using Locust.Modules.Setting.Strategies;
using Locust.Modules.Setting.Strategies;
using Locust.Modules.Setting.Strategies;
using Locust.Modules.Setting.Strategies;
using Locust.Modules.Setting.Strategies;
using Locust.Modules.Setting.Strategies;


namespace Locust.Modules.Setting.Service
{
    public class AppSettingCategoryConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<AppSettingCategoryAddStrategyBase, AppSettingCategoryAddStrategy>();
			Register<AppSettingCategoryUpdateStrategyBase, AppSettingCategoryUpdateStrategy>();
			Register<AppSettingCategoryDeleteStrategyBase, AppSettingCategoryDeleteStrategy>();
			Register<AppSettingCategoryGetByPKStrategyBase, AppSettingCategoryGetByPKStrategy>();
			Register<AppSettingCategoryGetByCodeStrategyBase, AppSettingCategoryGetByCodeStrategy>();
			Register<AppSettingCategoryGetAllStrategyBase, AppSettingCategoryGetAllStrategy>();
			
            Register<AppSettingCategoryStrategyStore, AppSettingCategoryStrategyStore>();

            Register<AppSettingCategoryServiceBase, AppSettingCategoryService>();
        }
    }
}
