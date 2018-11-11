using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service
{
    public class ApiClientConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApiClientAddStrategyBase, ApiClientAddStrategy>();
			Register<ApiClientUpdateStrategyBase, ApiClientUpdateStrategy>();
			Register<ApiClientDeleteByPKStrategyBase, ApiClientDeleteByPKStrategy>();
			Register<ApiClientDeleteByKeyStrategyBase, ApiClientDeleteByKeyStrategy>();
			Register<ApiClientRemoveByPKStrategyBase, ApiClientRemoveByPKStrategy>();
			Register<ApiClientRemoveByKeyStrategyBase, ApiClientRemoveByKeyStrategy>();
			Register<ApiClientGetByPKStrategyBase, ApiClientGetByPKStrategy>();
			Register<ApiClientGetByKeyStrategyBase, ApiClientGetByKeyStrategy>();
			Register<ApiClientGetByHashStrategyBase, ApiClientGetByHashStrategy>();
			Register<ApiClientGetAllStrategyBase, ApiClientGetAllStrategy>();
			Register<ApiClientGetApisStrategyBase, ApiClientGetApisStrategy>();
			Register<ApiClientSaveApisStrategyBase, ApiClientSaveApisStrategy>();
			Register<ApiClientGetPageStrategyBase, ApiClientGetPageStrategy>();
			
            Register<ApiClientStrategyStore, ApiClientStrategyStore>();

            Register<ApiClientServiceBase, ApiClientService>();
        }
    }
}
