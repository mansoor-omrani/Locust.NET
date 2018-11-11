using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginUpdateStrategy : AppCrossOriginUpdateStrategyBase
    {
		public AppCrossOriginUpdateStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppCrossOriginUpdateContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Response.AppId.ToString());
			// ExecuteNonQuery(context, Func<AppCrossOriginUpdateRequest, string> keySpecifier);
        }

        public override Task RunAsync(AppCrossOriginUpdateContext context)
        {
			return ExecuteNonQueryAsync(context, ctx => ctx.Response.AppId.ToString());
			// return ExecuteNonQueryAsync(context, Func<AppCrossOriginUpdateRequest, string> keySpecifier);
        }
    }
}