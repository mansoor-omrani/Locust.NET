using Locust.Db;
using Locust.Logging;
using Locust.Caching;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service
{
	public partial class ApiClientService : ApiClientServiceBase
    {
        public ApiClientService(ServiceSettingServiceBase serviceSettingService, ApiClientStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}