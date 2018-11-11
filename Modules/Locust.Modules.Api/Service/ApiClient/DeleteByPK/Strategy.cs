using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientDeleteByPKStrategy : ApiClientDeleteByPKStrategyBase
    {
		public ApiClientDeleteByPKStrategy()
		{
			Init();
		}
		private void Initialize(ApiClientDeleteByPKContext context)
		{
		}
		private void Finalize(ApiClientDeleteByPKContext context)
		{
            Service.CacheRemove(context);
		}
		public override void Run(ApiClientDeleteByPKContext context)
        {
			// Initialize(context);
			
			// ExecuteNonQuery(context);
			ExecuteNonQuery(context);
			
			Finalize(context);
        }

        public override async Task RunAsync(ApiClientDeleteByPKContext context)
        {
			// Initialize(context);
			
			// return ExecuteNonQueryAsync(context);
			await ExecuteNonQueryAsync(context);
			
			Finalize(context);
        }
    }
}