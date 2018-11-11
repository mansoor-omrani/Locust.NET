using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByKeyStrategy : ApiClientDeleteByKeyStrategyBase
    {
		public ApiClientDeleteByKeyStrategy()
		{
			Init();
		}
		private void Initialize(ApiClientDeleteByKeyContext context)
		{
		}
		private void Finalize(ApiClientDeleteByKeyContext context)
		{
		    Service.CacheRemove(context);
		}
		public override void Run(ApiClientDeleteByKeyContext context)
        {
			// Initialize(context);
			
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<ApiClientDeleteByKeyRequest, string> keySpecifier);
			
			Finalize(context);
        }

        public override async Task RunAsync(ApiClientDeleteByKeyContext context)
        {
			// Initialize(context);
			
			await ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<ApiClientDeleteByKeyRequest, string> keySpecifier);
			
			Finalize(context);
        }
    }
}