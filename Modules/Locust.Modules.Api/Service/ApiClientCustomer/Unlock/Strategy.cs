using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUnlockStrategy : ApiClientCustomerUnlockStrategyBase
    {
		public ApiClientCustomerUnlockStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerUnlockContext context)
        {
            ExecuteNonQuery(context);

            Service.CacheRemove(context);
            // ExecuteNonQuery(context, Func<ApiClientCustomerUnlockRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerUnlockContext context)
        {
            await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerUnlockRequest, string> keySpecifier);
        }
    }
}