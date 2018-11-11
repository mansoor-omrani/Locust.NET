using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiAddStrategy : ApiAddStrategyBase
    {
		public ApiAddStrategy():base()
		{
			Init();
		}
		public override void Run(ApiAddContext context)
        {
			ExecuteNonQuery(context);

            context.Response.Data = context.Response.Id;
            // ExecuteNonQuery(context, Func<ApiAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiAddContext context)
        {
			await ExecuteNonQueryAsync(context);

            context.Response.Data = context.Response.Id;
            // return ExecuteNonQueryAsync(context, Func<ApiAddRequest, string> keySpecifier);
        }
    }
}