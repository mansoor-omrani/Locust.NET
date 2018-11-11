using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingCategoryGetByPKStrategyBase : BabbageItemFetcherStrategy<AppSettingCategoryGetByPKResponse, AppSettingCategory, AppSettingCategoryGetByPKStatus, AppSettingCategoryGetByPKRequest, AppSettingCategoryGetByPKContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppSettingCategoryGetByPKStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init(iCacheFactory);
		}

    }
}