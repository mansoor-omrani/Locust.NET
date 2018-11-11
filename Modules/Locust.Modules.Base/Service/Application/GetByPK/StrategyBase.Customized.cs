using Locust.Caching;
using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Setting;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationGetByPKStrategyBase : BabbageItemFetcherStrategy<ApplicationGetByPKResponse, Application.Full, ApplicationGetByPKStatus, ApplicationGetByPKRequest, ApplicationGetByPKContext>
    {
		protected void Init(ICacheFactory iCacheFactory, ISetting iSetting)
		{
			Cache = _iCacheFactory.Get(CacheName.App);
		}
    }
}