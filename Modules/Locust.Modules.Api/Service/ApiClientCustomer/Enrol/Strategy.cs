using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerEnrolStrategy : ApiClientCustomerEnrolStrategyBase
    {
		public ApiClientCustomerEnrolStrategy()
		{
			Init();
		}

        private void Finalize(ApiClientCustomerEnrolContext context)
        {
            if (context.Response.Success)
            {
                context.Response.Data = new ApiClientCustomerEnrolResponseData
                {
                    ActivationCode = context.Response.ActivationCode,
                    ApiClientCustomerId = context.Response.ApiClientCustomerId
                };
            }
        }
		public override void Run(ApiClientCustomerEnrolContext context)
        {
            // ExecuteNonQuery(context);
            // ExecuteNonQuery(context, Func<ApiClientCustomerEnrolRequest, string> keySpecifier);
            ExecuteNonQuery(context);

            Finalize(context);
        }

        public override async Task RunAsync(ApiClientCustomerEnrolContext context)
        {
            // return ExecuteNonQueryAsync(context);
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerEnrolRequest, string> keySpecifier);
            await ExecuteNonQueryAsync(context);

            Finalize(context);
        }
    }
}