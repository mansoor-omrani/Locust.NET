using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationAddStrategy : ApplicationAddStrategyBase
    {
		public ApplicationAddStrategy(ICacheFactory iCacheFactory, ISetting iSetting):base(iCacheFactory, iSetting)
		{
			Init();
		}
		public override void Run(ApplicationAddContext context)
        {
			ExecuteNonQuery(context);

            context.Response.Data = context.Response.Id;
            // ExecuteNonQuery(context, Func<ApplicationAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApplicationAddContext context)
        {
			await ExecuteNonQueryAsync(context);

            context.Response.Data = context.Response.Id;
            // return ExecuteNonQueryAsync(context, Func<ApplicationAddRequest, string> keySpecifier);
        }
    }
}