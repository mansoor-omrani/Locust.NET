using Locust.Caching;
using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.Full;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginGetByPKStrategyBase : BabbageItemFetcherStrategy<AppCrossOriginGetByPKResponse, AppCrossOrigin, AppCrossOriginGetByPKStatus, AppCrossOriginGetByPKRequest, AppCrossOriginGetByPKContext>
    {
		protected void Init(ICacheFactory iCacheFactory)
		{
            Cache = _iCacheFactory.Get(CacheName.AppCrossOrigin);
        }
    }
}