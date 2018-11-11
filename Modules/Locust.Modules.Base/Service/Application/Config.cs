using Locust.ServiceModel;
using Locust.Modules.Base.Strategies;

namespace Locust.Modules.Base.Service
{
    public class ApplicationConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApplicationAddStrategyBase, ApplicationAddStrategy>();
			Register<ApplicationUpdateStrategyBase, ApplicationUpdateStrategy>();
			Register<ApplicationDeleteStrategyBase, ApplicationDeleteStrategy>();
			Register<ApplicationGetByPKStrategyBase, ApplicationGetByPKStrategy>();
			Register<ApplicationGetByShortNameStrategyBase, ApplicationGetByShortNameStrategy>();
			Register<ApplicationGetAllStrategyBase, ApplicationGetAllStrategy>();
			
            Register<ApplicationStrategyStore, ApplicationStrategyStore>();

            Register<ApplicationServiceBase, ApplicationService>();
        }
    }
}
