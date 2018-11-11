using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingDeleteStrategy : ServiceSettingDeleteStrategyBase
    {
		public ServiceSettingDeleteStrategy()
		{
			Init();
		}
		public override void Run(ServiceSettingDeleteContext context)
        {
			// ExecuteNonQuery(context);
			ExecuteNonQuery(context, ctx => ctx.Response.Service);
        }

        public override Task RunAsync(ServiceSettingDeleteContext context)
        {
			// return ExecuteNonQueryAsync(context);
			return ExecuteNonQueryAsync(context, ctx => ctx.Response.Service);
        }
    }
}