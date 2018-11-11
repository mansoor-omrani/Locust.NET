using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubAddStrategy : ApiClientCustomerHubAddStrategyBase
    {
		public ApiClientCustomerHubAddStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerHubAddContext context)
        {
			ExecuteNonQuery(context);

            context.Response.Data = context.Response.Id;
            // ExecuteNonQuery(context, Func<ApiClientCustomerHubAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerHubAddContext context)
        {
			await ExecuteNonQueryAsync(context);

            context.Response.Data = context.Response.Id;
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerHubAddRequest, string> keySpecifier);
        }
    }
}