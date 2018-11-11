using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingUpdateStrategy : AppSettingUpdateStrategyBase
    {
		public AppSettingUpdateStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingUpdateContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<AppSettingUpdateRequest, string> keySpecifier);
        }

        public override Task RunAsync(AppSettingUpdateContext context)
        {
			return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<AppSettingUpdateRequest, string> keySpecifier);
        }
    }
}