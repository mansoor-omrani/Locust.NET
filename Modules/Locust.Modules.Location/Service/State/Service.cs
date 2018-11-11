using Locust.Db;
using Locust.Logging;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public partial class StateService : StateServiceBase
    {
        public StateService(StateStrategyStore store,IExceptionLogger logger, IDbHelper db) : base(store, logger, db)
        {
			Init();
		}
    }
}