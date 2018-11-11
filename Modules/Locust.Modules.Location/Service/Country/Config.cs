using Locust.ServiceModel;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;
using Locust.Modules.Location.Strategies;


namespace Locust.Modules.Location.Service
{
    public class CountryConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<CountryAddStrategyBase, CountryAddStrategy>();
			Register<CountryUpdateStrategyBase, CountryUpdateStrategy>();
			Register<CountryDeleteByIdStrategyBase, CountryDeleteByIdStrategy>();
			Register<CountryGetByIdStrategyBase, CountryGetByIdStrategy>();
			Register<CountryGetByCodeStrategyBase, CountryGetByCodeStrategy>();
			Register<CountryGetAllStrategyBase, CountryGetAllStrategy>();
			
            Register<CountryStrategyStore, CountryStrategyStore>();

            Register<CountryServiceBase, CountryService>();
        }
    }
}
