using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service
{
    public class ApiClientCustomerHubConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApiClientCustomerHubAddStrategyBase, ApiClientCustomerHubAddStrategy>();
			Register<ApiClientCustomerHubUpdateStrategyBase, ApiClientCustomerHubUpdateStrategy>();
			Register<ApiClientCustomerHubQuickUpdateStrategyBase, ApiClientCustomerHubQuickUpdateStrategy>();
			Register<ApiClientCustomerHubDeleteStrategyBase, ApiClientCustomerHubDeleteStrategy>();
			Register<ApiClientCustomerHubGetByPKStrategyBase, ApiClientCustomerHubGetByPKStrategy>();
			Register<ApiClientCustomerHubGetPageStrategyBase, ApiClientCustomerHubGetPageStrategy>();
			
            Register<ApiClientCustomerHubStrategyStore, ApiClientCustomerHubStrategyStore>();

            Register<ApiClientCustomerHubServiceBase, ApiClientCustomerHubService>();
        }
    }
}
