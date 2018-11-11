using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingCategoryUpdateStrategyBase : BabbageDataManipulationStrategy<AppSettingCategoryUpdateResponse, object, AppSettingCategoryUpdateStatus, AppSettingCategoryUpdateRequest, AppSettingCategoryUpdateContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppSettingCategoryUpdateStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}