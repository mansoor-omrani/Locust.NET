using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;


namespace Locust.Modules.Api.Service
{
    public class DateConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<DateNowStrategyBase, DateNowStrategy>();
			
            Register<DateStrategyStore, DateStrategyStore>();

            Register<DateServiceBase, DateService>();
        }
    }
}
