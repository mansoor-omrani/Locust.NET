using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginAddStrategy : AppCrossOriginAddStrategyBase
    {
		public AppCrossOriginAddStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppCrossOriginAddContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Request.AppId.ToString());

            context.Response.Data = context.Response.Id;
            // ExecuteNonQuery(context, Func<AppCrossOriginAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(AppCrossOriginAddContext context)
        {
			await ExecuteNonQueryAsync(context, ctx => ctx.Request.AppId.ToString());

            context.Response.Data = context.Response.Id;
            // return ExecuteNonQueryAsync(context, Func<AppCrossOriginAddRequest, string> keySpecifier);
        }
    }
}