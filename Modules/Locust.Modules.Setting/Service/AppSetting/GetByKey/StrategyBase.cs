using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingGetByKeyStrategyBase : BabbageItemFetcherStrategy<AppSettingGetByKeyResponse, AppSetting, AppSettingGetByKeyStatus, AppSettingGetByKeyRequest, AppSettingGetByKeyContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppSettingGetByKeyStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init(iCacheFactory);
		}

    }
}