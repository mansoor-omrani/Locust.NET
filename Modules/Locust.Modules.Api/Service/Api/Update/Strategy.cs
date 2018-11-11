using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiUpdateStrategy : ApiUpdateStrategyBase
    {
		public ApiUpdateStrategy():base()
		{
			Init();
		}
		public override void Run(ApiUpdateContext context)
        {
			ExecuteNonQuery(context);

            Service.CacheRemove(context);
			// ExecuteNonQuery(context, Func<ApiUpdateRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiUpdateContext context)
        {
			await ExecuteNonQueryAsync(context);

            Service.CacheRemove(context);
            // return ExecuteNonQueryAsync(context, Func<ApiUpdateRequest, string> keySpecifier);
        }
    }
}