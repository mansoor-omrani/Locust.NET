using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubUpdateStrategy : ApiClientCustomerHubUpdateStrategyBase
    {
		public ApiClientCustomerHubUpdateStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerHubUpdateContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<ApiClientCustomerHubUpdateRequest, string> keySpecifier);
            Service.CacheRemove(context);
        }

        public override async Task RunAsync(ApiClientCustomerHubUpdateContext context)
        {
			await ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<ApiClientCustomerHubUpdateRequest, string> keySpecifier);
            Service.CacheRemove(context);
        }
    }
}