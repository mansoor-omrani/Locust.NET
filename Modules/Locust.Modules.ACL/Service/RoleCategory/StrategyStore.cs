using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.ACL.Service.Strategies;
using Locust.Modules.ACL.Strategies;
using Locust.ServiceModel;

namespace Locust.Modules.ACL.Service
{
    public class RoleCategoryStrategyStore: BaseServiceStrategyStore
    {
        public RoleCategoryGetByIdStrategyBase GetById
        {
            get { return _getByIdStrategy; }
        }

        protected RoleCategoryGetByIdStrategyBase _getByIdStrategy;
        public RoleCategoryStrategyStore(RoleCategoryGetByIdStrategyBase getByIdStrategy)
        {
            if (getByIdStrategy == null)
                throw new ArgumentNullException("getByIdStrategy");

            _getByIdStrategy = getByIdStrategy;

            Register(getByIdStrategy);
        }
    }

}
