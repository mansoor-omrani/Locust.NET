using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiDeleteStrategy : ApiDeleteStrategyBase
    {
		public ApiDeleteStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(ApiDeleteContext context)
        {
			ExecuteNonQuery(context);

            Service.CacheRemove(context);
            // ExecuteNonQuery(context, Func<ApiDeleteRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiDeleteContext context)
        {
			await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);
            // return ExecuteNonQueryAsync(context, Func<ApiDeleteRequest, string> keySpecifier);
        }
    }
}