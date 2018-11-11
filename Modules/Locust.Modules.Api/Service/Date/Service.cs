using Locust.Db;
using Locust.Logging;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class DateService : DateServiceBase
    {
        public DateService(DateStrategyStore store,IExceptionLogger logger, IDbHelper db) : base(store, logger, db)
        {
			Init();
		}
    }
}