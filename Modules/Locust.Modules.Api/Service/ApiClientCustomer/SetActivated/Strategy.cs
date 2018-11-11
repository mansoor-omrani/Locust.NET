using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerSetActivatedStrategy : ApiClientCustomerSetActivatedStrategyBase
    {
		public ApiClientCustomerSetActivatedStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerSetActivatedContext context)
        {
			ExecuteNonQuery(context);

            Service.CacheRemove(context);
            // ExecuteNonQuery(context, Func<ApiClientCustomerSetActivatedRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerSetActivatedContext context)
        {
            await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerSetActivatedRequest, string> keySpecifier);
        }
    }
}