using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubDeleteStrategy : ApiClientCustomerHubDeleteStrategyBase
    {
		public ApiClientCustomerHubDeleteStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerHubDeleteContext context)
        {
			ExecuteNonQuery(context);

            Service.CacheRemove(context);
			// ExecuteNonQuery(context, Func<ApiClientCustomerHubDeleteRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerHubDeleteContext context)
        {
			await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerHubDeleteRequest, string> keySpecifier);
        }
    }
}