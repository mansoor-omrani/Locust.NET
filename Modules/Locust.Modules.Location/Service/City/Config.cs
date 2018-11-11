using Locust.ServiceModel;
using Locust.Modules.Location.Strategies;

namespace Locust.Modules.Location.Service
{
    public class CityConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<CityAddStrategyBase, CityAddStrategy>();
			Register<CityUpdateStrategyBase, CityUpdateStrategy>();
			Register<CityDeleteByIdStrategyBase, CityDeleteByIdStrategy>();
			Register<CityGetByIdStrategyBase, CityGetByIdStrategy>();
			Register<CityGetByCodeStrategyBase, CityGetByCodeStrategy>();
			Register<CityGetAllStrategyBase, CityGetAllStrategy>();
			Register<CityGetAllByStateStrategyBase, CityGetAllByStateStrategy>();
			Register<CityGetByStateStrategyBase, CityGetByStateStrategy>();
			
            Register<CityStrategyStore, CityStrategyStore>();

            Register<CityServiceBase, CityService>();
        }
    }
}
