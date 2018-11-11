using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByKeyStrategy : ApiClientRemoveByKeyStrategyBase
    {
		public ApiClientRemoveByKeyStrategy()
		{
			Init();
		}
		private void Initialize(ApiClientRemoveByKeyContext context)
		{
		}
		private void Finalize(ApiClientRemoveByKeyContext context)
		{
            Service.CacheRemove(context);
		}
		public override void Run(ApiClientRemoveByKeyContext context)
        {
			// Initialize(context);
			
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<ApiClientRemoveByKeyRequest, string> keySpecifier);
			
			Finalize(context);
        }

        public override async Task RunAsync(ApiClientRemoveByKeyContext context)
        {
			// Initialize(context);
			
			await ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<ApiClientRemoveByKeyRequest, string> keySpecifier);
			
			Finalize(context);
        }
    }
}