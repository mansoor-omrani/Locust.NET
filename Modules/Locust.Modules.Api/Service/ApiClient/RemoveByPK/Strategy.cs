using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientRemoveByPKStrategy : ApiClientRemoveByPKStrategyBase
    {
		public ApiClientRemoveByPKStrategy()
		{
			Init();
		}
		private void Initialize(ApiClientRemoveByPKContext context)
		{
		}
		private void Finalize(ApiClientRemoveByPKContext context)
		{
            Service.CacheRemove(context);
		}
		public override void Run(ApiClientRemoveByPKContext context)
        {
			// Initialize(context);
			
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<ApiClientRemoveByPKRequest, string> keySpecifier);
			
			Finalize(context);
        }

        public override async Task RunAsync(ApiClientRemoveByPKContext context)
        {
			// Initialize(context);
			
			await ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<ApiClientRemoveByPKRequest, string> keySpecifier);
			
			Finalize(context);
        }
    }
}