using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerDeleteStrategy : ApiClientCustomerDeleteStrategyBase
    {
		public ApiClientCustomerDeleteStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerDeleteContext context)
        {
            ExecuteNonQuery(context);

            Service.CacheRemove(context);
            // ExecuteNonQuery(context, Func<ApiClientCustomerDeleteRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerDeleteContext context)
        {
            await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerDeleteRequest, string> keySpecifier);
        }
    }
}