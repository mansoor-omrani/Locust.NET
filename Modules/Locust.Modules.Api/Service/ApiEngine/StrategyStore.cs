using Locust.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service
{
	public class ApiEngineStrategyStore : BaseServiceStrategyStore
    {
		public ApiEngineRunStrategyBase Run 
		{ 
			get { return _runStrategy; }
		}

		
		protected ApiEngineRunStrategyBase _runStrategy;
		
        public ApiEngineStrategyStore(ApiEngineRunStrategyBase runStrategy)
        {
			if (runStrategy == null)
				throw new ArgumentNullException("runStrategy");

			
			_runStrategy = runStrategy;
			
            Register(runStrategy);
			
        }
    }
}