using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientSaveApisStrategy : ApiClientSaveApisStrategyBase
    {
		public ApiClientSaveApisStrategy()
		{
			Init();
		}
		public override void Run(ApiClientSaveApisContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<ApiClientSaveApisRequest, string> keySpecifier);
        }

        public override Task RunAsync(ApiClientSaveApisContext context)
        {
			return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<ApiClientSaveApisRequest, string> keySpecifier);
        }
    }
}