using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;
using Locust.Modules.Api.Strategies;


namespace Locust.Modules.Api.Service
{
    public class ApiClientIPConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApiClientIPAddStrategyBase, ApiClientIPAddStrategy>();
			Register<ApiClientIPUpdateStrategyBase, ApiClientIPUpdateStrategy>();
			Register<ApiClientIPDeleteStrategyBase, ApiClientIPDeleteStrategy>();
			Register<ApiClientIPSetIsActiveStrategyBase, ApiClientIPSetIsActiveStrategy>();
			Register<ApiClientIPGetAllStrategyBase, ApiClientIPGetAllStrategy>();
			
            Register<ApiClientIPStrategyStore, ApiClientIPStrategyStore>();

            Register<ApiClientIPServiceBase, ApiClientIPService>();
        }
    }
}
