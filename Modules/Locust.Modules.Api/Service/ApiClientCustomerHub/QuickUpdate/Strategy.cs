using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubQuickUpdateStrategy : ApiClientCustomerHubQuickUpdateStrategyBase
    {
		public ApiClientCustomerHubQuickUpdateStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerHubQuickUpdateContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<ApiClientCustomerHubQuickUpdateRequest, string> keySpecifier);
            Service.CacheRemove(context);
        }

        public override async Task RunAsync(ApiClientCustomerHubQuickUpdateContext context)
        {
			await ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<ApiClientCustomerHubQuickUpdateRequest, string> keySpecifier);
            Service.CacheRemove(context);
        }
    }
}