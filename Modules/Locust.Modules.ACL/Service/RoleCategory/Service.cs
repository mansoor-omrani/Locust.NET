using Locust.Logging;
using Locust.ServiceModel;

namespace Locust.Modules.ACL.Service
{
    public class RoleCategoryService : RoleCategoryServiceBase
    {
        public RoleCategoryService(RoleCategoryStrategyStore store, IExceptionLogger logger) : base(store, logger)
        { }
    }
}
