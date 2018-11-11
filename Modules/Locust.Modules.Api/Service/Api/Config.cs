using Locust.ServiceModel;
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
    public class ApiConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApiAddStrategyBase, ApiAddStrategy>();
			Register<ApiUpdateStrategyBase, ApiUpdateStrategy>();
			Register<ApiDeleteStrategyBase, ApiDeleteStrategy>();
			Register<ApiGetByPKStrategyBase, ApiGetByPKStrategy>();
			Register<ApiGetByPathStrategyBase, ApiGetByPathStrategy>();
			Register<ApiGetAllStrategyBase, ApiGetAllStrategy>();
			Register<ApiGetAllByAppShortNameStrategyBase, ApiGetAllByAppShortNameStrategy>();
			Register<ApiCheckAccessStrategyBase, ApiCheckAccessStrategy>();
			
            Register<ApiStrategyStore, ApiStrategyStore>();

            Register<ApiServiceBase, ApiService>();
        }
    }
}
