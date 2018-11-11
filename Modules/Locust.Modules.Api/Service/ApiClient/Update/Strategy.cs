using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientUpdateStrategy : ApiClientUpdateStrategyBase
    {
		public ApiClientUpdateStrategy()
		{
			Init();
		}
        public override void Run(ApiClientUpdateContext context)
        {
			ExecuteNonQuery(context);

            Service.CacheRemove(context);
            
            // ExecuteNonQuery(context, Func<ApiClientUpdateRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientUpdateContext context)
        {
			await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);

            // return ExecuteNonQueryAsync(context, Func<ApiClientUpdateRequest, string> keySpecifier);
        }
    }
}