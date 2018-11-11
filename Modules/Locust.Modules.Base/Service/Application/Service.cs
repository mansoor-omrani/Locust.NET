using Locust.Db;
using Locust.Logging;
using Locust.Modules.Base.Strategies;
namespace Locust.Modules.Base.Service
{
	public partial class ApplicationService : ApplicationServiceBase
    {
        public ApplicationService(ApplicationStrategyStore store,IExceptionLogger logger, IDbHelper db) : base(store, logger, db)
        {
			Init();
		}
    }
}