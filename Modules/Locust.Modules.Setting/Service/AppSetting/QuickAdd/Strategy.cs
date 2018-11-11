using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingQuickAddStrategy : AppSettingQuickAddStrategyBase
    {
		public AppSettingQuickAddStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingQuickAddContext context)
        {
            ExecuteNonQuery(context);

            context.Response.Data = context.Response.Id;

            // ExecuteNonQuery(context, Func<AppSettingQuickAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(AppSettingQuickAddContext context)
        {
            await ExecuteNonQueryAsync(context);

            context.Response.Data = context.Response.Id;
            
            // return ExecuteNonQueryAsync(context, Func<AppSettingQuickAddRequest, string> keySpecifier);
        }
    }
}