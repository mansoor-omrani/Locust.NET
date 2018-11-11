using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingCategoryGetAllStrategyBase : BabbageListFetcherStrategy<AppSettingCategoryGetAllResponse, AppSettingCategoryGetAllStatus, AppSettingCategoryGetAllRequest, AppSettingCategoryGetAllContext, AppSettingCategory>
    {
		protected void Init(ICacheFactory iCacheFactory)
		{
		}

    }
}