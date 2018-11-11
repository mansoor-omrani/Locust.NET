using System.Threading.Tasks;
using Locust.Caching;
using Locust.Collections;
using Locust.Db;
using Locust.Logging;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Service
{
	public partial class ServiceSettingService : ServiceSettingServiceBase
    {
        public ServiceSettingService(ServiceSettingStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(store, logger, db, cacheFactory)
        {
			Init();
		}
        
    }
}