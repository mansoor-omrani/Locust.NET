using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerUpdateStrategy : ApiClientCustomerUpdateStrategyBase
    {
		public ApiClientCustomerUpdateStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerUpdateContext context)
        {
            ExecuteNonQuery(context);

            Service.CacheRemove(context);
            // ExecuteNonQuery(context, Func<ApiClientCustomerUpdateRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerUpdateContext context)
        {
            await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerUpdateRequest, string> keySpecifier);
        }
    }
}