using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingUpdateStrategyBase : BabbageDataManipulationStrategy<AppSettingUpdateResponse, object, AppSettingUpdateStatus, AppSettingUpdateRequest, AppSettingUpdateContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppSettingUpdateStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}