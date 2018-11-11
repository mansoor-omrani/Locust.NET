using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryAddStrategy : AppSettingCategoryAddStrategyBase
    {
		public AppSettingCategoryAddStrategy(ICacheFactory iCacheFactory):base(iCacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingCategoryAddContext context)
        {
			ExecuteNonQuery(context);

            context.Response.Data = context.Response.Id;
            // ExecuteNonQuery(context, Func<AppSettingCategoryAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(AppSettingCategoryAddContext context)
        {
			await ExecuteNonQueryAsync(context);

            context.Response.Data = context.Response.Id;
            // return ExecuteNonQueryAsync(context, Func<AppSettingCategoryAddRequest, string> keySpecifier);
        }
    }
}