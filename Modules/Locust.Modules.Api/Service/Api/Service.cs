using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiService : ApiServiceBase
    {
        public ApiService(ServiceSettingServiceBase serviceSettingService, ApiStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}