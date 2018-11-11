using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingQuickUpdateStrategy : AppSettingQuickUpdateStrategyBase
    {
		public AppSettingQuickUpdateStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingQuickUpdateContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<AppSettingQuickUpdateRequest, string> keySpecifier);
        }

        public override Task RunAsync(AppSettingQuickUpdateContext context)
        {
			return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<AppSettingQuickUpdateRequest, string> keySpecifier);
        }
    }
}