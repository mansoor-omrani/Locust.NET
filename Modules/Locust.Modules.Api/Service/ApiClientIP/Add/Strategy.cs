using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPAddStrategy : ApiClientIPAddStrategyBase
    {
		public ApiClientIPAddStrategy()
		{
			Init();
		}
		public override void Run(ApiClientIPAddContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Request.ApiClientId.ToString());

            context.Response.Data = new {context.Request.ApiClientId, context.Request.IP};
            // ExecuteNonQuery(context, Func<ApiClientIPAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientIPAddContext context)
        {
			await ExecuteNonQueryAsync(context, ctx => ctx.Request.ApiClientId.ToString());

            context.Response.Data = new { context.Request.ApiClientId, context.Request.IP };
            // return ExecuteNonQueryAsync(context, Func<ApiClientIPAddRequest, string> keySpecifier);
        }
    }
}