using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryDeleteStrategy : AppSettingCategoryDeleteStrategyBase
    {
		public AppSettingCategoryDeleteStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingCategoryDeleteContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<AppSettingCategoryDeleteRequest, string> keySpecifier);
        }

        public override Task RunAsync(AppSettingCategoryDeleteContext context)
        {
			return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<AppSettingCategoryDeleteRequest, string> keySpecifier);
        }
    }
}