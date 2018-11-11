using Locust.ServiceModel;
using Locust.Modules.Base.Strategies;

namespace Locust.Modules.Base.Service
{
    public class AppCrossOriginConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<AppCrossOriginAddStrategyBase, AppCrossOriginAddStrategy>();
			Register<AppCrossOriginUpdateStrategyBase, AppCrossOriginUpdateStrategy>();
			Register<AppCrossOriginDeleteStrategyBase, AppCrossOriginDeleteStrategy>();
			Register<AppCrossOriginGetByPKStrategyBase, AppCrossOriginGetByPKStrategy>();
			Register<AppCrossOriginGetAllStrategyBase, AppCrossOriginGetAllStrategy>();
			
            Register<AppCrossOriginStrategyStore, AppCrossOriginStrategyStore>();

            Register<AppCrossOriginServiceBase, AppCrossOriginService>();
        }
    }
}
