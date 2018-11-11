using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPUpdateStrategy : ApiClientIPUpdateStrategyBase
    {
		public ApiClientIPUpdateStrategy()
		{
			Init();
		}
		public override void Run(ApiClientIPUpdateContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Request.ApiClientId.ToString());
			// ExecuteNonQuery(context, Func<ApiClientIPUpdateRequest, string> keySpecifier);
        }

        public override Task RunAsync(ApiClientIPUpdateContext context)
        {
			return ExecuteNonQueryAsync(context, ctx => ctx.Request.ApiClientId.ToString());
			// return ExecuteNonQueryAsync(context, Func<ApiClientIPUpdateRequest, string> keySpecifier);
        }
    }
}