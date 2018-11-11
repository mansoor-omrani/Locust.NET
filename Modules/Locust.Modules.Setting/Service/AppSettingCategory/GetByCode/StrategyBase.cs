using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingCategoryGetByCodeStrategyBase : BabbageItemFetcherStrategy<AppSettingCategoryGetByCodeResponse, AppSettingCategory, AppSettingCategoryGetByCodeStatus, AppSettingCategoryGetByCodeRequest, AppSettingCategoryGetByCodeContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppSettingCategoryGetByCodeStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init(iCacheFactory);
		}

    }
}