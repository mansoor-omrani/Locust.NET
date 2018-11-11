using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationUpdateStrategy : ApplicationUpdateStrategyBase
    {
		public ApplicationUpdateStrategy(ICacheFactory iCacheFactory, ISetting iSetting):base(iCacheFactory, iSetting)
		{
			Init();
		}
		public override void Run(ApplicationUpdateContext context)
        {
			ExecuteNonQuery(context, (ctx) => ctx.Response.OldShortName);

            if (context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
            }
        }

        public override async Task RunAsync(ApplicationUpdateContext context)
        {
            await ExecuteNonQueryAsync(context, (ctx) => ctx.Response.OldShortName);

            if (context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
            }
        }
    }
}