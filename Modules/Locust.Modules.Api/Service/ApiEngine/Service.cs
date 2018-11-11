using Locust.Caching;
using Locust.Db;
using Locust.Logging;

namespace Locust.Modules.Api.Service
{
	public class ApiEngineService : ApiEngineServiceBase
    {
        public ApiEngineService(ApiEngineStrategyStore store, ServiceSettingServiceBase serviceSettingService, IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(store, serviceSettingService, logger, db, cacheFactory)
        { }
    }
}