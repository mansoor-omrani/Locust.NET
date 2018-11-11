using Locust.Logging;
using Locust.Modules.ACL.Strategies;
using Locust.ServiceModel;

namespace Locust.Modules.ACL.Service
{
    public abstract class RoleCategoryServiceBase : BaseService
    {
        public RoleCategoryGetByIdStrategyBase GetById
        {
            get { return (Store as RoleCategoryStrategyStore).GetById; }
        }

        public RoleCategoryServiceBase(RoleCategoryStrategyStore store, IExceptionLogger logger): base(store, logger)
        { }
    }
}
