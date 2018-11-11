using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiClientIPService : ApiClientIPServiceBase
    {
        public ApiClientIPService(ServiceSettingServiceBase serviceSettingService, ApiClientIPStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}