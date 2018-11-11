using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ServiceModel;

using Locust.Modules.Api.Strategies;



namespace Locust.Modules.Api.Service
{
    public class ApiEngineConfig: ServiceConfig
    {
        public override void Configure()
        {
			Register<ApiEngineRunStrategyBase, ApiEngineRunStrategy>();
			
            Register<ApiEngineStrategyStore, ApiEngineStrategyStore>();

            Register<ApiEngineServiceBase, ApiEngineService>();
        }
    }
}
