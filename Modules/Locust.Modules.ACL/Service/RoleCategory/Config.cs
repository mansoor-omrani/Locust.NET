using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.ACL.Strategies;
using Locust.ServiceModel;

namespace Locust.Modules.ACL.Service
{
    public class RoleCategoryConfig: ServiceConfig
    {
        public override void Configure()
        {
            Register<RoleCategoryGetByIdStrategyBase, RoleCategoryGetByIdStrategy>();

            Register<RoleCategoryStrategyStore, RoleCategoryStrategyStore>();
            Register<RoleCategoryServiceBase, RoleCategoryService>();
        }
    }
}
