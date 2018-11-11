using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingUpdateStrategy : ApiSettingUpdateStrategyBase
    {
		public ApiSettingUpdateStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(ApiSettingUpdateContext context)
        {
			//ExecuteNonQuery(context);
            ExecuteNonQuery(context, ctx => ctx.Response.ApiId.ToString());
        }

        public override Task RunAsync(ApiSettingUpdateContext context)
        {
			// return ExecuteNonQueryAsync(context);
			return ExecuteNonQueryAsync(context, ctx => ctx.Response.ApiId.ToString());
        }
    }
}