using Locust.Db;
using Locust.Logging;
using Locust.Modules.Setting.Strategies;
namespace Locust.Modules.Setting.Service
{
	public partial class AppSettingCategoryService : AppSettingCategoryServiceBase
    {
        public AppSettingCategoryService(AppSettingCategoryStrategyStore store,IExceptionLogger logger, IDbHelper db) : base(store, logger, db)
        {
			Init();
		}
    }
}