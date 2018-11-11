using Locust.ServiceModel;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;


namespace Locust.Modules.Location.Service
{
    public class StateConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<StateAddStrategyBase, StateAddStrategy>();
			Register<StateUpdateStrategyBase, StateUpdateStrategy>();
			Register<StateDeleteByIdStrategyBase, StateDeleteByIdStrategy>();
			Register<StateGetByIdStrategyBase, StateGetByIdStrategy>();
			Register<StateGetByCodeStrategyBase, StateGetByCodeStrategy>();
			Register<StateGetAllStrategyBase, StateGetAllStrategy>();
			Register<StateGetCitiesStrategyBase, StateGetCitiesStrategy>();
			
            Register<StateStrategyStore, StateStrategyStore>();

            Register<StateServiceBase, StateService>();
        }
    }
}
