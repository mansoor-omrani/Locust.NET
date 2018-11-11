using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientAddStrategy : ApiClientAddStrategyBase
    {
		public ApiClientAddStrategy()
		{
			Init();
		}
		public override void Run(ApiClientAddContext context)
        {
			ExecuteNonQuery(context);

            context.Response.Data = context.Response.Id;
            // ExecuteNonQuery(context, Func<ApiClientAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientAddContext context)
        {
			await ExecuteNonQueryAsync(context);

            context.Response.Data = context.Response.Id;
            // return ExecuteNonQueryAsync(context, Func<ApiClientAddRequest, string> keySpecifier);
        }
    }
}