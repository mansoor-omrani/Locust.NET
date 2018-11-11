using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingGetAllStrategyBase : BabbageListFetcherStrategy<AppSettingGetAllResponse, AppSettingGetAllStatus, AppSettingGetAllRequest, AppSettingGetAllContext, AppSetting>
    {
		protected ICacheFactory _iCacheFactory;
		
		
		public AppSettingGetAllStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init(iCacheFactory);
		}

    }
}