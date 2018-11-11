using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingDeleteStrategy : ApiSettingDeleteStrategyBase
    {
		public ApiSettingDeleteStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(ApiSettingDeleteContext context)
        {
			// ExecuteNonQuery(context);
			ExecuteNonQuery(context, ctx => ctx.Response.ApiId.ToString());
        }

        public override Task RunAsync(ApiSettingDeleteContext context)
        {
			// return ExecuteNonQueryAsync(context);
            return ExecuteNonQueryAsync(context, ctx => ctx.Response.ApiId.ToString());
        }
    }
}