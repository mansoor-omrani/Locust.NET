using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Service
{
	public abstract class ApiEngineServiceBase : ApiBaseService
	{
        public ApiEngineRunStrategyBase Run 
		{ 
			get { return (Store as ApiEngineStrategyStore).Run; }
		}
	    public ApiEngineServiceBase(ApiEngineStrategyStore store, ServiceSettingServiceBase serviceSettingService, IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory)
	        : base(serviceSettingService, store, logger, db, cacheFactory)
	    { }
    }
}