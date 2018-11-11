using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Setting.Model;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public abstract partial class AppSettingGetByKeyStrategyBase : BabbageItemFetcherStrategy<AppSettingGetByKeyResponse, AppSetting, AppSettingGetByKeyStatus, AppSettingGetByKeyRequest, AppSettingGetByKeyContext>
    {
		protected void Init(ICacheFactory iCacheFactory)
		{
		}
    }
}