using System;
using Locust.Caching;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Modules.ACL.Service.Strategies;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.ACL.Strategies
{
    public partial class RoleCategoryGetByIdStrategy : RoleCategoryGetByIdStrategyBase
    {
        public RoleCategoryGetByIdStrategy(ICacheFactory cacheFactory): base(cacheFactory)
        {
			Init();
		}

        public override void Run(RoleCategoryGetByIdContext context)
        {
            ExecuteSingle(context, (ctx) => ctx.Request.Id.ToString());
        }

        public override Task RunAsync(RoleCategoryGetByIdContext context)
        {
            return ExecuteSingleAsync(context, (ctx) => ctx.Request.Id.ToString());
        }
    }
}
