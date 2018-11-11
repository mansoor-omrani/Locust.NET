using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingAddStrategy : ApiSettingAddStrategyBase
    {
		public ApiSettingAddStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(ApiSettingAddContext context)
        {
			// ExecuteNonQuery(context);
			ExecuteNonQuery(context, ctx => ctx.Request.ApiId.ToString());
        }

        public override Task RunAsync(ApiSettingAddContext context)
        {
			// return ExecuteNonQueryAsync(context);
            return ExecuteNonQueryAsync(context, ctx => ctx.Request.ApiId.ToString());
        }
    }
}