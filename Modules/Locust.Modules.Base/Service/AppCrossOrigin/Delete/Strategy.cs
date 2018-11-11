using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginDeleteStrategy : AppCrossOriginDeleteStrategyBase
    {
		public AppCrossOriginDeleteStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppCrossOriginDeleteContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Response.AppId.ToString());
			// ExecuteNonQuery(context, Func<AppCrossOriginDeleteRequest, string> keySpecifier);
        }

        public override Task RunAsync(AppCrossOriginDeleteContext context)
        {
			return ExecuteNonQueryAsync(context, ctx => ctx.Response.AppId.ToString());
			// return ExecuteNonQueryAsync(context, Func<AppCrossOriginDeleteRequest, string> keySpecifier);
        }
    }
}