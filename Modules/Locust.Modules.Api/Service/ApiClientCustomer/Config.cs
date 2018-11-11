using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;


namespace Locust.Modules.Api.Service
{
    public class ApiClientCustomerConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApiClientCustomerAddStrategyBase, ApiClientCustomerAddStrategy>();
			Register<ApiClientCustomerUpdateStrategyBase, ApiClientCustomerUpdateStrategy>();
			Register<ApiClientCustomerDeleteStrategyBase, ApiClientCustomerDeleteStrategy>();
			Register<ApiClientCustomerSetActivatedStrategyBase, ApiClientCustomerSetActivatedStrategy>();
			Register<ApiClientCustomerSetDisabledStrategyBase, ApiClientCustomerSetDisabledStrategy>();
			Register<ApiClientCustomerUnlockStrategyBase, ApiClientCustomerUnlockStrategy>();
			Register<ApiClientCustomerGetByPKStrategyBase, ApiClientCustomerGetByPKStrategy>();
			Register<ApiClientCustomerGetByTokenStrategyBase, ApiClientCustomerGetByTokenStrategy>();
			Register<ApiClientCustomerCheckStrategyBase, ApiClientCustomerCheckStrategy>();
			Register<ApiClientCustomerActivateStrategyBase, ApiClientCustomerActivateStrategy>();
			Register<ApiClientCustomerRefreshStrategyBase, ApiClientCustomerRefreshStrategy>();
			Register<ApiClientCustomerRegisterStrategyBase, ApiClientCustomerRegisterStrategy>();
			Register<ApiClientCustomerEnrolStrategyBase, ApiClientCustomerEnrolStrategy>();
			Register<ApiClientCustomerGetPageStrategyBase, ApiClientCustomerGetPageStrategy>();
			
            Register<ApiClientCustomerStrategyStore, ApiClientCustomerStrategyStore>();

            Register<ApiClientCustomerServiceBase, ApiClientCustomerService>();
        }
    }
}
