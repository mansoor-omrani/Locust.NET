using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Setting;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationGetByPKStrategyBase : BabbageItemFetcherStrategy<ApplicationGetByPKResponse, Application.Full, ApplicationGetByPKStatus, ApplicationGetByPKRequest, ApplicationGetByPKContext>
    {
		protected ICacheFactory _iCacheFactory;
		protected ISetting _iSetting;
		
		public ApplicationGetByPKStrategyBase (ICacheFactory iCacheFactory, ISetting iSetting)
		{
			_iCacheFactory = iCacheFactory;
			_iSetting = iSetting;
			
			Init(iCacheFactory, iSetting);
		}

    }
}