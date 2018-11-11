using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using ApiSetting = Locust.Modules.Api.Model.ApiSetting;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiSettingGetAllByApiStrategyBase : BabbageListFetcherStrategy<ApiSettingGetAllByApiResponse, ApiSettingGetAllByApiStatus, ApiSettingGetAllByApiRequest, ApiSettingGetAllByApiContext, ApiSetting.Full>
    {
		protected ICacheFactory _iCacheFactory;
		
		
		public ApiSettingGetAllByApiStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}