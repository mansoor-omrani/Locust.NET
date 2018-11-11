using Locust.Caching;
using System;
using System.Threading.Tasks;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingDeleteStrategy : AppSettingDeleteStrategyBase
    {
		public AppSettingDeleteStrategy(ICacheFactory cacheFactory):base(cacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingDeleteContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<AppSettingDeleteRequest, string> keySpecifier);
        }

        public override Task RunAsync(AppSettingDeleteContext context)
        {
			return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<AppSettingDeleteRequest, string> keySpecifier);
        }
    }
}