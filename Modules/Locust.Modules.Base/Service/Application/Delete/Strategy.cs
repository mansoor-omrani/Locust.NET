using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationDeleteStrategy : ApplicationDeleteStrategyBase
    {
		public ApplicationDeleteStrategy(ICacheFactory iCacheFactory, ISetting iSetting):base(iCacheFactory, iSetting)
		{
			Init();
		}
		public override void Run(ApplicationDeleteContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Response.ShortName);

            if (context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
            }
        }

        public override async Task RunAsync(ApplicationDeleteContext context)
        {
            await ExecuteNonQueryAsync(context, ctx => ctx.Response.ShortName);

            if (context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
            }
        }
    }
}