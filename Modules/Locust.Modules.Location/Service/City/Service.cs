using Locust.Db;
using Locust.Logging;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public partial class CityService : CityServiceBase
    {
        public CityService(CityStrategyStore store,IExceptionLogger logger, IDbHelper db) : base(store, logger, db)
        {
			Init();
		}
    }
}