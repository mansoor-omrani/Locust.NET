using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryUpdateStrategy : AppSettingCategoryUpdateStrategyBase
    {
		public AppSettingCategoryUpdateStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingCategoryUpdateContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<AppSettingCategoryUpdateRequest, string> keySpecifier);
        }

        public override Task RunAsync(AppSettingCategoryUpdateContext context)
        {
			return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<AppSettingCategoryUpdateRequest, string> keySpecifier);
        }
    }
}