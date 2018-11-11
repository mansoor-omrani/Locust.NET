using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiCheckAccessStrategy : ApiCheckAccessStrategyBase
    {
		public ApiCheckAccessStrategy()
		{
			Init();
		}
		public override void Run(ApiCheckAccessContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<ApiCheckAccessRequest, string> keySpecifier);
        }

        public override Task RunAsync(ApiCheckAccessContext context)
        {
			return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<ApiCheckAccessRequest, string> keySpecifier);
        }
    }
}