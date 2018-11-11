using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerAddStrategy : ApiClientCustomerAddStrategyBase
    {
		public ApiClientCustomerAddStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerAddContext context)
        {
			ExecuteNonQuery(context);

            if (context.Response.Success)
            {
                context.Response.Data = context.Response.Id;
            }
			// ExecuteNonQuery(context, Func<ApiClientCustomerAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerAddContext context)
        {
            await ExecuteNonQueryAsync(context);

            if (context.Response.Success)
            {
                context.Response.Data = context.Response.Id;
            }
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerAddRequest, string> keySpecifier);
        }
    }
}