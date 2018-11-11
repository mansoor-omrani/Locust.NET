using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPSetIsActiveStrategy : ApiClientIPSetIsActiveStrategyBase
    {
		public ApiClientIPSetIsActiveStrategy()
		{
			Init();
		}
		public override void Run(ApiClientIPSetIsActiveContext context)
        {
			ExecuteNonQuery(context, ctx => ctx.Request.ApiClientId.ToString());
			// ExecuteNonQuery(context, Func<ApiClientIPSetIsActiveRequest, string> keySpecifier);
        }

        public override Task RunAsync(ApiClientIPSetIsActiveContext context)
        {
			return ExecuteNonQueryAsync(context, ctx => ctx.Request.ApiClientId.ToString());
			// return ExecuteNonQueryAsync(context, Func<ApiClientIPSetIsActiveRequest, string> keySpecifier);
        }
    }
}