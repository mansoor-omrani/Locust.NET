using System.Threading.Tasks;
using Locust.Caching;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingAddStrategy : AppSettingAddStrategyBase
    {
		public AppSettingAddStrategy(ICacheFactory iCacheFactory):base(iCacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingAddContext context)
        {
			ExecuteNonQuery(context);

            context.Response.Data = context.Response.Id;
            // ExecuteNonQuery(context, Func<AppSettingAddRequest, string> keySpecifier);
        }

        public override async Task RunAsync(AppSettingAddContext context)
        {
			await ExecuteNonQueryAsync(context);

            context.Response.Data = context.Response.Id;
            // return ExecuteNonQueryAsync(context, Func<AppSettingAddRequest, string> keySpecifier);
        }
    }
}