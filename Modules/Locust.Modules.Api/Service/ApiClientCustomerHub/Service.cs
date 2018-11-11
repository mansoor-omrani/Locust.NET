using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiClientCustomerHubService : ApiClientCustomerHubServiceBase
    {
        public ApiClientCustomerHubService(ServiceSettingServiceBase serviceSettingService, ApiClientCustomerHubStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}