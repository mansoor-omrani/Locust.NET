using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingAddStrategy : ServiceSettingAddStrategyBase
    {
		public ServiceSettingAddStrategy()
		{
			Init();
		}
		public override void Run(ServiceSettingAddContext context)
        {
			// ExecuteNonQuery(context);
			ExecuteNonQuery(context, (ctx) => ctx.Request.Service);
        }

        public override Task RunAsync(ServiceSettingAddContext context)
        {
			//return ExecuteNonQueryAsync(context);
			return ExecuteNonQueryAsync(context, (ctx) => ctx.Request.Service);
        }
    }
}