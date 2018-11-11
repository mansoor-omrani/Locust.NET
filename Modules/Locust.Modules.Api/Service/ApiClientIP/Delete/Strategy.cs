using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPDeleteStrategy : ApiClientIPDeleteStrategyBase
    {
		public ApiClientIPDeleteStrategy()
		{
			Init();
		}
		public override void Run(ApiClientIPDeleteContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Request.ApiClientId.ToString());
			// ExecuteNonQuery(context, Func<ApiClientIPDeleteRequest, string> keySpecifier);
        }

        public override Task RunAsync(ApiClientIPDeleteContext context)
        {
			return ExecuteNonQueryAsync(context, ctx => ctx.Request.ApiClientId.ToString());
			// return ExecuteNonQueryAsync(context, Func<ApiClientIPDeleteRequest, string> keySpecifier);
        }
    }
}